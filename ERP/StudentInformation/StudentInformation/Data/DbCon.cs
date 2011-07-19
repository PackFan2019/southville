using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Southville.GP.Beans;
using Southville.GP.Data;
namespace StudentInformation.Data
{
    class DbCon
    {
        private static DbCon instance = new DbCon();
        private const string connectionString = "server=" + Constants.SERVERNAME + ";user id=" + Constants.USERID +
            ";password=" + Constants.PASSWORD + ";database=" + Constants.DATABASENAME + ";Trusted_Connection=false";
        
    }
}
