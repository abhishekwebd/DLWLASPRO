using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWLASPRO.UserControls
{
    public partial class Popup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["userCookie"];
                if (cookie["errorStat"].ToString() == "success")
                {
                    Panel1.Visible = true;
                    txtalert.Text = cookie["errorMsg"].ToString();
                    exampleModalLabel.Visible = true;
                }
                else if (cookie["errorStat"].ToString() == "error")
                {
                    Panel1.Visible = true;
                    txtalert.Text = cookie["errorMsg"].ToString();
                    exampleModalLabel2.Visible = true;
                }
                else if (cookie["errorStat"].ToString() == "warning")
                {
                    Panel1.Visible = true;
                    txtalert.Text = cookie["errorMsg"].ToString();
                    exampleModalLabel3.Visible = true;
                }

                cookie["errorStat"] = "";
                cookie["errorMsg"] = "";
                Response.Cookies.Add(cookie);
            }
            catch (Exception ex) { }
        }

       
    
    }
}