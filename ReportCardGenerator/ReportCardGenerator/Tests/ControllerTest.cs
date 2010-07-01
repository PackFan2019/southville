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
            //Add data programmatically here
            /*Student s = new Student();
             * s.FirstName = "..."
             * 
            */
        }


        [Test]
        public void testAddNewStudent()
        {
            //contoller = new FrontController().getStudentController();
            
            Student std = new Student();
            //NUnit.Framework.
            std.StudentID = "123";
            std.FirstName = "any";
            contoller.addOrUpdateStudent(std);
            //////Student totest = contoller.getStudent("123");
            Assert.AreEqual(contoller.getStudent("123"),std);
            Assert.AreEqual(contoller.getStudent("123"), std);
        }

        [Test]
        public void testUpdateStudent()
        {
            Student std = new Student();
            std.StudentID = "123";
            std.FirstName = "any";
            contoller.addOrUpdateStudent(std);
            //std.FirstName = "sample";
            //contoller.addOrUpdateStudent(std);
            //Student std2 = contoller.getStudent("123");
            Assert.AreEqual(contoller.getStudent("123"), std);
            Assert.AreEqual(contoller.getStudent("123"), std);
        }

        [Test]
        public void testNullStudent()
        {
            Student str = new Student();
            str = null;
            //contoller.addOrUpdateStudent(str);
            Assert.AreEqual(contoller.getStudent("as"),null);
            //Test when you pass a null parameter
        }

        [Test]
        public void testRemoveStudent()
        {
            Student str = new Student();
            str.StudentID = "11";
            str.FirstName = "romyr";
            contoller.addOrUpdateStudent(str);
            contoller.removeStudent("11");
            //Assert.AreNotEqual(contoller.getStudent("11").StudentID, "11");
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
            pd.PeriodName = "term2";
            contoller.addOrUpdatePeriod(st, pd);
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
            //test
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
            Assert.AreEqual(contoller.getPeriod(str, 1), p);
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
            g.SubjectName = "changedsample";
            g.LetterGrade = "A+";
            contoller.addOrUpdateGrade(str, g, p);
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
            Assert.AreEqual(contoller.getPeriod(str, 1).Grades.Find(delegate(Grade gd) { return gd.SubjectID.Equals(g.SubjectID); }), null);
        }

        [TearDown]
        public void teardown()
        {
            State.getInstance().Students = oldStudents;
        }
    }
}
