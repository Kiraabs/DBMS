namespace DBMS.ClassLibrary
{
    /// <summary>
    /// Represents root directory of DB files.
    /// </summary>
    public static class DBRoot
    {
        public const string Name = "DBs";
        public static DirectoryInfo Dir { get; private set; }

        static DBRoot()
        {
            Dir = new(Name);
            if (!Dir.Exists) 
                Dir.Create();
        }

        public static string Localize(string name)
        {
            DBException.ThrowIfStringIsEmpty(name, "Name was empty!");
            if (!name.Contains(".db"))
                name += ".db";
            var path = $@"{Dir.FullName}\{name}";
            return path;
        }
    }
}
