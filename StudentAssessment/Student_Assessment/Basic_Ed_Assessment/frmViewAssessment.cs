using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Objects;
using StudentAssessment.Adapter;
using System.Configuration;
using System.Collections.Specialized;
using StudentAssessment.Reports;

namespace StudentAssessment
{
    public partial class frmViewAssessment : Form
    {
        frmViewDiscountDetails discountDetails = null;
        frmViewPaymentDetails paymentDetails = null;

        //Discounts discounts;
        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;
        Transaction transaction;
        public frmViewAssessment(Transaction transaction)
        {
            InitializeComponent();
            this.transaction = transaction;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void populateHeader()
        {
            cboDoctype.Text = Enum.GetName(typeof(Transaction_Type), transaction.TransactionType);
            txtAssessmentNo.Text = transaction.DocumentNumber;
            txtStudentID.Text = transaction.StudentID;
            txtName.Text = transaction.StudentName;
            txtLevel.Text = transaction.GradeLevel;
            txtBatchID.Text = transaction.BatchID;
            txtCurrencyID.Text = transaction.CurrencyID;
            //txtPlan.Text = assessment.Plan.PlanID;
            dtpDocumentDate.Value = transaction.DocumentDate;
            txtSYFrom.Text = Convert.ToString(transaction.SYFrom);
            txtSYTo.Text = Convert.ToString(transaction.SYTo);
            txtRemarks.Text = transaction.Comments;
        }
        private void populateTotals()
        {

            txtTuitionFee.Text = Convert.ToString(transaction.TotalTuition);
            txtMiscellaneousFees.Text = Convert.ToString(transaction.TotalMiscellaneousFees);
            txtDirectCosts.Text = Convert.ToString(transaction.TotalDirectCosts);
            txtAdditionalFees.Text = Convert.ToString(transaction.TotalAdditionalFees);
            txtSubtotal.Text = Convert.ToString(transaction.Subtotal);
            txtDiscount.Text = Convert.ToString(transaction.TotalDiscounts);
            txtInstallmentFee.Text = Convert.ToString(transaction.InstallmentFee);
            txtReservationFee.Text = Convert.ToString(transaction.ReservationFee);
            txtNetAmountToPay.Text = Convert.ToString(transaction.TotalAmount);
        }

        private void initializeList()
        {
            //add groups            
            lstItems.Groups.Clear();
            lstItems.Groups.Add("TF", config["Tuition_Fee_Header"]);
            lstItems.Groups.Add("MF", config["Miscellaneous_Fees_Header"]);
            lstItems.Groups.Add("DC", config["Direct_Costs_Header"]);
            lstItems.Groups.Add("AF", config["Additional_Fees_Header"]);

            //add columns
            lstItems.Columns.Clear();
            lstItems.Columns.Add("Item Number", 90, HorizontalAlignment.Left);
            lstItems.Columns.Add("Description", 160, HorizontalAlignment.Left);
            lstItems.Columns.Add("Qty", 30, HorizontalAlignment.Left);
            lstItems.Columns.Add("Unit Price", 90, HorizontalAlignment.Right);
            lstItems.Columns.Add("M %", 40, HorizontalAlignment.Right);
            lstItems.Columns.Add("Extended Price", 90, HorizontalAlignment.Right);

        }

        private void populateDetails()
        {
            initializeList();
            //add items
            if (transaction.Items != null)
            {
                foreach (Item item in transaction.Items)
                {
                    if (item.ItemClass.Equals(config["Tuition_Fee"]) || item.ItemClass.Equals(config["Subject_Identifier"])) //show identifier in tuition fee group
                    {
                        lstItems.Items.Add(new ListViewItem(
                        new string[] { 
                        item.ItemNo, 
                        item.ItemDescription, Convert.ToString(item.Qty),
                        Convert.ToString(item.Unitprice),
                        Convert.ToString(item.MarkDown),
                        Convert.ToString(item.ExtendedPrice) }
                    , lstItems.Groups["TF"]));
                    }
                    else if (item.ItemClass.Equals(config["Miscellaneous_Fee"])
                        || item.ItemClass.Equals(config["Miscellaneous_Fee_Optional"]))
                    {
                        lstItems.Items.Add(new ListViewItem(
                            new string[] { 
                        item.ItemNo, 
                        item.ItemDescription, Convert.ToString(item.Qty),
                        Convert.ToString(item.Unitprice),
                        Convert.ToString(item.MarkDown),
                        Convert.ToString(item.ExtendedPrice) }
                    , lstItems.Groups["MF"]));
                    }
                    else if (item.ItemClass.Equals(config["Direct_Cost"])
                        || item.ItemClass.Equals(config["Direct_Cost_Optional"]))
                    {
                        lstItems.Items.Add(new ListViewItem(
                            new string[] { 
                        item.ItemNo, 
                        item.ItemDescription, Convert.ToString(item.Qty),
                        Convert.ToString(item.Unitprice),
                        Convert.ToString(item.MarkDown),
                        Convert.ToString(item.ExtendedPrice) }
                    , lstItems.Groups["DC"]));
                    }
                    else //if (item.ItemClass.Equals(config["Additional_Fee"])) 20110426
                    {
                        lstItems.Items.Add(new ListViewItem(
                            new string[] { 
                        item.ItemNo, 
                        item.ItemDescription, Convert.ToString(item.Qty),
                        Convert.ToString(item.Unitprice),
                        Convert.ToString(item.MarkDown),
                        Convert.ToString(item.ExtendedPrice) }
                    , lstItems.Groups["AF"]));
                    }
                }
            }
        }

        private void clearHeader()
        {
            txtAssessmentNo.Clear();

            txtStudentID.Clear();

            txtName.Clear();
            txtLevel.Clear();
            txtCurrencyID.Clear();
            txtBatchID.Clear();
            dtpDocumentDate.Value = DateTime.Now;
            txtSYFrom.Clear();
            txtSYTo.Clear();
            //txtPlan.Clear();

            cboDoctype.Items.Clear();
            cboDoctype.Items.AddRange(Enum.GetNames(typeof(Transaction_Type)));

        }
        private void clearItems()
        {
            lstItems.Items.Clear();
        }
        private void clearTotals()
        {
            txtTuitionFee.Clear();
            txtMiscellaneousFees.Clear();
            txtDirectCosts.Clear();
            txtAdditionalFees.Clear();
            txtSubtotal.Clear();
            txtDiscount.Clear();
            txtNetAmountToPay.Clear();

            if (transaction.TransactionType == Transaction_Type.Assessment)
            {
                btnExpandDiscount.Enabled = true;
                btnExpandNetAmount.Enabled = true;
            }
            else if (transaction.TransactionType == Transaction_Type.Drop)
            {
                btnExpandDiscount.Enabled = false;
                btnExpandNetAmount.Enabled = false;
            }
            else if (transaction.TransactionType == Transaction_Type.Add)
            {
                btnExpandDiscount.Enabled = false;
                btnExpandNetAmount.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (frmChooseForm chooseForm = new frmChooseForm())
            {
                if (chooseForm.ShowDialog() == DialogResult.OK)
                {                    
                    frmReportViewer assessmentReport;
                    
                    if (chooseForm.SelectedAssessmentForm == AssessmentForm.BasicEducation)
                    {
                        assessmentReport = new frmReportViewer("Assessment Report", new rptAssessment()
                        , new KeyValuePair<string, object>("Assessment No", transaction.DocumentNumber)
                        , new KeyValuePair<string, object>("SOP Type", (int)transaction.TransactionType));

                        assessmentReport.Show();
                    }
                    else if (chooseForm.SelectedAssessmentForm == AssessmentForm.College)
                    {
                        assessmentReport = new frmReportViewer("Assessment Report", new rptCollegeAssessment()
                        , new KeyValuePair<string, object>("Assessment No", transaction.DocumentNumber)
                        , new KeyValuePair<string, object>("SOP Type", (int)transaction.TransactionType));

                        assessmentReport.Show();
                    }
                    
                }
            }
            
        }

        private void clear()
        {
            clearHeader();
            clearItems();
            clearTotals();
        }

        private void frmViewAssessment_Load(object sender, EventArgs e)
        {            
            clear();

            populateHeader();
            populateTotals();
            populateDetails();
        }

        private void closeDialogs()
        {
            if (discountDetails != null)
            {
                discountDetails.Close();
                discountDetails.Dispose();
            }
            if (paymentDetails != null)
            {
                paymentDetails.Close();
                paymentDetails.Dispose();
            }
        }

        private void btnExpandNetAmount_Click(object sender, EventArgs e)
        {
            if (paymentDetails == null)
            {
                paymentDetails = new frmViewPaymentDetails(transaction);
            }
            else
            {
                if (paymentDetails.Created == false)
                {
                    paymentDetails = new frmViewPaymentDetails(transaction);
                }
            }

            paymentDetails.MdiParent = this.ParentForm;
            paymentDetails.Show();
            paymentDetails.Activate();
        }

        private void btnExpandDiscount_Click(object sender, EventArgs e)
        {            
            if (discountDetails == null)
            {
                discountDetails = new frmViewDiscountDetails(transaction.AppliedDiscounts);
            }
            else
            {
                if (discountDetails.Created == false)
                {
                    discountDetails = new frmViewDiscountDetails(transaction.AppliedDiscounts);
                }
            }

            discountDetails.MdiParent = this.ParentForm;
            discountDetails.Show();
            discountDetails.Activate();
        }

        private void frmViewAssessment_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeDialogs();
        }

    }
}