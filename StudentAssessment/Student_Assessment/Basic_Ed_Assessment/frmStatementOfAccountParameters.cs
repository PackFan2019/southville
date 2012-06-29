using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Reports;

namespace StudentAssessment
{
    public partial class frmStatementOfAccountParameters : Form
    {
        public frmStatementOfAccountParameters()
        {
            InitializeComponent();
        }

        private void btnStudentIDLookup_Click(object sender, EventArgs e)
        {
            using (frmStudentLookup studentLookup = new frmStudentLookup(txtStudentNo.Text))
            {
                studentLookup.ShowDialog();

                txtStudentNo.Text = studentLookup.GetCustomerNumber();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmReportViewer statementOfAccountReport;

            statementOfAccountReport = new frmReportViewer("Statement Of Account Report", new rptStatementOfAccount()
                , new KeyValuePair<string, object>("Student No", txtStudentNo.Text));

            statementOfAccountReport.Show();

            this.Close();
        }
    }
}
