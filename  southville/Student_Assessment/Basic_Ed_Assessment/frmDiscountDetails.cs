using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using StudentAssessment.Objects;
using StudentAssessment.Adapter;
using StudentAssessment.Common;
using log4net;
using System.Reflection;

namespace StudentAssessment
{
    public partial class frmDiscountDetails : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        frmAssessment mainWindow;
        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;
        Transaction transaction;
        Discounts discountsAvailable = new Discounts();
        Discounts discountsApplied = new Discounts();

        string discountID = "";

        bool resetApplication = true;


        public frmDiscountDetails(Transaction transaction, frmAssessment mainWindow)
        {
            InitializeComponent();
            this.transaction = transaction;
            this.mainWindow = mainWindow;

            discountsAvailable = transaction.AvailableDiscounts;
            discountsApplied = transaction.AppliedDiscounts;
            
        }

        private void frmDiscountDetails_Load(object sender, EventArgs e)
        {
            initializeDiscounts();

            clearDiscountsList();

            populateDiscountsList();

            populateItemsToApplyTo();

            populateTotalDiscount();            
        }

        private void populateItemsToApplyTo()
        {
            cboItemsToApplyTo.Items.Clear();

            cboItemsToApplyTo.Items.Add(Constants.SUBTOTAL);
            cboItemsToApplyTo.Items.Add(Constants.TUITIONFEES);
            cboItemsToApplyTo.Items.Add(Constants.MISCELLANEOUSFEES);
            cboItemsToApplyTo.Items.Add(Constants.DIRECTCOSTS);
            cboItemsToApplyTo.Items.Add(Constants.ADDITIONALFEES);

            if (chkValidate.Checked == false)
            {
                foreach (Item item in transaction.Items)
                {
                    cboItemsToApplyTo.Items.Add(item.ItemNo);
                }
            }            

            cboItemsToApplyTo.Text = "";
            cboItemsToApplyTo.Text = Constants.SUBTOTAL;
        }

        private void populateTotalDiscount()
        {            
            txtDiscountTotal.Text = Convert.ToString(transaction.TotalDiscounts);
        }

        private void initializeDiscounts()
        {            
            lstDiscounts.Columns.Clear();
            lstDiscounts.Columns.Add("Discount ID", 70, HorizontalAlignment.Left);
            lstDiscounts.Columns.Add("Description", 140, HorizontalAlignment.Left);
            lstDiscounts.Columns.Add("%", 50, HorizontalAlignment.Right);
            lstDiscounts.Columns.Add("Applied To", 115, HorizontalAlignment.Right);
            lstDiscounts.Columns.Add("Amount", 80, HorizontalAlignment.Right);

        }

        private void clearDiscountsList()
        {
            lstDiscounts.Items.Clear();
        }

        private void populateDiscountsList()
        {            
            lstDiscounts.Items.Clear();
            recomputeTotals();

            //populate applied discounts
            foreach (Discount discount in discountsApplied)
            {
                ListViewItem appliedDiscount = new ListViewItem(
                    new string[] {
                        discount.DiscountID
                        , discount.DiscountDescription
                        , Convert.ToString(discount.Percent)
                        , discount.ItemAppliedTo
                        , Convert.ToString((discount.Amount))}
                        );
                appliedDiscount.BackColor = Color.Honeydew;
                lstDiscounts.Items.Add(appliedDiscount);
            }

            //populate unapplied discounts
            foreach (Discount discount in discountsAvailable)
            {
                ListViewItem unappliedDiscount = new ListViewItem(
                    new string[] {
                        discount.DiscountID
                        , discount.DiscountDescription
                        , Convert.ToString(discount.Percent)
                        , discount.ItemAppliedTo
                        , Convert.ToString((discount.Amount))}
                        );             
                lstDiscounts.Items.Add(unappliedDiscount);
            }


            lstDiscounts.ListViewItemSorter = new ListViewItemComparer(2);
            lstDiscounts.Sort();

            populateTotalDiscount();
        }

        public Discounts GetAppliedDiscounts()
        {            
            return discountsApplied;
        }
        public Discounts GetAvailableDiscounts()
        {
            return discountsAvailable;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstAppliedDiscounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Discount discountSelected;
            if (lstDiscounts.SelectedItems.Count == 1)
            {
                discountID = lstDiscounts.SelectedItems[0].Text;

                discountSelected = discountsAvailable.GetDiscount(discountID);

                //if the discount is unapplied
                if (discountSelected != null)
                {

                    //enable application
                    btnInsert.Enabled = true;
                    cboItemsToApplyTo.Enabled = true;

                    btnRemove.Enabled = false;

                    txtDiscountID.Text = discountSelected.DiscountID;
                    txtPercentage.Text = Convert.ToString(discountSelected.Percent);
                    txtDiscountDescription.Text = discountSelected.DiscountDescription;

                    //if discount is variable make percent editable
                    if (discountSelected.DiscountType == Discount_Type.Variable_Discount)
                    {
                        txtPercentage.ReadOnly = false;
                    }
                    else //if discount is fixed disable edit
                    {
                        txtPercentage.ReadOnly = true;
                    }
                }
                else
                {
                    txtPercentage.ReadOnly = true;
                    btnRemove.Enabled = true;

                    //disable application
                    btnInsert.Enabled = false;
                    cboItemsToApplyTo.Enabled = false;
                }
            }
            else
            {
                txtDiscountID.Clear();
                txtDiscountDescription.Clear();
                txtPercentage.Clear();

                //disable apply/unapply
                btnInsert.Enabled = false;
                btnRemove.Enabled = false;

                disableDiscountApplication();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {            
            Discount discountSelected = discountsAvailable.GetDiscount
                    (discountID);

            //save discount
            try
            {
                discountsAvailable.GetDiscount(txtDiscountID.Text).Percent = Convert.ToDecimal(txtPercentage.Text);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Prompt.ShowError(ex.Message);
            }

            if (chkValidate.Checked == true)
            {
                if (isDiscountValid(discountSelected))
                {
                    if (discountsApplied.Count <= DiscountAdapter.Instance.GetDiscountLimit() - 1)
                    {
                        discountSelected.ItemAppliedTo = cboItemsToApplyTo.Text;
                        //add discount to applied discounts
                        discountsApplied.Add
                            (discountSelected);
                        //remove discount to available discounts
                        discountsAvailable.Delete(discountSelected);
                    }
                    else
                    {
                        Prompt.ShowError("Maximum number of applicable discounts is reached.");
                    }
                }
                else
                {
                    Prompt.ShowError("This discount is not applicable.");
                }
            }
            else
            {
                //if validation is disabled
                discountSelected.ItemAppliedTo = cboItemsToApplyTo.Text;
                //add discount to applied discounts
                discountsApplied.Add
                    (discountSelected);
                //remove discount to available discounts
                discountsAvailable.Delete(discountSelected);
            }

            //repopulate
            populateDiscountsList();

            populateTotalDiscount();

            //clear edit fields
            txtDiscountID.Clear();
            txtDiscountDescription.Clear();
            txtPercentage.Clear();

            txtPercentage.ReadOnly = true;

            btnInsert.Enabled = false;

            //disable application
            disableDiscountApplication();
        }

        private void disableDiscountApplication()
        {
            cboItemsToApplyTo.Enabled = false;
            populateItemsToApplyTo();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Discount discountSelected = discountsApplied.GetDiscount
                (lstDiscounts.SelectedItems[0].Text);

            //return discount to available discounts
            discountsAvailable.Add
                (discountSelected);
            discountsApplied.Delete(discountSelected);

            //unapply discount
            discountsAvailable.GetDiscount
                (discountSelected.DiscountID).ItemAppliedTo = "";
            discountsAvailable.GetDiscount
                (discountSelected.DiscountID).Amount = 0.00M;

            //repopulate
            populateDiscountsList();

            populateTotalDiscount();

            btnRemove.Enabled = false;
        }

        private bool isDiscountValid(Discount discount)
        {
            return DiscountAdapter.Instance.ValidateDiscount
                (transaction.StudentID, discount, transaction.DocumentDate);
        }

        private void recomputeTotals()
        {
            transaction.RecomputeTotals(config["Tuition_Fee"].ToString()
                , config["Miscellaneous_Fee"].ToString()
                , config["Miscellaneous_Fee_Optional"].ToString()
                , config["Direct_Cost"].ToString()
                , config["Direct_Cost_Optional"].ToString()
                , config["Additional_Fee"].ToString());
        }

        private void chkValidate_CheckedChanged(object sender, EventArgs e)
        {
            string password;
            
            if (chkValidate.CheckState == CheckState.Unchecked)
            {
                using (frmEnterPassword dvp = new frmEnterPassword())
                {
                    dvp.Text = "Discount Validation";
                    dvp.ShowDialog();
                    password = dvp.Password;
                }

                if (DiscountAdapter.Instance.CheckDiscountPassword(password))
                {
                    chkValidate.CheckState = CheckState.Unchecked;
                    resetApplication = true;
                }
                else
                {
                    Prompt.ShowError("Invalid password!");
                    chkValidate.CheckState = CheckState.Checked;
                    resetApplication = false;
                }
            }
            else if ((chkValidate.CheckState == CheckState.Checked) && resetApplication)
            {
                resetDiscountApplication();
            }

            populateItemsToApplyTo();
        }

        private void resetDiscountApplication()
        {            
            foreach (Discount d in discountsApplied)
            {
                d.Amount = 0.00M;
                d.ItemAppliedTo = "";
                discountsAvailable.Add(d);
            }

            discountsApplied.Clear();

            populateDiscountsList();
        }
        
        private void frmDiscountDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.UpdateDiscounts(discountsApplied, discountsAvailable);
        }

    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = ((ListViewItem)y).SubItems[col].Text.CompareTo(
            ((ListViewItem)x).SubItems[col].Text);
            return returnVal;
        }
    }
}