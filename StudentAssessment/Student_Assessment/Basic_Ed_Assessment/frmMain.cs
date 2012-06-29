using System;
using System.Windows.Forms;
using System.Configuration;
using StudentAssessment.Data;
using DynamicsGPLogin;

namespace StudentAssessment
{
    public partial class frmMain : Form
    {
        static frmAssessment AssessmentForm;
        static frmAssessmentsByStudent AssessmentsByStudent;
        static frmEnrolledSubjectsParameters EnrolledSubjectsParameters;
        static frmStudentsPerSubjectParameters StudentsPerSubjectParameters;
        static frmStatementOfAccountParameters StatementOfAccountParameters;

        public frmMain()
        {
            InitializeComponent();

            //string connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //20100625
            string connString = frmLogin.Instance.GetLogin().GetConnectionString(ConnectionType.SQLClient);
            DiscountData.Instance.ConnString = connString;
            ItemData.Instance.ConnString = connString;
            PlanData.Instance.ConnString = connString;
            StudentData.Instance.ConnString = connString;
            TransactionData.Instance.ConnString = connString;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
        }

        private void btnAssess_Click(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            if (AssessmentForm == null)
            {
                AssessmentForm = new frmAssessment();
            }
            else
            {
                if (AssessmentForm.Created == false)
                {
                    AssessmentForm = new frmAssessment();
                }
            }
            // Make it a child of this MDI form before showing it.

            AssessmentForm.MdiParent = this;
            AssessmentForm.Show();
            AssessmentForm.Activate();
        }

        private void assessmentsByStudentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AssessmentsByStudent == null)
            {
                AssessmentsByStudent = new frmAssessmentsByStudent();
            }
            else
            {
                if (AssessmentsByStudent.Created == false)
                {
                    AssessmentsByStudent = new frmAssessmentsByStudent();
                }
            }

            AssessmentsByStudent.MdiParent = this;
            AssessmentsByStudent.Show();
            AssessmentsByStudent.Activate();
        }

        private void enrolledSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EnrolledSubjectsParameters == null)
            {
                EnrolledSubjectsParameters = new frmEnrolledSubjectsParameters();
            }
            else
            {
                if (EnrolledSubjectsParameters.Created == false)
                {
                    EnrolledSubjectsParameters = new frmEnrolledSubjectsParameters();
                }
            }

            EnrolledSubjectsParameters.MdiParent = this;
            EnrolledSubjectsParameters.Show();
            EnrolledSubjectsParameters.Activate();
        }

        private void studentsPerSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StudentsPerSubjectParameters == null)
            {
                StudentsPerSubjectParameters = new frmStudentsPerSubjectParameters();
            }
            else
            {
                if (StudentsPerSubjectParameters.Created == false)
                {
                    StudentsPerSubjectParameters = new frmStudentsPerSubjectParameters();
                }
            }

            StudentsPerSubjectParameters.MdiParent = this;
            StudentsPerSubjectParameters.Show();
            StudentsPerSubjectParameters.Activate();
        }

        private void statementOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StatementOfAccountParameters == null)
            {
                StatementOfAccountParameters = new frmStatementOfAccountParameters();
            }
            else
            {
                if (StatementOfAccountParameters.Created == false)
                {
                    StatementOfAccountParameters = new frmStatementOfAccountParameters();
                }
            }

            StatementOfAccountParameters.MdiParent = this;
            StatementOfAccountParameters.Show();
            StatementOfAccountParameters.Activate();
        }       
    }
}
