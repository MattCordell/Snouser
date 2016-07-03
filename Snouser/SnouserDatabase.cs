using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.IO.Compression;


namespace Snouser
{
    class SnouserDatabase
    {
        const string dbFile = "Snouser.db";
        private string connString = "data source=" + dbFile + ";Version=3;Cache Size=10000;Page Size=4096;Synchronous=NORMAL;Journal Mode=WAL;";

        public void CreateNewDb()
        {
            if (File.Exists(dbFile))
            {
                File.Delete(dbFile);
            }
            
            SQLiteConnection.CreateFile(dbFile);

            // SnouserDB only uses a description table.
            ExecuteNonQuery(@"DROP TABLE IF EXISTS import_descriptions;
                              CREATE TABLE import_descriptions ( id LONG, effectiveTime INTEGER, active INTEGER, moduleId LONG, conceptId LONG, languageCode TEXT, typeId LONG, term TEXT, caseSignificanceId LONG);");
        }

        #region Database helper classes
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

        public void ImportData(string zipPath)
        {
            string temp = Directory.GetCurrentDirectory() + @"\temp\";
            if (Directory.Exists(temp))
            {
                Directory.Delete(temp, true);
            }

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {

                archive.ExtractToDirectory(temp);
                //find the RF2 delta directory (only expecting one!)
                //string directory = Directory.GetDirectories("tempExtract", @"RF2Release\Delta\Terminology").FirstOrDefault()
                string file = Directory.GetFiles(temp, "*Description_Delta*.txt", System.IO.SearchOption.AllDirectories).FirstOrDefault();

                tablePump(file);
                                
            }

            //clean up temp directory
            if (Directory.Exists(temp))
            {
                Directory.Delete(temp, true);
            }
        }

        private void tablePump(string inFile)
        {
            using (TextReader tr = File.OpenText(inFile))
            {
                using (SQLiteConnection cnn = new SQLiteConnection(connString))
                {
                    string line;
                    string insertCommand = "INSERT INTO import_descriptions VALUES (@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)";
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

            string q1 = @"CREATE VIRTUAL TABLE FTSsearcher USING FTS4(conceptId, active,typeId,term, tokenize=porter);";
            string q2 = @"INSERT INTO FTSsearcher SELECT conceptId, active,typeId,term from import_descriptions;";
            ExecuteNonQuery(q1);
            ExecuteNonQuery(q2);
        }

    }

}
