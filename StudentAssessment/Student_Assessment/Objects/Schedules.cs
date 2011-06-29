using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace StudentAssessment.Objects
{
    public class Schedule : CollectionBase
    {
        public void Add(Due due)
        {
            List.Add(due);
        }

        public void Delete(Due due)
        {
            List.Remove(due);
        }

        public Due GetDue(int index)
        {
            return (Due)List[index];
        }

        public int IndexOf(Due due)
        {
            return List.IndexOf(due);
        }

        public Due GetDue(DateTime dueDate)
        {
            Due due = null;
            for (int i = 0; i <= List.Count - 1; i++)
            {
                if (GetDue(i).Date.Date == dueDate.Date)
                {
                    due = GetDue(i);
                }
            }
            return due;
        }
    }
}
