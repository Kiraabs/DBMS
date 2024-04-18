using SQLLiteLibrary;

namespace DBMS
{
    public partial class DBEditorForm : Form
    {
        /// <summary>
        /// Активный в данный момент файл БД.
        /// </summary>
        readonly DBFile DBActive;

        public DBEditorForm(string pathToDB)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(pathToDB))
            {
                throw new ArgumentNullException(nameof(pathToDB), "Requires path to DB");
            }

            DBActive = new DBFile(pathToDB);
            ScanDB();
        }

        void ScanDB()
        {
            foreach (var item in DBActive.Tables)
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
            var dbtcn = new DBTableCreateNameForm(DBActive);
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
                            DBActive.DropTable(ListViewTables.SelectedItems[i].Text);
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
                var (names, vals) = DBActive.TableScheme(ListViewTables.SelectedItems[0].Text);

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

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
