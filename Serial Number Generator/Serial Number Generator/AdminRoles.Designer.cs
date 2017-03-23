namespace Serial_Number_Generator
{
    partial class AdminRoles
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FactoryIDComboBox = new System.Windows.Forms.ComboBox();
            this.ProductIDComboBox = new System.Windows.Forms.ComboBox();
            this.FactoryIDLabel = new System.Windows.Forms.Label();
            this.ProductIDLabel = new System.Windows.Forms.Label();
            this.FactoryIDErrorLabel = new System.Windows.Forms.Label();
            this.ProductIDErrorLabel = new System.Windows.Forms.Label();
            this.CreateSNBtn = new System.Windows.Forms.Button();
            this.PrinterLabel = new System.Windows.Forms.Label();
            this.ModelNumberLabel = new System.Windows.Forms.Label();
            this.ModelNumberErrorLabel = new System.Windows.Forms.Label();
            this.ModelNumberCb = new System.Windows.Forms.ComboBox();
            this.NumberOfSNLabel = new System.Windows.Forms.Label();
            this.NumberOfSNTb = new System.Windows.Forms.TextBox();
            this.NumberOfSNErrorLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // FactoryIDComboBox
            // 
            this.FactoryIDComboBox.FormattingEnabled = true;
            this.FactoryIDComboBox.Location = new System.Drawing.Point(147, 77);
            this.FactoryIDComboBox.Name = "FactoryIDComboBox";
            this.FactoryIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.FactoryIDComboBox.TabIndex = 4;
            // 
            // ProductIDComboBox
            // 
            this.ProductIDComboBox.FormattingEnabled = true;
            this.ProductIDComboBox.Location = new System.Drawing.Point(147, 104);
            this.ProductIDComboBox.Name = "ProductIDComboBox";
            this.ProductIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.ProductIDComboBox.TabIndex = 5;
            // 
            // FactoryIDLabel
            // 
            this.FactoryIDLabel.AutoSize = true;
            this.FactoryIDLabel.Location = new System.Drawing.Point(12, 77);
            this.FactoryIDLabel.Name = "FactoryIDLabel";
            this.FactoryIDLabel.Size = new System.Drawing.Size(56, 13);
            this.FactoryIDLabel.TabIndex = 6;
            this.FactoryIDLabel.Text = "Factory ID";
            // 
            // ProductIDLabel
            // 
            this.ProductIDLabel.AutoSize = true;
            this.ProductIDLabel.Location = new System.Drawing.Point(12, 104);
            this.ProductIDLabel.Name = "ProductIDLabel";
            this.ProductIDLabel.Size = new System.Drawing.Size(58, 13);
            this.ProductIDLabel.TabIndex = 7;
            this.ProductIDLabel.Text = "Product ID";
            // 
            // FactoryIDErrorLabel
            // 
            this.FactoryIDErrorLabel.AutoSize = true;
            this.FactoryIDErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FactoryIDErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.FactoryIDErrorLabel.Location = new System.Drawing.Point(279, 79);
            this.FactoryIDErrorLabel.Name = "FactoryIDErrorLabel";
            this.FactoryIDErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.FactoryIDErrorLabel.TabIndex = 9;
            // 
            // ProductIDErrorLabel
            // 
            this.ProductIDErrorLabel.AutoSize = true;
            this.ProductIDErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIDErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ProductIDErrorLabel.Location = new System.Drawing.Point(279, 107);
            this.ProductIDErrorLabel.Name = "ProductIDErrorLabel";
            this.ProductIDErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.ProductIDErrorLabel.TabIndex = 9;
            // 
            // CreateSNBtn
            // 
            this.CreateSNBtn.Location = new System.Drawing.Point(91, 220);
            this.CreateSNBtn.Name = "CreateSNBtn";
            this.CreateSNBtn.Size = new System.Drawing.Size(122, 23);
            this.CreateSNBtn.TabIndex = 11;
            this.CreateSNBtn.Text = "Create Serial Numbers";
            this.CreateSNBtn.UseVisualStyleBackColor = true;
            this.CreateSNBtn.Click += new System.EventHandler(this.Create_Click);
            // 
            // PrinterLabel
            // 
            this.PrinterLabel.AutoSize = true;
            this.PrinterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrinterLabel.Location = new System.Drawing.Point(12, 35);
            this.PrinterLabel.Name = "PrinterLabel";
            this.PrinterLabel.Size = new System.Drawing.Size(110, 13);
            this.PrinterLabel.TabIndex = 12;
            this.PrinterLabel.Text = "Printer Selected : ";
            // 
            // ModelNumberLabel
            // 
            this.ModelNumberLabel.AutoSize = true;
            this.ModelNumberLabel.Location = new System.Drawing.Point(12, 132);
            this.ModelNumberLabel.Name = "ModelNumberLabel";
            this.ModelNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.ModelNumberLabel.TabIndex = 14;
            this.ModelNumberLabel.Text = "Model Number";
            // 
            // ModelNumberErrorLabel
            // 
            this.ModelNumberErrorLabel.AutoSize = true;
            this.ModelNumberErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelNumberErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ModelNumberErrorLabel.Location = new System.Drawing.Point(279, 132);
            this.ModelNumberErrorLabel.Name = "ModelNumberErrorLabel";
            this.ModelNumberErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.ModelNumberErrorLabel.TabIndex = 15;
            // 
            // ModelNumberCb
            // 
            this.ModelNumberCb.FormattingEnabled = true;
            this.ModelNumberCb.Items.AddRange(new object[] {
            "SR001",
            "SR002"});
            this.ModelNumberCb.Location = new System.Drawing.Point(147, 129);
            this.ModelNumberCb.Name = "ModelNumberCb";
            this.ModelNumberCb.Size = new System.Drawing.Size(121, 21);
            this.ModelNumberCb.TabIndex = 17;
            // 
            // NumberOfSNLabel
            // 
            this.NumberOfSNLabel.AutoSize = true;
            this.NumberOfSNLabel.Location = new System.Drawing.Point(12, 156);
            this.NumberOfSNLabel.Name = "NumberOfSNLabel";
            this.NumberOfSNLabel.Size = new System.Drawing.Size(130, 13);
            this.NumberOfSNLabel.TabIndex = 18;
            this.NumberOfSNLabel.Text = "Number of Serial Numbers";
            // 
            // NumberOfSNTb
            // 
            this.NumberOfSNTb.Location = new System.Drawing.Point(147, 156);
            this.NumberOfSNTb.Name = "NumberOfSNTb";
            this.NumberOfSNTb.Size = new System.Drawing.Size(121, 20);
            this.NumberOfSNTb.TabIndex = 19;
            // 
            // NumberOfSNErrorLabel
            // 
            this.NumberOfSNErrorLabel.AutoSize = true;
            this.NumberOfSNErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfSNErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.NumberOfSNErrorLabel.Location = new System.Drawing.Point(279, 158);
            this.NumberOfSNErrorLabel.Name = "NumberOfSNErrorLabel";
            this.NumberOfSNErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.NumberOfSNErrorLabel.TabIndex = 20;
            // 
            // AdminRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 265);
            this.Controls.Add(this.NumberOfSNErrorLabel);
            this.Controls.Add(this.NumberOfSNTb);
            this.Controls.Add(this.NumberOfSNLabel);
            this.Controls.Add(this.ModelNumberCb);
            this.Controls.Add(this.ModelNumberErrorLabel);
            this.Controls.Add(this.ModelNumberLabel);
            this.Controls.Add(this.PrinterLabel);
            this.Controls.Add(this.CreateSNBtn);
            this.Controls.Add(this.ProductIDErrorLabel);
            this.Controls.Add(this.FactoryIDErrorLabel);
            this.Controls.Add(this.ProductIDLabel);
            this.Controls.Add(this.FactoryIDLabel);
            this.Controls.Add(this.ProductIDComboBox);
            this.Controls.Add(this.FactoryIDComboBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminRoles";
            this.Text = "AdminRoles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminRoles_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ComboBox FactoryIDComboBox;
        private System.Windows.Forms.ComboBox ProductIDComboBox;
        private System.Windows.Forms.Label FactoryIDLabel;
        private System.Windows.Forms.Label ProductIDLabel;
        private System.Windows.Forms.Label FactoryIDErrorLabel;
        private System.Windows.Forms.Label ProductIDErrorLabel;
        private System.Windows.Forms.Button CreateSNBtn;
        private System.Windows.Forms.Label PrinterLabel;
        private System.Windows.Forms.Label ModelNumberLabel;
        private System.Windows.Forms.Label ModelNumberErrorLabel;
        private System.Windows.Forms.ComboBox ModelNumberCb;
        private System.Windows.Forms.Label NumberOfSNLabel;
        private System.Windows.Forms.TextBox NumberOfSNTb;
        private System.Windows.Forms.Label NumberOfSNErrorLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}