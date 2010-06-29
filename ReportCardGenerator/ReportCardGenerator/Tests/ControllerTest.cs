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
            str.StudentID = "as";
            str.FirstName = null;
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
        public void testAddSubject()
        {
            //Add a new subject
            //Test that the subject is now present
        }
        [Test]
        public void testUpdateSubject()
        {
            //Check that two duplicate subjects are not created
            //Check that the new subject is updated after
        }
        [TearDown]
        public void teardown()
        {
            State.getInstance().Students = oldStudents;
        }
    }
}
