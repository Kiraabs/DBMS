using System.Data.Common;

namespace DBMS.ClassLibrary
{
    public class DBTableAttribute : DbColumn
    {
        public const int ArgsCount = 7;
        const int NameIndex = 0;
        const int TypeIndex = 1;
        const int NotNullIndex = 2;
        const int DefValIndex = 3;
        const int PKIndex = 4;
        const int UniqIndex = 5;
        const int AutoIncIndex = 6;
        object[] _args = new object[ArgsCount];
        DBTable _dt = null!;

        public object DefValue { get; private set; } = string.Empty;

        public DBTableAttribute(object[] args, DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Table was null or empty!");
            if (args != null && args.Length > 0 && args.Length <= ArgsCount)
            {
                _dt = dt;
                ArgsPass(args);
                GetInfo();
            }
            else
                throw new ArgumentException("Arguments was null or there were too many or few arguments!");
        }

        public (string Field, string PK) FieldView()
        {
            var field = DBString.BuildField(ColumnName, DataTypeName!, (bool)AllowDBNull!, (bool)IsUnique!);
            var fpk = DBString.BuildPrimaryField(ColumnName, (bool)IsKey!, (bool)IsAutoIncrement!);
            return (field, fpk);
        }


        public string[] RowView()
        {
            return [ColumnName.ToString(),
                    DataTypeName!.ToString(),
                    AllowDBNull.ToString()!,
                    DefValue.ToString()!,
                    IsKey.ToString()!,
                    IsUnique.ToString()!,
                    IsAutoIncrement.ToString()!];
        }

        void ArgsPass(in object[] args)
        {
            for (int i = 1; i < args.Length; i++)
                _args[i - 1] = args[i];
        }

        void UniqueCheck() => IsUnique = CheckConstraint("UNIQUE");

        void CheckAutoInc() => IsAutoIncrement = CheckConstraint("AUTOINC");

        void GetInfo()
        {
            #region Props initialization logic
            BaseTableName = _dt.TableName;

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
