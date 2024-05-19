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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ListViewTables
            // 
            ListViewTables.Location = new Point(6, 22);
            ListViewTables.Name = "ListViewTables";
            ListViewTables.Size = new Size(438, 398);
            ListViewTables.TabIndex = 0;
            ListViewTables.UseCompatibleStateImageBehavior = false;
            ListViewTables.View = View.List;
            ListViewTables.ItemActivate += ListViewTables_ItemActivate;
            ListViewTables.SelectedIndexChanged += ListViewTables_SelectedIndexChanged;
            // 
            // ListViewTableInfo
            // 
            ListViewTableInfo.Columns.AddRange(new ColumnHeader[] { CID, CName, CType, CNN, CDltVal, CPK });
            ListViewTableInfo.Location = new Point(6, 22);
            ListViewTableInfo.Name = "ListViewTableInfo";
            ListViewTableInfo.Size = new Size(605, 434);
            ListViewTableInfo.TabIndex = 1;
            ListViewTableInfo.UseCompatibleStateImageBehavior = false;
            ListViewTableInfo.View = View.Details;
            // 
            // CID
            // 
            CID.Text = "ID";
            CID.Width = 100;
            // 
            // CName
            // 
            CName.Text = "Name";
            CName.Width = 100;
            // 
            // CType
            // 
            CType.Text = "Type";
            CType.Width = 100;
            // 
            // CNN
            // 
            CNN.Text = "Not Null";
            CNN.Width = 100;
            // 
            // CDltVal
            // 
            CDltVal.Text = "Default Value";
            CDltVal.Width = 100;
            // 
            // CPK
            // 
            CPK.Text = "Primary Key";
            CPK.Width = 100;
            // 
            // ButtonCreateTable
            // 
            ButtonCreateTable.Location = new Point(6, 426);
            ButtonCreateTable.Name = "ButtonCreateTable";
            ButtonCreateTable.Size = new Size(105, 30);
            ButtonCreateTable.TabIndex = 2;
            ButtonCreateTable.Text = "Create Table";
            ButtonCreateTable.UseVisualStyleBackColor = true;
            ButtonCreateTable.Click += ButtonCreateTable_Click;
            // 
            // ButtonDropTable
            // 
            ButtonDropTable.Location = new Point(117, 426);
            ButtonDropTable.Name = "ButtonDropTable";
            ButtonDropTable.Size = new Size(105, 30);
            ButtonDropTable.TabIndex = 3;
            ButtonDropTable.Text = "Drop Table";
            ButtonDropTable.UseVisualStyleBackColor = true;
            ButtonDropTable.Click += ButtonDropTable_Click;
            // 
            // ButtonModifyTable
            // 
            ButtonModifyTable.Location = new Point(228, 426);
            ButtonModifyTable.Name = "ButtonModifyTable";
            ButtonModifyTable.Size = new Size(105, 30);
            ButtonModifyTable.TabIndex = 4;
            ButtonModifyTable.Text = "Modife Table";
            ButtonModifyTable.UseVisualStyleBackColor = true;
            ButtonModifyTable.Click += ButtonModifyTable_Click;
            // 
            // ButtonQuit
            // 
            ButtonQuit.Location = new Point(339, 426);
            ButtonQuit.Name = "ButtonQuit";
            ButtonQuit.Size = new Size(105, 30);
            ButtonQuit.TabIndex = 5;
            ButtonQuit.Text = "Quit";
            ButtonQuit.UseVisualStyleBackColor = true;
            ButtonQuit.Click += ButtonQuit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ListViewTables);
            groupBox1.Controls.Add(ButtonCreateTable);
            groupBox1.Controls.Add(ButtonModifyTable);
            groupBox1.Controls.Add(ButtonDropTable);
            groupBox1.Controls.Add(ButtonQuit);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 462);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tables";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ListViewTableInfo);
            groupBox2.Location = new Point(473, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(618, 462);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Table Attributes";
            // 
            // DBEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 483);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Editor";
            FormClosed += DBEditorForm_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
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
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}