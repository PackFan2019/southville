namespace StudentAssessment
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAssess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inquiryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.assessmentsByStudentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrolledSubjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsPerSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statementOfAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.inquiryMenu,
            this.reportsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(829, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAssess,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(86, 20);
            this.fileMenu.Text = "&Transactions";
            // 
            // btnAssess
            // 
            this.btnAssess.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAssess.Name = "btnAssess";
            this.btnAssess.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.A)));
            this.btnAssess.Size = new System.Drawing.Size(240, 22);
            this.btnAssess.Text = "&Assess/Add/Drop";
            this.btnAssess.Click += new System.EventHandler(this.btnAssess_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // inquiryMenu
            // 
            this.inquiryMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assessmentsByStudentToolStripMenuItem1});
            this.inquiryMenu.Name = "inquiryMenu";
            this.inquiryMenu.Size = new System.Drawing.Size(56, 20);
            this.inquiryMenu.Text = "&Inquiry";
            // 
            // assessmentsByStudentToolStripMenuItem1
            // 
            this.assessmentsByStudentToolStripMenuItem1.Name = "assessmentsByStudentToolStripMenuItem1";
            this.assessmentsByStudentToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.T)));
            this.assessmentsByStudentToolStripMenuItem1.Size = new System.Drawing.Size(274, 22);
            this.assessmentsByStudentToolStripMenuItem1.Text = "&Transactions by Student";
            this.assessmentsByStudentToolStripMenuItem1.Click += new System.EventHandler(this.assessmentsByStudentToolStripMenuItem1_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enrolledSubjectsToolStripMenuItem,
            this.studentsPerSubjectToolStripMenuItem,
            this.statementOfAccountToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // enrolledSubjectsToolStripMenuItem
            // 
            this.enrolledSubjectsToolStripMenuItem.Name = "enrolledSubjectsToolStripMenuItem";
            this.enrolledSubjectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.E)));
            this.enrolledSubjectsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.enrolledSubjectsToolStripMenuItem.Text = "Enrolled Subjects";
            this.enrolledSubjectsToolStripMenuItem.Click += new System.EventHandler(this.enrolledSubjectsToolStripMenuItem_Click);
            // 
            // studentsPerSubjectToolStripMenuItem
            // 
            this.studentsPerSubjectToolStripMenuItem.Name = "studentsPerSubjectToolStripMenuItem";
            this.studentsPerSubjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.studentsPerSubjectToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.studentsPerSubjectToolStripMenuItem.Text = "Students per Subject";
            this.studentsPerSubjectToolStripMenuItem.Click += new System.EventHandler(this.studentsPerSubjectToolStripMenuItem_Click);
            // 
            // statementOfAccountToolStripMenuItem
            // 
            this.statementOfAccountToolStripMenuItem.Name = "statementOfAccountToolStripMenuItem";
            this.statementOfAccountToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.statementOfAccountToolStripMenuItem.Text = "Statement Of &Account";
            this.statementOfAccountToolStripMenuItem.Click += new System.EventHandler(this.statementOfAccountToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 587);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Education Assessment";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem btnAssess;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inquiryMenu;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStripMenuItem assessmentsByStudentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enrolledSubjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsPerSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statementOfAccountToolStripMenuItem;
    }
}



