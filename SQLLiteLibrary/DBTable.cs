using System.Data.SQLite;

namespace DBMS.ClassLibrary
{
    public class DBTable : SQLiteVirtualTable
    {
        Dictionary<string, object[]> _atrs = [];
        public Dictionary<string, object[]> Attributes { get => _atrs; private set => _atrs = value; }

        public DBTable(string[] arguments) : base(arguments)
        {
            GetAtrs();
        }

        void GetAtrs()
        {

        }
    }
}

