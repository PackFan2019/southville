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

namespace ReportCardGenerator.Controller
{
    class HonorController:IHonorController
    {
        public void ComputeTermsHonors(DataTable HonorsTable, String StudentId, String Level, List<FinalComp> listGrades, int termPeriod)
        {
            try
            {
                if (Level.Trim().Equals("Grade 1") || Level.Trim().Equals("Grade 2"))
                { HonorsComputationFormula.Grade1And2(HonorsTable, StudentId, Level.Trim(), listGrades, termPeriod); }
                else if (Level.Trim().Equals("Grade 6") || Level.Trim().Equals("Grade 7"))
                { HonorsComputationFormula.Grade6And7(HonorsTable, StudentId, Level.Trim(), listGrades, termPeriod); }
                else if (Level.Trim().Equals("HS I") || Level.Trim().Equals("HS II") || Level.Trim().Equals("HS III") || Level.Trim().Equals("HS IV"))
                { HonorsComputationFormula.UpperSchool(HonorsTable, StudentId, Level.Trim(), listGrades, termPeriod); }
                else { HonorsComputationFormula.Grade3To5(HonorsTable, StudentId, Level.Trim(), listGrades, termPeriod); }
            }
            catch
            {
            }
        }
        public void ComputeTermsFormat(DataTable HonorsTable, int termPeriod, String Level, String StudentId)
        {
            try
            {
                if (Level.Trim().Equals("Grade 1") || Level.Trim().Equals("Grade 2"))
                { HonorsFormat.Grade1And2(HonorsTable, termPeriod, StudentId, Level.Trim()); }
                else if (Level.Trim().Equals("Grade 3") || Level.Trim().Equals("Grade 4") || Level.Trim().Equals("Grade 5"))
                { HonorsFormat.Grade3To5(HonorsTable, termPeriod, StudentId, Level.Trim()); }
                else if (Level.Trim().Equals("Grade 6") || Level.Trim().Equals("Grade 7"))
                { HonorsFormat.Grade6And7(HonorsTable, termPeriod, StudentId, Level.Trim()); }
                else if (Level.Trim().Equals("HS III"))
                { HonorsFormat.HS3(HonorsTable, termPeriod, StudentId, Level.Trim()); }
                else if (Level.Trim().Equals("HS IV"))
                { HonorsFormat.HS4(HonorsTable, termPeriod, StudentId, Level.Trim()); }
                else { HonorsFormat.HS1And2(HonorsTable, termPeriod, StudentId, Level.Trim()); }
            }
            catch
            {
            }
        }
        public void ComputeTerm3Honors(RPdata DS)
        {
        }
        public void ComputeFinalHonors(RPdata DS)
        {
        }
    }
}
