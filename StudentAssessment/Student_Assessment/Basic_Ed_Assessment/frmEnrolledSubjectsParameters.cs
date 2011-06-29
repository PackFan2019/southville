using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Reports;
using log4net;
using System.Reflection;

namespace StudentAssessment
{
    public partial class frmEnrolledSubjectsParameters : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public frmEnrolledSubjectsParameters()
        {
            InitializeComponent();
        }

        private void btnStudentIDLookup_Click(object sender, EventArgs e)
        {
            using (frmStudentLookup studentLookup = new frmStudentLookup(txtCustomerNo.Text))
            {
                studentLookup.ShowDialog();

                txtCustomerNo.Text = studentLookup.GetCustomerNumber();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmReportViewer enrolledSubjectsReport;

            enrolledSubjectsReport = new frmReportViewer("Enrolled Subjects Report", new rptEnrolledSubjects()
                , new KeyValuePair<string, object>("Customer No", txtCustomerNo.Text)
                , new KeyValuePair<string, object>("Date From", dtpFrom.Value)
                , new KeyValuePair<string, object>("Date To", dtpTo.Value));

            enrolledSubjectsReport.Show();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}