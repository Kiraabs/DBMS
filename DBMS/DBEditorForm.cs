using SQLLiteLibrary;

namespace DBMS
{
    public partial class DBEditorForm : Form
    {
        readonly string pathToDB;
        DBFile DBFile;

        public DBEditorForm(string pathToDB)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(pathToDB))
            {
                throw new ArgumentNullException(nameof(pathToDB), "Requires path to DB");
            }

            this.pathToDB = pathToDB;
            DBFile = new DBFile(pathToDB);
            ScanDB();
        }

        void ScanDB()
        {
            foreach (var item in DBFile.ReadTablesDB())
            {
                ListViewTables.Items.Add(item);
            }
        }

        void RefreshListView()
        {
            ListViewTables.Items.Clear();
            ScanDB();
        }

        private void ButtonCreateTable_Click(object sender, EventArgs e)
        {
            var dbtcn = new DBTableCreateNameForm(DBFile);
            dbtcn.Show();
            dbtcn.FormClosed += Dbtcn_FormClosed;
        }

        private void Dbtcn_FormClosed(object? sender, FormClosedEventArgs e)
        {
            RefreshListView();
        }

        private void ButtonDropTable_Click(object sender, EventArgs e)
        {
            if (ListViewTables.SelectedItems.Count > 0)
            {
                var mbr = MessageBox.Show
                (
                    $"Are you sure about to drop: {ListViewTables.SelectedItems.Count} tables?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (mbr == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < ListViewTables.SelectedItems.Count; i++)
                        {
                            DBFile.DropTable(ListViewTables.SelectedItems[i].Text);
                        }

                        RefreshListView();
                        MessageBox.Show
                        (
                            "Selected tables was successfully dropped",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void ListViewTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewTables.SelectedItems.Count == 1)
            {
                ListViewTableInfo.Columns.Clear();
                ListViewTableInfo.Items.Clear();
                var (names, vals) = DBFile.TableScheme(ListViewTables.SelectedItems[0].Text);

                for (int i = 0; i < names.Length; i++)
                {
                    var colH = new ColumnHeader()
                    {
                        Text = names[i],
                    };
                    ListViewTableInfo.Columns.Add(colH);
                }
                
                ListViewTableInfo.Items.Add(new ListViewItem(vals));
            }
        }
    }
}
