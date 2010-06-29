using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ReportCardGenerator.Data;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Controller;
namespace ReportCardGenerator.Tests
{
    [TestFixture]
    class ControllerTest
    {
        private List<Student> oldStudents;
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

            Student std = new Student();
            std.StudentID = "123";
            std.FirstName = "any";
            contoller.addOrUpdateStudent(std);
            contoller.getStudent("123");
            Assert.AreEqual(std.StudentID, "123");
            Assert.AreEqual(std.FirstName, "any");
        }

        [Test]
        public void testUpdateStudent()
        {
            Student std = new Student();
            std.StudentID = "123";
            std.FirstName = "any";
            contoller.addOrUpdateStudent(std);
            std.FirstName = "sample";
            contoller.addOrUpdateStudent(std);
            Student std2 = contoller.getStudent("123");
            Assert.AreEqual(std.StudentID, "123");
            Assert.AreEqual(std.FirstName, "sample");
        }
        [Test]
        public void testNullStudent()
        {
            Student str = new Student();
            str.StudentID = "as";
            str.FirstName = null;
            contoller.addOrUpdateStudent(str);
            Assert.AreEqual(contoller.getStudent("as"),null);
            //Test when you pass a null parameter
        }
        [Test]
        public void testNoDuplicateStudents()
        {
            Student str = new Student();
            str.StudentID = "122";
            str.FirstName = "ammy";
            contoller.addOrUpdateStudent(str);
            Student str2 = contoller.getStudent("122");
            Assert.AreEqual(str, str2);
            Assert.Fail();
            //Add a duplicate student
            //Test that the duplicateStudentException thrown
            //Assert.Fail() if it is not thrown
        }

        [Test]
        public void testRemoveStudent()
        {
            Student str = new Student();
            str.StudentID = "11";
            str.FirstName = "romyr";
            contoller.addOrUpdateStudent(str);
            contoller.removeStudent("11");
            Assert.AreNotEqual(str.StudentID, "11");
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
