using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAssessment.Objects
{    
    public class Transaction
    {
        #region Members
        private Transaction_Type transactionType;
        private int syFrom;
        private int syTo;
        private string term;
        private string documentNumber;
        private string studentID;
        private string studentName;
        private DateTime documentDate;
        //private decimal totalAmountDueOriginating;
        //private decimal totalAmountDueFunctional;
        //private string assessedBy;
        private int totalunits;
        private Items items = new Items();
        private string currencyID;
        private string priceLevel;
        private Plan plan = new Plan();
        private Discounts availableDiscounts = new Discounts();
        private Discounts appliedDiscounts = new Discounts();
        private string batchID;
        private decimal totalAmount = 0.00M;
        private decimal totalTuition = 0.00M;
        private decimal totalMiscellaneousFees = 0.00M;
        private decimal totalDirectCosts = 0.00M;
        private decimal totalAdditionalFees = 0.00M;
        private decimal totalDiscounts = 0.00M;
        private decimal subtotal = 0.00M;
        private Schedule schedule = new Schedule();
        private string gradeLevel = "";
        private string comments = "";
        private decimal installmentFee = 0.00M;
        private decimal reservationFee = 0.00M;
        //private decimal earlyEnrolmentDiscount = 0.00M;
        private DateTime expirationDate;
        #endregion

        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }        

        //public decimal EarlyEnrolmentDiscount
        //{
        //    get { return earlyEnrolmentDiscount; }
        //    set { earlyEnrolmentDiscount = value; }
        //}

        public decimal ReservationFee
        {
            get 
            { 
                return decimal.Round(reservationFee, 2); 
            }
            set
            {
                if (plan.NoOfPayments > 1)
                {
                    if (value < schedule.GetDue(0).Amount && value >= 0)
                    {
                        reservationFee = value;
                    }
                }
                else
                {
                    if (value < (subtotal - totalDiscounts) && value >= 0)
                    {
                        reservationFee = value;
                    }
                }
            }
        }


        public decimal InstallmentFee
        {
            get 
            {
                return decimal.Round(installmentFee, 2); 
            }
            set { installmentFee = value; }
        }
        public void RecomputeInstallmentFee()
        {
            decimal percentage = 0;
            decimal grossTotal = 0;
            decimal instfee = 0;

            if (plan.NoOfPayments > 1)
            {
                percentage = Convert.ToDecimal(plan.InstallmentFeePercentage);
                foreach (Item item in items)
                {
                    grossTotal += item.ExtendedPrice;
                }
            }
            instfee = grossTotal * (percentage / 100);
            installmentFee = instfee;
        }


        public void RecomputeInstallmentFee(string miscFee
            , string miscFeeOptional
            , string directCost
            , string directCostOptional)
        {
            decimal totaldirectcostmiscfees = 0;
            decimal instfee = 0;
            decimal percentage = 0;

            if (plan.NoOfPayments > 1)
            {
                percentage = Convert.ToDecimal(plan.InstallmentFeePercentage);

                foreach (Item item in items)
                {
                    if (
                        item.ItemClass.Equals(miscFee)
                        || item.ItemClass.Equals(miscFeeOptional)
                        || item.ItemClass.Equals(directCost)
                        || item.ItemClass.Equals(directCostOptional))
                    {
                        totaldirectcostmiscfees += item.ExtendedPrice;
                    }
                }
                instfee = totaldirectcostmiscfees * (percentage / 100);
            }

            installmentFee = instfee;
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string GradeLevel
        {
            get { return gradeLevel; }
            set { gradeLevel = value; }
        }

        public Schedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }

        public Plan Plan
        {
            get
            {
                return plan;
            }
            set
            {
                plan = value;
            }
        }

        public decimal Subtotal
        {
            get 
            {
                return decimal.Round(subtotal, 2); 
            }
        }

        public decimal TotalDiscounts
        {
            get
            {
                return decimal.Round(totalDiscounts, 2);
            }
        }

        private void computeTotalDiscounts()
        {
            decimal total = 0;
            if (appliedDiscounts != null)
            {
                //apply discounts 1 by 1
                decimal amountAgainst = subtotal;
                foreach (Discount discount in appliedDiscounts)
                {
                    total += discount.Amount;
                }
            }

            totalDiscounts = total;
        }

        public decimal TotalAdditionalFees
        {
            get
            {
                return decimal.Round(totalAdditionalFees, 2); 
            }
        }

        private void computeAdditionalFees(string additionalFee)
        {
            decimal total = 0;
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item.ItemClass.Equals(additionalFee))
                    {
                        total += item.ExtendedPrice;
                    }
                }
            }
            totalAdditionalFees = total;
        }

        public decimal TotalDirectCosts
        {
            get 
            {
                return decimal.Round(totalDirectCosts, 2); 
            }
        }

        private void computeDirectCosts(string directCost
            , string directCostOptional)
        {
            decimal total = 0;
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item.ItemClass.Equals(directCost)
                        || item.ItemClass.Equals(directCostOptional))
                    {
                        total += item.ExtendedPrice;
                    }
                }
            }
            totalDirectCosts = total;
        }

        public decimal TotalMiscellaneousFees
        {
            get
            {
                return decimal.Round(totalMiscellaneousFees, 2); 
            }
        }

        private void computeMiscellaneousFees(string miscFee
            , string miscFeeOptional)
        {
            decimal total = 0;
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item.ItemClass.Equals(miscFee)
                        || item.ItemClass.Equals(miscFeeOptional))
                    {
                        total += item.ExtendedPrice;
                    }
                }
            }
            totalMiscellaneousFees = total;
        }

        public decimal TotalTuition
        {
            get 
            {
                return decimal.Round(totalTuition, 2); 
            }
        }

        private void computeTuitionFees(string tuitionFee)
        {
            decimal total = 0;
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item.ItemClass.Equals(tuitionFee))
                    {
                        total += item.ExtendedPrice;
                    }
                }
            }
            totalTuition = total;
        }

        public decimal TotalAmount
        {
            get 
            {
                totalAmount = (subtotal - totalDiscounts) + installmentFee;
                return decimal.Round(totalAmount, 2); 
            }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public string BatchID
        {
            get { return batchID; }
            set { batchID = value; }
        }

        public Transaction_Type TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        public string CurrencyID
        {
            get { return currencyID; }
            set { currencyID = value; }
        }


        public string PriceLevel
        {
            get { return priceLevel; }
            set { priceLevel = value; }
        }

        public int SYFrom
        {
            get { return syFrom; }
            set { syFrom = value; }
        }

        public int SYTo
        {
            get { return syTo; }
            set { syTo = value; }
        }

        public string Term
        {
            get { return term; }
            set { term = value; }
        }

        public string DocumentNumber
        {
            get { return documentNumber; }
            set { documentNumber = value; }
        }

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public Items Items
        {
            get { return items; }
            set { items = value; }
        }

        public DateTime DocumentDate
        {
            get { return documentDate; }
            set { documentDate = value; }
        }

        //public decimal TotalAmountDueOriginating
        //{
        //    get { return totalAmountDueOriginating; }
        //    set { totalAmountDueOriginating = value; }
        //}

        //public decimal TotalAmountDueFunctional
        //{
        //    get { return totalAmountDueFunctional; }
        //    set { totalAmountDueFunctional = value; }
        //}

        //public string AssessedBy
        //{
        //    get { return assessedBy; }
        //    set { assessedBy = value; }
        //}

        public int Totalunits
        {
            get { return totalunits; }
            set { totalunits = value; }
        }

        public Discounts AppliedDiscounts
        {
            get { return appliedDiscounts; }
            set { appliedDiscounts = value; }
        }

        public Discounts AvailableDiscounts
        {
            get { return availableDiscounts; }
            set { availableDiscounts = value; }
        }

        private void computeSubTotal()
        {
            decimal total = 0;

            if (items != null)
            {
                foreach (Item item in items)
                {
                    total += item.ExtendedPrice;
                }
            }
            subtotal = total;
        }

        public void RecomputeTotals(string tuitionFee
            , string miscFee
            , string miscFeeOptional
            , string directCost
            , string directCostOptional
            , string additionalFee)
        {
            computeTuitionFees(tuitionFee);
            computeMiscellaneousFees(miscFee
                , miscFeeOptional);
            computeDirectCosts(directCost
                , directCostOptional);
            computeAdditionalFees(additionalFee);
            computeSubTotal();

            recomputeDiscounts();
            computeTotalDiscounts();           
        }

        //change this
        private void recomputeDiscounts()
        {
            //reset discounts
            foreach (Discount d in appliedDiscounts)
            {
                d.Computed = false;
            }
            foreach (Discount d in availableDiscounts)
            {
                d.Computed = false;
            }
            //discounts computation engine
            int ctr = 0;

            while (ctr != appliedDiscounts.Count)
            {
                SameDiscounts sameDiscounts = null;
                sameDiscounts = new SameDiscounts();
                for (int i = 0; i <= appliedDiscounts.Count - 1; i++)
                {
                    if (appliedDiscounts.GetDiscount(i).Computed == false)
                    {
                        //System.Windows.Forms.MessageBox.Show("Individual: "
                        //    + appliedDiscounts.GetDiscount(i).ItemAppliedTo);
                        sameDiscounts.Add(appliedDiscounts.GetDiscount(i));
                    }                    
                }
                ctr += sameDiscounts.Count;

                //System.Windows.Forms.MessageBox.Show("Group: "
                //    + sameDiscounts.AppliedToItem);
                sameDiscounts.SortByPercentage();
                switch (sameDiscounts.AppliedToItem)
                {
                    case Constants.SUBTOTAL:
                        computeDiscountsAgainst(ref sameDiscounts, subtotal);
                        break;
                    case Constants.TUITIONFEES:
                        computeDiscountsAgainst(ref sameDiscounts, totalTuition);
                        break;
                    case Constants.MISCELLANEOUSFEES:
                        computeDiscountsAgainst(ref sameDiscounts, totalMiscellaneousFees);
                        break;
                    case Constants.DIRECTCOSTS:
                        computeDiscountsAgainst(ref sameDiscounts, totalDirectCosts);
                        break;
                    case Constants.ADDITIONALFEES:
                        computeDiscountsAgainst(ref sameDiscounts, totalAdditionalFees);
                        break;

                    default:
                        decimal amountAgainst;
                        if (this.items.GetItem(sameDiscounts.AppliedToItem) != null)
                        {
                            amountAgainst = this.items.GetItem
                            (sameDiscounts.AppliedToItem).ExtendedPrice;
                        }
                        else
                        {
                            amountAgainst = 0;
                        }                        
                        computeDiscountsAgainst(ref sameDiscounts, amountAgainst);
                        break;
                }
            }
        }

        private void computeDiscountsAgainst(ref SameDiscounts sameDiscounts, decimal amountAgainst)
        {
            foreach (Discount discount in sameDiscounts)
            {
                //one by one application

                decimal discountAmount = 0.00M;

                discountAmount = computeDiscountAmount(discount.Percent, amountAgainst);                

                discount.Amount = discountAmount;
                discount.Computed = true;

                amountAgainst -= discountAmount;
            }
        }

        private decimal computeDiscountAmount(decimal percent, decimal againstAmount)
        {
            decimal amount = 0;
            amount = (percent / 100) * againstAmount;
            return decimal.Round(amount, 2);
        }
        /// <summary>
        /// Recompute totals/installment fee first before calculating payment schedule.
        /// </summary>
        public void RecalculatePaymentSchedules()
        {
            Schedule sked = new Schedule();
            decimal netAmount = this.subtotal - this.totalDiscounts;
            decimal totalComputed = 0.00M;
            Due due;
            DateTime instalmentDate = documentDate;

            if (plan.Breakdown != null)
            {
                for (int i = 0; i <= plan.NoOfPayments - 2; i++)
                {
                    due = new Due();
                    due = plan.Breakdown.GetDue(i);

                    //Original
                    //due.Amount = netAmount * (due.Percent / 100);

                    //Edited - 5/4/12
                    due.Amount = (netAmount + installmentFee) * (due.Percent / 100);

                    totalComputed += due.Amount;
                    sked.Add(due);
                }
                due = new Due();
                due = plan.Breakdown.GetDue(plan.Breakdown.Count - 1);
                //Original
                //due.Amount = netAmount - totalComputed;

                //Edited - 5/4/12
                due.Amount = (netAmount + installmentFee) - totalComputed;
                sked.Add(due);                
            }
            else
            {
                for (int i = 0; i <= plan.NoOfPayments - 2; i++)
                {
                    due = new Due();
                    if (i == 0)
                    {
                        instalmentDate = instalmentDate.AddDays(plan.DaysFromFirstPayment);
                    }

                    due.Date = instalmentDate;
                    //Original
                    //due.Amount = netAmount / plan.NoOfPayments;

                    //Edited - 5/4/12
                    due.Amount = (netAmount + installmentFee) / plan.NoOfPayments;

                    totalComputed += due.Amount;
                    sked.Add(due);
                    instalmentDate = instalmentDate.AddDays(plan.Cadence);
                }
                due = new Due();
                due.Date = instalmentDate;
                //Original
                //due.Amount = netAmount - totalComputed;

                //Edited - 5/4/12
                due.Amount = (netAmount + installmentFee) - totalComputed;
                if (plan.NoOfPayments == 1)
                {
                    due.Date = instalmentDate.AddDays(plan.DaysFromFirstPayment);
                }
                sked.Add(due);                
                
            }
            //add installment fee to the first payment
            //Original
            //sked.GetDue(0).Amount += this.installmentFee;

            //Edited - 5/4/12

            this.schedule = sked;
        }
    }
}
