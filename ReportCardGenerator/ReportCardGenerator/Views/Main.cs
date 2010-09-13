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
using System.Xml;



namespace ReportCardGenerator.Views
{
    public partial class Main : Form, IView
    {

       
        IStudentController controller = FrontController.getInstance().getStudentController();
        public Main()
        {
            InitializeComponent();
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
            State.getInstance().Students.Clear();
            GrabeBookList.Items.RemoveAt(GrabeBookList.SelectedIndex);
            RefreshStudGridView();
        }

        private void Add_hoom_btn_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(GrabeBookList.SelectedItem.ToString());
            EGPXMLParser.parseHomeroomXML(controller, doc);

            ProgressBar PBar = new ProgressBar();
            PBar.ShowDialog();
        }

        private void Add_grade_btn_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(GrabeBookList.SelectedItem.ToString());
            EGPXMLParser.parseGradebookXML(controller, doc);
            ProgressBar PBar = new ProgressBar();
            PBar.ShowDialog();
        }

        private void GrabeBookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GrabeBookList.SelectedItem.ToString());
                State.getInstance().Students.Clear();
                //StudGridView.DataSource = null;
                RefreshStudGridView();
                EGPXMLParser.parseGradebookXML(controller, doc);

                RefreshStudGridView();
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
            ReportCardViewer rptCard = new ReportCardViewer();
            rptCard.ShowDialog();
            
        }

        private void StudGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            const int Stud_Id = 0;
            const int Stud_FName = 1;
            const int Stud_LName = 2;

            //Student studIdString = new Student();
            int i = StudGridView.CurrentCell.RowIndex;
            //studIdString.StudentID = StudGridView[0, i].Value.ToString();

            ReportCardViewer rptCard = new ReportCardViewer();
            rptCard.StudentpassedId = StudGridView[Stud_Id, i].Value.ToString();
            rptCard.FirstName = StudGridView[Stud_FName, i].Value.ToString();
            rptCard.LastName = StudGridView[Stud_LName, i].Value.ToString();
            rptCard.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog and get result.
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";//|All files (*.*)|*.*";
            openFileDialog1.Title = "Select GradeBook XML file";
            if (result == DialogResult.OK) // Test result.
            {
                GrabeBookList.Items.Add(openFileDialog1.FileName);
            }
        }

        private void StudGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            const int Stud_Id = 0;
            const String Stud_FName = "Column2";
            const String Stud_LName = "Column3";

            //Student studIdString = new Student();
            int i = StudGridView.CurrentCell.RowIndex;
            //studIdString.StudentID = StudGridView[0, i].Value.ToString();

            ReportCardViewer rptCard = new ReportCardViewer();
            rptCard.StudentpassedId = StudGridView[Stud_Id, i].Value.ToString();
            rptCard.FirstName = StudGridView[Stud_FName, i].Value.ToString();
            rptCard.LastName = StudGridView[Stud_LName, i].Value.ToString();
            rptCard.ShowDialog();
        }
    }
}
