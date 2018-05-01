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


namespace DLWLASPRO
{
    public partial class EngineMaster : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _LoadGried();
            }
        }
        private void _LoadGried()
        {
            try
            {
                grdEngineMaster.DataSource = getMasterRecords.GetEngineMaster("IsDeactive in (0,1) and");
                grdEngineMaster.DataBind();
            }
            catch (Exception ex)
            { }
        }


        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtEngineName.Value.Trim() != "")
                {
                    Fn_EngineMaster("I", txtEngineName.Value.ToUpper(),0,0);
                    _LoadGried();
                    txtEngineName.Value = "";

                }
            }
            catch (Exception ex)
            { }

        }

        private void Fn_EngineMaster(string transtype, string Name, int code, int isdeactive)
        {
            EncDcr enc = new EncDcr();
            ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_EngineMaster", transtype, Name, code, isdeactive, "Admin", enc.GetIPAddress(), enc.GetHostName());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtalert.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    txtalert.CssClass = "alert alert-success pull-right";
                else
                    txtalert.CssClass = "alert alert-danger pull-right";
            }
        }

        protected void grdEngineMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { }
            grdEngineMaster.EditIndex = e.NewEditIndex;
            _LoadGried();

        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

                string Enginename = (row.Cells[1].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_EngineMaster("U", Enginename, int.Parse(code.Value), isd);
                grdEngineMaster.EditIndex = -1;
                _LoadGried();
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

                string Enginename = (row.Cells[1].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_EngineMaster("D", Enginename, int.Parse(code.Value), isd);
                grdEngineMaster.EditIndex = -1;
                _LoadGried();
            }
            catch (Exception ex)
            { }

        }

        protected void OnCancel(object sender, EventArgs e)
        {
            grdEngineMaster.EditIndex = -1;
            _LoadGried();
        }
    }

}