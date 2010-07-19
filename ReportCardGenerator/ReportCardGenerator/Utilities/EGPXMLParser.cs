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
            //Student stud = new Student();
            XmlNodeList nodeList = doc.GetElementsByTagName("stud_recordinfo");
            //System.Windows.Forms.MessageBox.Show("Number of students:" + studid.Count);
            //for (int i = 0; i < nodeList.Count; i++)
            //{
            //    stud.StudentID = nodeList.Item(i).FirstChild.InnerText;
            //    //stud.FirstName = nodeList.Item(i).InnerText;
            //    //stud.LastName = studLNAME.Item(i).InnerText;
            //    State.getInstance().Students.Add(stud);
            //    //controller.addOrUpdateStudent(stud);
            //    System.Windows.Forms.MessageBox.Show(stud.StudentID +" " + stud.FirstName);
            //}
            foreach (XmlNode node in nodeList)
            {
                Student stud = new Student();
                stud.StudentID = node["stud_id"].InnerText;
                stud.FirstName = node["stud_firstname"].InnerText;
                stud.LastName = node["stud_lastname"].InnerText;
                controller.addOrUpdateStudent(stud);
                
            }
            //foreach (Student st in State.getInstance().Students)
            //{
            //    System.Windows.Forms.MessageBox.Show(st.StudentID + " " + st.FirstName);
            //}
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
            XmlNodeList skillname = doc.GetElementsByTagName("ass_name");
            XmlNodeList skillid = doc.GetElementsByTagName("ass_id");
            XmlNodeList skillcateg = doc.GetElementsByTagName("ass_catname");
            XmlNodeList skillletgrade = doc.GetElementsByTagName("score_grade");
            XmlNodeList skillnumgrade = doc.GetElementsByTagName("score_percent");

            for (int x = 0; x < studentid.Count; x++)
            {
                skill.SkillName = skillname[x].InnerText;
                skill.SkillID = skillid[x].InnerText;
                skill.SkillCategory = skillcateg[x].InnerText;
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
            Student stud = new Student();
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
<<<<<<< .mine
<<<<<<< .mine
<<<<<<< .mine
                controller.addOrUpdatePeriod(controller.getStudent(studentid[i].InnerText), pd);
                controller.addOrUpdateGrade(controller.getStudent(studentid[i].InnerText), gd, pd);
=======
                controller.addOrUpdateGrade(stud, gd, pd);
                //System.Windows.Forms.MessageBox.Show(controller.getStudent(studentid[i].InnerText).ToString());


>>>>>>> .theirs
=======
                controller.addOrUpdateGrade(stud, gd, pd);
                //System.Windows.Forms.MessageBox.Show(controller.getStudent(studentid[i].InnerText).ToString());

>>>>>>> .theirs
=======
                controller.addOrUpdateGrade(stud, gd, pd);
                //System.Windows.Forms.MessageBox.Show(controller.getStudent(studentid[i].InnerText).ToString());
>>>>>>> .theirs

            }
            //Use the IStudentController to pass information
        }

        private static void addAttendanceFromXML(IStudentController controller, XmlDocument doc)
        {
            Attendance attend = new Attendance();
            Period pd = new Period();
            //attend.DaysAbsent;attend.DaysLate;attend.DaysPresent;attend.DaysTardy;
            XmlNodeList studentcount = doc.GetElementsByTagName("stud_id");
            XmlNodeList attendancesummary = doc.GetElementsByTagName("stud_att_mastercat");

            for (int i = 0; i < studentcount.Count; i++)
            {
                foreach (XmlNode node in attendancesummary)
                {
                    if(node.Attributes["cat"].Value.ToUpper().Equals("EXCUSED ABSENCE"))
                    {
                    }
                    if (node.Attributes["cat"].Value.ToUpper().Equals("UNEXCUSED ABSENCE"))
                    {
                    }
                    if (node.Attributes["cat"].Value.ToUpper().Equals("TARDY"))
                    {
                    }
                    if (node.Attributes["cat"].Value.ToUpper().Equals("Other"))
                    {
                    }
                    pd.PeriodID = ;
                    controller.addOrUpdatePeriod(controller.getStudent(studentcount[i].InnerText), pd);


                }
            }

            //Use the IStudentController to pass information
        }

        private static void addCommentsFromXML(IStudentController controller, XmlDocument doc)
        {
            //cant be done atm since there is no student that has any comment..\
            //I'm thinking of using the comment summary
            //or we can use the if else statment/switch if the value is one
            //we're just gonna yung the ft_note with the corresponding ID
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
            //addSkillsFromXML(controller, doc);
            
            //if (log.IsDebugEnabled) log.Debug("End parsing homeroom XML");
        }

        public static void parseGradebookXML(IStudentController controller, XmlDocument doc)
        {
            //Adds the relevant information from the Xmldocument
            addStudentsFromXML(controller, doc);
            addGradesFromXML(controller, doc);
        }
    }
}
