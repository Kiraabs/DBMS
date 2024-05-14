using DBMS.ClassLibrary;
using System.Data;

namespace DBMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ScanDBFold();
        }

        void ScanDBFold()
        {
            foreach (var fi in DBRoot.Dir.GetFiles())
            {
                if (fi.Extension.Contains(".db"))
                    ListViewDBs.Items.Add(fi.Name.Replace(fi.Extension, string.Empty));
            }
        }

        void RefreshListView()
        {
            ListViewDBs.Items.Clear();
            ScanDBFold();
        }

        void TryOpenDBFile()
        {
            if (ListViewDBs.SelectedItems.Count != 1)
            {
                MessageBox.Show
                (
                    "You have no or several selected database file(-s). Please, select only one!",
                    "Selection warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DBFile.Open(ListViewDBs.SelectedItems[0].Text);
            _ = new DBEditorForm().ShowDialog();
        }

        void TryDropDBFile()
        {
            var oneDropped = false;

            for (int i = 0; i < ListViewDBs.SelectedItems.Count; i++)
            {
                if (DBFile.Drop(ListViewDBs.SelectedItems[i].Text))
                    oneDropped = true;
            }

            if (oneDropped)
            {
                RefreshListView();
                MessageBox.Show
                (
                    $"Selected database file(-s) was successfully dropped!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        void ButtonCreateDB_Click(object sender, EventArgs e)
        {
            var dbc = new DBCreateForm();
            dbc.FormClosed += Dbc_FormClosed;
            dbc.ShowDialog();
        }

        void Dbc_FormClosed(object? sender, FormClosedEventArgs e) => RefreshListView();

        void ButtonDropDB_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count == 0)
            {
                MessageBox.Show
                (
                    "Please, select at least one or several database file(-s) to drop!",
                    "Not selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var mbr = MessageBox.Show
            (
                $"Are you sure about to drop: {ListViewDBs.SelectedItems.Count} database file(-s)?",
                "Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );
            if (mbr == DialogResult.Yes)
                TryDropDBFile();
        }

        void ButtonEditor_Click(object sender, EventArgs e) => TryOpenDBFile();

        void ListViewDBs_ItemActivate(object sender, EventArgs e) => TryOpenDBFile();

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DBFile.IsOpen)
                DBFile.Close();
        }

        void ButtonAddForeignDB_Click(object sender, EventArgs e)
        {
            var mbr = MessageBox.Show
            (
                "External database file will be permanently moved to program root directory. Are you sure?",
                "Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (mbr != DialogResult.Yes)
                return;

            var ofd = new OpenFileDialog() { Filter = "(*.db)|*.db" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (DBFile.MoveExternal(new FileInfo(ofd.FileName)))
                {
                    RefreshListView();
                    MessageBox.Show
                    (
                        "External database file successfully added!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }
    }
}
