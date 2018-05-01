using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace DLWLASPRO.App_Code
{
    public class getMasterRecords 
    {
        public static DataTable GetLocoType(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,Name,IsDeactive from tblLocoType where "+isdeactive+"  IsDelete =0").Tables[0];
        }

        public static DataTable GetEngineMaster(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,Name,IsDeactive from tblEngineMaster where " + isdeactive + " IsDelete =0").Tables[0];
        }

        public static DataTable GetACSystem(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,Name,IsDeactive from tblAcSystem where " + isdeactive + "  IsDelete =0").Tables[0];
        }

        public static DataTable GetLocoDetail(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,AcSystemId,IsDeactive from tblLocoDetail where " + isdeactive + " IsDelete =0").Tables[0];
        }

        public static DataTable GetShopSection(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,Name,Shopid,IsDeactive from tblShopSection where " + isdeactive + " IsDelete =0").Tables[0];
        }

        public static DataTable GetShopMaster(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,Name,ShopNo,Shortname,IsDeactive from tblShopMaster where " + isdeactive + " IsDelete =0").Tables[0];
        }

        public static DataTable GetWorkFlowMaster(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select * from tblWorkFlowMaster where " + isdeactive + " IsDelete =0").Tables[0];
        }
        public static DataTable GetViewShopSection()
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "SELECT  dbo.tblShopMaster.Name AS ShopName, dbo.TblShopSection.Name, dbo.TblShopSection.IsDeactive, dbo.TblShopSection.IsDelete, dbo.tblShopMaster.Code AS ShopCode, dbo.TblShopSection.Code FROM   dbo.TblShopSection INNER JOIN  dbo.tblShopMaster ON dbo.TblShopSection.ShopId = dbo.tblShopMaster.Code ").Tables[0];
        }
        public static DataTable GetWorkFlow()
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "SELECT     dbo.tblShopMaster.ShopNo, dbo.tblWorkFlowMaster.SrNo, dbo.tblWorkFlowMaster.Shopid, dbo.tblWorkFlowMaster.LocoCategory, dbo.tblWorkFlowMaster.Head, dbo.tblWorkFlowMaster.priority, dbo.tblWorkFlowMaster.IsDeactive, dbo.tblWorkFlowMaster.IsDelete, dbo.tblShopMaster.Name, dbo.tblWorkFlowMaster.Code FROM dbo.tblShopMaster INNER JOIN dbo.tblWorkFlowMaster ON dbo.tblShopMaster.Code = dbo.tblWorkFlowMaster.Shopid").Tables[0];
        }
        public static DataTable GetPermissionMaster(string isdeactive)
        {
            return SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select Code,Modulename,Categoryame,IsDeactive from tblPermissionMaster where " + isdeactive + "  IsDelete =0").Tables[0];
        }
    }
}