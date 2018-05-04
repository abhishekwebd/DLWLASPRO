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
    public partial class ShopMaster : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadGrird();
            }
        }

        private void _loadGrird()
        {
            grdShopMaster.DataSource = getMasterRecords.GetShopMaster("IsDeactive in (0,1) and");
            grdShopMaster.DataBind();
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtShopName.Value.Trim() != "" && txtShopNo.Value.Trim() != "" &&txtShortname.Value.Trim() !="")
                {
                    Fn_ShopMaster("I", txtShopName.Value.ToUpper(), txtShopNo.Value,txtShortname.Value.ToUpper(), 0, 0);
                    _loadGrird();
                    txtShopName.Value = "";
                    txtShopNo.Value = "";
                    txtShortname.Value = "";
                }
            }
            catch (Exception ex)
            { }
        }

        private void Fn_ShopMaster(string transtype, string shopname, string shopno ,string ShortName, int code, int isdeactive)
        {
            EncDcr enc = new EncDcr();
            ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_ShopMaster", transtype, shopname, shopno, ShortName, code, isdeactive, "Admin", enc.GetIPAddress(), enc.GetHostName());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtalert.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    txtalert.CssClass = "alert alert-success pull-right";
                else
                    txtalert.CssClass = "alert alert-danger pull-right";
            }
        }

        protected void grdShopMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdShopMaster.EditIndex = e.NewEditIndex;
            _loadGrird();
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
              
                string shopname = (row.Cells[1].Controls[0] as TextBox).Text;
                string shopno = (row.Cells[2].Controls[0] as TextBox).Text;
                string ShortName = (row.Cells[3].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_ShopMaster("U", shopname.ToUpper(), shopno, ShortName.ToUpper(), int.Parse(code.Value), isd);
                grdShopMaster.EditIndex = -1;
                _loadGrird();
            }
            catch (Exception ex)
            { }


        }
        protected void OnDelete(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
                string shopname = (row.Cells[1].Controls[0] as TextBox).Text;
                string shopno = (row.Cells[2].Controls[0] as TextBox).Text;
                string ShortName = (row.Cells[3].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_ShopMaster("D", shopname, shopno, ShortName, int.Parse(code.Value), isd);
                grdShopMaster.EditIndex = -1;
                _loadGrird();
            }
            catch (Exception ex)
            { }
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            grdShopMaster.EditIndex = -1;
            _loadGrird();
        
        }
       

       
    }
}