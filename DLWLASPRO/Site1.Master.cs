using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWLASPRO
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["userCookie"];
                if (cookie == null)
                {
                    Response.Redirect("Index.aspx", false);
                }
                //else
                //{
                //    if (cookie["UserType"] == "Admin")
                //    {
                //        panel1.Visible = false;
                //    }
                //    if (cookie["UserType"] == "Supervisor")
                //    {
                //        panel1.Visible = false;
                //        panel2.Visible = false;
                //    }
                //    if (cookie["UserType"] == "Staff")
                //    {
                //        panel1.Visible = false;
                //        panel2.Visible = false;
                //    }
                //}
                //txtName.Text = cookie["Name"].ToString();
                txtName.Text = cookie["Name"].ToString(); 
            }
            catch (Exception ex) { }
        }

        protected void btnlogout_ServerClick(object sender, EventArgs e)
        {
            ExpireAllCookies();
            Session.Clear();
            Response.Redirect("Index.aspx", false);
        }

        private void ExpireAllCookies()
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var cookieName = cookie.Name;
                        var expiredCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }

                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }
        }
    }
}