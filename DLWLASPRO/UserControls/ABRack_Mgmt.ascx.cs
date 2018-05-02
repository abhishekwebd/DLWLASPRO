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
    public partial class ABRack_Mgmt : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblLocono.Text = Request.QueryString["LocoNo"].ToString();
            }
            catch (Exception eX) { }
            if (!IsPostBack)
            {
                ddlSection.DataSource = getMasterRecords.GetShopSection();
                ddlSection.DataTextField = "Name";
                ddlSection.DataValueField = "Code";
                ddlSection.DataBind();
            }
        }
       
    }
}