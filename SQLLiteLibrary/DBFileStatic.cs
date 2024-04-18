namespace SQLLiteLibrary
{
    public partial class DBFile
    {
        public static bool Create(string name)
        {
            name = $"{DBRoot.Name}\\{name}.db";

            if (File.Exists(name))
            {
                MessageBox.Show
                (
                    "DB with entered name already exists!",
                    "Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            try
            {
                var f = File.Create(name);
                f.Dispose();
                MessageBox.Show
                (
                    "DB successfully created!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return false;
        }

        public static bool Drop(string name)
        {
            name = $"{DBRoot.Name}\\{name}.db";

            if (!File.Exists(name)) // just in case
            {
                MessageBox.Show
                (
                    "DB with entered name doesn't exists!",
                    "Not exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            try
            {
                File.Delete(name);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return false;
        }
    }
}
