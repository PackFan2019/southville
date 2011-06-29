using System;
using System.Collections.Generic;
using System.Text;
using StudentAssessment.Data;
using StudentAssessment.Objects;

namespace StudentAssessment.Adapter
{
    public class DiscountAdapter
    {
        static DiscountAdapter instance;

        public static DiscountAdapter Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new DiscountAdapter();
                }
                return instance; 
            }
        }

        static DiscountAdapter() { }

        public Discounts GetCustomerDiscounts(string customerNo)
        {
            return DiscountData.Instance.GetCustomerDiscounts(customerNo);
        }

        public Discounts GetAssessmentDiscountsByDocID(string assessmentNo, Transaction_Type type)
        {
            return DiscountData.Instance.GetAssessmentDiscountsByDocID(assessmentNo, type);
        }

        public bool ValidateDiscount(string studentID, Discount discount, DateTime date)
        {
            return DiscountData.Instance.ValidateDiscount(studentID, discount, date);
        }

        public bool CheckDiscountPassword(string password)
        {
            return DiscountData.Instance.CheckDiscountPassword(password);
        }

        public int GetDiscountLimit()
        {
            return DiscountData.Instance.GetDiscountLimit();
        }
    }
}
