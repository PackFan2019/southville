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
        public void addOrUpdateStudent(Student stud)
        {
            Student student = State.getInstance().Students.Find(delegate(Student s) {return s.StudentID.Equals(stud.StudentID); });
            if (student == null)
            {
                State.getInstance().Students.Add(stud);
            }
            else
            {
                if (stud.StudentID.Equals(student.StudentID) && !stud.FirstName.Equals(student.FirstName) || !stud.LastName.Equals(student.LastName))
                {
                    //State.getInstance().Students.Insert(State.getInstance().Students.IndexOf(stud), stud);
                    System.Windows.Forms.MessageBox.Show(student.FirstName + " " + student.LastName + " already exists! (" + student.FirstName + " " + student.LastName + " has same student ID " +student.StudentID +" from gradebook computer)",
                        "Duplication of Student Occurs", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    log.Warn("Duplication of Student Occurs");
                    //throw new DuplicateStudentException();
                }
            }
        }
        
        public void addOrUpdateGrade(Student stud, Grade g, Period p)
        {

           
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period != null)
            {
                if (g != null)
                {
                    Grade grade = new Grade();
                    grade = period.Grades.Find(delegate(Grade gr) { return gr.SubjectID.Equals(g.SubjectID); });
                    if (grade == null)
                    {
                        period.Grades.Add(g);
                    }
                }
            }   
        }
        public void addOrUpdateComment(Student stud, Comment c, Period p)
        {

            Period period = new Period();
            period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period != null)
            {
                if (c != null)
                {
                    Comment cm = period.PeriodComment.Find(delegate(Comment com) {return period.PeriodComment.Equals(c.CommentText);});
                    if (cm == null)
                    {
                        getPeriod(stud, period.PeriodID).PeriodComment.Add(cm);
                    }
                }
            }
            
        }
        public void addOrUpdatePeriod(Student stud, Period per)
        {
            Period periods = new Period();
            periods = stud.RptCard.Periods.Find(delegate(Period p) { return p.PeriodID.Equals(per.PeriodID); });
            if (periods == null)
            {
                stud.RptCard.Periods.Add(per);
            }
        }
        public void addOrUpdateSkill(Student stud, Skill s, Period p)
        {
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period != null)
            {
                if (s != null)
                {
                    Skill sk = period.Skills.Find(delegate(Skill skill) { return skill.SkillID.Equals(s.SkillID); });
                    if (sk == null)
                    {
                        period.Skills.Add(s);
                    }
                }
            }    
        }
        public void addOrUpdateAttendance(Student stud, Attendance a, Period p)
        {
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            //change p to null
            if (period != null)
            {
                if (a != null)
                {
                    period.PeriodAttendance.Add(a);
                }
            }
            
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
            Student student = State.getInstance().Students.Find(delegate(Student s) { return s.StudentID.Equals(stud.StudentID); });
            if (student != null) return student;
            else return null;
        }
        public Student getStudent(String studentID)
        {
            Student student = State.getInstance().Students.Find(delegate(Student s) { return s.StudentID.Equals(studentID); });
            if (student != null)return student;
            else return null;
            
        }
        public Period getPeriodByName(Student student, String periodName)
        {
            Period period = student.RptCard.Periods.Find(delegate(Period p) { return p.PeriodName.Equals(periodName); });
            if (period != null) return period;
            else return null;
        }
        public Period getPeriod(Student student, int periodID)
        {
            Period period = student.RptCard.Periods.Find(delegate(Period p) { return p.PeriodID.Equals(periodID); });
            if (period != null)
            {
                return period;          
            }
            else
            {
                return null; 
            }
            
        }

        public void removeStudent(Student stud)
        {
            State.getInstance().Students.RemoveAt(State.getInstance().Students.IndexOf(stud));
        }

        public void removeStudent(String studentID)
        {
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
