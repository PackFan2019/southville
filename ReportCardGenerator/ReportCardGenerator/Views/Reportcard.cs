using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Controller;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;

namespace ReportCardGenerator.Views
{
    public partial class Reportcard : Form, IView
    {
        IStudentController controller = FrontController.getInstance().getStudentController();
        public Reportcard()
        {
            InitializeComponent();
        }

        public void updateGUI()
        {
            //This gets called when the controller wants to update
        }

        private void Reportcard_Load(object sender, EventArgs e)
        {

        }

        private void LoadReport()
        {
            crystalreportcard ReportCryst = new crystalreportcard();
            ReportCardData DataSet = new ReportCardData();

            foreach (Student stud in State.getInstance().Students)
            {
                DataRow DRow = DataSet.ReportCardTable.NewRow();
                foreach (ReportCard ReportCard in stud)
                {
                    foreach (Period Period in ReportCard)
                    {
                        DRow["Termname"] = Period.PeriodName;
                        foreach (Skill skill in Period)
                        {
                            DRow["skillname"] = skill.SkillName;
                            DRow["skillletergrade"] = skill.LetterGrade;
                            DRow["skillnumgrade"] = skill.NumericGrade;
                        }
                        foreach (Grade grade in Period)
                        {
                            DRow["Subjectname"] = grade.SubjectName;
                            DRow["sublettergrade"] = grade.LetterGrade;
                            DRow["subnumgrade"] = grade.NumericGrade;
                        }
                    }
                }
                ReportCryst.SetDataSource(DataSet);
                crystalReportViewer1.ReportSource = ReportCryst;
                crystalReportViewer1.Refresh();


            }   
        }
    }
}
