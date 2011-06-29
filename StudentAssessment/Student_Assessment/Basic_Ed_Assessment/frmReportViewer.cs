using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using StudentAssessment.Reports;
using DynamicsGPLogin;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using log4net;
using System.Reflection;
using StudentAssessment.Common;

namespace StudentAssessment
{
    public partial class frmReportViewer : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        ReportClass report;        
        KeyValuePair<string, object>[] reportParameters;
        ReportDocument reportToDisplay;

        Database crDatabase;
        Tables crTables;

        TableLogOnInfo crTableLogOnInfo;
        ConnectionInfo crConnectionInfo = new ConnectionInfo();        

        public frmReportViewer(string reportTitle, ReportClass report, params KeyValuePair<string, object>[] reportParameters)//string assessmentNo, int sopType)
        {
            InitializeComponent();

            this.report = report;
            this.reportParameters = reportParameters;
            this.Text = reportTitle;
        }

        private void loadReport()
        {
            try
            {
                reportToDisplay = new ReportDocument();
                reportToDisplay.Load(Application.StartupPath + @"\Reports\" + report.ResourceName);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                //if report does not exists
                reportToDisplay = report;
            }
        }

        private void setConnectionDetails()
        {
            crConnectionInfo.ServerName = frmLogin.Instance.GetLogin().Dsn;
            crConnectionInfo.DatabaseName = frmLogin.Instance.GetLogin().Database;
            crConnectionInfo.UserID = frmLogin.Instance.GetLogin().Username;
            crConnectionInfo.Password = frmLogin.Instance.GetLogin().Password;

            crDatabase = reportToDisplay.Database;

            crTables = crDatabase.Tables;

            foreach (Table crTable in crTables)
            {
                crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);
            }
        }

        private void setParameterValues()
        {
            for (int i = 0; i <= reportParameters.Length - 1; i++)
            {
                reportToDisplay.SetParameterValue(reportParameters[i].Key, reportParameters[i].Value);
            }
        }

        private void displayReport()
        {
            loadReport();
            setConnectionDetails();
            setParameterValues();

            if (reportToDisplay.Rows.Count == 0)
            {
                Prompt.ShowError("There are no records to display.");
                Close();
            }

            crystalReportViewer1.ReportSource = reportToDisplay;
            crystalReportViewer1.Refresh();
        }
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            displayReport();            
        }
    }
}