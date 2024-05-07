using System.Data.Common;

namespace DBMS.ClassLibrary
{
    public class DBTable
    {
        string _name;
        List<DbColumn> _atrbus = null!;

        public string Name { get => _name; private set => _name = value; }
        public List<DbColumn> Columns { get => _atrbus; private set => _atrbus = value; }

        public DBTable(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was empty!");
            _name = name;
            Columns = [];
        }
    }
}
