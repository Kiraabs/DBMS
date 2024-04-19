using System.Data;
using System.Data.SQLite;

namespace SQLLiteLibrary
{   
    /// <summary>
    /// Represents DB file.
    /// </summary>
    public partial class DBFile
    {
        readonly string _path;
        public List<string> Tables { get; private set; } = [];
        
        public DBFile(string dbFilePath)
        {
            if (string.IsNullOrWhiteSpace(dbFilePath))
                throw new ArgumentNullException(nameof(dbFilePath), "Requires path to DB!");

            _path = $"Data Source={dbFilePath}";
            DBProvider.Provide(_path);
            ReadWriteTables();
        }

        ~DBFile()
        {
            DBProvider.EndProviding();
        }

        public bool CreateTable(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || TableIsExist(name))
            {
                MessageBox.Show
                (
                    "Table name was empty or already exists!",
                    "Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"CREATE TABLE {name} (\"ID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT));"))
                return ReadWriteTables();

            return false;
        }

        public bool DropTable(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !TableIsExist(name))
            {
                MessageBox.Show
                (
                    "Table name was empty or doesn't exists!",
                    "Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (DBProvider.ExecuteSimpleCmd($"DROP TABLE {name}"))
                return ReadWriteTables(true);

            return false;
        }

        //public (string[] names, string[] vals) TableScheme(string name)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(name))
        //        {
        //            Connect();
        //            var sqlc = new SQLiteCommand($"PRAGMA table_info('{name}')", _cnn);
        //            var ex = sqlc.ExecuteReader();
        //            var names = new string[ex.FieldCount];
        //            var vals = new string[ex.FieldCount];

        //            while (ex.Read())
        //            {
        //                for (int i = 0; i < ex.FieldCount; i++)
        //                {
        //                    names[i] = ex.GetName(i);
        //                    vals[i] = ex.GetValue(i).ToString()!;
        //                }
        //            }

        //            Disconnect();
        //            return (names, vals);
        //        }

        //        return (null!, null!);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        throw;
        //    }
        //}

        bool ReadWriteTables(bool clr = false)
        {
            try
            {
                var rdr = DBProvider.ExecuteReaderCmd("SELECT name FROM sqlite_master WHERE type='table'");
                if (clr) Tables.Clear();

                while (rdr.Read())
                {
                    if (!Tables.Contains(rdr.GetString(0)))
                    {
                        Tables.Add(rdr.GetString(0));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool TableIsExist(string name) => Tables.Contains(name);
    }
}
