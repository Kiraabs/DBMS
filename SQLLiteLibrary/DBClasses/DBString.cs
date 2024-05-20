namespace DBMS.ClassLibrary.DBClasses
{
    public static class DBString
    {
        public static string BuildInsertIntoSelect(string to, string from, string[] cols, string[] vals)
        {
            DBException.ThrowIfStringIsEmpty(cols.ToString()!, "Columns was null!");
            DBException.ThrowIfStringIsEmpty(vals.ToString()!, "Values was null!");
            DBException.ThrowIfStringIsEmpty(from, "From was null!");
            DBException.ThrowIfStringIsEmpty(to, "To was null!");
            return $"INSERT INTO {to} ({string.Join(", ", cols)}) SELECT {string.Join(", ", vals)} FROM {from}";
        }

        public static string BuildTableSchema(in DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Table was null!");
            var newShem = $"CREATE TABLE '{dt.TableName}'( ";
            var pk = string.Empty;

            for (int i = 0; i < dt.Attributes.Count; i++)
            {
                var (Field, PK) = dt.Attributes[i].FieldView();
                if (PK != string.Empty)
                    pk = PK;
                if (i + 1 != dt.Attributes.Count)
                    newShem += $"{Field}, ";
                else
                    newShem += $"{Field}";
            }

            return newShem += $", {pk})";
        }

        public static string BuildField(string name, string type, bool notNull = false, bool uniq = false, string defVal = "")
        {
            var fld = $"'{name}' {type}";
            if (notNull)
                fld += " NOT NULL";
            if (defVal != "")
                fld += $" DEFAULT {defVal}";
            if (uniq)
                fld += " UNIQUE";
            return fld;
        }

        public static string BuildPrimaryField(string name, bool ai)
        {
            DBException.ThrowIfStringIsEmpty(name, "Field name was null or empty!");
            var fpk = $"PRIMARY KEY ('{name}'";
            if (ai)
                fpk += " AUTOINCREMENT";
            fpk += ")";
            return fpk;
        }
    }
}
