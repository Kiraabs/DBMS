namespace DBMS
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonAddDB = new Button();
            ButtonDropBD = new Button();
            ButtonEditor = new Button();
            ListViewDBs = new ListView();
            ButtonOpenDB = new Button();
            GroupBoxDatabases = new GroupBox();
            GroupBoxDatabases.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonAddDB
            // 
            ButtonAddDB.Location = new Point(461, 22);
            ButtonAddDB.Name = "ButtonAddDB";
            ButtonAddDB.Size = new Size(86, 44);
            ButtonAddDB.TabIndex = 0;
            ButtonAddDB.Text = "Create Database File";
            ButtonAddDB.UseVisualStyleBackColor = true;
            ButtonAddDB.Click += ButtonCreateDB_Click;
            // 
            // ButtonDropBD
            // 
            ButtonDropBD.Location = new Point(461, 122);
            ButtonDropBD.Name = "ButtonDropBD";
            ButtonDropBD.Size = new Size(86, 44);
            ButtonDropBD.TabIndex = 1;
            ButtonDropBD.Text = "Drop Database File";
            ButtonDropBD.UseVisualStyleBackColor = true;
            ButtonDropBD.Click += ButtonDropDB_Click;
            // 
            // ButtonEditor
            // 
            ButtonEditor.Location = new Point(461, 172);
            ButtonEditor.Name = "ButtonEditor";
            ButtonEditor.Size = new Size(86, 44);
            ButtonEditor.TabIndex = 2;
            ButtonEditor.Text = "Editor";
            ButtonEditor.UseVisualStyleBackColor = true;
            ButtonEditor.Click += ButtonEditor_Click;
            // 
            // ListViewDBs
            // 
            ListViewDBs.Location = new Point(6, 22);
            ListViewDBs.Name = "ListViewDBs";
            ListViewDBs.Size = new Size(449, 194);
            ListViewDBs.TabIndex = 4;
            ListViewDBs.UseCompatibleStateImageBehavior = false;
            ListViewDBs.View = View.List;
            ListViewDBs.ItemActivate += ListViewDBs_ItemActivate;
            // 
            // ButtonOpenDB
            // 
            ButtonOpenDB.Location = new Point(461, 72);
            ButtonOpenDB.Name = "ButtonOpenDB";
            ButtonOpenDB.Size = new Size(86, 44);
            ButtonOpenDB.TabIndex = 5;
            ButtonOpenDB.Text = "Add Foreign Database File";
            ButtonOpenDB.UseVisualStyleBackColor = true;
            ButtonOpenDB.Click += ButtonAddForeignDB_Click;
            // 
            // GroupBoxDatabases
            // 
            GroupBoxDatabases.Controls.Add(ListViewDBs);
            GroupBoxDatabases.Controls.Add(ButtonAddDB);
            GroupBoxDatabases.Controls.Add(ButtonDropBD);
            GroupBoxDatabases.Controls.Add(ButtonOpenDB);
            GroupBoxDatabases.Controls.Add(ButtonEditor);
            GroupBoxDatabases.Location = new Point(12, 12);
            GroupBoxDatabases.Name = "GroupBoxDatabases";
            GroupBoxDatabases.Size = new Size(554, 232);
            GroupBoxDatabases.TabIndex = 6;
            GroupBoxDatabases.TabStop = false;
            GroupBoxDatabases.Text = "Databases";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 256);
            Controls.Add(GroupBoxDatabases);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Managment System";
            FormClosed += MainForm_FormClosed;
            GroupBoxDatabases.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonAddDB;
        private Button ButtonDropBD;
        private Button ButtonEditor;
        private ListView ListViewDBs;
        private Button ButtonOpenDB;
        private GroupBox GroupBoxDatabases;
    }
}
