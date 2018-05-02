using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DLWLASPRO.App_Code;
using Microsoft.ApplicationBlocks.Data;
using MyCrypt;

namespace DLWLASPRO.WCFS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CreateOperator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CreateOperator.svc or wcf_CreateOperator.svc.cs at the Solution Explorer and start debugging.
    public class wcf_CreateOperator : Iwcf_CreateOperator
    {
        public DataTable InsertUserDetails(UserDetails userInfo)
        {
            EncDcr enc = new EncDcr();
            DataTable dataTable = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "SP_USERMGMT", userInfo.TransType, userInfo.Code, userInfo.Shopid, userInfo.UserName, userInfo.Password, userInfo.Empno, userInfo.Fullname, 1, userInfo.LocoCategory, userInfo.WorkFlowList, userInfo.IsDeactive, userInfo.User, enc.GetIPAddress(), enc.GetHostName()).Tables[0];
            return dataTable;

        }
    }
}
