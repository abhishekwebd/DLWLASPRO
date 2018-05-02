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
using System.IO;
using System.Xml.Linq;


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
            try
            {
                
                string WorkFlowList = "";
                foreach (ListItem item in chkWorkFlowList.Items)
                    if (item.Selected)
                        WorkFlowList += item.Value+"|";


                WorkFlowList = WorkFlowList.Remove(WorkFlowList.Length - 1);
                HttpCookie cookie = Request.Cookies["userCookie"];
                WCFS.UserDetails cu = new WCFS.UserDetails();
                cu.TransType = 'I';
                cu.UserName = txtUsername.Text;
                cu.Fullname = txtFullName.Text;
                cu.Empno = txtEmpNo.Text;
                cu.Password = txtPassword.Text;
                cu.Shopid = int.Parse(ddlShop.SelectedValue);
                cu.WorkFlowList = WorkFlowList;
                cu.IsDeactive = 0;
                cu.Code = 0;
                cu.User = cookie["Name"].ToString(); 

                if (chkDiesel.Checked == true && chkElectric.Checked == true)
                {
                    cu.LocoCategory = "Diesel | Electric";
                }
                else if (chkDiesel.Checked == true)
                {
                    cu.LocoCategory = "Diesel | 0";
                }
                else if (chkElectric.Checked == true)
                {
                    cu.LocoCategory = "0 | Electric";
                }
                else
                {
                    txtalert.Text = "LocoCategory Selection Required";
                }


                DataTable dt = new DataTable();
                WCFS.wcf_CreateOperator createUser = new WCFS.wcf_CreateOperator();
                dt = createUser.InsertUserDetails(cu);
                if (dt.Rows.Count > 0)
                {
                    txtalert.Text = dt.Rows[0][1].ToString();
                    if (dt.Rows[0][0].ToString() == "1")
                        txtalert.CssClass = "alert alert-success pull-right";
                    else
                        txtalert.CssClass = "alert alert-danger pull-right";
                }

            }
            catch (Exception ex)
            {
                txtalert.Text = ex.Message;
            }
        }

    }
}