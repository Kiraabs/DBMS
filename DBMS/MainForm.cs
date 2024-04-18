
namespace DBMS
{

    public partial class MainForm : Form
    {
        const string DBsFolder = "DBs";

        public MainForm()
        {
            InitializeComponent();
            ScanDBFold();
        }

        void ScanDBFold()
        {
            var di = new DirectoryInfo(DBsFolder);
            if (!di.Exists) di.Create();

            foreach (var fi in di.GetFiles())
            {
                ListViewDBs.Items.Add(fi.Name);
            }
        }

        void RefreshListView()
        {
            ListViewDBs.Items.Clear();
            ScanDBFold();
        }

        void ButtonAddDB_Click(object sender, EventArgs e)
        {
            var dbn = new DBNameForm(DBsFolder);
            dbn.Show();
            dbn.FormClosed += Dbn_FormClosed;
        }

        void Dbn_FormClosed(object? sender, FormClosedEventArgs e)
        {
            RefreshListView();
        }

        private void ButtonRemoveDB_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count != 0)
            {
                var mbr = MessageBox.Show
                (
                    $"Are you sure about to delete: {ListViewDBs.SelectedItems.Count} DBs?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (mbr == DialogResult.Yes)
                {
                    for (int i = 0; i < ListViewDBs.SelectedItems.Count; i++)
                    {
                        var si = ListViewDBs.SelectedItems[i];

                        File.Delete($"{DBsFolder}\\{si.Text}");
                    }

                    RefreshListView();
                }
            }
        }

        void ButtonEditor_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count == 1)
            {
                var dbe = new DBEditor($"{DBsFolder}\\{ListViewDBs.SelectedItems[0].Text}");
                dbe.Show();
            }
            else
            {
                MessageBox.Show
                (
                    "Please, choose only one DB", 
                    "Choose error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
