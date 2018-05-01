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
    public partial class CreateOperator : System.Web.UI.UserControl
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

        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select * from tblWorkFlowMaster where IsDelete=0 and Shopid = " + ddlShop.SelectedValue;


          if(chkDiesel.Checked == true && chkElectric.Checked == true)
          {
              query += "and LocoCategory in (0,1)";
          }
          else if (chkDiesel.Checked == true)
          {
              query += "and LocoCategory = 0";
          }
          else if(chkElectric.Checked == true)
          {
              query += "and LocoCategory = 1";
          }
            
            chkWorkFlowList.DataSource = command.ExecuteQuery(query);
            chkWorkFlowList.DataTextField = "Head";
            chkWorkFlowList.DataValueField = "Code";
            chkWorkFlowList.DataBind();
        }

        protected void chkElectric_CheckedChanged(object sender, EventArgs e)
        {
            string query = "select * from tblWorkFlowMaster where IsDelete=0 and Shopid = " + ddlShop.SelectedValue;


            if (chkDiesel.Checked == true && chkElectric.Checked == true)
            {
                query += "and LocoCategory in (0,1)";
            }
            else if (chkDiesel.Checked == true)
            {
                query += "and LocoCategory = 0";
            }
            else if (chkElectric.Checked == true)
            {
                query += "and LocoCategory = 1";
            }

            chkWorkFlowList.DataSource = command.ExecuteQuery(query);
            chkWorkFlowList.DataTextField = "Head";
            chkWorkFlowList.DataValueField = "Code";
            chkWorkFlowList.DataBind();
        }

        protected void chkDiesel_CheckedChanged(object sender, EventArgs e)
        {
            string query = "select * from tblWorkFlowMaster where IsDelete=0 and Shopid = " + ddlShop.SelectedValue;


            if (chkDiesel.Checked == true && chkElectric.Checked == true)
            {
                query += "and LocoCategory in (0,1)";
            }
            else if (chkDiesel.Checked == true)
            {
                query += "and LocoCategory = 0";
            }
            else if (chkElectric.Checked == true)
            {
                query += "and LocoCategory = 1";
            }

            chkWorkFlowList.DataSource = command.ExecuteQuery(query);
            chkWorkFlowList.DataTextField = "Head";
            chkWorkFlowList.DataValueField = "Code";
            chkWorkFlowList.DataBind();
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {

        }

    }
}