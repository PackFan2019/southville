using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using StudentAssessment.Common;
using StudentAssessment.Objects;
using StudentAssessment.Adapter;
using StudentAssessment.Data;
using log4net;

namespace StudentAssessment
{
    public partial class frmStudentLookup : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        
        string customerNumber;
        string id;
        string name;

        public frmStudentLookup(string custnmbr)
        {
            InitializeComponent();
            this.customerNumber = custnmbr;

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadStudents()
        {
            try
            {
                if (Cache.students == null)
                    Cache.students = StudentAdapter.Instance.GetStudents();

                txtStudentID.Text = customerNumber;
                addItems(customerNumber);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                //Error.ShowMessage(ex.Message);
                throw ex;
            }
        }
        private void frmStudentLookup_Load(object sender, EventArgs e)
        {
            //Only get the students once unless refreshed
            loadStudents();
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            addItems(txtStudentID.Text);
        }

        public string GetCustomerNumber()
        {
            return id;
        }

        private void addItems(string name)
        {
            if (name == null || name.Equals(""))
            {
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Cache.students;
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                Students tempStudents = new Students();
                foreach (Student stud in Cache.students)
                {
                    if (stud.Fullname.ToUpper().Contains(name.ToUpper()))
                        tempStudents.Add(stud);

                }
                dataGridView1.DataSource = tempStudents;
            }
    
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
                Cache.students = StudentAdapter.Instance.GetStudents();
                loadStudents();
        }

        private void selectStudent()
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            id = dataGridView1[0, i].Value.ToString();
            name = dataGridView1[1, i].Value.ToString();
            label1.Text = "Current selected student: " + name;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                selectStudent();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                selectStudent();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                selectStudent();
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                selectStudent();
            }
        }
    }
}