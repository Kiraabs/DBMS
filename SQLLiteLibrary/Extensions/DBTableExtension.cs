namespace DBMS.ClassLibrary.Extensions
{
    public static class DBTableExtension
    {
        public static DBTableAttribute[] CollectAttrsFromDataGridView(this DBTable table, in DataGridView dgv)
        {
            DBException.ThrowIfObjectIsNull(dgv, "Data grid view was null!");
            var attrs = new DBTableAttribute[dgv.RowCount];
            for (int i = 0; i < dgv.RowCount; i++)
                attrs[i] = new DBTableAttribute(dgv.GetValuesFromCells(i), table);
            return attrs;
        }

        public static string[] ColumnIntersection(this DBTable table1, DBTable table2) 
        {
            var cls1 = new string[table1.Attributes.Count];
            var cls2 = new string[table2.Attributes.Count];
            for (int i = 0; i < cls1.Length; i++)
                cls1[i] = table1.Attributes[i].ColumnName;
            for (int i = 0; i < cls2.Length; i++)
                cls2[i] = table2.Attributes[i].ColumnName;
            return cls1.Intersect(cls2).ToArray();
        }
    }
}
