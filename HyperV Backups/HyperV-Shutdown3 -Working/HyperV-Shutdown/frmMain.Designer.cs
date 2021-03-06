﻿namespace HyperV_Shutdown
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
            this.hyperVListBox = new System.Windows.Forms.ListBox();
            this.vmColumnLabel = new System.Windows.Forms.Label();
            this.vmStateLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reorderUpButton = new System.Windows.Forms.Button();
            this.reorderDownButton = new System.Windows.Forms.Button();
            this.setTaskButton = new System.Windows.Forms.Button();
            this.restartTimeLabel = new System.Windows.Forms.Label();
            this.restartTimeTexbox = new System.Windows.Forms.TextBox();
            this.vmOptionDropDown = new System.Windows.Forms.ComboBox();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // hyperVListBox
            // 
            this.hyperVListBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperVListBox.FormattingEnabled = true;
            this.hyperVListBox.ItemHeight = 20;
            this.hyperVListBox.Location = new System.Drawing.Point(5, 52);
            this.hyperVListBox.Name = "hyperVListBox";
            this.hyperVListBox.Size = new System.Drawing.Size(289, 184);
            this.hyperVListBox.TabIndex = 0;
            // 
            // vmColumnLabel
            // 
            this.vmColumnLabel.AutoSize = true;
            this.vmColumnLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vmColumnLabel.Location = new System.Drawing.Point(7, 28);
            this.vmColumnLabel.Name = "vmColumnLabel";
            this.vmColumnLabel.Size = new System.Drawing.Size(34, 21);
            this.vmColumnLabel.TabIndex = 1;
            this.vmColumnLabel.Text = "VM";
            // 
            // vmStateLabel
            // 
            this.vmStateLabel.AutoSize = true;
            this.vmStateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vmStateLabel.Location = new System.Drawing.Point(153, 28);
            this.vmStateLabel.Name = "vmStateLabel";
            this.vmStateLabel.Size = new System.Drawing.Size(44, 21);
            this.vmStateLabel.TabIndex = 2;
            this.vmStateLabel.Text = "State";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(333, 24);
            this.mainMenuStrip.TabIndex = 4;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reorderUpButton
            // 
            this.reorderUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderUpButton.Location = new System.Drawing.Point(297, 83);
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
            this.reorderDownButton.Location = new System.Drawing.Point(297, 153);
            this.reorderDownButton.Name = "reorderDownButton";
            this.reorderDownButton.Size = new System.Drawing.Size(30, 50);
            this.reorderDownButton.TabIndex = 7;
            this.reorderDownButton.Text = "^";
            this.reorderDownButton.UseVisualStyleBackColor = true;
            this.reorderDownButton.Click += new System.EventHandler(this.reorderDownButton_Click);
            // 
            // setTaskButton
            // 
            this.setTaskButton.Location = new System.Drawing.Point(115, 303);
            this.setTaskButton.Name = "setTaskButton";
            this.setTaskButton.Size = new System.Drawing.Size(102, 24);
            this.setTaskButton.TabIndex = 8;
            this.setTaskButton.Text = "Start Tasks";
            this.setTaskButton.UseVisualStyleBackColor = true;
            this.setTaskButton.Click += new System.EventHandler(this.setTaskButton_Click);
            // 
            // restartTimeLabel
            // 
            this.restartTimeLabel.AutoSize = true;
            this.restartTimeLabel.Location = new System.Drawing.Point(42, 245);
            this.restartTimeLabel.Name = "restartTimeLabel";
            this.restartTimeLabel.Size = new System.Drawing.Size(195, 13);
            this.restartTimeLabel.TabIndex = 9;
            this.restartTimeLabel.Text = "Time between each restart (seconds):";
            // 
            // restartTimeTexbox
            // 
            this.restartTimeTexbox.Location = new System.Drawing.Point(241, 242);
            this.restartTimeTexbox.Name = "restartTimeTexbox";
            this.restartTimeTexbox.Size = new System.Drawing.Size(50, 22);
            this.restartTimeTexbox.TabIndex = 10;
            this.restartTimeTexbox.Text = "10";
            // 
            // vmOptionDropDown
            // 
            this.vmOptionDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vmOptionDropDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vmOptionDropDown.FormattingEnabled = true;
            this.vmOptionDropDown.Location = new System.Drawing.Point(86, 270);
            this.vmOptionDropDown.Name = "vmOptionDropDown";
            this.vmOptionDropDown.Size = new System.Drawing.Size(160, 25);
            this.vmOptionDropDown.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(333, 331);
            this.Controls.Add(this.vmOptionDropDown);
            this.Controls.Add(this.restartTimeTexbox);
            this.Controls.Add(this.restartTimeLabel);
            this.Controls.Add(this.setTaskButton);
            this.Controls.Add(this.reorderDownButton);
            this.Controls.Add(this.reorderUpButton);
            this.Controls.Add(this.vmStateLabel);
            this.Controls.Add(this.vmColumnLabel);
            this.Controls.Add(this.hyperVListBox);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "HyperV-Shutdown";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox hyperVListBox;
        private System.Windows.Forms.Label vmColumnLabel;
        private System.Windows.Forms.Label vmStateLabel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.Button reorderUpButton;
        private System.Windows.Forms.Button reorderDownButton;
        private System.Windows.Forms.Button setTaskButton;
        private System.Windows.Forms.Label restartTimeLabel;
        private System.Windows.Forms.TextBox restartTimeTexbox;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox vmOptionDropDown;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

