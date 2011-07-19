using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Southville.GP.Data;
using Southville.GP.Beans;
namespace StudentInformation.Forms
{
    public partial class EnrollmentReportDialog : Form
    {
        public String section = null;
        public String level = null;
        public String enrollmentStatus = null;
        public EnrollmentReportDialog()
        {
            InitializeComponent();
        }

        private void checkBoxLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLevel.Checked)
            {
                textBoxLevel.Enabled = true;
                textBoxLevel.Text = "";
            }
            else
            {
                textBoxLevel.Enabled = false;
                textBoxLevel.Text = "Any level";
            }
        }

        private void checkBoxSection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSection.Checked)
            {
                textBoxSection.Enabled = true;
                textBoxSection.Text = "";
            }
            else
            {
                textBoxSection.Enabled = false;
                textBoxSection.Text = "Any section";
            }
        }

        private void EnrollmentReportDialog_Load(object sender, EventArgs e)
        {
            comboBoxEnrollment.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            enrollmentStatus = comboBoxEnrollment.Text;
            level = null;
            section = null;
            if (checkBoxLevel.Checked) level = textBoxLevel.Text;
            if (checkBoxSection.Checked) section = textBoxSection.Text;
        }
    }
}
