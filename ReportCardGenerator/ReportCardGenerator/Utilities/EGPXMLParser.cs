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

                //XmlNodeList peroidlist = doc.SelectNodes("easygradepro/class/classrecord");
                //System.Windows.Forms.MessageBox.Show(primelist.Count.ToString());
                //foreach (XmlNode list in primelist)
                //{
                //    System.Windows.Forms.MessageBox.Show(list.FirstChild.InnerText);
                //}

                foreach (XmlNode primenode in primelist)
                {
                    XmlNodeList peroidlist =primenode.SelectNodes("classrecord");
                    XmlNodeList studentinfo = primenode.SelectNodes("student");
                    XmlNodeList gradename = primenode.SelectNodes("standards/standard");
                    Dictionary<String, String> skillNames = new Dictionary<string, string>();
                    //Dictionary<String, String> categories = new Dictionary<string, string>(); might not be needed anymore (Pending)
                    //System.Windows.Forms.MessageBox.Show(peroidlist.Count.ToString());
                    foreach (XmlNode test in gradename)
                    {
                        Skill skill = new Skill();
                        skill.SkillID = test.ChildNodes[0].InnerText;
                        skill.SkillName = test.ChildNodes[3].InnerText;
                        //skill.SkillCategory = test.ChildNodes[6].InnerText; might not be needed anymore
                        skillNames.Add(skill.SkillID, skill.SkillName);
                        //categories.Add(skill.SkillID, skill.SkillCategory); might not be needed anymore
                    }
                    for (int x = 0; x < peroidlist.Count; x++)
                    {
                        foreach (XmlNode test in peroidlist)
                        {
                            //System.Windows.Forms.MessageBox.Show(peroidlist.Count.ToString());
                            Period period = new Period();
                            period.PeriodID = Int32.Parse(test.ChildNodes[1].InnerText);
                            period.PeriodName = test.ChildNodes[2].InnerText;

                            foreach (XmlNode student in studentinfo)
                            {
                                Student idgeter = new Student();
                                idgeter.StudentID = student.ChildNodes[0].ChildNodes[0].InnerText;
                                idgeter.LastName = student.ChildNodes[0].ChildNodes[3].InnerText;
                                idgeter.FirstName = student.ChildNodes[0].ChildNodes[4].InnerText;
                                //XmlNodeList gradeinfo = student.SelectNodes("stud_grades/stud_stdgrades/stud_stdgrade");
                                XmlNodeList gradeinfo = student.SelectNodes("stud_grades/stud_stdgrades");
                                //System.Windows.Forms.MessageBox.Show(period.PeriodID + " " + period.PeriodName + " " + idgeter.StudentID + " " + idgeter.FirstName);
                                foreach (XmlNode grade in gradeinfo)
                                {
                                    //System.Windows.Forms.MessageBox.Show(grade.HasChildNodes.ToString());
                                    if (grade.HasChildNodes == true)
                                    {
                                        XmlNodeList stdgradeinfo = grade.SelectNodes("stud_stdgrade");
                                        //System.Windows.Forms.MessageBox.Show(stdgradeinfo.Count.ToString());
                                        foreach (XmlNode stdgrade in stdgradeinfo)
                                        {
                                            Skill skilltostore = new Skill();
                                            //System.Windows.Forms.MessageBox.Show(stdgrade.HasChildNodes.ToString());
                                            skilltostore.SkillID = stdgrade.ChildNodes[0].InnerText;
                                            skilltostore.SkillName = skillNames[skilltostore.SkillID];
                                            skilltostore.NumericGrade = double.Parse(stdgrade.ChildNodes[1].InnerText);
                                            skilltostore.LetterGrade = stdgrade.ChildNodes[2].InnerText; //Please take note that 


                                            //skilltostore.SkillID = grade.ChildNodes[0].InnerText;
                                            //skilltostore.SkillName = skillNames[skilltostore.SkillID];
                                            //skilltostore.NumericGrade = double.Parse(grade.ChildNodes[1].InnerText);
                                            //skilltostore.LetterGrade = grade.ChildNodes[2].InnerText; //Please take note that 
                                            //instead of latter grade we should just change this into rubrics.
                                            //consult sir wallen please


                                            controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);

                                            //Backup code incase the current revision is to be replaced with remarks
                                            //skilltostore.SkillCategory = categories[grade.Attributes[0].InnerText]; might not be needed anymore
                                            //if (skilltostore.SkillCategory.Equals("Remarks"))
                                            //{
                                            //    break;
                                            //}
                                            //else
                                            //{
                                            //    skilltostore.NumericGrade = double.Parse(grade.ChildNodes[1].InnerText);
                                            //    skilltostore.LetterGrade = grade.ChildNodes[2].InnerText;
                                            //    controller.addOrUpdateSkill(controller.getStudent(idgeter.StudentID), skilltostore, period);
                                            //} Pending for deletion since we removed the remarks adjustments

                                            controller.addOrUpdateSkill(controller.getStudent(idgeter.StudentID), skilltostore, period);
                                            //System.Windows.Forms.MessageBox.Show(period.PeriodID + " " + period.PeriodName);

                                            //System.Windows.Forms.MessageBox.Show(period.PeriodID + " " + period.PeriodName + " " + idgeter.StudentID + " " + idgeter.FirstName + " " + skilltostore.SkillID + " " + skilltostore.SkillName + " " + skilltostore.NumericGrade);
                                            //System.Windows.Forms.MessageBox.Show(controller.getStudent(idgeter.StudentID).StudentID);
                                            //idgeter.RptCard.Periods.Add(period);
                                            //}
                                           

                                        }
                                      
                                    }
                                    else
                                    {
                                        break;
                                        System.Windows.Forms.MessageBox.Show("NO childNodes Exists!!!");
                                    }
                                }

                            }
                        }
                    }
                }
        }

        private static void addGradesFromXML(IStudentController controller, XmlDocument doc)
        {
            try
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
                            XmlNodeList gradeinfo = student.SelectNodes("stud_grades/score");
                            foreach (XmlNode grade in gradeinfo)
                            {
                                controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                                Grade ToStoreGrade = new Grade();
                                ToStoreGrade.SubjectID = grade.Attributes[0].InnerText;
                                ToStoreGrade.SubjectCategory = categories[grade.Attributes[0].InnerText];
                                ToStoreGrade.NumericGrade = double.Parse(grade.ChildNodes[1].InnerText);
                                ToStoreGrade.LetterGrade = grade.ChildNodes[2].InnerText;
                                controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                                controller.addOrUpdateGrade(controller.getStudent(idgeter.StudentID), ToStoreGrade, period);
                                System.Windows.Forms.MessageBox.Show(period.PeriodID + " " + period.PeriodName + " " + idgeter.StudentID + " " + ToStoreGrade.SubjectID + ToStoreGrade.SubjectName + " " + ToStoreGrade.LetterGrade + " " + ToStoreGrade.NumericGrade);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private static void addAttendanceFromXML(IStudentController controller, XmlDocument doc)
        {
            int DaysPresentToStore = 0;
            XmlNodeList primelist = doc.SelectNodes("easygradepro/class");
            Period pd = new Period();
            foreach (XmlNode primenode in primelist)
            {
                List<DayOfWeek> validateddates = new List<DayOfWeek>();
                validateddates = validdates(doc);
                XmlNodeList periodlst = primenode.SelectNodes("classrecord");
                XmlNodeList datelist = primenode.SelectNodes("calendaroptions");
                XmlNodeList studinfo = primenode.SelectNodes("student");
                foreach (XmlNode periodgetter in periodlst)
                {
                    pd.PeriodID = Int32.Parse(periodgetter.ChildNodes[1].InnerText);
                    pd.PeriodName = periodgetter.ChildNodes[2].InnerText;
                    foreach (XmlNode datenodes in datelist)
                    {
                        DateTime start = DateTime.Parse(datenodes.ChildNodes[1].InnerText) ;
                        DateTime end = DateTime.Parse(datenodes.ChildNodes[2].InnerText);

                        int startDay = int.Parse(start.Day.ToString());
                        int endsDay = int.Parse(end.Day.ToString());

                        int startMonth = int.Parse(start.Month.ToString());
                        int endMonth = int.Parse(end.Month.ToString());

                        int startYear = int.Parse(start.Year.ToString());
                        int endYear = int.Parse(end.Year.ToString());

                        int totalDays = 0;
                        while (startYear != endYear)
                        {
                            while (startMonth != endMonth)
                            {         
                                while (startDay != endsDay)
                                {
                                    if (validateddates.Contains(start.DayOfWeek))
                                    {
                                        totalDays++;
                                    }
                                    startDay++;
                                    System.Windows.Forms.MessageBox.Show(startDay.ToString());
                                }
                                int NoClass = datenodes.ChildNodes[3].ChildNodes.Count;
                                DaysPresentToStore = totalDays - NoClass;
                                startMonth++;
                            }
                            startYear++;
                        }

                    }
                    foreach (XmlNode studparse in studinfo)
                    {

                        Student sd = new Student();
                        sd.StudentID = studparse.ChildNodes[0].InnerText;
                        XmlNodeList attendancelist = studparse.SelectNodes("stud_attendance/stud_att_total");
                        foreach (XmlNode attendancecomponent in attendancelist)
                        {
                            int absence1;
                            int absence2;
                            int store;
                            Attendance attendance = new Attendance();
                            absence1 = Int32.Parse(attendancecomponent.ChildNodes[0].InnerText);
                            absence2 = Int32.Parse(attendancecomponent.ChildNodes[4].InnerText);
                            store = absence1 + absence2;
                            attendance.DaysPresent = DaysPresentToStore - store;
                            attendance.DaysAbsent = store;
                            attendance.DaysLate = Int32.Parse(attendancecomponent.ChildNodes[7].InnerText);
                            controller.addOrUpdatePeriod(controller.getStudent(sd.StudentID), pd);
                            controller.addOrUpdateAttendance(controller.getStudent(sd.StudentID), attendance, pd);
                        }
                    }
                }
            }
        }


        private static List<DayOfWeek> validdates(XmlDocument doc)
        {
            //Use a set not a list
            List<DayOfWeek> returndates = new List<DayOfWeek>();
            XmlNodeList prime = doc.SelectNodes("easygradepro/class/calendaroptions/cal_daysofweek");
            //System.Windows.Forms.MessageBox.Show(prime.Count.ToString());
            foreach (XmlNode dateselected in prime)
            {
                //String n = dateselected.Attributes["id"];
                for (int n = 0; n < dateselected.ChildNodes.Count;n++)
                {

                    String x = dateselected.ChildNodes[n].Attributes["id"].Value;
                    //System.Windows.Forms.MessageBox.Show(x);
                    switch (x)
                    {
                        case "1":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Sunday);
                            break;
                        case "2":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Monday);
                            break;
                        case "3":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Tuesday);
                            break;
                        case "4":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Wednesday);
                            break;
                        case "5":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Thursday);
                            break;
                        case "6":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Friday);
                            break;
                        case "7":
                            if (dateselected.InnerText.Equals("yes"))
                                returndates.Add(DayOfWeek.Saturday);
                            break;
                        default:
                            System.Windows.Forms.MessageBox.Show("Attendance was not used", "Note");
                            break;
                    }
                }  
            }
            return returndates;
        }


        private static void addCommentsFromXML(IStudentController controller, XmlDocument doc)
        {
            try
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
                            XmlNodeList gradeinfo = student.SelectNodes("stud_grades/score");
                            foreach (XmlNode grade in gradeinfo)
                            {
                                Comment cm = new Comment();
                                cm.CommentText = grade.LastChild.InnerText;
                                controller.addOrUpdatePeriod(controller.getStudent(idgeter.StudentID), period);
                                controller.addOrUpdateComment(controller.getStudent(idgeter.StudentID), cm, period);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public static void parseHomeroomXML(IStudentController controller, XmlDocument doc)
        {
            addStudentsFromXML(controller, doc);
            //addAttendanceFromXML(controller, doc);
            addSkillsFromXML(controller, doc);
            //addCommentsFromXML(controller, doc);
        }

        public static void parseGradebookXML(IStudentController controller, XmlDocument doc)
        {
            addStudentsFromXML(controller, doc);
            addAttendanceFromXML(controller, doc);
            addGradesFromXML(controller, doc);
        }
    }
}
