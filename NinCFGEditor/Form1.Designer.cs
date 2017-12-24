namespace NinCFGEditor {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion1 = new System.Windows.Forms.Label();
            this.lblVersion2 = new System.Windows.Forms.Label();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblVideoMode = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lblGamePath = new System.Windows.Forms.Label();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.btnGamePathBrowse = new System.Windows.Forms.Button();
            this.btnCheatPathBrowse = new System.Windows.Forms.Button();
            this.txtCheatPath = new System.Windows.Forms.TextBox();
            this.lblCheatPath = new System.Windows.Forms.Label();
            this.lblMaxPads = new System.Windows.Forms.Label();
            this.numMaxPads = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblGameID = new System.Windows.Forms.Label();
            this.lblMemCardBlocks = new System.Windows.Forms.Label();
            this.ddlMemCardBlocks = new System.Windows.Forms.ComboBox();
            this.lblVideoScale = new System.Windows.Forms.Label();
            this.numVideoScale = new System.Windows.Forms.NumericUpDown();
            this.chkVideoWidthAuto = new System.Windows.Forms.CheckBox();
            this.numVideoOffset = new System.Windows.Forms.NumericUpDown();
            this.lblVideoOffset = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // lblVersion1
            // 
            this.lblVersion1.AutoSize = true;
            this.lblVersion1.Location = new System.Drawing.Point(12, 28);
            this.lblVersion1.Name = "lblVersion1";
            this.lblVersion1.Size = new System.Drawing.Size(42, 13);
            this.lblVersion1.TabIndex = 1;
            this.lblVersion1.Text = "Version";
            // 
            // lblVersion2
            // 
            this.lblVersion2.AutoSize = true;
            this.lblVersion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion2.Location = new System.Drawing.Point(60, 28);
            this.lblVersion2.Name = "lblVersion2";
            this.lblVersion2.Size = new System.Drawing.Size(14, 13);
            this.lblVersion2.TabIndex = 2;
            this.lblVersion2.Text = "0";
            // 
            // grpConfig
            // 
            this.grpConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfig.Location = new System.Drawing.Point(12, 48);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(360, 103);
            this.grpConfig.TabIndex = 3;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Configuration Options";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(82, 157);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(188, 157);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(80, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // lblVideoMode
            // 
            this.lblVideoMode.AutoSize = true;
            this.lblVideoMode.Location = new System.Drawing.Point(12, 160);
            this.lblVideoMode.Name = "lblVideoMode";
            this.lblVideoMode.Size = new System.Drawing.Size(64, 13);
            this.lblVideoMode.TabIndex = 5;
            this.lblVideoMode.Text = "Video Mode";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(12, 187);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 6;
            this.lblLanguage.Text = "Language";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(82, 184);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 21);
            this.comboBox3.TabIndex = 7;
            // 
            // lblGamePath
            // 
            this.lblGamePath.AutoSize = true;
            this.lblGamePath.Location = new System.Drawing.Point(12, 214);
            this.lblGamePath.Name = "lblGamePath";
            this.lblGamePath.Size = new System.Drawing.Size(60, 13);
            this.lblGamePath.TabIndex = 8;
            this.lblGamePath.Text = "Game Path";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGamePath.Location = new System.Drawing.Point(82, 211);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(260, 20);
            this.txtGamePath.TabIndex = 9;
            // 
            // btnGamePathBrowse
            // 
            this.btnGamePathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGamePathBrowse.Location = new System.Drawing.Point(348, 211);
            this.btnGamePathBrowse.Name = "btnGamePathBrowse";
            this.btnGamePathBrowse.Size = new System.Drawing.Size(24, 20);
            this.btnGamePathBrowse.TabIndex = 10;
            this.btnGamePathBrowse.Text = "...";
            this.btnGamePathBrowse.UseVisualStyleBackColor = true;
            // 
            // btnCheatPathBrowse
            // 
            this.btnCheatPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheatPathBrowse.Location = new System.Drawing.Point(348, 237);
            this.btnCheatPathBrowse.Name = "btnCheatPathBrowse";
            this.btnCheatPathBrowse.Size = new System.Drawing.Size(24, 20);
            this.btnCheatPathBrowse.TabIndex = 13;
            this.btnCheatPathBrowse.Text = "...";
            this.btnCheatPathBrowse.UseVisualStyleBackColor = true;
            // 
            // txtCheatPath
            // 
            this.txtCheatPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheatPath.Location = new System.Drawing.Point(82, 237);
            this.txtCheatPath.Name = "txtCheatPath";
            this.txtCheatPath.Size = new System.Drawing.Size(260, 20);
            this.txtCheatPath.TabIndex = 12;
            // 
            // lblCheatPath
            // 
            this.lblCheatPath.AutoSize = true;
            this.lblCheatPath.Location = new System.Drawing.Point(12, 240);
            this.lblCheatPath.Name = "lblCheatPath";
            this.lblCheatPath.Size = new System.Drawing.Size(60, 13);
            this.lblCheatPath.TabIndex = 11;
            this.lblCheatPath.Text = "Cheat Path";
            // 
            // lblMaxPads
            // 
            this.lblMaxPads.AutoSize = true;
            this.lblMaxPads.Location = new System.Drawing.Point(12, 265);
            this.lblMaxPads.Name = "lblMaxPads";
            this.lblMaxPads.Size = new System.Drawing.Size(233, 13);
            this.lblMaxPads.TabIndex = 14;
            this.lblMaxPads.Text = "Maximum native controller ports to use (Wii only)";
            // 
            // numMaxPads
            // 
            this.numMaxPads.Location = new System.Drawing.Point(322, 263);
            this.numMaxPads.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numMaxPads.Name = "numMaxPads";
            this.numMaxPads.Size = new System.Drawing.Size(50, 20);
            this.numMaxPads.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 289);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 17;
            // 
            // lblGameID
            // 
            this.lblGameID.AutoSize = true;
            this.lblGameID.Location = new System.Drawing.Point(12, 292);
            this.lblGameID.Name = "lblGameID";
            this.lblGameID.Size = new System.Drawing.Size(49, 13);
            this.lblGameID.TabIndex = 16;
            this.lblGameID.Text = "Game ID";
            // 
            // lblMemCardBlocks
            // 
            this.lblMemCardBlocks.AutoSize = true;
            this.lblMemCardBlocks.Location = new System.Drawing.Point(12, 318);
            this.lblMemCardBlocks.Name = "lblMemCardBlocks";
            this.lblMemCardBlocks.Size = new System.Drawing.Size(102, 13);
            this.lblMemCardBlocks.TabIndex = 18;
            this.lblMemCardBlocks.Text = "Memory card blocks";
            // 
            // ddlMemCardBlocks
            // 
            this.ddlMemCardBlocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMemCardBlocks.FormattingEnabled = true;
            this.ddlMemCardBlocks.Location = new System.Drawing.Point(120, 315);
            this.ddlMemCardBlocks.Name = "ddlMemCardBlocks";
            this.ddlMemCardBlocks.Size = new System.Drawing.Size(62, 21);
            this.ddlMemCardBlocks.TabIndex = 19;
            // 
            // lblVideoScale
            // 
            this.lblVideoScale.AutoSize = true;
            this.lblVideoScale.Location = new System.Drawing.Point(12, 344);
            this.lblVideoScale.Name = "lblVideoScale";
            this.lblVideoScale.Size = new System.Drawing.Size(62, 13);
            this.lblVideoScale.TabIndex = 20;
            this.lblVideoScale.Text = "Video width";
            // 
            // numVideoScale
            // 
            this.numVideoScale.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numVideoScale.Location = new System.Drawing.Point(120, 342);
            this.numVideoScale.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numVideoScale.Minimum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.numVideoScale.Name = "numVideoScale";
            this.numVideoScale.Size = new System.Drawing.Size(62, 20);
            this.numVideoScale.TabIndex = 21;
            this.numVideoScale.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // chkVideoWidthAuto
            // 
            this.chkVideoWidthAuto.AutoSize = true;
            this.chkVideoWidthAuto.Location = new System.Drawing.Point(188, 343);
            this.chkVideoWidthAuto.Name = "chkVideoWidthAuto";
            this.chkVideoWidthAuto.Size = new System.Drawing.Size(48, 17);
            this.chkVideoWidthAuto.TabIndex = 22;
            this.chkVideoWidthAuto.Text = "Auto";
            this.chkVideoWidthAuto.UseVisualStyleBackColor = true;
            // 
            // numVideoOffset
            // 
            this.numVideoOffset.Location = new System.Drawing.Point(120, 368);
            this.numVideoOffset.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numVideoOffset.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numVideoOffset.Name = "numVideoOffset";
            this.numVideoOffset.Size = new System.Drawing.Size(62, 20);
            this.numVideoOffset.TabIndex = 24;
            this.numVideoOffset.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblVideoOffset
            // 
            this.lblVideoOffset.AutoSize = true;
            this.lblVideoOffset.Location = new System.Drawing.Point(12, 370);
            this.lblVideoOffset.Name = "lblVideoOffset";
            this.lblVideoOffset.Size = new System.Drawing.Size(80, 13);
            this.lblVideoOffset.TabIndex = 23;
            this.lblVideoOffset.Text = "Screen position";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 431);
            this.Controls.Add(this.numVideoOffset);
            this.Controls.Add(this.lblVideoOffset);
            this.Controls.Add(this.chkVideoWidthAuto);
            this.Controls.Add(this.numVideoScale);
            this.Controls.Add(this.lblVideoScale);
            this.Controls.Add(this.ddlMemCardBlocks);
            this.Controls.Add(this.lblMemCardBlocks);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblGameID);
            this.Controls.Add(this.numMaxPads);
            this.Controls.Add(this.lblMaxPads);
            this.Controls.Add(this.btnCheatPathBrowse);
            this.Controls.Add(this.txtCheatPath);
            this.Controls.Add(this.lblCheatPath);
            this.Controls.Add(this.btnGamePathBrowse);
            this.Controls.Add(this.txtGamePath);
            this.Controls.Add(this.lblGamePath);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lblVideoMode);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.grpConfig);
            this.Controls.Add(this.lblVersion2);
            this.Controls.Add(this.lblVersion1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "nincfg.bin editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblVersion1;
        private System.Windows.Forms.Label lblVersion2;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblVideoMode;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label lblGamePath;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Button btnGamePathBrowse;
        private System.Windows.Forms.Button btnCheatPathBrowse;
        private System.Windows.Forms.TextBox txtCheatPath;
        private System.Windows.Forms.Label lblCheatPath;
        private System.Windows.Forms.Label lblMaxPads;
        private System.Windows.Forms.NumericUpDown numMaxPads;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblGameID;
        private System.Windows.Forms.Label lblMemCardBlocks;
        private System.Windows.Forms.ComboBox ddlMemCardBlocks;
        private System.Windows.Forms.Label lblVideoScale;
        private System.Windows.Forms.NumericUpDown numVideoScale;
        private System.Windows.Forms.CheckBox chkVideoWidthAuto;
        private System.Windows.Forms.NumericUpDown numVideoOffset;
        private System.Windows.Forms.Label lblVideoOffset;
    }
}

