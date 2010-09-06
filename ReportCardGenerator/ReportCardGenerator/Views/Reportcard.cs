using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Data;
using ReportCardGenerator.Controller;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Utilities;
using ReportCardGenerator.Exceptions;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Reports;

namespace ReportCardGenerator.Views
{
    public partial class ReportCard : Form
    {
        IStudentController controller = FrontController.getInstance().getStudentController();
        public ReportCard()
        {
            InitializeComponent();
        }
        #region
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
        }
        private void LoadReport()
        {
            ReportCardReport rptCard = new ReportCardReport();
            ReportCardData Dataset = new ReportCardData();
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

            rptCard.DataDefinition.FormulaFields["StudentID"].Text = "\"" + this.studentpassedId + "\"";
            rptCard.DataDefinition.FormulaFields["FirstName"].Text = "\"" + this.firstName + "\"";
            rptCard.DataDefinition.FormulaFields["LastName"].Text = "\"" + this.lastName + "\"";

            rptCard.SetDataSource(Dataset);
            crystalReportViewer1.ReportSource = rptCard;
            crystalReportViewer1.Refresh();


        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ReportCardReport2_InitReport(object sender, EventArgs e)
        {

        }
    }
}
