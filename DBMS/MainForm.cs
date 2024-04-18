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
            foreach (var fi in DBRootDir.Info.GetFiles())
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
            var dbc = new DBCreateForm();
            dbc.Show();
            dbc.FormClosed += Dbn_FormClosed;
        }

        void Dbn_FormClosed(object? sender, FormClosedEventArgs e) => RefreshListView();

        void ButtonDropDB_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count != 0)
            {
                var mbr = MessageBox.Show
                (
                    $"Are you sure about to drop: {ListViewDBs.SelectedItems.Count} DB (-s)?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (mbr == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < ListViewDBs.SelectedItems.Count; i++)
                        {
                            var si = ListViewDBs.SelectedItems[i];
                            File.Delete($"{DBRootDir.Name}\\{si.Text}");
                        }

                        RefreshListView();
                        MessageBox.Show
                        (
                            $"Selected DB (-s) was successfully dropped!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void ButtonEditor_Click(object sender, EventArgs e)
        {
            if (ListViewDBs.SelectedItems.Count == 1)
            {
                var dbe = new DBEditorForm($"{DBRootDir.Name}\\{ListViewDBs.SelectedItems[0].Text}");
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
