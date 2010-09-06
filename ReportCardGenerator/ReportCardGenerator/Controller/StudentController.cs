using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Data;
using ReportCardGenerator.Exceptions;
using ReportCardGenerator.DataSet;
namespace ReportCardGenerator.Controller
{
    public class StudentController:IStudentController
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(StudentController));
        //IController implementation

        //private int index = 0;
        public void registerView(IView i)
        {
        }
        public void unregisterView(IView i)
        {
        }

        public void setUpdateViews(bool condition)
        {
        }
        public void updateRegisteredViews()
        {
        }
        //IStudentController implementation
        public void addOrUpdateStudent(Student stud)
        {
            //Add or update a student to the State
            //Do not allow multiple adding of students: Throw a DuplicateStudentException
            //We throw a DuplicateStudentException so we can monitor when this occurs!
            //Remember to catch it and log.Warn !!
            //log.Debug("Test");
            //When updating: Throw an exception if the name, studentID or last name, or level, or section
            //changes
            //System.Windows.Forms.MessageBox.Show(stud.StudentID + " " + stud.FirstName + " " + stud.LastName);
            Student student = State.getInstance().Students.Find(delegate(Student s) {return s.StudentID.Equals(stud.StudentID); });
            if (student == null)
            {
                State.getInstance().Students.Add(stud);
                ReportCardData rptData = new ReportCardData();
                DataRow dRow = rptData.StudentTable.NewRow();

                dRow["StudentID"] = stud.StudentID;
                dRow["FirstName"] = stud.FirstName;
                dRow["LastName"] = stud.LastName;
                rptData.StudentTable.Rows.Add(dRow);
            }
            else
            {                
                if (stud.StudentID.Equals(student.StudentID) && !stud.FirstName.Equals(student.FirstName) || !stud.LastName.Equals(student.LastName))
                {
                    State.getInstance().Students.Insert(State.getInstance().Students.IndexOf(stud), stud);
                    System.Windows.Forms.MessageBox.Show("Exception was thrown!!!");
                    log.Warn("Duplication of Student Occurs");
                    throw new DuplicateStudentException();
                }
            }
        }
        
        public void addOrUpdateGrade(Student stud, Grade g, Period p)
        {
            //Add or update a grade given a period id
            //Update the grade (not add a new one) if there is already an existing grade
            //Test the existence of grades by using Equals
            //Add the period if it does not exist (call addOrUpdatePeriod())
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            //Skill skill = period.Skills.Find(delegate(Skill sk){return sk.SkillID.Equals(s.SkillID);});
           //System.Windows.Forms.MessageBox.Show(period.PeriodID.ToString());
            //if (period.Grades != p.Grades)
            //{
            if (period != null)
            {
                ////System.Windows.Forms.MessageBox.Show(p.PeriodID + " " + p.PeriodName + " " + stud.StudentID + " " + g.SubjectID + " " + g.SubjectName+ " " +g.SubjectCategory + " " + g.LetterGrade + " " + g.NumericGrade);
                if (g != null)
                {
                    Grade grade = p.Grades.Find(delegate(Grade gr) { return gr.SubjectID.Equals(g.SubjectID); });
                    this.getPeriod(this.getStudent(stud.StudentID), p.PeriodID).Grades.Add(g);

                    ReportCardData rptData = new ReportCardData();
                    DataRow dRow = rptData.SubjectTable.NewRow();

                    dRow["SubjectID"] = g.SubjectID;
                    dRow["TermID"] = p.PeriodID;
                    dRow["SubjectName"] = g.SubjectName;
                    dRow["SubjectNumGrade"] = g.NumericGrade;
                    dRow["SubjectLetGrade"] = g.LetterGrade;
                    dRow["StudentId"] = stud.StudentID;

                    rptData.SubjectTable.Rows.Add(dRow);
                }
            }
            //}
            //else
            //{
                //System.Windows.Forms.MessageBox.Show(g.NumericGrade + " " + g.LetterGrade + " " + g.SubjectName + " " + g.SubjectCategory);
                //p.Grades.Insert(p.Grades.IndexOf(grade), g);
                //this.getPeriod(this.getStudent(stud.StudentID), p.PeriodID).Grades.Insert(this.getPeriod(this.getStudent(stud.StudentID), p.PeriodID).Grades.IndexOf(grade), g);
                //if (p == null) addOrUpdatePeriod(stud, p);
            //}
            
        }
        public void addOrUpdateComment(Student stud, Comment c, Period p)
        {
            //Add or update a comment given a period id
            //Update the comment (not add a new one) if there is already an existing comment
            //Add the period if it does not exist
            //Period peri = this.getPeriod(stud,p.PeriodID);
            //p = new Period();
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (p == null)
            {
                addOrUpdatePeriod(stud, p);
            }
            else if (c.CommentText != "")
            {
                getPeriod(getStudent(stud.StudentID), period.PeriodID).PeriodComment.Add(c);
                ////Period per = new Period();
                //period.PeriodID = p.PeriodID;
                //period.PeriodName = p.PeriodName;
                //period.PeriodComment = getPeriod(getStudent(stud.StudentID), period.PeriodID).PeriodComment;
               
                //System.Windows.Forms.MessageBox.Show(this.getStudent(stud.StudentID).StudentID + " " + p.PeriodID + " " + period.PeriodComment.CommentText);
                ////addOrUpdatePeriod(stud, period);

                //this.getStudent(stud.StudentID).RptCard.Periods.Add(period);
            }
        }
        public void addOrUpdatePeriod(Student stud, Period per)
        {
            //Add a period to a student
            //By updating a period (Remember not to lose the references to the
            //Grades, Comments, Attendance etc.
            //ReportCard.getInstance().Periods.Add(per);
            
            Period periods = stud.RptCard.Periods.Find(delegate(Period p) { return p.PeriodID.Equals(per.PeriodID); });
            if (per!=null)
            {
                stud.RptCard.Periods.Add(per);
                ReportCardData rptData = new ReportCardData();
                DataRow dRow = rptData.PeriodTable.NewRow();

                dRow["TermID"] = per.PeriodID;
                dRow["TermName"] = per.PeriodName;
                dRow["StudentID"] = stud.StudentID;

                rptData.PeriodTable.Rows.Add(dRow);
            }
            //else
            //{
            //    stud.RptCard.Periods.Insert(stud.RptCard.Periods.IndexOf(periods), per);
            //}
        }
        public void addOrUpdateSkill(Student stud, Skill s, Period p)
        {
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period != null)
            {
                if (s != null)
                {
                    Skill sk = p.Skills.Find(delegate(Skill skill) { return skill.SkillID.Equals(s.SkillID); });
                    this.getPeriod(this.getStudent(stud.StudentID), p.PeriodID).Skills.Add(s);
                    ReportCardData rptData = new ReportCardData();
                    DataRow dRow = rptData.SkillTable.NewRow();

                    dRow["SkillID"] = s.SkillID;
                    dRow["TermID"] = p.PeriodID;
                    dRow["SkillName"] = s.SkillName;
                    dRow["SkillNumGrade"] = s.NumericGrade;
                    dRow["SkillLetGrade"] = s.LetterGrade;
                    dRow["StudentID"] = stud.StudentID;

                    rptData.SkillTable.Rows.Add(dRow);
                }
            }
        }
        public void addOrUpdateAttendance(Student stud, Attendance a, Period p)
        {
            //Add or update an attendance record given a period id
            //Update the attendance if there is already an existing attendance
            //Add the period if it does not exist
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period == p)
            {
                if (a != null)
                {
                    period.PeriodAttendance.DaysPresent = a.DaysPresent;
                    period.PeriodAttendance.DaysTardy = a.DaysTardy;
                }
                else
                {
                    period.PeriodAttendance = null;
                }
            }
            if (period == null) addOrUpdatePeriod(stud, p);
        }

        public void setStudents(List<Student> students)
        {
            State.getInstance().Students = students;   
        }
        public List<Student> getAllStudents()
        {
            return State.getInstance().Students;
        }
        public Student getStudent(Student stud)
        {
            //Return null if student doesn't exist
            //By using Equals and State.getInstance().Students.Find(...)
            Student student = State.getInstance().Students.Find(delegate(Student s) { return s.StudentID.Equals(stud.StudentID); });
           if (student != null) return student;
            else return null;
        }
        public Student getStudent(String studentID)
        {
            ////Return null if student doesn't exist
            ////By using the StudentID and .Find
        
            Student student = State.getInstance().Students.Find(delegate(Student s) { return s.StudentID.Equals(studentID); });
            if (student != null)return student;
            else return null;
            
        }
        public Period getPeriodByName(Student student, String periodName)
        {
            //Return null if period doesn't exist
            Period period = student.RptCard.Periods.Find(delegate(Period p) { return p.PeriodName.Equals(periodName); });
            if (period != null) return period;
            else return null;
        }
        public Period getPeriod(Student student, int periodID)
        {
            //Change null into something like  warning.
            //Return null if period doesn't exist
            Period period = student.RptCard.Periods.Find(delegate(Period p) { return p.PeriodID.Equals(periodID); });
            if (period != null)
            {
                //System.Windows.Forms.MessageBox.Show(student.RptCard.Periods.Count.ToString());
                return period;
               
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show(student.RptCard.Periods.Count.ToString());
                return null;
               
            }
            
        }

        public void removeStudent(Student stud)
        {
            State.getInstance().Students.RemoveAt(State.getInstance().Students.IndexOf(stud));
        }

        public void removeStudent(String studentID)
        {
            //Create a new student based on studentID and call
            //removeStudent(Student stud)
            Student stud = new Student();
            stud.StudentID = studentID;
            removeStudent(stud);
        }

        public void clearStudents()
        {
            State.getInstance().Students.Clear();
        }
    }
}
