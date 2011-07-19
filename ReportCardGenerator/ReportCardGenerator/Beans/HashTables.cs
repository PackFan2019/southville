using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Beans
{
    class HashTables
    {
        public static Hashtable YearLevel = new Hashtable();


        //static HashTables()
        //{
        //    Hashtable temp = new Hashtable();
        //    temp.Add("SCIE", 2.0);
        //    YearLevel.Add("Grade1", temp);

        //    //Code to extract
        //    Hashtable temp2 = YearLevel["Grade1"];
        //    return temp2["SCIE"];
        //}

       
        public static Hashtable StudentCardTable = new Hashtable();

        
        public static Hashtable Grade1 = new Hashtable();
        public static Hashtable Grade2 = new Hashtable();
        public static Hashtable Grade3 = new Hashtable();
        public static Hashtable Grade4 = new Hashtable();
        public static Hashtable Grade5 = new Hashtable();
        public static Hashtable Grade6 = new Hashtable();
        public static Hashtable Grade7 = new Hashtable();
        public static Hashtable HS1 = new Hashtable();
        public static Hashtable HS2 = new Hashtable();
        public static Hashtable HS3 = new Hashtable();
        public static Hashtable HS4 = new Hashtable();

        //Hashtables for Students Details
        public static Hashtable Term1 = new Hashtable();
        public static Hashtable Term2 = new Hashtable();
        public static Hashtable Term3 = new Hashtable();

        //Hasttables for Subject Names
        public static Hashtable SubjectName = new Hashtable();

        //Hashtables for Skills
        public static Hashtable SkillTerm1 = new Hashtable();
        public static Hashtable SkillTerm1Numeric = new Hashtable();

        public static Hashtable SkillTerm2 = new Hashtable();
        public static Hashtable SkillTerm2Numeric = new Hashtable();

        public static Hashtable SkillTerm3 = new Hashtable();
        public static Hashtable SkillTerm3Numeric = new Hashtable();


        //Hashtables for Grade
        public static Hashtable GradeTerm1 = new Hashtable();
        public static Hashtable GradeTerm1Numeric = new Hashtable();

        public static Hashtable GradeTerm2 = new Hashtable();
        public static Hashtable GradeTerm2Numeric = new Hashtable();

        public static Hashtable GradeTerm3 = new Hashtable();
        public static Hashtable GradeTerm3Numeric = new Hashtable();
        
    }
}
