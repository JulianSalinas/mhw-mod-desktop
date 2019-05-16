namespace mhw_mod_desktop
{
    partial class Window
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.findInComboBox = new System.Windows.Forms.ComboBox();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.newArmorIdTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.armorTextBox = new System.Windows.Forms.TextBox();
            this.currentFileTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.assignButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.zipFilesListBox = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.searchTextBox, 2);
            this.searchTextBox.Location = new System.Drawing.Point(114, 10);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(960, 20);
            this.searchTextBox.TabIndex = 5;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // findInComboBox
            // 
            this.findInComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.findInComboBox, 2);
            this.findInComboBox.DisplayMember = "Documents";
            this.findInComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.findInComboBox.FormattingEnabled = true;
            this.findInComboBox.Items.AddRange(new object[] {
            "Personal",
            "Desktop",
            "Documents"});
            this.findInComboBox.Location = new System.Drawing.Point(114, 49);
            this.findInComboBox.Name = "findInComboBox";
            this.findInComboBox.Size = new System.Drawing.Size(960, 21);
            this.findInComboBox.TabIndex = 7;
            this.findInComboBox.ValueMember = "Documents";
            this.findInComboBox.SelectedIndexChanged += new System.EventHandler(this.FindInComboBox_SelectedIndexChanged);
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.folderTextBox, 2);
            this.folderTextBox.Location = new System.Drawing.Point(114, 90);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.ReadOnly = true;
            this.folderTextBox.Size = new System.Drawing.Size(960, 20);
            this.folderTextBox.TabIndex = 10;
            // 
            // newArmorIdTextBox
            // 
            this.newArmorIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.newArmorIdTextBox, 2);
            this.newArmorIdTextBox.Location = new System.Drawing.Point(114, 210);
            this.newArmorIdTextBox.Name = "newArmorIdTextBox";
            this.newArmorIdTextBox.Size = new System.Drawing.Size(960, 20);
            this.newArmorIdTextBox.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 507F));
            this.tableLayoutPanel1.Controls.Add(this.armorTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.currentFileTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.findInComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.searchTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.folderTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.searchButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.newArmorIdTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.assignButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.filesListBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.zipFilesListBox, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 706);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // armorTextBox
            // 
            this.armorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.armorTextBox, 2);
            this.armorTextBox.Location = new System.Drawing.Point(114, 170);
            this.armorTextBox.Name = "armorTextBox";
            this.armorTextBox.ReadOnly = true;
            this.armorTextBox.Size = new System.Drawing.Size(960, 20);
            this.armorTextBox.TabIndex = 19;
            // 
            // currentFileTextBox
            // 
            this.currentFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.currentFileTextBox, 2);
            this.currentFileTextBox.Location = new System.Drawing.Point(114, 130);
            this.currentFileTextBox.Name = "currentFileTextBox";
            this.currentFileTextBox.ReadOnly = true;
            this.currentFileTextBox.Size = new System.Drawing.Size(960, 20);
            this.currentFileTextBox.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 34);
            this.button1.TabIndex = 17;
            this.button1.Text = "Current";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(3, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 34);
            this.button4.TabIndex = 16;
            this.button4.Text = "Folder";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 34);
            this.button3.TabIndex = 15;
            this.button3.Text = "Find In";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(3, 8);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(105, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // assignButton
            // 
            this.assignButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.assignButton.Location = new System.Drawing.Point(3, 208);
            this.assignButton.Name = "assignButton";
            this.assignButton.Size = new System.Drawing.Size(105, 23);
            this.assignButton.TabIndex = 14;
            this.assignButton.Text = "Assign To";
            this.assignButton.UseVisualStyleBackColor = true;
            this.assignButton.Click += new System.EventHandler(this.AssignButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Armor";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // filesListBox
            // 
            this.filesListBox.ColumnWidth = 4;
            this.filesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.Location = new System.Drawing.Point(114, 243);
            this.filesListBox.Name = "filesListBox";
            this.tableLayoutPanel1.SetRowSpan(this.filesListBox, 2);
            this.filesListBox.Size = new System.Drawing.Size(331, 451);
            this.filesListBox.TabIndex = 1;
            this.filesListBox.SelectedIndexChanged += new System.EventHandler(this.FilesListBox_SelectedIndexChanged);
            this.filesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilesListBox_MouseDoubleClick);
            // 
            // zipFilesListBox
            // 
            this.zipFilesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zipFilesListBox.FormattingEnabled = true;
            this.zipFilesListBox.Location = new System.Drawing.Point(451, 243);
            this.zipFilesListBox.Name = "zipFilesListBox";
            this.tableLayoutPanel1.SetRowSpan(this.zipFilesListBox, 2);
            this.zipFilesListBox.Size = new System.Drawing.Size(623, 451);
            this.zipFilesListBox.TabIndex = 20;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 727);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1095, 22);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(57, 17);
            this.statusLabel.Text = "Welcome";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1095, 749);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Window";
            this.Text = "MHWMod Desktop";
            this.Load += new System.EventHandler(this.Window_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ComboBox findInComboBox;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.TextBox newArmorIdTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TextBox currentFileTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox armorTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox zipFilesListBox;
    }
}

