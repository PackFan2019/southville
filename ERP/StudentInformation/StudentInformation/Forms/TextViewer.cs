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
    public partial class TextViewer : Form
    {
        public TextViewer()
        {
            InitializeComponent();
        }
        public void setText(String s)
        {
            txtMainArea.Text = s;
        }
        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMainArea.Text);
        }
    }
}
