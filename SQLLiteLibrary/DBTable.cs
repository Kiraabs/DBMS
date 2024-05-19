using System.Data.SQLite;

namespace DBMS.ClassLibrary
{
    public sealed class DBTable : SQLiteVirtualTable
    {
        readonly int _atrsCnt = 0;
        string _shem = string.Empty;
        List<DBTableAttribute> _atrs = [];

        public string Shema { get => _shem; private set => _shem = value; }
        public List<DBTableAttribute> Attributes { get => _atrs; private set => _atrs = value; }

        public DBTable(string[] args) : base(args)
        {
            _atrsCnt = DBQuery.TableRows(TableName).Count;
            _shem = DBQuery.TableSchema(TableName);
            GetAtrsFromDB();
        }

        public override bool Rename(string newName)
        {
            if (DBQuery.TableRename(TableName, newName))
                return base.Rename(newName);
            return false;
        }

        void GetAtrsFromDB()
        {
            for (int i = 0; i < _atrsCnt; i++)
                _atrs.Add(new DBTableAttribute(DBQuery.TableRows(TableName)[i].ItemArray!, this));
        }
    }
}

 