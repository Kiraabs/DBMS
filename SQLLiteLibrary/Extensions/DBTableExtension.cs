namespace DBMS.ClassLibrary.Extensions
{
    public static class DBTableExtension
    {
        public static void DataGridViewToDBTable(this DBTable table, in DataGridView dgv)
        {
            DBException.ThrowIfObjectIsNull(dgv, "Data grid view was null!");

            for (int i = 0; i < dgv.RowCount; i++)
            {
                var args = new object[DBTableAttribute.ArgsCount]; 
                dgv.GetValuesFromCells(i).CopyTo(args, 1);

                if (i >= table.Attributes.Count)
                {
                    table.Attributes.Add(new DBTableAttribute(args, table));
                }
                else
                {
                    table.Attributes[i] = new DBTableAttribute(args, table);
                }
            }
        }

        
    }
}
