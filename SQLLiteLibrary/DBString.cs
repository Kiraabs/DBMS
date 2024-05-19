namespace DBMS.ClassLibrary
{
    public static class DBString
    {
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
                newShem += $"{Field}, ";
            }

            return newShem += $"{pk})";
        }

        public static string BuildField(string name, string type, bool notNull, bool uniq, string defVal = "")
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

        public static string BuildPrimaryField(string name, bool pk, bool ai)
        {
            DBException.ThrowIfStringIsEmpty(name, "Field name was null or empty!");
            var fpk = string.Empty;

            if (pk)
            {
                fpk = $"PRIMARY KEY ('{name}'";
                if (ai)
                    fpk += " AUTOINCREMENT";
                fpk += ")";
            }
            return fpk;
        }
    }
}
