using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StudentAssessment.Objects
{
    public class Students : CollectionBase
    {
        public void Add(Student student)
        {
            List.Add(student);
        }

        public void Delete(Student student)
        {
            List.Remove(student);
        }

        public Student GetStudent(int index)
        {
            return (Student)List[index];
        }

        public int IndexOf(Student student)
        {
            return List.IndexOf(student);
        }

    }
}
