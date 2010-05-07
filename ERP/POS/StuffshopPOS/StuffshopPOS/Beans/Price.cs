using System;
using System.Collections.Generic;
using System.Text;

namespace StuffshopPOS.Beans
{
    class Price
    {
         private string UOFM = "";

        public string uofm
        {
            get { return UOFM; }
            set {UOFM = value; }
        }

        private double toqty;

        public double Toqty
        {
            get { return toqty; }
            set { toqty = value; }
        }

        private double fromqty;

        public double Fromqty
        {
            get { return fromqty; }
            set { fromqty = value; }
        }

        private double uomprice;

        public double Uomprice
        {
            get { return uomprice; }
            set { uomprice = value; }
        }

        private double qtybsoum;

        public double Qtybsoum
        {
            get { return qtybsoum; }
            set { qtybsoum = value; }
        }

        public Price(String UOFM, double toqty, double fromqty, double uomprice, double qtybsoum)
        {

            this.UOFM = UOFM;
            this.toqty = toqty;
            this.fromqty = fromqty;
            this.uomprice = uomprice;
            this.qtybsoum = qtybsoum;

        }

        public  Price()
        {

        }

        
    }
}
