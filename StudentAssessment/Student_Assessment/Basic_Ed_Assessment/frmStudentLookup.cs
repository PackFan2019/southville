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
using log4net;

namespace StudentAssessment
{
    public partial class frmStudentLookup : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        Students students;
        string customerNumber;
        
        public frmStudentLookup(string custnmbr)
        {
            InitializeComponent();
            this.customerNumber = custnmbr;

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudentLookup_Load(object sender, EventArgs e)
        {
            try
            {
                students = StudentAdapter.Instance.GetStudents();
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

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            addItems(txtStudentID.Text);
        }

        public string GetCustomerNumber()
        {
            return customerNumber;
        }

        private void addItems(string custnmbr)
        {
            try
            {
                lstStudentList.Items.Clear();

                foreach (Student stud in students)
                {
                    if (stud.StudentID.ToUpper().StartsWith(custnmbr.ToUpper()))
                    {
                        lstStudentList.Items.Add(
                            new ListViewItem(
                            new string[] { stud.StudentID
                                , stud.Fullname
                                , stud.GradeLevel }));
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                Prompt.ShowError(ex.Message);
            }
            
        }

        private void lstStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudentList.SelectedItems.Count == 1)
            {
                customerNumber = lstStudentList.SelectedItems[0].Text;
            }            
        }

        private void lstStudentList_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }
    }
}