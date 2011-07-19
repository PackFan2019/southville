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
    public partial class LetterOfRequestDialog : Form
    {
        private SelectStudents dialog = new SelectStudents();
        public String schoolName = "";
        public String schoolAddress = "";
        public String attainment = "";
        public String schoolYear = "";
        public LetterOfRequestDialog()
        {
            InitializeComponent();
        }

        private void LetterOfRequestDialog_Load(object sender, EventArgs e)
        {
            for (int x = 2005; x <= DateTime.Now.Year + 1; x++)
            {
                schoolYearComboBox.Items.Add(x + "-" + (x + 1));
            }
        }
        public void setSchoolName(String name)
        {
            this.schoolNameTextbox.Text = name;
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            schoolName = schoolNameTextbox.Text;
            schoolAddress = schoolAddressTextbox.Text;
            attainment = attainmentComboBox.Text;
            schoolYear = schoolYearComboBox.Text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }
    }
}
