using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Southville.GP.Beans
{
    class Address
    {
        private String addressCode = "HOME";

        public String AddressCode
        {
            get { return addressCode; }
            set { addressCode = value; }
        }
        private String addressString;

        public String AddressString
        {
            get { return addressString; }
            set { addressString = value; }
        }
        private String city;

        public String City
        {
            get { return city; }
            set { city = value; }
        }
        private String state;

        public String State
        {
            get { return state; }
            set { state = value; }
        }
        private String zipcode;

        public String Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        private String country;

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        private String countryCode;

        public String CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }

        private String phoneNumber1;

        public String PhoneNumber1
        {
            get { return phoneNumber1; }
            set { phoneNumber1 = value; }
        }
        private String phoneNumber2;

        public String PhoneNumber2
        {
            get { return phoneNumber2; }
            set { phoneNumber2 = value; }
        }
        private String faxNumber;

        public String FaxNumber
        {
            get { return faxNumber; }
            set { faxNumber = value; }
        }

        private String addressContact;

        public String AddressContact
        {
            get { return addressContact; }
            set { addressContact = value; }
        }

    }
}
