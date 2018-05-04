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
    public partial class LocoType : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _Loadgried();
            }
        }

        private void _Loadgried()
        {
            try
            {
                grdLocoType.DataSource = getMasterRecords.GetLocoType("IsDeactive in (0,1) and");
                grdLocoType.DataBind();

            }
            catch (Exception ex)
            { }


        }


        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtlocotype.Value.Trim() != "")
                {
                    Fn_LocoTypeMaster("I",txtlocotype.Value.ToUpper(),0,0);
                    _Loadgried();
                    txtlocotype.Value = "";

                }
            }
            catch (Exception ex)
            { }
        }


        private void Fn_LocoTypeMaster(string transtype, string Name, int code, int isdeactive)
        {
            EncDcr enc = new EncDcr();
            ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_LocotTypeMaster", transtype, Name, code, isdeactive, "Admin", enc.GetIPAddress(), enc.GetHostName());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtalert.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    txtalert.CssClass = "alert alert-success pull-right";
                else
                    txtalert.CssClass = "alert alert-danger pull-right";
            }
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                int isd = 0;
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

                string LocoType = (row.Cells[1].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_LocoTypeMaster("U", LocoType.ToUpper(), int.Parse(code.Value), isd);
                grdLocoType.EditIndex = -1;
                _Loadgried();
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

                string LocoType = (row.Cells[1].Controls[0] as TextBox).Text;
                HiddenField code = (HiddenField)row.Cells[0].FindControl("Code");
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDeactive");
                if (chk.Checked == true) { isd = 1; } else { isd = 0; }
                Fn_LocoTypeMaster("D", LocoType, int.Parse(code.Value), isd);
                grdLocoType.EditIndex = -1;
                _Loadgried();
            }
            catch (Exception ex)
            { }
        }


        protected void OnCancel(object sender, EventArgs e)
        {
            grdLocoType.EditIndex = -1;
            _Loadgried();
        }



        protected void grdLocoType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdLocoType.EditIndex = e.NewEditIndex;
            _Loadgried();
        }
    }
}