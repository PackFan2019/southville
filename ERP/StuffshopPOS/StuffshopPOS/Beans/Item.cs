using System;
using System.Collections.Generic;
using System.Text;

namespace StuffshopPOS.Beans
{
    class Item:IEquatable<Item>
    {
        public static List<Pricelist> PriceList = new List<Pricelist>();
        public string itemcode = "";
        public string itemname = "";
        //public string UOFM = "";
        public string pricegroup = "";
        public double cost = 0;
        public double Gtotal = 0;
        public double Cash = 0;
        public double Change = 0;
        //public double total = 0;
        public Pricelist priceList = new Pricelist();
        public override string ToString()
        {
            return itemcode + "  (" + itemname + ")";
        }

        public bool Equals(Item i)
        {
            //Two items are equal when they have the same itemcode
            return (this.itemcode.Equals(i.itemcode));
        }
    }
}
