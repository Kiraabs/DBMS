namespace DBMS
{
    partial class DBEditor
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
            cTabName = new ColumnHeader();
            cTabType = new ColumnHeader();
            cTabScheme = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ButtonSaQ = new Button();
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
            // 
            // ListViewTableInfo
            // 
            ListViewTableInfo.Columns.AddRange(new ColumnHeader[] { cTabName, cTabType, cTabScheme });
            ListViewTableInfo.Location = new Point(504, 12);
            ListViewTableInfo.Name = "ListViewTableInfo";
            ListViewTableInfo.Size = new Size(436, 426);
            ListViewTableInfo.TabIndex = 1;
            ListViewTableInfo.UseCompatibleStateImageBehavior = false;
            ListViewTableInfo.View = View.Details;
            // 
            // cTabName
            // 
            cTabName.Text = "Name";
            // 
            // cTabType
            // 
            cTabType.Text = "Type";
            // 
            // cTabScheme
            // 
            cTabScheme.Text = "Scheme";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(117, 30);
            button1.TabIndex = 2;
            button1.Text = "Create Table";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(135, 12);
            button2.Name = "button2";
            button2.Size = new Size(117, 30);
            button2.TabIndex = 3;
            button2.Text = "Delete Table";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(258, 12);
            button3.Name = "button3";
            button3.Size = new Size(117, 30);
            button3.TabIndex = 4;
            button3.Text = "Modife Table";
            button3.UseVisualStyleBackColor = true;
            // 
            // ButtonSaQ
            // 
            ButtonSaQ.Location = new Point(381, 12);
            ButtonSaQ.Name = "ButtonSaQ";
            ButtonSaQ.Size = new Size(117, 30);
            ButtonSaQ.TabIndex = 5;
            ButtonSaQ.Text = "Save and Quit";
            ButtonSaQ.UseVisualStyleBackColor = true;
            // 
            // DBEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 450);
            Controls.Add(ButtonSaQ);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ListViewTableInfo);
            Controls.Add(ListViewTables);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "DBEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editor";
            ResumeLayout(false);
        }

        #endregion

        private ListView ListViewTables;
        private ListView ListViewTableInfo;
        private ColumnHeader cTabName;
        private Button button1;
        private Button button2;
        private Button button3;
        private ColumnHeader cTabType;
        private ColumnHeader cTabScheme;
        private Button ButtonSaQ;
    }
}