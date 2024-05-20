using DBMS.ClassLibrary.Extensions;
using DBMS.ClassLibrary.Other;
using System.Data;

namespace DBMS.ClassLibrary.DBClasses
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

        public static bool CreateTable(string name, string pkfName)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            DBException.ThrowIfStringIsEmpty(pkfName, "Primary key column name was null or empty!");
            return DBProvider.ExecuteSimpleCmd($"CREATE TABLE {name} ({DBString.BuildField(pkfName, "INTEGER")}, {DBString.BuildPrimaryField(pkfName, true)})");
        }

        public static bool AlterTable(DBTable table, DBTableAttribute[] tempAttrs)
        {
            DBException.ThrowIfObjectIsNull(table, "Table was null!");
            DBException.ThrowIfObjectIsNull(tempAttrs, "Temporal table attributes was null!");
            // creating temporal table just as program object.
            var temporal = new DBTable([table.Arguments[0], table.DatabaseName, $"temp_{table.TableName}"], tempAttrs); 

            try
            {
                DBProvider.ExecuteSimpleCmd(temporal.Shema); // creating temporal table directly in DB file
                var (Intersection, IsIntersects) = temporal.ColumnIntersection(table);
                if (IsIntersects)
                    DBProvider.ExecuteSimpleCmd(DBString.BuildInsertIntoSelect(temporal.TableName, table.TableName, Intersection, Intersection)); 
                DBProvider.ExecuteSimpleCmd($"DROP TABLE '{table.TableName}'");
                TableRename($"{temporal.TableName}", $"{table.TableName}");
                return DBFile.UpdateTables(); // just need to update db file, cuz temporal table doesn't exist in it
            }
            catch (Exception ex)
            {
                UserMSG.Error(ex.Message);
                return false;
            }
        }
    }
}
