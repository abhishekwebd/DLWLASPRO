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

namespace DLWLASPRO.UserControls
{
    public partial class CreateAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlShop.DataSource = getMasterRecords.GetShopMaster("IsDeactive = 0 and");
                ddlShop.DataTextField = "Name";
                ddlShop.DataValueField = "Code";
                ddlShop.DataBind();
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {

        }
    }
}