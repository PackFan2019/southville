using System;
using System.Collections.Generic;
using System.Text;
using StudentAssessment.Objects;
using StudentAssessment.Data;

namespace StudentAssessment.Adapter
{
    public class StudentAdapter
    {
        public static StudentAdapter instance;
        static StudentAdapter() { }
        public static StudentAdapter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentAdapter();
                }
                return instance;
            }
        }

        public Students GetStudents()
        {
            return StudentData.Instance.GetStudents();
        }

        public Student GetStudent(string customerNo)
        {
            return StudentData.Instance.GetStudent(customerNo);
        }
    }
}
