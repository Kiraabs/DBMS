//using System.Data.Common;

//namespace DBMS.ClassLibrary
//{
//    public class DBTable
//    {
//        string _name;
//        Dictionary<string, object> _cols;
//        public string Name { get => _name; private set => _name = value; }
//        Dictionary<string, object> Columns { get => _cols; private set => _cols = value; }

//        public DBTable(string name)
//        {
//            DBException.ThrowIfStringIsEmpty(name, "Table name was empty!");
//            _name = name;
//            Columns = [];
//            ColsRead()
//        }

//        void ColsRead()
//        {

//        }
//    }
//}
