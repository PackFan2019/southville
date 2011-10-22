using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Controller;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;

namespace ReportCardGenerator.Interfaces
{
    interface IGradeController
    {
        void loadStudent(Student Stud,UserInputData inputted);
        void loadStudentDetails(Period tempPeriod, Student Stud, RPdata dataset);
        DataRow loadSkills(Period tempPeriod, String StudId, DataRow srow, List<FinalComp> ListSkills);
        DataRow loadGrade(Period tempPeriod, Student Stud, DataRow grow, List<FinalComp> ListGrade);
        void loadSubjectName(Period tempPeriod, Student Stud);
        DataRow FinalComputation(String StudentId, int termPeriod, DataRow drow);
        DataRow getAttendanceFinalComp(String StudentId, DataRow drow);
        DataRow SkillsFinalComputation(String StudId, DataRow srow);
        DataRow TermGradeDistribution(DataRow drow, Period period, Student Stud, List<FinalComp> listGrades);
        Double getSkillFinal(String SkillId, String StudId);
        Double getFinal(String SubjectId, String StudentID, int termPeriod);
        void UpdateFinalGrade(DataTable TermFinal, DataTable ActionTaken, String StudentId, int termPeriod);
        String Translate(String SubjectId);
        DataSet2 loadReport();

        //Double isNotNullNumericGrade(String SubjectCat, Period p);
        //String ConvertToLetterGrade(double value);
        //Double isNotNullESLRNumeric(String ESLRCat, Period p);
    }
}
