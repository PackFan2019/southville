using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StudentAssessment.Objects
{
    public class Plans : CollectionBase
    {
        public void Add(Plan plan)
        {
            List.Add(plan);
        }
        public void Delete(Plan plan)
        {            
            List.Remove(plan);
        }
        public Plan GetPlan(int index)
        {
            return (Plan)List[index];
        }
        public int IndexOf(Plan plan)
        {
            return List.IndexOf(plan);
        }
    }
}
