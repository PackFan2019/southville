using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Southville.GP.Beans;
using StudentInformation.Reports;
using StudentInformation.Datasets;
namespace StudentInformation.Forms
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
        }

        public void loadEnrollmentReport(List<Customer> students, String enrollmentStatus, String numberOfStudents)
        {
            EnrollmentReport rpt = new EnrollmentReport();
            DataSetStudents ds = new DataSetStudents();
            foreach (Customer c in students)
            {
                DataRow cRow = ds.Student.NewRow();
                cRow["CustomerID"] = c.CustomerID;
                cRow["CustomerName"] = c.CustomerName;
                cRow["FirstName"] = c.FirstName;
                cRow["LastName"] = c.LastName;
                cRow["Level"] = c.Level;
                cRow["Section"] = c.Section;
                cRow["Gender"] = c.Gender;
                ds.Student.Rows.Add(cRow);
            }
            rpt.DataDefinition.FormulaFields["EnrollmentStatus"].Text = "\""+enrollmentStatus+"\"";
            rpt.DataDefinition.FormulaFields["NumberOfStudents"].Text = "\"" + numberOfStudents + "\"";
            rpt.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        public void loadEasyGradeProReport(List<Customer> students)
        {
            EasyGradeProReport rpt = new EasyGradeProReport();
            DataSetStudents ds = new DataSetStudents();
            foreach (Customer c in students)
            {
                DataRow cRow = ds.Student.NewRow();
                cRow["CustomerID"] = c.CustomerID;
                cRow["CustomerName"] = c.CustomerName;
                cRow["FirstName"] = c.FirstName;
                cRow["LastName"] = c.LastName;
                cRow["Gender"] = c.Gender;
                cRow["EmailAddress"] = c.EmailAddress;
                cRow["Level"] = c.Level;
                cRow["Section"] = c.Section;
                ds.Student.Rows.Add(cRow);
            }
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

        }
        public void loadLetterOfRequest(List<Customer> selectedStudents, String schName, String schAdd, String attained, String schYear)
        {
            LetterOfRequestTOR rpt = new LetterOfRequestTOR();
            DataSetStudents ds = new DataSetStudents();
            foreach (Customer c in selectedStudents)
            {
                DataRow cRow = ds.Student.NewRow();
                cRow["CustomerID"] = c.CustomerID;
                cRow["CustomerName"] = c.CustomerName;
                cRow["FirstName"] = c.FirstName;
                cRow["LastName"] = c.LastName;
                cRow["Gender"] = c.Gender;
                cRow["EmailAddress"] = c.EmailAddress;
                cRow["Level"] = c.Level;
                cRow["Section"] = c.Section;
                ds.Student.Rows.Add(cRow);
            }
            rpt.DataDefinition.FormulaFields["schoolName"].Text = "\"" + schName+"\"";
            rpt.DataDefinition.FormulaFields["schoolAddress"].Text = "\"" + schAdd + "\"";
            rpt.DataDefinition.FormulaFields["attainment"].Text = "\"" + attained + "\"";
            rpt.DataDefinition.FormulaFields["schoolYear"].Text = "\"" + schYear + "\"";
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        public void EnrolmentStatus(List<Customer> selectedStudents)
        {
            EnrolmentReportStatus rpt = new EnrolmentReportStatus();
            DataSetStudents ds = new DataSetStudents();
            foreach (Customer c in selectedStudents)
            {
                DataRow cRow = ds.Student.NewRow();
                cRow["CustomerID"] = c.CustomerID;
                cRow["CustomerName"] = c.CustomerName;
                cRow["FirstName"] = c.FirstName;
                cRow["LastName"] = c.LastName;
                cRow["Gender"] = c.Gender;
                cRow["EmailAddress"] = c.EmailAddress;
                cRow["Level"] = c.Level;
                cRow["Section"] = c.Section;
                cRow["Guardians"] = c.BillTo;
                cRow["Address"] = c.CustomerAddress.AddressString;
                cRow["Phone1"] = c.CustomerAddress.PhoneNumber1;
                cRow["Phone2"] = c.CustomerAddress.PhoneNumber2;
                ds.Student.Rows.Add(cRow);
            }
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        public void loadAgeProfile(List<Customer> AllStudents)
        {
            AgeProfileReport rpt = new AgeProfileReport();
            AgeProfile ds = new AgeProfile();

            foreach (Customer c in AllStudents)
            {
                DataRow cRow = ds.Level.NewRow();
                cRow["Level"] = c.Level;
                cRow["Male"] = getCount(AllStudents, c.Level, "Male");
                cRow["Female"] = getCount(AllStudents, c.Level, "Female");
                cRow["Age"] = DateTime.Now.Year - Convert.ToDateTime(c.Birthday).Year;

                ds.Level.Rows.Add(cRow);
            }
            DataView myView = new DataView(ds.Level);
            dataGridView1.DataSource = myView;

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        public int getCount(List<Customer> customer, String level, String gender)
        {
            return customer.FindAll(delegate(Customer c) { return (c.Level.Equals(level) && c.Gender.Equals(gender)); }).Count;
        }
    }
}
