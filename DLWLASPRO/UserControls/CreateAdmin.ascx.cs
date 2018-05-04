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
            try
            {
                HttpCookie cookie = Request.Cookies["userCookie"];
                if (txtEmpNo.Text.Trim() == "" || txtFullName.Text == "" || txtPassword.Text == "" || txtUsername.Text == "" || ddlShop.SelectedValue == "")
                {
                   MyAlert("warning", "All Fields are Mendatory");
                }
                else
                {
                    WCFS.UserDetails cu = new WCFS.UserDetails();
                    cu.TransType = 'I';
                    cu.UserName = txtUsername.Text;
                    cu.Fullname = txtFullName.Text;
                    cu.Empno = txtEmpNo.Text;
                    cu.Password = enc.Encrypt(txtPassword.Text);
                    cu.Shopid = int.Parse(ddlShop.SelectedValue);
                    cu.WorkFlowList = "";
                    cu.UserCategory = 0;
                    cu.IsDeactive = 0;
                    cu.Code = 0;
                    cu.User = cookie["Name"].ToString();

                


                    DataTable dt = new DataTable();
                    WCFS.wcf_CreateOperator createUser = new WCFS.wcf_CreateOperator();
                    dt = createUser.InsertUserDetails(cu);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            MyAlert("success", dt.Rows[0][1].ToString());
                        }
                        else
                        {
                            MyAlert("error", dt.Rows[0][1].ToString());
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MyAlert("error", ex.Message);
            }
        }

        private void MyAlert(string stat, string Msg)
        {
            HttpCookie cookie = Request.Cookies["userCookie"];
            cookie["errorStat"] = stat;
            cookie["errorMsg"] = Msg;
            Response.Cookies.Add(cookie);
            Response.Redirect(Request.RawUrl, false);
        }
    }
}