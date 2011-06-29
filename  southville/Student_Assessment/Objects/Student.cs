using System;
using System.Collections.Generic;
using System.Text;


namespace StudentAssessment.Objects
{
    public class Student
    {
        #region Members
        private string studentID;
        private string fullname;
        private string priceLevel;
        private string status = "";
        private Plan plan = new Plan();
        private Discounts discounts;
        private string currency;
        private bool studentFound = false;
        private string classID;
        private string gradeLevel = "";
        #endregion

        #region Get, Set

        public string GradeLevel
        {
            get { return gradeLevel; }
            set { gradeLevel = value; }
        }

        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }
        public string ClassID
        {
            get { return classID; }
            set { classID = value; }
        }
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public string PriceLevel
        {
            get { return priceLevel; }
            set { priceLevel = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

 
        public Discounts Discounts
        {
            get { return discounts; }
            set { discounts = value; }
        }
        public bool StudentFound
        {
            get { return studentFound; }
            set { studentFound = value; }
        }
        #endregion        

        public Student(string studentID, string fullname
            , string pricelevel, string classid
            , string currency, string gradeLevel, string status)
        {
            this.studentID = studentID;
            this.fullname = fullname;
            this.priceLevel = pricelevel;
            this.classID = classid;
            this.currency = currency;
            this.gradeLevel = gradeLevel;
            this.status = status;
        }

        public Student() { }

        
    }
}
