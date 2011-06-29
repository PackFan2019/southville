using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Objects;

namespace StudentAssessment
{
    public partial class frmViewPaymentDetails : Form
    {
        Transaction assessment = new Transaction();
        Schedule schedule = new Schedule();
        public frmViewPaymentDetails(Transaction transaction)
        {
            InitializeComponent();
            this.assessment = transaction;
            this.schedule = assessment.Schedule;            
        }

        private void frmViewPaymentDetails_Load(object sender, EventArgs e)
        {
            initializePaymentSchedule();
            clearPaymentSchedule();
            populatePaymentSchedule();
            populateTotalAmount();
        }


        private void clearPaymentSchedule()
        {
            lstPaymentSchedule.Items.Clear();
        }

        private void populatePaymentSchedule()
        {
            lstPaymentSchedule.Items.Clear();
            for (int i = 0; i <= schedule.Count - 1; i++)
            {
                lstPaymentSchedule.Items.Add(
                new ListViewItem(
                new string[] {schedule.GetDue(i).Date.ToShortDateString()
                     , Convert.ToString(schedule.GetDue(i).Amount)
                 }
                 ));
            }
        }

        private void populateTotalAmount()
        {
            txtTotal.Text = Convert.ToString(assessment.TotalAmount);
        }

        private void initializePaymentSchedule()
        {
            lstPaymentSchedule.Columns.Clear();
            lstPaymentSchedule.Columns.Add("Due", 100, HorizontalAlignment.Left);
            lstPaymentSchedule.Columns.Add("Amount", 90, HorizontalAlignment.Right);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}