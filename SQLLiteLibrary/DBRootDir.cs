using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLiteLibrary
{
    /// <summary>
    /// Represents root folder of DB files.
    /// </summary>
    public static class DBRootDir
    {
        public const string Name = "DBs";
        public static DirectoryInfo Info { get; private set; }

        static DBRootDir()
        {
            Info = new(Name);
            if (!Info.Exists) Info.Create();
        }
    }
}
