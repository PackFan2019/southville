using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class Student:IEquatable<Student>
    {
        private String adviser;

        public String Adviser
        {
            get { return adviser; }
            set { adviser = value; }
        }
        private String studentID;

        public String StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private ReportCard rptCard = new ReportCard();

        internal ReportCard RptCard
        {
            get { return rptCard; }
            set { rptCard = value; }
        }

        private String emailAddress;

        public String EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private String level;

        public String Level
        {
            get { return level; }
            set { level = value; }
        }
        private String section;

        public String Section
        {
            get { return section; }
            set { section = value; }
        }
        //private String sY;

        //public String SY
        //{
        //    get { return sY; }
        //    set { sY = value; }
        //}
        //private String t1;

        //public String T1
        //{
        //    get { return t1; }
        //    set { t1 = value; }
        //}
        //private String t2;

        //public String T2
        //{
        //    get { return t2; }
        //    set { t2 = value; }
        //}
        //private String t3;

        //public String T3
        //{
        //    get { return t3; }
        //    set { t3 = value; }
        //}
        public bool Equals(Student s)
        {
            return (this.studentID.Equals(s.studentID));
        }
        //public override string ToString()
        //{
        //    return "Student ID: " + this.StudentID;
        //}
    }
}
