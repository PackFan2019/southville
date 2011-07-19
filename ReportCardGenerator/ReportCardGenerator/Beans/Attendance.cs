using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class Attendance
    {
        private double daysLate;

        public double DaysLate
        {
            get { return daysLate; }
            set { daysLate = value; }
        }
        private double daysTardy;

        public double DaysTardy
        {
            get { return daysTardy; }
            set { daysTardy = value; }
        }
        private double daysAbsent;

        public double DaysAbsent
        {
            get { return daysAbsent; }
            set { daysAbsent = value; }
        }

        private double daysPresent;

        public double DaysPresent
        {
            get { return daysPresent; }
            set { daysPresent = value; }
        }
        //public override string ToString()
        //{
        //    return "Attendance: " + this.DaysPresent + " " + this.DaysTardy;
        //}
    }
}
