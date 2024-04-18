using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SQLLiteLibrary
{
    public class DBFile
    {
        readonly string pathToDBFile;
        readonly SQLiteConnection cnn = null!;

        public DBFile(string pathToDBFile)
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
                l.Add(ex.GetString("name"));
            }

            Disconnect();
            return l;
        }

        public bool TableIsExist(string name)
        {
            return ReadTablesDB().Contains(name);
        }

        public bool CreateTable(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    Connect();
                    var sqlc = new SQLiteCommand
                    (
                        $"CREATE TABLE {name} (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));", cnn
                    );
                    sqlc.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public bool DropTable(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && TableIsExist(name))
            {
                try
                {
                    Connect();
                    var sqlc = new SQLiteCommand
                    (
                        $"DROP TABLE {name}", cnn
                    );
                    sqlc.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
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
