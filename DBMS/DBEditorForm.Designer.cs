namespace DBMS
{
    partial class DBEditorForm
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
            ListViewTables = new ListView();
            ListViewTableInfo = new ListView();
            CID = new ColumnHeader();
            CName = new ColumnHeader();
            CType = new ColumnHeader();
            CNN = new ColumnHeader();
            CDltVal = new ColumnHeader();
            CPK = new ColumnHeader();
            ButtonCreateTable = new Button();
            ButtonDropTable = new Button();
            ButtonModifyTable = new Button();
            ButtonQuit = new Button();
            SuspendLayout();
            // 
            // ListViewTables
            // 
            ListViewTables.Location = new Point(12, 48);
            ListViewTables.Name = "ListViewTables";
            ListViewTables.Size = new Size(486, 390);
            ListViewTables.TabIndex = 0;
            ListViewTables.UseCompatibleStateImageBehavior = false;
            ListViewTables.View = View.List;
            ListViewTables.SelectedIndexChanged += ListViewTables_SelectedIndexChanged;
            // 
            // ListViewTableInfo
            // 
            ListViewTableInfo.Columns.AddRange(new ColumnHeader[] { CID, CName, CType, CNN, CDltVal, CPK });
            ListViewTableInfo.Location = new Point(504, 12);
            ListViewTableInfo.Name = "ListViewTableInfo";
            ListViewTableInfo.Size = new Size(436, 426);
            ListViewTableInfo.TabIndex = 1;
            ListViewTableInfo.UseCompatibleStateImageBehavior = false;
            ListViewTableInfo.View = View.Details;
            // 
            // CID
            // 
            CID.Text = "ID";
            // 
            // CName
            // 
            CName.Text = "Name";
            // 
            // CType
            // 
            CType.Text = "Type";
            // 
            // CNN
            // 
            CNN.Text = "Not Null";
            // 
            // CDltVal
            // 
            CDltVal.Text = "Default Value";
            // 
            // CPK
            // 
            CPK.Text = "Auto Increment";
            // 
            // ButtonCreateTable
            // 
            ButtonCreateTable.Location = new Point(12, 12);
            ButtonCreateTable.Name = "ButtonCreateTable";
            ButtonCreateTable.Size = new Size(117, 30);
            ButtonCreateTable.TabIndex = 2;
            ButtonCreateTable.Text = "Create Table";
            ButtonCreateTable.UseVisualStyleBackColor = true;
            ButtonCreateTable.Click += ButtonCreateTable_Click;
            // 
            // ButtonDropTable
            // 
            ButtonDropTable.Location = new Point(135, 12);
            ButtonDropTable.Name = "ButtonDropTable";
            ButtonDropTable.Size = new Size(117, 30);
            ButtonDropTable.TabIndex = 3;
            ButtonDropTable.Text = "Drop Table";
            ButtonDropTable.UseVisualStyleBackColor = true;
            ButtonDropTable.Click += ButtonDropTable_Click;
            // 
            // ButtonModifyTable
            // 
            ButtonModifyTable.Location = new Point(258, 12);
            ButtonModifyTable.Name = "ButtonModifyTable";
            ButtonModifyTable.Size = new Size(117, 30);
            ButtonModifyTable.TabIndex = 4;
            ButtonModifyTable.Text = "Modife Table";
            ButtonModifyTable.UseVisualStyleBackColor = true;
            ButtonModifyTable.Click += ButtonModifyTable_Click;
            // 
            // ButtonQuit
            // 
            ButtonQuit.Location = new Point(381, 12);
            ButtonQuit.Name = "ButtonQuit";
            ButtonQuit.Size = new Size(117, 30);
            ButtonQuit.TabIndex = 5;
            ButtonQuit.Text = "Quit";
            ButtonQuit.UseVisualStyleBackColor = true;
            ButtonQuit.Click += ButtonQuit_Click;
            // 
            // DBEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 450);
            Controls.Add(ButtonQuit);
            Controls.Add(ButtonModifyTable);
            Controls.Add(ButtonDropTable);
            Controls.Add(ButtonCreateTable);
            Controls.Add(ListViewTableInfo);
            Controls.Add(ListViewTables);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Editor";
            FormClosed += DBEditorForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private ListView ListViewTables;
        private ListView ListViewTableInfo;
        private Button ButtonCreateTable;
        private Button ButtonDropTable;
        private Button ButtonModifyTable;
        private Button ButtonQuit;
        private ColumnHeader CID;
        private ColumnHeader CName;
        private ColumnHeader CType;
        private ColumnHeader CNN;
        private ColumnHeader CDltVal;
        private ColumnHeader CPK;
    }
}