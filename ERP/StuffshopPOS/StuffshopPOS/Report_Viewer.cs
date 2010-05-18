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
        public Report_Viewer()
        {
            InitializeComponent();
        }

        private void Report_Viewer_Load(object sender, EventArgs e)
        {
            GPData.ReportData();

            ReportView rv = new ReportView();
            ReportSet ds = new ReportSet();
            DataTable RPtable = ds.Tables.Add("ReportViewer");
            RPtable.Columns.Add("SOPNUMBER", Type.GetType("System.String"));
            RPtable.Columns.Add("ITEMNUMBER", Type.GetType("System.String"));
            RPtable.Columns.Add("ITEMDESCRIPTION", Type.GetType("System.String"));
            RPtable.Columns.Add("CUSTOMERNAME", Type.GetType("System.String"));
            RPtable.Columns.Add("QUANTITY", Type.GetType("System.Int32"));
            RPtable.Columns.Add("DOCDATE", Type.GetType("System.DateTime"));
            RPtable.Columns.Add("PRICE", Type.GetType("System.Decimal"));

            foreach (ReportContainerClass rc in GPData.reportlist)
            {
                DataRow cRow = RPtable.NewRow();
                cRow["SOPNUMBER"] = rc.sopnumber;
                cRow["ITEMNUMBER"] = rc.itemnumber;
                cRow["ITEMDESCRIPTION"] = rc.itemDescription;
                cRow["CUSTOMERNAME"] = rc.custname;
                cRow["QUANTITY"] = rc.quantity;
                cRow["DOCDATE"] = rc.docdate;
                cRow["PRICE"] = rc.price;
                RPtable.Rows.Add(cRow);

            }
            rv.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rv;
            crystalReportViewer1.Refresh();
        }

    }
}
