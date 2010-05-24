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
    public partial class CustomerSelectDialog : Form
    {
        public string custselected = "none";
        //PriceGroupReportViewer pgrv = new PriceGroupReportViewer();
        public CustomerSelectDialog(String Title)
        {
            InitializeComponent();
            this.Text = Title;
            
        }

        private void customselect_Load(object sender, EventArgs e)
        {
            GPData.customergetter();
            foreach(customer cc in GPData.custnames)
            {
                comboBox1.Items.Add(cc.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                button1.DialogResult = DialogResult.No;
                MessageBox.Show("Please Select a Customer", "Error");
            }
            else
            {

            custselected = comboBox1.SelectedItem.ToString();
            
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            custselected = "All";
            GPData.ReportAllData(Date.date1, Date.date2);            
        }
    }
}
