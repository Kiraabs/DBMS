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
            SuspendLayout();
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(425, 41);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(75, 23);
            ButtonCreate.TabIndex = 3;
            ButtonCreate.Text = "Create";
            ButtonCreate.UseVisualStyleBackColor = true;
            ButtonCreate.Click += ButtonCreate_Click;
            // 
            // TextBoxTableName
            // 
            TextBoxTableName.Location = new Point(12, 12);
            TextBoxTableName.Name = "TextBoxTableName";
            TextBoxTableName.Size = new Size(488, 23);
            TextBoxTableName.TabIndex = 2;
            // 
            // DBTableCreateNameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 72);
            Controls.Add(ButtonCreate);
            Controls.Add(TextBoxTableName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBTableCreateNameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter Table Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonCreate;
        private TextBox TextBoxTableName;
    }
}