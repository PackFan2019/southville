using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Reports;
using log4net;
using System.Reflection;
using System.Configuration;

namespace StudentAssessment
{
    public partial class frmStudentsPerSubjectParameters : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;

        public frmStudentsPerSubjectParameters()
        {
            InitializeComponent();
        }

        private void btnStudentIDLookup_Click(object sender, EventArgs e)
        {
            using (frmItemLookup itemLookup = new frmItemLookup(config["Default_Price_Level"].ToString(), config["Default_Currency"].ToString(), true /*subjects only*/))
            {
                itemLookup.ShowDialog();

                txtCourse.Text = itemLookup.GetItemNumber();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmReportViewer studentsPerSubjectReport;

            studentsPerSubjectReport = new frmReportViewer("Students Per Subject Report", new rptStudentsPerSubject()
                , new KeyValuePair<string, object>("Item Number", txtCourse.Text)
                , new KeyValuePair<string, object>("Date From", dtpFrom.Value)
                , new KeyValuePair<string, object>("Date To", dtpTo.Value));

            studentsPerSubjectReport.Show();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}