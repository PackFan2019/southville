using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReportCardGenerator.Views;
using ReportCardGenerator.Exceptions;
using ReportCardGenerator.Controller;
namespace ReportCardGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            
        }
        
    }
}
