namespace DBMS
{
    partial class DBCreateNameForm
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
            TextBoxDBName = new TextBox();
            ButtonCreate = new Button();
            SuspendLayout();
            // 
            // TextBoxDBName
            // 
            TextBoxDBName.Location = new Point(12, 12);
            TextBoxDBName.Name = "TextBoxDBName";
            TextBoxDBName.Size = new Size(488, 23);
            TextBoxDBName.TabIndex = 0;
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(425, 41);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(75, 23);
            ButtonCreate.TabIndex = 1;
            ButtonCreate.Text = "Create";
            ButtonCreate.UseVisualStyleBackColor = true;
            ButtonCreate.Click += ButtonCreate_Click;
            // 
            // DBCreateNameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 71);
            Controls.Add(ButtonCreate);
            Controls.Add(TextBoxDBName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DBCreateNameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Create";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxDBName;
        private Button ButtonCreate;
    }
}