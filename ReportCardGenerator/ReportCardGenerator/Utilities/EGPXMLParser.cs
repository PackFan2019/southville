using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;


namespace ReportCardGenerator.Utilities
{
    class EGPXMLParser
    {
        //This parser should use EasyGrade Pro 4.0 xml information 
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(EGPXMLParser));
        
        private static void addStudentsFromXML(IStudentController controller, XmlDocument doc)
        {
            Student stud = new Student();
            XmlNodeList studid = doc.GetElementsByTagName("stud_id");
            XmlNodeList studFNAME = doc.GetElementsByTagName("stud_firstname");
            XmlNodeList studLNAME = doc.GetElementsByTagName("stud_lastname");
            for (int i = 0; i < studid.Count; i++)
            {
                stud.StudentID = studid[i].InnerText;
                stud.FirstName = studFNAME[i].InnerText;
                stud.LastName = studLNAME[i].InnerText;
                controller.addOrUpdateStudent(stud);
            }

            //Use the IStudentController to pass information
            //e.g. controller.addOrUpdateStudent(s)..
        }

        private static void addSkillsFromXML(IStudentController controller, XmlDocument doc)
        {


            //Use the IStudentController to pass information
        }

        private static void addGradesFromXML(IStudentController controller, XmlDocument doc)
        {
            //Use the IStudentController to pass information
        }

        private static void addAttendanceFromXML(IStudentController controller, XmlDocument doc)
        {
            //Use the IStudentController to pass information
        }

        private static void addCommentsFromXML(IStudentController controller, XmlDocument doc)
        {
            //Use the IStudentController to pass information
        }
        public static void parseHomeroomXML(IStudentController controller, XmlDocument doc)
        {
            //Adds the relevant information from the Xmldocument
            //Call relevant functions e.g. List<Student> students = getStudentsFromXML(doc)   
            //foreach (Student s in students) controller.add(s) 
            //if (log.IsDebugEnabled) log.Debug("Parsing homeroom XML");

            ////Use this style to pass students
            //if (log.IsDebugEnabled) log.Debug("Adding students from XML");
            addStudentsFromXML(controller, doc);
            //if (log.IsDebugEnabled) log.Debug("End parsing homeroom XML");
        }

        public static void parseGradebookXML(IStudentController controller, XmlDocument doc)
        {
            //Adds the relevant information from the Xmldocument
            addStudentsFromXML(controller, doc);
        }
    }
}
