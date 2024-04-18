using System.Data;
using System.Data.SQLite;

namespace SQLLiteLibrary
{   
    /// <summary>
    /// Represents DB file.
    /// </summary>
    public partial class DBFile
    {
        readonly string _path;
        readonly SQLiteConnection _cnn;
        readonly List<string> _tables = [];
        SQLiteCommand? _cmd;
        SQLiteDataReader? _rdr;

        public List<string> Tables { get => _tables; }

        public DBFile(string dbFilePath)
        {
            if (string.IsNullOrWhiteSpace(dbFilePath))
            {
                throw new ArgumentNullException(nameof(dbFilePath), "Requires path to DB!");
            }

            _path = $"Data Source={dbFilePath}";
            _cnn = new SQLiteConnection(_path);
            ReadWriteTables();
        }

        ~DBFile()
        {
            _cnn.Dispose();
            _cmd!.Dispose();
            _rdr!.Dispose(); // never null, stupid VS
        }

        public bool CreateTable(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (TableIsExist(name))
                {
                    MessageBox.Show
                    (
                        "Table with entered name already exists!", 
                        "Exists", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning
                    );

                    return false;
                }

                try
                {
                    Connect();
                    _cmd = new SQLiteCommand
                    (
                        $"CREATE TABLE {name} (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));", _cnn
                    );
                    _cmd.ExecuteNonQuery();
                    Disconnect();
                    ReadWriteTables();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        public bool DropTable(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && TableIsExist(name)) // last con-on - just in case
            {
                try
                {
                    Connect();
                    _cmd = new SQLiteCommand($"DROP TABLE {name}", _cnn); 
                    _cmd.ExecuteNonQuery();
                    Disconnect();
                    ReadWriteTables(true);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        public (string[] names, string[] vals) TableScheme(string name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    Connect();
                    var sqlc = new SQLiteCommand($"PRAGMA table_info('{name}')", _cnn);
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

        void ReadWriteTables(bool clr = false)
        {
            try
            {
                Connect();
                _cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table'", _cnn);
                _rdr = _cmd.ExecuteReader();
                if (clr) _tables.Clear();

                while (_rdr.Read())
                {
                    if (!_tables.Contains(_rdr.GetString(0)))
                    {
                        _tables.Add(_rdr.GetString(0));
                    }
                }

                Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        bool Connect()
        {
            if (_cnn.State == ConnectionState.Closed) 
            {
                try
                {
                    _cnn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        bool Disconnect()
        {
            if (_cnn.State == ConnectionState.Open)
            {
                try
                {
                    _cnn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        bool TableIsExist(string name) => _tables.Contains(name);
    }
}
