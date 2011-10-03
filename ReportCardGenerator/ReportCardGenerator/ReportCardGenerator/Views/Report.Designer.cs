namespace ReportCardGenerator.Views
{
    partial class StudReportCard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudReportCard));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentList = new System.Windows.Forms.ListBox();
            this.HonorsBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.honorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depEdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIILCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIIIILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIVILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeSchoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr3ILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr4ILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr5ILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr6ILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gr7ILCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 28);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1353, 707);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(413, 372);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(584, 341);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // StudentList
            // 
            this.StudentList.ColumnWidth = 65;
            this.StudentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentList.FormattingEnabled = true;
            this.StudentList.ItemHeight = 20;
            this.StudentList.Location = new System.Drawing.Point(0, 36);
            this.StudentList.Margin = new System.Windows.Forms.Padding(4);
            this.StudentList.Name = "StudentList";
            this.StudentList.Size = new System.Drawing.Size(191, 624);
            this.StudentList.TabIndex = 3;
            this.StudentList.Visible = false;
            this.StudentList.MouseHover += new System.EventHandler(this.StudentList_MouseHover);
            this.StudentList.SelectedIndexChanged += new System.EventHandler(this.StudentList_SelectedIndexChanged);
            // 
            // HonorsBtn
            // 
            this.HonorsBtn.Location = new System.Drawing.Point(479, 5);
            this.HonorsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.HonorsBtn.Name = "HonorsBtn";
            this.HonorsBtn.Size = new System.Drawing.Size(100, 28);
            this.HonorsBtn.TabIndex = 5;
            this.HonorsBtn.Text = "Honors";
            this.HonorsBtn.UseVisualStyleBackColor = true;
            this.HonorsBtn.Visible = false;
            this.HonorsBtn.Click += new System.EventHandler(this.HonorsBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1353, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.honorsToolStripMenuItem,
            this.depEdToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // honorsToolStripMenuItem
            // 
            this.honorsToolStripMenuItem.Name = "honorsToolStripMenuItem";
            this.honorsToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.honorsToolStripMenuItem.Text = "Honors";
            this.honorsToolStripMenuItem.Click += new System.EventHandler(this.honorsToolStripMenuItem_Click);
            // 
            // depEdToolStripMenuItem
            // 
            this.depEdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hSIVToolStripMenuItem,
            this.gradeSchoolToolStripMenuItem});
            this.depEdToolStripMenuItem.Name = "depEdToolStripMenuItem";
            this.depEdToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.depEdToolStripMenuItem.Text = "DepEd";
            this.depEdToolStripMenuItem.Click += new System.EventHandler(this.depEdToolStripMenuItem_Click);
            // 
            // hSIVToolStripMenuItem
            // 
            this.hSIVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hSIToolStripMenuItem,
            this.hSIILCToolStripMenuItem,
            this.hSIIToolStripMenuItem,
            this.hSIILCToolStripMenuItem1,
            this.hSIIIToolStripMenuItem,
            this.hSIIIILCToolStripMenuItem,
            this.hSIVToolStripMenuItem1,
            this.hSIVILCToolStripMenuItem});
            this.hSIVToolStripMenuItem.Name = "hSIVToolStripMenuItem";
            this.hSIVToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.hSIVToolStripMenuItem.Text = "High School";
            // 
            // hSIToolStripMenuItem
            // 
            this.hSIToolStripMenuItem.Name = "hSIToolStripMenuItem";
            this.hSIToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.hSIToolStripMenuItem.Text = "HS I";
            this.hSIToolStripMenuItem.Click += new System.EventHandler(this.hSIToolStripMenuItem_Click);
            // 
            // hSIILCToolStripMenuItem
            // 
            this.hSIILCToolStripMenuItem.Name = "hSIILCToolStripMenuItem";
            this.hSIILCToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.hSIILCToolStripMenuItem.Text = "HS I-ILC";
            this.hSIILCToolStripMenuItem.Click += new System.EventHandler(this.hSIILCToolStripMenuItem_Click);
            // 
            // hSIIToolStripMenuItem
            // 
            this.hSIIToolStripMenuItem.Name = "hSIIToolStripMenuItem";
            this.hSIIToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.hSIIToolStripMenuItem.Text = "HS II";
            this.hSIIToolStripMenuItem.Click += new System.EventHandler(this.hSIIToolStripMenuItem_Click);
            // 
            // hSIILCToolStripMenuItem1
            // 
            this.hSIILCToolStripMenuItem1.Name = "hSIILCToolStripMenuItem1";
            this.hSIILCToolStripMenuItem1.Size = new System.Drawing.Size(140, 24);
            this.hSIILCToolStripMenuItem1.Text = "HS II-ILC";
            this.hSIILCToolStripMenuItem1.Click += new System.EventHandler(this.hSIILCToolStripMenuItem1_Click);
            // 
            // hSIIIToolStripMenuItem
            // 
            this.hSIIIToolStripMenuItem.Name = "hSIIIToolStripMenuItem";
            this.hSIIIToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.hSIIIToolStripMenuItem.Text = "HS III";
            this.hSIIIToolStripMenuItem.Click += new System.EventHandler(this.hSIIIToolStripMenuItem_Click);
            // 
            // hSIIIILCToolStripMenuItem
            // 
            this.hSIIIILCToolStripMenuItem.Name = "hSIIIILCToolStripMenuItem";
            this.hSIIIILCToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.hSIIIILCToolStripMenuItem.Text = "HS III-ILC";
            this.hSIIIILCToolStripMenuItem.Click += new System.EventHandler(this.hSIIIILCToolStripMenuItem_Click);
            // 
            // hSIVToolStripMenuItem1
            // 
            this.hSIVToolStripMenuItem1.Name = "hSIVToolStripMenuItem1";
            this.hSIVToolStripMenuItem1.Size = new System.Drawing.Size(140, 24);
            this.hSIVToolStripMenuItem1.Text = "HS IV";
            this.hSIVToolStripMenuItem1.Click += new System.EventHandler(this.hSIVToolStripMenuItem1_Click);
            // 
            // hSIVILCToolStripMenuItem
            // 
            this.hSIVILCToolStripMenuItem.Name = "hSIVILCToolStripMenuItem";
            this.hSIVILCToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.hSIVILCToolStripMenuItem.Text = "HS IV-ILC";
            this.hSIVILCToolStripMenuItem.Click += new System.EventHandler(this.hSIVILCToolStripMenuItem_Click);
            // 
            // gradeSchoolToolStripMenuItem
            // 
            this.gradeSchoolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gr1ToolStripMenuItem,
            this.gr2ToolStripMenuItem,
            this.gr3ToolStripMenuItem,
            this.gr3ILCToolStripMenuItem,
            this.gr4ToolStripMenuItem,
            this.gr4ILCToolStripMenuItem,
            this.gr5ToolStripMenuItem,
            this.gr5ILCToolStripMenuItem,
            this.gr6ToolStripMenuItem,
            this.gr6ILCToolStripMenuItem,
            this.gr7ToolStripMenuItem,
            this.gr7ILCToolStripMenuItem});
            this.gradeSchoolToolStripMenuItem.Name = "gradeSchoolToolStripMenuItem";
            this.gradeSchoolToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.gradeSchoolToolStripMenuItem.Text = "Grade School";
            // 
            // gr1ToolStripMenuItem
            // 
            this.gr1ToolStripMenuItem.Name = "gr1ToolStripMenuItem";
            this.gr1ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr1ToolStripMenuItem.Text = "Gr 1";
            this.gr1ToolStripMenuItem.Click += new System.EventHandler(this.gr1ToolStripMenuItem_Click);
            // 
            // gr2ToolStripMenuItem
            // 
            this.gr2ToolStripMenuItem.Name = "gr2ToolStripMenuItem";
            this.gr2ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr2ToolStripMenuItem.Text = "Gr 2";
            this.gr2ToolStripMenuItem.Click += new System.EventHandler(this.gr2ToolStripMenuItem_Click);
            // 
            // gr3ToolStripMenuItem
            // 
            this.gr3ToolStripMenuItem.Name = "gr3ToolStripMenuItem";
            this.gr3ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr3ToolStripMenuItem.Text = "Gr 3";
            this.gr3ToolStripMenuItem.Click += new System.EventHandler(this.gr3ToolStripMenuItem_Click);
            // 
            // gr3ILCToolStripMenuItem
            // 
            this.gr3ILCToolStripMenuItem.Name = "gr3ILCToolStripMenuItem";
            this.gr3ILCToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr3ILCToolStripMenuItem.Text = "Gr 3-ILC";
            this.gr3ILCToolStripMenuItem.Click += new System.EventHandler(this.gr3ILCToolStripMenuItem_Click);
            // 
            // gr4ToolStripMenuItem
            // 
            this.gr4ToolStripMenuItem.Name = "gr4ToolStripMenuItem";
            this.gr4ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr4ToolStripMenuItem.Text = "Gr 4";
            this.gr4ToolStripMenuItem.Click += new System.EventHandler(this.gr4ToolStripMenuItem_Click);
            // 
            // gr4ILCToolStripMenuItem
            // 
            this.gr4ILCToolStripMenuItem.Name = "gr4ILCToolStripMenuItem";
            this.gr4ILCToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr4ILCToolStripMenuItem.Text = "Gr 4-ILC";
            this.gr4ILCToolStripMenuItem.Click += new System.EventHandler(this.gr4ILCToolStripMenuItem_Click);
            // 
            // gr5ToolStripMenuItem
            // 
            this.gr5ToolStripMenuItem.Name = "gr5ToolStripMenuItem";
            this.gr5ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr5ToolStripMenuItem.Text = "Gr 5";
            this.gr5ToolStripMenuItem.Click += new System.EventHandler(this.gr5ToolStripMenuItem_Click);
            // 
            // gr5ILCToolStripMenuItem
            // 
            this.gr5ILCToolStripMenuItem.Name = "gr5ILCToolStripMenuItem";
            this.gr5ILCToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr5ILCToolStripMenuItem.Text = "Gr 5-ILC";
            this.gr5ILCToolStripMenuItem.Click += new System.EventHandler(this.gr5ILCToolStripMenuItem_Click);
            // 
            // gr6ToolStripMenuItem
            // 
            this.gr6ToolStripMenuItem.Name = "gr6ToolStripMenuItem";
            this.gr6ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr6ToolStripMenuItem.Text = "Gr 6";
            this.gr6ToolStripMenuItem.Click += new System.EventHandler(this.gr6ToolStripMenuItem_Click);
            // 
            // gr6ILCToolStripMenuItem
            // 
            this.gr6ILCToolStripMenuItem.Name = "gr6ILCToolStripMenuItem";
            this.gr6ILCToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr6ILCToolStripMenuItem.Text = "Gr 6-ILC";
            this.gr6ILCToolStripMenuItem.Click += new System.EventHandler(this.gr6ILCToolStripMenuItem_Click);
            // 
            // gr7ToolStripMenuItem
            // 
            this.gr7ToolStripMenuItem.Name = "gr7ToolStripMenuItem";
            this.gr7ToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr7ToolStripMenuItem.Text = "Gr 7";
            this.gr7ToolStripMenuItem.Click += new System.EventHandler(this.gr7ToolStripMenuItem_Click);
            // 
            // gr7ILCToolStripMenuItem
            // 
            this.gr7ILCToolStripMenuItem.Name = "gr7ILCToolStripMenuItem";
            this.gr7ILCToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.gr7ILCToolStripMenuItem.Text = "Gr 7-ILC";
            this.gr7ILCToolStripMenuItem.Click += new System.EventHandler(this.gr7ILCToolStripMenuItem_Click);
            // 
            // StudReportCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 735);
            this.Controls.Add(this.HonorsBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.StudentList);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StudReportCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportCardTaks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox StudentList;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button HonorsBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem honorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depEdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIILCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hSIIIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIIIILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIVToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hSIVILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeSchoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr3ILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr4ILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr5ILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr6ILCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gr7ILCToolStripMenuItem;
    }
}