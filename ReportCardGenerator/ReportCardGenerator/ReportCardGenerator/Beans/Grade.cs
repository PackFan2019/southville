using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class Grade:IEquatable<Grade>
    {
        private string subjectID;

        public string SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }
        private string subjectName;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }
        private string subjectCategory;

        public string SubjectCategory
        {
            get { return subjectCategory; }
            set { subjectCategory = value; }
        }
        private double numericGrade;

        public double NumericGrade
        {
            get { return numericGrade; }
            set { numericGrade = value; }
        }
        private string letterGrade;

        public string LetterGrade
        {
            get { return letterGrade; }
            set { letterGrade = value; }
        }
        private Double weight;

        public Double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public bool Equals(Grade g)
        {
            return (this.subjectID.Equals(g.subjectID));
        }
    }
}
