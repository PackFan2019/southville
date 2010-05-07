using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Southville.GP.Beans;

namespace Southville.GP.Data
{
    class Session
    {
        private static Session instance = new Session();
        static Session()
        {
        }
        
        public static Session getInstance()
        {
            return instance;
        }

        public Session()
        {
            if (customerList == null) customerList = SQLData.getInstance().getAllCustomers();
        }
        private List<Customer> customerList;

        public List<Customer> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }

    }
}
