using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using ReportCardGenerator.Data;
using ReportCardGenerator.Controller;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Reports;
using ReportCardGenerator.Utilities;
using ReportCardGenerator.Exceptions;
using ReportCardGenerator.DataSet;
//using ReportCardGenerator.Reports;

namespace ReportCardGenerator.Views
{
    public partial class ReportCardViewer : Form
    {
        IStudentController controller = FrontController.getInstance().getStudentController();
        public ReportCardViewer()
        {
            InitializeComponent();
        }
        #region
        public static ReportCardData Dataset;
        private String studentpassedId;

        public String StudentpassedId
        {
            get { return studentpassedId; }
            set { studentpassedId = value; }
        }

        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        #endregion
        private void ReportCard_Load(object sender, EventArgs e)
        {
            LoadReport();
            DataView myDataview = new DataView(Test.dataset.SkillTable);
            PeriodDG.DataSource = myDataview;

            DataView dataView = new DataView(Test.dataset.SubjectTable);
            SubjectDG.DataSource = dataView;
        }
        private void LoadReport()
        {
           
            //ReportCardReport rptCard = new ReportCardReport();
            
            ////Student stud = controller.getStudent(this.studentpassedId);
            ////MessageBox.Show(State.getInstance().Students.Count.ToString());
            //foreach (Student stud in State.getInstance().Students)
            //{
            //    //MessageBox.Show(stud.StudentID.ToString());
            //    foreach (Period period in controller.getStudent(stud.StudentID).RptCard.Periods)
            //    {
            //        //dRow["Termname"] = period.PeriodName;
            //        //foreach (Skill skill in controller.getPeriod(controller.getStudent(stud.StudentID), period.PeriodID).Skills)
            //        //{

            //        //    //dRow["skillname"] = skill.SkillName;
            //        //    //dRow["skillletergrade"] = skill.LetterGrade;
            //        //    //dRow["skillnumgrade"] = skill.NumericGrade;
            //        //    //MessageBox.Show(controller.getStudent(stud.StudentID).StudentID + " " +skill.SkillName + " " + skill.LetterGrade + " " + skill.NumericGrade);
            //        //}
            //        foreach (Grade grade in controller.getPeriod(controller.getStudent(stud.StudentID), period.PeriodID).Grades)
            //        {

            //            //dRow["Subjectname"] = grade.SubjectName;
            //            //dRow["sublettergrade"] = grade.LetterGrade;
            //            //dRow["subnumgrade"] = grade.NumericGrade;
            //            MessageBox.Show(controller.getStudent(stud.StudentID).StudentID.ToString() + " " + grade.SubjectName + " " + grade.LetterGrade + " " + grade.NumericGrade);
            //        }

            //    }
            //}

            //rptCard.DataDefinition.FormulaFields["StudentID"].Text = "\"" + this.studentpassedId + "\"";
            //rptCard.DataDefinition.FormulaFields["FirstName"].Text = "\"" + this.firstName + "\"";
            //rptCard.DataDefinition.FormulaFields["LastName"].Text = "\"" + this.lastName + "\"";

            //rptCard.SetDataSource(ReportCardData.da);



            //ReportCardData dataset = new ReportCardData();
            //for (int x = 0; x < State.getInstance().Students.Count; x++)
            //{
                foreach (Student stud in State.getInstance().Students)
                {
                    if (Test.dataset.StudentTable.Rows.Contains(stud.FirstName) == false)
                    {
                        DataRow studRow = Test.dataset.StudentTable.NewRow();
                        studRow["StudentID"] = stud.StudentID;
                        studRow["FirstName"] = stud.FirstName;
                        studRow["LastName"] = stud.LastName;

                        Test.dataset.StudentTable.Rows.Add(studRow);
                    }
                    //foreach (Period period in stud.RptCard.Periods)
                    //{
                    //    Period per = stud.RptCard.Periods.Find(delegate(Period p) { return p.PeriodID.Equals(period.PeriodID); });
                    //    //DataRow row = dataset.PeriodTable.Rows.Contains(period.PeriodID);
                    //    if (Test.dataset.PeriodTable.Rows.Contains(period.PeriodID) == false)
                    //    {
                    //        DataRow periodRow = Test.dataset.PeriodTable.NewRow();
                    //        periodRow["TermID"] = period.PeriodID;
                    //        periodRow["TermName"] = period.PeriodName;
                    //        periodRow["StudentID"] = stud.StudentID;

                    //        Test.dataset.PeriodTable.Rows.Add(periodRow);
                    //    }
                    //    //foreach (Grade grade in period.Grades)
                    //    //{
                    //    //    DataRow gradeRow = dataset.SubjectTable.NewRow();
                    //    //    gradeRow["SubjectID"] = grade.SubjectID;
                    //    //    gradeRow["TermID"] = period.PeriodID;
                    //    //    gradeRow["SubjectName"] = grade.SubjectName;
                    //    //    gradeRow["SubjectNumGrade"] = grade.NumericGrade;
                    //    //    gradeRow["SubjectLetGrade"] = grade.LetterGrade;
                    //    //    gradeRow["StudentID"] = stud.StudentID;

                    //    //    dataset.SubjectTable.Rows.Add(gradeRow);
                    //    //}
                    //}
                }
            //}


            //System.Windows.Forms.MessageBox.Show(Dataset.StudentTable.Count.ToString());
            //dataset.SubjectTable.Count.ToString();
            //DataTable dt = Test.dataset.SubjectTable.Clone();

            //DataRow[] results = Test.dataset.SubjectTable.Select("StudentID='95-0072'");

            //foreach (DataRow dr in results)
            //{
            //    rptDataSet rptData = new rptDataSet();
            //    rptData.SubjectTable.ImportRow(dr);

            //}
                //CrystalReport1 rptCard = new CrystalReport1();

            rptReportCard rptCard = new rptReportCard();
            rptCard.SetDataSource(Test.dataset);
            crystalReportViewer2.ReportSource = rptCard;
            crystalReportViewer2.Refresh();
            

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void ReportCardReport2_InitReport(object sender, EventArgs e)
        {

        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {
            
        }
    }
}
