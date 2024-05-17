namespace DBMS.ClassLibrary
{
    public static class UserMSG
    {
        public static DialogResult Info(string msg, string hdr = "Information") => DefMsg(msg, hdr, MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static DialogResult Confirm(string msg, string hdr = "Confirmation") => DefMsg(msg, hdr, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        public static DialogResult Warn(string msg, string hdr = "Warning") => DefMsg(msg, hdr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public static DialogResult Error(string msg, string hdr = "Error") => DefMsg(msg, hdr, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static (DialogResult Dr, bool Empty) WarnIfTextEmpty(string msg, string text, string hdr = "Warning")
        {
            return WarnIfTrue(msg, string.IsNullOrWhiteSpace(text), hdr);
        }

        public static (DialogResult Dr, bool True) WarnIfTrue(string msg, bool condition, string hdr = "Warning")
        {
            if (condition)
                return (Warn(msg, hdr), true);
            return (0, false);
        }

        static DialogResult DefMsg(string msg, string hdr, MessageBoxButtons bts, MessageBoxIcon icon)
        {
            if (string.IsNullOrEmpty(msg) || string.IsNullOrWhiteSpace(hdr))
                throw new ArgumentException("Message box should contains message and header!");
            return MessageBox.Show(msg, hdr, bts, icon);
        }
    }
}
