using System.Data;

namespace DBMS.ClassLibrary
{
    public static class ListViewExtension
    {
        public static void TableToView(this ListView view, string name)
        {
            for (int i = 0; i < view.Columns.Count; i++)
            {
                var col = view.Columns[i];
                var lvi = new ListViewItem(new string[] { col.Name });
                view.Items.Add(lvi);
            }
        }
    }
}
