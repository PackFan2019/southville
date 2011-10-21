using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Controller;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Reports;

namespace ReportCardGenerator.Beans
{
    class HonorsComputationFormula:SubjectUnit
    {
       static Double cluster1 = 0;
       static Double cluster2 = 0;
       static Double cluster3 = 0;
        public static void Grade1And2(DataTable HonorsTable, String StudentId, String Level, List<FinalComp> listGrades, int termPeriod)
        {
            DataRow Grade6termsRow = HonorsTable.NewRow();
            cluster1 = getCluster1and2NumericGrade1and2("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            cluster2 = getCluster1and2Numeric("SLGE", "RVED", "", Level, StudentId, listGrades);
            Double ave = 0;
            Grade6termsRow["Cluster1"] = getCluster1and2StringGrade1("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            Grade6termsRow["Cluster1Ans"] = getCluster1and2NumericGrade1and2("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            Grade6termsRow["Cluster2"] = getCluster1and2String("SLGE", "RVED", "", Level, StudentId, listGrades);
            Grade6termsRow["Cluster2Ans"] = getCluster1and2Numeric("SLGE", "RVED", "", Level, StudentId, listGrades);
            if (termPeriod.Equals(1))
            {
                cluster3 = getCluster3Numeric("PHED", "MUSI", "", "", "", Level, StudentId, listGrades,termPeriod);
                Grade6termsRow["Cluster3"] = getCluster3String("PHED", "MUSI", "", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "MUSI", "", "", "", Level, StudentId, listGrades, termPeriod);
            }
            else if (termPeriod.Equals(2))
            {
                cluster3 = getCluster3Numeric("PHED", "ARTS", "", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3"] = getCluster3String("PHED", "ARTS", "", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "ARTS", "", "", "", Level, StudentId, listGrades, termPeriod);
            }
            else
            {
                cluster3 = getCluster3Numeric("PHED", "", "", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3"] = getCluster3String("PHED", "", "", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "", "", "", "", Level, StudentId, listGrades, termPeriod);
            }
            Grade6termsRow["Average"] = ave = Math.Round((cluster1 * 0.7) + (cluster2 * 0.2) + (cluster3 * 0.1), 3);
            Grade6termsRow["Award"] = ConvertToAward((cluster1 * .7) + (cluster2 * .2) + (cluster3 * .1));
            Grade6termsRow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(Grade6termsRow);
        }
        public static void Grade3To5(DataTable HonorsTable, String StudentId, String Level, List<FinalComp> listGrades, int termPeriod)
        {
            DataRow termsRow = HonorsTable.NewRow();
            cluster1 = getCluster1and2Numeric("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            cluster2 = getCluster1and2Numeric("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            cluster3 = getCluster3Numeric("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);

            termsRow["Cluster1"] = getCluster1and2String("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            termsRow["Cluster1Ans"] = getCluster1and2Numeric("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            termsRow["Cluster2"] = getCluster1and2String("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            termsRow["Cluster2Ans"] = getCluster1and2Numeric("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            termsRow["Cluster3"] = getCluster3String("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
            termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
            termsRow["Average"] = Math.Round((cluster1 * 0.7) + (cluster2 * 0.2) + (cluster3 * 0.1), 3);
            termsRow["Award"] = ConvertToAward((cluster1 * .7) + (cluster2 * .2) + (cluster3 * .1));
            termsRow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(termsRow);
        }
        public static void Grade6And7(DataTable HonorsTable, String StudentId, String Level, List<FinalComp> listGrades, int termPeriod)
        {
            DataRow Grade6termsRow = HonorsTable.NewRow();
            cluster1 = getCluster1and2Numeric("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            cluster2 = getCluster1and2Numeric("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            

            Double ave = 0;
            Grade6termsRow["Cluster1"] = getCluster1and2String("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            Grade6termsRow["Cluster1Ans"] = getCluster1and2Numeric("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            Grade6termsRow["Cluster2"] = getCluster1and2String("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            Grade6termsRow["Cluster2Ans"] = getCluster1and2Numeric("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            
            if (termPeriod.Equals(1))
            {
                cluster3 = getCluster3Numeric("PHED", "ARTS", "HOME", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3"] = getCluster3String("PHED", "ARTS", "HOME", "", "", Level, StudentId, listGrades, termPeriod);
                Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "ARTS", "HOME", "", "", Level, StudentId, listGrades, termPeriod);
            }
            else if (termPeriod.Equals(2))
            {
                if (Level.Equals("Grade 6"))
                {
                    cluster3 = getCluster3Numeric("PHED", "ART", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3"] = getCluster3String("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                }
                else
                {
                    cluster3 = getCluster3Numeric("PHED", "SHOP", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3"] = getCluster3String("PHED", "SHOP", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "SHOP", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                }
            }
            else
            {
                if (Level.Equals("Grade 6"))
                {
                    cluster3 = getCluster3Numeric("PHED", "SHOP", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3"] = getCluster3String("PHED", "SHOP", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "SHOP", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                }
                else
                {
                    cluster3 = getCluster3Numeric("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3"] = getCluster3String("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                    Grade6termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "ARTS", "MUSI", "", "", Level, StudentId, listGrades, termPeriod);
                }
            }
            Grade6termsRow["Average"] = ave = Math.Round((cluster1 * 0.7) + (cluster2 * 0.2) + (cluster3 * 0.1), 3);
            Grade6termsRow["Award"] = ConvertToAward((cluster1 * .7) + (cluster2 * .2) + (cluster3 * .1));
            Grade6termsRow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(Grade6termsRow);
        }
        public static void UpperSchool(DataTable HonorsTable, String StudentId, String Level, List<FinalComp> listGrades, int termPeriod)
        {
            DataRow termsRow = HonorsTable.NewRow();
            cluster1 = getCluster1and2Numeric("MATH", "SCIE", "ENGL", Level, StudentId, listGrades);
            cluster2 = getCluster1and2Numeric("SLGE", "ECON", "COMP", Level, StudentId, listGrades);


            termsRow["Cluster1"] = getCluster1and2String("MATH", "PHYS", "ENGL", Level, StudentId, listGrades);
            termsRow["Cluster1Ans"] = getCluster1and2Numeric("MATH", "PHYS", "ENGL", Level, StudentId, listGrades);
            termsRow["Cluster2"] = getCluster1and2String("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            termsRow["Cluster2Ans"] = getCluster1and2Numeric("SLGE", "COMP", "RVED", Level, StudentId, listGrades);
            if (Level.Equals("HS IV"))
            {
                if (termPeriod.Equals(1))
                {
                    //modification 10/20/11 HOME to SHOP
                    cluster3 = getCluster3Numeric("PHED", "COIN", "RVED", "SHOP", "ARTS", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "COIN", "RVED", "SHOP", "ARTS", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "COIN", "RVED", "SHOP", "ARTS", Level, StudentId, listGrades, termPeriod);
                }
                else if (termPeriod.Equals(2))
                {
                    cluster3 = getCluster3Numeric("PHED", "COIN", "RVED", "HOME", "MUSI", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "COIN", "RVED", "HOME", "MUSI", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "COIN", "RVED", "HOME", "MUSI", Level, StudentId, listGrades, termPeriod);
                }
                else
                {
                    cluster3 = getCluster3Numeric("PHED", "COIN", "RVED", "SHOP", "MUSI", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "COIN", "RVED", "SHOP", "MUSI", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "COIN", "RVED", "SHOP", "MUSI", Level, StudentId, listGrades, termPeriod);
                }
            }
            else if (Level.Equals("HS III"))
            {
                if (termPeriod.Equals(1))
                {
                    cluster3 = getCluster3Numeric("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                }
                else if (termPeriod.Equals(2))
                {
                    cluster3 = getCluster3Numeric("PHED", "RVED", "ARTS", "SHOP", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "RVED", "ARTS", "SHOP", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "RVED", "ARTS", "SHOP", "", Level, StudentId, listGrades, termPeriod);
                }
                else
                {
                    cluster3 = getCluster3Numeric("PHED", "RVED", "MUSI", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "RVED", "MUSI", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "RVED", "MUSI", "HOME", "", Level, StudentId, listGrades, termPeriod);
                }
            }
            else
            {
                if (termPeriod.Equals(1))
                {
                    cluster3 = getCluster3Numeric("PHED", "RVED", "SHOP", "MUSI", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "RVED", "SHOP", "MUSI", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "RVED", "SHOP", "MUSI", "", Level, StudentId, listGrades, termPeriod);
                }
                else if (termPeriod.Equals(2))
                {
                    cluster3 = getCluster3Numeric("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                }
                else
                {
                    cluster3 = getCluster3Numeric("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3"] = getCluster3String("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                    termsRow["Cluster3Ans"] = getCluster3Numeric("PHED", "RVED", "ARTS", "HOME", "", Level, StudentId, listGrades, termPeriod);
                }
            }
            termsRow["Average"] = Math.Round((cluster1 * 0.7) + (cluster2 * 0.2) + (cluster3 * 0.1), 3);
            termsRow["Award"] = ConvertToAward((cluster1 * .7) + (cluster2 * .2) + (cluster3 * .1));
            termsRow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(termsRow);
        }
        
        //Cluster 1-3 Numeric Value
        private static Double getCluster1and2NumericGrade1and2(String Subject1, String Subject2, String Subject3, String Level, String StudentId, List<FinalComp> listGrades)
        {
            return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                 (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)) +
                (getValue(Subject3, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject3)))
               / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3)), 3);

        }
        private static Double getCluster1and2Numeric(String Subject1, String Subject2, String Subject3, String Level, String StudentId, List<FinalComp> listGrades)
        {
            if (Level.Equals("Grade 1") || Level.Equals("Grade 2"))
            {
                return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                    (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)))
                  / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2)), 3);
            }
            else
            {
                return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                     (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)) +
                    (getValue(Subject3, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject3)))
                   / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3)), 3);
            }
        }
        private static Double getCluster3Numeric(String Subject1, String Subject2, String Subject3, String Subject4, String Subject5, String Level, String StudentId, List<FinalComp> listGrades, int termPeriod)
        {
            if (Level.Equals("Grade 1") || Level.Equals("Grade 2"))
            {
                if (termPeriod.Equals(3))
                {
                    return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)))
                    / (SubjectUnit.getWeight(Level, Subject1)), 3);
                }
                else
                {
                    return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                    (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)))
                    / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2)), 3);
                }
            }
            else if (Level.Equals("Grade 3") || Level.Equals("Grade 4") || Level.Equals("Grade 5") || Level.Equals("Grade 6") || Level.Equals("Grade 7"))
            {
                return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                 (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)) +
                (getValue(Subject3, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject3)))
               / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3)), 3);
            }
            else if (Level.Equals("HS I") || Level.Equals("HS II") || Level.Equals("HS III"))
            {
                return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                 (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)) +
                (getValue(Subject3, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject3)) +
                (getValue(Subject4, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject4)))
               / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3) + SubjectUnit.getWeight(Level, Subject4)), 3);
            }
            else
            {
                return Math.Round(((getValue(Subject1, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject1)) +
                 (getValue(Subject2, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject2)) +
                (getValue(Subject3, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject3)) +
                (getValue(Subject4, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject4)) +
                (getValue(Subject5, StudentId, listGrades) * SubjectUnit.getWeight(Level, Subject5)))
               / (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3) + SubjectUnit.getWeight(Level, Subject4) + SubjectUnit.getWeight(Level, Subject5)), 3);
            }
        }

        //Cluster 1-3 String Value
        private static String getCluster1and2StringGrade1(String Subject1, String Subject2, String Subject3, String Level, String StudentId, List<FinalComp> listGrades)
        {
            return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
               "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ") + " +
               "(" + getValue(Subject3, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject3) + ")" +
               "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3));

        }
        private static String getCluster1and2String(String Subject1, String Subject2, String Subject3, String Level, String StudentId, List<FinalComp> listGrades)
        {
            if (Level.Equals("Grade 1") || Level.Equals("Grade 2"))
            {
                return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
                   "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ") + " +
                   "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2));
            }
            else
            {
                return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
                   "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ") + " +
                   "(" + getValue(Subject3, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject3) + ")" +
                   "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3));
            }
        }
        private static String getCluster3String(String Subject1, String Subject2, String Subject3, String Subject4, String Subject5, String Level, String StudentId, List<FinalComp> listGrades, int termPeriod)
        {
            if (Level.Equals("Grade 1") || Level.Equals("Grade 2"))
            {
                if (termPeriod.Equals(3))
                {
                    return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ")" +
                    "]/" + (SubjectUnit.getWeight(Level, Subject1));
                }
                else
                {
                    return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
                    "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ")" +
                    "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2));
                }
            }
            else if (Level.Equals("Grade 3") || Level.Equals("Grade 4") || Level.Equals("Grade 5") || Level.Equals("Grade 6") || Level.Equals("Grade 7"))
            {
                return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
              "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ") + " +
              "(" + getValue(Subject3, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject3) + ")" +
              "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3));
            }
            else if (Level.Equals("HS I") || Level.Equals("HS II") || Level.Equals("HS III"))
            {
                return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
              "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ") + " +
              "(" + getValue(Subject3, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject3) + ") + " +
              "(" + getValue(Subject4, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject4) + ")" +
              "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3) + SubjectUnit.getWeight(Level, Subject4));
            }
            else
            {
                return "[" + "(" + getValue(Subject1, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject1) + ") + " +
             "(" + getValue(Subject2, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject2) + ") + " +
             "(" + getValue(Subject3, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject3) + ") + " +
             "(" + getValue(Subject4, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject4) + ") + " +
             "(" + getValue(Subject5, StudentId, listGrades) + "*" + SubjectUnit.getWeight(Level, Subject5) + ")" +
             "]/" + (SubjectUnit.getWeight(Level, Subject1) + SubjectUnit.getWeight(Level, Subject2) + SubjectUnit.getWeight(Level, Subject3) + SubjectUnit.getWeight(Level, Subject4) + SubjectUnit.getWeight(Level, Subject5));
            }
        }
        
        private static Double getValue(String SubjectId, String StudentID, List<FinalComp> listGrades)
        {
            //try
            //{
            FinalComp finalComp2 = null;
            finalComp2 = listGrades.Find(delegate(FinalComp fcomp)
            {
                if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId))
                {
                    return true;
                }
                else { return false; }
            });
            if (finalComp2 != null)
            {
                return Math.Round(ConvertToGradePoints(finalComp2.Grade), 3);
            }
            else { return 0.000; }
            //}
            //catch
            //{
            //    return 0.000;
            //}
        }
        
        private static String ConvertToAward(Double Average)
        {
            String Award = "";
            if (Average >= 3.75)
            {
                Award = "GREEN";
            }
            if (Average >= 3.5 && Average < 3.75)
            {
                Award = "PURPLE";
            }
            if (Average >= 3.25 && Average < 3.5)
            {
                Award = "PINK";
            }
            return Award;
        }
        private static Double ConvertToGradePoints(Double value)
        {
            Double variable = 0;
            if (value > 95 && value <= 100)
            {
                variable = 4;
            }
            if (value >= 91 && value <= 95)
            {
                variable = 3.5;
            }
            if (value >= 86 && value < 91)
            {
                variable = 3;
            }
            if (value >= 80 && value < 86)
            {
                variable = 2.5;
            }
            if (value >= 75 && value < 80)
            {
                variable = 2;
            }
            if (value >= 70 && value < 75)
            {
                variable = 1.5;
            }
            if (value < 70)
            {
                variable = 0;
            }
            return variable;
        }
    }
}
