using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Reports;
namespace ReportCardGenerator.Views
{
    public partial class DepEd : Form
    {
        public DepEd()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //HSIV rpt = new HSIV();
            //rpt.SetDataSource(StudReportCard.DS);
            //crystalReportViewer1.ReportSource = rpt;
        }
        public void loadDepEdReport(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
        {
            rpt.SetDataSource(StudReportCard.DS);
            crystalReportViewer1.ReportSource = rpt;
        }
        private void DepEd_Load(object sender, EventArgs e)
        {

        }
    }
}
