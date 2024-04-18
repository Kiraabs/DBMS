using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLLiteLibrary;

namespace DBMS
{
    public partial class DBEditorForm : Form
    {
        readonly string pathToDB;
        DBFile DBFile;

        public DBEditorForm(string pathToDB)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(pathToDB))
            {
                throw new ArgumentNullException(nameof(pathToDB), "Requires path to DB");
            }

            this.pathToDB = pathToDB;
            DBFile = new DBFile(pathToDB);
            ScanDB();
        }

        void ScanDB()
        {
            foreach (var item in DBFile.ReadTablesDB())
            {
                ListViewTables.Items.Add(item);
            }
        }

        void RefreshListView()
        {
            ListViewTables.Items.Clear();
            ScanDB();
        }

        private void ButtonCreateTable_Click(object sender, EventArgs e)
        {
            var dbtcn = new DBTableCreateNameForm(DBFile);
            dbtcn.Show();
            dbtcn.FormClosed += Dbtcn_FormClosed;
        }

        private void Dbtcn_FormClosed(object? sender, FormClosedEventArgs e)
        {
            RefreshListView();
        }

        private void ButtonDropTable_Click(object sender, EventArgs e)
        {
            if (ListViewTables.SelectedItems.Count > 0)
            {
                var mbr = MessageBox.Show
                (
                    $"Are you sure about to drop: {ListViewTables.SelectedItems.Count} tables?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (mbr == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < ListViewTables.SelectedItems.Count; i++)
                        {
                            DBFile.DropTable(ListViewTables.SelectedItems[i].Text);
                        }

                        RefreshListView();
                        MessageBox.Show
                        (
                            "Selected tables was successfully dropped",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
