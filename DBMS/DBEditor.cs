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
    public partial class DBEditor : Form
    {
        readonly string pathToDB;
        DBProvider DBFile;

        public DBEditor(string pathToDB)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(pathToDB))
            {
                throw new ArgumentNullException(nameof(pathToDB), "Requires path to DB");
            }

            this.pathToDB = pathToDB;
            DBFile = new DBProvider(pathToDB);
            ScanDB();
        }

        void ScanDB()
        {
            foreach (var item in DBFile.ReadTablesDB())
            {
                ListViewTables.Items.Add(item);
            }
        }
    }
}
