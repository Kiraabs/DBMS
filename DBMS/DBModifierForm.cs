using DBMS.ClassLibrary;

namespace DBMS
{
    public partial class DBModifierForm : Form
    {
        readonly DBTable _tabMod;

        public DBModifierForm(string tableName)
        {
            DBException.ThrowIfStringIsEmpty(tableName, "Table name was null or empty!");
            _tabMod = DBFile.GetTable(tableName);
            InitializeComponent();
            TextBoxTableName.Text = tableName;
            TextBoxTableName.SelectionStart = TextBoxTableName.TextLength;
        }
        void ButtonBack_Click(object sender, EventArgs e) => Close();

        void ButtonTableRename_Click(object sender, EventArgs e)
        {
            if (UserMSG.WarnIfTextEmpty("Please, enter the table name!", TextBoxTableName.Text).Empty)
                return;

            if (UserMSG.WarnIfTrue("The table names match! Please, enter different table name.",
                TextBoxTableName.Text == _tabMod.TableName).True)
                return;

            try
            {
                if (_tabMod.Rename(TextBoxTableName.Text))
                    UserMSG.Info("Table successfully renamed!");
            }
            catch (Exception ex)
                { UserMSG.Error(ex.Message); }
        }
    }
}
