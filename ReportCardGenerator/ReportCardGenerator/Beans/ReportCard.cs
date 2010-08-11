using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    public class ReportCard
    {
        private List<Period> periods = new List<Period>();

        public List<Period> Periods
        {
            get { return periods; }
            set { periods = value; }
        }

        //public List<Period> Periods
        //{
        //    get { return periods; }
        //    set { periods = value; }
        //}

        //internal List<Period> Periods
        //{
        //    get { return periods; }
        //    set { periods = value; }
        //}

        private String adviser;

        public String Adviser
        {
            get { return adviser; }
            set { adviser = value; }
        }
        private String schoolYear;

        public String SchoolYear
        {
            get { return schoolYear; }
            set { schoolYear = value; }
        }
        private String level;

        public String Level
        {
            get { return level; }
            set { level = value; }
        }
        private String section;

        public String Section
        {
            get { return section; }
            set { section = value; }
        }
    }
}
