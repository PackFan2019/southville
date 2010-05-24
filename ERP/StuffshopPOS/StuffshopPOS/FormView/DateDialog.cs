using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StuffshopPOS
{
    public partial class DateDialog : Form
    {
        public string dateselected = "none";
        public DateDialog(String Title)
        {
            InitializeComponent();
            this.Text = Title;
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateselect_Load(object sender, EventArgs e)
        {
            label2.Text = monthCalendar1.SelectionStart.ToShortDateString();
            dateselected = label2.Text;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label2.Text = monthCalendar1.SelectionStart.ToShortDateString();
            dateselected = label2.Text;
        }
    }
}
