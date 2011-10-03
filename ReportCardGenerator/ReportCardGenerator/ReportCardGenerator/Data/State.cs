using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportCardGenerator.Beans;

namespace ReportCardGenerator.Data
{
    public class State
    {
        /*Class variables*/
        private List<Student> students = new List<Student>();

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        
        /*Singleton pattern*/
        private static State instance = new State();
        public static State getInstance()
        {
            return instance;
        }
    }
}
