using DBMS.ClassLibrary;

namespace DBMS
{
    public partial class DBEditorForm : Form
    {
        public DBEditorForm()
        {
            InitializeComponent();
            ScanDB();
        }

        void ScanDB()
        {
            foreach (var item in DBFile.Tables)
                ListViewTables.Items.Add(item.TableName);
        }

        void RefreshListView()
        {
            ListViewTables.Items.Clear();
            ListViewTableInfo.Items.Clear();
            ScanDB();
        }

        void TryDropTable()
        {
            var atLsOneDropped = false;
            for (int i = 0; i < ListViewTables.SelectedItems.Count; i++)
                if (DBFile.DropTable(ListViewTables.SelectedItems[i].Text))
                    atLsOneDropped = true;

            if (atLsOneDropped)
            {
                RefreshListView();
                UserMSG.Info("Selected table(-s) was successfully dropped!");
            }
        }

        void OpenTableToModify()
        {
            if (UserMSG.WarnIfTrue("You have no or several selected table(-s). Please, select only one!", 
                ListViewTables.SelectedItems.Count != 1).True)
                return;

            var dbmf = new DBModifierForm(ListViewTables.SelectedItems[0].Text);
            if (dbmf.ShowDialog() == DialogResult.Cancel)
                RefreshListView();
        }

        void ButtonModifyTable_Click(object sender, EventArgs e) => OpenTableToModify();

        void ListViewTables_ItemActivate(object sender, EventArgs e) => OpenTableToModify();

        void DBTableCreateForm_Closed(object? sender, FormClosedEventArgs e) => RefreshListView();

        void ButtonQuit_Click(object sender, EventArgs e) => Close();

        void ButtonDropTable_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTrue("Please, select at least one table to drop!",
                ListViewTables.SelectedItems.Count == 0).True)
                return;

            if (UserMSG.Confirm($"Are you sure about to drop: {ListViewTables.SelectedItems.Count} " +
                $"table(-s)?") == DialogResult.Yes)
                TryDropTable();
        }
        void ButtonCreateTable_Click(object sender, EventArgs e)
        {
            var dbtcn = new DBTableCreateForm();
            dbtcn.Show();
            dbtcn.FormClosed += DBTableCreateForm_Closed;
        }

        void ListViewTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewTables.SelectedItems.Count == 1)
            {
                ListViewTableInfo.Items.Clear();
                ListViewTableInfo.TableInfoToView(ListViewTables.SelectedItems[0].Text);
            }
        }

        void DBEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DBFile.IsOpen)
                DBFile.Close();
        }
    }
}
