namespace HyperV_Shutdown
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.hyperVListBox = new System.Windows.Forms.ListBox();
            this.vmColumnLabel = new System.Windows.Forms.Label();
            this.vmStateLabel = new System.Windows.Forms.Label();
            this.saveVMOrderButton = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.reorderUpButton = new System.Windows.Forms.Button();
            this.reorderDownButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.restartTimeLabel = new System.Windows.Forms.Label();
            this.restartTimeTexbox = new System.Windows.Forms.TextBox();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.getStateButton = new System.Windows.Forms.Button();
            this.clearConsoleBoxButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.saveVMOrderButton)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // hyperVListBox
            // 
            this.hyperVListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperVListBox.FormattingEnabled = true;
            this.hyperVListBox.ItemHeight = 18;
            this.hyperVListBox.Location = new System.Drawing.Point(10, 93);
            this.hyperVListBox.Name = "hyperVListBox";
            this.hyperVListBox.Size = new System.Drawing.Size(298, 202);
            this.hyperVListBox.TabIndex = 0;
            // 
            // vmColumnLabel
            // 
            this.vmColumnLabel.AutoSize = true;
            this.vmColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vmColumnLabel.Location = new System.Drawing.Point(12, 73);
            this.vmColumnLabel.Name = "vmColumnLabel";
            this.vmColumnLabel.Size = new System.Drawing.Size(33, 20);
            this.vmColumnLabel.TabIndex = 1;
            this.vmColumnLabel.Text = "VM";
            // 
            // vmStateLabel
            // 
            this.vmStateLabel.AutoSize = true;
            this.vmStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vmStateLabel.Location = new System.Drawing.Point(193, 73);
            this.vmStateLabel.Name = "vmStateLabel";
            this.vmStateLabel.Size = new System.Drawing.Size(48, 20);
            this.vmStateLabel.TabIndex = 2;
            this.vmStateLabel.Text = "State";
            // 
            // saveVMOrderButton
            // 
            this.saveVMOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveVMOrderButton.Image = ((System.Drawing.Image)(resources.GetObject("saveVMOrderButton.Image")));
            this.saveVMOrderButton.Location = new System.Drawing.Point(12, 35);
            this.saveVMOrderButton.Name = "saveVMOrderButton";
            this.saveVMOrderButton.Size = new System.Drawing.Size(35, 32);
            this.saveVMOrderButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saveVMOrderButton.TabIndex = 3;
            this.saveVMOrderButton.TabStop = false;
            this.saveVMOrderButton.Click += new System.EventHandler(this.saveVMOrderButton_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1144, 24);
            this.mainMenuStrip.TabIndex = 4;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 338);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 5;
            // 
            // reorderUpButton
            // 
            this.reorderUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderUpButton.Location = new System.Drawing.Point(314, 145);
            this.reorderUpButton.Name = "reorderUpButton";
            this.reorderUpButton.Size = new System.Drawing.Size(30, 50);
            this.reorderUpButton.TabIndex = 6;
            this.reorderUpButton.Text = "^";
            this.reorderUpButton.UseVisualStyleBackColor = true;
            this.reorderUpButton.Click += new System.EventHandler(this.reorderUpButton_Click);
            // 
            // reorderDownButton
            // 
            this.reorderDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderDownButton.Location = new System.Drawing.Point(314, 215);
            this.reorderDownButton.Name = "reorderDownButton";
            this.reorderDownButton.Size = new System.Drawing.Size(30, 50);
            this.reorderDownButton.TabIndex = 7;
            this.reorderDownButton.Text = "^";
            this.reorderDownButton.UseVisualStyleBackColor = true;
            this.reorderDownButton.Click += new System.EventHandler(this.reorderDownButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(125, 344);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(102, 24);
            this.restartButton.TabIndex = 8;
            this.restartButton.Text = "Restart VMs";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // restartTimeLabel
            // 
            this.restartTimeLabel.AutoSize = true;
            this.restartTimeLabel.Location = new System.Drawing.Point(60, 311);
            this.restartTimeLabel.Name = "restartTimeLabel";
            this.restartTimeLabel.Size = new System.Drawing.Size(185, 13);
            this.restartTimeLabel.TabIndex = 9;
            this.restartTimeLabel.Text = "Time between each restart (seconds):";
            // 
            // restartTimeTexbox
            // 
            this.restartTimeTexbox.Location = new System.Drawing.Point(244, 308);
            this.restartTimeTexbox.Name = "restartTimeTexbox";
            this.restartTimeTexbox.Size = new System.Drawing.Size(50, 20);
            this.restartTimeTexbox.TabIndex = 10;
            this.restartTimeTexbox.Text = "10";
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(400, 47);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(469, 247);
            this.consoleBox.TabIndex = 11;
            // 
            // getStateButton
            // 
            this.getStateButton.Location = new System.Drawing.Point(400, 311);
            this.getStateButton.Name = "getStateButton";
            this.getStateButton.Size = new System.Drawing.Size(75, 23);
            this.getStateButton.TabIndex = 12;
            this.getStateButton.Text = "Get State";
            this.getStateButton.UseVisualStyleBackColor = true;
            this.getStateButton.Click += new System.EventHandler(this.getStateButton_Click);
            // 
            // clearConsoleBoxButton
            // 
            this.clearConsoleBoxButton.Location = new System.Drawing.Point(502, 311);
            this.clearConsoleBoxButton.Name = "clearConsoleBoxButton";
            this.clearConsoleBoxButton.Size = new System.Drawing.Size(75, 23);
            this.clearConsoleBoxButton.TabIndex = 13;
            this.clearConsoleBoxButton.Text = "Clear";
            this.clearConsoleBoxButton.UseVisualStyleBackColor = true;
            this.clearConsoleBoxButton.Click += new System.EventHandler(this.clearConsoleBoxButton_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 392);
            this.Controls.Add(this.clearConsoleBoxButton);
            this.Controls.Add(this.getStateButton);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.restartTimeTexbox);
            this.Controls.Add(this.restartTimeLabel);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.reorderDownButton);
            this.Controls.Add(this.reorderUpButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.saveVMOrderButton);
            this.Controls.Add(this.vmStateLabel);
            this.Controls.Add(this.vmColumnLabel);
            this.Controls.Add(this.hyperVListBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "HyperV-Shutdown";
            ((System.ComponentModel.ISupportInitialize)(this.saveVMOrderButton)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox hyperVListBox;
        private System.Windows.Forms.Label vmColumnLabel;
        private System.Windows.Forms.Label vmStateLabel;
        private System.Windows.Forms.PictureBox saveVMOrderButton;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button reorderUpButton;
        private System.Windows.Forms.Button reorderDownButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label restartTimeLabel;
        private System.Windows.Forms.TextBox restartTimeTexbox;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.Button getStateButton;
        private System.Windows.Forms.Button clearConsoleBoxButton;
    }
}

