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
using System.Drawing;

namespace DLWLASPRO
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["userCookie"];
            if (cookie != null)
            {
                Response.Redirect("Dashboard.aspx", false);
            }
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            if (txtUsername.Value.Trim() != "" && txtPassword.Value.Trim() != "")
            {
                
                DataSet ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_LoginCheck", txtUsername.Value,enc.Encrypt(txtPassword.Value));
                if (ds.Tables[0].Rows[0]["Code"].ToString() != "0")
                {
                    if (ds.Tables[0].Rows[0]["UserCategory"].ToString() == "2")
                    {
                        HttpCookie userCookie = new HttpCookie("userCookie");
                        userCookie["Code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                        userCookie["UserCategory"] = ds.Tables[0].Rows[0]["UserCategory"].ToString();
                        userCookie["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        userCookie.Expires = DateTime.UtcNow.AddDays(1);
                        Response.Cookies.Add(userCookie);
                        Response.Redirect("Dashboard.aspx", false);
                    }

                }
                else
                {

                    Label1.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
                    Label1.ForeColor = Color.Red;
                }
            }
        }
    }
}

