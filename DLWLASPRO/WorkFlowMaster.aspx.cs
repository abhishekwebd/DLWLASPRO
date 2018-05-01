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
    public partial class WorkFlowMaster : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ShopName();
                _loadGrid();

            }
        }
        private void _loadGrid()
        {
            grdWorkFlow.DataSource = getMasterRecords.GetWorkFlow();
            grdWorkFlow.DataBind();

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
                Fn_WorkFlowMaster("I", 0, int.Parse(txtSrno.Value), int.Parse(ddlShopName.SelectedValue), txtHeadName.Value, int.Parse(txtPriority.Value), int.Parse(ddlLocoCategory.SelectedValue), 0);
                _loadGrid();
                txtSrno.Value = "";
                txtHeadName.Value = "";
                txtPriority.Value = "";
            }
            catch (Exception ex)
            { }

        }
        private void Fn_WorkFlowMaster(string transtype, int code, int Srno, int ShopID, string head, int priority, int lococatgory, int IsDeactive)
        {
            try
            {
                EncDcr enc = new EncDcr();
                ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_WorkFlowMaster", transtype, code, Srno, ShopID, lococatgory, head, priority, IsDeactive, "Admin", enc.GetIPAddress(), enc.GetHostName());
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

        protected void grdWorkFlow_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    string ctype1 = (e.Row.FindControl("lblShopCode") as HiddenField).Value;
                    ddlShop.Items.FindByValue(ctype1).Selected = true;
                 
                    DropDownList ddlLocoCategory = (e.Row.FindControl("ddlLocoCategory") as DropDownList);
                    string ctype = (e.Row.FindControl("lblLocoCategory") as HiddenField).Value;
                    ddlLocoCategory.Items.FindByValue(ctype).Selected = true;

                }
            }
            catch (Exception ex)
            {
                txtalert.Text = ex.Message;
            }

        }

        protected void grdWorkFlow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdWorkFlow.EditIndex = e.NewEditIndex;
            _loadGrid();

        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
                string Srno = (row.Cells[1].Controls[0] as TextBox).Text;
                string Head = (row.Cells[2].Controls[0] as TextBox).Text;
                DropDownList ShopName = (DropDownList)row.Cells[0].FindControl("ddlShop");
                string priorty = (row.Cells[4].Controls[0] as TextBox).Text;
                DropDownList LocoCategory = (DropDownList)row.Cells[0].FindControl("ddlLocoCategory");
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_WorkFlowMaster("U", int.Parse(code.Value), int.Parse(Srno), int.Parse(ShopName.SelectedValue), Head, int.Parse(priorty), int.Parse(LocoCategory.SelectedValue), isd);
                grdWorkFlow.EditIndex = -1;
                _loadGrid();
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
                string Srno = (row.Cells[1].Controls[0] as TextBox).Text;
                string Head = (row.Cells[2].Controls[0] as TextBox).Text;
                DropDownList ShopName = (DropDownList)row.Cells[0].FindControl("ddlShop");
                string priorty = (row.Cells[4].Controls[0] as TextBox).Text;
                DropDownList LocoCategory = (DropDownList)row.Cells[0].FindControl("ddlLocoCategory");
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_WorkFlowMaster("D", int.Parse(code.Value), int.Parse(Srno), int.Parse(ShopName.SelectedValue), Head, int.Parse(priorty), int.Parse(LocoCategory.SelectedValue), isd);
                grdWorkFlow.EditIndex = -1;
                _loadGrid();
            }
            catch (Exception ex)
            { }
        }


        protected void OnCancel(object sender, EventArgs e)
        {
            grdWorkFlow.EditIndex = -1;
            _loadGrid();

        }

    }
}