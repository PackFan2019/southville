using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAssessment.Objects
{
    public class Plan
    {        
        string planID = "";
        string description = "";
        int noOfPayments = 1;
        int daysFromFirstPayment;
        int cadence;
        decimal installmentFeePercentage;

        Schedule breakdown = null;

        public Schedule Breakdown
        {
            get { return breakdown; }
            set { breakdown = value; }
        }

        public decimal InstallmentFeePercentage
        {
            get { return decimal.Round(installmentFeePercentage, 2); }
            set { installmentFeePercentage = value; }
        }

        public int Cadence
        {
            get { return cadence; }
            set { cadence = value; }
        }

        public int DaysFromFirstPayment
        {
            get { return daysFromFirstPayment; }
            set { daysFromFirstPayment = value; }
        }

        public int NoOfPayments
        {
            get { return noOfPayments; }
            set { noOfPayments = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string PlanID
        {
            get { return planID; }
            set { planID = value; }
        }

        
    }
}
