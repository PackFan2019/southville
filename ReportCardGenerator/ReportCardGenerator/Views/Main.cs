using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Controller;

namespace ReportCardGenerator.Views
{
    public partial class Main : Form, IView
    {

        public Main()
        {
            InitializeComponent();
        }

        public void updateGUI()
        {
            //This gets called when the controller wants to update
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //Register this view with the frontcontroller   
            FrontController.getInstance().registerView(this);
            
        }
    }
}
