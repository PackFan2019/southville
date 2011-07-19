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
        
        /*
         * Group of 5 functions are used to create an GP Extender transaction (Utility functions)
         */
        private static string beginExtenderTransaction(string customer_id)
        {
            string result = "BEGIN TRANSACTION";
            return result;
        }
        private static string addExtenderString(string strAdded, string window_id, string keyfield, string item_id)
        {
            //Check that the strAdded does not contain apostrophe's
            strAdded = strAdded.Replace("'", "''");

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

        /*
         * Group of 2 functions is used to add GP Extender string data to an object
         * using buffers (only use 1 SQL statement)
         */
        public Dictionary<String,String> getExtenderDatabuffer(String Window_Ext_Id, String PT_Number)
        {
            //Buffer contains (CustomerID, ExtenderString) pairs
            Dictionary<String, String> buffer = new Dictionary<String, String>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    String sqlGetExtenderData = "SELECT PT_UD_Key, STRGA255 FROM EXT00101 WHERE PT_Window_ID='" + Window_Ext_Id + "' AND PT_UD_Number=" + PT_Number + "";
                    SqlCommand cmd = new SqlCommand(sqlGetExtenderData, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        buffer.Add(reader["PT_UD_Key"].ToString().Trim(), reader["STRGA255"].ToString().Trim());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return buffer;
        }
        public Dictionary<String, DateTime> getExtenderDates(String Window_Ext_Id, String PT_Number)
        {
            //Buffer contains (CustomerID, ExtenderString) pairs
            Dictionary<String, DateTime> buffer = new Dictionary<String, DateTime>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    String sqlGetExtenderData = "SELECT PT_UD_Key, DATE1 FROM EXT00102 WHERE PT_Window_ID='" + Window_Ext_Id + "' AND PT_UD_Number=" + PT_Number + "";
                    SqlCommand cmd = new SqlCommand(sqlGetExtenderData, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["DATE1"].ToString() != null)
                        {
                            buffer.Add(reader["PT_UD_Key"].ToString().Trim(), Convert.ToDateTime(reader["DATE1"].ToString().Trim()));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return buffer;
        }
       public String getExtenderDataIfExists(String customerID, Dictionary<String, String> buffer)
        {
            if (customerID!=null && buffer.ContainsKey(customerID)) return buffer[customerID];
            return "";
        }

       public DateTime getExtenderBdayIfExists(String customerID, Dictionary<String, DateTime> buffer)
       {
           if (customerID != null && buffer.ContainsKey(customerID)) return buffer[customerID];
           return Convert.ToDateTime(null);
       }
        public static SQLData getInstance()
        {
            return instance;
        }

        //This is optimized to only do one SQL statement
        public Customer getCustomer(Customer c)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (c.CustomerID == null) return null;
                //Pre: Customer has been loaded with a customerId
                string sqlGetStrings = "SELECT STRGA255, PT_UD_Number FROM EXT00101 WHERE PT_Window_ID='" +
                    Constants.WINDOW_EXT_ID + "' AND PT_UD_Key='" + c.CustomerID + "'";
                string sqlGetDates = "SELECT DATE1, PT_UD_Number FROM EXT00102 WHERE PT_Window_ID='" +
                    Constants.WINDOW_EXT_ID + "' AND PT_UD_Key='" + c.CustomerID + "'";
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
                                c.Birthday = Convert.ToDateTime(str_value);
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
            }
            return c;
        }
        
        //This transaction appends several extender sql statements into one transaction
        public bool saveOrUpdate(Customer c)
        {
            bool status = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
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
                    sqlString += SQLData.addExtenderDate(Convert.ToDateTime(c.Birthday), Constants.WINDOW_EXT_ID,
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
            }
            return status;
        }

        /*This SQL statement uses one SQL query to get a customer as long as they are in
         the Constants.STUDENTCLASSES string array
         */
        public List<Customer> getAllCustomers()
        {
            /* Queries that can be used
             * SELECT CUSTNMBR, CUSTNAME FROM RM00101
            SELECT * FROM RM00101 WHERE INACTIVE=0 AND CUSTCLAS='STUDENTS'*/
            
            /* Build the WHERE section using IN (Student classes)*/
            String studentClasses = "(";
            for (int i = 0; i < Constants.STUDENTCLASSES.Length; i++)
            {
                if (i != 0) studentClasses += ",";
                studentClasses += "'" + Constants.STUDENTCLASSES[i] + "'";
            }
            studentClasses += ")";
            /*This comes out with (STUDENT,IB,COLLEGE) etc */
            List<Customer> result = null;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sqlGetAllCustomers = "SELECT CUSTNMBR, CUSTNAME, CUSTCLAS, USERDEF1, USERDEF2, STMTNAME, ADDRESS1, CITY, PHONE1, PHONE2  FROM RM00101 WHERE CUSTCLAS IN " + studentClasses + " ORDER BY CUSTNAME";
                result = new List<Customer>();
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
                        c.CustomerClass = reader["CUSTCLAS"].ToString().Trim();
                        c.Type = reader["USERDEF1"].ToString().Trim();
                        c.StudentStatus = reader["USERDEF2"].ToString().Trim();
                        c.BillTo = reader["STMTNAME"].ToString().Trim();
                        c.CustomerAddress.AddressString = reader["ADDRESS1"].ToString().Trim() + " " + reader["CITY"].ToString().Trim();
                        c.CustomerAddress.PhoneNumber1 = reader["PHONE1"].ToString().Trim();
                        c.CustomerAddress.PhoneNumber2 = reader["PHONE2"].ToString().Trim();
                        result.Add(c);
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                finally
                {
                    reader.Close();
                } 
            }
            
            return result;
        }

        /*
         * Note that this will only fill the section and level fields
         * of the customer (from Extender tables) for efficiency
         * it performs caching of the level and section fields from table EXT00101
         * 
         */
        public List<Customer> getAllCustomers(String enrollmentStatus, String level, String section)
        {
            Dictionary<String, String> levels = 
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.LEVEL_FIELD_ID);
            Dictionary<String, String> sections = 
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.SECTION_FIELD_ID);
            Dictionary<String, String> enrollment = 
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.ENROLLED_FIELD_ID);
            Dictionary<String, String> firstname =
               getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.FIRSTNAME_FIELD_ID);
            Dictionary<String, String> lastname =
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.LASTNAME_FIELD_ID);
            List<Customer> result = getAllCustomers();
            //Add the buffer data into the List
            
            foreach (Customer c in result)
            {
                c.FirstName = getExtenderDataIfExists(c.CustomerID, firstname);
                c.LastName = getExtenderDataIfExists(c.CustomerID, lastname);
                c.Level = getExtenderDataIfExists(c.CustomerID, levels);
                c.Section = getExtenderDataIfExists(c.CustomerID, sections);
                c.OfficiallyEnrolled = getExtenderDataIfExists(c.CustomerID, enrollment);
            }


            /*
             * Filter for enrollment status
             */
            if (enrollmentStatus.Equals("All"))
            {
                //Do nothing
            }
            else if (enrollmentStatus.Equals("Not applicable"))
            {
                result = result.FindAll(delegate(Customer c)
                {
                    return !(c.OfficiallyEnrolled.Equals("Not enrolled") ||
                    c.OfficiallyEnrolled.Equals("Assessed") ||
                    c.OfficiallyEnrolled.Equals("Enrolled"));
                });
            }
            else
            {
                result = result.FindAll(delegate(Customer c) { return c.OfficiallyEnrolled.Equals(enrollmentStatus); });
            }

            /*
             * Filter for sections
             */ 
            if (section != null)
                result = result.FindAll(delegate(Customer c) { return c.Section.Equals(section); });

            /*
             * Filter for levels
             */
            if (level != null)
                result = result.FindAll(delegate(Customer c) { return c.Level.Equals(level); });

            return result;
        }

        /*
         * Added code to and All customer the enrollmentStatus attribute
         */

        public List<Customer> getAllCustomersByEnrollmentStatus(String enrollmentStatus)
        {
            Dictionary<String, String> enrollment =
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.ENROLLED_FIELD_ID);

            List<Customer> result = getAllCustomers();
            //Add the buffer data into the List

            foreach (Customer c in result)
            {
                c.OfficiallyEnrolled = getExtenderDataIfExists(c.CustomerID, enrollment);
            }


            /*
             * Filter for enrollment status
             */
            if (enrollmentStatus.Equals("All"))
            {
                //Do nothing
            }
            else if (enrollmentStatus.Equals("Not applicable"))
            {
                result = result.FindAll(delegate(Customer c)
                {
                    return !(c.OfficiallyEnrolled.Equals("Not enrolled") ||
                    c.OfficiallyEnrolled.Equals("Assessed") ||
                    c.OfficiallyEnrolled.Equals("Enrolled"));
                });
            }
            else
            {
                result = result.FindAll(delegate(Customer c) { return c.OfficiallyEnrolled.Equals(enrollmentStatus); });
            }

            return result;
        }
        public List<Customer> getAllCustomersForEGP(String enrollmentStatus, String level, String section)
        {
            List<Customer> students = getAllCustomers(enrollmentStatus, level, section);
            Dictionary<String, String> firstNames =
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.FIRSTNAME_FIELD_ID);
            Dictionary<String, String> lastNames =
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.LASTNAME_FIELD_ID);
            Dictionary<String, String> emailAddresses =
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.EMAIL_FIELD_ID);
            Dictionary<String, String> genders =
                getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.GENDER_FIELD_ID);
            foreach (Customer c in students)
            {
                c.EmailAddress = getExtenderDataIfExists(c.CustomerID, emailAddresses);
                c.Gender = getExtenderDataIfExists(c.CustomerID, genders);
                c.FirstName = getExtenderDataIfExists(c.CustomerID, firstNames);
                c.LastName = getExtenderDataIfExists(c.CustomerID, lastNames);
            }
            return students;
        }

        public String getAllCustomersString(String enrollmentStatus, String level, String section)
        {
            
            StringBuilder result = new StringBuilder();
            List<Customer> students = getAllCustomersForEGP(enrollmentStatus, level, section);
            foreach (Customer c in students)
            {
                result.Append(c.CustomerID + "," + c.FirstName + "," + c.LastName + "," +
                       c.Gender + "," + c.EmailAddress + "," + c.Level + "," + c.Section + "\r\n");
            }
            return result.ToString();
        }
        public void Dispose()
        {

        }
        
        public String suggestID(String year, String suffix)
        {
            int length = 7 + (suffix.Length);
            String cmdStr = "SELECT TOP(1) CUSTNMBR FROM RM00101 WHERE"
            + " CUSTNMBR LIKE '" + year + "-%" + suffix + "' AND LEN(CUSTNMBR)=" + length + " ORDER BY CUSTNMBR DESC";
            String UniqueID = year + "-0001" + suffix;
            String LastCustomerID = "";
            SqlDataReader reader = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(cmdStr, connection);
                    reader = null;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LastCustomerID = reader["CUSTNMBR"].ToString().Trim();
                    }
                    if (LastCustomerID != null && LastCustomerID.Length >= 7)
                    {
                        String currentID = LastCustomerID.Substring(3, 4);
                        int next = (Int32.Parse(currentID) + 1);
                        String formattedNext = String.Format("{00:0001}", next);
                        UniqueID = year + "-" + (formattedNext) + suffix;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            return UniqueID;
        }
        public void updateCustomers(String Newvalue, String PT_UD_Number)
        {
            /* Queries that can be used
             * SELECT CUSTNMBR, CUSTNAME FROM RM00101
            SELECT * FROM RM00101 WHERE INACTIVE=0 AND CUSTCLAS='STUDENTS'*/

            /* Build the WHERE section using IN (Student classes)*/
            
        }
        public void massUpdate(String extenderWindowID, List<Customer> customers, String newValue, String PT_UD_Number)
        {
            if (customers != null || customers.Count <= 0 || extenderWindowID != null || PT_UD_Number != null)
            {
                String studentIDs = "(";
                for (int i = 0; i < customers.Count; i++)
                {
                    if (i != 0) studentIDs += ",";
                    studentIDs += "'" + customers[i].CustomerID + "'";
                }
                studentIDs += ")";
                /*This comes out with (STUDENT,IB,COLLEGE) etc */
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlGetAllCustomers = "UPDATE EXT00101 SET STRGA255='" + newValue +
                        "' WHERE PT_Window_ID = 'STUDENT_EXT' AND PT_UD_Number = '" + PT_UD_Number +
                        "' AND PT_UD_Key IN " + studentIDs + "";
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sqlGetAllCustomers, connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                    finally
                    {
                    }
                }
            }
            else { System.Windows.Forms.MessageBox.Show("No columns to update","Empty",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information); }
            
        }
    }
}
