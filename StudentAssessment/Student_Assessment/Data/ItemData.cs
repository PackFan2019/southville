using System;
using System.Data;
using System.Data.SqlClient;
using StudentAssessment.Objects;
using log4net;
using System.Reflection;

namespace StudentAssessment.Data
{
    public class ItemData
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static ItemData instance;

        string connString = "";

        static ItemData() 
        {
            
        }

        public static ItemData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemData();
                }
                return instance;
            }

        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        public Items GetItems(string level, string currency
            , string uOfM)
        {
            Items items = new Items();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))

                using (SqlCommand comm = new SqlCommand("usp_GetItemsByLevel", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@UofM", uOfM));
                    comm.Parameters.Add(new SqlParameter("@Currency", currency));
                    comm.Parameters.Add(new SqlParameter("@Level", level));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Item item = new Item();

                            item.ItemNo = dr["Item Number"].ToString();
                            item.ItemDescription = dr["Item Description"].ToString();
                            item.ItemClass = dr["Item Class Code"].ToString();
                            item.Uofm = dr["U of M"].ToString();
                            item.Unitprice = Convert.ToDecimal(dr["Unit Price"].ToString());
                            item.ItemType = (ItemType)Convert.ToInt32(dr["Item Type"].ToString());

                            items.Add(item);
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }

            return items;
        }

        public Items GetAssessmentItems(string assessmentNo
            , Transaction_Type sopType)
        {
            Items items = new Items();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetAssessmentItems", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@SOPType", (int)sopType));
                    comm.Parameters.Add(new SqlParameter("@Assessment_No", assessmentNo));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Item i = new Item();
                            i.ItemNo = dr["Item Number"].ToString();
                            i.ItemDescription = dr["Item Description"].ToString();
                            i.Qty = Convert.ToDecimal(dr["Quantity"].ToString());
                            i.Unitprice = Convert.ToDecimal(dr["Unit Price"].ToString());
                            i.ItemClass = dr["Item Class"].ToString();
                            i.Uofm = dr["U of M"].ToString();
                            i.MarkDown = Convert.ToDecimal(dr["Markdown"]);

                            items.Add(i);
                        }
                    }                    
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return items;
        }

        public string[] GetTemplates()
        {
            string[] templates = new string[0];
            int size = 0;
            try
            {                
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetTemplates", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            size++;
                            Array.Resize(ref templates, size);
                            templates[size - 1] = dr["Template ID"].ToString();
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return templates;
        }

        public Items GetKitComponents(string kitItemNo)
        {
            Items items = new Items();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetKitComponents", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Kit", kitItemNo));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr.HasRows)
                            {
                                Item item = new Item();
                                item.ItemNo = dr["Component Item No"].ToString();
                                item.Uofm = dr["U of M"].ToString();
                                item.Qty = Convert.ToDecimal(dr["Qty"].ToString());
                                item.ItemType = (ItemType)Convert.ToInt32(dr["Item Type"]);
                                items.Add(item);
                            }
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return items;
        }

        public Item GetItem(string priceLevel, string currency
            , string itemNumber, string uOfM)
        {
            Item item = null;
            try
            {                
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetItemsByLevel", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@UofM", uOfM));
                    comm.Parameters.Add(new SqlParameter("@Currency", currency));
                    comm.Parameters.Add(new SqlParameter("@Level", priceLevel));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr.HasRows
                                && dr["Item Number"].ToString().Equals(itemNumber))
                            {
                                item = new Item(dr["Item Number"].ToString()
                                                , dr["Item Description"].ToString()
                                                , dr["Item Class Code"].ToString()
                                                , dr["U of M"].ToString()
                                                , Convert.ToDecimal(dr["Unit Price"].ToString()));
                                item.ItemType = (ItemType)Convert.ToInt32(dr["Item Type"]);
                            }
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return item;
        }
        public Items GetTemplateItems(string templateID, string pricelevel
            , string currency, string uOFm)
        {
            Items items = new Items();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetTemplateItems", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@TemplateID", templateID));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Item i = null;
                            decimal qty;

                            i = ItemData.Instance.GetItem(pricelevel, currency
                                , dr["Item no"].ToString(), uOFm);

                            qty = Convert.ToDecimal(dr["Qty"]);

                            if (i != null)
                            {
                                if (qty > 0)
                                {
                                    i.Qty = qty;
                                }

                                if (items != null)
                                {
                                    items.Add(i);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return items;
        }

        public bool CheckMarkdownPassword(string password)
        {
            bool valid = false;
            int result;
            result = 1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_CheckMarkdownPassword", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Password", password));
                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result = (int)dr["Result"];
                        }

                    }
                }

                if (result == 0)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                valid = false;
                throw;
            }
            return valid;
        }
    }
}
