using System.Collections.ObjectModel;
using System.Data.Common;

namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Represents DB file.
    /// </summary>
    public static class DBFile
    {
        static string _name = string.Empty;
        static List<DBTable> _tbls = null!;

        public static bool IsOpen { get; private set; }
        public static List<DBTable> Tables 
        {
            get
            {
                ThrowIfNotOpened("Names");
                return _tbls;
            }
            private set => _tbls = value;
        }

        public static void Open(string name)
        {
            InternalOpen(name);
            ThrowIfNotCreated();
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
            ThrowIfEmpty(name);
            InternalOpen(name);

            if (File.Exists(_name))
            {
                AlreadyExistsMSG();
                return false;
            }

            try
            {
                File.Create(_name).Dispose();
                InternalClose();
            }
            catch (Exception ex)
            {
                ErrMSG(ex.Message);
                return false;
            }

            return true;
        }

        public static bool MoveExternal(FileInfo external)
        {
            if (external == null)
                throw new ArgumentException("External file was null!");

            ThrowIfEmpty(external.Name);
            InternalOpen(external.Name);

            if (File.Exists(_name))
            {
                AlreadyExistsMSG();
                return false;
            }

            try
            {
                File.Move(external.FullName, _name); 
                InternalClose();
            }
            catch (Exception ex)
            {
                ErrMSG(ex.Message);
                return false;
            }

            return true;
        }

        public static bool Drop(string name)
        {
            ThrowIfEmpty(name);
            InternalOpen(name);

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
                InternalClose();
            }
            catch (Exception ex)
            {
                ErrMSG(ex.Message);
                return false;
            }

            return true;
        }

        public static bool CreateTable(string name)
        {
            ThrowIfNotOpened();
            ThrowIfEmpty(name);

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

            if (DBProvider.ExecuteSimpleCmd($"CREATE TABLE '{name}' (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));"))
                return NamesRead();

            return false;
        }

        public static bool DropTable(string name)
        {
            ThrowIfNotOpened();
            ThrowIfEmpty(name);

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
                return NamesRead(true);

            return false;
        }

        public static DBTable GetTable(string name)
        {
            ThrowIfNotOpened();
            ThrowIfEmpty(name);
            if (TableIsExist(name))
                return Tables.Where(i => i.Name == name).FirstOrDefault()!;

            return null!;
        }

        static void InternalOpen(string name)
        {
            ThrowIfOpened();
            _name = name;
            DBRoot.Localize(ref _name);
            IsOpen = true;
        }

        static void InternalClose()
        {
            ThrowIfNotOpened();
            _name = string.Empty;
            IsOpen = false;
        }

        static bool NamesRead(bool clear = false)
        {
            ThrowIfNotOpened();

            try
            {
                var rdr = DBProvider.ExecuteReaderCmd("SELECT name FROM sqlite_master WHERE type='table'");
                if (clear) 
                    Tables.Clear();

                while (rdr.Read())
                    if (rdr.GetString(0) != "sqlite_sequence" && !TableIsExist(rdr.GetString(0)))
                        Tables.Add(new DBTable(rdr.GetString(0)));

                return true;
            }
            catch (Exception ex)
            {
                ErrMSG(ex.Message);
                return false;
            }
        }

        static void AlreadyExistsMSG()
        {
            MessageBox.Show
            (
                "Database with entered name already exists!",
                "Exists",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        static void ErrMSG(string msg)
        {
            MessageBox.Show
            (
                msg, 
                "Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error
            );
        }

        static bool TableIsExist(string name) => Tables.Any(i => i.Name == name);

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
