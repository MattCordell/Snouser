using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Snouser
{
    class SnouserDatabase
    {
        private SQLiteConnection db = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

        private void ExecuteQuery(string txtQuery)
        {
            using (db.Open())
            {
                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = txtQuery;
                cmd.ExecuteNonQuery();
            }
            
        }
            

    }
}
