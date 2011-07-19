using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    class HonorsFormat
    {
        public static void Grade1And2(DataTable HonorsTable, int termPeriod, String StudentId, String Level)
        {
            DataRow drow = HonorsTable.NewRow();
            drow["Cluster1Format"] = "[(Math*" + SubjectUnit.getWeight(Level, "MATH") + ") + (Science*" + SubjectUnit.getWeight(Level, "SCIE") + ") + English*" + SubjectUnit.getWeight(Level, "ENGL") + "]/" + (SubjectUnit.getWeight(Level, "MATH") + SubjectUnit.getWeight(Level, "SCIE") + SubjectUnit.getWeight(Level, "ENGL"));
            drow["Cluster2Format"] = "[(SLGE*" + SubjectUnit.getWeight(Level, "SLGE") + ") + (RVED/HR*" + SubjectUnit.getWeight(Level, "RVED") + ")]/" + (SubjectUnit.getWeight(Level, "SLGE") + SubjectUnit.getWeight(Level, "RVED"));
            if (termPeriod.Equals(1))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "MUSI"));
            }
            else if (termPeriod.Equals(2))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "ART"));
            }
            else
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ")]/" + (SubjectUnit.getWeight(Level, "PHED"));
            }
            
            drow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(drow);
        }
        public static void Grade3To5(DataTable HonorsTable, int termPeriod, String StudentId, String Level)
        {
            DataRow drow = HonorsTable.NewRow();
            drow["Cluster1Format"] = "[(Math*" + SubjectUnit.getWeight(Level, "MATH") + ") + (Science*" + SubjectUnit.getWeight(Level, "SCIE") + ") + English*" + SubjectUnit.getWeight(Level, "ENGL") + "]/" + (SubjectUnit.getWeight(Level, "MATH") + SubjectUnit.getWeight(Level, "SCIE") + SubjectUnit.getWeight(Level, "ENGL"));
            drow["Cluster2Format"] = "[(SLGE*" + SubjectUnit.getWeight(Level, "SLGE") + ") + (Computer*" + SubjectUnit.getWeight(Level, "COMP") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ")]/" + (SubjectUnit.getWeight(Level, "SLGE") + SubjectUnit.getWeight(Level, "COMP") + SubjectUnit.getWeight(Level, "RVED"));
            drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "MUSI") + SubjectUnit.getWeight(Level, "ART"));
            drow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(drow);
        }
        public static void Grade6And7(DataTable HonorsTable, int termPeriod, String StudentId, String Level)
        {
            DataRow drow = HonorsTable.NewRow();
            drow["Cluster1Format"] = "[(Math*" + SubjectUnit.getWeight(Level, "MATH") + ") + (Science*" + SubjectUnit.getWeight(Level, "SCIE") + ") + English*" + SubjectUnit.getWeight(Level, "ENGL") + "]/" + (SubjectUnit.getWeight(Level, "MATH") + SubjectUnit.getWeight(Level, "SCIE") + SubjectUnit.getWeight(Level, "ENGL"));
            drow["Cluster2Format"] = "[(SLGE*" + SubjectUnit.getWeight(Level, "SLGE") + ") + (Computer*" + SubjectUnit.getWeight(Level, "COMP") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ")]/" + (SubjectUnit.getWeight(Level, "SLGE") + SubjectUnit.getWeight(Level, "COMP") + SubjectUnit.getWeight(Level, "RVED"));
            if (termPeriod.Equals(1))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "ART"));
            }
            else if (termPeriod.Equals(2))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "MUSI") + SubjectUnit.getWeight(Level, "ART"));
            }
            else
            {
                if (Level.Equals("Grade 6"))
                {
                    drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") + (Shop*" + SubjectUnit.getWeight(Level, "SHOP") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "MUSI") + SubjectUnit.getWeight(Level, "SHOP"));
                }
                else
                {
                    drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ")]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "MUSI") + SubjectUnit.getWeight(Level, "ART"));
                }
            }
            drow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(drow);
        }
        public static void HS1And2(DataTable HonorsTable, int termPeriod, String StudentId, String Level)
        {
            DataRow drow = HonorsTable.NewRow();
            drow["Cluster1Format"] = "[(Math*" + SubjectUnit.getWeight(Level, "MATH") + ") + (Science*" + SubjectUnit.getWeight(Level, "SCIE") + ") + English*" + SubjectUnit.getWeight(Level, "ENGL") + "]/" + (SubjectUnit.getWeight(Level, "MATH") + SubjectUnit.getWeight(Level, "SCIE") + SubjectUnit.getWeight(Level, "ENGL"));
            drow["Cluster2Format"] = "[(SLGE*" + SubjectUnit.getWeight(Level, "SLGE") + ") + (Acctg*" + SubjectUnit.getWeight(Level, "ECON") + ") + (Computer*" + SubjectUnit.getWeight(Level, "COMP") + ")]/" + (SubjectUnit.getWeight(Level, "SLGE") + SubjectUnit.getWeight(Level, "ECON") + SubjectUnit.getWeight(Level, "COMP"));
            if (termPeriod.Equals(1))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (Shop*" + SubjectUnit.getWeight(Level, "SHOP") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "SHOP") + SubjectUnit.getWeight(Level, "MUSI"));
            }
            if (termPeriod.Equals(2))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "ART"));
            }
            if (termPeriod.Equals(3))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "ART"));
            }
            drow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(drow);
        }
        public static void HS3(DataTable HonorsTable, int termPeriod, String StudentId, String Level)
        {
            DataRow drow = HonorsTable.NewRow();
            drow["Cluster1Format"] = "[(Math*" + SubjectUnit.getWeight(Level, "MATH") + ") + (Science*" + SubjectUnit.getWeight(Level, "SCIE") + ") + English*" + SubjectUnit.getWeight(Level, "ENGL") + "]/" + (SubjectUnit.getWeight(Level, "MATH") + SubjectUnit.getWeight(Level, "SCIE") + SubjectUnit.getWeight(Level, "ENGL"));
            drow["Cluster2Format"] = "[(SLGE*" + SubjectUnit.getWeight(Level, "SLGE") + ") + (Investmet*" + SubjectUnit.getWeight(Level, "ECON") + ") + (Computer*" + SubjectUnit.getWeight(Level, "COMP") + ")]/" + (SubjectUnit.getWeight(Level, "SLGE") + SubjectUnit.getWeight(Level, "ECON") + SubjectUnit.getWeight(Level, "COMP"));
            if (termPeriod.Equals(1))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "ART"));
            }
            if (termPeriod.Equals(2))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (Shop*" + SubjectUnit.getWeight(Level, "SHOP") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "SHOP") + SubjectUnit.getWeight(Level, "ART"));
            }
            if (termPeriod.Equals(3))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "MUSI"));
            }
            drow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(drow);
        }
        public static void HS4(DataTable HonorsTable, int termPeriod, String StudentId, String Level)
        {
            DataRow drow = HonorsTable.NewRow();
            drow["Cluster1Format"] = "[(Math*" + SubjectUnit.getWeight(Level, "MATH") + ") + (Science*" + SubjectUnit.getWeight(Level, "SCIE") + ") + English*" + SubjectUnit.getWeight(Level, "ENGL") + "]/" + (SubjectUnit.getWeight(Level, "MATH") + SubjectUnit.getWeight(Level, "SCIE") + SubjectUnit.getWeight(Level, "ENGL"));
            drow["Cluster2Format"] = "[(SLGE*" + SubjectUnit.getWeight(Level, "SLGE") + ") + (Economics*" + SubjectUnit.getWeight(Level, "ECON") + ") + (Computer*" + SubjectUnit.getWeight(Level, "COMP") + ")]/" + (SubjectUnit.getWeight(Level, "SLGE") + SubjectUnit.getWeight(Level, "ECON") + SubjectUnit.getWeight(Level, "COMP"));
            if (termPeriod.Equals(1))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (CAT/CAS*" + SubjectUnit.getWeight(Level, "COIN") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Art*" + SubjectUnit.getWeight(Level, "ART") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "COIN") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "ART"));
            }
            if (termPeriod.Equals(2))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (CAT/CAS*" + SubjectUnit.getWeight(Level, "COIN") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (HE*" + SubjectUnit.getWeight(Level, "HOME") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "COIN") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "HOME") + SubjectUnit.getWeight(Level, "MUSI"));
            }
            if (termPeriod.Equals(3))
            {
                drow["Cluster3Format"] = "[(PE*" + SubjectUnit.getWeight(Level, "PHED") + ") + (CAT/CAS*" + SubjectUnit.getWeight(Level, "COIN") + ") + (RVED*" + SubjectUnit.getWeight(Level, "RVED") + ") + (Shop*" + SubjectUnit.getWeight(Level, "SHOP") + ") + (Music*" + SubjectUnit.getWeight(Level, "MUSI") + ") ]/" + (SubjectUnit.getWeight(Level, "PHED") + SubjectUnit.getWeight(Level, "COIN") + SubjectUnit.getWeight(Level, "RVED") + SubjectUnit.getWeight(Level, "SHOP") + SubjectUnit.getWeight(Level, "MUSI"));
            }
            drow["StudentId"] = StudentId;
            HonorsTable.Rows.Add(drow);
        }
    }
}
