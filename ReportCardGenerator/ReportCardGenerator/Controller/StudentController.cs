using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Data;
namespace ReportCardGenerator.Controller
{
    public class StudentController:IStudentController
    {
        
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
        }

        public void addOrUpdatePeriod(Student s, Period p)
        {
            //Add a period to a student
            //By updating a period (Remember not to lose the references to the
            //Grades, Comments, Attendance etc.
        }
        public void addOrUpdateGrade(Student stud, Grade g, Period p)
        {
            //Add or update a grade given a period id
            //Update the grade (not add a new one) if there is already an existing grade
            //Test the existence of grades by using Equals
            //Add the period if it does not exist (call addOrUpdatePeriod())
        }
        public void addOrUpdateComment(Student stud, Comment c, Period p)
        {
            //Add or update a comment given a period id
            //Update the comment (not add a new one) if there is already an existing comment
            //Add the period if it does not exist
            
        }
        public void addOrUpdateSkill(Student stud, Skill s, Period p)
        {
            //Add or update a skill given a period id
            //Update the skill if there is already an existing skill
            //Test the existence of a skill using Equals
            //Add the period if it does not exist
        }
        public void addOrUpdateAttendance(Student s, Attendance a, Period p)
        {
            //Add or update an attendance record given a period id
            //Update the attendance if there is already an existing attendance
            //Add the period if it does not exist
            
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
            return null;
        }
        public Student getStudent(String studentID)
        {
            //Return null if student doesn't exist
            //By using the StudentID and .Find
            return null;
        }
        public Period getPeriodByName(Student student, String periodName)
        {
            //Return null if period doesn't exist
            return null;
        }
        public Period getPeriod(Student student, String periodID)
        {
            //Return null if period doesn't exist
            return null;
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
