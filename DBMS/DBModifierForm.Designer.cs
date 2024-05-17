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
            GroupBoxFields = new GroupBox();
            listView1 = new ListView();
            CName = new ColumnHeader();
            CType = new ColumnHeader();
            CNN = new ColumnHeader();
            CPK = new ColumnHeader();
            CAI = new ColumnHeader();
            CDefault = new ColumnHeader();
            ButtonCommit = new Button();
            ButtonBack = new Button();
            GroupBoxTableName.SuspendLayout();
            GroupBoxFields.SuspendLayout();
            SuspendLayout();
            // 
            // TextBoxTableName
            // 
            TextBoxTableName.Location = new Point(6, 22);
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
            // GroupBoxFields
            // 
            GroupBoxFields.Controls.Add(ButtonCommit);
            GroupBoxFields.Controls.Add(listView1);
            GroupBoxFields.Location = new Point(12, 149);
            GroupBoxFields.Name = "GroupBoxFields";
            GroupBoxFields.Size = new Size(770, 411);
            GroupBoxFields.TabIndex = 2;
            GroupBoxFields.TabStop = false;
            GroupBoxFields.Text = "Fields";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { CName, CType, CNN, CPK, CAI, CDefault });
            listView1.Location = new Point(6, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(758, 346);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // CName
            // 
            CName.Text = "Name";
            CName.Width = 120;
            // 
            // CType
            // 
            CType.Text = "Type";
            CType.Width = 120;
            // 
            // CNN
            // 
            CNN.Text = "Not Null";
            CNN.Width = 120;
            // 
            // CPK
            // 
            CPK.Text = "Primary Key";
            CPK.Width = 120;
            // 
            // CAI
            // 
            CAI.Text = "Auto Increment";
            CAI.Width = 120;
            // 
            // CDefault
            // 
            CDefault.Text = "Default Value";
            CDefault.Width = 120;
            // 
            // ButtonCommit
            // 
            ButtonCommit.Location = new Point(6, 376);
            ButtonCommit.Name = "ButtonCommit";
            ButtonCommit.Size = new Size(94, 29);
            ButtonCommit.TabIndex = 2;
            ButtonCommit.Text = "Commit";
            ButtonCommit.UseVisualStyleBackColor = true;
            // 
            // ButtonBack
            // 
            ButtonBack.Location = new Point(688, 566);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(94, 29);
            ButtonBack.TabIndex = 3;
            ButtonBack.Text = "Back";
            ButtonBack.UseVisualStyleBackColor = true;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // DBModifierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 604);
            Controls.Add(ButtonBack);
            Controls.Add(GroupBoxFields);
            Controls.Add(GroupBoxTableName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBModifierForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modify Table";
            GroupBoxTableName.ResumeLayout(false);
            GroupBoxTableName.PerformLayout();
            GroupBoxFields.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox TextBoxTableName;
        private GroupBox GroupBoxTableName;
        private Button ButtonTableRename;
        private GroupBox GroupBoxFields;
        private ListView listView1;
        private ColumnHeader CName;
        private ColumnHeader CType;
        private ColumnHeader CNN;
        private ColumnHeader CPK;
        private ColumnHeader CAI;
        private ColumnHeader CDefault;
        private Button ButtonCommit;
        private Button ButtonBack;
    }
}