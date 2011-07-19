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
using ReportCardGenerator.Views;
using System.Xml;



namespace ReportCardGenerator.Views
{
    public partial class Main : Form, IView
    {
        //private DMSoft.SkinCrafterLight skinCrafter;
        ProgressBar PBar = new ProgressBar();
        IStudentController controller = FrontController.getInstance().getStudentController();
        public Main()
        {
            InitializeComponent();
            //skinCrafter = new DMSoft.SkinCrafterLight();
            //skinCrafter.Skin = DMSoft.Skinset.Mac_Style;
            //skinCrafter.ApplySkin();
        }

        public void updateGUI()
        {
            //This gets called when the controller wants to update
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //Register this view with the frontcontroller   
            FrontController.getInstance().registerView(this);
            
        }



        private void Del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                State.getInstance().Students.Clear();
                GrabeBookList.Items.RemoveAt(GrabeBookList.SelectedIndex);
                RefreshStudGridView();
            }
            catch
            {
                MessageBox.Show("No xml path is selected", "Empty xml path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_hoom_btn_Click(object sender, EventArgs e)
        {
            try
            {
                PBar.Show();
                XmlDocument doc = new XmlDocument();
                doc.Load(GrabeBookList.SelectedItem.ToString());
                EGPXMLParser.parseHomeroomXML(controller, doc);
                //PBar.Close();
            }
            catch
            {
                //MessageBox.Show(er.Message);
                MessageBox.Show("Click XML path to Run Parsing!!!");
            }
        }

        private void Add_grade_btn_Click(object sender, EventArgs e)
        {
            PBar.Show();
            XmlDocument doc = new XmlDocument();
            doc.Load(GrabeBookList.SelectedItem.ToString());
            EGPXMLParser.parseGradebookXML(controller, doc);
            //PBar.Close();
        }

        private void GrabeBookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //XmlDocument doc = new XmlDocument();
                //doc.Load(GrabeBookList.SelectedItem.ToString());
                //State.getInstance().Students.Clear();
                //RefreshStudGridView();
                //EGPXMLParser.parseGradebookXML(controller, doc);

                //RefreshStudGridView();
                //foreach (Student s in State.getInstance().Students)
                //{
                //    StudentList.Items.Add(s.LastName + ", " + s.FirstName);
                //    StudentNumList.Items.Add(s.StudentID);
                //    StudentList.Sorted = true;
                //}
            }
            catch
            {
            }
        }

        private void RefreshStudGridView()
        {
            StudGridView.DataSource = null;
            int count = State.getInstance().Students.Count;
            int stopper = 0;

            while (stopper != count)
            {
                StudGridView.DataSource = null;
                StudGridView.AutoGenerateColumns = false;
                StudGridView.DataSource = State.getInstance().Students;
                stopper++;
            }
        }
        private void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudReportCard rptCard = new StudReportCard();
            rptCard.ShowDialog();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog and get result.
            openFileDialog1.Filter = "XML Files (*.xml)|*.XML|" + "All files (*.*)|*.*";
            openFileDialog1.Title = "Select GradeBook XML file";
            if (result == DialogResult.OK) // Test result.
            {
                GrabeBookList.Items.Add(openFileDialog1.FileName);
            }
        }

        private void StudGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //const int Stud_Id = 0;

            //Student studIdString = new Student();
            int i = StudGridView.CurrentCell.RowIndex;
            //studIdString.StudentID = StudGridView[0, i].Value.ToString();
            ReportCardOption rptCard = new ReportCardOption();
            rptCard.Show();
            //ReportCardTaks rptCard = new ReportCardTaks();
            //rptCard.StudntID = StudGridView[Stud_Id, i].Value.ToString();
            //rptCard.ShowDialog();
        }

        private void StudGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CrystalReportbtn_Click(object sender, EventArgs e)
        {
            ReportCardOption rptCard = new ReportCardOption();
            try
            {
                
                StudReportCard.SY = SYcb.Text;
                StudReportCard.T1 = T1Tb.Text;
                StudReportCard.T2 = T2Tb.Text;
                StudReportCard.T3 = T3Tb.Text;
                rptCard.Show();
            }
            catch
            {
            }
            finally
            {
                rptCard.Show();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.clearStudents();
            Student stud = new Student();
            stud.RptCard.Periods.Clear();

            Application.Exit();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.CompanyName + "\n" +
                Application.ProductName + "\n" +
                    "Version:" + Application.ProductVersion + "\n" +
                    "Project Manager: Mr. Wallen Tan" + "\n" +
                        "Programmers: Mr. Romyr Reyes and Mr. Takeo Tanemura" + "\n" +
                            "Date Implemented: January 2011", "Product Info Box",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
