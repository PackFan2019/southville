using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using ReportCardGenerator.Data;
using ReportCardGenerator.Controller;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Utilities;
using ReportCardGenerator.Exceptions;
namespace ReportCardGenerator.Tests
{
    [TestFixture]
    public class EGPParserTest
    {
        //Put Sample XML here for a Homeroom class (Same 5 students, with attendance
        //and deportment)
        //Put A sample for a combined gradebook class (3 terms, 3 subjects, 5 students)
        IStudentController controller = FrontController.getInstance().getStudentController();
        private List<Student> oldRecords;
        [SetUp]
        public void setup()
        {
            //1.Setup the environment by holding a link to the old state (student list)
            //2.Create a new list of students
            //3.Use the frontcontroller to add to the state
            //4.Run the EGPXMLParser on HomeroomSample and CombinedGradebooks
            
            //Get the controller
            //controller = FrontController.getInstance().getStudentController();
            //Save a state to the old records
            oldRecords = controller.getAllStudents();
            State.getInstance().Students.Clear();
            //Clear the list of students
            //controller.clearStudents();
            //Get the xml document
            //XmlDocument doc = Utilities.FileData.getXmlFromPath("Put the path to the CombinedGradebooks here");
            ////Parse the homeroom xml
            //EGPXMLParser.parseHomeroomXML(controller, doc);


        }

        [Test]//, ExpectedException(typeof(DuplicateStudentException))]
        public void testAddStudentsFromXML()
        {
            Student stud = new Student();
            stud.StudentID = "07-0052";
            stud.FirstName = "Maria Syahirah Binti";
            stud.LastName = "Ahmad";
            XmlDocument doc = new XmlDocument();
            doc.Load("XML Gradebook.xml");
            EGPXMLParser.parseHomeroomXML(FrontController.getInstance().getStudentController(), doc);
            int count = controller.getAllStudents().Count;

            //foreach (Student stu in State.getInstance().Students)
            //{
            //    System.Windows.Forms.MessageBox.Show(stu.StudentID);
            //}
            int sample = State.getInstance().Students.Count;
            //System.Windows.Forms.MessageBox.Show(sample.ToString());
            Assert.AreEqual(controller.getAllStudents().Count, count);
            Assert.AreEqual(controller.getStudent("07-0052").StudentID, stud.StudentID);
            Assert.AreEqual(controller.getStudent("07-0052").FirstName, stud.FirstName);
            Assert.AreEqual(controller.getStudent("07-0052").LastName, stud.LastName);
            //Assert.AreEqual(controller.getStudent("4335"), stud);
            
        }
        [Test]
        public void testaddSkillsFromXML()
        {
            Student stud = new Student();
            stud.StudentID = "07-0052";
            stud.FirstName = "Maria Syahirah Binti";
            stud.LastName = "Ahmad";
            XmlDocument doc = new XmlDocument();
            doc.Load("XML Homeroom.xml");
            EGPXMLParser.parseHomeroomXML(FrontController.getInstance().getStudentController(), doc);

            //Assert.AreEqual()
        }
        [Test]
        public void testaddGradesFromXML()
        {
            XmlDocument doc = new XmlDocument();
            Student stud = new Student();
            Grade gd = new Grade();
            Period per = new Period();
            doc.Load("XML Gradebook.xml");
            stud.StudentID = "07-0052";
            gd.SubjectID = "Quiz#1";
            gd.NumericGrade = 97;
            gd.LetterGrade = "A";
            EGPXMLParser.parseGradebookXML(FrontController.getInstance().getStudentController(), doc);
            //int count = controller.getPeriod(stud, 2).Grades.Count;
            //System.Windows.Forms.MessageBox.Show(controller.getPeriod(stud,2).Grades.Count.ToString());
            //for (int i = 0; i < count; i++)
            //{
            //    foreach (Grade g in controller.getPeriod(stud, i).Grades)
            //    {
            //        System.Windows.Forms.MessageBox.Show(stud.StudentID + " " + g.NumericGrade.ToString());
            //    }
            //}
            //Assert.AreEqual(controller.getPeriod(stud, 2).Grades.Count,count );
            Assert.AreEqual(controller.getPeriod(stud, 1).Grades.Find(delegate(Grade grade) { return grade.SubjectID.Equals(gd.SubjectID); }), gd.SubjectID);
            Assert.AreEqual(controller.getPeriod(stud, 1).Grades.Find(delegate(Grade grade) { return grade.LetterGrade.Equals(gd.LetterGrade); }), gd.LetterGrade);
            Assert.AreEqual(controller.getPeriod(stud, 1).Grades.Find(delegate(Grade grade) { return grade.NumericGrade.Equals(gd.NumericGrade); }), gd.NumericGrade);
        }
        [Test]
        public void testaddAttendanceFromXML()
        {
            //Student stud = new Student();
            //stud.StudentID = "4335";
            //stud.FirstName = "Romyr";
            //stud.LastName = "Reyes";
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"c:\XML Gradebook.xml");
            //EGPXMLParser.parseGradebookXML(FrontController.getInstance().getStudentController(), doc);
        }
        [Test]
        public void testaddCommentsFromXML()
        {

        }

















        //[Test]
        //public void testHomeroomSkills()
        //{
        //    ////Instructions
        //    ////1.Check specific homeroom skills from 3-4 students
        //    ////from 2-3 different terms
        //    ////IStudentController controller = FrontController.getInstance().getStudentController();
        //    ////Student s = controller.getStudent("09-0073");
        //    ////Period p = new Period();
        //    ////p = controller.getPeriod(controller.getStudent("09-0073"), "3");
        //    ////List<Skill> skills = p.Skills;
        //    ////Here I will iterate and check that I find the following..
        //    ////Skill s = p.Skills.Find(D5)
        //    ////The letter grade and the numeric grade of s is correct.
        //    ////Skill skill = new Skill();
        //    ////Assert.AreEqual(skill.LetterGrade, "S");
        //    ////Assert.AreEqual(skill.NumericGrade, 95);
        //    //1.Check specific homeroom skills from 3-4 students
        //    //from 2-3 different terms
        //    //IStudentController controller = FrontController.getInstance().getStudentController();
        //    //Student s = controller.getStudent("09-0073");
        //    //Period p = controller.getPeriod(s,3);
        //    //List<Skill> skills = p.Skills;
        //    ////Here I will iterate and check that I find the following..
        //    ////Skill s = p.Skills.Find(D5)
        //    ////The letter grade and the numeric grade of s is correct.
        //    //Skill skill = new Skill();
        //    //Assert.AreEqual(skill.LetterGrade, "S");
        //    //Assert.AreEqual(skill.NumericGrade, 95);


        //    //Assert.AreEqual(true, true);
        //}

        //[Test]
        //public void testAttendance()
        //{

        //    //Instructions
        //    //1. Check specific attendance records (tardiness, late, etc) from 3-4 students
        //    //from 2-3 different terms
        //    //Assert.AreEqual(true, true);
        //}

        //[Test]

        //public void testGrades()
        //{
        //    //Instructions
        //    //1. Check that the grades are retrieved for 3-4 students in 2-3 different terms
        //    //2. Check the SubjectID, SubjectName, SubjectGroup are correct
        //    //3. Check the numeric grades
        //    //4. Check the letter grades
            
        //}

        //[Test]

        //public void testComments()
        //{
        //    //Instructions
        //    //1. Check that you can retrieve comments from 3-4 students in 2-3 different
        //    //terms
        //    //Term 1: 02-0190: Check that "Airi is a great student!"
        //    //Term 3: 04-0140: Check that "Beatrice was fantastic this term definitely!"
        //}
        [TearDown]
        public void tearDown()
        {
            //Set the old list of students directly into the State
            //FrontController.getInstance().getStudentController().setStudents(oldRecords);
            State.getInstance().Students = oldRecords;
        }
    }
}
