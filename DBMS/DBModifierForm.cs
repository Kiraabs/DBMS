using DBMS.ClassLibrary;

namespace DBMS
{
    public partial class DBModifierForm : Form
    {
        DBTable _tabMod;

        public DBModifierForm(string tableName)
        {
            DBException.ThrowIfStringIsEmpty(tableName, "Table name was null or empty!");
            _tabMod = DBFile.GetTable(tableName);
            InitializeComponent();
            TextBoxTableName.Text = tableName;
            TextBoxTableName.SelectionStart = TextBoxTableName.TextLength;
        }

        void ButtonTableRename_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxTableName.Text))
            {
                MessageBox.Show
                (
                    "Table name was empty! Please, enter table name.",
                    "Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            else if (TextBoxTableName.Text == _tabMod.TableName)
            {
                MessageBox.Show
                (
                    "The table names match! Please, enter different table name.",
                    "Names match",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            else
            {
                if (_tabMod.Rename(TextBoxTableName.Text))
                {
                    MessageBox.Show
                    (
                        "Table successfully renamed!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }
    }
}
