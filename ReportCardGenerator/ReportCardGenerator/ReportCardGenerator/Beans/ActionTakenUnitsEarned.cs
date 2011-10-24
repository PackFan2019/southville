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
using ReportCardGenerator.Views;
namespace ReportCardGenerator.Beans
{
    class ActionTakenUnitsEarned:SubjectUnit
    {

        private static IGradeController gradeController = new GradeController();
        public static DataRow ActionTaken(DataRow drow, String StudentId, int tempPeriod, String Level)
        {
            drow["Math"] = ActionTakenValue(gradeController.getFinal("MATH", StudentId, tempPeriod), Level);
            drow["Science"] = ActionTakenValue(gradeController.getFinal("SCIE", StudentId, tempPeriod), Level);
            drow["Reading"] = ActionTakenValue(gradeController.getFinal("READ", StudentId, tempPeriod), Level);
            drow["Language"] = ActionTakenValue(gradeController.getFinal("LANG", StudentId, tempPeriod), Level);
            drow["History"] = ActionTakenValue(gradeController.getFinal("HIST", StudentId, tempPeriod), Level);
            drow["Leadership"] = ActionTakenValue(gradeController.getFinal("LEAD", StudentId, tempPeriod), Level);
            drow["Filipino"] = ActionTakenValue(gradeController.getFinal("FILI", StudentId, tempPeriod), Level);
            drow["Computer"] = ActionTakenValue(gradeController.getFinal("COMP", StudentId, tempPeriod), Level);
            drow["Music"] = ActionTakenValue(gradeController.getFinal("MUSI", StudentId, tempPeriod), Level);
            drow["Art"] = ActionTakenValue(gradeController.getFinal("ARTS", StudentId, tempPeriod), Level);
            drow["PE"] = ActionTakenValue(gradeController.getFinal("PHED", StudentId, tempPeriod), Level);
            drow["Forex"] = ActionTakenValue(gradeController.getFinal("FOREX", StudentId, tempPeriod), Level);
            drow["Religion"] = ActionTakenValue(gradeController.getFinal("RVED", StudentId, tempPeriod), Level);
            drow["Life"] = ActionTakenValue(gradeController.getFinal("HRLI", StudentId, tempPeriod), Level);
            drow["Co-curricular"] = ActionTakenValue(gradeController.getFinal("COIN", StudentId, tempPeriod), Level);
            drow["Deport"] = ActionTakenValue(gradeController.getFinal("DEPO", StudentId, tempPeriod), Level);
            drow["EntrepAcc"] = ActionTakenValue(gradeController.getFinal("ECON", StudentId, tempPeriod), Level);
            drow["HomeEco"] = ActionTakenValue(gradeController.getFinal("HOME", StudentId, tempPeriod), Level);
            drow["Shop"] = ActionTakenValue(gradeController.getFinal("SHOP", StudentId, tempPeriod), Level);
            drow["SLGE"] = ActionTakenValue(gradeController.getFinal("SLGE", StudentId, tempPeriod), Level);
            drow["Conduct"] = ActionTakenValue(gradeController.getFinal("COND", StudentId, tempPeriod), Level);
            drow["English"] = ActionTakenValue(gradeController.getFinal("ENGL", StudentId, tempPeriod), Level);
            drow["MAPE"] = ActionTakenValue(gradeController.getFinal("MAPE", StudentId, tempPeriod), Level);
            drow["CAS"] = ActionTakenValue(gradeController.getFinal("CAS", StudentId, tempPeriod), Level);
            drow["BTA"] = ActionTakenValue(gradeController.getFinal("BTA", StudentId, tempPeriod), Level);
            drow["Physics"] = ActionTakenValue(gradeController.getFinal("PHYS", StudentId, tempPeriod), Level);
            drow["StudentId"] = StudentId;
            return drow;
        }
        public static void UpdateActionTaken(DataTable ActionTaken, Student Stud)
        {
            foreach (FinalComp extendedGrade in FinalComp.ListGradeSR)
            {
                if (extendedGrade.Grade >= 75)
                {
                    foreach (DataRow drow in ActionTaken.Rows)
                    {
                        if (drow["StudentId"].Equals(Stud.StudentID) && Stud.StudentID.Equals(extendedGrade.StudId))
                        {
                            ActionTaken.Rows[ActionTaken.Rows.IndexOf(drow)][gradeController.Translate(extendedGrade.SubjectId)] = ActionTakenValue(extendedGrade.Grade,Stud.Level);
                            //StudReportCard.DS.UnitsEarned.Rows[ActionTaken.Rows.IndexOf(drow)][gradeController.Translate(extendedGrade.SubjectId)] = "Passed";
                        }
                    }
                }
            }
        }
        public static String ActionTakenValue(Double Grade, String Level)
        {
            String result = "";
            if (Level != "HS IV")
            {
                if (Grade >= 70 && Grade <= 79.4)
                {
                    return "Failed";
                }
                else if (Grade == 0)
                {
                    return "N/A";
                }
                else if (Grade < 70)
                {
                    return "Incomplete";
                }
                else if (Grade >= 79.5)
                {
                    return "Passed";
                }               
                else
                {
                    return null;
                }
            }
            else
            {
                if (Grade >= 70 && Grade <= 74.4)
                {
                    return "Failed";
                }
                else if (Grade < 70)
                {
                    return "Incomplete";
                }
                else if (Grade > 74.4)
                {
                    return "Passed";
                }
                else
                {
                    return null;
                }
            }
        }
        public static DataRow UnitsEarned(DataRow drow, String Level, Period period, Student Stud)
        {
            if (!period.PeriodID.Equals(1) && !period.PeriodID.Equals(2))
            {
                drow["Math"] = getFinalWeight(Level, "MATH", gradeController.getFinal("MATH", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Science"] = getFinalWeight(Level, "SCIE", gradeController.getFinal("SCIE", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Reading"] = getFinalWeight(Level, "READ", gradeController.getFinal("READ", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Language"] = getFinalWeight(Level, "LANG", gradeController.getFinal("LANG", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["History"] = getFinalWeight(Level, "HIST", gradeController.getFinal("HIST", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Leadership"] = getFinalWeight(Level, "LEAD", gradeController.getFinal("LEAD", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Filipino"] = getFinalWeight(Level, "FILI", gradeController.getFinal("FILI", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Computer"] = getFinalWeight(Level, "COMP", gradeController.getFinal("COMP", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Music"] = getFinalWeight(Level, "MUSI", gradeController.getFinal("MUSI", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Art"] = getFinalWeight(Level, "ARTS", gradeController.getFinal("ARTS", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["PE"] = getFinalWeight(Level, "PHED", gradeController.getFinal("PHED", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Forex"] = getFinalWeight(Level, "FORE", gradeController.getFinal("FOREX", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Religion"] = getFinalWeight(Level, "RVED", gradeController.getFinal("RVED", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Life"] = getFinalWeight(Level, "HRLI", gradeController.getFinal("HRLI", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Co-curricular"] = getFinalWeight(Level, "COIN", gradeController.getFinal("COIN", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Deport"] = getFinalWeight(Level, "DEPO", gradeController.getFinal("DEPO", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["EntrepAcc"] = getFinalWeight(Level, "ECON", gradeController.getFinal("ECON", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["HomeEco"] = getFinalWeight(Level, "HOME", gradeController.getFinal("HOME", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Shop"] = getFinalWeight(Level, "SHOP", gradeController.getFinal("SHOP", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["SLGE"] = getFinalWeight(Level, "SLGE", gradeController.getFinal("SLGE", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Conduct"] = getFinalWeight(Level, "COND", gradeController.getFinal("COND", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["English"] = getFinalWeight(Level, "ENGL", gradeController.getFinal("ENGL", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["MAPE"] = getFinalWeight(Level, "MAPE", gradeController.getFinal("MAPE", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["CAS"] = getFinalWeight(Level, "CAS", gradeController.getFinal("CAS", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["BTA"] = getFinalWeight(Level, "BTA", gradeController.getFinal("BTA", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["Physics"] = getFinalWeight(Level, "PHYS", gradeController.getFinal("PHYS", Stud.StudentID, period.PeriodID), Stud.StudentID);
                drow["StudentId"] = Stud.StudentID;
            }
            else
            {
                drow["Math"] = getWeight(Level, "MATH");
                drow["Science"] = getWeight(Level, "SCIE");
                drow["Reading"] = getWeight(Level, "READ");
                drow["Language"] = getWeight(Level, "LANG");
                drow["History"] = getWeight(Level, "HIST");
                drow["Leadership"] = getWeight(Level, "LEAD");
                drow["Filipino"] = getWeight(Level, "FILI");
                drow["Computer"] = getWeight(Level, "COMP");
                drow["Music"] = getWeight(Level, "MUSI");
                drow["Art"] = getWeight(Level, "ARTS");
                drow["PE"] = getWeight(Level, "PHED");
                drow["Forex"] = getWeight(Level, "FORE");
                drow["Religion"] = getWeight(Level, "RVED");
                drow["Life"] = getWeight(Level, "HRLI");
                drow["Co-curricular"] = getWeight(Level, "COIN");
                drow["Deport"] = getWeight(Level, "DEPO");
                drow["EntrepAcc"] = getWeight(Level, "ECON");
                drow["HomeEco"] = getWeight(Level, "HOME");
                drow["Shop"] = getWeight(Level, "SHOP");
                drow["SLGE"] = getWeight(Level, "SLGE");
                drow["Conduct"] = getWeight(Level, "COND");
                drow["English"] = getWeight(Level, "ENGL");
                drow["MAPE"] = getWeight(Level, "MAPE");
                drow["CAS"] = getWeight(Level, "CAS");
                drow["BTA"] = getWeight(Level, "BTA");
                drow["Physics"] = getWeight(Level, "PHYS");
                drow["StudentId"] = Stud.StudentID;
                drow["Total"] = getWeight(Level, "Total");
            }
            return drow;
        }
    }
}
