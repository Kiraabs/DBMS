using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Contains queries to database.
    /// </summary>
    public static class DBQuery
    {
        // TODO: Add additional check of existing table in db file

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

        public static bool AlterTable(DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Table was null!");
            var newShem = dt.Shema.Replace(dt.Shema, DBString.BuildTableSchema(dt)).Replace(dt.TableName, $"new_{dt.TableName}");

            try
            {
                DBProvider.ExecuteSimpleCmd(newShem);
                DBProvider.ExecuteSimpleCmd($"INSERT INTO 'new_{dt.TableName}' SELECT * FROM '{dt.TableName}'");
                DBProvider.ExecuteSimpleCmd($"DROP TABLE '{dt.TableName}'");
                return TableRename($"new_{dt.TableName}", $"{dt.TableName}");
            }
            catch (Exception ex)
            {
                UserMSG.Error(ex.Message);
                return false;
            }
        }

        public static bool AlterTable(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            return AlterTable(DBFile.GetTable(name));
        }
    }
}
