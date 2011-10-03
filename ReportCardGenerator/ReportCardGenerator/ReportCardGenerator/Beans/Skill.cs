using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class Skill:IEquatable<Skill>
    {
        private String skillID;

        public String SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }
        private String skillName;

        public String SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        private String skillCategory;

        public String SkillCategory
        {
            get { return skillCategory; }
            set { skillCategory = value; }
        }
        private double numericGrade;

        public double NumericGrade
        {
            get { return numericGrade; }
            set { numericGrade = value; }
        }

        
        private String letterGrade;

        public String LetterGrade
        {
            get { return letterGrade; }
            set { letterGrade = value; }
        }

        public bool Equals(Skill s)
        {
            return (this.skillID.Equals(s.skillID));
        }
    }
}
