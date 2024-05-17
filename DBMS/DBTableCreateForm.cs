using DBMS.ClassLibrary;

namespace DBMS
{
    public partial class DBTableCreateForm : Form
    {
        public DBTableCreateForm()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTextEmpty("Please, enter the table name!", TextBoxTableName.Text).Empty)
                return;

            try
            {
                if (DBFile.CreateTable(TextBoxTableName.Text))
                    UserMSG.Info("Table successfully created");
            }
            catch (Exception ex)
                { UserMSG.Error(ex.Message); }
        }
    }
}
