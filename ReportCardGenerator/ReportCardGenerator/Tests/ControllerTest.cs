using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ReportCardGenerator.Data;
namespace ReportCardGenerator.Tests
{
    [TestFixture]
    class ControllerTest
    {
        
        [SetUp]
        public void setup()
        {
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
            
            Assert.AreEqual(true, true);
        }

        [Test]
        public void testUpdateStudent()
        {

        }
        [Test]
        public void testNullStudent()
        {
            //Test when you pass a null parameter
        }
        [Test]
        public void testNoDuplicateStudents()
        {
            //Add a duplicate student
            //Test that the duplicateStudentException thrown
            //Assert.Fail() if it is not thrown
        }

        [Test]
        public void testRemoveStudent()
        {
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
            //Clear the state
        }
    }
}
