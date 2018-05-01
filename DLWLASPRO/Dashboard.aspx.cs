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
            if (!IsPostBack)
            {
                DataList1.DataSource = command.ExecuteQuery("select * from tblLocoMaster where IsDelete = 0");
                DataList1.DataBind();
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int id = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString());
            DataList DataList2 = (DataList)e.Item.FindControl("DataList2");
            DataList2.DataSource = command.ExecuteQuery("select * from tblWorkFlowMaster where  LocoCategory="+id+" and IsDelete = 0");
            DataList2.DataBind();
        }
    }
}