using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StudentAssessment.Objects
{
    public class Discount
    {
        private Discount_Type discountType = Discount_Type.Fixed_Discount;
        private string discountID;
        private string discountDescription;
        private decimal percent = 0.00M;
        private decimal amount = 0.00M;
        private string itemAppliedTo = "";
        private bool computed = false;

        public bool Computed
        {
            get { return computed; }
            set { computed = value; }
        }


        public string ItemAppliedTo
        {
            get { return itemAppliedTo; }
            set { itemAppliedTo = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Discount_Type DiscountType
        {
            get { return discountType; }
            set { discountType = value; }
        }

        public  string DiscountID
        {
            get { return discountID; }
            set { discountID = value; }
        }
        
        public string DiscountDescription
        {
            get { return discountDescription; }
            set { discountDescription = value; }
        }

        public decimal Percent
        {
            get { return percent; }
            set 
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception
                        ("Discount percentage cannot be greater "
                        + "\nthan 100 or less than 0.");
                }
                percent = value;
            }
        }
    }
}
