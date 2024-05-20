using DBMS.ClassLibrary.DBClasses;

namespace DBMS.ClassLibrary.Extensions
{
    public static class DataGridViewExtension
    {
        public static void DBTableAttributesAsRows(this DataGridView dgv, in DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Database table was null!");
            dgv.Rows.Add(dt.Attributes.Count);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var atr = dt.Attributes[i].RowView();
                for (int ri = 0; ri < atr.Length; ri++)
                    if (bool.TryParse(atr[ri], out var rt))
                        dgv.Rows[i].Cells[ri].Value = rt;
                    else
                        dgv.Rows[i].Cells[ri].Value = atr[ri];
            }
        }

        public static void GetDBTableData(this DataGridView dgv, in DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Database table was null!");

            if (dt.Data.Length != 0)
            {
                dgv.Rows.Add(dt.Data.Length);
                for (int i = 0; i < dt.Data.Length; i++)
                    for (int j = 0; j < dt.Data[i].ItemArray.Length; j++)
                        dgv.Rows[i].Cells[j].Value = dt.Data[i].ItemArray[j];
            }
        }

        public static void DBTableAttributesAsCols(this DataGridView dgv, in DBTable dt)
        {
            DBException.ThrowIfObjectIsNull(dt, "Database table was null!");

            for (int i = 0; i < dt.Attributes.Count; i++)
                dgv.Columns.Add($"C{dt.Attributes[i].ColumnName}", dt.Attributes[i].ColumnName);
        }

        public static void DBTableAttributesAsCols(this DataGridView dgv, string dbTabName)
        {
            DBException.ThrowIfStringIsEmpty(dbTabName, "Database table name was null or empty!");
            var dt = DBFile.GetTable(dbTabName);
            if (dt != null)
                dgv.DBTableAttributesAsCols(dt);
        }

        public static void DBTableAttributesAsRows(this DataGridView dgv, string dbTabName)
        {
            DBException.ThrowIfStringIsEmpty(dbTabName, "Database table name was null or empty!");
            var dt = DBFile.GetTable(dbTabName);
            if (dt != null)
                dgv.DBTableAttributesAsRows(dt);
        }

        public static DataGridViewCell[] GetCellsByColIndex(this DataGridView dgv, int colInd)
        {
            if (colInd >= 0 && colInd < dgv.ColumnCount)
            {
                var cls = new DataGridViewCell[dgv.RowCount];
                for (int i = 0; i < cls.Length; i++)
                    cls[i] = dgv.Rows[i].Cells[colInd];
                return cls;
            }
            else
                throw new ArgumentException("Column index out of range!");
        }

        public static DataGridViewCell[] GetCellsByRowIndex(this DataGridView dgv, int rowInd) 
        {
            if (rowInd >= 0 && rowInd < dgv.RowCount)
            {
                var cls = new DataGridViewCell[dgv.Rows[rowInd].Cells.Count];
                for (int i = 0; i < cls.Length; i++)
                    cls[i] = dgv.Rows[rowInd].Cells[i];
                return cls;
            }
            else
                throw new ArgumentException("Row index out of range!");
        }

        public static object[] GetValuesFromCells(this DataGridView dgv, int rowInd)
        {
            var cls = GetCellsByRowIndex(dgv, rowInd);
            var vals = new object[cls.Length];
            for (int i = 0; i < cls.Length; i++)
                vals[i] = cls[i].Value;
            return vals;
        }
    }
}
