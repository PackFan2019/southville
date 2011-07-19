using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    class FinalComp
    {
        private String _studId;

        public String StudId
        {
            get { return _studId; }
            set { _studId = value; }
        }
        private String _subjectId;

        public String SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }
        private Double _grade;

        public Double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        private Double _skillGrade;

        public Double SkillGrade
        {
            get { return _skillGrade; }
            set { _skillGrade = value; }
        }
        private String _skillId;

        public String SkillId
        {
            get { return _skillId; }
            set { _skillId = value; }
        }

        private Double _absent;

        public Double Absent
        {
            get { return _absent; }
            set { _absent = value; }
        }
        private Double _tardy;

        public Double Tardy
        {
            get { return _tardy; }
            set { _tardy = value; }
        }
        public static List<FinalComp> ListGradeTerm1 = new List<FinalComp>();
        public static List<FinalComp> ListGradeTerm2 = new List<FinalComp>();
        public static List<FinalComp> ListGradeTerm3 = new List<FinalComp>();
        public static List<FinalComp> ListGradeFinal = new List<FinalComp>();
        public static List<FinalComp> ListGradeSR = new List<FinalComp>();

        public static List<FinalComp> ListSkillTerm1 = new List<FinalComp>();
        public static List<FinalComp> ListSkillTerm2 = new List<FinalComp>();
        public static List<FinalComp> ListSkillTerm3 = new List<FinalComp>();

        public static List<FinalComp> AttendanceTerm1 = new List<FinalComp>();
        public static List<FinalComp> AttendanceTerm2 = new List<FinalComp>();
        public static List<FinalComp> AttendanceTerm3 = new List<FinalComp>();


    }
}
