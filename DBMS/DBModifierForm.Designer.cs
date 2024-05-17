namespace DBMS
{
    partial class DBModifierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBoxTableName = new TextBox();
            GroupBoxTableName = new GroupBox();
            ButtonTableRename = new Button();
            GroupBoxTableName.SuspendLayout();
            SuspendLayout();
            // 
            // TextBoxTableName
            // 
            TextBoxTableName.Location = new Point(6, 26);
            TextBoxTableName.Name = "TextBoxTableName";
            TextBoxTableName.Size = new Size(764, 23);
            TextBoxTableName.TabIndex = 0;
            // 
            // GroupBoxTableName
            // 
            GroupBoxTableName.Controls.Add(ButtonTableRename);
            GroupBoxTableName.Controls.Add(TextBoxTableName);
            GroupBoxTableName.Location = new Point(12, 12);
            GroupBoxTableName.Name = "GroupBoxTableName";
            GroupBoxTableName.Size = new Size(776, 94);
            GroupBoxTableName.TabIndex = 1;
            GroupBoxTableName.TabStop = false;
            GroupBoxTableName.Text = "Table Name";
            // 
            // ButtonTableRename
            // 
            ButtonTableRename.Location = new Point(6, 55);
            ButtonTableRename.Name = "ButtonTableRename";
            ButtonTableRename.Size = new Size(94, 29);
            ButtonTableRename.TabIndex = 1;
            ButtonTableRename.Text = "Rename";
            ButtonTableRename.UseVisualStyleBackColor = true;
            ButtonTableRename.Click += ButtonTableRename_Click;
            // 
            // DBModifierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GroupBoxTableName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBModifierForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modify Table";
            GroupBoxTableName.ResumeLayout(false);
            GroupBoxTableName.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TextBoxTableName;
        private GroupBox GroupBoxTableName;
        private Button ButtonTableRename;
    }
}