namespace DBMS
{
    partial class DBTableCreateForm
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
            ButtonCreate = new Button();
            TextBoxTableName = new TextBox();
            LabelTabName = new Label();
            label1 = new Label();
            TextBoxPKFName = new TextBox();
            SuspendLayout();
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(425, 114);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(75, 23);
            ButtonCreate.TabIndex = 3;
            ButtonCreate.Text = "Create";
            ButtonCreate.UseVisualStyleBackColor = true;
            ButtonCreate.Click += ButtonCreate_Click;
            // 
            // TextBoxTableName
            // 
            TextBoxTableName.Location = new Point(12, 25);
            TextBoxTableName.Name = "TextBoxTableName";
            TextBoxTableName.Size = new Size(488, 23);
            TextBoxTableName.TabIndex = 2;
            // 
            // LabelTabName
            // 
            LabelTabName.AutoSize = true;
            LabelTabName.Location = new Point(12, 7);
            LabelTabName.Name = "LabelTabName";
            LabelTabName.Size = new Size(72, 15);
            LabelTabName.TabIndex = 4;
            LabelTabName.Text = "Table Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 5;
            label1.Text = "Primary Field Name:";
            // 
            // TextBoxPKFName
            // 
            TextBoxPKFName.Location = new Point(12, 81);
            TextBoxPKFName.Name = "TextBoxPKFName";
            TextBoxPKFName.Size = new Size(488, 23);
            TextBoxPKFName.TabIndex = 6;
            // 
            // DBTableCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 149);
            Controls.Add(TextBoxPKFName);
            Controls.Add(label1);
            Controls.Add(LabelTabName);
            Controls.Add(ButtonCreate);
            Controls.Add(TextBoxTableName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBTableCreateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Table Create";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonCreate;
        private TextBox TextBoxTableName;
        private Label LabelTabName;
        private Label label1;
        private TextBox TextBoxPKFName;
    }
}