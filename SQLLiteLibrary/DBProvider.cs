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
            if (!NotProvided())
                throw new Exception("Connection is already provided!");

            if (IsEmpty(path))
                throw new Exception("Connection path was empty!");

            _path = $"DataSource={path}";
            _cnn = new SQLiteConnection(_path);
            return Connect();
        }

        public static void EndProviding()
        {
            if (NotProvided())
                throw new Exception("Connection wasn't provided!");

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
                ErrMessage(ex);
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
                ErrMessage(ex);
                throw;
            }
        }

        static void WriteCmd(string text)
        {
            if (IsEmpty(text))
                throw new Exception("Command text was empty!");

            if (NotProvided())
                throw new Exception("Connection was not provided!");

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
                ErrMessage(ex);
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
                ErrMessage(ex);
                return false;
            }
        }

        static void ErrMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static bool IsEmpty(string text) => string.IsNullOrEmpty(text);
        static bool NotProvided() => _cnn == null;
    }
}
