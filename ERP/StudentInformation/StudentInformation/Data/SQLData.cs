using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using Southville.GP.Beans;

namespace Southville.GP.Data
{
    class SQLData
    {
        private static SQLData instance = new SQLData();
        private const string connectionString = "server=" + Constants.SERVERNAME + ";user id=" + Constants.USERID +
            ";password=" + Constants.PASSWORD + ";database=" + Constants.DATABASENAME + ";Trusted_Connection=false";
        private SqlConnection connection = new SqlConnection(connectionString);
        static SQLData()
        {
        }
        public SQLData()
        {
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops " + e.ToString());
            }
        }
        private static string beginExtenderTransaction(string customer_id)
        {
            string result = "BEGIN TRANSACTION";
            return result;
        }

        
        private static string addExtenderString(string strAdded, string window_id, string keyfield, string item_id)
        {
            string result = "\nIF EXISTS(SELECT * FROM EXT00101 WHERE PT_Window_ID='" + window_id + "' AND PT_UD_Number=" + item_id + " AND PT_UD_Key='" + keyfield + "')"
                            +"\nBEGIN" 
                              +"\nUPDATE EXT00101 SET STRGA255='"+strAdded+"' WHERE PT_Window_ID='"+window_id+"' AND PT_UD_Number="+item_id+" AND PT_UD_Key='"+keyfield+"'"
                            +"\nEND"
                              +"\nELSE"
                            +"\nBEGIN"
                              +"\nINSERT INTO EXT00101 (PT_Window_ID, PT_UD_Key, PT_UD_Number, STRGA255) VALUES ('"+window_id+"', '"+keyfield+"', "+item_id+", '"+strAdded+"')"
                            +"\nEND";
            return result;
        }
        private static string addExtenderNumber(double numberAdded, string window_id, string keyfield, string item_id)
        {
            string result = "\nIF EXISTS(SELECT * FROM EXT00103 WHERE PT_Window_ID='"+window_id+"' AND PT_UD_Number="+item_id+" AND PT_UD_Key='"+keyfield+"')" 
                            + "\nBEGIN"
	                          + "\nUPDATE EXT00103 SET TOTAL="+numberAdded.ToString()+" WHERE PT_Window_ID='"+window_id+"' AND PT_UD_Number="+item_id+" AND PT_UD_Key='"+keyfield+"'" 
                            + "\nEND"
                            + "\nELSE"
                            + "\nBEGIN"
	                          + "\nINSERT INTO EXT00103 (PT_Window_ID, PT_UD_Key, PT_UD_Number, TOTAL) VALUES ('"+window_id+"', '"+keyfield+"', "+item_id+", "+numberAdded.ToString()+")"
                            + "\nEND";
            return result;
        }
        private static string addExtenderDate(DateTime dateAdded, string window_id, string keyfield, string item_id)
        {
            string dateAddedString = dateAdded.ToString("yyyy-MM-dd HH:mm:ss");
            string result = "\nIF EXISTS(SELECT * FROM EXT00102 WHERE PT_Window_ID='"+window_id+"' AND PT_UD_Number="+item_id+" AND PT_UD_Key='"+keyfield+"')"
                            + "\nBEGIN"
                            + "\nUPDATE EXT00102 SET DATE1='" + dateAddedString + "' WHERE PT_Window_ID='" + window_id + "' AND PT_UD_Number=" + item_id + " AND PT_UD_Key='" + keyfield + "'"
                            + "\nEND"
                            + "\nELSE"
                            + "\nBEGIN"
                            + "\nINSERT INTO EXT00102 (PT_Window_ID, PT_UD_Key, PT_UD_Number, DATE1) VALUES ('" + window_id + "', '" + keyfield + "', " + item_id + ", '" + dateAddedString + "')"
                            + "\nEND";
            return result;
        }

        private static string endExtenderTransaction()
        {
            string result = "\nIF @@ERROR <> 0" +
                               "\nBEGIN" +
                                    "\nROLLBACK" +
                                    "\nRAISERROR ('Error in GP Extender Transaction', 16, 1)" +
                                    "\nRETURN" +
                               "\nEND" +
                            "\nCOMMIT";
            return result;
        }
        public static SQLData getInstance()
        {
            return instance;
        }
        public Customer getCustomer(Customer c)
        {
            if (c.CustomerID == null) return null;
            //Pre: Customer has been loaded with a customerId
            string sqlGetStrings = "SELECT STRGA255, PT_UD_Number FROM EXT00101 WHERE PT_Window_ID='"+
                Constants.WINDOW_EXT_ID+"' AND PT_UD_Key='"+c.CustomerID+"'";
            string sqlGetDates = "SELECT DATE1, PT_UD_Number FROM EXT00102 WHERE PT_Window_ID='"+
                Constants.WINDOW_EXT_ID+"' AND PT_UD_Key='"+c.CustomerID+"'";
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sqlGetStrings, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string str_value = reader["STRGA255"].ToString().Trim();
                    string field_num = reader["PT_UD_Number"].ToString().Trim();
                    if ((str_value != null) && !(str_value.Equals("")))
                    {
                        if (field_num.Equals(Constants.FIRSTNAME_FIELD_ID))
                            c.FirstName = str_value;
                        else if (field_num.Equals(Constants.MIDDLENAME_FIELD_ID))
                            c.MiddleName = str_value;
                        else if (field_num.Equals(Constants.LASTNAME_FIELD_ID))
                            c.LastName = str_value;
                        else if (field_num.Equals(Constants.LEVEL_FIELD_ID))
                            c.Level = str_value;
                        else if (field_num.Equals(Constants.SECTION_FIELD_ID))
                            c.Section = str_value;
                        else if (field_num.Equals(Constants.NATIONALITY_FIELD_ID))
                            c.Nationality = str_value;
                        else if (field_num.Equals(Constants.ENROLLED_FIELD_ID))
                            c.OfficiallyEnrolled = str_value;
                        else if (field_num.Equals(Constants.GENDER_FIELD_ID))
                            c.Gender = str_value;
                        else if (field_num.Equals(Constants.RELIGION_FIELD_ID))
                            c.Religion = str_value;
                        else if (field_num.Equals(Constants.PLACEOFBIRTH_FIELD_ID))
                            c.PlaceOfBirth = str_value;
                        else if (field_num.Equals(Constants.EMAIL_FIELD_ID))
                            c.EmailAddress = str_value;
                        else if (field_num.Equals(Constants.LASTSCHOOL_FIELD_ID))
                            c.LastSchAttended = str_value;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                reader.Close();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sqlGetDates, connection);
                reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string str_value = reader["DATE1"].ToString().Trim();
                    string field_num = reader["PT_UD_Number"].ToString().Trim();
                    if ((str_value != null) && !(str_value.Equals("")))
                    {
                        if (field_num.Equals(Constants.BIRTHDAY_FIELD_ID))
                            c.Birthday = DateTime.Parse(str_value);
                        if (field_num.Equals(Constants.LASTENROLLEDDATE_FIELD_ID))
                            c.LastEnrolledDate = DateTime.Parse(str_value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                reader.Close();
            }
            return c;
        }
        public bool saveOrUpdate(Customer c)
        {
            bool status = true;
            //DONT PROCESS IF THIS IS FALSE
            if (c.OfficiallyEnrolled == null) return false;

            //Create Extender SQLString
            string sqlString = SQLData.beginExtenderTransaction(c.CustomerID);
            if (c.FirstName != null)
                sqlString += SQLData.addExtenderString(c.FirstName, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.FIRSTNAME_FIELD_ID);
            if (c.MiddleName != null)
                sqlString += SQLData.addExtenderString(c.MiddleName, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.MIDDLENAME_FIELD_ID);
            if (c.LastName != null)
                sqlString += SQLData.addExtenderString(c.LastName, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.LASTNAME_FIELD_ID);
            if (c.EmailAddress != null) 
                sqlString += SQLData.addExtenderString(c.EmailAddress, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.EMAIL_FIELD_ID);
            if ((c.Birthday != null) && !(c.Birthday.Equals(new DateTime())))  
                sqlString += SQLData.addExtenderDate(c.Birthday, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.BIRTHDAY_FIELD_ID);
            if ((c.LastEnrolledDate != null) && !(c.LastEnrolledDate.Equals(new DateTime())))
                sqlString += SQLData.addExtenderDate(c.LastEnrolledDate, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.LASTENROLLEDDATE_FIELD_ID);
            if (c.OfficiallyEnrolled != null) 
                sqlString += SQLData.addExtenderString(c.OfficiallyEnrolled, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.ENROLLED_FIELD_ID);
            if (c.Level != null) 
                sqlString += SQLData.addExtenderString(c.Level, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.LEVEL_FIELD_ID);
            if (c.Section != null) 
                sqlString += SQLData.addExtenderString(c.Section, Constants.WINDOW_EXT_ID, 
                    c.CustomerID, Constants.SECTION_FIELD_ID);
            if (c.Nationality != null) 
                sqlString += SQLData.addExtenderString(c.Nationality, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.NATIONALITY_FIELD_ID);
            if (c.LastSchAttended != null)
                sqlString += SQLData.addExtenderString(c.LastSchAttended, Constants.WINDOW_EXT_ID, 
                    c.CustomerID, Constants.LASTSCHOOL_FIELD_ID);
            if (c.Gender != null)
                sqlString += SQLData.addExtenderString(c.Gender, Constants.WINDOW_EXT_ID, 
                    c.CustomerID, Constants.GENDER_FIELD_ID);
            if (c.Religion != null)
                sqlString += SQLData.addExtenderString(c.Religion, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.RELIGION_FIELD_ID);
            if (c.PlaceOfBirth != null)
                sqlString += SQLData.addExtenderString(c.PlaceOfBirth, Constants.WINDOW_EXT_ID,
                    c.CustomerID, Constants.PLACEOFBIRTH_FIELD_ID);


            sqlString += SQLData.endExtenderTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlString, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                status = false;
                Console.WriteLine(e);
            }
            return status;
        }

        public List<Customer> getAllCustomers()
        {
            /* Queries that can be used
             * SELECT CUSTNMBR, CUSTNAME FROM RM00101
            SELECT * FROM RM00101 WHERE INACTIVE=0 AND CUSTCLAS='STUDENTS'*/
            String sqlGetAllCustomers = "SELECT CUSTNMBR, CUSTNAME FROM RM00101 WHERE CUSTCLAS='STUDENTS' ORDER BY CUSTNAME";
            List<Customer> result = new List<Customer>();
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sqlGetAllCustomers, connection);
                reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    Customer c = new Customer();
                    c.CustomerID = reader["CUSTNMBR"].ToString().Trim();
                    c.CustomerName = reader["CUSTNAME"].ToString().Trim();
                    result.Add(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                reader.Close();
            }
            
            return result;
        }


        public void Dispose()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
    }
}
