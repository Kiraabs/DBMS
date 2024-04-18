using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SQLLiteLibrary
{   
    /// <summary>
    /// Представляет файл БД.
    /// </summary>
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
            try
            {
                Connect();
                var sqlc = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table'", cnn);
                var ex = sqlc.ExecuteReader();
                var l = new List<string>();

                while (ex.Read())
                {
                    if (ex.GetString(0) != "sqlite_sequence")
                    {
                        l.Add(ex.GetString("name"));
                    }
                }

                Disconnect();
                return l;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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

        public (string[] names, string[] vals) TableScheme(string name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    Connect();
                    var sqlc = new SQLiteCommand($"PRAGMA table_info('{name}')", cnn);
                    var ex = sqlc.ExecuteReader();
                    var names = new string[ex.FieldCount];
                    var vals = new string[ex.FieldCount];

                    while (ex.Read())
                    {
                        for (int i = 0; i < ex.FieldCount; i++)
                        {
                            names[i] = ex.GetName(i);
                            vals[i] = ex.GetValue(i).ToString()!;
                        }
                    }

                    Disconnect();
                    return (names, vals);
                }

                return (null!, null!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool Connect()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                try
                {
                    cnn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }

            return false;
        }

        public bool Disconnect()
        {
            if (cnn.State == ConnectionState.Open)
            {
                try
                {
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }

            return false;
        }
    }
}
