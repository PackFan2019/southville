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
using ReportCardGenerator.Views;
using ReportCardGenerator.Reports;

namespace ReportCardGenerator.Controller
{
    class GradeController:IGradeController
    {
        public static String source = "";
        #region Finals variables
        double math1 = 0;
        double math2 = 0;
        double math3 = 0;
        double math4 = 0;

        double science1 = 0;
        double science2 = 0;
        double science3 = 0;
        double science4 = 0;

        double read1 = 0;
        double read2 = 0;
        double read3 = 0;
        double read4 = 0;

        double lang1 = 0;
        double lang2 = 0;
        double lang3 = 0;
        double lang4 = 0;

        double hist1 = 0;
        double hist2 = 0;
        double hist3 = 0;
        double hist4 = 0;

        double lead1 = 0;
        double lead2 = 0;
        double lead3 = 0;
        double lead4 = 0;

        double fil1 = 0;
        double fil2 = 0;
        double fil3 = 0;
        double fil4 = 0;

        double spfl1 = 0;
        double spfl2 = 0;
        double spfl3 = 0;
        double spfl4 = 0;


        double comp1 = 0;
        double comp2 = 0;
        double comp3 = 0;
        double comp4 = 0;

        double PE1 = 0;
        double PE2 = 0;
        double PE3 = 0;
        double PE4 = 0;

        double Art1 = 0;
        double Art2 = 0;
        double Art3 = 0;
        double Art4 = 0;

        double Music1 = 0;
        double Music2 = 0;
        double Music3 = 0;
        double Music4 = 0;

        double Forex1 = 0;
        double Forex2 = 0;
        double Forex3 = 0;
        double Forex4 = 0;

        double cocur1 = 0;
        double cocur2 = 0;
        double cocur3 = 0;
        double cocur4 = 0;

        double deport1 = 0;
        double deport2 = 0;
        double deport3 = 0;
        double deport4 = 0;

        double reli1 = 0;
        double reli2 = 0;
        double reli3 = 0;
        double reli4 = 0;

        double life1 = 0;
        double life2 = 0;
        double life3 = 0;
        double life4 = 0;

        double conduct1 = 0;
        double conduct2 = 0;
        double conduct3 = 0;
        double conduct4 = 0;

        double rela1 = 0;
        double rela2 = 0;
        double rela3 = 0;
        double rela4 = 0;

        double mape1 = 0;
        double mape2 = 0;
        double mape3 = 0;
        double mape4 = 0;

        double eng1 = 0;
        double eng2 = 0;
        double eng3 = 0;
        double eng4 = 0;

        double slge1 = 0;
        double slge2 = 0;
        double slge3 = 0;
        double slge4 = 0;

        double HE1 = 0;
        double HE2 = 0;
        double HE3 = 0;
        double HE4 = 0;

        double CAS1 = 0;
        double CAS2 = 0;
        double CAS3 = 0;
        double CAS4 = 0;

        double BTA1 = 0;
        double BTA2 = 0;
        double BTA3 = 0;
        double BTA4 = 0;

        double entrep1 = 0;
        double entrep2 = 0;
        double entrep3 = 0;
        double entrep4 = 0;

        double shop1 = 0;
        double shop2 = 0;
        double shop3 = 0;
        double shop4 = 0;

        double homeEco1 = 0;
        double homeEco2 = 0;
        double homeEco3 = 0;
        double homeEco4 = 0;

        double phys1 = 0;
        double phys2 = 0;
        double phys3 = 0;
        double phys4 = 0;
#endregion
        //DataSet2 reportSet = new DataSet2();
        RPdata DS = new RPdata();
        public void loadStudent(Student Stud, UserInputData inputted)
        {

        }
        public void loadStudentDetails(Period tempPeriod, Student Stud, RPdata DS)
        {
            //reportSet = new ReportDataset();
            switch (tempPeriod.PeriodID)
            {
                case 1: DataRow Term1row = DS.Term1.NewRow();
                    FinalComp attTerm1 = new FinalComp();
                    foreach (Comment cm in tempPeriod.PeriodComment)
                    {
                        Term1row["Comment"] = cm.CommentText;
                    }
                    foreach (Attendance attend in tempPeriod.PeriodAttendance)
                    {
                        attTerm1.Absent = attend.DaysAbsent;
                        attTerm1.Tardy = attend.DaysTardy;
                        Term1row["Absents"] = attend.DaysAbsent;
                        Term1row["Lates"] = attend.DaysTardy;
                        Term1row["Present"] = attend.DaysPresent;
                    }
                    Term1row["StudentId"] = Stud.StudentID;
                    attTerm1.StudId = Stud.StudentID;

                    FinalComp.AttendanceTerm1.Add(attTerm1);
                    DS.Term1.Rows.Add(Term1row);
                    break;

                case 2:

                    DataRow Term2row = DS.Term2.NewRow();
                    FinalComp attTerm2 = new FinalComp();
                    foreach (Comment cm in tempPeriod.PeriodComment)
                    {
                        Term2row["Comment"] = cm.CommentText;
                    }
                    foreach (Attendance attend in tempPeriod.PeriodAttendance)
                    {
                        attTerm2.Absent = attend.DaysAbsent;
                        attTerm2.Tardy = attend.DaysTardy;
                        Term2row["Absents"] = attend.DaysAbsent;
                        Term2row["Lates"] = attend.DaysTardy;
                        Term2row["Present"] = attend.DaysPresent;
                    }

                    Term2row["StudentId"] = Stud.StudentID;
                    attTerm2.StudId = Stud.StudentID;

                    FinalComp.AttendanceTerm2.Add(attTerm2);
                    DS.Term2.Rows.Add(Term2row);
                    break;

                case 3:
                    FinalComp attTerm3 = new FinalComp();
                    DataRow Term3row = DS.Term3.NewRow();
                    foreach (Comment cm in tempPeriod.PeriodComment)
                    {
                        Term3row["Comment"] = cm.CommentText;
                    }
                    foreach (Attendance attend in tempPeriod.PeriodAttendance)
                    {
                        attTerm3.Absent = attend.DaysAbsent;
                        attTerm3.Tardy = attend.DaysTardy;
                        Term3row["Absents"] = attend.DaysAbsent;
                        Term3row["Lates"] = attend.DaysTardy;
                        Term3row["Present"] = attend.DaysPresent;
                    }
                    Term3row["StudentId"] = Stud.StudentID;
                    attTerm3.StudId = Stud.StudentID;

                    FinalComp.AttendanceTerm3.Add(attTerm3);
                    DS.Term3.Rows.Add(Term3row);
                    break;
            }
        }
        #region
        public DataRow loadSkills(Period tempPeriod, String StudId, DataRow srow, List<FinalComp> ListSkills)
        {
            srow["a1"] = isNotNullESLR("A1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A1", tempPeriod), "A1", ListSkills);
            srow["a2"] = isNotNullESLR("A2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A2", tempPeriod), "A2", ListSkills);
            srow["a3"] = isNotNullESLR("A3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A3", tempPeriod), "A3", ListSkills);
            srow["a4"] = isNotNullESLR("A4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A4", tempPeriod), "A4", ListSkills);
            srow["a5"] = isNotNullESLR("A5", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A5", tempPeriod), "A5", ListSkills);
            srow["a6"] = isNotNullESLR("A6", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A6", tempPeriod), "A6", ListSkills);
            srow["a7"] = isNotNullESLR("A7", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A7", tempPeriod), "A7", ListSkills);
            srow["a8"] = isNotNullESLR("A8", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A8", tempPeriod), "A8", ListSkills);
            srow["a9"] = isNotNullESLR("A9", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A9", tempPeriod), "A9", ListSkills);
            srow["a10"] = isNotNullESLR("A10", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A10", tempPeriod), "A10", ListSkills);

            srow["b1"] = isNotNullESLR("B1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B1", tempPeriod), "B1", ListSkills);
            srow["b2"] = isNotNullESLR("B2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B2", tempPeriod), "B2", ListSkills);
            srow["b3"] = isNotNullESLR("B3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B3", tempPeriod), "B3", ListSkills);
            srow["b4"] = isNotNullESLR("B4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B4", tempPeriod), "B4", ListSkills);


            srow["c1"] = isNotNullESLR("C1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C1", tempPeriod), "C1", ListSkills);
            srow["c2"] = isNotNullESLR("C2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C2", tempPeriod), "C2", ListSkills);
            srow["c3"] = isNotNullESLR("C3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C3", tempPeriod), "C3", ListSkills);
            srow["c4"] = isNotNullESLR("C4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C4", tempPeriod), "C4", ListSkills);

            srow["d1"] = isNotNullESLR("D1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D1", tempPeriod), "D1", ListSkills);
            srow["d2"] = isNotNullESLR("D2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D2", tempPeriod), "D2", ListSkills);
            srow["d3"] = isNotNullESLR("D3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D3", tempPeriod), "D3", ListSkills);
            srow["d4"] = isNotNullESLR("D4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D4", tempPeriod), "D4", ListSkills);
            srow["d5"] = isNotNullESLR("D5", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D5", tempPeriod), "D5", ListSkills);
            srow["d6"] = isNotNullESLR("D6", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D6", tempPeriod), "D6", ListSkills);

            srow["e1"] = isNotNullESLR("E1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("E1", tempPeriod), "E1", ListSkills);
            srow["e2"] = isNotNullESLR("E2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("E2", tempPeriod), "E2", ListSkills);
            srow["e3"] = isNotNullESLR("E3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("E3", tempPeriod), "E3", ListSkills);

            srow["StudentId"] = StudId;
            //SkillsFinalComputation(StudId);
            return srow;
        }
        private void addToSkillList(String StudId, Double grade, String SkillId, List<FinalComp> ListSkills)
        {
            FinalComp finalComp = new FinalComp();
            finalComp.StudId = StudId;
            finalComp.SkillGrade = grade;
            finalComp.SkillId = SkillId;
            if (finalComp.StudId != null || finalComp.StudId != "")
            {
                ListSkills.Add(finalComp);
            }
        }
        public DataRow SkillsFinalComputation(String StudId, DataRow srow)
        {
            #region loading of grade to final table from list
            srow["a1"] = ESLRchecker(getSkillFinal("A1", StudId));
            srow["a2"] = ESLRchecker(getSkillFinal("A2", StudId));
            srow["a3"] = ESLRchecker(getSkillFinal("A3", StudId));
            srow["a4"] = ESLRchecker(getSkillFinal("A4", StudId));
            srow["a5"] = ESLRchecker(getSkillFinal("A5", StudId));
            srow["a6"] = ESLRchecker(getSkillFinal("A6", StudId));
            srow["a7"] = ESLRchecker(getSkillFinal("A7", StudId));
            srow["a8"] = ESLRchecker(getSkillFinal("A8", StudId));
            srow["a9"] = ESLRchecker(getSkillFinal("A9", StudId));
            srow["a10"] = ESLRchecker(getSkillFinal("A10", StudId));

            srow["b1"] = ESLRchecker(getSkillFinal("B1", StudId));
            srow["b2"] = ESLRchecker(getSkillFinal("B2", StudId));
            srow["b3"] = ESLRchecker(getSkillFinal("B3", StudId));
            srow["b4"] = ESLRchecker(getSkillFinal("B4", StudId));


            srow["c1"] = ESLRchecker(getSkillFinal("C1", StudId));
            srow["c2"] = ESLRchecker(getSkillFinal("C2", StudId));
            srow["c3"] = ESLRchecker(getSkillFinal("C3", StudId));
            srow["c4"] = ESLRchecker(getSkillFinal("C4", StudId));

            srow["d1"] = ESLRchecker(getSkillFinal("D1", StudId));
            srow["d2"] = ESLRchecker(getSkillFinal("D2", StudId));
            srow["d3"] = ESLRchecker(getSkillFinal("D3", StudId));
            srow["d4"] = ESLRchecker(getSkillFinal("D4", StudId));
            srow["d5"] = ESLRchecker(getSkillFinal("D5", StudId));
            srow["d6"] = ESLRchecker(getSkillFinal("D6", StudId));

            srow["e1"] = ESLRchecker(getSkillFinal("E1", StudId));
            srow["e2"] = ESLRchecker(getSkillFinal("E2", StudId));
            srow["e3"] = ESLRchecker(getSkillFinal("E3", StudId));
            srow["StudentId"] = StudId;
            #endregion
            return srow;

        }
        public Double getSkillFinal(String SkillId, String StudId)
        {
            #region
            //try
            //{
            int term1 = 0;
            int term2 = 0;
            int term3 = 0;
            FinalComp finalComp = null;
            FinalComp finalComp2 = null;
            FinalComp finalComp3 = null;
            if (isOnSkillList(SkillId, FinalComp.ListSkillTerm1))
            {
                finalComp = FinalComp.ListSkillTerm1.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudId) && fcomp.SkillId.Equals(SkillId) && fcomp.SkillGrade != 0)
                    {
                        term1 = 1;
                        return true;
                    }
                    else { return false; }
                });
            }
            if (isOnSkillList(SkillId, FinalComp.ListSkillTerm2))
            {
                finalComp2 = FinalComp.ListSkillTerm2.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudId) && fcomp.SkillId.Equals(SkillId) && fcomp.SkillGrade != 0)
                    {
                        term2 = 1;
                        return true;

                    }
                    else { return false; }
                });
            }
            if (isOnSkillList(SkillId, FinalComp.ListSkillTerm3))
            {
                finalComp3 = FinalComp.ListSkillTerm3.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudId) && fcomp.SkillId.Equals(SkillId) && fcomp.SkillGrade != 0)
                    {
                        term3 = 1;
                        return true;

                    }
                    else { return false; }
                });
            }
            if (finalComp != null && finalComp2 != null && finalComp3 != null)
            {
                return (finalComp.SkillGrade + finalComp2.SkillGrade + finalComp3.SkillGrade) / (term1 + term2 + term3);
            }
            else if (finalComp != null && finalComp2 != null && finalComp3 == null)
            {
                return (finalComp.SkillGrade + finalComp2.SkillGrade) / (term1 + term2);
            }
            else if (finalComp != null && finalComp2 == null && finalComp3 != null)
            {
                return (finalComp.SkillGrade + finalComp3.SkillGrade) / (term1 + term3);
            }
            else if (finalComp == null && finalComp2 != null && finalComp3 != null)
            {
                return (finalComp2.SkillGrade + finalComp3.SkillGrade) / (term2 + term3);
            }
            else if (finalComp != null && finalComp2 == null && finalComp3 == null)
            {
                return (finalComp.SkillGrade) / (term1);
            }
            else if (finalComp == null && finalComp2 != null && finalComp3 == null)
            {
                return (finalComp2.SkillGrade) / (term2);
            }
            else if (finalComp == null && finalComp2 == null && finalComp3 != null)
            {
                return (finalComp3.SkillGrade) / (term3);
            }
            else { return 0; }
            //}
            //catch (Exception er)
            //{
            //    //MessageBox.Show(er.Message);
            //    return 0;
            //}
            //finally
            //{
            //}
            #endregion
        }
        public DataRow loadGrade(Period tempPeriod, Student Stud, DataRow grow, List<FinalComp> ListGrade)
        {
            #region loading of grades to datarow from List
            //Math
            grow["Math"] = isNotNull("MATH", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("MATH", tempPeriod, Stud), "MATH", ListGrade);
            //Science
            grow["Science"] = isNotNull("SCIE", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("SCIE", tempPeriod, Stud), "SCIE", ListGrade);

            //if (source == "Grade 1" || source == "Grade 2")
            //{
            //    grow["English"] = isNotNull("READ", tempPeriod,Stud);
            //    rela1 = isNotNullNumericGrade("READ", tempPeriod,Stud);
            //}


            //Reading
            grow["Reading"] = isNotNull("READ", tempPeriod);
            read1 = isNotNullNumericGrade("READ", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("READ", tempPeriod, Stud), "READ", ListGrade);


            //Language
            grow["Language"] = isNotNull("LANG", tempPeriod);
            lang1 = isNotNullNumericGrade("LANG", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("LANG", tempPeriod, Stud), "LANG", ListGrade);

            if (StudReportCard.source.Equals("Grade 1") || StudReportCard.source.Equals("Grade 2") || StudReportCard.source.Equals("Grade 3-ILC") || StudReportCard.source.Equals("Grade 4-ILC") || StudReportCard.source.Equals("Grade 5-ILC") || StudReportCard.source.Equals("Grade 6-ILC") || StudReportCard.source.Equals("Grade 7-ILC") || StudReportCard.source.Equals("Upper School I") || StudReportCard.source.Equals("Upper School I-ILC") || StudReportCard.source.Equals("Upper School II") || StudReportCard.source.Equals("Upper School II-ILC") || StudReportCard.source.Equals("Upper School III") || StudReportCard.source.Equals("Upper School III-ILC") || StudReportCard.source.Equals("Upper School IV") ||StudReportCard.source.Equals("Upper School IV-ILC"))
            {
                grow["English"] = isNotNull("ENGL", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("ENGL", tempPeriod, Stud), "ENGL", ListGrade);

            }
            else
            {
                if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("LANG"); }) != null && tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("READ"); }) == null)
                {
                    rela1 = lang1;
                    grow["English"] = checker(Math.Round(rela1, 2), tempPeriod.PeriodID);
                    addToList(Stud, rela1, "ENGL", ListGrade);
                }
                else if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("READ"); }) != null && tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("LANG"); }) == null)
                {
                    rela1 = read1;
                    grow["English"] = checker(Math.Round(rela1, 2), tempPeriod.PeriodID);
                    addToList(Stud, rela1, "ENGL", ListGrade);
                }
                else
                {
                    rela1 = (read1 + lang1) / 2;
                    grow["English"] = checker(Math.Round(rela1, 2), tempPeriod.PeriodID);
                    addToList(Stud, rela1, "ENGL", ListGrade);
                }
            }


            //English Upper School 4
            //if (source == "Upper School IV")
            //{
            //    grow["English"] = isNotNull("ENGL", tempPeriod,Stud);
            //    rela1 = isNotNullNumericGrade("ENGL", tempPeriod,Stud);
            //}
            //English Grades 1-6
            //if (source == "Grade 7" || source == "Grade 6" || source == "Grade 5" || source == "Grade 4" || source == "Grade 3")
            //{

            //}
            //History
            grow["History"] = isNotNull("HIST", tempPeriod);
            hist1 = isNotNullNumericGrade("HIST", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("HIST", tempPeriod, Stud), "HIST", ListGrade);

            //Leadership
            grow["Leadership"] = isNotNull("LEAD", tempPeriod);
            lead1 = isNotNullNumericGrade("LEAD", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("LEAD", tempPeriod, Stud), "LEAD", ListGrade);

            if (isOffered("LEAD", tempPeriod, Stud) && !isOffered("HIST", tempPeriod, Stud))
            {
                slge1 = 0;
                grow["SLGE"] = isNotNull("LEAD", tempPeriod);
                addToList(Stud, slge1, "SLGE", ListGrade);
            }
            if (!isOffered("LEAD", tempPeriod, Stud) && isOffered("HIST", tempPeriod, Stud))
            {
                slge1 = 0;
                grow["SLGE"] = isNotNull("HIST", tempPeriod);
                addToList(Stud, slge1, "SLGE", ListGrade);
            }
            //SLGE
            if (isOffered("LEAD", tempPeriod, Stud) && isOffered("HIST", tempPeriod, Stud))
            {
                slge1 = (hist1 + lead1) / 2;
                grow["SLGE"] = checker(Math.Round(slge1), tempPeriod.PeriodID);
                addToList(Stud, slge1, "SLGE", ListGrade);
            }

            //Computer Education
            grow["Computer"] = isNotNull("COMP", tempPeriod);
            comp1 = isNotNullNumericGrade("COMP", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("COMP", tempPeriod, Stud), "COMP", ListGrade);
            //SHOP
            //if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SHOP"); }) != null)
            //{
            //    grow["Shop"] = isNotNull("SHOP", tempPeriod);
            //    homeEco1 = isNotNullNumericGrade("SHOP", tempPeriod, Stud);
            //    addToList(Stud, isNotNullNumericGrade("SHOP", tempPeriod, Stud), "SHOP", ListGrade);
            //}

            //Home Economics
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("HOME"); }) != null)
            {
                grow["HomeEco"] = isNotNull("HOME", tempPeriod);
                homeEco1 = isNotNullNumericGrade("HOME", tempPeriod, Stud);
                addToList(Stud, isNotNullNumericGrade("HOME", tempPeriod, Stud), "HOME", ListGrade);
            }
            else// if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SHOP"); }) != null)
            {
                grow["HomeEco"] = isNotNull("SHOP", tempPeriod);
                homeEco1 = isNotNullNumericGrade("SHOP", tempPeriod, Stud);
                addToList(Stud, isNotNullNumericGrade("HOME", tempPeriod, Stud), "HOME", ListGrade);
            }
            //else
            //{
            //    grow["HomeEco"] = isNotNull("SHOP", tempPeriod);
            //    homeEco1 = isNotNullNumericGrade("SHOP", tempPeriod, Stud);
            //    addToList(Stud, isNotNullNumericGrade("HOME", tempPeriod, Stud), "HOME", ListGrade);
            //}
            //Economics and Investments
            grow["EntrepAcc"] = isNotNull("ECON", tempPeriod);
            entrep1 = isNotNullNumericGrade("ECON", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("ECON", tempPeriod, Stud), "ECON", ListGrade);

            if (StudReportCard.source != "Upper School III-ILC" || StudReportCard.source != "Upper School IV-ILC" || StudReportCard.source != "Upper School II-ILC" || StudReportCard.source != "Upper School I-ILC")
            {
                if (isOffered("ECON", tempPeriod, Stud) && !isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = entrep1;
                }
                else if (isOffered("COMP", tempPeriod, Stud) && !isOffered("ECON", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = comp1;
                }
                else if (isOffered("HOME", tempPeriod, Stud) && !isOffered("ECON", tempPeriod, Stud) && !isOffered("COMP", tempPeriod, Stud))
                {
                    BTA1 = homeEco1;
                }
                else if (isOffered("ECON", tempPeriod, Stud) && isOffered("COMP", tempPeriod, Stud))
                {
                    BTA1 = (entrep1 + comp1) / 2;
                }
                else if (isOffered("ECON", tempPeriod, Stud) && isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = (entrep1 + homeEco1) / 2;
                }
                else if (isOffered("COMP", tempPeriod, Stud) && isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = (comp1 + homeEco1) / 2;
                }
                else if (!isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud) && !isOffered("ECON", tempPeriod, Stud))
                {
                    BTA1 = 0;
                }
            }
            else
            //if (source == "Upper School III-ILC" || source == "Upper School IV-ILC" || source == "Upper School II-ILC" || source == "Upper School I-ILC")
            {
                if (isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = comp1;
                }
                else if (isOffered("HOME", tempPeriod, Stud) && !isOffered("COMP", tempPeriod, Stud))
                {
                    BTA1 = homeEco1;
                }
                else if (isOffered("COMP", tempPeriod, Stud) && isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = (comp1 + homeEco1) / 2;
                }
                else if (!isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = 0;
                }
                //grow["BTA"] = checker(BTA1);
                //addToList(Stud, BTA1, "BTA", ListGrade);

                //If CAS and Art is offered on Term 1
                //if (isOffered("COIN", tempPeriod) && isOffered("ART", tempPeriod))
                //{ mape1 = (PE1 + Art1 + cocur1) / 3; }

                ////If CAS is offered and Art is not
                //if (isOffered("COIN", tempPeriod))
                //{ mape1 = (PE1 + cocur1) / 2; }

                ////If ART is offered and CAS is not
                //if (isOffered("ART", tempPeriod))
                //{ mape1 = (PE1 + Art1) / 2; }
                //grow["MAPE"] = checker(mape1);
                //addToList(Stud, mape1, "MAPE", ListGrade);

            }

            grow["BTA"] = checker(BTA1, tempPeriod.PeriodID);
            addToList(Stud, BTA1, "BTA", ListGrade);
            //Filipino
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("FILI"); }) != null)
            {
                grow["Filipino"] = isNotNull("FILI", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("FILI", tempPeriod, Stud), "FILI", ListGrade);
            }
            //Special Filipino
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SPFL"); }) != null)
            {
                grow["Filipino"] = isNotNull("SPFL", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("SPFL", tempPeriod, Stud), "FILI", ListGrade);
            }

            //PE
            grow["PE"] = isNotNull("PHED", tempPeriod);
            PE1 = isNotNullNumericGrade("PHED", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("PHED", tempPeriod, Stud), "PHED", ListGrade);
            //Art
            grow["Art"] = isNotNull("ART", tempPeriod);
            Art1 = isNotNullNumericGrade("ART", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("ART", tempPeriod, Stud), "ART", ListGrade);
            //Music
            grow["Music"] = isNotNull("MUSI", tempPeriod);
            Music1 = isNotNullNumericGrade("MUSI", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("MUSI", tempPeriod, Stud), "MUSI", ListGrade);
            //MAPE 
            //If PE, Music and Art are offered
            if (isOffered("PHED", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud))
            {
                mape1 = (PE1 + Art1 + Music1) / 3;
            }
            //If Music and Art are offered
            if (!isOffered("PHED", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud))
            {
                mape1 = (Art1 + Music1) / 2;
            }
            //If PE and Music are offered
            if (isOffered("PHED", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud))
            {
                mape1 = (PE1 + Music1) / 2;
            }
            //If PE and Art are offered                      
            if (isOffered("PHED", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = (PE1 + Art1) / 2;
            }
            //If Art is offered and Mustic and PE is not   
            if (!isOffered("PHED", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = Art1;
            }
            //If Music is offered and Art and PE is not  
            if (!isOffered("PHED", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = Music1;
            }
            //If PE is offered and Mustic and Art is not  
            if (isOffered("PHED", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = PE1;
            }
            if (!isOffered("PHED", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = 0;
            }
            grow["MAPE"] = checker(Math.Round(mape1, 2), tempPeriod.PeriodID);
            addToList(Stud, mape1, "MAPE", ListGrade);
            //Co-Curricular
            grow["Co-curricular"] = isNotNull("COIN", tempPeriod);
            cocur1 = isNotNullNumericGrade("COIN", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("COIN", tempPeriod, Stud), "COIN", ListGrade);



            //Homeroom Life
            grow["Life"] = isNotNull("HRLI", tempPeriod);
            life1 = isNotNullNumericGrade("HRLI", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("HRLI", tempPeriod, Stud), "HRLI", ListGrade);

            //Conduct
            grow["Conduct"] = isNotNull("COND", tempPeriod);
            conduct1 = isNotNullNumericGrade("COND", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("COND", tempPeriod, Stud), "COND", ListGrade);


            //Religion/Values
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("RVED1"); }) != null)
            {
                grow["Religion"] = isNotNull("RVED1", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("RVED1", tempPeriod, Stud), "RVED", ListGrade);
            }
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("RVED2"); }) != null)
            {
                grow["Religion"] = isNotNull("RVED2", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("RVED2", tempPeriod, Stud), "RVED", ListGrade);
            }
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("RVED3"); }) != null)
            {
                grow["Religion"] = isNotNull("RVED3", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("RVED3", tempPeriod, Stud), "RVED", ListGrade);
            }

            //Religion for Grade 1 and Grade 2
            if (StudReportCard.source == "Grade 1" || StudReportCard.source == "Grade 2")
            {
                reli1 = (life1 + conduct1) / 2;
                grow["Religion"] = checker(reli1, tempPeriod.PeriodID);
                addToList(Stud, reli1, "RVED", ListGrade);
            }
            //Deportment
            grow["Deport"] = isNotNull("DEPO", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("DEPO", tempPeriod, Stud), "DEPO", ListGrade);

            //FOREX
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("CHIN"); }) != null)
            {
                grow["Forex"] = isNotNull("CHIN", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("CHIN", tempPeriod, Stud), "FOREX", ListGrade);
            }
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("FREN"); }) != null)
            {
                grow["Forex"] = isNotNull("FREN", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("FREN", tempPeriod, Stud), "FOREX", ListGrade);
            }
            //Physics
            grow["Physics"] = isNotNull("PHYS", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("PHYS", tempPeriod, Stud), "PHYS", ListGrade);

            //if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SCIE"); }) == null)
            //{
            //    grow["Science"] = isNotNull("PHYS", tempPeriod);
            //    addToList(Stud, isNotNullNumericGrade("PHYS", tempPeriod, Stud), "SCIE", ListGrade);
            //}
            //CAS
            //grow["Physics"] = isNotNull("PHYS", tempPeriod,Stud);
            //read1 = isNotNullNumericGrade("PHYS", tempPeriod,Stud);  


            //Student ID
            grow["StudentId"] = Stud.StudentID;
            #endregion
            return grow;
        }
        public DataRow FinalComputation(String StudentId, int termPeriod, DataRow drow)
        {
            #region loading of grade to final table from list
            drow["Math"] = checker(getFinal("MATH", StudentId, termPeriod), termPeriod);
            drow["Science"] = checker(getFinal("SCIE", StudentId, termPeriod), termPeriod);
            drow["Reading"] = checker(getFinal("READ", StudentId, termPeriod), termPeriod);
            drow["Language"] = checker(getFinal("LANG", StudentId, termPeriod), termPeriod);
            drow["History"] = checker(getFinal("HIST", StudentId, termPeriod), termPeriod);
            drow["Leadership"] = checker(getFinal("LEAD", StudentId, termPeriod), termPeriod);
            drow["Filipino"] = checker(getFinal("FILI", StudentId, termPeriod), termPeriod);
            drow["Computer"] = checker(getFinal("COMP", StudentId, termPeriod), termPeriod);
            drow["Music"] = checker(getFinal("MUSI", StudentId, termPeriod), termPeriod);
            drow["Art"] = checker(getFinal("ART", StudentId, termPeriod), termPeriod);
            drow["PE"] = checker(getFinal("PHED", StudentId, termPeriod), termPeriod);
            drow["Forex"] = checker(getFinal("FOREX", StudentId, termPeriod), termPeriod);
            drow["Religion"] = checker(getFinal("RVED", StudentId, termPeriod), termPeriod);
            drow["Life"] = checker(getFinal("HRLI", StudentId, termPeriod), termPeriod);
            drow["Co-curricular"] = checker(getFinal("COIN", StudentId, termPeriod), termPeriod);
            drow["Deport"] = checker(getFinal("DEPO", StudentId, termPeriod), termPeriod);
            drow["EntrepAcc"] = checker(getFinal("ECON", StudentId, termPeriod), termPeriod);
            drow["HomeEco"] = checker(getFinal("HOME", StudentId, termPeriod), termPeriod);
            drow["Shop"] = checker(getFinal("SHOP", StudentId, termPeriod), termPeriod);
            drow["SLGE"] = checker(getFinal("SLGE", StudentId, termPeriod), termPeriod);
            drow["Conduct"] = checker(getFinal("COND", StudentId, termPeriod), termPeriod);
            drow["English"] = checker(getFinal("ENGL", StudentId, termPeriod), termPeriod);
            drow["MAPE"] = checker(getFinal("MAPE", StudentId, termPeriod), termPeriod);
            drow["CAS"] = checker(getFinal("CAS", StudentId, termPeriod), termPeriod);
            drow["BTA"] = checker(getFinal("BTA", StudentId, termPeriod), termPeriod);
            drow["Physics"] = checker(getFinal("PHYS", StudentId, termPeriod), termPeriod);
            drow["StudentId"] = StudentId;
            return drow;
            #endregion

        }
        public Double getFinal(String SubjectId, String StudentID, int termPeriod)
        {
            try
            {
                int term1 = 0;
                int term2 = 0;
                int term3 = 0;
                FinalComp finalComp = null;
                FinalComp finalComp2 = null;
                FinalComp finalComp3 = null;
                Double finalAverage = 0;
                FinalComp final = new FinalComp();
                final.SubjectId = SubjectId;
                final.StudId = StudentID;
                //if (isOnList(SubjectId, FinalComp.ListGradeTerm1))
                //{
                finalComp = FinalComp.ListGradeTerm1.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId) && fcomp.Grade != 0)
                    {
                        term1 = 1;
                        return true;
                    }
                    else { return false; }
                });
                //}
                //if (isOnList(SubjectId, FinalComp.ListGradeTerm2))
                //{
                finalComp2 = FinalComp.ListGradeTerm2.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId) && fcomp.Grade != 0)
                    {
                        term2 = 1;
                        return true;

                    }
                    else { return false; }
                });
                //}
                //if (isOnList(SubjectId, FinalComp.ListGradeTerm3))
                //{
                finalComp3 = FinalComp.ListGradeTerm3.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId) && fcomp.Grade != 0)
                    {
                        term3 = 1;
                        return true;

                    }
                    else { return false; }
                });
                //}
                if (finalComp != null && finalComp2 != null && finalComp3 != null)
                {
                    final.Grade = (finalComp.Grade + finalComp2.Grade + finalComp3.Grade) / (term1 + term2 + term3);
                    FinalComp.ListGradeFinal.Add(final);
                    finalAverage = (finalComp.Grade + finalComp2.Grade + finalComp3.Grade) / (term1 + term2 + term3);

                    return finalAverage;
                }
                else
                    if (finalComp != null && finalComp2 != null && finalComp3 == null)
                    {
                        final.Grade = (finalComp.Grade + finalComp2.Grade) / (term1 + term2);
                        FinalComp.ListGradeFinal.Add(final);
                        finalAverage = (finalComp.Grade + finalComp2.Grade) / (term1 + term2);

                        return finalAverage;
                    }
                    else
                        if (finalComp != null && finalComp2 == null && finalComp3 != null)
                        {
                            final.Grade = (finalComp.Grade + finalComp3.Grade) / (term1 + term3);
                            FinalComp.ListGradeFinal.Add(final);
                            finalAverage = (finalComp.Grade + finalComp3.Grade) / (term1 + term3);

                            return finalAverage;
                        }
                        else
                            if (finalComp == null && finalComp2 != null && finalComp3 != null)
                            {
                                final.Grade = (finalComp2.Grade + finalComp3.Grade) / (term2 + term3);
                                FinalComp.ListGradeFinal.Add(final);
                                finalAverage = (finalComp2.Grade + finalComp3.Grade) / (term2 + term3);

                                return finalAverage;
                            }
                            else
                                if (finalComp != null && finalComp2 == null && finalComp3 == null)
                                {
                                    final.Grade = (finalComp.Grade) / (term1);
                                    FinalComp.ListGradeFinal.Add(final);
                                    finalAverage = (finalComp.Grade) / (term1);

                                    return finalAverage;
                                }
                                else
                                    if (finalComp == null && finalComp2 != null && finalComp3 == null)
                                    {
                                        final.Grade = (finalComp2.Grade) / (term2);
                                        FinalComp.ListGradeFinal.Add(final);
                                        finalAverage = (finalComp2.Grade) / (term2);

                                        return finalAverage;
                                    }
                                    else
                                        if (finalComp == null && finalComp2 == null && finalComp3 != null)
                                        {
                                            final.Grade = (finalComp3.Grade) / (term3);
                                            FinalComp.ListGradeFinal.Add(final);
                                            finalAverage = (finalComp3.Grade) / (term3);

                                            return finalAverage;
                                        }
                                        else
                                        {
                                            final.Grade = 0;
                                            FinalComp.ListGradeFinal.Add(final);

                                            return 0;
                                        }
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
                return 0;
            }
            finally
            {
            }
        }
        public void UpdateFinalGrade(DataTable TermFinal, DataTable ActionTaken, String StudentId, int termPeriod)
        {
            foreach (FinalComp extendedGrade in FinalComp.ListGradeSR)
            {
                if (extendedGrade.Grade >= 75)
                {
                    foreach (DataRow drow in TermFinal.Rows)
                    {
                        if (drow["StudentId"].Equals(StudentId) && StudentId.Equals(extendedGrade.StudId))
                        {
                            TermFinal.Rows[TermFinal.Rows.IndexOf(drow)][Translate(extendedGrade.SubjectId)] = checker(extendedGrade.Grade, termPeriod);
                        }
                    }
                }
            }
        }
        private void addToList(Student Stud, Double grade, String SubjectId, List<FinalComp> ListGrade)
        {
            FinalComp finalComp = new FinalComp();
            finalComp.StudId = Stud.StudentID;
            finalComp.Grade = grade;
            finalComp.SubjectId = SubjectId;
            ListGrade.Add(finalComp);
        }
        public DataRow getAttendanceFinalComp(String StudentId, DataRow drow)
        {
            drow["Absents"] = getAbsent(StudentId);
            drow["Lates"] = getTardy(StudentId);
            drow["StudentId"] = StudentId;
            return drow;
        }
        private Double getAbsent(String StudId)
        {
            FinalComp term1 = null;
            FinalComp term2 = null;
            FinalComp term3 = null;
            Double finalAtt = 0;
            Double attTerm1 = 0;
            Double attTerm2 = 0;
            Double attTerm3 = 0;
            term1 = FinalComp.AttendanceTerm1.Find(delegate(FinalComp fc)
            {
                return fc.StudId.Equals(StudId);
            });

            term2 = FinalComp.AttendanceTerm2.Find(delegate(FinalComp fc)
            {
                return fc.StudId.Equals(StudId);
            });

            term3 = FinalComp.AttendanceTerm3.Find(delegate(FinalComp fc)
            {
                return fc.StudId.Equals(StudId);
            });
            if (term1 != null) attTerm1 = term1.Absent;
            else attTerm1 = 0;

            if (term2 != null) attTerm2 = term2.Absent;
            else attTerm2 = 0;

            if (term3 != null) attTerm3 = term3.Absent;
            else attTerm3 = 0;

            return finalAtt = attTerm1 + attTerm2 + attTerm3;
        }
        private Double getTardy(String StudId)
        {
            FinalComp term1 = null;
            FinalComp term2 = null;
            FinalComp term3 = null;
            Double attTerm1 = 0;
            Double attTerm2 = 0;
            Double attTerm3 = 0;
            Double finalAtt = 0;
            term1 = FinalComp.AttendanceTerm1.Find(delegate(FinalComp fc)
            {
                return fc.StudId.Equals(StudId);
            });

            term2 = FinalComp.AttendanceTerm2.Find(delegate(FinalComp fc)
            {
                return fc.StudId.Equals(StudId);
            });

            term3 = FinalComp.AttendanceTerm3.Find(delegate(FinalComp fc)
            {
                return fc.StudId.Equals(StudId);
            });

            if (term1 != null) attTerm1 = term1.Tardy;
            else attTerm1 = 0;

            if (term2 != null) attTerm2 = term2.Tardy;
            else attTerm2 = 0;

            if (term3 != null) attTerm3 = term3.Tardy;
            else attTerm3 = 0;

            return finalAtt = attTerm1 + attTerm2 + attTerm3;
        }
        public void loadSubjectName(Period tempPeriod, Student Stud)
        {
        }
        public String loadSubjects(Grade grade)
        {
            return "";
        }
        private String isNotNull(String SubjectCat, Period p)
        {
            if (p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }) != null)
            {
                String value = p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }).LetterGrade;
                return value;
            }
            else if (p.PeriodID != 4)
            { 
                return "N/A"; 
            }
            else { return ""; }

        }
        private Double isNotNullNumericGrade(String SubjectCat, Period p, Student Stud)
        {
            if (p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }) != null)
            {
                double value = p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }).NumericGrade;
                return value;
            }
            else return 0;

        }
        private Boolean isOffered(String SubjectID, Period p, Student Stud)
        {
            Period period = new Period();
            period = Stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });

            if (period.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectID); }) != null)
            {
                return true;
            }
            else { return false; }
        }
        public static String checker(double value, int termPeriod)
        {
            string variable = "";
            if (value >= 95.5 && value <= 100)
            {
                variable = "VS";
            }
            if (value >= 90.5 && value < 95.5)
            {
                variable = "S";
            }
            if (value >= 85.5 && value < 90.5)
            {
                variable = "AA";
            }
            if (value >= 79.5 && value < 85.5)
            {
                variable = "A";
            }
            if (value >= 74.5 && value < 79.5)
            {
                variable = "LA";
            }
            if (value >= 70 && value <= 74.4)
            {
                variable = "P";
            }
            if (value < 70)
            {
                variable = "INC";
            }
            if (termPeriod != 4)
            {
                if (value == 0.0)
                {
                    variable = "N/A";
                }
            }
            else { variable = ""; }
            return variable;
        }
        public String Translate(String SubjectId)
        {
            String result = "";
            switch (SubjectId)
            {
                case "MATH": result = "Math";
                    break;
                case "SCIE": result = "Science";
                    break;
                case "READ": result = "Reading";
                    break;
                case "LANG": result = "Language";
                    break;
                case "HIST": result = "History";
                    break;
                case "LEAD": result = "Leadership";
                    break;
                case "FILI": result = "Filipino";
                    break;
                case "COMP": result = "Computer";
                    break;
                case "MUSI": result = "Music";
                    break;
                case "ART": result = "Art";
                    break;
                case "PHED": result = "PE";
                    break;
                case "FORE": result = "Forex";
                    break;
                case "FOREX": result = "Forex";
                    break;
                case "RVED": result = "Religion";
                    break;
                case "HRLI": result = "Life";
                    break;
                case "COIN": result = "Co-curricular";
                    break;
                case "DEPO": result = "Deport";
                    break;
                case "ECON": result = "EntrepAcc";
                    break;
                case "HOME": result = "HomeEco";
                    break;
                case "SHOP": result = "Shop";
                    break;
                case "SLGE": result = "SLGE";
                    break;
                case "COND": result = "Conduct";
                    break;
                case "ENGL": result = "English";
                    break;
                case "MAPE": result = "MAPE";
                    break;
                case "CAS": result = "CAS";
                    break;
                case "BTA": result = "BTA";
                    break;
                case "PHYS": result = "Physics";
                    break;
                case "SPFL": result = "SpecialFil";
                    break;
                default: result = "N/A";
                    break;
            }
            return result;
        }
        private String ConvertToLetterGrade(double value)
        {
            string variable = "";
            if (value >= 95.5 && value <= 100)
            {
                variable = "VS";
            }
            if (value >= 90.5)
            {
                variable = "S";
            }
            if (value >= 85.5)
            {
                variable = "AA";
            }
            if (value >= 80)
            {
                variable = "A";
            }
            if (value >= 75)
            {
                variable = "LA";
            }
            if (value >= 70)
            {
                variable = "P";
            }
            if (value < 70)
            {
                variable = "INC";
            }
            return variable;
        }
        private String ESLRchecker(double value)
        {
            string variable = "";
            if (value == 5)
            {
                variable = "VS";
            }
            if (value >= 4 && value < 5)
            {
                variable = "S";
            }
            if (value >= 3 && value < 4)
            {
                variable = "AA";
            }
            if (value >= 2 && value < 3)
            {
                variable = "A";
            }
            if (value >= 1 && value < 2)
            {
                variable = "LA";
            }
            if (value == 0)
            {
                variable = "N/A";
            }
            return variable;
        }
        private Boolean isOnSkillList(String SkillId, List<FinalComp> ListFinal)
        {
            if (ListFinal.Find(delegate(FinalComp final) { return final.SkillId.Equals(SkillId); }) != null)
            {
                return true;
            }
            else { return false; }
        }
        private String isNotNullESLR(String ESLRCat, Period p)
        {
            if (p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }) != null)
            {
                String ESLRValue = p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }).LetterGrade;
                return ESLRValue;
            }
            else return "N/A";
        }
        private Double isNotNullESLRNumeric(String ESLRCat, Period p)
        {
            if (p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }) != null)
            {
                double ESLRValue = p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }).NumericGrade;
                return ESLRValue;
            }
            else return 0;
        }
        public DataSet2 loadReport()
        {
            return DatasetClass.reportSet;
        }
        #endregion
    }
}
