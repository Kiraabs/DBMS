using DBMS.ClassLibrary.DBClasses;
using DBMS.ClassLibrary.Extensions;
using DBMS.ClassLibrary.Other;

namespace DBMS
{
    public partial class DBDataEditorForm : Form
    {
       readonly DBTable _data;

        public DBDataEditorForm(string tableName)
        {
            DBException.ThrowIfStringIsEmpty(tableName, "Table name was null or empty!");
            _data = DBFile.GetTable(tableName);
            InitializeComponent();
            DataGridViewTableData.DBTableAttributesAsCols(_data);
            DataGridViewTableData.GetDBTableData(_data);
        }

        void ButtonBack_Click(object sender, EventArgs e)
        {
            if (UserMSG.Confirm("Are you sure about to exit?") == DialogResult.Yes)
                Close();
        }

        void ButtonCommit_Click(object sender, EventArgs e)
        {
            if (UserMSG.Confirm("Are you sure about to save changes?") == DialogResult.Yes)
            {
                ExecuteCommitAsync();
            }
        }

        async void ExecuteCommitAsync()
        {
            await Task.Run(ExecuteCommit);
        }

        void ExecuteCommit()
        {
            // very bad code section

            var hasErrors = false;
            var hasChanges = false;
            if (DBQuery.DeleteAllFrom(_data.TableName).Affected > 0)
                hasChanges = true;

            for (int i = 0; i < DataGridViewTableData.RowCount; i++)
            {
                var vals = new string[DataGridViewTableData.Rows[i].Cells.Count];

                if (!DataGridViewTableData.GetValuesFromCells(i).All(c => c == null)) // skip empty row 
                {
                    for (int j = 0; j < vals.Length; j++)
                        vals[j] = $"'{DataGridViewTableData.Rows[i].Cells[j].Value}'";

                    if (!DBQuery.InsertInto(_data.TableName, vals))
                        hasErrors = true;
                    else
                        hasChanges = true;
                }
            }

            if (hasErrors)
                UserMSG.Warn("Some data has errors and hasn't been saved!");
            else if (hasChanges)
                UserMSG.Info("Data was successfully saved!");
            else
                UserMSG.Warn("No data to save!");
            DBFile.UpdateTables();
        }
    }
}
