using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Southville.GP.Beans;

namespace Southville.GP.Data
{
    class CustomerDAO
    {
        private static CustomerDAO instance = new CustomerDAO();
        
        static CustomerDAO()
        {
        }

        public static CustomerDAO getInstance()
        {
            return instance;
        }

        public bool saveCustomer(Customer c)
        {
            bool result = true;
            result = EConnectData.getInstance().createOrUpdateCustomer(c);
            result = SQLData.getInstance().saveOrUpdate(c);
            return result;
        }

        public Customer getCustomer(String customerCode)
        {
            Customer c = EConnectData.getInstance().getCustomer(customerCode);
            if (c == null) return null;
            c = SQLData.getInstance().getCustomer(c);
            return c;
        }

        public List<Customer> getAllCustomers()
        {
            return SQLData.getInstance().getAllCustomers();
        }
    }
}
