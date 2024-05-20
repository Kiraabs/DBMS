namespace DBMS
{
    partial class DBDataEditorForm
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
            GroupBoxTableData = new GroupBox();
            DataGridViewTableData = new DataGridView();
            ButtonCommit = new Button();
            ButtonBack = new Button();
            GroupBoxTableData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewTableData).BeginInit();
            SuspendLayout();
            // 
            // GroupBoxTableData
            // 
            GroupBoxTableData.Controls.Add(DataGridViewTableData);
            GroupBoxTableData.Location = new Point(12, 12);
            GroupBoxTableData.Name = "GroupBoxTableData";
            GroupBoxTableData.Size = new Size(825, 440);
            GroupBoxTableData.TabIndex = 0;
            GroupBoxTableData.TabStop = false;
            GroupBoxTableData.Text = "Table ";
            // 
            // DataGridViewTableData
            // 
            DataGridViewTableData.BackgroundColor = SystemColors.Window;
            DataGridViewTableData.BorderStyle = BorderStyle.None;
            DataGridViewTableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewTableData.Location = new Point(6, 22);
            DataGridViewTableData.Name = "DataGridViewTableData";
            DataGridViewTableData.Size = new Size(813, 412);
            DataGridViewTableData.TabIndex = 0;
            // 
            // ButtonCommit
            // 
            ButtonCommit.Location = new Point(12, 457);
            ButtonCommit.Name = "ButtonCommit";
            ButtonCommit.Size = new Size(121, 33);
            ButtonCommit.TabIndex = 1;
            ButtonCommit.Text = "Commit";
            ButtonCommit.UseVisualStyleBackColor = true;
            ButtonCommit.Click += ButtonCommit_Click;
            // 
            // ButtonBack
            // 
            ButtonBack.Location = new Point(139, 457);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(121, 33);
            ButtonBack.TabIndex = 2;
            ButtonBack.Text = "Back";
            ButtonBack.UseVisualStyleBackColor = true;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // DBDataEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 502);
            Controls.Add(ButtonBack);
            Controls.Add(ButtonCommit);
            Controls.Add(GroupBoxTableData);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBDataEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editing Table Data";
            GroupBoxTableData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridViewTableData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GroupBoxTableData;
        private DataGridView DataGridViewTableData;
        private Button ButtonCommit;
        private Button ButtonBack;
    }
}