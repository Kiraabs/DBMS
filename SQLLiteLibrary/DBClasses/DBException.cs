﻿using System.Data.SQLite;

namespace DBMS.ClassLibrary.DBClasses
{
    public static class DBException
    {
        public static void ThrowIfStringIsEmpty(string str, string msg)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException($"{msg}");
        }

        public static void ThrowIfObjectIsNull(object obj, string msg)
        {
            if (obj == null)
                throw new ArgumentException($"{msg}");
        }

        public static void ThrowIfDBFileNotCreated(string name)
        {
            ThrowIfStringIsEmpty(name, "Database file name was null or empty!");
            if (!File.Exists(name))
                throw new ArgumentException("File wasn't exists!");
        }

        public static void ThrowIfDBFileOpened(string name, object? sender = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"File already opened! Source: {sender?.ToString()}");
        }

        public static void ThrowIfDBFileIsNotOpened(string name, object? sender = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"File wasn't opened! Source: {sender?.ToString()}");
        }

        public static void ThrowIfConnectionIsProvided(SQLiteConnection connection)
        {
            if (connection != null)
                throw new ArgumentException("Connection is already provided!");
        }

        public static void ThrowIfConnectionIsNotProvided(SQLiteConnection connection)
        {
            if (connection == null)
                throw new ArgumentException("Connection wasn't provided!");
        }
    }
}
