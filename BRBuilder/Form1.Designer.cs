namespace BRBuilder
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataForCurrentConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTabels = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerateClaesses = new System.Windows.Forms.Button();
            this.tbcClasses = new System.Windows.Forms.TabControl();
            this.tbpBE = new System.Windows.Forms.TabPage();
            this.txtBE = new System.Windows.Forms.TextBox();
            this.tbpIRepository = new System.Windows.Forms.TabPage();
            this.txtIRepository = new System.Windows.Forms.TextBox();
            this.tbpRepository = new System.Windows.Forms.TabPage();
            this.txtRepository = new System.Windows.Forms.TextBox();
            this.tbpBL = new System.Windows.Forms.TabPage();
            this.txtBL = new System.Windows.Forms.TextBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSaveClasses = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbcClasses.SuspendLayout();
            this.tbpBE.SuspendLayout();
            this.tbpIRepository.SuspendLayout();
            this.tbpRepository.SuspendLayout();
            this.tbpBL.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNewConnectionToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // openNewConnectionToolStripMenuItem
            // 
            this.openNewConnectionToolStripMenuItem.Name = "openNewConnectionToolStripMenuItem";
            this.openNewConnectionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openNewConnectionToolStripMenuItem.Text = "Open new connection";
            this.openNewConnectionToolStripMenuItem.Click += new System.EventHandler(this.openNewConnectionToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataForCurrentConnectionToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // loadDataForCurrentConnectionToolStripMenuItem
            // 
            this.loadDataForCurrentConnectionToolStripMenuItem.Name = "loadDataForCurrentConnectionToolStripMenuItem";
            this.loadDataForCurrentConnectionToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.loadDataForCurrentConnectionToolStripMenuItem.Text = "Load data for current connection";
            this.loadDataForCurrentConnectionToolStripMenuItem.Click += new System.EventHandler(this.loadDataForCurrentConnectionToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTabels);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 596);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data tables";
            // 
            // lstTabels
            // 
            this.lstTabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTabels.FormattingEnabled = true;
            this.lstTabels.Location = new System.Drawing.Point(3, 16);
            this.lstTabels.Name = "lstTabels";
            this.lstTabels.Size = new System.Drawing.Size(257, 577);
            this.lstTabels.TabIndex = 0;
            this.lstTabels.SelectedIndexChanged += new System.EventHandler(this.lstTabels_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveClasses);
            this.groupBox2.Controls.Add(this.btnSelectAll);
            this.groupBox2.Controls.Add(this.btnGenerateClaesses);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 620);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(929, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnGenerateClaesses
            // 
            this.btnGenerateClaesses.Location = new System.Drawing.Point(12, 11);
            this.btnGenerateClaesses.Name = "btnGenerateClaesses";
            this.btnGenerateClaesses.Size = new System.Drawing.Size(111, 23);
            this.btnGenerateClaesses.TabIndex = 0;
            this.btnGenerateClaesses.Text = "Generate classes";
            this.btnGenerateClaesses.UseVisualStyleBackColor = true;
            this.btnGenerateClaesses.Click += new System.EventHandler(this.btnGenerateClasses_Click);
            // 
            // tbcClasses
            // 
            this.tbcClasses.Controls.Add(this.tbpBE);
            this.tbcClasses.Controls.Add(this.tbpIRepository);
            this.tbcClasses.Controls.Add(this.tbpRepository);
            this.tbcClasses.Controls.Add(this.tbpBL);
            this.tbcClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcClasses.Location = new System.Drawing.Point(263, 24);
            this.tbcClasses.Name = "tbcClasses";
            this.tbcClasses.SelectedIndex = 0;
            this.tbcClasses.Size = new System.Drawing.Size(666, 596);
            this.tbcClasses.TabIndex = 3;
            // 
            // tbpBE
            // 
            this.tbpBE.Controls.Add(this.txtBE);
            this.tbpBE.Location = new System.Drawing.Point(4, 22);
            this.tbpBE.Name = "tbpBE";
            this.tbpBE.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBE.Size = new System.Drawing.Size(658, 570);
            this.tbpBE.TabIndex = 0;
            this.tbpBE.Text = "BE";
            this.tbpBE.UseVisualStyleBackColor = true;
            // 
            // txtBE
            // 
            this.txtBE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBE.Location = new System.Drawing.Point(3, 3);
            this.txtBE.Multiline = true;
            this.txtBE.Name = "txtBE";
            this.txtBE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBE.Size = new System.Drawing.Size(652, 564);
            this.txtBE.TabIndex = 0;
            // 
            // tbpIRepository
            // 
            this.tbpIRepository.Controls.Add(this.txtIRepository);
            this.tbpIRepository.Location = new System.Drawing.Point(4, 22);
            this.tbpIRepository.Name = "tbpIRepository";
            this.tbpIRepository.Padding = new System.Windows.Forms.Padding(3);
            this.tbpIRepository.Size = new System.Drawing.Size(658, 570);
            this.tbpIRepository.TabIndex = 1;
            this.tbpIRepository.Text = "IRepository";
            this.tbpIRepository.UseVisualStyleBackColor = true;
            // 
            // txtIRepository
            // 
            this.txtIRepository.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIRepository.Location = new System.Drawing.Point(3, 3);
            this.txtIRepository.Multiline = true;
            this.txtIRepository.Name = "txtIRepository";
            this.txtIRepository.Size = new System.Drawing.Size(652, 564);
            this.txtIRepository.TabIndex = 0;
            // 
            // tbpRepository
            // 
            this.tbpRepository.Controls.Add(this.txtRepository);
            this.tbpRepository.Location = new System.Drawing.Point(4, 22);
            this.tbpRepository.Name = "tbpRepository";
            this.tbpRepository.Size = new System.Drawing.Size(658, 570);
            this.tbpRepository.TabIndex = 2;
            this.tbpRepository.Text = "Repository";
            this.tbpRepository.UseVisualStyleBackColor = true;
            // 
            // txtRepository
            // 
            this.txtRepository.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRepository.Location = new System.Drawing.Point(0, 0);
            this.txtRepository.Multiline = true;
            this.txtRepository.Name = "txtRepository";
            this.txtRepository.Size = new System.Drawing.Size(658, 570);
            this.txtRepository.TabIndex = 0;
            // 
            // tbpBL
            // 
            this.tbpBL.Controls.Add(this.txtBL);
            this.tbpBL.Location = new System.Drawing.Point(4, 22);
            this.tbpBL.Name = "tbpBL";
            this.tbpBL.Size = new System.Drawing.Size(658, 570);
            this.tbpBL.TabIndex = 3;
            this.tbpBL.Text = "BL";
            this.tbpBL.UseVisualStyleBackColor = true;
            // 
            // txtBL
            // 
            this.txtBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBL.Location = new System.Drawing.Point(0, 0);
            this.txtBL.Multiline = true;
            this.txtBL.Name = "txtBL";
            this.txtBL.Size = new System.Drawing.Size(658, 570);
            this.txtBL.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(130, 11);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSaveClasses
            // 
            this.btnSaveClasses.Location = new System.Drawing.Point(842, 11);
            this.btnSaveClasses.Name = "btnSaveClasses";
            this.btnSaveClasses.Size = new System.Drawing.Size(75, 23);
            this.btnSaveClasses.TabIndex = 2;
            this.btnSaveClasses.Text = "Save";
            this.btnSaveClasses.UseVisualStyleBackColor = true;
            this.btnSaveClasses.Click += new System.EventHandler(this.btnSaveClasses_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 666);
            this.Controls.Add(this.tbcClasses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "BrBuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tbcClasses.ResumeLayout(false);
            this.tbpBE.ResumeLayout(false);
            this.tbpBE.PerformLayout();
            this.tbpIRepository.ResumeLayout(false);
            this.tbpIRepository.PerformLayout();
            this.tbpRepository.ResumeLayout(false);
            this.tbpRepository.PerformLayout();
            this.tbpBL.ResumeLayout(false);
            this.tbpBL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNewConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataForCurrentConnectionToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstTabels;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerateClaesses;
        private System.Windows.Forms.TabControl tbcClasses;
        private System.Windows.Forms.TabPage tbpBE;
        private System.Windows.Forms.TabPage tbpIRepository;
        private System.Windows.Forms.TabPage tbpRepository;
        private System.Windows.Forms.TabPage tbpBL;
        private System.Windows.Forms.TextBox txtBE;
        private System.Windows.Forms.TextBox txtIRepository;
        private System.Windows.Forms.TextBox txtRepository;
        private System.Windows.Forms.TextBox txtBL;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSaveClasses;
    }
}

