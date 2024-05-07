using System.Data.Common;

namespace DBMS.ClassLibrary
{
    public class DBTable
    {
        string _name;
        List<DbColumn> _cols = null!;

        public string Name { get => _name; private set => _name = value; }
        public List<DbColumn> Columns { get => _cols; private set => _cols = value; }

        public DBTable(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Table name was empty!");
            _name = name;
            Columns = [];
            ReadColumns();
        }

        bool ReadColumns(bool clear = false)
        {
            try
            {             
                var cs = DBProvider.ExecuteReaderCmd($"PRAGMA table_info('{_name}')").GetColumnSchema();
                if (clear)
                    Columns.Clear();

                foreach (var item in cs)
                    if (!Columns.Contains(item))
                        Columns.Add(item);

                return true;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                throw;
            }
        }
    }
}
