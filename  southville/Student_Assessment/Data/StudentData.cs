using System;
using System.Data;
using System.Data.SqlClient;
using StudentAssessment.Objects;
using log4net;
using System.Reflection;

namespace StudentAssessment.Data
{
    public class StudentData
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static StudentData instance;
        string connString = "";

        static StudentData()
        {
            
        }

        public static StudentData Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new StudentData();
                }
                return instance; 
            }
        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        public Students GetStudents()
        {
            Students students = new Students();                      

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetActiveCustomers", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Student stud = new Student(dr["Customer Number"].ToString(),
                                dr["Customer Name"].ToString(),
                                dr["Price Level"].ToString(),
                                dr["Customer Class"].ToString(),
                                dr["Currency ID"].ToString(),
                                dr["Grade Level"].ToString(),
                                dr["Status"].ToString());

                            students.Add(stud);
                        }
                    }                    
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return students;
        }

        public Student GetStudent(string customerNo)
        {
            Student student = new Student();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetCustomerByID", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@Customer_ID", customerNo));

                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        student.StudentFound = false;
                        while (dr.Read())
                        {
                            student = new Student(dr["Customer Number"].ToString()
                                                    , dr["Customer Name"].ToString()
                                                    , dr["Price Level"].ToString()
                                                    , dr["Customer Class"].ToString()
                                                    , dr["Currency ID"].ToString()
                                                    , dr["Grade Level"].ToString()
                                                    , dr["Status"].ToString());

                            student.Plan = PlanData.Instance.GetPlan(dr["Plan"].ToString());

                            student.StudentFound = true;
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }

            return student;
        }
    }
}
