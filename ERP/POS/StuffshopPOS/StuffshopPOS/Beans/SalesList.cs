using System;
using System.Collections.Generic;
using System.Text;

namespace StuffshopPOS.Beans
{
    class SalesList
    {
        private static List<SalesEntry> sales = new List<SalesEntry>();


        private static SalesEntry findItemInList(SalesEntry i)
        {
            foreach (SalesEntry item in sales)
            {
                if (item.Equals(i)) return item;
            }
            return null;
        }

        public void addEntry(SalesEntry s)
        {
            //Logic: If the entry exists (same UOFM, itemcode) then:
            //Store the current quantity of the entry with the same item code, UOFM
            //remove the existing entry
            //Add the two quantities together
            //Add back to saleslist
            //If it doesnt exist, just add
           
            //sales.Add(s);
            //found = s;
            int quantity = s.Quantity;
            double total = s.Total;
            int quantity2 = 0;
            double total2 = 0;

                //s.Quantity = 0;
            foreach (SalesEntry SE in sales)
            {
                if (SE.ItemCode.Equals(s.ItemCode) && SE.UOFM.Equals(s.UOFM))
                {
                    quantity2 = SE.Quantity;
                    total2 = SE.Total;
                    quantity = quantity + quantity2;
                    total = total + total2;

                    
                }
                else
                {
                    
                }
                
            }
            sales.RemoveAll(delegate(SalesEntry he) { return he.ItemCode.Equals(s.ItemCode) && he.UOFM.Equals(s.UOFM); });
            s.Quantity = quantity;
            s.Total = total;
            sales.Add(s);

        }

        public void removeEntry(SalesEntry s)
        {
            //To delete the proper salesentry
            sales.Remove(s);
            s.Price = 0;
        }

        public List<SalesEntry> getSalesList()
        {
            return sales;
        }
    }
}
