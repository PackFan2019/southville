using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Objects;

namespace StudentAssessment
{
    public partial class frmViewDiscountDetails : Form
    {
        Discounts discounts = new Discounts();

        public frmViewDiscountDetails(Discounts discounts)
        {
            InitializeComponent();
            this.discounts = discounts;
        }

        private void initializeDiscountsList()
        {
            lstDiscounts.Columns.Clear();
            lstDiscounts.Columns.Add("Discount ID", 70, HorizontalAlignment.Left);
            lstDiscounts.Columns.Add("Description", 140, HorizontalAlignment.Left);
            lstDiscounts.Columns.Add("%", 50, HorizontalAlignment.Right);
            lstDiscounts.Columns.Add("Applied To", 115, HorizontalAlignment.Left);
            lstDiscounts.Columns.Add("Amount", 80, HorizontalAlignment.Right);

        }

        private void clearDiscountsList()
        {
            lstDiscounts.Items.Clear();
        }

        private void populateDiscountsList()
        {
            foreach (Discount discount in discounts)
            {
                lstDiscounts.Items.Add(new ListViewItem(
                    new string[] {
                        discount.DiscountID
                        , discount.DiscountDescription
                        , Convert.ToString(discount.Percent)
                        , discount.ItemAppliedTo
                        , Convert.ToString((discount.Amount))}
                        ));
            }
        }

        private void populateTotalDiscount()
        {
            decimal totalDiscounts = 0.00M;

            foreach (Discount d in discounts)
            {
                totalDiscounts += d.Amount;
            }

            txtDiscountTotal.Text = Convert.ToString(totalDiscounts);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewDiscountDetails_Load(object sender, EventArgs e)
        {
            clearDiscountsList();
            initializeDiscountsList();
            populateDiscountsList();
            populateTotalDiscount();
        }
    }
}