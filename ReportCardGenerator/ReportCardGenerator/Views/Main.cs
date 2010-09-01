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
            GrabeBookList.Items.RemoveAt(GrabeBookList.SelectedIndex);
            StudentList.Items.Clear();
        }

        private void Add_hoom_btn_Click(object sender, EventArgs e)
        {
            //State.getInstance().Students.Clear();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog and get result.
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";//|All files (*.*)|*.*";
            openFileDialog1.Title = "Select Hoomroom XML file";
            if (result == DialogResult.OK) // Test result.
            {
                GrabeBookList.Items.Add(openFileDialog1.FileName);
            }
        }

        private void Add_grade_btn_Click(object sender, EventArgs e)
        {
            
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog and get result.
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";//|All files (*.*)|*.*";
            openFileDialog1.Title = "Select GradeBook XML file";
            if (result == DialogResult.OK) // Test result.
            {
                GrabeBookList.Items.Add(openFileDialog1.FileName);
            }
        }

        private void GrabeBookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GrabeBookList.SelectedItem.ToString());
                State.getInstance().Students.Clear();
                StudentList.Items.Clear();
                EGPXMLParser.parseHomeroomXML(controller, doc);
                
                foreach (Student s in State.getInstance().Students)
                {
                    StudentList.Items.Add(s.LastName + ", " + s.FirstName);
                    StudentList.Sorted = true;
                }
            }
            catch
            {
            }
        }

        private void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        

    }
}
