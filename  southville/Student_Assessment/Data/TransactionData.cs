using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentAssessment.Objects;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using Microsoft.Dynamics.GP.eConnect.MiscRoutines;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using log4net;
using System.Reflection;

namespace StudentAssessment.Data
{
    public class TransactionData
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static TransactionData instance;

        string connString = "";
        int schoolyrfrom;
        int schoolyrto;

        GetSopNumber sopNumber = new GetSopNumber();
        bool rollback = true;

        static TransactionData() 
        { 
            
        }

        public static TransactionData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransactionData();
                }
                return instance;
            }
        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        private void getSchoolYear()
        {          
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetSchoolYear", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            schoolyrfrom = Convert.ToInt32(dr["School Year From"].ToString());
                            schoolyrto = Convert.ToInt32(dr["School Year To"].ToString());
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new Exception("Unable to retrieve school year.");
            }
        }

        public Transaction CreateTransaction(Transaction_Type type, string documentID)
        {
            Transaction transation = new Transaction();

            //get next document number
            try
            {
                transation.DocumentNumber =
                    sopNumber.GetNextSopNumber((int)type, documentID,
                    connString).Trim();

                //get school year
                getSchoolYear();
                transation.SYFrom = schoolyrfrom;
                transation.SYTo = schoolyrto;

                transation.TransactionType = type;
                rollback = true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new Exception("Unable to create new transaction.");
            }
            return transation;
        }

        private void saveToSOP(Transaction assessment, string documentID, string defaultSiteID)
        {
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    string sAssessment;
                    string sXSD;
                    XmlDocument XSDdoc = new XmlDocument();
                    XSDdoc.Load(@"eConnect.xsd");
                    sXSD = XSDdoc.OuterXml;
                    serializeSOPObject("assessment.xml", assessment, documentID, defaultSiteID);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load("assessment.xml");
                    sAssessment = xmldoc.OuterXml;
                    eConnect.eConnect_EntryPoint(connString, EnumTypes.ConnectionStringType.SqlClient, sAssessment, EnumTypes.SchemaValidationType.XSD, sXSD);

                    rollback = false; //20100625
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        public void SaveTransaction(Transaction assessment, string documentID, string defaultSiteID)
        {
            saveToSOP(assessment, documentID, defaultSiteID);
            
            saveToAssessment(assessment);
            saveItems(assessment);
            saveDiscounts(assessment);
            savePaymentSchedule(assessment);
        }

        private void saveDiscounts(Transaction assessment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_InsertAssessmentDiscount", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    if (assessment.AppliedDiscounts != null)
                    {
                        foreach (Discount discount in assessment.AppliedDiscounts)
                        {
                            comm.Parameters.Clear();
                            comm.Parameters.Add(new SqlParameter("@SOPType", (int)assessment.TransactionType));
                            comm.Parameters.Add(new SqlParameter("@AssessmentNo", assessment.DocumentNumber));
                            comm.Parameters.Add(new SqlParameter("@Sequence", assessment.AppliedDiscounts.IndexOf(discount)));
                            comm.Parameters.Add(new SqlParameter("@DiscountID", discount.DiscountID));
                            comm.Parameters.Add(new SqlParameter("@Percent", discount.Percent));
                            comm.Parameters.Add(new SqlParameter("@DiscountAmount", discount.Amount));
                            comm.Parameters.Add(new SqlParameter("@AppliedTo", discount.ItemAppliedTo));

                            comm.ExecuteNonQuery();
                        }
                    }  
                }               
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        private void saveItems(Transaction assessment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_InsertAssessmentLine", conn))
                {
                    conn.Open();
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (Item item in assessment.Items)
                    {
                        comm.Parameters.Clear();
                        comm.Parameters.Add(new SqlParameter("@SOPType", (int)assessment.TransactionType));
                        comm.Parameters.Add(new SqlParameter("@AssessmentNo", assessment.DocumentNumber)); //change this
                        comm.Parameters.Add(new SqlParameter("@Sequence", assessment.Items.IndexOf(item)));
                        comm.Parameters.Add(new SqlParameter("@ItemNumber", item.ItemNo));
                        comm.Parameters.Add(new SqlParameter("@ItemDescription", item.ItemDescription));
                        comm.Parameters.Add(new SqlParameter("@UofM", item.Uofm));
                        comm.Parameters.Add(new SqlParameter("@Quantity", item.Qty));
                        comm.Parameters.Add(new SqlParameter("@UnitPrice", item.Unitprice));
                        comm.Parameters.Add(new SqlParameter("@Markdown", item.MarkDown));
                        comm.Parameters.Add(new SqlParameter("@ExtendedPrice", item.ExtendedPrice));

                        comm.ExecuteNonQuery();
                    }
                }                                     
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        private void saveToAssessment(Transaction assessment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_CreateAssessment", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Clear();
                    comm.Parameters.Add(new SqlParameter("@AssessmentNo", assessment.DocumentNumber)); //change this
                    comm.Parameters.Add(new SqlParameter("@SOPType", (int)assessment.TransactionType));
                    comm.Parameters.Add(new SqlParameter("@CustomerNo", assessment.StudentID));
                    comm.Parameters.Add(new SqlParameter("@CustomerName", assessment.StudentName));
                    comm.Parameters.Add(new SqlParameter("@Level", assessment.PriceLevel));
                    comm.Parameters.Add(new SqlParameter("@GradeLevel", assessment.GradeLevel));
                    comm.Parameters.Add(new SqlParameter("@CurrencyID", assessment.CurrencyID));
                    comm.Parameters.Add(new SqlParameter("@BatchID", assessment.BatchID));
                    comm.Parameters.Add(new SqlParameter("@DocDate", assessment.DocumentDate));
                    comm.Parameters.Add(new SqlParameter("@Plan", assessment.Plan.PlanID));
                    comm.Parameters.Add(new SqlParameter("@SYFrom", assessment.SYFrom));
                    comm.Parameters.Add(new SqlParameter("@SYTo", assessment.SYTo));
                    comm.Parameters.Add(new SqlParameter("@TotalFees", assessment.Subtotal));
                    comm.Parameters.Add(new SqlParameter("@TotalDiscounts", assessment.TotalDiscounts));
                    comm.Parameters.Add(new SqlParameter("@TotalAmount", assessment.TotalAmount));
                    comm.Parameters.Add(new SqlParameter("@Comments", assessment.Comments));
                    comm.Parameters.Add(new SqlParameter("@SOPNumber", assessment.DocumentNumber));
                    comm.Parameters.Add(new SqlParameter("@InstallmentFee", assessment.InstallmentFee));
                    comm.Parameters.Add(new SqlParameter("@ReservationFee", assessment.ReservationFee));

                    conn.Open();
                    comm.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public void RollbackDocumentNumber(string assessmentNumber, Transaction_Type type, string documentID)
        {
            //buggy
            bool result = true;
            if (rollback)
            {
                try
                {
                    result = sopNumber.RollBackSopNumber(assessmentNumber, (int)type,
                            documentID, connString);                
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw;
                }                
            }
        }

        private void serializeSOPObject(string filename, Transaction assessment, string documentID, string defaultSiteID)
        {
            try
            {
                taSopLineIvcInsert_ItemsTaSopLineIvcInsert itemLine;

                taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] lineItems =
                    new taSopLineIvcInsert_ItemsTaSopLineIvcInsert[assessment.Items.Count];
                

                int r = 0;
                //populate item lines
                foreach (Item item in assessment.Items)
                {
                    itemLine =
                        new taSopLineIvcInsert_ItemsTaSopLineIvcInsert();

                    //item pks
                    itemLine.SOPTYPE = (short)assessment.TransactionType;
                    itemLine.CUSTNMBR = assessment.StudentID;
                    itemLine.SOPNUMBE = assessment.DocumentNumber;
                    itemLine.PRCLEVEL = assessment.PriceLevel; //20100527

                    itemLine.DOCID = documentID;
                    //item details
                    itemLine.ITEMNMBR = item.ItemNo;
                    itemLine.UOFM = item.Uofm;
                    if (assessment.TransactionType == Transaction_Type.Drop)
                    {
                        itemLine.QUANTITY = item.Qty;
                        itemLine.QTYINSVC = item.Qty;
                    }
                    else if (assessment.TransactionType == Transaction_Type.Assessment)
                    {
                        itemLine.QUOTEQTYTOINV = item.Qty; 
                    }
                    else if (assessment.TransactionType == Transaction_Type.Add)
                    {
                        itemLine.QUANTITY = item.Qty;
                    }
                    itemLine.ITEMDESC = item.ItemDescription;
                    itemLine.UNITPRCE = item.Unitprice;
                    itemLine.MRKDNPCTSpecified = true;
                    itemLine.MRKDNPCT = item.MarkDown;
                    
                    itemLine.XTNDPRCE = item.ExtendedPrice;
                    itemLine.LOCNCODE = defaultSiteID;
                    itemLine.DOCDATE = assessment.DocumentDate.ToShortDateString();                    
                    
                    //itemLine.UpdateIfExists = 1;
                    lineItems[r] = itemLine;
                    r += 1;
                }
                //add items

                SOPTransactionType salesOrder = new SOPTransactionType();
                Array.Resize(ref salesOrder.taSopLineIvcInsert_Items, r);
                salesOrder.taSopLineIvcInsert_Items = lineItems;

                taSopHdrIvcInsert header = new taSopHdrIvcInsert();

                //populate header node
                header.SOPTYPE = (short)assessment.TransactionType;
                header.SOPNUMBE = assessment.DocumentNumber;
                header.DOCID = documentID;
                header.PRCLEVEL = assessment.PriceLevel; //20100527
                header.TRDISAMTSpecified = true;

                header.BACHNUMB = assessment.BatchID;
                header.LOCNCODE = defaultSiteID;
                header.CUSTNMBR = assessment.StudentID;
                header.CUSTNAME = assessment.StudentName;
                header.CURNCYID = assessment.CurrencyID;
                header.DOCDATE = assessment.DocumentDate.ToShortDateString();
                if (assessment.TransactionType == Transaction_Type.Assessment)
                {
                    header.QUOEXPDA = assessment.ExpirationDate.ToShortDateString();                    
                    header.INVODATE = assessment.DocumentDate.ToShortDateString();
                }
                header.CMMTTEXT = assessment.Comments;
                header.SUBTOTAL = assessment.Subtotal;                
                header.TRDISAMT = assessment.TotalDiscounts;
                header.MISCAMNT = assessment.InstallmentFee;                
                header.DOCAMNT = assessment.TotalAmount;
                header.USINGHEADERLEVELTAXES = 1;
                //header.DEFTAXSCHDS = 1;
                //header.UpdateExisting = 1;

                //add header
                
                salesOrder.taSopHdrIvcInsert = header;

                eConnectType eConnType = new eConnectType();
                Array.Resize(ref eConnType.SOPTransactionType, 1);
                eConnType.SOPTransactionType[0] = salesOrder;
                //serialization proper
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    XmlTextWriter writer = new XmlTextWriter(fs, new UTF8Encoding());
                    XmlSerializer serializer = new XmlSerializer(eConnType.GetType());
                    serializer.Serialize(writer, eConnType);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        private void savePaymentSchedule(Transaction assessment)
        {
            if (assessment.TransactionType == Transaction_Type.Assessment)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    using (SqlCommand comm = new SqlCommand("usp_InsertAssessmentPaymentDetail", conn))
                    {
                        comm.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        //save amount upon enrolment
                        foreach (Due due in assessment.Schedule)
                        {
                            comm.Parameters.Clear();
                            comm.Parameters.Add(new SqlParameter("@SOPType", (int)assessment.TransactionType));
                            comm.Parameters.Add(new SqlParameter("@AssessmentNo", assessment.DocumentNumber));
                            comm.Parameters.Add(new SqlParameter("@DueDate", due.Date));
                            comm.Parameters.Add(new SqlParameter("@Amount", due.Amount));
                            comm.ExecuteNonQuery();
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw;
                }
            }            
        }

        public Transactions GetTransactionsByStudentID(string studentID)
        {
            Transactions transactions =  new Transactions();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand comm = new SqlCommand("usp_GetAssessmentByCustomerID", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Add(new SqlParameter("@Customer_ID", studentID));

                    conn.Open();
                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Transaction t = new Transaction();
                            t.DocumentNumber = dr["Assessment No"].ToString();
                            t.TransactionType = (Transaction_Type)Convert.ToInt32(dr["SOP Type"]);
                            t.StudentID = dr["Student No"].ToString();
                            t.StudentName = dr["Student Name"].ToString();
                            t.PriceLevel = dr["Level"].ToString();
                            t.GradeLevel = dr["Grade Level"].ToString();
                            t.CurrencyID = dr["Currency"].ToString();
                            t.BatchID = dr["Batch No"].ToString();
                            t.DocumentDate = Convert.ToDateTime(dr["Document Date"].ToString());
                            t.Plan = PlanData.Instance.GetPlan(dr["Plan"].ToString());
                            t.SYFrom = Convert.ToInt32(dr["SY From"].ToString());
                            t.SYTo = Convert.ToInt32(dr["SY To"].ToString());
                            t.Comments = dr["Comments"].ToString();
                            t.InstallmentFee = Convert.ToDecimal(dr["Installment Fee"]);
                            

                            t.Items = ItemData.Instance.GetAssessmentItems(t.DocumentNumber, t.TransactionType);
                            t.AppliedDiscounts = DiscountData.Instance.GetAssessmentDiscountsByDocID(t.DocumentNumber, t.TransactionType);
                            t.Schedule = PlanData.Instance.GetAssessmentSchedule(t.DocumentNumber, t.TransactionType);
                            t.ReservationFee = Convert.ToDecimal(dr["Reservation Fee"]);                            

                            transactions.Add(t);
                        }
                    }                    
                }                
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            
            return transactions;
        }        
    }
}
