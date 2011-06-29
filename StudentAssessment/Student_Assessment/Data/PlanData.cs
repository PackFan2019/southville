using System;
using System.Data;
using System.Data.SqlClient;
using StudentAssessment.Objects;
using log4net;
using System.Reflection;

namespace StudentAssessment.Data
{
    public class PlanData
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static PlanData instance;
        string connString = "";

        public static PlanData Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new PlanData();
                }
                return instance; 
            }
        }

        static PlanData() 
        {
            
        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        public Plans GetPlans()
        {
            Plans plans = new Plans();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetInstalmentSchedules", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Plan p = new Plan();
                            p.PlanID = dr["Plan ID"].ToString();
                            p.Description = dr["Description"].ToString();
                            p.NoOfPayments = Convert.ToInt32(dr["Number of Payments"].ToString());
                            p.DaysFromFirstPayment = Convert.ToInt32(dr["Days from first payment"].ToString());
                            p.Cadence = Convert.ToInt32(dr["Cadence"].ToString());

                            plans.Add(p);
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return plans;
        }

        public int GetPayday(string customerNo, int paydayNo)
        {
            int payday = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetPayday", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Customer_ID", customerNo));
                    comm.Parameters.Add(new SqlParameter("@PaydayNo", paydayNo));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            payday = Convert.ToInt32(dr["Payday"].ToString());
                        }
                    }                    
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }            
            return payday;
        }

        public Plan GetPlan(string planID)
        {
            Plan plan = new Plan();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetPlanDetails", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Plan_ID", planID));

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            plan.PlanID = dr["Plan ID"].ToString();
                            plan.Description = dr["Description"].ToString();
                            plan.NoOfPayments = Convert.ToInt32(dr["Number of Payments"].ToString());
                            plan.DaysFromFirstPayment = Convert.ToInt32(dr["Days from first payment"].ToString());
                            plan.Cadence = Convert.ToInt32(dr["Cadence"].ToString());
                            plan.InstallmentFeePercentage =
                                Convert.ToDecimal(dr["Installment Fee Percentage"]);
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return plan;
        }

        public Schedule GetPlanSchedule(string planID)
        {
            Schedule sked = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetPlanBreakdown", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Plan_ID", planID));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            sked = new Schedule();
                        }
                        while (dr.Read())
                        {
                            Due d = new Due();
                            d.Date = Convert.ToDateTime(dr["Due Date"]);
                            d.Percent = Convert.ToDecimal(dr["Percentage"]);

                            sked.Add(d);
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return sked;
        }
        
        public Schedule GetAssessmentSchedule(string assessmentNo, Transaction_Type sopType)
        {
            Schedule sked = new Schedule();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetAssessmentScheduleByDocID", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@AssessmentNo", assessmentNo));
                    comm.Parameters.Add(new SqlParameter("@SOPType", (int)sopType));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Due due = new Due();
                            due.Date = Convert.ToDateTime(dr["Due Date"]);
                            due.Amount = Convert.ToDecimal(dr["Amount"]);

                            sked.Add(due);
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                sked = null;
                log.Error(ex);
                throw;
            }
            return sked;
        }
    }
}
