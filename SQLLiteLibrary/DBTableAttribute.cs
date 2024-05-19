using System.Data.Common;

namespace DBMS.ClassLibrary
{
    public class DBTableAttribute : DbColumn
    {
        public const int ArgsCount = 8;
        const int IdIndex = 0;
        const int NameIndex = 1;
        const int TypeIndex = 2;
        const int NotNullIndex = 3;
        const int DefValIndex = 4;
        const int PKIndex = 5;
        const int UniqIndex = 6;
        const int AutoIncIndex = 7;
        object[] _args = new object[ArgsCount];
        DBTable _dt = null!;

        public int Id { get; private set; }
        public object DefValue { get; private set; } = string.Empty;

        public DBTableAttribute(object[] args, DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Table was null or empty!");
            if (args != null && args.Length > 0 && args.Length <= ArgsCount)
            {
                args.CopyTo(_args, 0);
                _dt = dt;
                GetInfo();
            }
            else
                throw new ArgumentException("Arguments was null or there were too many or few arguments!");
        }

        public string[] RowView()
        {
            return [Id.ToString(),
                    ColumnName.ToString(),
                    DataTypeName!.ToString(),
                    AllowDBNull.ToString()!,
                    DefValue.ToString()!,
                    IsKey.ToString()!,
                    IsUnique.ToString()!,
                    IsAutoIncrement.ToString()!];
        }

        void UniqueCheck() => IsUnique = CheckConstraint("UNIQUE");

        void CheckAutoInc() => IsAutoIncrement = CheckConstraint("AUTOINC");

        void GetInfo()
        {
            #region Props initialization logic
            BaseTableName = _dt.TableName;

            if (_args[IdIndex] != null)
                Id = Convert.ToInt32(_args[IdIndex]);
            else
                Id = -1;

            if (_args[NameIndex] != null)
                ColumnName = _args[NameIndex].ToString()!;
            else
                ColumnName = string.Empty;

            if (_args[TypeIndex] != null)
                DataTypeName = _args[TypeIndex].ToString();
            else
                DataTypeName = string.Empty;

            if (_args[NotNullIndex] != null)
                AllowDBNull = Convert.ToBoolean(_args[NotNullIndex]);
            else
                AllowDBNull = false;

            if (_args[DefValIndex] != null && _args[DefValIndex].ToString() != string.Empty)
                DefValue = _args[DefValIndex];
            else
                DefValue = "NULL";

            if (_args[PKIndex] != null)
                IsKey = Convert.ToBoolean(_args[PKIndex]);
            else
                IsKey = false;

            if (_args[UniqIndex] != null)
                IsUnique = Convert.ToBoolean(_args[UniqIndex]);
            else
                UniqueCheck();

            if (_args[AutoIncIndex] != null)
                IsAutoIncrement = Convert.ToBoolean(_args[AutoIncIndex]);
            else
                CheckAutoInc(); 

            #endregion
        }

        bool CheckConstraint(string ctName)
        {
            if (ColumnName == string.Empty)
                return false;

            DBException.ThrowIfStringIsEmpty(ctName, "Constraint name was null or empty!");
            var shem = _dt.Shema.Replace('\n', ' ')
                                .Replace('\r', ' ')
                                .Replace('\t', ' ')
                                .Replace('\"', ' ');

            foreach (var item in shem.Split(','))
                if (item.Contains(ColumnName))
                    if (item.Contains(ctName, StringComparison.CurrentCultureIgnoreCase))
                        return true;

            return false;
        }
    }
}
