namespace view
{
    partial class AdminForm
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
            this.enterQueryLabel = new System.Windows.Forms.Label();
            this.adminQueryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.submitQueryButton = new System.Windows.Forms.Button();
            this.rentalDataGridView = new System.Windows.Forms.DataGridView();
            this.adminResultLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentalDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // enterQueryLabel
            // 
            this.enterQueryLabel.AutoSize = true;
            this.enterQueryLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterQueryLabel.Location = new System.Drawing.Point(12, 35);
            this.enterQueryLabel.Name = "enterQueryLabel";
            this.enterQueryLabel.Size = new System.Drawing.Size(118, 14);
            this.enterQueryLabel.TabIndex = 0;
            this.enterQueryLabel.Text = "Enter your query:";
            // 
            // adminQueryRichTextBox
            // 
            this.adminQueryRichTextBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminQueryRichTextBox.Location = new System.Drawing.Point(15, 52);
            this.adminQueryRichTextBox.Name = "adminQueryRichTextBox";
            this.adminQueryRichTextBox.Size = new System.Drawing.Size(489, 153);
            this.adminQueryRichTextBox.TabIndex = 1;
            this.adminQueryRichTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(518, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.employeeToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(12, 20);
            // 
            // submitQueryButton
            // 
            this.submitQueryButton.Location = new System.Drawing.Point(15, 211);
            this.submitQueryButton.Name = "submitQueryButton";
            this.submitQueryButton.Size = new System.Drawing.Size(93, 25);
            this.submitQueryButton.TabIndex = 26;
            this.submitQueryButton.Text = "Submit";
            this.submitQueryButton.UseVisualStyleBackColor = true;
            this.submitQueryButton.Click += new System.EventHandler(this.submitQueryButton_Click);
            // 
            // rentalDataGridView
            // 
            this.rentalDataGridView.AllowUserToAddRows = false;
            this.rentalDataGridView.AllowUserToDeleteRows = false;
            this.rentalDataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.rentalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentalDataGridView.Location = new System.Drawing.Point(15, 258);
            this.rentalDataGridView.Name = "rentalDataGridView";
            this.rentalDataGridView.ReadOnly = true;
            this.rentalDataGridView.Size = new System.Drawing.Size(489, 183);
            this.rentalDataGridView.TabIndex = 35;
            // 
            // adminResultLabel
            // 
            this.adminResultLabel.AutoSize = true;
            this.adminResultLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminResultLabel.Location = new System.Drawing.Point(15, 243);
            this.adminResultLabel.Name = "adminResultLabel";
            this.adminResultLabel.Size = new System.Drawing.Size(58, 14);
            this.adminResultLabel.TabIndex = 36;
            this.adminResultLabel.Text = "Results:";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 451);
            this.Controls.Add(this.adminResultLabel);
            this.Controls.Add(this.rentalDataGridView);
            this.Controls.Add(this.submitQueryButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.adminQueryRichTextBox);
            this.Controls.Add(this.enterQueryLabel);
            this.Name = "AdminForm";
            this.Text = "RentMe Admin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentalDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterQueryLabel;
        private System.Windows.Forms.RichTextBox adminQueryRichTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Button submitQueryButton;
        private System.Windows.Forms.DataGridView rentalDataGridView;
        private System.Windows.Forms.Label adminResultLabel;
    }
}