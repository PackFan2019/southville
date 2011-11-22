using System;
using System.Windows.Forms;
using StudentAssessment.Objects;
using StudentAssessment.Common;
using StudentAssessment.Adapter;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Configuration;
using log4net;
using System.Reflection;
using StudentAssessment.Reports;

namespace StudentAssessment
{
    public partial class frmAssessment : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        

        frmDiscountDetails discountDetails = null;
        frmPaymentDetails paymentDetails = null;        

        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;
        Student student;
        Transaction transaction;
        string studentID = "";
        string documentID = "";

        public frmAssessment()
        {
            InitializeComponent();
            
        }

        private void frmAssessment_Load(object sender, EventArgs e)
        {
            clearHeader();
            clearItems();
            clearTotals();
            initializeList();
        }

        private void assess()
        {
            //Header
            student = StudentAdapter.Instance.GetStudent(studentID);
            if (student.StudentFound)
            {
                btnAddItem.Enabled = true;
                cboPlan.Enabled = true;
                //populateHeader();

                //assessment
                transaction.StudentID = student.StudentID;
                transaction.StudentName = student.Fullname;
                if (student.Currency.Trim().Length > 0)
                {
                    transaction.CurrencyID = student.Currency;
                }
                else
                {
                    transaction.CurrencyID = config["Default_Currency"].ToString(); //added 20110426 use default currency in config if customer has no currency specified
                }
                
                transaction.GradeLevel = student.GradeLevel;

                populateHeader(); //moved 20110426 display default currency

                if (transaction.TransactionType == Transaction_Type.Assessment)
                {
                    if (student.Plan.PlanID.Length > 0)
                    {
                        transaction.Plan = student.Plan;
                    }
                    else //if customer has no plan
                    {
                        transaction.Plan =
                            PlanAdapter.Instance.GetPlan(config["Default_Plan"].ToString());
                    }
                } //20100524
                else
                {
                    transaction.Plan = PlanAdapter.Instance.GetPlan(config["Default_Plan"].ToString());

                    cboPlan.Enabled = false; //20100527
                } //20100519
                cboPlan.Text = transaction.Plan.PlanID;

                transaction.PriceLevel = config["Default_Price_Level"].ToString();

                transaction.DocumentDate = dtpDocumentDate.Value;

                //retrieve customer discounts
                //20100512
                if (transaction.TransactionType == Transaction_Type.Assessment)
                {
                    if (chkDiscountEnabled.Checked == true)
                    {
                        transaction.AppliedDiscounts = new Discounts();
                        transaction.AvailableDiscounts =
                            DiscountAdapter.Instance.GetCustomerDiscounts
                            (transaction.StudentID);

                        transaction.AvailableDiscounts.SortByPercentage();
                    }
                    else if (chkDiscountEnabled.Checked == false)
                    {
                        transaction.AvailableDiscounts = new Discounts();
                        transaction.AppliedDiscounts = new Discounts();
                    }                    
                }               

                
                //Details
                populateDetails();
                //Totals
                populateTotals();
            }

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
            lstItems.Columns.Add("Qty", 30, HorizontalAlignment.Right);
            lstItems.Columns.Add("Unit Price", 90, HorizontalAlignment.Right);
            lstItems.Columns.Add("M %", 40, HorizontalAlignment.Right);
            lstItems.Columns.Add("Extended Price", 90, HorizontalAlignment.Right);
        }

        private void populateTotals()
        {
            //recompute totals
            transaction.RecomputeTotals(config["Tuition_Fee"].ToString()
                , config["Miscellaneous_Fee"].ToString()
                , config["Miscellaneous_Fee_Optional"].ToString()
                , config["Direct_Cost"].ToString()
                , config["Direct_Cost_Optional"].ToString()
                , config["Additional_Fee"].ToString());

            /*
             *  Code to compute Installment fee based on Miscellaneous and Direct Cost
            transaction.RecomputeInstallmentFee(config["Miscellaneous_Fee"].ToString()
                , config["Miscellaneous_Fee_Optional"].ToString()
                , config["Direct_Cost"].ToString()
                , config["Direct_Cost_Optional"].ToString());
            */

            //Recompute Gross Amount for Installment Fee
            transaction.RecomputeInstallmentFee();

            txtTuitionFee.Text = Convert.ToString(transaction.TotalTuition);
            txtMiscellaneousFees.Text = Convert.ToString(transaction.TotalMiscellaneousFees);
            txtDirectCosts.Text = Convert.ToString(transaction.TotalDirectCosts);
            txtAdditionalFees.Text = Convert.ToString(transaction.TotalAdditionalFees);

            txtSubtotal.Text = Convert.ToString(transaction.Subtotal);
            txtDiscount.Text = Convert.ToString(transaction.TotalDiscounts);


            if (transaction.TransactionType == Transaction_Type.Assessment)
            {
                btnExpandDiscount.Enabled = true;
                btnExpandNetAmount.Enabled = true;

                txtReservationFee.Enabled = true;
                btnSaveReservationFee.Enabled = true;

                chkDiscountEnabled.Enabled = true;
            }
            else
            {
                transaction.Plan = PlanAdapter.Instance.GetPlan(config["Default_Plan"].ToString());

                btnExpandDiscount.Enabled = false;
                btnExpandNetAmount.Enabled = false;

                txtReservationFee.Enabled = false;
                btnSaveReservationFee.Enabled = false;

                //chkDiscountEnabled.Enabled = false;
            }

            //get plan breakdown
            transaction.Plan.Breakdown =
                PlanAdapter.Instance.GetPlanSchedule(transaction.Plan.PlanID);
            transaction.RecalculatePaymentSchedules();

            txtInstallmentFee.Text = Convert.ToString(transaction.InstallmentFee);
            txtNetAmountToPay.Text = Convert.ToString(transaction.TotalAmount);
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
                        Convert.ToString(item.ExtendedPrice)
                        }
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
                    else //if (item.ItemClass.Equals(config["Additional_Fee"])) 20110420 put all other items in additional fee group
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

        private void populateHeader()
        {
                //Disable fields            
                txtStudentID.Enabled = false;
                btnStudentIDLookup.Enabled = false;

                btnAddItem.Enabled = true; //20100513
                //populate fields
                txtName.Text = transaction.StudentName;     //get info from transaction
                txtCurrencyID.Text = transaction.CurrencyID;
                txtLevel.Text = student.GradeLevel;
                txtSYFrom.Text = Convert.ToString(transaction.SYFrom);
                txtSYTo.Text = Convert.ToString(transaction.SYTo);

                btnClearAll.Enabled = true; //20100531

                loadTemplates();
        }

        private void loadTemplates()
        {
            cboTemplate.Enabled = true;

            cboTemplate.Items.Clear();

            string[] templates = ItemAdapter.Instance.GetTemplates();

            foreach (string template in templates)
            {
                cboTemplate.Items.Add(template);
            }
        }

        private void btnStudentIDLookup_Click(object sender, EventArgs e)
        {
            if (txtAssessmentNo.Text.Trim().Length > 0)
            {
                using (frmStudentLookup studentLookup = new frmStudentLookup(txtStudentID.Text))
                {
                    studentLookup.ShowDialog();

                    studentID = studentLookup.GetCustomerNumber();
                }                

                txtStudentID.Text = studentID;

                assess();
            }
            else
            {
                Prompt.ShowError("Please enter a document number.");
                txtAssessmentNo.Focus();
            }
        }

        private void clearHeader()
        {
            cboDoctype.Enabled = true;

            txtAssessmentNo.Clear();
            txtAssessmentNo.Enabled = true;

            txtStudentID.Clear();
            txtStudentID.Enabled = true;
            btnStudentIDLookup.Enabled = true;

            txtName.Clear();
            txtLevel.Clear();
            resetcboStatus();
            resetcboDoctype();
            cboPlan.Enabled = false;
            resetcboPlan();
            txtCurrencyID.Clear();
            //txtBatchID.Clear();
            dtpDocumentDate.Value = DateTime.Now;
            txtSYFrom.Clear();
            txtSYTo.Clear();
            cboPlan.Text = "";
            txtRemarks.Clear();

            btnAddItem.Enabled = false;
            btnDeleteItem.Enabled = false;            

            txtItemNo.Clear();
            txtItemDescription.Clear();
            txtQty.Clear();
            txtUnitPrice.Clear();
            txtMarkdown.Clear();
            btnSaveItem.Enabled = false;

            cboTemplate.Items.Clear();
            cboTemplate.Enabled = false;

            btnClearAll.Enabled = false;
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
            txtInstallmentFee.Clear();
            txtNetAmountToPay.Clear();

            btnExpandDiscount.Enabled = false;
            btnExpandNetAmount.Enabled = false;

            txtReservationFee.Enabled = false;
            txtReservationFee.Clear();
            btnSaveReservationFee.Enabled = false;

            chkDiscountEnabled.Enabled = false;
        }

        private void resetcboStatus()
        {
            cboStatus.Items.Clear();
        }

        private void resetcboPlan()
        {
            Plans plans = PlanAdapter.Instance.GetPlans();

            cboPlan.Items.Clear();

            foreach (Plan plan in plans)
            {
                cboPlan.Items.Add(plan.PlanID);
            }
        }

        private void resetcboDoctype()
        {
            cboDoctype.Items.Clear();
            cboDoctype.Items.AddRange(Enum.GetNames(typeof(Transaction_Type)));
            
            cboDoctype.Text = Enum.GetName(typeof(Transaction_Type), Transaction_Type.Assessment);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!WindowOpen(discountDetails) && !WindowOpen(paymentDetails))
            {
                clearHeader();
                clearItems();
                clearTotals();

                tryRollback();
            }            
        }

        private void tryRollback()
        {
            if (transaction != null)
            {
                TransactionAdapter.Instance.RollbackDocumentNumber(transaction.DocumentNumber
                    , transaction.TransactionType, documentID);
                transaction = null;
            }  
        }

        private void txtAssessmentNo_Enter(object sender, EventArgs e)
        {
            try
            {
                Transaction_Type doctype = Transaction_Type.Assessment;

                tryRollback();

                if (cboDoctype.Text.Equals(Enum.GetName(typeof(Transaction_Type), Transaction_Type.Assessment)))
                {
                    doctype = Transaction_Type.Assessment;
                    documentID = config["Document_ID"].ToString();                        
                }
                else if (cboDoctype.Text.Equals(Enum.GetName(typeof(Transaction_Type), Transaction_Type.Drop)))
                {
                    documentID = config["Document_ID_Return"].ToString();
                    doctype = Transaction_Type.Drop;
                }
                else if (cboDoctype.Text.Equals(Enum.GetName(typeof(Transaction_Type), Transaction_Type.Add)))
                {
                    documentID = config["Document_ID_Invoice"].ToString();
                    doctype = Transaction_Type.Add;
                }

                transaction = TransactionAdapter.Instance.CreateTransaction(doctype, documentID);

                txtAssessmentNo.Text = transaction.DocumentNumber;
                transaction.TransactionType = doctype;

                cboDoctype.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Prompt.ShowError(ex.Message);
            }
        }


        private void txtAssessmentNo_Leave(object sender, EventArgs e)
        {
            if (txtAssessmentNo.Text.Trim().Length > 0)
            {
                txtAssessmentNo.Enabled = false;
                //btnAddItem.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //check detail windows
            if (!WindowOpen(discountDetails) && !WindowOpen(paymentDetails))            
            {
                if (Required())
                {
                    try
                    {
                        transaction.DocumentNumber = txtAssessmentNo.Text;
                        if (transaction.TransactionType == Transaction_Type.Assessment)
                        {
                            transaction.ExpirationDate = transaction.DocumentDate.AddDays(Convert.ToInt32(config["Quote_Expiration"]));
                        }
                        transaction.StudentID = txtStudentID.Text;
                        transaction.StudentName = txtName.Text;
                        transaction.BatchID = txtBatchID.Text;
                        transaction.DocumentDate = dtpDocumentDate.Value;
                        transaction.CurrencyID = txtCurrencyID.Text;
                        transaction.Comments = txtRemarks.Text;

                        TransactionAdapter.Instance.SaveTransaction(transaction
                            , documentID
                            , config["Default_Site_ID"].ToString());

                        //addedd 20101006 - clear first before printing the report
                        clearHeader();
                        clearItems();
                        clearTotals();

                        using (frmChooseForm chooseForm = new frmChooseForm())
                        {
                            if (chooseForm.ShowDialog() == DialogResult.OK)
                            {
                                //TODO: add code to choose report to show

                                frmReportViewer assessmentReport;

                                if (chooseForm.SelectedAssessmentForm == AssessmentForm.BasicEducation)
                                {
                                    assessmentReport = new frmReportViewer("Assessment Report", new rptAssessment()
                                    , new KeyValuePair<string, object>("Assessment No", transaction.DocumentNumber)
                                    , new KeyValuePair<string, object>("SOP Type", (int)transaction.TransactionType));

                                    assessmentReport.Show();
                                }
                                else if(chooseForm.SelectedAssessmentForm == AssessmentForm.College)
                                {
                                    assessmentReport = new frmReportViewer("Assessment Report", new rptCollegeAssessment()
                                    , new KeyValuePair<string, object>("Assessment No", transaction.DocumentNumber)
                                    , new KeyValuePair<string, object>("SOP Type", (int)transaction.TransactionType));

                                    assessmentReport.Show();
                                }                                
                            }                            
                        }

                        //show assessment report
                        //frmReportViewer assessmentReport = new frmReportViewer();//transaction.DocumentNumber, (int)transaction.TransactionType);                        
                        
                        transaction = null;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        Prompt.ShowError(ex.Message);
                    }
                }                
            }            
        }

        private bool Required() //put simple validations here
        {
            bool result = true;

            if (txtAssessmentNo.Text.Trim().Length == 0)
            {
                Prompt.ShowError("Please enter a Document No."); 
                result = false;
            }
            else if (txtStudentID.Text.Trim().Length == 0)
            {
                Prompt.ShowError("Please enter a Student ID."); 
                result = false;
            }
            else if (txtName.Text.Trim().Length == 0)
            {
                Prompt.ShowError("Please enter a Student Name."); 
                result = false;
            }
            else if (txtCurrencyID.Text.Trim().Length == 0)
            {
                Prompt.ShowError("Please enter a Currency ID."); 
                result = false;
            }
            else if (txtBatchID.Text.Trim().Length == 0)
            {
                Prompt.ShowError("Please enter a Batch ID.");
                result = false;
            }
            return result;
        }

        private void txtStudentID_Leave(object sender, EventArgs e)
        {
            studentID = txtStudentID.Text;
            assess();
        }

        private void frmAssessment_FormClosed(object sender, FormClosedEventArgs e)
        {
            tryRollback();           
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtAssessmentNo.Text.Trim().Length > 0)
            {
                using (frmItemLookup itemLookup = new frmItemLookup(transaction.PriceLevel, transaction.CurrencyID))
                {
                    itemLookup.ShowDialog();
                    if (itemLookup.GetItemNumber().Length > 0)
                    {
                        Item item = ItemAdapter.Instance.GetItem(transaction.PriceLevel, transaction.CurrencyID, itemLookup.GetItemNumber(), config["Default_U_of_M"].ToString());
                        if (item != null)
                            if (item.ItemType == ItemType.Service)
                                addItem(item);
                            else
                                if (item.ItemType == ItemType.Kit)
                                    foreach (Item component in getKitComponents(item))
                                        addItem(component);
                    }
                }

                populateDetails();
                populateTotals();

                btnDeleteItem.Enabled = false;
            }
            else
            {
                Prompt.ShowError("Please enter a document number.");
                txtAssessmentNo.Focus();
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count == 1)
            {
                btnDeleteItem.Enabled = true;
                btnSaveItem.Enabled = true;

                //for editing

                string itemNo = lstItems.SelectedItems[0].Text;

                if (transaction.Items.GetItem(itemNo) != null)
                {
                    txtItemNo.Text = transaction.Items.GetItem(itemNo).ItemNo;
                    txtItemDescription.Text = transaction.Items.GetItem(itemNo).ItemDescription;
                    txtQty.Text = Convert.ToString(transaction.Items.GetItem(itemNo).Qty);
                    txtUnitPrice.Text = Convert.ToString(transaction.Items.GetItem(itemNo).Unitprice);
                    txtMarkdown.Text = Convert.ToString(transaction.Items.GetItem(itemNo).MarkDown);
                }
            }
            else
            {
                btnDeleteItem.Enabled = false;
                btnSaveItem.Enabled = false;

                txtItemNo.Clear();
                txtItemDescription.Clear();
                txtQty.Clear();
                txtUnitPrice.Clear();
                txtMarkdown.Clear();
            }
        }
        //TODO: don't allow a mandatory item to be deleted/edited
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            bool deleteItem = false;
            string itemNo = lstItems.SelectedItems[0].Text;

            if (!transaction.Items.GetItem(itemNo).ItemClass.Equals(config["Miscellaneous_Fee"])
            && !transaction.Items.GetItem(itemNo).ItemClass.Equals(config["Direct_Cost"])
            && !transaction.Items.GetItem(itemNo).ItemNo.StartsWith(config["Unit_Item_Prefix"]))
            {
                deleteItem = true;
            }
            else
            {
                Prompt.ShowError("You cannot delete this item.");
            }

            if (deleteItem)
            {
                string kitItemNumber = transaction.Items.GetItem(itemNo).ComponentOf;
                if (kitItemNumber != "")
                {
                    using (frmDeleteKit deleteKit = new frmDeleteKit(kitItemNumber))
                    {
                        deleteKit.ShowDialog();

                        if (deleteKit.Response == DeleteKitDialogResult.DeleteComponent)
                        {
                            transaction.Items.Delete(transaction.Items.GetItem(itemNo));
                        }
                        else if (deleteKit.Response == DeleteKitDialogResult.DeleteAll)
                        {
                            Items kitItems = new Items();
                            kitItems = ItemAdapter.Instance.GetKitComponents(kitItemNumber);

                            for (int j = transaction.Items.Count - 1; j >= 0; j--)
                            {
                                Item tempItem = null, trxItem = null;
                                trxItem = transaction.Items.GetItem(j);
                                tempItem = kitItems.GetItem(trxItem.ItemNo);

                                if (tempItem != null) //trx line item exists in kit components
                                {
                                    if (trxItem.Qty > tempItem.Qty)
                                    {
                                        transaction.Items.GetItem(j).Qty = trxItem.Qty - tempItem.Qty;
                                    }
                                    else if (trxItem.Qty < tempItem.Qty)
                                    {
                                        transaction.Items.Delete(transaction.Items.GetItem(j));
                                        log.Error(String.Format
                                            ("{0} {1} Qty of item is less than the Qty being deleted."
                                            , transaction.DocumentNumber, trxItem.ItemNo));
                                    }
                                    else if (trxItem.Qty == tempItem.Qty)
                                    {
                                        transaction.Items.Delete(transaction.Items.GetItem(j));
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    transaction.Items.Delete(transaction.Items.GetItem(itemNo));
                }
            }

            populateDetails();
            populateTotals();

            txtItemNo.Clear();
            txtItemDescription.Clear();
            txtQty.Clear();
            txtUnitPrice.Clear();
            txtMarkdown.Clear();
            btnSaveItem.Enabled = false;
            btnDeleteItem.Enabled = false;
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            string markdownPassword = "";
            if (!transaction.Items.GetItem(txtItemNo.Text).ItemClass.Equals(config["Miscellaneous_Fee"])
                    && !transaction.Items.GetItem(txtItemNo.Text).ItemClass.Equals(config["Direct_Cost"]))
            {
                try
                {
                    transaction.Items.GetItem(txtItemNo.Text).ItemDescription = txtItemDescription.Text;
                    transaction.Items.GetItem(txtItemNo.Text).Qty = Convert.ToDecimal(txtQty.Text);

                    if (transaction.Items.GetItem(txtItemNo.Text).MarkDown != Convert.ToDecimal(txtMarkdown.Text))
                    {
                        using (frmEnterPassword mvp = new frmEnterPassword())
                        {
                            mvp.Text = "Edit Markdown";
                            mvp.ShowDialog();
                            markdownPassword = mvp.Password;
                        } //prompt for password

                        if (ItemAdapter.Instance.CheckMarkdownPassword(markdownPassword))
                        {
                            transaction.Items.GetItem(txtItemNo.Text).MarkDown = Convert.ToDecimal(txtMarkdown.Text);
                        }
                        else
                        {
                            Prompt.ShowError("Invalid password! You are not allowed to apply a markdown.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Prompt.ShowError(ex.Message);
                }
            }
            else
            {
                Prompt.ShowError("You cannot edit a mandatory item.");
            }            

            populateDetails();
            populateTotals();

            txtItemNo.Clear();
            txtItemDescription.Clear();
            txtQty.Clear();
            txtUnitPrice.Clear();
            txtMarkdown.Clear();

            btnSaveItem.Enabled = false;
            btnDeleteItem.Enabled = false;
        }

        private void btnExpandDiscount_Click(object sender, EventArgs e)
        {
            if (discountDetails == null)
            {
                discountDetails = new frmDiscountDetails(transaction, this);
            }
            else
            {
                if (discountDetails.Created == false)
                {
                    discountDetails = new frmDiscountDetails(transaction, this);
                }
            }
            
            discountDetails.MdiParent = this.ParentForm;
            discountDetails.Show();
            discountDetails.Activate();
        }

        

        private void btnExpandNetAmount_Click(object sender, EventArgs e)
        {
            //for viewing only
            transaction.DocumentDate = dtpDocumentDate.Value;
            //if plan is specified
            if (cboPlan.Text.Length > 0)
            {
                transaction.Plan = PlanAdapter.Instance.GetPlan(cboPlan.Text);
                //get plan breakdown
                transaction.Plan.Breakdown =
                    PlanAdapter.Instance.GetPlanSchedule(transaction.Plan.PlanID);
            }

            if (paymentDetails == null)
            {
                paymentDetails = new frmPaymentDetails(transaction, this);
            }
            else
            {
                if (paymentDetails.Created == false)
                {
                    paymentDetails = new frmPaymentDetails(transaction, this);
                }
            }
            cboPlan.Enabled = false;
            paymentDetails.MdiParent = this.ParentForm;
            paymentDetails.Show();
            paymentDetails.Activate();
        }

        public void UpdatePaymentSchedule(Schedule sked)
        {
            transaction.Schedule = sked;
            cboPlan.Enabled = true;
        }

        public void UpdateDiscounts(Discounts appliedDiscounts, Discounts availableDiscounts)
        {
            transaction.AppliedDiscounts = appliedDiscounts;
            transaction.AvailableDiscounts = availableDiscounts;
            populateTotals();
        }

        private void dtpDocumentDate_ValueChanged(object sender, EventArgs e)
        {
            if (transaction != null)
            {
                transaction.DocumentDate = dtpDocumentDate.Value;

                if (transaction.TransactionType == Transaction_Type.Assessment)
                {
                    transaction.ExpirationDate = transaction.DocumentDate.AddDays(Convert.ToInt32(config["Quote_Expiration"]));                    
                }
            }            
        }

        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {            
            transaction.DocumentDate = dtpDocumentDate.Value;
            //if plan is indicated
            if (cboPlan.Text.Length > 0)
            {
                transaction.Plan = PlanAdapter.Instance.GetPlan(cboPlan.Text);
            }
            else
            {
                transaction.Plan = new Plan();
            }

            //repopulate totals
            populateTotals();

            
        }

        private void cboDoctype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDoctype.Text.Equals(Enum.GetName(typeof(Transaction_Type), Transaction_Type.Assessment)))
            {
                cboPlan.Enabled = true;
            }
            else
            {
                cboPlan.Enabled = false;
            }
        }

        private void btnSaveReservationFee_Click(object sender, EventArgs e)
        {
            try
            {
                transaction.ReservationFee = Convert.ToDecimal(txtReservationFee.Text);                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Prompt.ShowError(ex.Message);
                //transaction.ReservationFee = 0;
            }
            txtReservationFee.Text = Convert.ToString(transaction.ReservationFee);
        }

        private void chkDiscountEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //if (transaction.TransactionType == Transaction_Type.Assessment)
            //{
                if (chkDiscountEnabled.Checked == true)
                {
                    transaction.AppliedDiscounts = new Discounts();
                    transaction.AvailableDiscounts =
                        DiscountAdapter.Instance.GetCustomerDiscounts
                        (transaction.StudentID);
                }
                else if (chkDiscountEnabled.Checked == false)
                {
                    transaction.AvailableDiscounts = new Discounts();
                    transaction.AppliedDiscounts = new Discounts();
                }     
            //}
            populateTotals();
        }

        private Items getKitComponents(Item itemKit)
        {
            Items items = new Items();
            Items pricedItems = new Items();

            if (transaction != null)
            {
                if (itemKit.ItemType == ItemType.Kit)
                {
                    items = ItemAdapter.Instance.GetKitComponents(itemKit.ItemNo);

                    foreach (Item item in items)
                    {
                        Item pricedItem;
                        pricedItem = ItemAdapter.Instance.GetItem
                            (transaction.PriceLevel, transaction.CurrencyID
                            , item.ItemNo, item.Uofm);

                        if (pricedItem != null)
                        {
                            //set qty equals qty of the component 
                            //in the kit multiplied by the qty of the kit
                            pricedItem.Qty = item.Qty * itemKit.Qty;
                            pricedItem.ComponentOf = itemKit.ItemNo;
                            pricedItems.Add(pricedItem);
                        }
                    }
                }                                
            }
            return pricedItems;
        }

        private void addItem(Item item)
        {
            if (transaction != null)
            {
                if (transaction.Items != null)
                {
                    if (transaction.TransactionType == Transaction_Type.Drop)
                    {
                        item.MarkDown = 100 - Convert.ToDecimal(config["Percent_To_Refund"].ToString());
                    }
                    transaction.Items.Add(item);
                }
            }
        }

        private void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTemplate.SelectedIndex != -1)
            {
                foreach (Item item in ItemAdapter.Instance
                    .GetTemplateItems(cboTemplate.Text, transaction.PriceLevel
                    , transaction.CurrencyID, config["Default_U_of_M"].ToString()))
                {
                    if (item != null)
                    {
                        if (item.ItemType == ItemType.Service)
                        {
                            addItem(item);
                        }
                        else if (item.ItemType == ItemType.Kit)
                        {
                            foreach (Item component in getKitComponents(item))
                            {
                                addItem(component);
                            }
                        }
                    }                    
                }                           
            }

            loadTemplates();

            populateDetails();
            populateTotals();

            btnAddItem.Focus();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (transaction.Items.Count > 0)
            {
                transaction.Items.Clear();

                txtItemNo.Clear();
                txtItemDescription.Clear();
                txtQty.Clear();
                txtUnitPrice.Clear();
                txtMarkdown.Clear();
                btnSaveItem.Enabled = false;
                btnDeleteItem.Enabled = false;

                populateDetails();
                populateTotals();
            }
        }

        private bool WindowOpen(Form form)
        {
            if (form != null && form.Created)
            {
                Prompt.ShowError("Please close the " + form.Text + " window.");
                form.Activate();
            }

            return (form != null && form.Created);
        }

        private void frmAssessment_FormClosing(object sender, FormClosingEventArgs e)
        {
            //added 20101006 - check detail windows
            if (!WindowOpen(discountDetails) && !WindowOpen(paymentDetails))
            {
                if (transaction != null)
                {
                    if (Prompt.Confirm(transaction.DocumentNumber +
                        " is modified. Discard changes?")
                    == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
            
        }
    }
}