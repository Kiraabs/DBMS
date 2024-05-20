using DBMS.ClassLibrary.DBClasses;
using DBMS.ClassLibrary.Other;

namespace DBMS
{
    public partial class DBFileCreateForm : Form
    {
        public DBFileCreateForm()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTextEmpty("Database file name was empty!", TextBoxDBName.Text).Empty)
                return;

            if (TextBoxDBName.Text.Contains(".db"))
                TextBoxDBName.Text = TextBoxDBName.Text.Replace(".db", string.Empty);

            try
            {
                if (DBFile.Create(TextBoxDBName.Text)) 
                {
                    TextBoxDBName.Clear();
                    UserMSG.Info("Database file successfully created!");
                }
            }
            catch (Exception ex)
                { UserMSG.Error(ex.Message); }
        }
    }
}
