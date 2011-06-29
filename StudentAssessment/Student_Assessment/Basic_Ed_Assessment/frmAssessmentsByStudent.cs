using System;
using System.Windows.Forms;
using StudentAssessment.Adapter;
using StudentAssessment.Objects;
using System.Configuration;
using System.Collections.Specialized;

namespace StudentAssessment
{
    public partial class frmAssessmentsByStudent : Form
    {
        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;
        Transactions transactions;
        string studentID="";
        frmViewAssessment viewAssessment;
        Student student;

        public frmAssessmentsByStudent()
        {
            InitializeComponent();
        }

        private void frmAssessmentsByStudent_Load(object sender, EventArgs e)
        {
            initializeAssessmentList();
        }

        private void initializeAssessmentList()
        {
            lstDocuments.Columns.Clear();
            lstDocuments.Columns.Add("Doc. No.", 90, HorizontalAlignment.Left);
            lstDocuments.Columns.Add("Doc. Type", 70, HorizontalAlignment.Left);
            lstDocuments.Columns.Add("Doc. Date", 80, HorizontalAlignment.Left);
            lstDocuments.Columns.Add("Level", 80, HorizontalAlignment.Left);
            lstDocuments.Columns.Add("Currency", 60, HorizontalAlignment.Right);
            lstDocuments.Columns.Add("Sch. Year", 80, HorizontalAlignment.Right);
            lstDocuments.Columns.Add("Subtotal", 60, HorizontalAlignment.Right);
            lstDocuments.Columns.Add("Discount", 60, HorizontalAlignment.Right);
            lstDocuments.Columns.Add("Total Amount", 80, HorizontalAlignment.Right);
        }

        private void btnStudentIDLookup_Click(object sender, EventArgs e)
        {
            using (frmStudentLookup studentLookup = new frmStudentLookup(txtStudentID.Text))
            {
                studentLookup.ShowDialog();
                studentID = studentLookup.GetCustomerNumber();
                txtStudentID.Text = studentID;
            }

            populateDocumentList();   
        }

        private void populateDocumentList()
        {
            lstDocuments.Items.Clear();
            student = StudentAdapter.Instance.GetStudent(studentID);
            if (student.StudentFound)
            {
                txtName.Text = student.Fullname;

                lblDocumentNo.Enabled = true;
                txtDocumentNo.Enabled = true;

                transactions = TransactionAdapter.Instance.GetTransactionsByStudentID(student.StudentID);

                if (transactions.Count > 0)
                {
                    foreach (Transaction t in transactions)
                    {
                        if (t.DocumentNumber.ToUpper().StartsWith(txtDocumentNo.Text.ToUpper()))
                        {
                            t.RecomputeTotals(config["Tuition_Fee"].ToString()
                                , config["Miscellaneous_Fee"].ToString()
                                , config["Miscellaneous_Fee_Optional"].ToString()
                                , config["Direct_Cost"].ToString()
                                , config["Direct_Cost_Optional"].ToString()
                                , config["Additional_Fee"].ToString());
                            lstDocuments.Items.Add(new ListViewItem(
                            new string[] 
                                    {
                                        t.DocumentNumber,
                                        Enum.GetName(typeof(Transaction_Type), t.TransactionType),
                                        t.DocumentDate.ToShortDateString(),
                                        t.GradeLevel,
                                        t.CurrencyID,
                                        String.Format("{0}-{1}", Convert.ToString(t.SYFrom), Convert.ToString(t.SYTo)),
                                        Convert.ToString(t.Subtotal),
                                        Convert.ToString(t.TotalDiscounts),
                                        Convert.ToString(t.TotalAmount)
                                    }
                            ));
                        }                        
                    }
                }
            }
            else
            {
                txtName.Clear();
                lblDocumentNo.Enabled = false;

                txtDocumentNo.Clear();
                txtDocumentNo.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtStudentID_Leave(object sender, EventArgs e)
        {
            studentID = txtStudentID.Text;
            populateDocumentList();
        }

        private void btnRedisplay_Click(object sender, EventArgs e)
        {
            studentID = txtStudentID.Text;
            populateDocumentList();
        }

        private void lstDocuments_DoubleClick(object sender, EventArgs e)
        {
            string assessmentNo;
            Transaction_Type sopType;
            if (lstDocuments.SelectedItems.Count == 1)
            {
                assessmentNo = lstDocuments.SelectedItems[0].Text;
                if (lstDocuments.SelectedItems[0].SubItems[1].Text 
                    == Enum.GetName(typeof(Transaction_Type), Transaction_Type.Assessment))
                {
                    sopType = Transaction_Type.Assessment;
                }
                else if (lstDocuments.SelectedItems[0].SubItems[1].Text
                    == Enum.GetName(typeof(Transaction_Type), Transaction_Type.Drop))
                {
                    sopType = Transaction_Type.Drop;
                }
                else
                {
                    sopType = Transaction_Type.Add;
                }

                
                if (viewAssessment == null)
                {
                    viewAssessment = new frmViewAssessment(transactions.GetTransaction(assessmentNo, sopType));
                }
                else
                {
                    if (viewAssessment.Created == false)
                    {
                        viewAssessment = new frmViewAssessment(transactions.GetTransaction(assessmentNo, sopType));
                    }
                    else
                    {
                        viewAssessment.Close();
                        viewAssessment = null;

                        viewAssessment = new frmViewAssessment(transactions.GetTransaction(assessmentNo, sopType));
                    }
                }
                viewAssessment.MdiParent = this.ParentForm; //added 20101006
                viewAssessment.Show();
                viewAssessment.Activate();
            }
        }


    }
}