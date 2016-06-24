using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Snouser
{
    class SnouserDatabase
    {
        private string connString = "Data Source=Snouser.db;Version=3;";

        // Basic db helper classes

        private void ExecuteQuery(string txtQuery)
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
            using (SQLiteConnection cnn = new SQLiteConnection(connString))
            {
                cnn.Open();
                SQLiteCommand cmd = cnn.CreateCommand();
                cmd.CommandText = txtQuery;
                return cmd.ExecuteScalar().ToString();
            }
        }

        private DataTable QueryResultSet(string txtQuery)
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection cnn = new SQLiteConnection(connString))
            {
                cnn.Open();
                SQLiteCommand cmd = cnn.CreateCommand();
                cmd.CommandText = txtQuery;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                rdr.Close();
            }
            return dt;
        }





    }
}
