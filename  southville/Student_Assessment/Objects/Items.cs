using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StudentAssessment.Objects
{
    public class Items : CollectionBase
    {
        public void Add(Item item)
        {
            if (GetItem(item.ItemNo) != null)
            {
                GetItem(item.ItemNo).Qty += item.Qty;
            }
            else
            {
                List.Add(item);
            }            
        }

        public void Delete(Item item)
        {
            List.Remove(item);
        }

        public Item GetItem(int index)
        {
            return (Item)List[index];
        }

        public int IndexOf(Item item)
        {
            return List.IndexOf(item);
        }

        public Item GetItem(string itemNo)
        {
            Item item = null;
            for (int i = 0; i <= List.Count - 1; i++)
            {
                if (GetItem(i).ItemNo == itemNo)
                {
                    item = GetItem(i);
                    break;
                }
            }
            return item;
        }
    }
}
