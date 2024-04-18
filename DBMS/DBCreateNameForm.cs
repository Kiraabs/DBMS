namespace DBMS
{
    public partial class DBCreateNameForm : Form
    {
        readonly string pathToDBs;

        public DBCreateNameForm(string pathToDBs)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(pathToDBs))
            {
                throw new ArgumentNullException(nameof(pathToDBs), "Requires path to DBs folder");
            }

            this.pathToDBs = pathToDBs;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxDBName.Text))
            {
                try
                {
                    var f = File.Create($"{pathToDBs}\\{TextBoxDBName.Text}.db");
                    f.Close();
                    TextBoxDBName.Clear();
                    MessageBox.Show
                    (
                        "DB successfully created",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show
                    (
                        ex.Message, 
                        "Error of creating DB", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
