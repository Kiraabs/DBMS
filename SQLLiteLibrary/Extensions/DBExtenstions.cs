namespace DBMS.ClassLibrary.Extensions
{
    public static class ListViewExtension
    {
        public static void TableToListView(this ListView lv, string name)
        {
            var table = DBFile.GetTable(name);
            for (int i = 0; i < table.Attributes.Count; i++)
                lv.Items.Add(new ListViewItem(table.Attributes[i].RowView()));
        }
    }
}
