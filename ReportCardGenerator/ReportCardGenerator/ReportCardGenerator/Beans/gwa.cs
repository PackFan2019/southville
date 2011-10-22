using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    class gwa
    {
        public static List<gwa> gradeList = new List<gwa>();

        private String _subjectId;

        public String SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }
        private String _subjectGrade;

        public String SubjectGrade
        {
            get { return _subjectGrade; }
            set { _subjectGrade = value; }
        }
    }
}
