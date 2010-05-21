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
        private int valuecontainer;
        private decimal valuecontainer2;

        
        public Report_Viewer()
        {
           
            DateDialog start = new DateDialog("Enter Start Date");
            start.StartPosition = FormStartPosition.CenterScreen;
            start.ShowDialog();
            Date.date1 = start.dateselected;
            DateDialog end = new DateDialog("Enter End Date");
            end.StartPosition = FormStartPosition.CenterScreen;
            end.ShowDialog();
            Date.date2 = end.dateselected;
            CustomerSelectDialog custtt = new CustomerSelectDialog("Please Select Customer");
            custtt.StartPosition = FormStartPosition.CenterScreen;
            custtt.ShowDialog();
            customer = custtt.custselected;
            
            InitializeComponent();
            GPData.ReportData(Date.date1, Date.date2, customer);
        }
        private void Report_Viewer_Load(object sender, EventArgs e)
        {
            LoadCrystalReport();

        }
        private void LoadCrystalReport()
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
                cRow["CUSTOMERNAME"] = rc.custname;
                cRow["QUANTITY"] = valuecontainer;
                cRow["PRICE"] = valuecontainer2;
                ds.ReportViewer.Rows.Add(cRow);

            }
            ReportContainerClass rc1 = new ReportContainerClass();
            rv.DataDefinition.FormulaFields["startDate"].Text = "\"" + Date.date1 + "\"";
            rv.DataDefinition.FormulaFields["End Date"].Text = "\"" + Date.date2 + "\"";
            rv.DataDefinition.FormulaFields["Customer"].Text = "\"" + customer + "\"";
            rv.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rv;
            crystalReportViewer1.Refresh();
        }
        private void Report_Viewer_Leave(object sender, EventArgs e)
        {

        }

        private void Report_Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            GPData.reportlist.Clear();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadCrystalReport();
        }

    }
}
