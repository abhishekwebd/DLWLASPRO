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
    public partial class CreateLoco : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initialise();
            }
        }

        private void Initialise()
        {

            ddlLocoType.DataSource = getMasterRecords.GetLocoType("IsDeactive = 0 and");
            ddlLocoType.Items.Insert(0, new ListItem("--Select Loco Type--", ""));
            ddlLocoType.DataTextField = "Name";
            ddlLocoType.DataValueField = "Code";
            ddlLocoType.DataBind();

            ddlEngineType.DataSource = getMasterRecords.GetEngineMaster("IsDeactive = 0 and");
            ddlEngineType.Items.Insert(0, new ListItem("--Select Engine Type--", ""));
            ddlEngineType.DataTextField = "Name";
            ddlEngineType.DataValueField = "Code";
            ddlEngineType.DataBind();

            ddlToShop.DataSource = getMasterRecords.GetShopMaster("IsDeactive = 0 and");
            ddlToShop.DataTextField = "Name";
            ddlToShop.DataValueField = "Code";
            ddlToShop.DataBind();

            ddlFromShop.DataSource = getMasterRecords.GetShopMaster("IsDeactive = 0 and");
            ddlFromShop.DataTextField = "Name";
            ddlFromShop.DataValueField = "Code";
            ddlFromShop.DataBind();
            ddlFromShop.SelectedValue = "4";
            ddlFromShop.Enabled = false;

            chkAcSystemList.DataSource = getMasterRecords.GetACSystem("IsDeactive = 0 and");
            chkAcSystemList.DataTextField = "Name";
            chkAcSystemList.DataValueField = "Code";
            chkAcSystemList.DataBind();
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtDLWSrno.Value.Trim() != "" && txtHP.Value.Trim() != "" && ddlLocoCategory.SelectedValue != "")
                {
                    string AcSystems = "";
                    string LocoNo = ddlLocoType.SelectedItem.Text.ToString() + " - " + txtDLWSrno.Value + " " + ddlEngineType.SelectedItem.Text.ToString();
                    if (chkAcSystemList.Items.Cast<ListItem>().Count(li => li.Selected) > 0)
                    {
                        LocoNo += " (";
                        foreach (ListItem item in chkAcSystemList.Items)
                        {
                            if (item.Selected && item.Value != "0")
                            {
                                AcSystems += item.Value + "|";
                                LocoNo += item.Text + ",";
                            }
                        }
                        LocoNo = LocoNo.Remove(LocoNo.Length - 1);
                        LocoNo += ")";
                        AcSystems = AcSystems.Remove(AcSystems.Length - 1);
                    }

                    Fn_CreateLoco(LocoNo, AcSystems);
                }
                else {
                    Label1.Text = "All Fields are Mendatory !";
                }
            }
            catch (Exception ex) { Label1.Text = ex.Message; }
        }

        private void Fn_CreateLoco(string LocoNo,string AcSystems)
        {
            EncDcr enc = new EncDcr();
            ds = SqlHelper.ExecuteDataset(dbConnect.getConstr(), "sp_LocoMaster", "I", txtLasInDate.Text, int.Parse(ddlFromShop.SelectedValue), int.Parse(ddlToShop.SelectedValue), int.Parse(ddlLocoCategory.SelectedValue), int.Parse(ddlLocoType.SelectedValue), txtDLWSrno.Value, int.Parse(ddlEngineType.SelectedValue), LocoNo, txtHP.Value, AcSystems, 0, 0, 0, 0, "Admin", enc.GetIPAddress(), enc.GetHostName());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = ds.Tables[0].Rows[0][1].ToString();
             
            }
        }
    }
}