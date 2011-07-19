using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Southville.GP.Data;

namespace Southville.GP.Beans
{
    public class Customer:IComparable
    {
        public int CompareTo(Object o)
        {
            if (o is Customer) 
            {
                Customer c = (Customer) o;
                return (this.CompareTo(c.customerID));
            }
            return -1;
        }
        private String customerID = "default";
        public String CustomerID
        {
            get { return customerID; }
            set { customerID = value.ToUpper(); }
        }
        private String customerName = "none";
        public String CustomerName
        {
            get 
            {
                if ((this.firstName == null) || (this.lastName == null)) return customerName;
                string result = firstName;
                if (this.middleName != null) result = result + " " + this.middleName;
                result = result + " " + this.lastName;
                return result;
            }
            set { customerName = value; }
        }
        private String shortName;
        public String ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }
        private String statementName;
        public String StatementName
        {
            get { return statementName; }
            set { statementName = value; }
        }
        private Address customerAddress = new Address();
        internal Address CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        private String shipTo;
        public String ShipTo
        {
            get { return shipTo; }
            set { shipTo = value; }
        }
        private String billTo;
        public String BillTo
        {
            get { return billTo; }
            set { billTo = value; }
        }
        private String statementTo;
        public String StatementTo
        {
            get { return statementTo; }
            set { statementTo = value; }
        }
        private String type;
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private String studentStatus;

        public String StudentStatus
        {
            get { return studentStatus; }
            set { studentStatus = value; }
        }


        private Boolean inactive = false;
        public Boolean Inactive
        {
            get { return inactive; }
            set { inactive = value; }
        }
        private String customerClass = Constants.CUSTOMERCLASS;
        public String CustomerClass
        {
            get { return customerClass; }
            set { customerClass = value; }
        }


/* (IMPORTANT)
 * The following fields are stored in GP Extender 
 * 
 */

        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private String middleName;

        public String MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }
        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private String emailAddress;

        public String EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private DateTime lastEnrolledDate;

        public DateTime LastEnrolledDate
        {
            get { return lastEnrolledDate; }
            set { lastEnrolledDate = value; }
        }

        
        private String officiallyEnrolled; // YES/ASSESSED/NO

        public String OfficiallyEnrolled
        {
            get { return officiallyEnrolled; }
            set { officiallyEnrolled = value; }
        }
        private String level; //Course or level

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
        private String nationality;

        public String Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }
        private String lastSchAttended;

        public String LastSchAttended
        {
            get { return lastSchAttended; }
            set { lastSchAttended = value; }
        }
        private String gender;

        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private String religion;

        public String Religion
        {
            get { return religion; }
            set { religion = value; }
        }
        private String placeOfBirth;

        public String PlaceOfBirth
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }



    }
}
