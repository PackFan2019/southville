using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace ReportCardGenerator.Utilities
{
    public class FileData
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(FileData));
        public static XmlDocument getXmlFromPath(String filePath)
        {
            //Use log.Debug for very arbitrary statements e.g. starting
            if (log.IsDebugEnabled) log.Debug("Retrieving XML from " + filePath);
            try
            {
                //Put code here
            }
            catch (Exception e)
            {
                //Use log.Error for exceptions (Error is always outputted!)
                if (log.IsErrorEnabled) log.Error(e.Message);
            }
            return null;
        }
    }
}
