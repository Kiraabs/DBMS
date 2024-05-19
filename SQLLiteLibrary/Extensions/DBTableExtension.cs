namespace DBMS.ClassLibrary.Extensions
{
    public static class DBTableExtension
    {
        public static void DataGridViewToDBTable (this DBTable table, in DataGridView dgv)
        {
            DBException.ThrowIfObjectIsNull(dgv, "Data grid view was null!");

            if (table.Attributes.Count == dgv.RowCount)
            {
                for (int i = 0; i < table.Attributes.Count; i++)
                {
                    var argsWithColId = new object[DBTableAttribute.ArgsCount];
                    dgv.GetValuesFromCells(i).CopyTo(argsWithColId, 1);
                    argsWithColId[0] = table.Attributes[i].Id;
                    table.Attributes[i] = new DBTableAttribute(argsWithColId, table);
                }
            }
        }
    }
}
