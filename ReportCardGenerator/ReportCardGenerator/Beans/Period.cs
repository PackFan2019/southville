using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class Period:IEquatable<Period>
    {

        private int periodID;

        public int PeriodID
        {
            get { return periodID; }
            set { periodID = value; }
        }


        private String periodName;

        public String PeriodName
        {
            get { return periodName; }
            set { periodName = value; }
        }


        private Comment periodComment;

        internal Comment PeriodComment
        {
            get { return periodComment; }
            set { periodComment = value; }
        }
        private Attendance periodAttendance;

        internal Attendance PeriodAttendance
        {
            get { return periodAttendance; }
            set { periodAttendance = value; }
        }
        private List<Grade> grades;

        internal List<Grade> Grades
        {
            get { return grades; }
            set { grades = value; }
        }
        private List<Skill> skills;

        internal List<Skill> Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public bool Equals(Period p)
        {
            return (this.periodID == p.periodID);
        }
    }
}
