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
            Period pd = new Period();
            Skill skill = new Skill();
            XmlNodeList studentid = doc.GetElementsByTagName("stud_id");
            XmlNodeList periodid = doc.GetElementsByTagName("cr_termnum");
            XmlNodeList periodname = doc.GetElementsByTagName("cr_termlabel");
            XmlNodeList skillname = doc.GetElementsByTagName("cr_classsubjectname");
            XmlNodeList skillcategandid = doc.GetElementsByTagName("cr_data");
            XmlNodeList skillletgrade = doc.GetElementsByTagName("score_grade");
            XmlNodeList skillnumgrade = doc.GetElementsByTagName("score_percent");

            for (int x = 0; x < studentid.Count; x++)
            {
                skill.SkillName = skillname[x].InnerText;
                foreach (XmlNode node in skillcategandid)
                {
                    if (node.Attributes["label"].Value.ToUpper().Equals("SUBJECTID"))
                    {
                        skill.SkillID = node.InnerText;
                    }
                    if (node.Attributes["label"].Value.ToUpper().Equals("SUBJECTCATEGORY"))
                    {
                        skill.SkillCategory = node.InnerText;
                    }
                }
                skill.NumericGrade = double.Parse(skillnumgrade[x].InnerText);
                skill.LetterGrade = skillletgrade[x].InnerText;
                pd.PeriodID = int.Parse(periodid[x].InnerText);
                pd.PeriodName = periodname[x].InnerText;
                controller.addOrUpdatePeriod(controller.getStudent(studentid[x].InnerText), pd);
                controller.addOrUpdateSkill(controller.getStudent(studentid[x].InnerText), skill, pd);
            }

            //Use the IStudentController to pass information
        }

        private static void addGradesFromXML(IStudentController controller, XmlDocument doc)
        {
            Grade gd = new Grade();
            Period pd = new Period();
            XmlNodeList studentid = doc.GetElementsByTagName("stud_id");
            XmlNodeList periodid = doc.GetElementsByTagName("cr_termnum");
            XmlNodeList periodname = doc.GetElementsByTagName("cr_termlabel");
            XmlNodeList gradename = doc.GetElementsByTagName("ass_name");
            XmlNodeList gradeid = doc.GetElementsByTagName("ass_id");
            XmlNodeList gradecateg = doc.GetElementsByTagName("ass_catname");
            XmlNodeList gradenumgrade = doc.GetElementsByTagName("score_percent");
            XmlNodeList gradelettergrade = doc.GetElementsByTagName("score_grade");

            for (int i = 0; i < studentid.Count; i++)
            {
                gd.SubjectName = gradename[i].InnerText;
                gd.SubjectID = gradeid[i].InnerText;
                gd.SubjectCategory = gradecateg[i].InnerText;
                gd.NumericGrade = double.Parse(gradenumgrade[i].InnerText);
                gd.LetterGrade = gradelettergrade[i].InnerText;
                pd.PeriodID = int.Parse(periodid[i].InnerText);
                pd.PeriodName = periodname[i].InnerText;
                controller.addOrUpdateGrade(controller.getStudent(studentid[i].InnerText), gd, pd);

            }
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
