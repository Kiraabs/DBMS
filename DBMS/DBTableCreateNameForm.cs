using SQLLiteLibrary;

namespace DBMS
{
    public partial class DBTableCreateNameForm : Form
    {
        DBFile DBPv;
        public DBTableCreateNameForm(DBFile DBPv)
        {
            InitializeComponent();
            this.DBPv = DBPv;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxTableName.Text))
            {
                if (!DBPv.TableIsExist(TextBoxTableName.Text))
                {
                    if (DBPv.CreateTable(TextBoxTableName.Text))
                    {
                        MessageBox.Show("Table successfuly created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Table already exists", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
