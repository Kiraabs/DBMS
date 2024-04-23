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

        public static void Localize(ref string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name was empty!");

            name = $@"{Name}\{name}";
            if (!name.Contains(".db"))
                name += ".db";
        }
    }
}
