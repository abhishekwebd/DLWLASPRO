using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCrypt;

namespace DLWLASPRO.App_Code
{
    public class enc
    {
        public static String Encrypt(string String)
        {
            EncDcr encr = new EncDcr();
            return encr.Encrypt(String);
        }
        public static String Decrypt(string String)
        {
            EncDcr encr = new EncDcr();
            return encr.Decrypt(String);
        }

    }
}