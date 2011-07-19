using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Southville.GP.Beans;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace Southville.GP.Data
{
    class EConnectData
    {
        private static string sConnectionString = @"data source=sisc-crusaders;initial catalog=SISC; integrated security=SSPI;persist security info=False;packet size=4096";
        private static EConnectData instance = new EConnectData();
        static EConnectData()
        {
            
        }
        public static EConnectData getInstance()
        {
            return instance;
        }

        public Customer getCustomer(String customerId)
        {
            eConnectMethods eConnect = new eConnectMethods();
            String address1 = "";
            String address2 = "";
            Customer result = new Customer();
            result.CustomerID = customerId;
            try
            {

                eConnectType myEConnectType = new eConnectType();
                RQeConnectOutType myReqType = new RQeConnectOutType();
                eConnectOut myeConnectOut = new eConnectOut();
                myeConnectOut.ACTION = 1;
                myeConnectOut.DOCTYPE = "Customer";
                myeConnectOut.OUTPUTTYPE = 2;
                myeConnectOut.INDEX1FROM = customerId;
                myeConnectOut.INDEX1TO = customerId;
                myeConnectOut.FORLIST = 1;
                // Add the eConnectOut XML node object to the RQeConnectOutType schema object
                myReqType.eConnectOut = myeConnectOut;

                // Add the RQeConnectOutType schema object to the eConnect document object
                RQeConnectOutType[] myReqOutType = { myReqType };
                myEConnectType.RQeConnectOutType = myReqOutType;

                // Serialize the eConnect document object to a memory stream
                MemoryStream myMemStream = new MemoryStream();
                XmlSerializer mySerializer = new XmlSerializer(myEConnectType.GetType());
                mySerializer.Serialize(myMemStream, myEConnectType);
                myMemStream.Position = 0;

                // Load the serialized eConnect document object into an XML document object
                XmlTextReader xmlreader = new XmlTextReader(myMemStream);
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(xmlreader);

                // Call the eConnect_Requester method of the eConnectMethods object to retrieve specified XML data
                string reqDoc = eConnect.eConnect_Requester(sConnectionString, EnumTypes.ConnectionStringType.SqlClient, myXmlDocument.OuterXml);
                XmlDocument resultDocument = new XmlDocument();
                resultDocument.LoadXml(reqDoc);

                XmlNodeList customerNodeList = resultDocument.GetElementsByTagName("Customer");

                if (customerNodeList.Count == 0) return null;
                else
                {
                    //Here we have retrieved the customer document
                    foreach (XmlNode node in customerNodeList[0])
                    {
                        if (node.Name.Equals("ADDRESS1"))
                            address1 = node.InnerText;
                        if (node.Name.Equals("ADDRESS2"))
                            address2 = node.InnerText;
                        else if (node.Name.Equals("ADRSCODE"))
                            result.CustomerAddress.AddressCode = node.InnerText;
                        else if (node.Name.Equals("CITY"))
                            result.CustomerAddress.City = node.InnerText;
                        else if (node.Name.Equals("CNTCPRSN"))
                            result.CustomerAddress.AddressContact = node.InnerText;
                        else if (node.Name.Equals("COUNTRY"))
                            result.CustomerAddress.Country = node.InnerText;
                        else if (node.Name.Equals("CUSTCLAS"))
                            result.CustomerClass = node.InnerText;
                        else if (node.Name.Equals("CUSTNAME"))
                            result.CustomerName = node.InnerText;
                        else if (node.Name.Equals("PHONE1"))
                            result.CustomerAddress.PhoneNumber1 = node.InnerText;
                        else if (node.Name.Equals("PHONE2"))
                            result.CustomerAddress.PhoneNumber2 = node.InnerText;
                        else if (node.Name.Equals("FAX"))
                            result.CustomerAddress.FaxNumber = node.InnerText;
                        else if (node.Name.Equals("STATE"))
                            result.CustomerAddress.State = node.InnerText;
                        else if (node.Name.Equals("ZIP"))
                            result.CustomerAddress.Zipcode = node.InnerText;
                        else if (node.Name.Equals("STMTNAME"))
                            result.StatementName = node.InnerText;
                        else if (node.Name.Equals("SHRTNAME"))
                            result.ShortName = node.InnerText;
                        else if (node.Name.Equals("PRBTADCD"))
                            result.BillTo = node.InnerText;
                        else if (node.Name.Equals("PRSTADCD"))
                            result.ShipTo = node.InnerText;
                        else if (node.Name.Equals("STADDRCD"))
                            result.StatementTo = node.InnerText;
                        else if (node.Name.Equals("USERDEF1"))
                            result.Type = node.InnerText;
                        else if (node.Name.Equals("USERDEF2"))
                            result.StudentStatus = node.InnerText;
                        else if (node.Name.Equals("INACTIVE"))
                            if (node.InnerText.Equals("1")) result.Inactive = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            result.CustomerAddress.AddressString = address1 + address2;
            return result;

        }

        public bool createOrUpdateCustomer(Customer c)
        {
            bool status = false;
            if ((c.CustomerName == null) || (c.CustomerID == null) || (c.CustomerClass == null)) return false;
            eConnectMethods eConnect = new eConnectMethods();
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<eConnect>");
                xml.Append("<RMCustomerMasterType>");
                xml.Append("<taUpdateCreateCustomerRcd>");
                xml.Append("<CUSTNMBR><![CDATA[" + c.CustomerID + "]]></CUSTNMBR>");
                xml.Append("<CUSTNAME><![CDATA[" + c.CustomerName + "]]></CUSTNAME>");
                xml.Append("<CUSTCLAS><![CDATA[" + c.CustomerClass + "]]></CUSTCLAS>");
                xml.Append("<INACTIVE><![CDATA[" + c.Inactive.GetHashCode() + "]]></INACTIVE>");

                if (c.ShortName != null) xml.Append("<SHRTNAME><![CDATA[" + c.ShortName + "]]></SHRTNAME>");
                if (c.StatementName != null) xml.Append("<STMTNAME><![CDATA[" + c.StatementName + "]]></STMTNAME>");
                if (c.ShipTo != null) xml.Append("<PRSTADCD><![CDATA[" + c.ShipTo + "]]></PRSTADCD>");
                if (c.StatementTo != null) xml.Append("<STADDRCD><![CDATA[" + c.StatementTo + "]]></<STADDRCD>");
                if (c.BillTo != null) xml.Append("<PRBTADCD><![CDATA[" + c.BillTo + "]]></PRBTADCD>");
                if (c.Type != null) xml.Append("<USERDEF1><![CDATA[" + c.Type + "]]></USERDEF1>");
                if (c.StudentStatus != null) xml.Append("<USERDEF2><![CDATA[" + c.StudentStatus + "]]></USERDEF2>");
                
/*
 *  This data is part of the address
 */
                if (c.CustomerAddress.AddressString != null)
                {
                    if (c.CustomerAddress.AddressString.Length < 50)
                    {
                        xml.Append("<ADDRESS1><![CDATA[" + c.CustomerAddress.AddressString + "]]></ADDRESS1>");
                    }
                    else
                    {
                        xml.Append("<ADDRESS1><![CDATA[" + c.CustomerAddress.AddressString.Substring(0, 50) + "]]></ADDRESS1>");
                        xml.Append("<ADDRESS2><![CDATA[" + c.CustomerAddress.AddressString.Substring(50, c.CustomerAddress.AddressString.Length - 50) + "]]></ADDRESS2>");
                    }
                }
                if (c.CustomerAddress.AddressCode != null) xml.Append("<ADRSCODE><![CDATA[" + c.CustomerAddress.AddressCode + "]]></ADRSCODE>");
                if (c.CustomerAddress.AddressContact != null) xml.Append("<CNTCPRSN><![CDATA[" + c.CustomerAddress.AddressContact + "]]></CNTCPRSN>");
                if (c.CustomerAddress.City != null) xml.Append("<CITY><![CDATA[" + c.CustomerAddress.City + "]]></CITY>");
                if (c.CustomerAddress.State != null) xml.Append("<STATE><![CDATA[" + c.CustomerAddress.State + "]]></STATE>");
                if (c.CustomerAddress.Country != null) xml.Append("<COUNTRY><![CDATA[" + c.CustomerAddress.Country + "]]></COUNTRY>");
                if (c.CustomerAddress.Zipcode != null) xml.Append("<ZIPCODE><![CDATA[" + c.CustomerAddress.Zipcode + "]]></ZIPCODE>");
                if (c.CustomerAddress.PhoneNumber1 != null) xml.Append("<PHNUMBR1><![CDATA[" + c.CustomerAddress.PhoneNumber1 + "]]></PHNUMBR1>");
                if (c.CustomerAddress.PhoneNumber2 != null) xml.Append("<PHNUMBR2><![CDATA[" + c.CustomerAddress.PhoneNumber2 + "]]></PHNUMBR2>");
                if (c.CustomerAddress.FaxNumber != null) xml.Append("<FAX><![CDATA[" + c.CustomerAddress.FaxNumber + "]]></FAX>");
                //CAUSES ERRORS IF COUNTRYCODE DOESNT EXIST
                //if (c.CustomerAddress.CountryCode != null) xml.Append("<CCODE>" + c.CustomerAddress.CountryCode + "</CCODE>");

                xml.Append("<UseCustomerClass>1</UseCustomerClass>");
                xml.Append("<UpdateIfExists>1</UpdateIfExists>");
                xml.Append("</taUpdateCreateCustomerRcd>");
                xml.Append("</RMCustomerMasterType>");
                xml.Append("</eConnect>");

                status = eConnect.eConnect_EntryPoint(sConnectionString, EnumTypes.ConnectionStringType.SqlClient,
                    xml.ToString(), EnumTypes.SchemaValidationType.None, "");
            }
            catch (eConnectException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return status;
        }
    }
}
