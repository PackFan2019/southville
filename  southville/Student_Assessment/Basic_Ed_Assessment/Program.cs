using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using log4net;

namespace StudentAssessment
{
    static class Program
    {
        //TODO: Refactor
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin LoginForm = frmLogin.Instance;
            frmMain MainForm;

            Application.Run(LoginForm);

            if (LoginForm.Authenticated)
            {
                MainForm = new frmMain();
                Application.Run(MainForm);
            }
        }
    }
}