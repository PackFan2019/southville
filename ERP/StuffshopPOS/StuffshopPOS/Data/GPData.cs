using System;
using System.Collections.Generic;
using System.Text;
using StuffshopPOS.Beans;
using StuffshopPOS.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace StuffshopPOS.Data
{
    class GPData:IDisposable
    {
        private static string connectionString = "server=sisc-crusaders.sville.edu.ph;user id=sa;password=southville;database=TWO;Trusted_Connection=false";
        private static SqlConnection connection = new SqlConnection(connectionString);
        public static List<Item> items = new List<Item>();
        public static List<ReportContainerClass> reportlist = new List<ReportContainerClass>();
        private static Dictionary<String, Int32> table = new Dictionary<String, Int32>();
        //private static Item findItemInList(Item i)
        //{
        //    foreach (Item item in items)
        //    {
        //        if (item.Equals(i)) return item;
        //    }
        //    return null;
        //}
        static GPData()
        {
            try
            {
                connection.Open();
                refreshData();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops " + e.ToString());
            }
        }
        public static void refreshData()
        {
            items.Clear();
            int index = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.IV00101 ORDER BY ITEMNMBR", connection);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item();
                    i.itemcode = reader["ITEMNMBR"].ToString().Trim();
                    i.itemname = reader["ITEMDESC"].ToString().Trim();
                    i.pricegroup = reader["PriceGroup"].ToString().Trim();
                    string temp = reader["STNDCOST"].ToString();
                    i.cost = Convert.ToDouble(temp);
                    items.Add(i);
                    table.Add(i.ToString(), index);
                    index++;


                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! " + e.ToString());
            }


            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM dbo.IV00108 WHERE PRCLEVEL = 'RETAIL' ORDER BY ITEMNMBR", connection);
                SqlDataReader reader2 = null;
                reader2 = cmd2.ExecuteReader();
                
                while (reader2.Read())
                {
                    Price p = new Price();
                    String tempItemNumber = "";
                    tempItemNumber = reader2["ITEMNMBR"].ToString().Trim();
                    p.uofm = reader2["UOFM"].ToString().Trim();
                    p.Toqty = Convert.ToDouble(reader2["TOQTY"].ToString().Trim());
                    p.Fromqty = Convert.ToDouble(reader2["FROMQTY"].ToString().Trim());
                    p.Uomprice = Convert.ToDouble(reader2["UOMPRICE"].ToString().Trim());
                    p.Qtybsoum = Convert.ToDouble(reader2["QTYBSUOM"].ToString().Trim());
                    Item found = items.Find(delegate(Item it) { return it.itemcode.Equals(tempItemNumber); });
                    found.priceList.prices.Add(p);

                }
                reader2.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! " + e.ToString());
            }

        }


        public static void ReportData()
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("select a.SOPNUMBE,a.ITEMNMBR, a.ITEMDESC, a.XTNDPRCE, a.QUANTITY, b.DOCDATE, b.CUSTNAME from SOP30300 a, SOP30200 b where a.SOPNUMBE = b.SOPNUMBE", connection);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReportContainerClass rc = new ReportContainerClass();
                    rc.custname = reader["CUSTNAME"].ToString().Trim();
                    rc.docdate  = Convert.ToDateTime(reader["DOCDATE"].ToString());
                    rc.itemDescription = reader["ITEMDESC"].ToString().Trim();
                    rc.itemnumber = reader["ITEMNMBR"].ToString();
                    rc.price = Convert.ToDecimal(reader["XTNDPRCE"].ToString());
                    rc.quantity = Convert.ToInt32(reader["QUANTITY"]);
                    rc.sopnumber = Convert.ToString(reader["SOPNUMBE"].ToString().Trim());
                    reportlist.Add(rc);        


                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        public static List<Item> getAllItems()
        {
            return items;
        }
        public static List<Item> getItems(string pricegroup)
        {
            if (pricegroup.Equals("All")) return items;
            List<Item> result = new List<Item>();
            foreach (Item i in items)
            {
                
                if (i.pricegroup.Equals(pricegroup))
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public static Item getItem(string itemstring)
        {
            //itemstring refers to the toString component of the Item class
            //This returns the Item i from the toString string of each item
            int index = table[itemstring];
            return items[index];
        }

        public void Dispose()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops " + e.ToString());
            }
        }
    }
}
