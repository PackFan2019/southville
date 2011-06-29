using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAssessment.Objects
{
    public class Item
    {
        #region Members
        private string itemNo;
        private string itemDescription;
        private string itemClass;
        private string uofm;
        private decimal qty = 1;
        private decimal unitprice;
        private string priceGroup = "";
        private decimal markDown = 0.00M;
        private decimal extendedPrice = 0.00M;
        private string componentOf = "";
        private ItemType itemType = ItemType.Service;

        public ItemType ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public string ComponentOf
        {
            get { return componentOf; }
            set { componentOf = value; }
        }

        public decimal ExtendedPrice
        {
            get 
            {
                extendedPrice = (unitprice - ((markDown / 100) * unitprice)) * qty;
                return decimal.Round(extendedPrice, 2); 
            }
        }

        public decimal MarkDown
        {
            get 
            {
                return decimal.Round(markDown, 2); 
            }
            set 
            {
                if (value > 100 || value < 0)
                {
                    throw new Exception
                        ("Markdown percentage cannot be greater "
                        + "\nthan 100 or less than 0.");
                }
                else
                {
                    markDown = value;
                }
            }
        }

        public string PriceGroup
        {
            get { return priceGroup; }
            set { priceGroup = value; }
        }
        #endregion

        public Item() { }

        public Item(string itemNo, string itemDescription
            , string itemClass, string uofm, decimal unitprice)
        {            
            this.itemNo = itemNo;
            this.itemDescription = itemDescription;
            this.itemClass = itemClass;
            this.uofm = uofm;
            this.unitprice = unitprice;
        }

        #region Get, Set


        public string ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }

        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        public string ItemClass
        {
            get { return itemClass; }
            set { itemClass = value; }
        }

        public string Uofm
        {
            get { return uofm; }
            set { uofm = value; }
        }

        public decimal Qty
        {
            get 
            {
                return decimal.Round(qty, 0); 
            }
            set 
            {
                if (value >= 1)
                {
                    qty = value;
                }
                else
                {
                    throw new Exception("Quantity cannot be negative.");
                }
            }
        }

        public decimal Unitprice
        {
            get 
            {
                return decimal.Round(unitprice, 2); 
            }
            set { unitprice = value; }
        } 
        #endregion

    }
}
