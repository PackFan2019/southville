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
    public partial class StudentType : Form
    {
        public String year = null;
        public String studType = null;
        public StudentType()
        {
            InitializeComponent();
        }

        private void studTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void StudentType_Load(object sender, EventArgs e)
        {
            getYears();
            studTypeCb.SelectedIndex = 0;
            yearCb.SelectedIndex = 4;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            studType = studTypeCb.Text;
            year = yearCb.Text;
        }
        private int getYears()
        {
            int year = 2007;
            int addedYear = DateTime.Now.Year + 4;
            while(year <= addedYear)
            {
                yearCb.Items.Add(year);
                year++;
            }
            return year;
        }
    }
}
