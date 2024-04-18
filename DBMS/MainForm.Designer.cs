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
            ButtonRemoveDB = new Button();
            ButtonEditor = new Button();
            ButtonAIS = new Button();
            ListViewDBs = new ListView();
            SuspendLayout();
            // 
            // ButtonAddDB
            // 
            ButtonAddDB.Location = new Point(12, 253);
            ButtonAddDB.Name = "ButtonAddDB";
            ButtonAddDB.Size = new Size(119, 23);
            ButtonAddDB.TabIndex = 0;
            ButtonAddDB.Text = "Add DB";
            ButtonAddDB.UseVisualStyleBackColor = true;
            ButtonAddDB.Click += ButtonAddDB_Click;
            // 
            // ButtonRemoveDB
            // 
            ButtonRemoveDB.Location = new Point(12, 282);
            ButtonRemoveDB.Name = "ButtonRemoveDB";
            ButtonRemoveDB.Size = new Size(119, 23);
            ButtonRemoveDB.TabIndex = 1;
            ButtonRemoveDB.Text = "Remove DB";
            ButtonRemoveDB.UseVisualStyleBackColor = true;
            ButtonRemoveDB.Click += ButtonRemoveDB_Click;
            // 
            // ButtonEditor
            // 
            ButtonEditor.Location = new Point(342, 253);
            ButtonEditor.Name = "ButtonEditor";
            ButtonEditor.Size = new Size(119, 23);
            ButtonEditor.TabIndex = 2;
            ButtonEditor.Text = "Editor";
            ButtonEditor.UseVisualStyleBackColor = true;
            ButtonEditor.Click += ButtonEditor_Click;
            // 
            // ButtonAIS
            // 
            ButtonAIS.Location = new Point(342, 282);
            ButtonAIS.Name = "ButtonAIS";
            ButtonAIS.Size = new Size(119, 23);
            ButtonAIS.TabIndex = 3;
            ButtonAIS.Text = "AIS";
            ButtonAIS.UseVisualStyleBackColor = true;
            // 
            // ListViewDBs
            // 
            ListViewDBs.Location = new Point(12, 12);
            ListViewDBs.Name = "ListViewDBs";
            ListViewDBs.Size = new Size(449, 235);
            ListViewDBs.TabIndex = 4;
            ListViewDBs.UseCompatibleStateImageBehavior = false;
            ListViewDBs.View = View.List;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 317);
            Controls.Add(ListViewDBs);
            Controls.Add(ButtonAIS);
            Controls.Add(ButtonEditor);
            Controls.Add(ButtonRemoveDB);
            Controls.Add(ButtonAddDB);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Managment System";
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonAddDB;
        private Button ButtonRemoveDB;
        private Button ButtonEditor;
        private Button ButtonAIS;
        private ListView ListViewDBs;
    }
}
