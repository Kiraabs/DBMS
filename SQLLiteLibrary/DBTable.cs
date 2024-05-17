using System.Data;
using System.Data.SQLite;

namespace DBMS.ClassLibrary
{
    public sealed class DBTable : SQLiteVirtualTable
    {
        DataTable _tabInf = null!;
        List<(string ColName, object Value)> _atrs = [];

        public List<(string ColName, object Value)> Attributes { get => _atrs; private set => _atrs = value; }

        public DBTable(string[] args) : base(args)
        {
            GetAtrs();
        }

        public override bool Rename(string newName)
        {
            DBException.ThrowIfStringIsEmpty(newName, "New table name was null or empty!");
            DBProvider.ExecuteSimpleCmd($"ALTER TABLE '{TableName}' RENAME TO '{newName}'");
            return base.Rename(newName);
        }

        void GetAtrs()
        {
            _tabInf = new DataTable();
            DBProvider.ExecuteAdapterCmd($"PRAGMA table_info('{TableName}')").Fill(_tabInf);
            for (int i = 0; i < _tabInf.Rows.Count; i++)
                for (int j = 0; j < _tabInf.Rows[i].ItemArray.Length; j++)
                    _atrs.Add((_tabInf.Columns[j].ColumnName, _tabInf.Rows[i].ItemArray[j]!));
        }
    }
}

