using DBMS.ClassLibrary;

namespace DBMS
{
    public partial class DBTableCreateNameForm : Form
    {
        public DBTableCreateNameForm()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxTableName.Text))
            {
                MessageBox.Show
                (
                    "Please, enter the table name!",
                    "Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (DBFile.CreateTable(TextBoxTableName.Text))
            {
                MessageBox.Show
                (
                    "Table successfully created",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
