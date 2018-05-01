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
    public partial class PermissionMaster : System.Web.UI.Page
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                _LoadGrid();
            }
        }

        private void _LoadGrid()
        {

            try
            {
                grdPermissionMaster.DataSource = getMasterRecords.GetPermissionMaster("IsDeactive in (0,1) and");
                grdPermissionMaster.DataBind();

            }
            catch (Exception ex)
            { }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {

            try
            {
                Fn_PermissionMaster("I", 0, txtModulename.Value.ToUpper(), txtcategory.Value.ToUpper(), 0);
                _LoadGrid();
                txtModulename.Value = "";
                txtcategory.Value = "";
            }
            catch (Exception ex)
            {
                txtalert.Text = ex.Message;
            }

        }

        private void Fn_PermissionMaster(string transtype, int code, string Modulename, string Category, int isdeactive)
        {
            try
            {

                EncDcr enc = new EncDcr();
                ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_PermissionMaster", transtype, code, Modulename, Category, isdeactive, "Admin", enc.GetIPAddress(), enc.GetHostName());
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
                txtalert.Text = ex.Message;
            }
        }

        protected void grdPermissionMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPermissionMaster.EditIndex = e.NewEditIndex;
            _LoadGrid();
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

                string modulname = (row.Cells[1].Controls[0] as TextBox).Text;
                string category = (row.Cells[2].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_PermissionMaster("U", int.Parse(code.Value), modulname, category, isd);
                grdPermissionMaster.EditIndex = -1;
                _LoadGrid();
            }
            catch (Exception ex)
            {

                txtalert.Text = ex.Message;
            }
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

                string modulname = (row.Cells[1].Controls[0] as TextBox).Text;
                string category = (row.Cells[2].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_PermissionMaster("D", int.Parse(code.Value), modulname, category, isd);
                grdPermissionMaster.EditIndex = -1;
                _LoadGrid();
            }
            catch (Exception ex)
            {

                txtalert.Text = ex.Message;
            }
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            grdPermissionMaster.EditIndex = -1;
            _LoadGrid();

        }
    }
}