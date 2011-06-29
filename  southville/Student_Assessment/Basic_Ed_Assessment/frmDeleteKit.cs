using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentAssessment
{
    public enum DeleteKitDialogResult
    {
        DeleteComponent,
        DeleteAll,
        No
    }

    public partial class frmDeleteKit : Form
    {
        DeleteKitDialogResult response;

        public DeleteKitDialogResult Response
        {
            get { return response; }
        }
        
        public frmDeleteKit(string kitItemNo)
        {
            InitializeComponent();
            lblPrompt.Text = String.Format("This item is a component of kit {0}. \n\nDo you want to continue?", kitItemNo);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            response = DeleteKitDialogResult.No;
            this.Close();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            response = DeleteKitDialogResult.DeleteAll;
            this.Close();
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            response = DeleteKitDialogResult.DeleteComponent;
            this.Close();
        }
    }
}