using DBMS.ClassLibrary.Extensions;
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

        public static bool CreateTable(string name, string pkName)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was null or empty!");
            DBException.ThrowIfStringIsEmpty(pkName, "Primary key column name was null or empty!");
            return DBProvider.ExecuteSimpleCmd($"CREATE TABLE {name} ({DBString.BuildField(pkName, "INTEGER")}, {DBString.BuildPrimaryField(pkName, true)})");
        }

        public static bool AlterTable(DBTable table, DBTableAttribute[] tempAttrs)
        {
            DBException.ThrowIfObjectIsNull(table, "Table was null!");
            DBException.ThrowIfObjectIsNull(tempAttrs, "Temporal table attributes was null!");
            // creating temporal table just as program object
            var temporal = new DBTable([table.Arguments[0], table.DatabaseName, $"temp_{table.TableName}"], tempAttrs); 

            try
            {
                var insert = DBString.BuildInsertIntoSelect(
                    temporal.TableName, 
                    table.TableName, 
                    temporal.ColumnIntersection(table), 
                    temporal.ColumnIntersection(table));
                DBProvider.ExecuteSimpleCmd(temporal.Shema); // creating temporal table directly in database
                DBProvider.ExecuteSimpleCmd(insert);
                DBProvider.ExecuteSimpleCmd($"DROP TABLE '{table.TableName}'");
                return TableRename($"{temporal.TableName}", $"{table.TableName}");
            }
            catch (Exception ex)
            {
                UserMSG.Error(ex.Message);
                return false;
            }
        }
    }
}
