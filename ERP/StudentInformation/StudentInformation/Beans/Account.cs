using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformation.Beans
{
    class Account
    {
        public static List<Account> accountList = new List<Account>();
        private String _uId;

        public String UId
        {
            get { return _uId; }
            set { _uId = value; }
        }
        private String _uname;

        public String Uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        private String _pword;

        public String Pword
        {
            get { return _pword; }
            set { _pword = value; }
        }
    }
}
