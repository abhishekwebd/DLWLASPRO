using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DLWLASPRO.WCFS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CreateOperator" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CreateOperator
    {
        [OperationContract]
        DataTable InsertUserDetails(UserDetails userInfo);
    }

    public class UserDetails
    {

        string userid = string.Empty;

        string password = string.Empty;

        string fullname = string.Empty;

        string empNo = string.Empty;

        string lococategory = string.Empty;

        int shopid = 0;

        string WorkFlowXml;

        char transtype;

        int isdeactive;

        int code;

        string user;



        [DataMember]

        public string User
        {

            get { return user; }

            set { user = value; }

        }

        [DataMember]

        public int IsDeactive
        {

            get { return isdeactive; }

            set { isdeactive = value; }

        }

        [DataMember]

        public int Code
        {

            get { return code; }

            set { code = value; }

        }

        [DataMember]

        public string UserName
        {

            get { return userid; }

            set { userid = value; }

        }

        [DataMember]

        public string Password
        {

            get { return password; }

            set { password = value; }

        }

        [DataMember]

        public string LocoCategory
        {

            get { return lococategory; }

            set { lococategory = value; }

        }

        [DataMember]

        public string Fullname
        {

            get { return fullname; }

            set { fullname = value; }

        }

        [DataMember]

        public string Empno
        {

            get { return empNo; }

            set { empNo = value; }

        }

        [DataMember]

        public int Shopid
        {

            get { return shopid; }

            set { shopid = value; }

        }

        [DataMember]

        public char TransType
        {

            get { return transtype; }

            set { transtype = value; }

        }

        [DataMember]

        public string WorkFlowList
        {

            get { return WorkFlowXml; }

            set { WorkFlowXml = value; }

        }
    }

}
