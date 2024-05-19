using System.Data;
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
        static SQLiteDataAdapter _adr = null!;
        static DataTable _dt = null!;

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
            _adr.Dispose();
            _dt.Dispose();
            _cnn = null!;
            _cmd = null!;
            _adr = null!;
            _dt = null!;
        }

        /// <summary>
        /// Executes cmd.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
                UserMSG.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Returns executed as adapter cmd.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static SQLiteDataAdapter ExecuteAdapterCmd(string text)
        {
            try
            {
                WriteCmd(text);
                return _adr = new SQLiteDataAdapter(_cmd);
            }
            catch (Exception ex)
            {
                UserMSG.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Executes cmd and retrieves data.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DataTable RetrieveDataFromCmd(string text)
        {
            try
            {
                _dt = new DataTable();
                WriteCmd(text);
                ExecuteAdapterCmd(text).Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                UserMSG.Error(ex.Message);
                throw;
            }
        }

        static bool Connect() => ConnectionAction(_cnn.Open);

        static bool Disconnect() => ConnectionAction(_cnn.Close);

        static void WriteCmd(string text)
        {
            DBException.ThrowIfStringIsEmpty(text, "Command text was empty!");
            DBException.ThrowIfConnectionIsNotProvided(_cnn);
            _cmd = new SQLiteCommand(text, _cnn);
        }

        static bool ConnectionAction(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                UserMSG.Error(ex.Message);
                return false;
            }
        }
    }
}
