using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Represents DB file.
    /// </summary>
    public static class DBFile
    {
        const string SysTable = "sqlite_sequence";
        static string _name = string.Empty, _path = string.Empty;
        static List<string> _tbls = null!;

        public static bool IsOpen { get; private set; }
        public static List<string> Tables 
        {
            get
            {
                DBException.ThrowIfDBFileIsNotOpened("Names");
                return _tbls;
            }
            private set => _tbls = value;
        }

        public static void Open(string name)
        {
            InternalOpen(name);
            DBException.ThrowIfDBFileNotCreated(_path);
            Tables = [];
            DBProvider.Provide(_name);
            NamesRead();
        }

        public static void Close()
        {
            InternalClose();
            DBProvider.EndProviding();
            Tables = null!;
        }

        public static bool Create(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Database file name file null or emtpy!");
            InternalOpen(name);

            if (File.Exists(_name))
                DBException.WrMSG("Database with entered name already exists!");
            else
            {
                try
                {
                    File.Create(_name).Dispose();
                    InternalClose();
                    return true;
                }
                catch (Exception ex) 
                    { DBException.ErrMSG(ex.Message); }
            }

            InternalClose();
            return false;
        }

        public static bool MoveExternal(FileInfo external)
        {
            DBException.ThrowIfStringIsEmpty(external.Name, "External file name was null or empty!");
            InternalOpen(external.Name);

            if (File.Exists(_name))
                DBException.WrMSG("Database with entered name already exists!");
            else
            {
                try
                {
                    File.Move(external.FullName, _name);
                    InternalClose();
                    return true;
                }
                catch (Exception ex)
                    { DBException.ErrMSG(ex.Message); }
            }

            InternalClose();
            return false;
        }

        public static bool Drop(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Database file name was null or empty");
            InternalOpen(name);

            if (!File.Exists(_name))
                DBException.WrMSG("Database with entered name doesn't exists!");
            else
            {
                try
                {
                    File.Delete(_name);
                    InternalClose();
                    return true;
                }
                catch (Exception ex)
                    { DBException.ErrMSG(ex.Message); }
            }

            InternalClose();
            return false;
        }

        public static bool CreateTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_name);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");

            if (TableIsExist(name))
            {
                DBException.WrMSG("Table name was empty or already exists!");
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"CREATE TABLE '{name}' (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));"))
                return NamesRead();
            return false;
        }

        public static bool DropTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_name);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty");

            if (!TableIsExist(name))
            {
                DBException.WrMSG("Table name was empty or doesn't exists!");
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"DROP TABLE {name}"))
                return NamesRead(true);
            return false;
        }

        public static string GetTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_name);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty");
            if (TableIsExist(name))
                return Tables.Where(i => i == name).FirstOrDefault()!;
            return null!;
        }

        static void InternalOpen(string name)
        {
            DBException.ThrowIfDBFileOpened(_name);
            _name = name;
            _path = DBRoot.Localize(ref _name);
            IsOpen = true;
        }

        static void InternalClose()
        {
            DBException.ThrowIfDBFileIsNotOpened(_name);
            _name = string.Empty;
            IsOpen = false;
        }

        static bool NamesRead(bool clear = false)
        {
            DBException.ThrowIfDBFileIsNotOpened(_name);

            try
            {
                var rdr = DBProvider.ExecuteReaderCmd("SELECT name FROM sqlite_master WHERE type='table'");
                if (clear) 
                    Tables.Clear();

                while (rdr.Read())
                    if (rdr.GetString(0) != SysTable && !TableIsExist(rdr.GetString(0)))
                    {
                        var i = TableInfo(rdr.GetString(0)).GetValues().GetValues(2);
                        Tables.Add(rdr.GetString(0));
                        
                    }
                return true;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                return false;
            }
        }

        static SQLiteDataReader TableInfo(string name)
        {
            try
            {
                return DBProvider.ExecuteReaderCmd($"PRAGMA table_info('{name}')");
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                throw;
            }
        }

        static bool TableIsExist(string name) => Tables.Any(i => i == name);
    }
}
