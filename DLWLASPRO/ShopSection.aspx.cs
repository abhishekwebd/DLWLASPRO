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
    public partial class ShopSection : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ShopName();
                _LoadGrid();
            }
        }
        private void _LoadGrid()
        {
            grdshopSection.DataSource = getMasterRecords.GetViewShopSection();
            grdshopSection.DataBind();
        }
        private void _ShopName()
        {

            ddlShopName.DataSource = getMasterRecords.GetShopMaster("IsDeactive = 0 and");
            ddlShopName.Items.Insert(0, new ListItem("--Select Shop Name--", ""));
            ddlShopName.DataTextField = "Name";
            ddlShopName.DataValueField = "Code";
            ddlShopName.DataBind();
        
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtShopsection.Value.Trim() != "")
                {
                    Fn_ShopSectionMaster("I",int.Parse(ddlShopName.SelectedValue),txtShopsection.Value, 0, 0);
                    _LoadGrid();
                     txtShopsection.Value = "";
                }
            }
            catch (Exception ex)
            { }
        }

        private void Fn_ShopSectionMaster(string transtype,int ShopCode ,string SectionName, int code, int isdeactive)
        {
            try
            {
                EncDcr enc = new EncDcr();
                ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_ShopSectionMaster", transtype, ShopCode, SectionName, code, isdeactive, "Admin", enc.GetIPAddress(), enc.GetHostName());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtalert.Text = ds.Tables[0].Rows[0][1].ToString();
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        txtalert.CssClass = "alert alert-success pull-right";
                    else
                        txtalert.CssClass = "alert alert-danger pull-right";
                }
            }
            catch (Exception ex)
            { 
            
            }
        }

        protected void grdshopSection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdshopSection.EditIndex = e.NewEditIndex;
            _LoadGrid();
        }

        protected void grdshopSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlShop = (e.Row.FindControl("ddlShop") as DropDownList);
                    ddlShop.DataSource = getMasterRecords.GetViewShopSection();
                    ddlShop.DataTextField = "ShopName";
                    ddlShop.DataValueField = "ShopCode";
                    ddlShop.DataBind();
                    string ctype = (e.Row.FindControl("lblShopCode") as HiddenField).Value;
                    ddlShop.Items.FindByValue(ctype).Selected = true;
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
                DropDownList ShopCode = (DropDownList)row.Cells[0].FindControl("ddlShop");
                string shopname = (row.Cells[2].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_ShopSectionMaster("U",int.Parse(ShopCode.SelectedValue),shopname, int.Parse(code.Value), isd);
                grdshopSection.EditIndex = -1;
                _LoadGrid();
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
                DropDownList ShopCode = (DropDownList)row.Cells[0].FindControl("ddlShop");
                string shopname = (row.Cells[2].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_ShopSectionMaster("D", int.Parse(ShopCode.SelectedValue), shopname, int.Parse(code.Value), isd);
                grdshopSection.EditIndex = -1;
                _LoadGrid();
            }
            catch (Exception ex)
            { }
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            grdshopSection.EditIndex = -1;
            _LoadGrid();

        }

    }
}