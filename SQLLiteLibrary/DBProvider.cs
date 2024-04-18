using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SQLLiteLibrary
{
    public class DBProvider
    {
        readonly string pathToDBFile;
        readonly SQLiteConnection cnn = null!;

        public DBProvider(string pathToDBFile)
        {
            if (string.IsNullOrWhiteSpace(pathToDBFile))
            {
                throw new ArgumentNullException(nameof(pathToDBFile), "Requires path to DB");
            }

            this.pathToDBFile = $"Data Source={pathToDBFile}";
            cnn = new SQLiteConnection(this.pathToDBFile);
            
        }

        public List<string> ReadTablesDB()
        {
            Connect();
            var sqlc = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table'", cnn);
            var ex = sqlc.ExecuteReader();
            var l = new List<string>();

            while (ex.Read())
            {
                l.Add(ex.GetString(0));
            }

            Disconnect();
            return l;
        }

        public bool Connect()
        {
            if (cnn.State == ConnectionState.Closed) 
            {
                cnn.Open();
                return true;
            }

            return false;
        }

        public bool Disconnect()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                return true;
            }

            return false;
        }
    }
}
