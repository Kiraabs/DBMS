namespace SQLLiteLibrary
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
            if (!Dir.Exists) Dir.Create();
        }
    }
}
