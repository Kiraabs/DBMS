﻿using System.Data.SQLite;

namespace DBMS.ClassLibrary.DBClasses
{
    public sealed class DBTable : SQLiteVirtualTable
    {
        readonly int _attrsCnt = 0;
        string _shem = string.Empty;
        List<DBTableAttribute> _attrs = [];

        public string Shema { get => _shem; private set => _shem = value; }
        public List<DBTableAttribute> Attributes { get => _attrs; private set => _attrs = value; }

        /// <summary>
        /// Constructor for auto creating table. Use it ONLY if table IS EXISTS in DB File.
        /// </summary>
        /// <param name="args"></param>
        public DBTable(string[] args) : base(args)
        {
            _attrsCnt = DBQuery.TableRows(TableName).Count;
            _shem = DBQuery.TableSchema(TableName);
            GetAttrs();
        }

        /// <summary>
        /// Constructor for manually creating table. Usually used, when table is doesn't exist in DB File. 
        /// So, after init you can create this table by it schema using a create query.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="attrs"></param>
        public DBTable(string[] args, DBTableAttribute[] attrs) : base(args)
        {
            DBException.ThrowIfObjectIsNull(attrs, "Table should contains attributes!");
            _attrsCnt = attrs.Length;
            _attrs = [.. attrs];
            _shem = DBString.BuildTableSchema(this);
        }

        public override bool Rename(string newName)
        {
            if (DBQuery.TableRename(TableName, newName))
                return base.Rename(newName);
            return false;
        }

        void GetAttrs()
        {
            for (int i = 0; i < _attrsCnt; i++)
                _attrs.Add(new DBTableAttribute(DBQuery.TableRows(TableName)[i].ItemArray!, this));
        }
    }
}

 