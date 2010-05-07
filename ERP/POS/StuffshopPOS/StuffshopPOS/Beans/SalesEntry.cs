using System;
using System.Collections.Generic;
using System.Text;

namespace StuffshopPOS.Beans
{
    class SalesEntry:IEquatable<SalesEntry>
    {
        private String _itemCode = "2123QEW";

        public String ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }
        private String _ItemName = "RAM";


        private string _UOFM = "Default";

        public string UOFM
        {
            get { return _UOFM; }
            set { _UOFM = value; }
        }


        public String ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        private Double _price;

        public Double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private int _quantity = 0;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        private Double grandTotal = 0;

        public Double GrandTotal
        {
            get { return grandTotal; }
            set { grandTotal = value; }
        }
        private Double total = 0;

        public Double Total
        {
            get { return total; }
            set { total = value; }
        }

        private Double toqty;

        public Double Toqty
        {
            get { return toqty; }
            set { toqty = value; }
        }


        public static String transId = "qwer34";
        public bool Equals(SalesEntry s)
        {
            return ((this.Price) == s.Price) && (this.ItemName.Equals(s.ItemName));

        }



    }
}
