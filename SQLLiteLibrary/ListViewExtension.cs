namespace DBMS.ClassLibrary
{
    public static class ListViewExtension
    {
        public static void TableInfoToView(this ListView view, string name)
        {
            var table = DBFile.GetTable(name);
            var atrs = new string[table.Attributes.Count];

            for (int i = 0; i < table.Attributes.Count; i++)
            {
                atrs[i] = table.Attributes[i].Value.ToString()!;
                if (atrs[i] == string.Empty)
                    atrs[i] = "NULL";
            }

            view.Items.Add(new ListViewItem(atrs));
        }
    }
}
