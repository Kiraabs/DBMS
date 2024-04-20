using SQLLiteLibrary;

namespace DBMS
{
    public partial class DBCreateForm : Form
    {
        public DBCreateForm()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxDBName.Text))
            {
                if (DBFile.Create(TextBoxDBName.Text))
                {
                    TextBoxDBName.Clear();
                    MessageBox.Show
                    (
                        "Database file successfully created!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            else
            {
                MessageBox.Show
                (
                    "Database file name was empty!",
                    "Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
