using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ReportCardGenerator.Views;

namespace ReportCardGenerator.Beans
{
    class SubjectUnit
    {
        public static double getWeight(String Level, String SubjectID)
        {
            try
            {
                Hashtable GradeUnit = HashTables.YearLevel[Level.Trim()] as Hashtable;
                if (GradeUnit.Equals(null))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(GradeUnit[SubjectID]);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Level " + Level + " is not in the list. \n" + "Please correct or complete the Information in the Gradebook Computer", 
                    "Incomplete Level Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return 0;
            }
        }
        public static double getFinalWeight(String Level, String SubjectID, Double final, String StudentId)
        {
            try
            {
                Hashtable GradeUnit = HashTables.YearLevel[Level.Trim()] as Hashtable;
                if (GradeUnit.Equals(null))
                {
                    return 0;
                }
                else
                {
                    double result = 0;
                    foreach (DataRow drow in StudReportCard.DS.ActionTaken.Rows)
                    {
                        if (drow["StudentId"].Equals(StudentId) && StudReportCard.DS.ActionTaken.Rows[StudReportCard.DS.ActionTaken.Rows.IndexOf(drow)][StudReportCard.Translate(SubjectID)].ToString().Equals("Passed"))
                        {
                            result =  Convert.ToDouble(GradeUnit[SubjectID]);
                        }
                        else
                        {
                            result = 0;
                        }
                    }
                    //if (final <= 79)
                    //{
                    //    return Convert.ToDouble(GradeUnit[SubjectID]);
                    //}
                    //else
                    //{
                        
                    //}
                    return result;
                }
                
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Level " + Level + " is not in the list. \n" + "Please correct or complete the Information in the Gradebook Computer",
                    "Incomplete Level Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return 0;
            }
        }
        public static void loadGradeUnit()
        {
            //HashTables.YearLevel.Add("Grade 1",HashTables.SubjectUnit.Add("MATH",1)
            HashTables.YearLevel.Add("Grade 1", HashTables.Grade1);
            HashTables.YearLevel.Add("Grade 2", HashTables.Grade2);
            HashTables.YearLevel.Add("Grade 3", HashTables.Grade3);
            HashTables.YearLevel.Add("Grade 4", HashTables.Grade4);
            HashTables.YearLevel.Add("Grade 5", HashTables.Grade5);
            HashTables.YearLevel.Add("Grade 6", HashTables.Grade6);
            HashTables.YearLevel.Add("Grade 7", HashTables.Grade7);
            HashTables.YearLevel.Add("HS I", HashTables.HS1);
            HashTables.YearLevel.Add("HS II", HashTables.HS2);
            HashTables.YearLevel.Add("HS III", HashTables.HS3);
            HashTables.YearLevel.Add("HS IV", HashTables.HS4);
        }
        public static void loadUnit()
        {
            try
            {
                HashTables.Grade1.Add("MATH", 1);
                HashTables.Grade1.Add("SCIE", 1);
                HashTables.Grade1.Add("ENGL", 1);
                HashTables.Grade1.Add("SLGE", 1);
                HashTables.Grade1.Add("HIST", 1);
                HashTables.Grade1.Add("FILI", 1);
                HashTables.Grade1.Add("COMP", 0.25);
                HashTables.Grade1.Add("MAPE", 1.5);
                HashTables.Grade1.Add("MUSI", 0.5);
                HashTables.Grade1.Add("ART", 0.5);
                HashTables.Grade1.Add("PHED", 0.5);
                HashTables.Grade1.Add("RVED", 1);
                HashTables.Grade1.Add("HOME", 1);
                HashTables.Grade1.Add("HRLI", 0.5);
                HashTables.Grade1.Add("COND", 0.5);

                HashTables.Grade2.Add("MATH", 1);
                HashTables.Grade2.Add("SCIE", 1);
                HashTables.Grade2.Add("ENGL", 1);
                HashTables.Grade2.Add("HIST", 1);
                HashTables.Grade2.Add("FILI", 1);
                HashTables.Grade2.Add("COMP", 0.25);
                HashTables.Grade2.Add("MAPE", 1.5);
                HashTables.Grade2.Add("MUSI", 0.5);
                HashTables.Grade2.Add("ART", 0.5);
                HashTables.Grade2.Add("PHED", 0.5);
                HashTables.Grade2.Add("RVED", 1);
                HashTables.Grade2.Add("HOME", 1);
                HashTables.Grade2.Add("HRLI", 0.5);
                HashTables.Grade2.Add("COND", 0.5);

                HashTables.Grade3.Add("MATH", 1);
                HashTables.Grade3.Add("SCIE", 1);
                HashTables.Grade3.Add("ENGL", 1);
                HashTables.Grade3.Add("SLGE", 1);
                HashTables.Grade3.Add("HIST", 0.8);
                HashTables.Grade3.Add("LEAD", 0.2);
                HashTables.Grade3.Add("FILI", 1);
                HashTables.Grade3.Add("COMP", 0.25);
                HashTables.Grade3.Add("MAPE", 1);
                HashTables.Grade3.Add("MUSI", 0.25);
                HashTables.Grade3.Add("ART", 0.25);
                HashTables.Grade3.Add("PHED", 0.5);
                HashTables.Grade3.Add("FORE", 0.25);
                HashTables.Grade3.Add("RVED", 1);
                HashTables.Grade3.Add("HOME", 1);
                HashTables.Grade3.Add("LANG", 0.5);
                HashTables.Grade3.Add("READ", 0.5);

                HashTables.Grade4.Add("MATH", 1);
                HashTables.Grade4.Add("SCIE", 1);
                HashTables.Grade4.Add("ENGL", 1);
                HashTables.Grade4.Add("SLGE", 1);
                HashTables.Grade4.Add("HIST", 0.8);
                HashTables.Grade4.Add("LEAD", 0.2);
                HashTables.Grade4.Add("FILI", 1);
                HashTables.Grade4.Add("COMP", 0.25);
                HashTables.Grade4.Add("MAPE", 1);
                HashTables.Grade4.Add("MUSI", 0.25);
                HashTables.Grade4.Add("ART", 0.25);
                HashTables.Grade4.Add("PHED", 0.5);
                HashTables.Grade4.Add("FORE", 0.25);
                HashTables.Grade4.Add("RVED", 1);
                HashTables.Grade4.Add("LANG", 0.5);
                HashTables.Grade4.Add("READ", 0.5);

                HashTables.Grade5.Add("MATH", 1);
                HashTables.Grade5.Add("SCIE", 1);
                HashTables.Grade5.Add("ENGL", 1);
                HashTables.Grade5.Add("SLGE", 1);
                HashTables.Grade5.Add("HIST", 0.8);
                HashTables.Grade5.Add("LEAD", 0.2);
                HashTables.Grade5.Add("FILI", 1);
                HashTables.Grade5.Add("COMP", 0.25);
                HashTables.Grade5.Add("MAPE", 1);
                HashTables.Grade5.Add("MUSI", 0.25);
                HashTables.Grade5.Add("ART", 0.25);
                HashTables.Grade5.Add("PHED", 0.5);
                HashTables.Grade5.Add("FORE", 0.25);
                HashTables.Grade5.Add("RVED", 1);
                HashTables.Grade5.Add("LANG", 0.5);
                HashTables.Grade5.Add("READ", 0.5);

                HashTables.Grade6.Add("MATH", 1);
                HashTables.Grade6.Add("SCIE", 1);
                HashTables.Grade6.Add("ENGL", 2);
                HashTables.Grade6.Add("SLGE", 0.75);
                HashTables.Grade6.Add("HIST", 0.55);
                HashTables.Grade6.Add("LEAD", 0.2);
                HashTables.Grade6.Add("FILI", 0.5);
                HashTables.Grade6.Add("COMP", 0.5);
                HashTables.Grade6.Add("MAPE", 1.25);
                HashTables.Grade6.Add("MUSI", 0.25);
                HashTables.Grade6.Add("ART", 0.25);
                HashTables.Grade6.Add("PHED", 0.75);
                HashTables.Grade6.Add("FORE", 0.25);
                HashTables.Grade6.Add("HOME", 0.25);
                HashTables.Grade6.Add("RVED", 0.5);
                HashTables.Grade6.Add("DEPO", 0);
                HashTables.Grade6.Add("LANG", 1);
                HashTables.Grade6.Add("READ", 1);
                HashTables.Grade6.Add("SHOP", 0.25);

                HashTables.Grade7.Add("MATH", 1);
                HashTables.Grade7.Add("SCIE", 1);
                HashTables.Grade7.Add("ENGL", 2);
                HashTables.Grade7.Add("SLGE", 0.75);
                HashTables.Grade7.Add("HIST", 0.55);
                HashTables.Grade7.Add("LEAD", 0.2);
                HashTables.Grade7.Add("FILI", 0.5);
                HashTables.Grade7.Add("COMP", 0.5);
                HashTables.Grade7.Add("MAPE", 1.25);
                HashTables.Grade7.Add("MUSI", 0.25);
                HashTables.Grade7.Add("ART", 0.25);
                HashTables.Grade7.Add("PHED", 0.75);
                HashTables.Grade7.Add("FORE", 0.25);
                HashTables.Grade7.Add("HOME", 0.25);
                HashTables.Grade7.Add("RVED", 0.5);
                HashTables.Grade7.Add("LANG", 1);
                HashTables.Grade7.Add("READ", 1);
                HashTables.Grade7.Add("SHOP", 0.25);

                HashTables.HS1.Add("MATH", 1.5);
                HashTables.HS1.Add("SCIE", 2);
                HashTables.HS1.Add("ENGL", 2);
                HashTables.HS1.Add("SLGE", 1.2);
                HashTables.HS1.Add("HIST", 1);
                HashTables.HS1.Add("LEAD", 0.2);
                HashTables.HS1.Add("FILI", 1.2);
                HashTables.HS1.Add("BTA", 1.5);
                HashTables.HS1.Add("ECON", 0.5);
                HashTables.HS1.Add("COMP", 0.5);
                HashTables.HS1.Add("MAPE", 1.8);
                HashTables.HS1.Add("MUSI", 0.6);
                HashTables.HS1.Add("ART", 0.6);
                HashTables.HS1.Add("PHED", 0.6);
                HashTables.HS1.Add("COIN", 0.4);
                HashTables.HS1.Add("FORE", 0.25);
                HashTables.HS1.Add("HOME", 0.5);
                HashTables.HS1.Add("RVED", 1);
                HashTables.HS1.Add("LANG", 1);
                HashTables.HS1.Add("READ", 1);
                HashTables.HS1.Add("SHOP", 0.5);
                HashTables.HS1.Add("HRLI", 1);

                HashTables.HS2.Add("MATH", 1.5);
                HashTables.HS2.Add("SCIE", 2);
                HashTables.HS2.Add("ENGL", 2);
                HashTables.HS2.Add("SLGE", 1.2);
                HashTables.HS2.Add("HIST", 1);
                HashTables.HS2.Add("LEAD", 0.2);
                HashTables.HS2.Add("FILI", 1.2);
                HashTables.HS2.Add("BTA", 1.5);
                HashTables.HS2.Add("ECON", 0.5);
                HashTables.HS2.Add("COMP", 0.5);
                HashTables.HS2.Add("MAPE", 1.2);
                HashTables.HS2.Add("MUSI", 0.4);
                HashTables.HS2.Add("ART", 0.4);
                HashTables.HS2.Add("PHED", 0.4);
                HashTables.HS2.Add("COIN", 0.4);
                HashTables.HS2.Add("FORE", 0.25);
                HashTables.HS2.Add("HOME", 0.5);
                HashTables.HS2.Add("RVED", 1);
                HashTables.HS2.Add("SHOP", 0.5);
                HashTables.HS2.Add("HRLI", 1);

                HashTables.HS3.Add("MATH", 1.5);
                HashTables.HS3.Add("SCIE", 2);
                HashTables.HS3.Add("ENGL", 2);
                HashTables.HS3.Add("SLGE", 1.2);
                HashTables.HS3.Add("HIST", 1);
                HashTables.HS3.Add("LEAD", 0.2);
                HashTables.HS3.Add("FILI", 1.2);
                HashTables.HS3.Add("BTA", 1.5);
                HashTables.HS3.Add("ECON", 0.5);
                HashTables.HS3.Add("COMP", 0.5);
                HashTables.HS3.Add("MAPE", 1.2);
                HashTables.HS3.Add("MUSI", 0.4);
                HashTables.HS3.Add("ART", 0.4);
                HashTables.HS3.Add("PHED", 0.4);
                HashTables.HS3.Add("COIN", 0.4);
                HashTables.HS3.Add("FORE", 0.25);
                HashTables.HS3.Add("HOME", 0.5);
                HashTables.HS3.Add("RVED", 1);
                HashTables.HS3.Add("SHOP", 0.5);

                HashTables.HS4.Add("MATH", 1.5);
                HashTables.HS4.Add("SCIE", 2.1);
                HashTables.HS4.Add("ENGL", 2);
                HashTables.HS4.Add("SLGE", 1.2);
                HashTables.HS4.Add("HIST", 1);
                HashTables.HS4.Add("LEAD", 0.2);
                HashTables.HS4.Add("FILI", 1.2);
                HashTables.HS4.Add("BTA", 1.5);
                HashTables.HS4.Add("ECON", 0.5);
                HashTables.HS4.Add("COMP", 0.5);
                HashTables.HS4.Add("MAPE", 1.5);
                HashTables.HS4.Add("MUSI", 0.5);
                HashTables.HS4.Add("ART", 0.5);
                HashTables.HS4.Add("PHED", 0.5);
                HashTables.HS4.Add("COIN", 0.5);
                HashTables.HS4.Add("FORE", 0.25);
                HashTables.HS4.Add("HOME", 0.5);
                HashTables.HS4.Add("RVED", 1);
                HashTables.HS4.Add("SHOP", 0.5);
                HashTables.HS4.Add("PHYS", 2);

                loadGradeUnit();
            }
            catch
            {
            }
        }
    }
}
