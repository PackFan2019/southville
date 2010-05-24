namespace StuffshopPOS
{
    partial class PriceGroupReportViewer
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.PriceGroup1 = new StuffshopPOS.PriceGroup();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.PriceGroup1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(668, 539);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // PriceGroupReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 539);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "PriceGroupReportViewer";
            this.Text = "PriceGroupReportViewer";
            this.Load += new System.EventHandler(this.PriceGroupReportViewer_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PriceGroupReportViewer_FormClosed);
            this.Leave += new System.EventHandler(this.PriceGroupReportViewer_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private PriceGroup PriceGroup1;
    }
}