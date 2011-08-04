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
using StudentInformation.Beans;
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
            List<String> Levels = new List<string>();
            foreach (Customer c in AllStudents)
            {
                if (!Levels.Exists(delegate(String s) { return s.Equals(c.Level); }))
                {
                    Levels.Add(c.Level);
                    int age = DateTime.Now.Year - Convert.ToDateTime(c.Birthday).Year;


                    //DataRow cRow = ds.Level.NewRow();
                    if (getCount(AllStudents, c.Level, "Male") != 0 || getCount(AllStudents, c.Level, "Male").ToString() != "")
                    {
                        if (getCount(AllStudents, c.Level, "Female") != 0 || getCount(AllStudents, c.Level, "Female").ToString() != "")
                        {
                            if (c.Level.Equals("Grade 1") || c.Level.Equals("Grade 2") || c.Level.Equals("Grade 3") || c.Level.Equals("Grade 4") || c.Level.Equals("Grade 5") || c.Level.Equals("Grade 6"))
                            {
                                if (age >= 16 && age <= 18)
                                {
                                    ds.Level[0][18 + c.Level + "M"] = getCount(AllStudents, c.Level, "Male");
                                    ds.Level[0][18 + c.Level + "F"] = getCount(AllStudents, c.Level, "Female");
                                }
                                else if (age >= 19)
                                {
                                    ds.Level[0][19 + c.Level + "M"] = getCount(AllStudents, c.Level, "Male");
                                    ds.Level[0][19 + c.Level + "F"] = getCount(AllStudents, c.Level, "Female");
                                    //DataRow cRow2 = ds.Level.NewRow();
                                    //cRow2[19 + c.Level + "M"] = getCount(AllStudents, c.Level, "Male");
                                    //cRow2[19 + c.Level + "F"] = getCount(AllStudents, c.Level, "Female");
                                    //ds.Level.Rows.Add(cRow2);
                                }
                                else
                                {
                                    DataRow cRow3 = ds.Level.NewRow();
                                    cRow3[age + c.Level + "M"] = getCount(AllStudents, c.Level, "Male");
                                    cRow3[age + c.Level + "F"] = getCount(AllStudents, c.Level, "Female");
                                    ds.Level.Rows.Add(cRow3);
                                    ds.Level[0][age + c.Level + "M"] = getCount(AllStudents, c.Level, "Male");
                                    ds.Level[0][age + c.Level + "F"] = getCount(AllStudents, c.Level, "Female");
                                    
                                }
                                
                            }
                        }
                    }

                }
            }


            //DataView myView = new DataView(ds.Level);
            //dataGridView1.DataSource = myView;

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        public int getCount(List<Customer> customer, String level, String gender)
        {
            int count = customer.FindAll(delegate(Customer c) { return (c.Level.Equals(level) && c.Gender.Equals(gender)); }).Count;
            return count;
        }
        public void loadAgeAndAddress(List<Customer> AllStudents)
        {
            AgeAndAddress rpt = new AgeAndAddress();
            DataSetStudents ds = new DataSetStudents();
            foreach (Customer c in AllStudents)
            {
                int age = DateTime.Now.Year - c.Birthday.Year;
                DataRow cRow = ds.Student.NewRow();
                cRow["CustomerID"] = c.CustomerID;
                cRow["FirstName"] = c.FirstName;
                cRow["LastName"] = c.LastName;
                cRow["Gender"] = c.Gender;
                //cRow["EmailAddress"] = c.EmailAddress;
                //cRow["Level"] = c.Level;
                //cRow["Section"] = c.Section;
                //cRow["Guardians"] = c.BillTo;
                cRow["Address"] = c.CustomerAddress.AddressString;
                cRow["Age"] = age;
                ds.Student.Rows.Add(cRow);
            }
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
