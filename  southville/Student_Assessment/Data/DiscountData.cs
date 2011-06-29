using System;
using System.Data;
using System.Data.SqlClient;
using StudentAssessment.Objects;
using log4net;
using System.Reflection;

namespace StudentAssessment.Data
{
    public class DiscountData
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static DiscountData instance;
        string connString="";

        static DiscountData() 
        { 
            
        }

        public static DiscountData Instance
        {            
            get 
            {
                if (instance == null)
                {
                    instance = new DiscountData();
                }
                return instance; 
            }
        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        public int GetDiscountLimit()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetDiscountLimit", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();

                    conn.Open();
                    result = (int)comm.ExecuteScalar();
                                       
                }  
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }

            return result;
        }

        public Discounts GetCustomerDiscounts(string customerNo)
        {
            Discounts discounts = new Discounts();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetCustomerDiscounts", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Customer_ID", customerNo));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Discount d = new Discount();
                            d.DiscountID = dr["Discount ID"].ToString();
                            d.DiscountDescription = dr["Discount Description"].ToString();
                            d.Percent = decimal.Round(Convert.ToDecimal(dr["Discount Percentage"].ToString()), 2);
                            d.DiscountType = (Discount_Type)Convert.ToInt32(dr["Discount Type"].ToString());
                            d.Computed = false;

                            discounts.Add(d);                            
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return discounts;
        }

        public Discounts GetAssessmentDiscountsByDocID(string transactionNo, Transaction_Type type)
        {
            Discounts discounts = new Discounts();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetAssessmentDiscountsByDocID", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Assessment_No", transactionNo));
                    comm.Parameters.Add(new SqlParameter("@SOPType", (int)type));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Discount d = new Discount();
                            d.DiscountID = dr["Discount ID"].ToString();
                            d.DiscountDescription = dr["Discount Description"].ToString();
                            d.Percent = decimal.Round(Convert.ToDecimal((dr["Percent"]).ToString()), 2);
                            d.DiscountType = (Discount_Type)Convert.ToInt32(dr["Discount Type"].ToString());
                            d.Amount = decimal.Round(Convert.ToDecimal((dr["Discount Amount"]).ToString()), 2);
                            d.ItemAppliedTo = dr["Applied To"].ToString();
                            d.Computed = true;

                            discounts.Add(d);

                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return discounts;
        }

        public bool ValidateDiscount(string studentID, Discount discount, DateTime date)
        {
            bool valid = false;
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_ValidateDiscount", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@StudentNo", studentID));
                    comm.Parameters.Add(new SqlParameter("@DiscountID", discount.DiscountID));
                    comm.Parameters.Add(new SqlParameter("@Date", date));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result = (int)dr["Result"];
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
                
            }
            catch (Exception ex)
            {
                valid = false;
                log.Error(ex);
                throw;
                //throw new Exception("Unable to validate discount.");
            }
            
            return valid;
        }

        public bool CheckDiscountPassword(string password)
        {
            bool valid = false;
            int result;
            result = 1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_CheckDiscountPassword", conn))
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
