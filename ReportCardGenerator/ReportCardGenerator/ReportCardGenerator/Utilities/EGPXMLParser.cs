using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Data;


namespace ReportCardGenerator.Utilities
{
    class EGPXMLParser
    { 
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(EGPXMLParser));
        private static StreamReader myReader;
       
        private static void addStudentsFromXML(IStudentController controller, String doc)
        {
            #region codes
            //String adviser = "";
            //XmlNodeList nodeList = doc.GetElementsByTagName("stud_recordinfo");
            //XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            //foreach (XmlNode primenode in primelist)
            //{
            //    XmlNodeList periodList = primenode.SelectNodes("classrecord");
            //    foreach (XmlNode adviseNode in periodList)
            //    {
            //        adviser = adviseNode.ChildNodes[8].InnerText;
            //    }
            //}
            //foreach (XmlNode node in nodeList)
            //{
            //    Student stud = new Student();
            //    stud.StudentID = node["stud_id"].InnerText;
            //    stud.FirstName = node["stud_firstname"].InnerText;
            //    stud.LastName = node["stud_lastname"].InnerText;
            //    stud.Section = node.ChildNodes[8].InnerText;
            //    stud.Level = node.ChildNodes[7].InnerText;
            //    stud.Adviser = adviser;
            //    controller.addOrUpdateStudent(stud);
            //}
            #endregion
            myReader = new StreamReader(doc);

            String loadedString = null;

            while ((loadedString = myReader.ReadLine()) != null)
            {
                Student stud = new Student();
                String[] studentDetails = loadedString.Split('\t');
                stud.StudentID = studentDetails[0];
                stud.FirstName = studentDetails[2];
                stud.LastName = studentDetails[1];
                stud.Level = studentDetails[5];
                stud.Section = studentDetails[6];
                stud.Adviser = studentDetails[7];
                controller.addOrUpdateStudent(stud);
            }
            myReader.Close();
        }

        private static void addSkillsFromXML(IStudentController controller, String doc)
        {
        #region codes
            //XmlNodeList primelist = doc.SelectNodes("easygradepro/class");

            //foreach (XmlNode primenode in primelist)
            //{
            //    XmlNodeList periodList = primenode.SelectNodes("classrecord");
            //    XmlNodeList studentinfo = primenode.SelectNodes("student");
            //    XmlNodeList gradename = primenode.SelectNodes("standards/standard");
            //    Dictionary<String, String> skillNames = new Dictionary<string, string>();
            //    foreach (XmlNode test in gradename)
            //    {
            //        Skill skill = new Skill();
            //        skill.SkillID = test.ChildNodes[0].InnerText;
            //        skill.SkillName = test.ChildNodes[3].InnerText;
            //        skillNames.Add(skill.SkillID, skill.SkillName);
            //    }
                    

            //            foreach (XmlNode student in studentinfo)
            //            {
            //                //String adviser;
            //                Student idgeter = new Student();
            //                idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
            //                idgeter.LastName = student.ChildNodes[0].ChildNodes[3].InnerText;
            //                idgeter.FirstName = student.ChildNodes[0].ChildNodes[4].InnerText;
            //                XmlNodeList gradeinfo = student.SelectNodes("stud_grades/stud_stdgrades");

            //                foreach (XmlNode test in periodList)
            //                {
            //                    Period period = new Period();
            //                    period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
            //                    period.PeriodName = test.ChildNodes[2].InnerText;
            //                    //adviser = test.ChildNodes[8].InnerText;
            //                    controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
            //                foreach (XmlNode grade in gradeinfo)
            //                {
            //                    if (grade.HasChildNodes == true)
            //                    {
            //                        XmlNodeList stdgradeinfo = grade.SelectNodes("stud_stdgrade");

            //                        foreach (XmlNode stdgrade in stdgradeinfo)
            //                        {

            //                            Skill skilltostore = new Skill();
            //                            skilltostore.SkillID = stdgrade.ChildNodes[0].InnerText;
            //                            skilltostore.SkillName = skillNames[skilltostore.SkillID];
            //                            if (stdgrade.ChildNodes[1].InnerText == "" || stdgrade.ChildNodes[2].InnerText == "")
            //                            {
            //                                skilltostore.NumericGrade = 0.0;
            //                                skilltostore.LetterGrade = "N/A";
            //                            }
            //                            else
            //                            {
            //                                skilltostore.NumericGrade = double.Parse(stdgrade.ChildNodes[1].InnerText);
            //                                skilltostore.LetterGrade = stdgrade.ChildNodes[2].InnerText;
            //                            }
            //                            //idgeter.Adviser = adviser;
            //                            controller.addOrUpdateSkill(controller.getStudent(idgeter.StudentID), skilltostore, controller.getPeriod(controller.getStudent(idgeter.StudentID), period.PeriodID));

            //                        }

            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }

            //                }
            //        }
            //    }
            //}
#endregion
            myReader = new StreamReader(doc);

            String loadedString = null;
            Student stud = new Student();

            while ((loadedString = myReader.ReadLine()) != null)
            {
                String[] studentDetails = loadedString.Split('\t');
                stud.StudentID = studentDetails[0];

               
                Period period = new Period();
                period.PeriodID = Convert.ToInt32(studentDetails[3].Substring(5,1));
                controller.addOrUpdatePeriod(controller.getStudent(stud.StudentID), period);

                int term1Counter = 8;
                while (term1Counter <= 68)
                {
                    Skill Skill = new Skill();
                    Skill.SkillID = studentDetails[term1Counter];
                    if (Skill.SkillID != "A" || Skill.SkillID != "B" || Skill.SkillID != "C" || Skill.SkillID != "D" || Skill.SkillID != "E")
                    {
                        if (studentDetails[term1Counter + 1] != "")
                        {
                            String[] skillGrades = studentDetails[term1Counter + 1].Split('/');
                            Skill.NumericGrade = Convert.ToDouble(skillGrades[0]);
                            Skill.LetterGrade = skillGrades[1];
                        }
                        else
                        {
                            //Grade.SubjectID = studentDetails[4].Substring(0, 4);
                            Skill.LetterGrade = "";
                            Skill.NumericGrade = 0;
                        }
                    }
                    term1Counter += 2;
                    controller.addOrUpdateSkill(controller.getStudent(stud.StudentID), Skill, controller.getPeriod(controller.getStudent(stud.StudentID), period.PeriodID));
                }
            }
        }

        private static void addGradesFromXML(IStudentController controller, String doc)
        {
            #region codes
            //XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            //foreach (XmlNode primenode in primelist)
            //{
            //    XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
            //    XmlNodeList studentinfo = primenode.SelectNodes("student");
            //    XmlNodeList gradename = primenode.SelectNodes("assignments/assignment");

            //    foreach (XmlNode student in studentinfo)
            //    {
            //        Student idgeter = new Student();
            //        idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
            //        XmlNodeList gradeinfo = student.SelectNodes("stud_grades/overall");
            //        foreach (XmlNode test in peroidlist)
            //        {
            //            Grade Grade = new Grade();
            //            Period period = new Period();
            //            period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
            //            period.PeriodName = test.ChildNodes[2].InnerText;
            //            Grade.SubjectID = test.ChildNodes[4].InnerText;
            //            Grade.SubjectCategory = test.ChildNodes[5].InnerText;
            //            Grade.SubjectName = test.ChildNodes[0].InnerText;
            //            controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
            //            foreach (XmlNode grade in gradeinfo)
            //            {
            //                if (grade.ChildNodes[2].InnerText != "")
            //                {
            //                    Grade.NumericGrade = double.Parse(grade.ChildNodes[0].InnerText);
            //                    Grade.LetterGrade = grade.ChildNodes[2].InnerText;
            //                    controller.addOrUpdateGrade(controller.getStudent(idgeter.StudentID), Grade, controller.getPeriod(controller.getStudent(idgeter),period.PeriodID));
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
            myReader = new StreamReader(doc);

            String loadedString = null;
            Student stud = new Student();
           
            while ((loadedString = myReader.ReadLine()) != null)
            {
                String[] studentDetails = loadedString.Split('\t');
                stud.StudentID = studentDetails[0];
                Grade Grade = new Grade();
                Period period = new Period();
                if (studentDetails[9] != null)
                {
                    period.PeriodID = 1;
                    period.PeriodName = "Term 1";
                    controller.addOrUpdatePeriod(controller.getStudent(stud.StudentID), period);
                    if (studentDetails[8] != "")
                    {
                        Grade.SubjectID = studentDetails[4].Substring(0, 4);
                        //Grade.SubjectID = studentDetails[4];
                        Grade.LetterGrade = studentDetails[9];
                        Grade.NumericGrade = Convert.ToDouble(studentDetails[8]);
                    }
                    else
                    {
                        Grade.SubjectID = studentDetails[4].Substring(0, 4);
                        //Grade.SubjectID = studentDetails[4];
                        Grade.LetterGrade = ""; 
                        Grade.NumericGrade = 0; 
                    }
                    controller.addOrUpdateGrade(controller.getStudent(stud.StudentID), Grade, controller.getPeriod(controller.getStudent(stud), period.PeriodID));
                }

                //if (studentDetails[11] != null)
                //{
                //    period.PeriodID = 2;
                //    period.PeriodName = "Term 2";
                //    controller.addOrUpdatePeriod(controller.getStudent(stud.StudentID), period);
                //    if (studentDetails[10] != "")
                //    {
                //        //Grade.SubjectID = studentDetails[4].Substring(0, 4);
                //        Grade.SubjectID = studentDetails[4];
                //        Grade.LetterGrade = studentDetails[11];
                //        Grade.NumericGrade = Convert.ToDouble(studentDetails[10]);
                //    }
                //    else
                //    {
                //        //Grade.SubjectID = studentDetails[4].Substring(0, 4);
                //        Grade.SubjectID = studentDetails[4];
                //        Grade.LetterGrade = "";
                //        Grade.NumericGrade = 0;
                //    }
                //    controller.addOrUpdateGrade(controller.getStudent(stud.StudentID), Grade, controller.getPeriod(controller.getStudent(stud), period.PeriodID));
                //}

                //if (studentDetails[13] != null)
                //{
                //    period.PeriodID = 3;
                //    period.PeriodName = "Term 3";
                //    controller.addOrUpdatePeriod(controller.getStudent(stud.StudentID), period);
                //    if (studentDetails[12] != "")
                //    {
                //        //Grade.SubjectID = studentDetails[4].Substring(0, 4);
                //        Grade.SubjectID = studentDetails[4];
                //        Grade.LetterGrade = studentDetails[13];
                //        Grade.NumericGrade = Convert.ToDouble(studentDetails[12]);
                //    }
                //    else
                //    {
                //        //Grade.SubjectID = studentDetails[4].Substring(0, 4);
                //        Grade.SubjectID = studentDetails[4];
                //        Grade.LetterGrade = "";
                //        Grade.NumericGrade = 0;
                //    }
                //    controller.addOrUpdateGrade(controller.getStudent(stud.StudentID), Grade, controller.getPeriod(controller.getStudent(stud), period.PeriodID));
                //}
                
            }
            myReader.Close();
        }
        private static void addAttendanceFromXML(IStudentController controller, String doc)
        {
            #region codes
            //try
            //{
            //    XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            //    foreach (XmlNode primenode in primelist)
            //    {
            //        XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
            //        XmlNodeList studentinfo = primenode.SelectNodes("student");
            //        foreach (XmlNode student in studentinfo)                    
            //        {
            //            Student idgeter = new Student();
            //            idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
            //            //String idgeter = "";
            //            //idgeter = student.ChildNodes[0].ChildNodes[0].InnerText;
            //            XmlNodeList attend = student.SelectNodes("stud_attendance/stud_att_totals/stud_att_mastercat");
            //            foreach (XmlNode period in peroidlist)
            //            {
            //                Attendance a = new Attendance();
            //                Period p = new Period();
            //                p.PeriodID = Int32.Parse(period.ChildNodes[1].InnerText);
            //                p.PeriodName = period.ChildNodes[2].InnerText;
            //                Double exabsent = 0;
            //                Double absent = 0;
            //                Double total = 0;
            //                Double tardy = 0;
            //                foreach (XmlNode attendance in attend)
            //                {
            //                    if (attendance.Attributes["cat"].Value == "Excused Absence")
            //                    {
            //                        //change "" to 0
            //                        if (attendance.InnerText != "")
            //                        {
            //                            exabsent = Convert.ToDouble(attendance.InnerText);
            //                        }
            //                        else
            //                        { exabsent = 0; }
            //                    }
            //                    if (attendance.Attributes["cat"].Value == "Unexcused Absence")
            //                    {
            //                        //change "" to 0
            //                        if (attendance.InnerText != "")
            //                        {
            //                            absent = Convert.ToDouble(attendance.InnerText);
            //                        }
            //                        else
            //                        {
            //                            absent = 0;
            //                        }
            //                    }
            //                    total = exabsent + absent;
            //                    a.DaysAbsent = total;
            //                    if (attendance.Attributes["cat"].Value == "Tardy")
            //                    {
            //                        //change "" to 0
            //                        if (attendance.InnerText != "")
            //                        {
            //                            tardy = Convert.ToDouble(attendance.InnerText);
            //                        }
            //                        else { tardy = 0;  }
            //                    }
            //                    a.DaysTardy = tardy;
            //                    controller.addOrUpdateAttendance(controller.getStudent(idgeter.StudentID), a, p);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception er)
            //{
            //    System.Windows.Forms.MessageBox.Show(er.Message,"Attendance catcher!!!");
            //}
            #endregion
            double ab = 0;
            double ex = 0;
            double tardy = 0;
            myReader = new StreamReader(doc);

            String loadedString = null;

            while ((loadedString = myReader.ReadLine()) != null)
            {
                Student stud = new Student();
                Attendance att = new Attendance();
                Period p = new Period();
                String[] studentDetails = loadedString.Split('\t');
                stud.StudentID = studentDetails[0];
                stud.FirstName = studentDetails[1];
                stud.LastName = studentDetails[2];

                if (studentDetails[3].ToString() != "") ex = Convert.ToDouble(studentDetails[3]);
                else ex = 0;

                if (studentDetails[4].ToString() != "") ab = Convert.ToDouble(studentDetails[4]);
                else ab = 0;

                if (studentDetails[5].ToString() != "") tardy = Convert.ToDouble(studentDetails[5]);
                else tardy = 0;

                p.PeriodID = 1;
                p.PeriodName = "Term 1";
                att.DaysAbsent = ex + ab;
                att.DaysTardy = tardy;

                controller.addOrUpdateAttendance(controller.getStudent(stud.StudentID), att, p);
            }
            myReader.Close();

        }
        private static void addCommentsFromXML(IStudentController controller, String doc)
        {
            #region codes
            //XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            //Dictionary<string, string> subjectname = new Dictionary<string, string>();
            //foreach (XmlNode primenode in primelist)
            //{
            //    XmlNodeList peroidlist = primenode.SelectNodes("classrecord");
            //    XmlNodeList assignlst = primenode.SelectNodes("assignments/assignment");
            //    XmlNodeList studentinfo = primenode.SelectNodes("student");
            //    foreach (XmlNode test in peroidlist)
            //    {
            //        Period period = new Period();
            //        period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
            //        period.PeriodName = test.ChildNodes[2].InnerText;
            //        foreach (XmlNode student in studentinfo)
            //        {
            //            String studid = student.ChildNodes[0].ChildNodes[0].InnerText;
            //            XmlNodeList comment = student.SelectNodes("stud_grades/score/score_note");
            //            foreach (XmlNode commentcontainer in comment)
            //            {
            //                if (commentcontainer.InnerText != "")
            //                {
            //                    Comment cmt = new Comment();
            //                    cmt.CommentText = commentcontainer.InnerText;
            //                    controller.addOrUpdatePeriod(controller.getStudent(studid), period);
            //                    controller.getPeriod(controller.getStudent(studid), period.PeriodID).PeriodComment.Add(cmt);

            //                }

            //            }

            //        }
            //    }
            //}
            #endregion
            myReader = new StreamReader(doc);

            String loadedString = null;

            while ((loadedString = myReader.ReadLine()) != null)
            {
                Student stud = new Student();
                Period p = new Period();
                Comment cmt = new Comment();
                String[] studentDetails = loadedString.Split('\t');
                stud.StudentID = studentDetails[0];
                stud.FirstName = studentDetails[1];
                stud.LastName = studentDetails[2];

                if (studentDetails[3] != null)
                {
                    p.PeriodID = 1;
                    p.PeriodName = "Term 1";
                    cmt.CommentText = studentDetails[3];
                    controller.addOrUpdatePeriod(controller.getStudent(stud.StudentID), p);
                    controller.getPeriod(controller.getStudent(stud.StudentID), p.PeriodID).PeriodComment.Add(cmt);
                }
            }
            myReader.Close();
        }


        public static void parseHomeroomXML(IStudentController controller, String doc)
        {
            //addStudentsFromXML(controller, doc);
            addSkillsFromXML(controller, doc);
            //addCommentsFromXML(controller, doc);
            //addAttendanceFromXML(controller, doc);
        }
        public static void parseAttendanceXML(IStudentController controller, String doc)
        {
            //addStudentsFromXML(controller, doc);
            //addSkillsFromXML(controller, doc);
            //addCommentsFromXML(controller, doc);
            addAttendanceFromXML(controller, doc);
        }
        public static void parseCommentXML(IStudentController controller, String doc)
        {
            //addStudentsFromXML(controller, doc);
            //addSkillsFromXML(controller, doc);
            addCommentsFromXML(controller, doc);
            //addAttendanceFromXML(controller, doc);
        }
        public static void parseGradebookXML(IStudentController controller, String doc)
        {
            addStudentsFromXML(controller, doc);
            addGradesFromXML(controller, doc);
        }
    }
}
   
