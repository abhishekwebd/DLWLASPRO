<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DLWLASPRO.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div class="col-xs-12 col-sm-9 content">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar"><span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a><i class="glyphicon glyphicon-home"></i> Dashboard</h3>
              </div>
              <div class="panel-body">
                <div class="content-row">
                  <h2 class="content-row-title">Loco Management</h2>
                  <div class="row">
                  
                    <div class="col-md-12">
                      <div class="panel-group panel-group-lists" id="accordion2">

                          <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="LocoCategory">
                              <ItemTemplate>
                           <div class="panel">
                          <div class="panel-heading">
                            <h4 class="panel-title">
                              <a data-toggle="collapse" style="font-size:large;color:darkblue;" data-parent="#accordion2" href="#<%# Eval("Code") %>"><i class="fa fa-plus-square-o"></i> <%# Eval("LocoNo") %></a>
                            </h4>
                          </div>
                          <div id="<%# Eval("Code") %>" class="panel-collapse collapse ">
                            <div class="panel-body">
                             
                                <asp:DataList ID="DataList2" runat="server">
                                    <ItemTemplate>
                                       
                                       <b style="font-size:large;">
                                           <asp:HyperLink ID="HyperLink1" NavigateUrl="#" runat="server"><%# Eval("Head") %></asp:HyperLink>
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
                  </div>
                </div>
             
            
                    </div>
                  </div>
                </div>
     
   
</asp:Content>
