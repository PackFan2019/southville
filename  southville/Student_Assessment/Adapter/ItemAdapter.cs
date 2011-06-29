using System;
using System.Collections.Generic;
using System.Text;
using StudentAssessment.Objects;
using StudentAssessment.Data;

namespace StudentAssessment.Adapter
{
    public class ItemAdapter
    {
        static ItemAdapter instance;
        static ItemAdapter() { }
        public static ItemAdapter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemAdapter();
                }
                return instance;
            }
        }


        public Items GetItems(string level
            , string currency
            , string uOfM)
        {
            return ItemData.Instance.GetItems(level
                , currency
                , uOfM);
        }

        public Item GetItem(string level, 
            string currency, string itemno, string uOfM)
        {
            return ItemData.Instance.GetItem(level, currency, itemno, uOfM);
        }

        public Items GetAssessmentItems(string assessmentNo, Transaction_Type sopType)
        {
            return ItemData.Instance.GetAssessmentItems(assessmentNo, sopType);
        }

        public string[] GetTemplates()
        {
            return ItemData.Instance.GetTemplates();
        }

        public Items GetKitComponents(string kitItemNo)
        {
            return ItemData.Instance.GetKitComponents(kitItemNo);
        }

        public Items GetTemplateItems(string templateID, string pricelevel
        , string currency, string uOFm)
        {
            return ItemData.Instance.GetTemplateItems(templateID, pricelevel
            , currency, uOFm);
        }

        public bool CheckMarkdownPassword(string password)
        {
            return ItemData.Instance.CheckMarkdownPassword(password);
        }
        
    }
}
