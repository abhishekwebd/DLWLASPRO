using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using MyCrypt;
using DLWLASPRO.App_Code;

namespace DLWLASPRO
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] == "1")
             ABRack_Mgmt.Visible = true;

            if (Request.QueryString["code"] == "2")
                CAB_Mgmt.Visible = true;
            
            if (!IsPostBack)
            {
                DataList1.DataSource = command.ExecuteQuery("select * from tblLocoMaster where IsDelete = 0 and IsDeactive =0");
                DataList1.DataBind();
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int id = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString());
            DataTable dt = SqlHelper.ExecuteDataset(dbConnect.getConstr(), CommandType.Text, "select LocoCategory,LastShopid from tblLocoMaster where Code ="+id).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataList DataList2 = (DataList)e.Item.FindControl("DataList2");
                DataList2.DataSource = command.ExecuteQuery("select tblWorkFlowMaster.Code,Head,LocoNo,tblLocoMaster.CreateDate from tblWorkFlowMaster inner join tblLocoMaster on tblLocoMaster.LocoCategory = tblWorkFlowMaster.LocoCategory and tblLocoMaster.LastShopId = tblWorkFlowMaster.Shopid where tblLocoMaster.Code = " + id + " and tblWorkFlowMaster.IsDelete = 0 order by srno");
                DataList2.DataBind();
            }
       

        }
    }
}