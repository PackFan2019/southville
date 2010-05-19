using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StuffshopPOS.Data;
using StuffshopPOS.Beans;

namespace StuffshopPOS
{
    public partial class Report_Viewer : Form
    {

        private string date1 = "none";
        private string date2 = "none";
        private string customer = "none";

        public Report_Viewer()
        {
            dateselect start = new dateselect("Enter Start Date");
            start.ShowDialog();
            date1 = start.dateselected;
            dateselect end = new dateselect("Enter End Date");
            end.ShowDialog();
            date2 = end.dateselected;
            customselect custtt = new customselect("Please Select Customer");
            custtt.ShowDialog();
            customer = custtt.custselected;

            InitializeComponent();
            GPData.ReportData(date1,date2,customer);
        }

        private void Report_Viewer_Load(object sender, EventArgs e)
        {
         

            ReportView rv = new ReportView();
            ReportSet ds = new ReportSet();
            foreach (ReportContainerClass rc in GPData.reportlist)
            {
                DataRow cRow = ds.ReportViewer.NewRow();
                cRow["SOPNUMBER"] = rc.sopnumber;
                cRow["ITEMNUMBER"] = rc.itemnumber;
                cRow["ITEMDESCRIPTION"] = rc.itemDescription;
                cRow["CUSTOMERNAME"] = rc.custname;
                cRow["QUANTITY"] = rc.quantity;
                cRow["DOCDATE"] = rc.docdate;
                cRow["PRICE"] = rc.price;
                ds.ReportViewer.Rows.Add(cRow);

            }
            rv.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rv;
            crystalReportViewer1.Refresh();
        }

    }
}
