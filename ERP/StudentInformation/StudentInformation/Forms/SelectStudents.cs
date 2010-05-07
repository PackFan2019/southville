using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Southville.GP.Data;
using Southville.GP.Beans;

namespace StudentInformation.Forms
{
    public partial class SelectStudents : Form
    {
        public Customer selectedStudent = new Customer();
        public DialogResult result;
        public SelectStudents()
        {
            InitializeComponent();
        }

        private void SelectStudents_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Session.getInstance().CustomerList;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                String id = dataGridView1[0, i].Value.ToString();
                String name = dataGridView1[1, i].Value.ToString();
                selectedStudent.CustomerID = id;
                selectedStudent.CustomerName = name;
                label1.Text = "Current selected student: " + name;
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            Session.getInstance().CustomerList = SQLData.getInstance().getAllCustomers();
            dataGridView1.DataSource = Session.getInstance().CustomerList;
            dataGridView1.Refresh();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
        }

 


    }
}
