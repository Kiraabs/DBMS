using System.Data.SQLite;

namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Provides connection and executes cmd's to DB file.
    /// </summary>
    public static class DBProvider
    {
        static string _path = string.Empty;
        static SQLiteConnection _cnn = null!;
        static SQLiteCommand _cmd = null!;
        static SQLiteDataReader _rdr = null!;

        public static bool Provide(string path)
        {
            DBException.ThrowIfConnectionIsProvided(_cnn);
            DBException.ThrowIfStringIsEmpty(path, "Path to database file was empty!");
            _path = $"DataSource={path}";
            _cnn = new SQLiteConnection(_path);
            return Connect();
        }

        public static void EndProviding()
        {
            DBException.ThrowIfConnectionIsNotProvided(_cnn);
            Disconnect();
            _path = string.Empty;
            _cnn.Dispose();
            _cmd.Dispose();
            _rdr.Dispose();
            _cnn = null!;
            _cmd = null!;
            _rdr = null!;
        }

        public static bool ExecuteSimpleCmd(string text)
        {
            try
            {
                WriteCmd(text);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                return false;
            }
        }

        public static SQLiteDataReader ExecuteReaderCmd(string text)
        {
            try
            {
                WriteCmd(text);
                _rdr = _cmd.ExecuteReader();
                return _rdr;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                throw;
            }
        }

        static void WriteCmd(string text)
        {
            DBException.ThrowIfStringIsEmpty(text, "Command text was empty!");
            DBException.ThrowIfConnectionIsNotProvided(_cnn);
            _cmd = new SQLiteCommand(text, _cnn);
        }

        static bool Connect()
        {
            try
            {
                _cnn.Open();
                return true;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                return false;
            }
        }

        static bool Disconnect()
        {
            try
            {
                _cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                DBException.ErrMSG(ex.Message);
                return false;
            }
        }
    }
}
