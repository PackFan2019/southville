using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class Student:IEquatable<Student>
    {
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
        private ReportCard rptCard;

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

        public bool Equals(Student s)
        {
            return (this.studentID.Equals(s.studentID));
        }
    }
}
