using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace StudentAssessment.Common
{
    public static class Prompt
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public static DialogResult Confirm(string message)
        {
            return MessageBox.Show(message,
                    Application.ProductName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
        }
    }
}
