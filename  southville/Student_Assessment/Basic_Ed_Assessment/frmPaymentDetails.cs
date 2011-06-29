using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudentAssessment.Objects;
using System.Configuration;
using System.Collections.Specialized;
using StudentAssessment.Adapter;

namespace StudentAssessment
{
    public partial class frmPaymentDetails : Form
    {
        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;

        frmAssessment mainWindow = null;

        Transaction assessment = new Transaction();
        Schedule schedule = new Schedule();
        int selectedIndex = -1;

        public Schedule GetSchedule()
        {
            return schedule;
        }

        public frmPaymentDetails(Transaction assessment, frmAssessment mainWindow)
        {           
            InitializeComponent();
            this.assessment = assessment;
            this.schedule = assessment.Schedule;
            this.mainWindow = mainWindow;
        }

        private void frmPaymentDetails_Load(object sender, EventArgs e)
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

        private void lstPaymentSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPaymentSchedule.SelectedItems.Count == 1)
            {
                DateTime dueDate = Convert.ToDateTime(lstPaymentSchedule.SelectedItems[0].Text);

                if (schedule.GetDue(dueDate) != null)
                {
                    dtpDueDate.Value = schedule.GetDue(dueDate).Date;
                    txtAmount.Text = Convert.ToString(schedule.GetDue(dueDate).Amount);

                    btnSaveDate.Enabled = true;
                    dtpDueDate.Enabled = true;

                    selectedIndex = lstPaymentSchedule.SelectedItems[0].Index;
                }
            }
            else
            {
                dtpDueDate.Value = DateTime.Now.Date;
                dtpDueDate.Enabled = false;

                txtAmount.ReadOnly = true;
                txtAmount.Clear();

                btnSaveDate.Enabled = false;

                selectedIndex = -1;
            }
        }

        private void btnSaveDate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= schedule.Count - 1; i++)
            {
                schedule.GetDue(selectedIndex).Date = dtpDueDate.Value;
            }

            btnSaveDate.Enabled = false;

            dtpDueDate.Value = DateTime.Now.Date;
            dtpDueDate.Enabled = false;
            txtAmount.Clear();

            btnSaveDate.Enabled = false;

            selectedIndex = -1;

            populatePaymentSchedule();
            populateTotalAmount();
        }

        private void frmPaymentDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.UpdatePaymentSchedule(schedule);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}