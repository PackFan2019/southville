using System;
using System.Collections.Generic;
using System.Text;
using StuffshopPOS.Beans;
using System.IO;

namespace StuffshopPOS.Data
{

    class FileData
    {

        private static StreamWriter itemWriter;
        private static StreamWriter itemWriter2;

        public static void saveToFile(String TransactionNumber, SalesEntry se)
        {
            int listCount = Session.Cart.getSalesList().Count;
            int counter = 0;
            while (counter < listCount)
            {
                foreach (SalesEntry se1 in Session.Cart.getSalesList())
                {
                    itemWriter = new StreamWriter("sales-" + DateTime.Now.ToString("MMMM") + "-" + DateTime.Now.Day.ToString() + ".txt", true);
                    itemWriter.WriteLine(TransactionNumber.ToString() + "," + se1.ItemCode + "," + se1.Price + "," + se1.Quantity + "," + se1.UOFM);
                    itemWriter.Close();


                    counter++;
                }
            }
        }
    }

}

