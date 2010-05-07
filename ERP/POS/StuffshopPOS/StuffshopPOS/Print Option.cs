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
    public partial class Print_Option : Form
    {
        Form1 f = new Form1();
        public Print_Option()
        {
            InitializeComponent();
        }

        private void PnSbtn_Click(object sender, EventArgs e)
        {
            
            f.toolStripMenuItem3_Click(sender, e);
            salesReportentry();
            this.Close();

            
        }

        private void salesReportentry()
        {
            //SalesEntry se = new SalesEntry();
            //se.ItemCode = f.itemCode;
            //se.Price = f.itemPrice;
            //se.Quantity = f.quantity;
            //FileData.saveToFile(SalesEntry.transId, se);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            salesReportentry();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}