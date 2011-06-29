using System;
using System.Collections.Generic;
using System.Text;
using StudentAssessment.Objects;
using StudentAssessment.Data;

namespace StudentAssessment.Adapter
{
    public class PlanAdapter
    {
        static PlanAdapter instance;
        static PlanAdapter() { }

        public static PlanAdapter Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new PlanAdapter();
                }
                return instance; 
            }
        }


        public Plans GetPlans()
        {
            return PlanData.Instance.GetPlans();
        }

        public Plan GetPlan(string planID)
        {
            return PlanData.Instance.GetPlan(planID);
        }

        public int GetPayday(string customerNo, int paydayNo)
        {
            return PlanData.Instance.GetPayday(customerNo, paydayNo);
        }

        public Schedule GetAssessmentSchedule(string assessmentNo, Transaction_Type sopType)
        {
            return PlanData.Instance.GetAssessmentSchedule(assessmentNo, sopType);
        }
        public Schedule GetPlanSchedule(string planID)
        {
            return PlanData.Instance.GetPlanSchedule(planID);
        }
    }
}
