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
            ButtonRemoveField = new Button();
            ButtonAddField = new Button();
            DataGridViewFields = new DataGridView();
            CName = new DataGridViewTextBoxColumn();
            CType = new DataGridViewComboBoxColumn();
            CNN = new DataGridViewCheckBoxColumn();
            CDef = new DataGridViewTextBoxColumn();
            CPK = new DataGridViewCheckBoxColumn();
            CU = new DataGridViewCheckBoxColumn();
            CAI = new DataGridViewCheckBoxColumn();
            ButtonCommit = new Button();
            ButtonBack = new Button();
            GroupBoxTableName.SuspendLayout();
            GroupBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewFields).BeginInit();
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
            GroupBoxFields.Controls.Add(ButtonRemoveField);
            GroupBoxFields.Controls.Add(ButtonAddField);
            GroupBoxFields.Controls.Add(DataGridViewFields);
            GroupBoxFields.Controls.Add(ButtonCommit);
            GroupBoxFields.Location = new Point(12, 112);
            GroupBoxFields.Name = "GroupBoxFields";
            GroupBoxFields.Size = new Size(770, 448);
            GroupBoxFields.TabIndex = 2;
            GroupBoxFields.TabStop = false;
            GroupBoxFields.Text = "Fields";
            // 
            // ButtonRemoveField
            // 
            ButtonRemoveField.Location = new Point(106, 15);
            ButtonRemoveField.Name = "ButtonRemoveField";
            ButtonRemoveField.Size = new Size(94, 29);
            ButtonRemoveField.TabIndex = 5;
            ButtonRemoveField.Text = "Remove";
            ButtonRemoveField.UseVisualStyleBackColor = true;
            ButtonRemoveField.Click += ButtonRemoveField_Click;
            // 
            // ButtonAddField
            // 
            ButtonAddField.Location = new Point(6, 15);
            ButtonAddField.Name = "ButtonAddField";
            ButtonAddField.Size = new Size(94, 29);
            ButtonAddField.TabIndex = 4;
            ButtonAddField.Text = "Add";
            ButtonAddField.UseVisualStyleBackColor = true;
            ButtonAddField.Click += ButtonAddField_Click;
            // 
            // DataGridViewFields
            // 
            DataGridViewFields.AllowUserToAddRows = false;
            DataGridViewFields.AllowUserToDeleteRows = false;
            DataGridViewFields.BackgroundColor = SystemColors.Window;
            DataGridViewFields.BorderStyle = BorderStyle.None;
            DataGridViewFields.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewFields.Columns.AddRange(new DataGridViewColumn[] { CName, CType, CNN, CDef, CPK, CU, CAI });
            DataGridViewFields.Location = new Point(6, 50);
            DataGridViewFields.MultiSelect = false;
            DataGridViewFields.Name = "DataGridViewFields";
            DataGridViewFields.RowHeadersVisible = false;
            DataGridViewFields.Size = new Size(758, 357);
            DataGridViewFields.TabIndex = 3;
            DataGridViewFields.CellContentClick += DataGridViewFields_CellContentClick;
            // 
            // CName
            // 
            CName.HeaderText = "Name";
            CName.Name = "CName";
            CName.Resizable = DataGridViewTriState.True;
            CName.SortMode = DataGridViewColumnSortMode.NotSortable;
            CName.Width = 160;
            // 
            // CType
            // 
            CType.HeaderText = "Type";
            CType.Items.AddRange(new object[] { "INTEGER", "TEXT", "BLOB", "REAL", "NUMERIC" });
            CType.Name = "CType";
            CType.Width = 145;
            // 
            // CNN
            // 
            CNN.HeaderText = "Not Null";
            CNN.Name = "CNN";
            CNN.Width = 60;
            // 
            // CDef
            // 
            CDef.HeaderText = "Default";
            CDef.Name = "CDef";
            CDef.Width = 152;
            // 
            // CPK
            // 
            CPK.HeaderText = "Primary Key";
            CPK.Name = "CPK";
            CPK.Width = 80;
            // 
            // CU
            // 
            CU.HeaderText = "Unique";
            CU.Name = "CU";
            CU.Width = 60;
            // 
            // CAI
            // 
            CAI.HeaderText = "Auto Increment";
            CAI.Name = "CAI";
            // 
            // ButtonCommit
            // 
            ButtonCommit.Location = new Point(6, 413);
            ButtonCommit.Name = "ButtonCommit";
            ButtonCommit.Size = new Size(94, 29);
            ButtonCommit.TabIndex = 2;
            ButtonCommit.Text = "Commit";
            ButtonCommit.UseVisualStyleBackColor = true;
            ButtonCommit.Click += ButtonCommit_Click;
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
            Text = "Table Modifier ";
            FormClosing += DBModifierForm_FormClosing;
            GroupBoxTableName.ResumeLayout(false);
            GroupBoxTableName.PerformLayout();
            GroupBoxFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridViewFields).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TextBoxTableName;
        private GroupBox GroupBoxTableName;
        private Button ButtonTableRename;
        private GroupBox GroupBoxFields;
        private Button ButtonCommit;
        private Button ButtonBack;
        private DataGridView DataGridViewFields;
        private Button ButtonAddField;
        private Button ButtonRemoveField;
        private DataGridViewTextBoxColumn CName;
        private DataGridViewComboBoxColumn CType;
        private DataGridViewCheckBoxColumn CNN;
        private DataGridViewTextBoxColumn CDef;
        private DataGridViewCheckBoxColumn CPK;
        private DataGridViewCheckBoxColumn CU;
        private DataGridViewCheckBoxColumn CAI;
    }
}