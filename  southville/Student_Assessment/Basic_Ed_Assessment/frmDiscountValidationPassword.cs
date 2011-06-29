using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentAssessment
{
    public partial class frmDiscountValidationPassword : Form
    {
        string password;

        public string Password
        {
            get { return password; }
        }
        public frmDiscountValidationPassword()
        {            
            InitializeComponent();
            password = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            password = txtPassword.Text;
            this.Close();
        }
    }
}