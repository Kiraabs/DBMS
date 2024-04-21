using SQLiteLibrary;

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
            {
                ListViewTables.Items.Add(item);
            }
        }

        void RefreshListView()
        {
            ListViewTables.Items.Clear();
            ScanDB();
        }

        void ButtonCreateTable_Click(object sender, EventArgs e)
        {
            var dbtcn = new DBTableCreateNameForm();
            dbtcn.Show();
            dbtcn.FormClosed += Dbtcn_FormClosed;
        }

        void ButtonDropTable_Click(object sender, EventArgs e)
        {
            if (ListViewTables.SelectedItems.Count == 0)
            {
                MessageBox.Show
                (
                    $"Please, select at least one table to drop!",
                    "Not selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var mbr = MessageBox.Show
            (
                $"Are you sure about to drop: {ListViewTables.SelectedItems.Count} table(-s)?",
                "Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );
            if (mbr != DialogResult.Yes)
                return;

            var atLsOneDropped = false;

            for (int i = 0; i < ListViewTables.SelectedItems.Count; i++)
            {
                if (DBFile.DropTable(ListViewTables.SelectedItems[i].Text))
                    atLsOneDropped = true;
            }

            if (atLsOneDropped)
            {
                RefreshListView();
                MessageBox.Show
                (
                    "Selected table(-s) was successfully dropped!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        void ButtonModifyTable_Click(object sender, EventArgs e)
        {
            if (ListViewTables.SelectedItems.Count == 0)
            {
                MessageBox.Show
                (
                    "You have no or several selected table(-s). Please, select only one!",
                    "Selection warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
        }

        void Dbtcn_FormClosed(object? sender, FormClosedEventArgs e) => RefreshListView();

        private void ListViewTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ListViewTables.SelectedItems.Count == 1)
            //{
            //    ListViewTableInfo.Columns.Clear();
            //    ListViewTableInfo.Items.Clear();
            //    var (names, vals) = DBActive.TableScheme(ListViewTables.SelectedItems[0].Text);

            //    for (int i = 0; i < names.Length; i++)
            //    {
            //        var colH = new ColumnHeader()
            //        {
            //            Text = names[i],
            //        };
            //        ListViewTableInfo.Columns.Add(colH);
            //    }

            //    ListViewTableInfo.Items.Add(new ListViewItem(vals));
            //}
        }

        void ButtonQuit_Click(object sender, EventArgs e) => Close();

        void DBEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DBFile.IsOpen)
                DBFile.Close();
        }
    }
}
