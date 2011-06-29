using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DynamicsGPLogin;

namespace StudentAssessment
{
    public partial class frmLogin : Form
    {
        Login login;
        bool authenticated = false;
        static frmLogin instance;

        private frmLogin()
        {
            InitializeComponent();
        }

        public static frmLogin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new frmLogin();
                }
                return instance;
            }
        }

        public bool Authenticated
        {
            get
            {
                return authenticated;
            }            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (udcGPLogin1.IsCompanySelected() && udcGPLogin1.IsConnected)
            {
                login = udcGPLogin1.GetLogin();
                authenticated = true;
                this.Close();
            }
            else
            {
                authenticated = false;
                MessageBox.Show("Please fill in the required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Login GetLogin()
        {
            return login;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}