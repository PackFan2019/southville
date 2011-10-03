using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Controller;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;

namespace ReportCardGenerator.Views
{
    public partial class ReportCardOption : Form
    {
        IGradeController gradeCont = new GradeController();
        
        public ReportCardOption()
        {
            InitializeComponent();
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            if (rptCardcb.Text != "")
            {
            StudReportCard.source = rptCardcb.Text;
               
            Form.ActiveForm.Close();
            StudReportCard rptCard = new StudReportCard();
            rptCard.Show();
            } else { MessageBox.Show("No Report Card is selected. Please select one","Null Report Card",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
    }
}
