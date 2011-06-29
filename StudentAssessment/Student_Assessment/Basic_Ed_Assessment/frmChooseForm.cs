using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Reflection;

namespace StudentAssessment
{
    public enum AssessmentForm
    {
        BasicEducation = 0,
        College = 1
    }

    public partial class frmChooseForm : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        AssessmentForm selectedAssessmentForm;

        public AssessmentForm SelectedAssessmentForm
        {
            get { return selectedAssessmentForm; }
            set { selectedAssessmentForm = value; }
        }

        public frmChooseForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            selectedAssessmentForm = (AssessmentForm)lstForms.SelectedIndex;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmChooseForm_Load(object sender, EventArgs e)
        {
            //set default asssessment form
            lstForms.SelectedIndex = (int)AssessmentForm.BasicEducation;
        }

        private void lstForms_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }
    }
}