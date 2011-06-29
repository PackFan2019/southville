using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StudentAssessment.Objects
{
    class PercentSortHelper : IComparer
    {
        public int Compare(object x, object y)
        {
            Discount d1 = (Discount)x;
            Discount d2 = (Discount)y;

            return d2.Percent.CompareTo(d1.Percent);
        }
    }

    public class SameDiscounts : Discounts
    {
        private string appliedToItem = "";

        public SameDiscounts()
        {
            appliedToItem = "";
        }

        public string AppliedToItem
        {
            get { return appliedToItem; }
        }        

        public override void Add(Discount discount)
        {
            if (List.Count == 0)
            {
                appliedToItem = discount.ItemAppliedTo;
            }

            if (discount.ItemAppliedTo == appliedToItem)
            {
                base.Add(discount);
            }
        }
    }

    public class Discounts : CollectionBase
    {
        public virtual void Add(Discount discount)
        {            
            List.Add(discount);          
        }

        public void Delete(Discount discount)
        {
            List.Remove(discount);
        }

        public Discount GetDiscount(int index)
        {
            return (Discount)List[index];
        }

        public Discount GetDiscount(string discountID)
        {
            Discount discount = null;
            for (int i = 0; i <= List.Count - 1; i++)
            {
                if (GetDiscount(i).DiscountID == discountID)
                {
                    discount = GetDiscount(i);
                    break;
                }
            }
            return discount;
        }

        public int IndexOf(Discount discount)
        {
            return List.IndexOf(discount);
        }
        /// <summary>
        /// Sorts the discounts by percentage from largest to smallest.
        /// </summary>
        public void SortByPercentage()
        {
            IComparer sorter = new PercentSortHelper();
            InnerList.Sort(sorter);
        }
    }
}
