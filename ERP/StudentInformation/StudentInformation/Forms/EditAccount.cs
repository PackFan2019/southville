using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentInformation.Forms
{
    public partial class Edit_Account : Form
    {
        public static String acccount = "";
        public Edit_Account()
        {
            InitializeComponent();
        }

        private void Edit_Account_Load(object sender, EventArgs e)
        {
            label1.Text = "You editing the account for " + acccount;
        }
    }
}
