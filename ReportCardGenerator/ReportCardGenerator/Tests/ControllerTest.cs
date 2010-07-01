using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using NUnit.Framework;
using ReportCardGenerator.Data;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Controller;
using ReportCardGenerator.Exceptions;
namespace ReportCardGenerator.Tests
{
    [TestFixture]
    class ControllerTest
    {
        private List<Student> oldStudents;
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(ControllerTest));
        IStudentController contoller = FrontController.getInstance().getStudentController();
        [SetUp]
        public void setup()
        {
            
            oldStudents = State.getInstance().Students;
            State.getInstance().Students.Clear();
            //Clear the State
        }


        [Test]
        public void testAddNewStudent()
        {
            //contoller = new FrontController().getStudentController();
            
            Student std = new Student();
            std.StudentID = "123";
            std.FirstName = "any";
            int asd = contoller.getAllStudents().Count;
            contoller.addOrUpdateStudent(std);
            int sample2 = contoller.getAllStudents().Count;
            Assert.AreEqual(contoller.getStudent("123"),std);
            Assert.AreEqual(contoller.getStudent("123").FirstName, std.FirstName);
            Assert.AreNotEqual(contoller.getAllStudents().Count, asd);
            Assert.AreEqual(sample2, contoller.getAllStudents().Count);
        }

        [Test]
        public void testUpdateStudent()
        {
            Student std = new Student();
            std.StudentID = "123";
            std.FirstName = "any";
            contoller.addOrUpdateStudent(std);
            std.FirstName = "sample";
            int asd = contoller.getAllStudents().Count;
            contoller.addOrUpdateStudent(std);
            Assert.AreEqual(contoller.getStudent("123"), std);
            Assert.AreEqual(contoller.getStudent("123").FirstName, "sample");
            Assert.AreEqual(contoller.getAllStudents().Count, asd);
        }

        [Test]
        public void testNullStudent()
        {
            Student str = new Student();
            str = null;
            Assert.AreEqual(contoller.getStudent("as"),null);
            Assert.AreEqual(contoller.getAllStudents().Count,0);
            //Test when you pass a null parameter
        }

        [Test]
        public void testRemoveStudent()
        {
            Student str = new Student();
            str.StudentID = "11";
            str.FirstName = "romyr";
            contoller.addOrUpdateStudent(str);
            str.StudentID = "123";
            str.FirstName = "sample";
            contoller.removeStudent("11");
            int asd = contoller.getAllStudents().Count;
            Assert.AreNotEqual(contoller.getStudent("11").StudentID, null);
            Assert.AreEqual(contoller.getAllStudents().Count, asd);
            //Remove a student
            //Test that the student is not present after running the remove function
        }

        [Test]
        public void testAddPeriod()
        {
            Student st = new Student();
            Period pd = new Period();
            st.StudentID = "1223";
            st.FirstName = "sample";
            contoller.addOrUpdateStudent(st);
            pd.PeriodID = 1;
            pd.PeriodName = "term1";
            contoller.addOrUpdatePeriod(st, pd);
            pd.PeriodID = 33;
            pd.PeriodName = "term33";
            int asd = contoller.getStudent("1223").RptCard.Periods.Count;
            Assert.AreEqual(contoller.getStudent("1223").RptCard.Periods.Count, asd);
            Assert.AreEqual(contoller.getPeriod(st, 1), pd);
            Assert.AreEqual(contoller.getPeriodByName(st, "term1"), pd);
            //Test if the period is added to a student
        }

        [Test]
        public void testUpdatePeriod()
        {
            Student st = new Student();
            Period pd = new Period();
            st.StudentID = "1223";
            st.FirstName = "sample";
            contoller.addOrUpdateStudent(st);
            pd.PeriodID = 1;
            pd.PeriodName = "term1";
            contoller.addOrUpdatePeriod(st, pd);
            int asd = contoller.getStudent("1223").RptCard.Periods.Count;
            pd.PeriodName = "term2";
            contoller.addOrUpdatePeriod(st, pd);
            Assert.AreEqual(contoller.getStudent("1223").RptCard.Periods.Count, asd);
            Assert.AreEqual(contoller.getPeriod(st, 1), pd);
            Assert.AreEqual(contoller.getPeriodByName(st, "term2"), pd);
            Assert.AreNotEqual(contoller.getPeriod(st, 1).PeriodName, "term1");
            //test if the period is updated
        }

        [Test]
        public void testAddNullPeriod()
        {
            Student st = new Student();
            Period pd = new Period();
            st.StudentID = "12";
            st.FirstName = "sample";
            contoller.addOrUpdateStudent(st);
            pd = null;
            contoller.addOrUpdatePeriod(st, pd);
            Assert.AreEqual(contoller.getPeriod(st, 1), null);
            Assert.AreEqual(contoller.getStudent("12").RptCard.Periods.Count, 0);
            //test if null student was inserted
        }
        
        [Test]
        public void testAddSubjectOrGrade()
        {
            Period p = new Period();
            p.PeriodID = 1;
            p.PeriodName = "term 1";
            Grade g = new Grade();
            g.SubjectID = "11";
            g.SubjectName = "sample";
            Student str = new Student();
            str.StudentID = "123";
            contoller.addOrUpdateStudent(str);
            contoller.addOrUpdatePeriod(str, p);
            contoller.addOrUpdateGrade(str, g, p);
            g.SubjectID = "b2";
            g.SubjectName = "gendou";
            contoller.addOrUpdateGrade(str, g, p);
            int asd = contoller.getPeriod(str, 1).Grades.Count;
            Assert.AreEqual(contoller.getPeriod(str, 1).Grades.Find(delegate(Grade gd) { return gd.SubjectID.Equals(g.SubjectID); }), g);
            Assert.AreEqual(contoller.getPeriod(str, 1).Grades.Count, asd);
            //Add a new subject
            //Test that the subject is now present
        }

        [Test]
        public void testUpdateSubjectOrGrade()
        {
            Period p = new Period();
            p.PeriodID = 1;
            p.PeriodName = "term 1";
            Grade g = new Grade();
            g.SubjectID = "11";
            g.SubjectName = "sample";
            Student str = new Student();
            str.StudentID = "123";
            contoller.addOrUpdateStudent(str);
            contoller.addOrUpdatePeriod(str, p);
            contoller.addOrUpdateGrade(str, g, p);
            int asd = contoller.getPeriod(str, 1).Grades.Count;
            g.SubjectName = "changedsample";
            g.LetterGrade = "A+";
            contoller.addOrUpdateGrade(str, g, p);
            Assert.AreEqual(contoller.getPeriod(str, 1).Grades.Count, asd);
            Assert.AreEqual(contoller.getPeriod(str,1).Grades.Find(delegate(Grade gd) { return gd.SubjectID.Equals(g.SubjectID); }), g);
            //Check that two duplicate subjects are not created
            //Check that the new subject is updated after
        }

        [Test]
        public void testNullSubjectOrGrade()
        {
            Period p = new Period();
            p.PeriodID = 1;
            p.PeriodName = "term 1";
            Grade g = new Grade();
            g = null;
            Student str = new Student();
            str.StudentID = "123";
            contoller.addOrUpdateStudent(str);
            contoller.addOrUpdatePeriod(str, p);
            contoller.addOrUpdateGrade(str, g, p);
            Assert.AreEqual(contoller.getPeriod(str, 1).Grades.Count, 0);
            Assert.AreEqual(contoller.getPeriod(str, 1).Grades.Find(delegate(Grade gd) { return gd.SubjectID.Equals(g.SubjectID); }), null);
        }

        [Test]
        public void testAddSkill()
        {
            Student st = new Student();
            Period pd = new Period();
            Skill sk = new Skill();
            st.StudentID = "12";
            st.FirstName = "taks";
            pd.PeriodID = 1;
            pd.PeriodName = "sampleterm";
            sk.SkillID = "D1";
            sk.SkillName = "sampleskill";
            contoller.addOrUpdateStudent(st);
            contoller.addOrUpdatePeriod(st, pd);
            contoller.addOrUpdateSkill(st, sk, pd);
            int asd = contoller.getPeriod(st, 1).Skills.Count;
            Assert.AreEqual(contoller.getPeriod(st, 1).Skills.Count, asd);
            Assert.AreEqual(contoller.getPeriod(st, 1).Skills.Find(delegate(Skill sk2) { return sk2.SkillID.Equals(sk.SkillID); }), sk);
        }

        [Test]
        public void testUpdateSkill()
        {
            Student st = new Student();
            Period pd = new Period();
            Skill sk = new Skill();
            st.StudentID = "12";
            st.FirstName = "taks";
            pd.PeriodID = 1;
            pd.PeriodName = "sampleterm";
            sk.SkillID = "D1";
            sk.SkillName = "sampleskill";
            contoller.addOrUpdateStudent(st);
            contoller.addOrUpdatePeriod(st, pd);
            contoller.addOrUpdateSkill(st, sk, pd);
            int asd = contoller.getPeriod(st, 1).Skills.Count;
            sk.SkillName = "sample2";
            sk.NumericGrade = 99;
            contoller.addOrUpdateSkill(st, sk, pd);
            Assert.AreEqual(contoller.getPeriod(st, 1).Skills.Count, asd);
            Assert.AreEqual(contoller.getPeriod(st, 1).Skills.Find(delegate(Skill sk2) { return sk2.SkillID.Equals(sk.SkillID); }), sk);
        }

        [Test]
        public void testAddNullSkill()
        {
            Student st = new Student();
            Period pd = new Period();
            Skill sk = new Skill();
            st.StudentID = "12";
            st.FirstName = "taks";
            pd.PeriodID = 1;
            pd.PeriodName = "sampleterm";
            sk = null;
            contoller.addOrUpdateStudent(st);
            contoller.addOrUpdatePeriod(st, pd);
            contoller.addOrUpdateSkill(st, sk, pd);
            Assert.AreEqual(contoller.getPeriod(st, 1).Skills.Count, 0);
            Assert.AreEqual(contoller.getPeriod(st, 1).Skills.Find(delegate(Skill sk2) { return sk2.SkillID.Equals(sk.SkillID); }), null); 
        }

        [Test]
        public void testAddComment()
        {
            Student stud = new Student();
            Period pp = new Period();
            Comment cs = new Comment();
            cs.CommentText = "BLAH BLAH BLAH! BLAH BLAH BLAH!";
            stud.StudentID = "123";
            pp.PeriodID = 11;
            contoller.addOrUpdateStudent(stud);
            contoller.addOrUpdatePeriod(stud, pp);
            contoller.addOrUpdateComment(stud, cs, pp);
            Assert.AreEqual(contoller.getPeriod(stud, 11).PeriodComment.CommentText, cs.CommentText);

        }

        [Test]
        public void testUpdateComment()
        {
            Student stud = new Student();
            Period pp = new Period();
            Comment cs = new Comment();
            cs.CommentText = "BLAH BLAH BLAH! BLAH BLAH BLAH!";
            stud.StudentID = "123";
            pp.PeriodID = 11;
            contoller.addOrUpdateStudent(stud);
            contoller.addOrUpdatePeriod(stud, pp);
            contoller.addOrUpdateComment(stud, cs, pp);
            cs.CommentText = "argh argh argh arghar";
            contoller.addOrUpdateComment(stud, cs, pp);
            Assert.AreEqual(contoller.getPeriod(stud, 11).PeriodComment.CommentText.ToString(), "argh argh argh arghar");

        }

        [Test]
        public void testAddNullComment()
        {
            Student stud = new Student();
            Period pp = new Period();
            Comment cs = new Comment();
            cs = null;
            stud.StudentID = "123";
            pp.PeriodID = 11;
            contoller.addOrUpdateStudent(stud);
            contoller.addOrUpdatePeriod(stud, pp);
            contoller.addOrUpdateComment(stud, cs, pp);
            Assert.AreNotEqual(contoller.getPeriod(stud, 11).PeriodComment.CommentText.ToString(), "argh argh argh arghar");
            Assert.AreEqual(contoller.getPeriod(stud, 11).PeriodComment, null);

        }

        [Test]
        public void testAddAttendance()
        {
            Student st = new Student();
            Period ps = new Period();
            Attendance at = new Attendance();
            st.StudentID = "11";
            ps.PeriodID = 11;
            at.DaysPresent = 11;
            at.DaysTardy = 100;
            contoller.addOrUpdateStudent(st);
            contoller.addOrUpdatePeriod(st, ps);
            contoller.addOrUpdateAttendance(st, at, ps);
            Assert.AreEqual(contoller.getPeriod(st, 11).PeriodAttendance, at);
            Assert.AreEqual(contoller.getPeriod(st, 11).PeriodAttendance.DaysPresent, 11);

        }

        [Test]
        public void testUpdateAttendance()
        {
            Student st = new Student();
            Period ps = new Period();
            Attendance at = new Attendance();
            st.StudentID = "11";
            ps.PeriodID = 11;
            at.DaysPresent = 11;
            at.DaysTardy = 100;
            contoller.addOrUpdateStudent(st);
            contoller.addOrUpdatePeriod(st, ps);
            contoller.addOrUpdateAttendance(st, at, ps);
            at.DaysPresent = 99;
            contoller.addOrUpdateAttendance(st, at, ps);
            Assert.AreEqual(contoller.getPeriod(st, 11).PeriodAttendance, at);
            Assert.AreNotEqual(contoller.getPeriod(st, 11).PeriodAttendance.DaysPresent, 11);
            Assert.AreEqual(contoller.getPeriod(st, 11).PeriodAttendance.DaysPresent, 99);
        }

        [Test]
        public void testAddNullAttendance()
        {
            Student st = new Student();
            Period ps = new Period();
            Attendance at = new Attendance();
            st.StudentID = "11";
            ps.PeriodID = 11;
            at = null;
            contoller.addOrUpdateStudent(st);
            contoller.addOrUpdatePeriod(st, ps);
            contoller.addOrUpdateAttendance(st, at, ps);
            Assert.AreEqual(contoller.getPeriod(st, 11).PeriodAttendance, at);
            Assert.AreEqual(contoller.getPeriod(st, 11).PeriodAttendance.DaysPresent, null);
        }

        [TearDown]
        public void teardown()
        {
            State.getInstance().Students = oldStudents;
        }
    }
}
