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
            //Student stud = controller.getStudent(this.studentpassedId);
            string skillName = "";
            string lettergrade = "";
            double numericgrade = 0;

            string subject = "";
            double subjectGrade = 0;
            string subletergrade = "";
            foreach (Period period in controller.getStudent(this.studentpassedId).RptCard.Periods)
            {
                DataRow dRow = Dataset.ReportCardTable.NewRow();
               

                dRow["Termname"] = period.PeriodName;
                foreach (Skill skill in controller.getPeriod(controller.getStudent(this.studentpassedId), period.PeriodID).Skills)
                {
                    //DataRow eRow = Dataset.ReportCardTable.NewRow();
                    skillName = skill.SkillName;
                    lettergrade = skill.LetterGrade;
                    numericgrade = skill.NumericGrade;
                    //Dataset.ReportCardTable.Rows.Add(eRow);
                    //MessageBox.Show(skill.SkillName + " " + skill.LetterGrade + " " + skill.NumericGrade);
                }
                foreach (Grade grade in controller.getPeriod(controller.getStudent(this.studentpassedId), period.PeriodID).Grades)
                {
                    //DataRow fRow = Dataset.ReportCardTable.NewRow();
                    //dRow["Subjectname"] = grade.SubjectName;
                    //dRow["sublettergrade"] = grade.LetterGrade;
                    //dRow["subnumgrade"] = grade.NumericGrade;

                    subject = grade.SubjectName;
                    subletergrade = grade.LetterGrade;
                    subjectGrade = grade.NumericGrade;
                    //Dataset.ReportCardTable.Rows.Add(fRow);
                    //MessageBox.Show(controller.getStudent(this.studentpassedId).StudentID.ToString() + " " + grade.SubjectName + " " + grade.LetterGrade + " " + grade.NumericGrade);
                }
                dRow["skillname"] = skillName;
                dRow["skillletergrade"] = lettergrade;
                dRow["skillnumgrade"] = numericgrade;

                dRow["Subjectname"] = subject;
                dRow["sublettergrade"] = subletergrade;
                dRow["subnumgrade"] = subletergrade;

                Dataset.ReportCardTable.Rows.Add(dRow);
            }


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
