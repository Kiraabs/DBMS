using SQLLiteLibrary;

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
                {
                    ListViewDBs.Items.Add(fi.Name.Replace(fi.Extension, string.Empty));
                }
            }
        }

        void RefreshListView()
        {
            ListViewDBs.Items.Clear();
            ScanDBFold();
        }

        void ButtonAddDB_Click(object sender, EventArgs e)
        {
            var dbc = new DBCreateForm();
            dbc.Show();
            dbc.FormClosed += Dbc_FormClosed;
        }

        void Dbc_FormClosed(object? sender, FormClosedEventArgs e) => RefreshListView();

        void ButtonDropDB_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count == 0)
            {
                MessageBox.Show
                (
                    "Please, select at least one or several DB (-s) to drop!",
                    "Not selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var mbr = MessageBox.Show
            (
                $"Are you sure about to drop: {ListViewDBs.SelectedItems.Count} DB (-s)?",
                "Confirmation",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (mbr == DialogResult.Yes)
            {
                bool atLsOneDropped = false;

                for (int i = 0; i < ListViewDBs.SelectedItems.Count; i++)
                {
                    if (DBFile.Drop(ListViewDBs.SelectedItems[i].Text))
                    {
                        atLsOneDropped = true;
                    }
                }

                if (atLsOneDropped)
                {
                    RefreshListView();
                    MessageBox.Show
                    (
                        $"Selected DB (-s) was successfully dropped!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        void ButtonEditor_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count == 1)
            {
                var dbe = new DBEditorForm($"{DBRoot.Name}\\{ListViewDBs.SelectedItems[0].Text}");
                dbe.ShowDialog();
            }
            else
            {
                MessageBox.Show
                (
                    "You have no or several selected DB (-s). Please, select only one DB!", 
                    "Selection warning", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
