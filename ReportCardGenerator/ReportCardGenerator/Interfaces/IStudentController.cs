using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportCardGenerator.Beans;
namespace ReportCardGenerator.Interfaces
{
    public interface IStudentController:IController
    {
        /*Add and update functions for data*/
        void addOrUpdateStudent(Student stud);
        void addOrUpdatePeriod(Student s, Period p);
        void addOrUpdateGrade(Student stud, Grade g, Period p);
        void addOrUpdateComment(Student stud, Comment c, Period p);
        void addOrUpdateSkill(Student stud, Skill s, Period p);
        void addOrUpdateAttendance(Student s, Attendance a, Period p);
        void setStudents(List<Student> students);

        /*Get functions for data*/
        List<Student> getAllStudents();
        Student getStudent(Student stud);
        Student getStudent(String studentID);
        Period getPeriodByName(Student student, String periodName);
        Period getPeriod(Student student, String periodID);

        /*Remove functions for data*/
        void removeStudent(String studentID);
        void removeStudent(Student stud);
        void clearStudents();


    }
}
