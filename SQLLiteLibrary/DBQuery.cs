using System.Data;

namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Contains queries to database.
    /// </summary>
    public static class DBQuery
    {
        public static DataRowCollection TableRows(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            return DBProvider.RetrieveDataFromCmd($"PRAGMA table_info('{name}')").Rows;
        }

        public static string TableSchema(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            return DBProvider.RetrieveDataFromCmd($"SELECT SQL FROM sqlite_master WHERE type = 'table' AND name = '{name}'").Rows[0].ItemArray[0]!.ToString()!;
        }

        public static bool DropTable(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            return DBProvider.ExecuteSimpleCmd($"DROP TABLE '{name}'");
        }

        public static bool TableRename(string name, string newName)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            DBException.ThrowIfStringIsEmpty(newName, "New table name was null or empty!");
            return DBProvider.ExecuteSimpleCmd($"ALTER TABLE '{name}' RENAME TO '{newName}'");
        }

        public static string[] GetTables()
        {
            var data = DBProvider.RetrieveDataFromCmd("SELECT name FROM sqlite_master WHERE type='table'").Rows;
            var tbls = new string[data.Count];
            for (int i = 0; i < tbls.Length; i++)
                tbls[i] = data[i].ItemArray[0]!.ToString()!;
            return tbls;
        }

        public static bool CreateTable(string name, string fName, bool pk = false, bool autoInc = false)
        {
            
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            return DBProvider.ExecuteSimpleCmd($"CREATE TABLE '{name}' (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT))");
        }


        static string BuildField(string name, string type, bool notNull, bool uniq, string defVal = "")
        {
            var fld = $"{name} {type}";
            if (notNull)
                fld += " NOT NULL";
            if (defVal != "")
                fld += $" DEFAULT {defVal}";
            if (uniq)
                fld += " UNIQUE";
            return fld += ",";
        }

        static string BuildPrimary(string name, bool ai)
        {
            var pk = $"PRIMARY KEY('{name}')";
            if (ai)
                pk += " AUTOINCREMENT";
            return pk;
        }
    }
}
