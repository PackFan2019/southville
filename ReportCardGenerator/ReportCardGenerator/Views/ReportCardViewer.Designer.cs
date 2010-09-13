namespace ReportCardGenerator.Views
{
    partial class ReportCardViewer
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
            this.rptCard1 = new ReportCardGenerator.rptCard();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport11 = new ReportCardGenerator.CrystalReport1();
            this.PeriodDG = new System.Windows.Forms.DataGridView();
            this.SubjectDG = new System.Windows.Forms.DataGridView();
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDG)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = 0;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.ReportSource = this.reportDocument1;
            this.crystalReportViewer2.Size = new System.Drawing.Size(855, 379);
            this.crystalReportViewer2.TabIndex = 0;
            // 
            // CrystalReport11
            // 
            this.CrystalReport11.InitReport += new System.EventHandler(this.CrystalReport11_InitReport);
            // 
            // PeriodDG
            // 
            this.PeriodDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PeriodDG.Location = new System.Drawing.Point(0, 385);
            this.PeriodDG.Name = "PeriodDG";
            this.PeriodDG.Size = new System.Drawing.Size(357, 229);
            this.PeriodDG.TabIndex = 1;
            // 
            // SubjectDG
            // 
            this.SubjectDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectDG.Location = new System.Drawing.Point(373, 385);
            this.SubjectDG.Name = "SubjectDG";
            this.SubjectDG.Size = new System.Drawing.Size(377, 229);
            this.SubjectDG.TabIndex = 2;
            // 
            // reportDocument1
            // 
            this.reportDocument1.FileName = "rassdk://C:\\Southville project\\ReportCardGenerator\\ReportCardGenerator\\Reports\\rp" +
                "tReportCard.rpt";
            // 
            // ReportCardViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 611);
            this.Controls.Add(this.SubjectDG);
            this.Controls.Add(this.PeriodDG);
            this.Controls.Add(this.crystalReportViewer2);
            this.Name = "ReportCardViewer";
            this.Text = "ReportCard_Viewer";
            this.Load += new System.EventHandler(this.ReportCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PeriodDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private ReportCardGenerator.Reports.rptReportCard rptReportCard1;
        private rptCard rptCard1;
        private CrystalReport1 CrystalReport11;
        private System.Windows.Forms.DataGridView PeriodDG;
        private System.Windows.Forms.DataGridView SubjectDG;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
    }
}
