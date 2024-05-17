using System.Data;

namespace DBMS.ClassLibrary
{
    public static class ListViewExtension
    {
        public static void TableInfoToView(this ListView view, string name)
        {
            var table = DBFile.GetTable(name);
            var attrs = new string[table.Attributes.Count];

            for (int i = 0; i < table.Attributes.Count; i++)
            {
                attrs[i] = table.Attributes[i].Value.ToString()!;
                if (attrs[i] == string.Empty)
                    attrs[i] = "NULL";
            }

            view.Items.Add(new ListViewItem(attrs));
        }
    }
}
