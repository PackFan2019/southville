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
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(EGPXMLParser));

        private static void addStudentsFromXML(IStudentController controller, XmlDocument doc)
        {
            String adviser = "";
            XmlNodeList nodeList = doc.GetElementsByTagName("stud_recordinfo");
            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList periodList = primenode.SelectNodes("classrecord");
                foreach (XmlNode adviseNode in periodList)
                {
                    adviser = adviseNode.ChildNodes[8].InnerText;
                }
            }
            foreach (XmlNode node in nodeList)
            {
                Student stud = new Student();
                stud.StudentID = node["stud_id"].InnerText;
                stud.FirstName = node["stud_firstname"].InnerText;
                stud.LastName = node["stud_lastname"].InnerText;
                stud.Section = node.ChildNodes[8].InnerText;
                stud.Level = node.ChildNodes[7].InnerText;
                stud.Adviser = adviser;
                controller.addOrUpdateStudent(stud);
            }
        }

        private static void addSkillsFromXML(IStudentController controller, XmlDocument doc)
        {

            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");

            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList periodList = primenode.SelectNodes("classrecord");
                XmlNodeList studentinfo = primenode.SelectNodes("student");
                XmlNodeList gradename = primenode.SelectNodes("standards/standard");
                Dictionary<String, String> skillNames = new Dictionary<string, string>();
                foreach (XmlNode test in gradename)
                {
                    Skill skill = new Skill();
                    skill.SkillID = test.ChildNodes[0].InnerText;
                    skill.SkillName = test.ChildNodes[3].InnerText;
                    skillNames.Add(skill.SkillID, skill.SkillName);
                }
                    

                        foreach (XmlNode student in studentinfo)
                        {
                            //String adviser;
                            Student idgeter = new Student();
                            idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                            idgeter.LastName = student.ChildNodes[0].ChildNodes[3].InnerText;
                            idgeter.FirstName = student.ChildNodes[0].ChildNodes[4].InnerText;
                            XmlNodeList gradeinfo = student.SelectNodes("stud_grades/stud_stdgrades");

                            foreach (XmlNode test in periodList)
                            {
                                Period period = new Period();
                                period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                                period.PeriodName = test.ChildNodes[2].InnerText;
                                //adviser = test.ChildNodes[8].InnerText;
                                controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                            foreach (XmlNode grade in gradeinfo)
                            {
                                if (grade.HasChildNodes == true)
                                {
                                    XmlNodeList stdgradeinfo = grade.SelectNodes("stud_stdgrade");

                                    foreach (XmlNode stdgrade in stdgradeinfo)
                                    {

                                        Skill skilltostore = new Skill();
                                        skilltostore.SkillID = stdgrade.ChildNodes[0].InnerText;
                                        skilltostore.SkillName = skillNames[skilltostore.SkillID];
                                        if (stdgrade.ChildNodes[1].InnerText == "" || stdgrade.ChildNodes[2].InnerText == "")
                                        {
                                            skilltostore.NumericGrade = 0.0;
                                            skilltostore.LetterGrade = "N/A";
                                        }
                                        else
                                        {
                                            skilltostore.NumericGrade = double.Parse(stdgrade.ChildNodes[1].InnerText);
                                            skilltostore.LetterGrade = stdgrade.ChildNodes[2].InnerText;
                                        }
                                        //idgeter.Adviser = adviser;
                                        controller.addOrUpdateSkill(controller.getStudent(idgeter.StudentID), skilltostore, controller.getPeriod(controller.getStudent(idgeter.StudentID), period.PeriodID));

                                    }

                                }
                                else
                                {
                                    break;
                                }

                            }
                    }
                }
            }
        }

        private static void addGradesFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
                XmlNodeList studentinfo = primenode.SelectNodes("student");
                XmlNodeList gradename = primenode.SelectNodes("assignments/assignment");

                foreach (XmlNode student in studentinfo)
                {
                    Student idgeter = new Student();
                    idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                    XmlNodeList gradeinfo = student.SelectNodes("stud_grades/overall");
                    foreach (XmlNode test in peroidlist)
                    {
                        Grade Grade = new Grade();
                        Period period = new Period();
                        period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                        period.PeriodName = test.ChildNodes[2].InnerText;
                        Grade.SubjectID = test.ChildNodes[4].InnerText;
                        Grade.SubjectCategory = test.ChildNodes[5].InnerText;
                        Grade.SubjectName = test.ChildNodes[0].InnerText;
                        controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                        foreach (XmlNode grade in gradeinfo)
                        {
                            if (grade.ChildNodes[2].InnerText != "")
                            {
                                Grade.NumericGrade = double.Parse(grade.ChildNodes[0].InnerText);
                                Grade.LetterGrade = grade.ChildNodes[2].InnerText;
                                controller.addOrUpdateGrade(controller.getStudent(idgeter.StudentID), Grade, controller.getPeriod(controller.getStudent(idgeter),period.PeriodID));
                            }

                        }
                    }
                }
            }
        }
        private static void addAttendanceFromXML(IStudentController controller, XmlDocument doc)
        {
            try
            {
                XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
                foreach (XmlNode primenode in primelist)
                {
                    XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
                    XmlNodeList studentinfo = primenode.SelectNodes("student");
                    foreach (XmlNode student in studentinfo)                    
                    {
                        Student idgeter = new Student();
                        idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                        //String idgeter = "";
                        //idgeter = student.ChildNodes[0].ChildNodes[0].InnerText;
                        XmlNodeList attend = student.SelectNodes("stud_attendance/stud_att_totals/stud_att_mastercat");
                        foreach (XmlNode period in peroidlist)
                        {
                            Attendance a = new Attendance();
                            Period p = new Period();
                            p.PeriodID = Int32.Parse(period.ChildNodes[1].InnerText);
                            p.PeriodName = period.ChildNodes[2].InnerText;
                            Double exabsent = 0;
                            Double absent = 0;
                            Double total = 0;
                            Double tardy = 0;
                            foreach (XmlNode attendance in attend)
                            {


                                if (attendance.Attributes["cat"].Value == "Excused Absence")
                                {
                                    //change "" to 0
                                    if (attendance.InnerText != "")
                                    {
                                        exabsent = Convert.ToDouble(attendance.InnerText);
                                    }
                                    else
                                    { exabsent = 0; }
                                }
                                if (attendance.Attributes["cat"].Value == "Unexcused Absence")
                                {
                                    //change "" to 0
                                    if (attendance.InnerText != "")
                                    {
                                        absent = Convert.ToDouble(attendance.InnerText);
                                    }
                                    else
                                    {
                                        absent = 0;
                                    }
                                }
                                total = exabsent + absent;
                                a.DaysAbsent = total;
                                if (attendance.Attributes["cat"].Value == "Tardy")
                                {
                                    //change "" to 0
                                    if (attendance.InnerText != "")
                                    {
                                        tardy = Convert.ToDouble(attendance.InnerText);
                                    }
                                    else { tardy = 0;  }
                                }
                                a.DaysTardy = tardy;
                                controller.addOrUpdateAttendance(controller.getStudent(idgeter.StudentID), a, p);
                            }
                          
                        }
                    }
                }
            }
            catch (Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.Message,"Attendance catcher!!!");
            }
        }


        
        private static void addCommentsFromXML(IStudentController controller, XmlDocument doc)
        {

            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            Dictionary<string, string> subjectname = new Dictionary<string, string>();
            foreach (XmlNode primenode in primelist)
            {
                XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
                XmlNodeList assignlst = primenode.SelectNodes("assignments/assignment");
                XmlNodeList studentinfo = primenode.SelectNodes("student");
                foreach (XmlNode test in peroidlist)
                {
                    Period period = new Period();
                    period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                    period.PeriodName = test.ChildNodes[2].InnerText;
                    foreach (XmlNode student in studentinfo)
                    {
                        String studid = student.ChildNodes[0].ChildNodes[0].InnerText;
                        XmlNodeList comment = student.SelectNodes("stud_grades/score/score_note");
                        foreach (XmlNode commentcontainer in comment)
                        {
                            if (commentcontainer.InnerText != "")
                            {
                                Comment cmt = new Comment();
                                cmt.CommentText = commentcontainer.InnerText;
                                controller.addOrUpdatePeriod(controller.getStudent(studid), period);
                                controller.getPeriod(controller.getStudent(studid), period.PeriodID).PeriodComment.Add(cmt);

                            }

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
            addAttendanceFromXML(controller, doc);
        }

        public static void parseGradebookXML(IStudentController controller, XmlDocument doc)
        {
            addStudentsFromXML(controller, doc);
            addGradesFromXML(controller, doc);
            
        }
    }
}
   
