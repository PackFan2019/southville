using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformation.Beans
{
    class Profile
    {
        public static List<Profile> listAgeAndLevel = new List<Profile>();

        private String _level;

        public String Level
        {
            get { return _level; }
            set { _level = value; }
        }
        private String _age;

        public String Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
