using SQLLiteLibrary;

namespace DBMS
{
    public partial class DBTableCreateNameForm : Form
    {
        readonly DBFile _DBActive;

        public DBTableCreateNameForm(DBFile DBActive)
        {
            InitializeComponent();
            _DBActive = DBActive;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxTableName.Text))
            {
                if (_DBActive.CreateTable(TextBoxTableName.Text))
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
}
