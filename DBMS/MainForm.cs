using DBMS.ClassLibrary;

namespace DBMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ScanDBFold();
        }

        void RefreshListView()
        {
            ListViewDBs.Items.Clear();
            ScanDBFold();
        }

        void ScanDBFold()
        {
            foreach (var fi in DBRoot.Dir.GetFiles())
                if (fi.Extension.Contains(".db"))
                    ListViewDBs.Items.Add(fi.Name.Replace(fi.Extension, string.Empty));
        }

        void TryOpenDBFile()
        {
            if (UserMSG.WarnIfTrue("You have no or several selected database file(-s). Please, select only one!",
                ListViewDBs.SelectedItems.Count != 1).True)
                return;

            DBFile.Open(ListViewDBs.SelectedItems[0].Text);
            _ = new DBEditorForm().ShowDialog();
        }

        void TryDropDBFile()
        {
            var oneDropped = false;
            for (int i = 0; i < ListViewDBs.SelectedItems.Count; i++)
                if (DBFile.Drop(ListViewDBs.SelectedItems[i].Text))
                    oneDropped = true;

            if (oneDropped)
            {
                RefreshListView();
                UserMSG.Info("Selected database file(-s) was successfully dropped!");
            }
        }

        void ButtonEditor_Click(object sender, EventArgs e) => TryOpenDBFile();

        void ListViewDBs_ItemActivate(object sender, EventArgs e) => TryOpenDBFile();

        void Dbc_FormClosed(object? sender, FormClosedEventArgs e) => RefreshListView();

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DBFile.IsOpen)
                DBFile.Close();
        }

        void ButtonCreateDB_Click(object sender, EventArgs e)
        {
            var dbc = new DBFileCreateForm();
            dbc.FormClosed += Dbc_FormClosed;
            dbc.ShowDialog();
        }

        void ButtonDropDB_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTrue("Please, select at least one or several database file(-s) to drop!",
                ListViewDBs.SelectedItems.Count == 0).True)
                return;

            if (UserMSG.Confirm($"Are you sure about to drop: {ListViewDBs.SelectedItems.Count} " +
                $"database file(-s)?") == DialogResult.Yes)
                TryDropDBFile();
        }

        void ButtonAddForeignDB_Click(object sender, EventArgs e)
        {
            if (UserMSG.Confirm("External database file will be permanently moved to program root directory. " +
                "Are you sure?") != DialogResult.Yes)
                return;

            var ofd = new OpenFileDialog() { Filter = "(*.db)|*.db" };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            if (DBFile.MoveExternal(new FileInfo(ofd.FileName)))
            {
                RefreshListView();
                UserMSG.Info("External database file successfully added!");
            }
        }
    }
}
