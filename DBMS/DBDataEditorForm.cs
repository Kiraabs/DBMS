using DBMS.ClassLibrary.DBClasses;
using DBMS.ClassLibrary.Extensions;
using DBMS.ClassLibrary.Other;

namespace DBMS
{
    public partial class DBDataEditorForm : Form
    {
        bool _hasChanges = false;
        readonly DBTable _data;

        public DBDataEditorForm(string tableName)
        {
            DBException.ThrowIfStringIsEmpty(tableName, "Table name was null or empty!");
            _data = DBFile.GetTable(tableName);
            InitializeComponent();
            DataGridViewTableData.DBTableAttributesAsCols(_data);
            DataGridViewTableData.GetDBTableData(_data);
            DataGridViewTableData.CellValueChanged += DataGridViewTableData_CellValueChanged;
            DataGridViewTableData.RowsRemoved += DataGridViewTableData_RowsRemoved;
        }

        void DataGridViewTableData_RowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e) => _hasChanges = true;

        void DataGridViewTableData_CellValueChanged(object? sender, DataGridViewCellEventArgs e) => _hasChanges = true;

        void ButtonBack_Click(object sender, EventArgs e) => Close();

        void ButtonCommit_Click(object sender, EventArgs e)
        {
            if (_hasChanges)
            {
                if (UserMSG.Confirm("Are you sure about to save changes?") == DialogResult.Yes)
                    ExecuteCommitAsync();
            }
            else
                UserMSG.Warn("There are no changes!");
        }

        async void ExecuteCommitAsync()
        {
            await Task.Run(ExecuteCommit);
        }

        void ExecuteCommit()
        {
            // very bad code section

            var hasErrors = false;
            DBQuery.DeleteAllFrom(_data.TableName);

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
                        _hasChanges = true;
                }
            }

            if (hasErrors)
                UserMSG.Warn("Some data has errors and hasn't been saved!");
            else if (_hasChanges)
                UserMSG.Info("Data was successfully saved!");
            else
                UserMSG.Warn("No data to save!");
            DBFile.UpdateTables();
            _hasChanges = false;
        }

        void DBDataEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hasChanges)
            {
                if (UserMSG.Confirm("Are you sure about to exit? All changes will be lost.") != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
    }
}
