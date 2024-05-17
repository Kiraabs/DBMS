using System.Data;

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

        public static void Close()
        {
            InternalClose();
            DBProvider.EndProviding();
            Tables = null!;
        }

        public static void Open(string name)
        {
            InternalOpen(name);
            DBException.ThrowIfDBFileNotCreated(_path);
            Tables = [];
            DBProvider.Provide(_path);
            ReadTables();
        }

        public static bool Create(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Database file name file null or empty!");
            InternalOpen(name);
            if (UserMSG.WarnIfTrue("Database file with entered name already exists!", File.Exists(_path)).True)
                return false;
            return FileAction(() => File.Create(_path).Dispose());
        }

        public static bool MoveExternal(FileInfo external)
        {
            DBException.ThrowIfStringIsEmpty(external.Name, "External file name was null or empty!");
            InternalOpen(external.Name);
            if (UserMSG.WarnIfTrue("Database file with external name already exists!", File.Exists(_path)).True)
                return false;
            return FileAction(() => File.Move(external.FullName, _path));
        }

        public static bool Drop(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Database file name was null or empty");
            InternalOpen(name);
            if (UserMSG.WarnIfTrue("Database with entered name doesn't exists!", !File.Exists(_path)).True)
                return false;
            return FileAction(() => File.Delete(_path));
        }

        public static bool CreateTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_path);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            if (UserMSG.WarnIfTrue("Table name was empty or already exists!", TableIsExist(name)).True)
                return false;

            if (DBProvider.ExecuteSimpleCmd($"CREATE TABLE '{name}' (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));"))
                return ReadTables();
            return false;
        }

        public static bool DropTable(string name)
        {
            DBException.ThrowIfDBFileIsNotOpened(_path);
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty");
            if (UserMSG.WarnIfTrue("Table name was empty or doesn't exists!", !TableIsExist(name)).True)
                return false;

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

        static bool FileAction(Action action)
        {
            try
            {
                action();
                InternalClose();
                return true;
            }
            catch (Exception ex) 
            { 
                UserMSG.Error(ex.Message);
                InternalClose();
                return false;
            }
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
                UserMSG.Error(ex.Message);
                return false;
            }
        }

        static bool TableIsExist(string name) => Tables.Any(i => i.TableName == name);
    }
}
