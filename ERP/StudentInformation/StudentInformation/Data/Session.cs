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
        private List<Customer> selectedCustomerList;

        public List<Customer> SelectedCustomerList
        {
            get { return selectedCustomerList; }
            set { selectedCustomerList = value; }
        }
        private List<Customer> customerList;

        public List<Customer> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }

        private List<Object> selectedFields = new List<Object>();

        public List<Object> SelectedFields
        {
            get { return selectedFields; }
            set { selectedFields = value; }
        }

    }
}
