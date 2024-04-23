namespace DBMS.ClassLibrary
{
    public static class ListViewExtension
    {
        public static void TableToView(this ListView view, string name)
        {
            foreach (var item in DBFile.GetTable(name).Columns)
            {
                view.Items.Add
                (
                    "A"
                );
            }
        }
    }
}
