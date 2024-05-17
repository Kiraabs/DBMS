using System.Data;
using System.Xml.Linq;

namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Represents DB file.
    /// </summary>
    public static class DBFile
    {
        const string SysTable = "sqlite_sequence";
        static string _name = string.Empty, _path = string.Empty;
        static List<DBTable> _tbls = null!;

        public static bool IsOpen { get; private set; }
        public static List<DBTable> Tables 
        {
            get
            {
                DBException.ThrowIfDBFileIsNotOpened("Tables");
                return _tbls;
            }
            private set => _tbls = value;
        }

        public static void Open(string name)
        {
            InternalOpen(name);
            DBException.ThrowIfDBFileNotCreated(_path);
            Tables = [];
            DBProvider.Provide(_path);
            ReadTables();
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

            if (File.Exists(_path))
                DBException.WrMSG("Database with entered name already exists!");
            else
            {
                try
                {
                    File.Create(_path).Dispose();
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

            if (File.Exists(_path))
                DBException.WrMSG("Database with entered name already exists!");
            else
            {
                try
                {
                    File.Move(external.FullName, _path);
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

            if (!File.Exists(_path))
                DBException.WrMSG("Database with entered name doesn't exists!");
            else
            {
                try
                {
                    File.Delete(_path);
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
            DBException.ThrowIfDBFileIsNotOpened(_path);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");

            if (TableIsExist(name))
            {
                DBException.WrMSG("Table name was empty or already exists!");
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"CREATE TABLE '{name}' (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));"))
                return ReadTables();
            return false;
        }

        public static bool DropTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_path);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty");

            if (!TableIsExist(name))
            {
                DBException.WrMSG("Table name was empty or doesn't exists!");
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"DROP TABLE '{name}'"))
                return ReadTables(true);
            return false;
        }

        public static DBTable GetTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_path);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty");
            if (TableIsExist(name))
                return Tables.Where(i => i.TableName == name).FirstOrDefault()!;
            return null!;
        }



        static void InternalOpen(string name)
        {
            DBException.ThrowIfDBFileOpened(_path);
            _name = name;
            _path = DBRoot.Localize(_name);
            IsOpen = true;
        }

        static void InternalClose()
        {
            DBException.ThrowIfDBFileIsNotOpened(_path);
            _name = string.Empty;
            _path = string.Empty;
            IsOpen = false;
        }

        static bool ReadTables(bool clear = false)
        {
            DBException.ThrowIfDBFileIsNotOpened(_path);

            try
            {
                var rdr = DBProvider.ExecuteReaderCmd("SELECT name FROM sqlite_master WHERE type='table'");
                if (clear) 
                    Tables.Clear();

                while (rdr.Read())
                    if (rdr.GetString(0) != SysTable && !TableIsExist(rdr.GetString(0)))
                        Tables.Add(new DBTable([string.Empty, _name, rdr.GetString(0)]));

                return true;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                return false;
            }
        }

        static bool TableIsExist(string name) => Tables.Any(i => i.TableName == name);
    }
}
