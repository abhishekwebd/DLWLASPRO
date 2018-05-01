using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyCrypt;
using System.Data;

namespace DLWLASPRO.App_Code
{
    public class dbConnect
    {
        private static SqlConnection NewCon;
        private static string conStr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString.ToString();

        public static SqlConnection getConnection()
        {
            NewCon = new SqlConnection(conStr);
            return NewCon;
        }
        public static String getConstr()
        {
            return "Data Source = AJAY\\SQLEXPRESS2008;Initial Catalog=DLWLOCODB;User id=admin;Password=''";
        }

        public static SqlConnection getCn()
        {
            EncDcr enc = new EncDcr();
            SqlConnection cn = enc.Connection("AJAY\\SQLEXPRESS2008", "DLWLOCODB", "admin", "");
            cn.Open();
            return cn;
        }
    }
}