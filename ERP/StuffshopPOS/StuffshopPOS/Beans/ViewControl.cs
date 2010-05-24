using System;
using System.Collections.Generic;
using System.Text;
using StuffshopPOS.Data;

namespace StuffshopPOS.Beans
{
    class ViewControl
    {
        private string date1 = "none";
        private string date2 = "none";
        private string customer = "none";
        private int valuecontainer;
        private decimal valuecontainer2;

        public void datecaller()
        {
            DateDialog start = new DateDialog("Enter Start Date");
            start.ShowDialog();
            date1 = start.dateselected;
            DateDialog end = new DateDialog("Enter End Date");
            end.ShowDialog();
            date2 = end.dateselected;
            CustomerSelectDialog custtt = new CustomerSelectDialog("Please Select Customer");
            custtt.ShowDialog();
            customer = custtt.custselected;
            GPData.ReportData(date1, date2, customer);
        }

        public void reportcall()
        {
            ReportView rv = new ReportView();
            ReportSet ds = new ReportSet();

            foreach (ReportContainerClass rc in GPData.reportlist)
            {
                if (rc.soptype == 4)
                {
                    valuecontainer = (rc.quantity - (rc.quantity * 2));
                    valuecontainer2 = (rc.price - (rc.price * 2));
                }
                else
                {
                    valuecontainer = rc.quantity;
                    valuecontainer2 = rc.price;
                }
                DataRow cRow = ds.ReportViewer.NewRow();
                cRow["SOPNUMBER"] = rc.sopnumber;
                cRow["ITEMNUMBER"] = rc.itemnumber;
                cRow["ITEMDESCRIPTION"] = rc.itemDescription;
                cRow["CUSTOMERNAME"] = rc.custname;
                cRow["QUANTITY"] = valuecontainer;
                cRow["DOCDATE"] = rc.docdate;
                cRow["PRICE"] = valuecontainer2;
                ds.ReportViewer.Rows.Add(cRow);

            }
            rv.DataDefinition.FormulaFields["startDate"].Text = "\"" + date1 + "\"";
            rv.DataDefinition.FormulaFields["End Date"].Text = "\"" + date2 + "\"";
            rv.DataDefinition.FormulaFields["Customer"].Text = "\"" + customer + "\"";
            rv.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rv;
            crystalReportViewer1.Refresh();
        }


    }
}
