using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Controller;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Reports;
using ReportCardGenerator.Views;
namespace ReportCardGenerator.Views
{
    public partial class Honors : Form
    {
        HonorsTerm1 termReport = new HonorsTerm1();
        HonorsTerm2 term2Report = new HonorsTerm2();
        HonorsTerm3 term3Report = new HonorsTerm3();
        HonorsFinalTerm FinaltermReport = new HonorsFinalTerm();
        public Honors()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            termReport.SetDataSource(StudReportCard.DS);
            crystalReportViewer1.ReportSource = termReport;
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            term2Report.SetDataSource(StudReportCard.DS);
            crystalReportViewer2.ReportSource = term2Report;
        }

        private void crystalReportViewer3_Load(object sender, EventArgs e)
        {
            term3Report.SetDataSource(StudReportCard.DS);
            crystalReportViewer3.ReportSource = term3Report;
        }

        private void crystalReportViewer4_Load(object sender, EventArgs e)
        {
            FinaltermReport.SetDataSource(StudReportCard.DS);
            crystalReportViewer4.ReportSource = FinaltermReport;
        }
    }
}
