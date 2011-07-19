using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Controller;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Reports;

namespace ReportCardGenerator.Interfaces
{
    interface IHonorController
    {
        void ComputeTermsHonors(DataTable HonorsTable, String StudentId, String Level, List<FinalComp> list, int termPeriod);
        void ComputeTermsFormat(DataTable HonorsTable, int termPeriod, String Level, String StudentId);
        void ComputeTerm3Honors(RPdata DS);
        void ComputeFinalHonors(RPdata DS);
    }
}
