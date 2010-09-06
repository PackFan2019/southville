using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportCardGenerator.Views
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PBar.Minimum = 0;
            PBar.Maximum = 100;
            PBar.Step = 1;
            PBar.PerformStep();
            val.Text = PBar.Value.ToString();
            if (int.Parse(val.Text) == 100)
            {
                this.Close();
            }

        }
    }
}
