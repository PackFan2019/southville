using System;
using System.Collections.Generic;
using System.Text;

namespace StuffshopPOS.Beans
{
    class ReportContainerClass
    {
        private string Pricegroup;

        public string pricegroup
        {
            get { return Pricegroup; }
            set { Pricegroup = value; }
        }

        private int Soptype;

        public int soptype
        {
            get { return Soptype; }
            set { Soptype = value; }
        }

        private String Sopnumber;

        public String sopnumber
        {
          get { return Sopnumber; }
          set { Sopnumber = value; }
        }
        private String Itemnumber;

        public String itemnumber
        {
          get { return Itemnumber; }
          set { Itemnumber = value; }
        }
        private String ItemDescription;

        public String itemDescription
        {
          get { return ItemDescription; }
          set { ItemDescription = value; }
        }
        private decimal Price;

        public decimal price
        {
          get { return Price; }
          set { Price = value; }
        }
        private int Quantity;

        public int quantity
        {
          get { return Quantity; }
          set { Quantity = value; }
        }
        private DateTime Docdate;

        public DateTime docdate
        {
          get { return Docdate; }
          set { Docdate = value; }
        }
        private String Custname;

        public String custname
        {
          get { return Custname; }
          set { Custname = value; }
        }

        public ReportContainerClass()
        {

        }

    }
}
