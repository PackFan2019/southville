using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Data;


namespace ReportCardGenerator.Utilities
{
    class EGPXMLParser
    {
        //This parser should use EasyGrade Pro 4.0 xml information 
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(EGPXMLParser));
        
        private static void addStudentsFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList nodeList = doc.GetElementsByTagName("stud_recordinfo");
            foreach (XmlNode node in nodeList)
            {
                Student stud = new Student();
                stud.StudentID = node["stud_id"].InnerText;
                stud.FirstName = node["stud_firstname"].InnerText;
                stud.LastName = node["stud_lastname"].InnerText;
                //System.Windows.Forms.MessageBox.Show(stud.StudentID);
                controller.addOrUpdateStudent(stud);
            }
        }

        private static void addSkillsFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            Period period = new Period();
            Skill skill = new Skill();
            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
                XmlNodeList studentinfo = primenode.SelectNodes("student");
                XmlNodeList gradename = primenode.SelectNodes("assignments/assignment");
                Dictionary<String, String> skillNames = new Dictionary<string, string>();
                Dictionary<String, String> categories = new Dictionary<string, string>();
                foreach (XmlNode test in gradename)
                {

                    skill.SkillID = test.ChildNodes[0].InnerText;
                    skill.SkillName = test.ChildNodes[1].InnerText;
                    skill.SkillCategory = test.ChildNodes[6].InnerText;
                    skillNames.Add(skill.SkillID, skill.SkillName);
                    categories.Add(skill.SkillID, skill.SkillCategory);
                }
                foreach (XmlNode test in peroidlist)
                {
                    period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                    period.PeriodName = test.ChildNodes[2].InnerText;
                    foreach (XmlNode student in studentinfo)
                    {
                        Student idgeter = new Student();
                        idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                        controller.addOrUpdatePeriod(idgeter, period);
                        XmlNodeList gradeinfo = student.SelectNodes("stud_grades/score");
                        foreach (XmlNode grade in gradeinfo)
                        {
                            Skill skilltostore = new Skill();
                            skilltostore.SkillID = grade.Attributes[0].InnerText;
                            skilltostore.SkillName = skillNames[grade.Attributes[0].InnerText];
                            skilltostore.SkillCategory = categories[grade.Attributes[0].InnerText];
                            if (skilltostore.SkillCategory.Equals("Remarks"))
                            {
                                break;
                            }
                            else
                            {
                                skilltostore.NumericGrade = double.Parse(grade.ChildNodes[1].InnerText);
                                skilltostore.LetterGrade = grade.ChildNodes[2].InnerText;
                            }
                          
                            controller.addOrUpdateSkill(idgeter, skilltostore, period);
                            
                            
                            //System.Windows.Forms.MessageBox.Show(period.PeriodID + " " + period.PeriodName + " " + idgeter.StudentID + " " + skilltostore.SkillID + skilltostore.SkillName + " " + skilltostore.LetterGrade + " " + skilltostore.NumericGrade);
                        }
                    }
                }
            }
        }

        private static void addGradesFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            Period period = new Period();
            Grade Grade = new Grade();
            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
                XmlNodeList studentinfo = primenode.SelectNodes("student");
                XmlNodeList gradename = primenode.SelectNodes("assignments/assignment");
                Dictionary<String, String> categories = new Dictionary<string, string>();
                foreach (XmlNode test in gradename)
                {
                    Grade.SubjectCategory = test.ChildNodes[6].InnerText;
                    Grade.SubjectID = test.ChildNodes[0].InnerText;
                    categories.Add(Grade.SubjectID, Grade.SubjectCategory);
                }
                foreach (XmlNode test in peroidlist)
                {
                    period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                    period.PeriodName = test.ChildNodes[2].InnerText;
                    Grade.SubjectName = test.ChildNodes[0].InnerText;
                    foreach (XmlNode student in studentinfo)
                    {
                        Student idgeter = new Student();
                        idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                        controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                        XmlNodeList gradeinfo = student.SelectNodes("stud_grades/score");
                        foreach (XmlNode grade in gradeinfo)
                        {
                            Grade ToStoreGrade = new Grade();
                            ToStoreGrade.SubjectID = grade.Attributes[0].InnerText;
                            ToStoreGrade.SubjectCategory = categories[grade.Attributes[0].InnerText];
                            ToStoreGrade.NumericGrade = double.Parse(grade.ChildNodes[1].InnerText);
                            ToStoreGrade.LetterGrade = grade.ChildNodes[2].InnerText;

                            System.Windows.Forms.MessageBox.Show(period.PeriodID + " " + period.PeriodName + " " + idgeter.StudentID + " " + ToStoreGrade.SubjectID + ToStoreGrade.SubjectName + " " + ToStoreGrade.LetterGrade + " " + ToStoreGrade.NumericGrade);
                        }
                    }
                }
            }
        }

        private static void addAttendanceFromXML(IStudentController controller, XmlDocument doc)
        {

            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            Period pd = new Period();
            foreach (XmlNode primenode in primelist)
            {
                
            }
        }

        private static void addCommentsFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            Period period = new Period();
            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
                XmlNodeList studentinfo = primenode.SelectNodes("student");
                foreach (XmlNode test in peroidlist)
                {
                    period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                    period.PeriodName = test.ChildNodes[2].InnerText;
                    foreach (XmlNode student in studentinfo)
                    {
                        Student idgeter = new Student();
                        idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                        controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                        XmlNodeList gradeinfo = student.SelectNodes("stud_grades/score");
                        foreach (XmlNode grade in gradeinfo)
                        {
                            Comment cm = new Comment();
                            cm.CommentText = grade.LastChild.InnerText;
                            controller.addOrUpdateComment(controller.getStudent(idgeter.StudentID),cm,period);
                        }
                    }
                }
            }
        }
        public static void parseHomeroomXML(IStudentController controller, XmlDocument doc)
        {
            addStudentsFromXML(controller, doc);
            addSkillsFromXML(controller, doc);
            addCommentsFromXML(controller, doc);
            //addCommentsFromXML(controller,doc);
            //addAttendanceFromXML(controller,doc);

        }

        public static void parseGradebookXML(IStudentController controller, XmlDocument doc)
        {
            //Adds the relevant information from the Xmldocument
            addStudentsFromXML(controller, doc);
            addGradesFromXML(controller, doc);
        }
    }
}
