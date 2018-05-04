<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DLWLASPRO.Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/UserControls/ABRack_Mgmt.ascx" TagPrefix="uc1" TagName="ABRack_Mgmt" %>
<%@ Register Src="~/UserControls/CAB_Mgmt.ascx" TagPrefix="uc1" TagName="CAB_Mgmt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

  
       <div class="col-xs-12 col-sm-9 content">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar">
                    <span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a>
                  <ul class="list-inline pull-right">
                        <li  style="font-weight:bold;color:darkblue;">Diesel = <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></li>
                        <li  style="font-weight:bold;color:#6d2727;">Electric = <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label></li>
                    </ul>
                       <i class="glyphicon glyphicon-home"></i> Dashboard 
                   
                </h3>
              </div>
              <div class="panel-body">
                <div class="content-row">
                  <h2 class="content-row-title">Loco Management</h2>
                  <div class="row">
                  
                    <div class="col-md-6">
                      <div class="panel-group panel-group-lists" id="accordion2">

                          <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="Code">
                              <ItemTemplate>
                           <div class="panel">
                          <div class="panel-heading">
                            <h4 class="panel-title">
                              <a data-toggle="collapse" style="font-size:large;color:darkblue;font-weight:bold;" data-parent="#accordion2" href="#<%# Eval("Code") %>"><i class="fa fa-plus-square-o"></i> <%# Eval("LocoNo") %></a>
                             <medium class="pull-right">Create Date : <%# Eval("CreateDate") %></medium>
                            </h4>
                             
                          </div>
                          <div id="<%# Eval("Code") %>" class="panel-collapse collapse ">
                            <div class="panel-body">
                             
                                <asp:DataList ID="DataList2" runat="server">
                                    <ItemTemplate>
                                       
                                       <b style="font-size:large;">
                                             <a href="dashboard.aspx?LocoNo=<%# Eval("LocoNo") %>&Code=<%# Eval("code") %>"> <%# Eval("Head") %></a>
                                       </b>
                                        <br />
                                    </ItemTemplate>
                                </asp:DataList>
                             
                             </div>
                          </div>
                        </div>
                                  </ItemTemplate>
                          </asp:DataList>
                 
                     
                      </div>
                    </div>

                          <div class="col-md-6 text-center">
                              <asp:Label runat="server" ID="lblLocono2" Font-Bold="true" Font-Size="Large" ></asp:Label>
                              <uc1:ABRack_Mgmt runat="server" id="ABRack_Mgmt" Visible="false" />
                              <uc1:CAB_Mgmt runat="server" ID="CAB_Mgmt" Visible="false" />
                        </div>
                  </div>
                </div>
             
            
                    </div>
                  </div>
                </div>
      
   <script>
       $("#leftsidebar").addClass("active");
   </script>
</asp:Content>
