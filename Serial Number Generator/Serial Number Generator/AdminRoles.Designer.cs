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
            this.CreateSerialNumberButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintLabelBtn = new System.Windows.Forms.Button();
            this.FactoryIDComboBox = new System.Windows.Forms.ComboBox();
            this.ProductIDComboBox = new System.Windows.Forms.ComboBox();
            this.FactoryIDLabel = new System.Windows.Forms.Label();
            this.ProductIDLabel = new System.Windows.Forms.Label();
            this.SerialNumberCreatedLabel = new System.Windows.Forms.Label();
            this.FactoryIDErrorLabel = new System.Windows.Forms.Label();
            this.ProductIDErrorLabel = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateSerialNumberButton
            // 
            this.CreateSerialNumberButton.Location = new System.Drawing.Point(89, 222);
            this.CreateSerialNumberButton.Name = "CreateSerialNumberButton";
            this.CreateSerialNumberButton.Size = new System.Drawing.Size(122, 23);
            this.CreateSerialNumberButton.TabIndex = 1;
            this.CreateSerialNumberButton.Text = "Create Serial Number";
            this.CreateSerialNumberButton.UseVisualStyleBackColor = true;
            this.CreateSerialNumberButton.Click += new System.EventHandler(this.CreateSerialNumberButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
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
            // PrintLabelBtn
            // 
            this.PrintLabelBtn.Location = new System.Drawing.Point(89, 251);
            this.PrintLabelBtn.Name = "PrintLabelBtn";
            this.PrintLabelBtn.Size = new System.Drawing.Size(122, 23);
            this.PrintLabelBtn.TabIndex = 3;
            this.PrintLabelBtn.Text = "Print Label";
            this.PrintLabelBtn.UseVisualStyleBackColor = true;
            this.PrintLabelBtn.Visible = false;
            // 
            // FactoryIDComboBox
            // 
            this.FactoryIDComboBox.FormattingEnabled = true;
            this.FactoryIDComboBox.Location = new System.Drawing.Point(128, 62);
            this.FactoryIDComboBox.Name = "FactoryIDComboBox";
            this.FactoryIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.FactoryIDComboBox.TabIndex = 4;
            // 
            // ProductIDComboBox
            // 
            this.ProductIDComboBox.FormattingEnabled = true;
            this.ProductIDComboBox.Location = new System.Drawing.Point(128, 89);
            this.ProductIDComboBox.Name = "ProductIDComboBox";
            this.ProductIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.ProductIDComboBox.TabIndex = 5;
            // 
            // FactoryIDLabel
            // 
            this.FactoryIDLabel.AutoSize = true;
            this.FactoryIDLabel.Location = new System.Drawing.Point(29, 62);
            this.FactoryIDLabel.Name = "FactoryIDLabel";
            this.FactoryIDLabel.Size = new System.Drawing.Size(56, 13);
            this.FactoryIDLabel.TabIndex = 6;
            this.FactoryIDLabel.Text = "Factory ID";
            // 
            // ProductIDLabel
            // 
            this.ProductIDLabel.AutoSize = true;
            this.ProductIDLabel.Location = new System.Drawing.Point(27, 89);
            this.ProductIDLabel.Name = "ProductIDLabel";
            this.ProductIDLabel.Size = new System.Drawing.Size(58, 13);
            this.ProductIDLabel.TabIndex = 7;
            this.ProductIDLabel.Text = "Product ID";
            // 
            // SerialNumberCreatedLabel
            // 
            this.SerialNumberCreatedLabel.AutoSize = true;
            this.SerialNumberCreatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialNumberCreatedLabel.Location = new System.Drawing.Point(70, 159);
            this.SerialNumberCreatedLabel.Name = "SerialNumberCreatedLabel";
            this.SerialNumberCreatedLabel.Size = new System.Drawing.Size(161, 16);
            this.SerialNumberCreatedLabel.TabIndex = 8;
            this.SerialNumberCreatedLabel.Text = "Serial number created";
            // 
            // FactoryIDErrorLabel
            // 
            this.FactoryIDErrorLabel.AutoSize = true;
            this.FactoryIDErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FactoryIDErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.FactoryIDErrorLabel.Location = new System.Drawing.Point(255, 65);
            this.FactoryIDErrorLabel.Name = "FactoryIDErrorLabel";
            this.FactoryIDErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.FactoryIDErrorLabel.TabIndex = 9;
            // 
            // ProductIDErrorLabel
            // 
            this.ProductIDErrorLabel.AutoSize = true;
            this.ProductIDErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIDErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ProductIDErrorLabel.Location = new System.Drawing.Point(255, 92);
            this.ProductIDErrorLabel.Name = "ProductIDErrorLabel";
            this.ProductIDErrorLabel.Size = new System.Drawing.Size(0, 18);
            this.ProductIDErrorLabel.TabIndex = 9;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(128, 117);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(121, 20);
            this.test.TabIndex = 10;
            // 
            // AdminRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 330);
            this.Controls.Add(this.test);
            this.Controls.Add(this.ProductIDErrorLabel);
            this.Controls.Add(this.FactoryIDErrorLabel);
            this.Controls.Add(this.SerialNumberCreatedLabel);
            this.Controls.Add(this.ProductIDLabel);
            this.Controls.Add(this.FactoryIDLabel);
            this.Controls.Add(this.ProductIDComboBox);
            this.Controls.Add(this.FactoryIDComboBox);
            this.Controls.Add(this.PrintLabelBtn);
            this.Controls.Add(this.CreateSerialNumberButton);
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
        private System.Windows.Forms.Button CreateSerialNumberButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Button PrintLabelBtn;
        private System.Windows.Forms.ComboBox FactoryIDComboBox;
        private System.Windows.Forms.ComboBox ProductIDComboBox;
        private System.Windows.Forms.Label FactoryIDLabel;
        private System.Windows.Forms.Label ProductIDLabel;
        private System.Windows.Forms.Label SerialNumberCreatedLabel;
        private System.Windows.Forms.Label FactoryIDErrorLabel;
        private System.Windows.Forms.Label ProductIDErrorLabel;
        private System.Windows.Forms.TextBox test;
    }
}