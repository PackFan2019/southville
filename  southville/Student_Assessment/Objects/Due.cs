using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAssessment.Objects
{
    public class Due
    {
        DateTime date;
        decimal amount = 0.00M;
        decimal percent = 0.00M;

        public decimal Percent
        {
            get 
            {
                return decimal.Round(percent, 2);
            }
            set { percent = value; }
        }

        public Due()
        {
            amount = 0.00M;
            percent = 0.00M;
        }

        public DateTime Date
        {
            get 
            {
                return date; 
            }
            set { date = value; }
        }

        public decimal Amount
        {
            get 
            { 
                return decimal.Round(amount, 2); 
            }
            set { amount = value; }
        }
    }
}
