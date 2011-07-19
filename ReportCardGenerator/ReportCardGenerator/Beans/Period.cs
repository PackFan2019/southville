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

        private List<Comment> periodComment = new List<Comment>();

        public List<Comment> PeriodComment
        {
            get { return periodComment; }
            set { periodComment = value; }
        }

        //private Comment periodComment = new Comment();

        //internal Comment PeriodComment
        //{
        //    get { return periodComment; }
        //    set { periodComment = value; }
        //}
        private List<Attendance> periodAttendance = new List<Attendance>();

        public List<Attendance> PeriodAttendance
        {
            get { return periodAttendance; }
            set { periodAttendance = value; }
        }

        
        private List<Grade> grades = new List<Grade>();

        internal List<Grade> Grades
        {
            get { return grades; }
            set { grades = value; }
        }
        private List<Skill> skills = new List<Skill>();

        internal List<Skill> Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public bool Equals(Period p)
        {
            return (this.periodID == p.periodID);
        }
        //public override string ToString()
        //{
        //    return "Periods: " + this.PeriodAttendance.DaysPresent +" " + this.PeriodAttendance.DaysTardy;
        //}

        //public Object Clone()
        //{
        //    Period p = new Period();
        //    p.Grades = this.Grades; //Not allowed
        //    //Have to copy contents of list from this.grades to p.Grades
        //    return p;
        //}
    }
}
