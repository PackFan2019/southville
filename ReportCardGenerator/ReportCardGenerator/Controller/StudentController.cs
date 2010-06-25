using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Data;
using ReportCardGenerator.Exceptions;
namespace ReportCardGenerator.Controller
{
    public class StudentController:IStudentController
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(StudentController));
        //IController implementation

        
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
            Student student = State.getInstance().Students.Find(delegate(Student s) { return s.StudentID.Equals(stud.StudentID); });
            if (!student.StudentID.Equals(stud.StudentID)) State.getInstance().Students.Add(stud);
            else
            {
                State.getInstance().Students.Insert(State.getInstance().Students.IndexOf(student), stud);
                log.Warn("Duplication of Student Occurs");
                throw new DuplicateStudentException();                
            }
        }
        public void addOrUpdatePeriod(Student s, Period p)
        {
            //Add a period to a student
            //By updating a period (Remember not to lose the references to the
            //Grades, Comments, Attendance etc.
            Period period = s.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period.Equals(null)) s.RptCard.Periods.Add(p);
            else s.RptCard.Periods.Insert(s.RptCard.Periods.IndexOf(period), p);
        }
        public void addOrUpdateGrade(Student stud, Grade g, Period p)
        {
            //Add or update a grade given a period id
            //Update the grade (not add a new one) if there is already an existing grade
            //Test the existence of grades by using Equals
            //Add the period if it does not exist (call addOrUpdatePeriod())
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period.Grades.Count.Equals(0)) period.Grades.Add(g);
            else period.Grades.Insert(stud.RptCard.Periods.IndexOf(period), g);
            if (period.Equals(null))addOrUpdatePeriod(stud,p);
        }
        public void addOrUpdateComment(Student stud, Comment c, Period p)
        {
            //Add or update a comment given a period id
            //Update the comment (not add a new one) if there is already an existing comment
            //Add the period if it does not exist
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period.Equals(null)) addOrUpdatePeriod(stud, p);
        }
        public void addOrUpdateSkill(Student stud, Skill s, Period p)
        {
            //Add or update a skill given a period id
            //Update the skill if there is already an existing skill
            //Test the existence of a skill using Equals
            //Add the period if it does not exist
            Period period = stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            Skill skill = period.Skills.Find(delegate(Skill sk){return sk.SkillID.Equals(s.SkillID);});
            if (skill.Equals(null)) period.Skills.Add(s);
            else period.Skills.Insert(period.Skills.IndexOf(skill),s);
            if (period.Equals(null)) addOrUpdatePeriod(stud, p);
        }
        public void addOrUpdateAttendance(Student s, Attendance a, Period p)
        {
            //Add or update an attendance record given a period id
            //Update the attendance if there is already an existing attendance
            //Add the period if it does not exist
            Period period = s.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });
            if (period.PeriodAttendance.Equals(null)) period.PeriodAttendance.Equals(a);   
            if (period.Equals(null)) addOrUpdatePeriod(s, p);
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
            if (student.Equals(null)) return null;
            else return student;
        }
        public Student getStudent(String studentID)
        {
            //Return null if student doesn't exist
            //By using the StudentID and .Find
            Student student = State.getInstance().Students.Find(delegate(Student s) { return s.StudentID.Equals(studentID); });
            if (student.Equals(null)) return null;
            else return student;
        }
        public Period getPeriodByName(Student student, String periodName)
        {
            //Return null if period doesn't exist
            Period period = student.RptCard.Periods.Find(delegate(Period p) { return p.PeriodName.Equals(periodName); });
            if (period.Equals(null)) return null;
            else return period;
        }
        public Period getPeriod(Student student, String periodID)
        {
            //Return null if period doesn't exist
            Period period = student.RptCard.Periods.Find(delegate(Period p) { return p.PeriodID.Equals(periodID); });
            if (period.Equals(null)) return null;
            else return period;
        }

        public void removeStudent(Student stud)
        {
        }

        public void removeStudent(String studentID)
        {
            //Create a new student based on studentID and call
            //removeStudent(Student stud)

        }

        public void clearStudents()
        {
            State.getInstance().Students.Clear();
        }
    }
}
