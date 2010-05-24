using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StuffshopPOS.Beans;
using StuffshopPOS.Data;

namespace StuffshopPOS
{
    public partial class PriceGroupReportViewer : Form
    {

        public static string date1 = "none";
        public static string date2 = "none";
        private string customer = "none";
        private int valuecontainer;
        private decimal valuecontainer2;
        private string PGroupChecker;

        public PriceGroupReportViewer()
        {
            DateDialog start = new DateDialog("Enter Start Date");
            start.StartPosition = FormStartPosition.CenterScreen;
            start.ShowDialog();
            Date.date1= start.dateselected;

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
            //GPData.ReportAllData(date1, date2);
        }

        private void PriceGroupReportViewer_Load(object sender, EventArgs e)
        {
            PriceGroup rv = new PriceGroup();
            ReportSet ds = new ReportSet();

            foreach (ReportContainerClass rc in GPData.reportlist)
            {

                if (rc.pricegroup == "")
                {
                    PGroupChecker = "No PriceGroup Items";
                }
                else
                {
                    PGroupChecker = rc.pricegroup;
                }
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
                cRow["PRICEGROUP"] = PGroupChecker;
                cRow["QUANTITY"] = valuecontainer;
                cRow["PRICE"] = valuecontainer2;
                ds.ReportViewer.Rows.Add(cRow);

            }
            rv.DataDefinition.FormulaFields["startDate"].Text = "\"" + Date.date1 + "\"";
            rv.DataDefinition.FormulaFields["End Date"].Text = "\"" + Date.date2 + "\"";
            rv.DataDefinition.FormulaFields["Customer"].Text = "\"" + customer + "\"";
            rv.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rv;
            crystalReportViewer1.Refresh();
        }

        private void PriceGroupReportViewer_Leave(object sender, EventArgs e)
        {
       
        }

        private void PriceGroupReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            GPData.reportlist.Clear();
        }
    }
}
