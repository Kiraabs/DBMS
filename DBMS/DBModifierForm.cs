using DBMS.ClassLibrary.DBClasses;
using DBMS.ClassLibrary.Extensions;
using DBMS.ClassLibrary.Other;

namespace DBMS
{
    public partial class DBModifierForm : Form
    {
        bool _hasChanges;
        readonly DBTable _tabMod;

        public DBModifierForm(string tableName)
        {
            DBException.ThrowIfStringIsEmpty(tableName, "Table name was null or empty!");
            _tabMod = DBFile.GetTable(tableName);
            InitializeComponent();
            TextBoxTableName.Text = tableName;
            TextBoxTableName.SelectionStart = TextBoxTableName.TextLength;
            DataGridViewFields.DBTableAttributesAsRows(_tabMod);
            DataGridViewFields.CellValueChanged += DataGridViewFields_CellValueChanged;
        }

        void DataGridViewFields_CellValueChanged(object? sender, DataGridViewCellEventArgs e) => _hasChanges = true;

        void PKSelect()
        {
            DataGridViewFields.GetCellsByColIndex(CAI.Index).ToList().ForEach(c => c.Value = false);
            _hasChanges = true;
        }

        void TryRenameTable()
        {
            try
            {
                if (_tabMod.Rename(TextBoxTableName.Text))
                    UserMSG.Info("Table successfully renamed!");
            }
            catch (Exception ex)
            { UserMSG.Error(ex.Message); }
        }

        void MakeOnlyOneAI()
        {
            var caiCls = DataGridViewFields.GetCellsByColIndex(CAI.Index);
            var pkCls = DataGridViewFields.GetCellsByColIndex(CPK.Index);
            pkCls.ToList().ForEach((c) => c.Value = false);
            caiCls.ToList().ForEach(c => c.Value = false);
            pkCls[DataGridViewFields.SelectedCells[0].OwningRow.Index].Value = true;
        }

        void ButtonBack_Click(object sender, EventArgs e) => Close();

        void DBModifierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hasChanges)
            {
                if (UserMSG.Confirm("Are you sure about to exit? All changes will be lost.") != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        void ButtonAddField_Click(object sender, EventArgs e)
        {
            if (DataGridViewFields.RowCount == 0)
                ButtonCommit.Enabled = true;
            DataGridViewFields.Rows.Add();
            DataGridViewFields.Rows[^1].Cells["CName"].Value = $"Field {DataGridViewFields.RowCount}";
            DataGridViewFields.Rows[^1].Cells["CType"].Value = "INTEGER";
            DataGridViewFields.Rows[^1].Cells["CDef"].Value = "NULL";
            _hasChanges = true;
        }

        void ButtonRemoveField_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTrue("You have no selected field to remove!",
                DataGridViewFields.SelectedCells.Count != 1).True)
                return;

            DataGridViewFields.Rows.Remove(DataGridViewFields.SelectedCells[0].OwningRow);
            _hasChanges = true;
            if (DataGridViewFields.RowCount == 0)
                ButtonCommit.Enabled = false;
        }

        void DataGridViewFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex > 0)
            {
                if (DataGridViewFields[e.ColumnIndex, e.RowIndex].OwningColumn == CAI)
                    MakeOnlyOneAI();
                if (DataGridViewFields[e.ColumnIndex, e.RowIndex].OwningColumn == CPK)
                    PKSelect();
                _hasChanges = true;
            }
        }

        void ButtonTableRename_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTextEmpty("Please, enter the table name!", TextBoxTableName.Text).Empty)
                return;

            if (UserMSG.WarnIfTrue("The table names match! Please, enter different table name.",
                TextBoxTableName.Text == _tabMod.TableName).True)
                return;

            if (UserMSG.Confirm("Are you sure about to rename the table?") == DialogResult.Yes)
                TryRenameTable();
        }

        void ButtonCommit_Click(object sender, EventArgs e)
        {
            if (_hasChanges)
            {
                if (UserMSG.Confirm("Are you sure about " +
                    "to commit all changes in table structure?") != DialogResult.Yes)
                    return;

                if (DBQuery.AlterTable(_tabMod, _tabMod.CollectAttrsFromDataGridView(DataGridViewFields)))
                {
                    UserMSG.Info("Table structure was successfully changed!");
                    _hasChanges = false;
                }
            }
            else
                UserMSG.Warn("There are no changes!");
        }
    }
}
