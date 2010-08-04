﻿using System;
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
            List<Skill> skillcontainer = new List<Skill>();
            XmlNodeList primelist = doc.GetElementsByTagName("class");
            
            //Declaration of Beans
            Period period = new Period();
            Skill skill = new Skill();
            Student stud = new Student();
            //End of Declaration

            for (int i = 0; i < primelist.Count; i++)
            {
                //System.Windows.Forms.MessageBox.Show(primelist.Item(i).FirstChild.Name);
                //get the period name and period id from node "classrecord"
                if (primelist.Item(i).FirstChild.Name.Equals("classrecord"))
                {
                    //System.Windows.Forms.MessageBox.Show(primelist.Item(i).FirstChild.ChildNodes[0].InnerText);
                    period.PeriodID = int.Parse(primelist.Item(i).FirstChild.ChildNodes[1].InnerText);
                    period.PeriodName = primelist.Item(i).FirstChild.ChildNodes[0].InnerText;
                }
                //int count = int.Parse(primelist.Item(i).FirstChild["student"]);
                //System.Windows.Forms.MessageBox.Show(primelist.Item(i).FirstChild["student"].ToString());
                System.Windows.Forms.MessageBox.Show(primelist.Item(i)["student"].FirstChild.Name);

            }
            //foreach (XmlNode primenode in primelist)
            //{
            //    Period pd = new Period();
            //    Student stud = new Student();
            //    Skill skilltostore = new Skill();
            //    System.Windows.Forms.MessageBox.Show(primelist.Count.ToString());
            //    if (primenode.FirstChild.Name.Equals("classrecord"))
            //    {
            //        XmlNodeList classlist = primenode.FirstChild.SelectNodes("class/classrecord");
            //        foreach (XmlNode pernode in classlist)
            //        {
            //            //System.Windows.Forms.MessageBox.Show(pernode.InnerText);
            //        }
            //        //foreach (XmlNode periodxml in crecord)
            //        //{
            //        //    System.Windows.Forms.MessageBox.Show(periodxml.FirstChild.Name);
            //        //    pd.PeriodID = Int32.Parse(periodxml["cr_termnum"].InnerText);
            //        //    pd.PeriodName = periodxml["cr_classsubjectname"].InnerText.ToString();
            //        //    //System.Windows.Forms.MessageBox.Show(pd.PeriodID.ToString());
            //        //}
            //    }
            //    //if (primenode.Attributes.Equals("assignments"))
            //    //{
            //    //    XmlNodeList assrec = primenode.ChildNodes;
            //    //    Skill skill = new Skill();
            //    //    foreach (XmlNode skillxml in assrec)
            //    //    {
                        
            //    //        skill.SkillID = skillxml["ass_id"].InnerText;
            //    //        skill.SkillName = skillxml["ass_name"].InnerText;
            //    //        skill.SkillCategory = skillxml["ass_catname"].InnerText;
            //    //        skillcontainer.Add(skill);
            //    //    }
            //    //}
            //    //if (primenode.Attributes.Equals("student"))
            //    //{
            //    //    XmlNodeList studinfoall = primenode.ChildNodes;
            //    //    foreach (XmlNode studseg in studinfoall)
            //    //    {
            //    //        if (studseg.Attributes.Equals("stud_recordinfo"))
            //    //        {
            //    //            XmlNodeList studentinfo = studseg.ChildNodes;
            //    //            foreach (XmlNode studinfo in studentinfo)
            //    //            {
                                
            //    //                stud.StudentID = studinfo["stud_id"].InnerText;
            //    //            }
            //    //        }
            //    //        if (studseg.Attributes.Equals("stud_grade"))
            //    //        {
                           
            //    //            XmlNodeList grades =  studseg.ChildNodes;
            //    //            foreach (XmlNode gradseg in grades)
            //    //            {
            //    //                if (gradseg.Attributes["score"].Value.Equals("assid"))
            //    //                {
            //    //                    skilltostore.SkillID = studseg.InnerText;
            //    //                    skilltostore.SkillName = skillcontainer[int.Parse(skilltostore.SkillID)].SkillName;
            //    //                    skilltostore.SkillCategory = skillcontainer[int.Parse(skilltostore.SkillID)].SkillCategory;
            //    //                }
            //    //                skilltostore.NumericGrade = Int32.Parse(gradseg["score_percent"].InnerText);
            //    //                skilltostore.LetterGrade = gradseg["score_grade"].InnerText;
            //    //            }
                            
            //    //        }
                        
            //    //    }

            //    //}
            //    //System.Windows.Forms.MessageBox.Show(pd.PeriodName + " " + stud.StudentID + " " + skilltostore.SkillName + " " + skilltostore.NumericGrade + " " + skilltostore.SkillCategory);
            //}
        }

        private static void addGradesFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList nodeList = doc.GetElementsByTagName("stud_recordinfo");
            //XmlNodeList gradelist = doc.GetElementsByTagName("assignment");
            XmlNodeList grades = doc.GetElementsByTagName("score");
            XmlNodeList periodlist = doc.GetElementsByTagName("classrecord");
            foreach (XmlNode node2 in periodlist)
            {
                string studid = "";
                Grade grade = new Grade();
                Period period = new Period();
                period.PeriodID = Int32.Parse(node2["cr_termnum"].InnerText);
                period.PeriodName = node2["cr_termlabel"].InnerText;
                grade.SubjectName = node2["cr_classsubjectname"].InnerText;
                //if (node2.Attributes["cr_data"].Value["label"].Equals("SubjectID"))
                //{

                //}
                //foreach (XmlNode node in gradelist)
                //{
                //    grade.SubjectID = node["ass_id"].InnerText;
                //    grade.SubjectName = node["ass_name"].InnerText;
                //    grade.SubjectCategory = node["ass_catname"].InnerText;
                    foreach (XmlNode studnode in nodeList)
                    {
                        studid = studnode["stud_id"].InnerText;
                        foreach (XmlNode graded in grades)
                        {
                            //Grade g = new Grade();
                            if (!graded["score_percent"].InnerText.Equals(""))
                            {
                                grade.NumericGrade = double.Parse(graded["score_percent"].InnerText.ToString());
                                grade.LetterGrade = graded["score_grade"].InnerText;
                            }
                            else
                            {
                                if (graded["score_grade"].InnerText.Equals(""))
                                {
                                    grade.LetterGrade = graded["score_grade"].InnerText = "blank letter grade!!!";
                                    graded["score_percent"].InnerText = "0.0";
                                    grade.NumericGrade = double.Parse(graded["score_percent"].InnerText.ToString());
                                    grade.LetterGrade = graded["score_grade"].InnerText;
                                    //System.Windows.Forms.MessageBox.Show(skill.NumericGrade.ToString() + " " + skill.LetterGrade);
                                }
                                else
                                {
                                    graded["score_percent"].InnerText = "0.0";
                                    grade.NumericGrade = double.Parse(graded["score_percent"].InnerText.ToString());
                                    grade.LetterGrade = graded["score_grade"].InnerText;

                                    //System.Windows.Forms.MessageBox.Show(skill.NumericGrade.ToString() + " " + skill.LetterGrade);
                                }
                            }
                            //System.Windows.Forms.MessageBox.Show(controller.getStudent(studid).StudentID.ToString());
                            controller.addOrUpdatePeriod(controller.getStudent(studid), period);
                            controller.addOrUpdateGrade(controller.getStudent(studid), grade, period);
                        }

                    }
            
                    
                }
                
            }

        

        private static void addAttendanceFromXML(IStudentController controller, XmlDocument doc)
        {

            XmlNodeList nodelist = doc.GetElementsByTagName("classrecord");
            XmlNodeList nodelist2 = doc.GetElementsByTagName("stud_recordinfo");

            foreach (XmlNode pdcheck in nodelist)
            {
                Period period = new Period();
                Attendance attend = new Attendance();
                period.PeriodID = int.Parse(pdcheck["cr_termnum"].InnerText);
                period.PeriodName = pdcheck["cr_termlabel"].InnerText;

            }

        }

        private static void addCommentsFromXML(IStudentController controller, XmlDocument doc)
        {
            XmlNodeList nodeList = doc.GetElementsByTagName("stud_recordinfo");
            XmlNodeList grades = doc.GetElementsByTagName("score");
            XmlNodeList periodlist = doc.GetElementsByTagName("classrecord");

            foreach (XmlNode node2 in periodlist)
            {
                string studid = "";
                Comment comment = new Comment();
                Period period = new Period();
                period.PeriodID = Int32.Parse(node2["cr_termnum"].InnerText);
                period.PeriodName = node2["cr_termlabel"].InnerText;
                foreach (XmlNode studnode in nodeList)
                {
                    studid = studnode["stud_id"].InnerText;
                    foreach (XmlNode graded in grades)
                    {
                        comment.CommentText = graded["score_note"].InnerText;
                        controller.addOrUpdateComment(controller.getStudent(studid), comment, period);
                    }
                }
            }         
        }
        public static void parseHomeroomXML(IStudentController controller, XmlDocument doc)
        {
            addStudentsFromXML(controller, doc);
            addSkillsFromXML(controller, doc);
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
