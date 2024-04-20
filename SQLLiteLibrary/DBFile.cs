using System.Data;
using System.Data.SQLite;
using System.Xml.Linq;

namespace SQLLiteLibrary
{   
    /// <summary>
    /// Represents DB file.
    /// </summary>
    public static class DBFile
    {
        static string _name = string.Empty;
        static List<string> _tbls = null!;
        public static bool IsOpen { get; private set; }
        public static List<string> Tables 
        {
            get
            {
                ThrowIfNotOpened("Tables");
                return _tbls;
            }
            private set => _tbls = value;
        }

        public static void Open(string name)
        {
            InnerOpen(name);
            ThrowIfNotCreated();
            Tables = [];
            DBProvider.Provide(_name);
            ReadWriteTables();
        }

        public static void Close()
        {
            InnerClose();
            DBProvider.EndProviding();
            Tables = null!;
        }

        public static bool Create(string name)
        {
            ThrowIfEmpty(name);
            InnerOpen(name);

            if (File.Exists(_name))
            {
                MessageBox.Show
                (
                    "Database with entered name already exists!",
                    "Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            try
            {
                File.Create(_name).Dispose();
                InnerClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        public static bool Drop(string name)
        {
            ThrowIfEmpty(name);
            InnerOpen(name);

            if (!File.Exists(_name))
            {
                MessageBox.Show
                (
                    "Database with entered name doesn't exists!",
                    "Not exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            try
            {
                File.Delete(_name);
                InnerClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        //public (string[] names, string[] vals) TableScheme(string name)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(name))
        //        {
        //            Connect();
        //            var sqlc = new SQLiteCommand($"PRAGMA table_info('{name}')", _cnn);
        //            var ex = sqlc.ExecuteReader();
        //            var names = new string[ex.FieldCount];
        //            var vals = new string[ex.FieldCount];

        //            while (ex.Read())
        //            {
        //                for (int i = 0; i < ex.FieldCount; i++)
        //                {
        //                    names[i] = ex.GetName(i);
        //                    vals[i] = ex.GetValue(i).ToString()!;
        //                }
        //            }

        //            Disconnect();
        //            return (names, vals);
        //        }

        //        return (null!, null!);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        throw;
        //    }
        //}

        public static bool CreateTable(string name)
        {
            ThrowIfEmpty(name);
            ThrowIfNotOpened();

            if (TableIsExist(name))
            {
                MessageBox.Show
                (
                    "Table name was empty or already exists!",
                    "Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"CREATE TABLE {name} (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));"))
                return ReadWriteTables();

            return false;
        }

        public static bool DropTable(string name)
        {
            ThrowIfEmpty(name);
            ThrowIfNotOpened();

            if (!TableIsExist(name))
            {
                MessageBox.Show
                (
                    "Table name was empty or doesn't exists!",
                    "Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"DROP TABLE {name}"))
                return ReadWriteTables(true);

            return false;
        }

        static void InnerOpen(string name)
        {
            ThrowIfOpened();
            _name = name;
            DBRoot.Localize(ref _name);
            IsOpen = true;
        }

        static void InnerClose()
        {
            ThrowIfNotOpened();
            _name = string.Empty;
            IsOpen = false;
        }

        static bool ReadWriteTables(bool clr = false)
        {
            ThrowIfNotOpened();

            try
            {
                var rdr = DBProvider.ExecuteReaderCmd("SELECT name FROM sqlite_master WHERE type='table'");
                if (clr) Tables.Clear();

                while (rdr.Read())
                {
                    if (rdr.GetString(0) != "sqlite_sequence" && !Tables.Contains(rdr.GetString(0)))
                    {
                        Tables.Add(rdr.GetString(0));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static bool TableIsExist(string name) => Tables.Contains(name);

        static void ThrowIfEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name was empty!");
        }
        static void ThrowIfNotOpened(object? sender = null)
        {
            if (string.IsNullOrWhiteSpace(_name))
                throw new ArgumentException($"File wasn't opened! Source: {sender?.ToString()}");
        }
        static void ThrowIfOpened(object? sender = null)
        {
            if (!string.IsNullOrWhiteSpace(_name))
                throw new ArgumentException($"File already opened! Source: {sender?.ToString()}");
        }
        static void ThrowIfNotCreated()
        {
            if (!File.Exists(_name))
                throw new ArgumentException("File wasn't exists!");
        }
    }
}
