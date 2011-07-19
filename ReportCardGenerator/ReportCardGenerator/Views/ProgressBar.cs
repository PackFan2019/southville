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
            //val.Text = PBar.Value.ToString();
            int percent = (int)(((double)PBar.Value / (double)PBar.Maximum) * 100);
            PBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(PBar.Width / 2 - 10, PBar.Height / 2 - 7));
            if (percent == 100)
            {
                this.Hide();
            }

        }
    }
}
