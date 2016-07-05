using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Snouser
{

    enum RF2format { Full, Snapshot, Delta};

    class SnouserDatabase
    {
        const string dbFile = "Snouser.db";
        private string connString = "data source=" + dbFile + ";Version=3;Cache Size=10000;Page Size=4096;Synchronous=NORMAL;Journal Mode=WAL;";

        public SnouserDatabase()
        {
            //if the database doesn't exist, initialise.
            //default is March release
            if (!File.Exists(dbFile))
            {
                CreateNewDb();
            }
        }

        private void CreateNewDb()
        {
            if (File.Exists(dbFile))
            {
                File.Delete(dbFile);
            }
            
            SQLiteConnection.CreateFile(dbFile);

            // SnouserDB only uses a description table.
            ExecuteNonQuery(@"DROP TABLE IF EXISTS import_descriptions;
                              CREATE TABLE import_descriptions ( id LONG, effectiveTime INTEGER, active INTEGER, moduleId LONG, conceptId LONG, languageCode TEXT, typeId LONG, term TEXT, caseSignificanceId LONG);");
            ExecuteNonQuery(@"DROP TABLE if exists FTSsearcher
                              CREATE VIRTUAL TABLE FTSsearcher USING FTS4(conceptId, active,typeId,term, tokenize=porter);");
            // Table to track versions imported into the system
            ExecuteNonQuery(@"DROP TABLE IF EXISTS updateLog;
                              CREATE TABLE updateLog ( vURI TEXT, logTime TEXT);");

            ImportZip(@"C:\Users\MatthewCordell\Downloads\NCTS_SCT_RF2_DISTRIBUTION_32506021000036107-20160331-FULL.zip", "http://snomed.info/sct/32506021000036107/version/20160331");

        }

        #region Database helper methods
        private void ExecuteNonQuery(string txtQuery)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(connString))
            {
                cnn.Open();
                SQLiteCommand cmd = cnn.CreateCommand();
                cmd.CommandText = txtQuery;
                cmd.ExecuteNonQuery();
            }            
        }

        private string QueryValue(string txtQuery)
        {
            object value = null;

            using (SQLiteConnection cnn = new SQLiteConnection(connString))
            {
                cnn.Open();
                SQLiteCommand cmd = cnn.CreateCommand();
                cmd.CommandText = txtQuery;
                value = cmd.ExecuteScalar();
            }
            if (value != null)
            {
                return value.ToString();
            }
            else return "";
        }

        private DataTable QueryResultSet(string txtQuery)
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection cnn = new SQLiteConnection(connString))
            {
                cnn.Open();
                SQLiteCommand cmd = cnn.CreateCommand();
                cmd.CommandText = txtQuery;
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    dt.Load(rdr);
                    rdr.Close();
                }                                
            }
            return dt;
        }

        #endregion

        public void ImportZip(string zipPath, string versionURI)
        {            
            string temp = Directory.GetCurrentDirectory() + @"\temp\";
            if (Directory.Exists(temp))
            {
                Directory.Delete(temp, true);
            }
            else
            {
                Directory.CreateDirectory(temp);
            }

            Uri zipUri = new Uri(zipPath);
            
            using (var client = new WebClient())
            {
                //bit of debug code to accept self signed certs.
                //change to alternative, with specific conditions,
                #if DEBUG
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;
                #endif
                client.DownloadFile(zipUri, temp + @"patch.zip");              
            }

            using (ZipArchive archive = ZipFile.OpenRead(temp + @"patch.zip"))
            {

                archive.ExtractToDirectory(temp);
                //find the RF2 delta directory (only expecting one!)             
                string file = Directory.GetFiles(temp, "*Description_*.txt", System.IO.SearchOption.AllDirectories).FirstOrDefault();

                tablePump(file);

            }

            //clean up temp directory
            if (Directory.Exists(temp))
            {
                Directory.Delete(temp, true);
            }

            //log the version just imported
            UpdateVersionLog(versionURI);
        }

        private void UpdateVersionLog(string versionURI)
        {
            string insertCommand = String.Format("INSERT INTO updateLog VALUES (\"{0}\",\"{1}\");", versionURI, DateTime.Now.ToString());
            ExecuteNonQuery(insertCommand);            
        }

        public string GetCurrentTerminologyVersionUsed()
        {
            string q = "select vURI from updateLog order by logTime desc limit 1;";

            return QueryValue(q);
        }

        public string GetLastUpdateTime()
        {
            string q = "select logTime from updateLog order by logTime desc limit 1;";

            return QueryValue(q);    
        }

        //basic pump, just loads into descriptions file.
        private void tablePump(string inFile)
        {
            using (TextReader tr = File.OpenText(inFile))
            {
                using (SQLiteConnection cnn = new SQLiteConnection(connString))
                {
                    string line;
                    string insertCommand = "INSERT INTO import_descriptions VALUES (@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8); "+
                                           "INSERT INTO FTSsearcher VALUES (@P4, @P2,@P6,@P7);";
                    cnn.Open();
                    SQLiteCommand mycommand = new SQLiteCommand("begin", cnn);
                    mycommand.ExecuteNonQuery();

                    mycommand.CommandText = insertCommand;

                    //munge the first line (header)
                    line = tr.ReadLine();

                    while ((line = tr.ReadLine()) != null)
                    {
                        string[] csv = line.Split('\t');

                        mycommand.Parameters.AddWithValue("@P0", csv[0]);
                        mycommand.Parameters.AddWithValue("@P1", csv[1]);
                        mycommand.Parameters.AddWithValue("@P2", csv[2]);
                        mycommand.Parameters.AddWithValue("@P3", csv[3]);
                        mycommand.Parameters.AddWithValue("@P4", csv[4]);
                        mycommand.Parameters.AddWithValue("@P5", csv[5]);
                        mycommand.Parameters.AddWithValue("@P6", csv[6]);
                        mycommand.Parameters.AddWithValue("@P7", csv[7]);
                        mycommand.Parameters.AddWithValue("@P8", csv[8]);

                        mycommand.ExecuteNonQuery();
                    }

                    mycommand.CommandText = "end";
                    mycommand.ExecuteNonQuery();
                }
            }            
        }

        // returns search results from input string
        public DataTable PerformSearch(string searchString)
        {
            //improve the magic here
            StringBuilder s = new StringBuilder();
            foreach (var token in searchString.Split(' '))
            {
                s.Append(token).Append("* ");
            }


            string searchQuery = String.Format("select * from FTSsearcher where term match '{0}' limit 10;",s.ToString());

            return QueryResultSet(searchQuery);
        }
    }

}
