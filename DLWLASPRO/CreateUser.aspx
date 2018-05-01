<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="DLWLASPRO.CreateUser" %>

<%@ Register Src="~/UserControls/CreateAdmin.ascx" TagPrefix="uc1" TagName="CreateAdmin" %>
<%@ Register Src="~/UserControls/CreateOperator.ascx" TagPrefix="uc1" TagName="CreateOperator" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 col-sm-9 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar">
                    <span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a>
                    <i class="fa fa-user"></i> Create User</h3>
            </div>
            <div class="panel-body">

              <div class="content-row">
                  <h2 class="content-row-title">Tabs</h2>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="panel">
                        <ul id="myTab1" class="nav nav-tabs nav-justified"> 
                            
                            <li class="alert active alert-info"><a href="#profile1" data-toggle="tab">Create Operator</a></li>
                        <li class=" alert alert-info"><a href="#home1" data-toggle="tab">Create Admin</a></li>
                         
                        </ul>
                        <div id="myTabContent" class="tab-content">
                          <div class="tab-pane fade" id="home1">
                           
                              <uc1:CreateAdmin runat="server" ID="CreateAdmin" />
                          </div>
                          <div class="tab-pane fade  active in" id="profile1">
                              <uc1:CreateOperator runat="server" id="CreateOperator" />
                               
                           </div>
                     
                        </div>
                      </div>
                    </div>
                
                  </div>
               
                </div>

            </div>
        </div>
    </div>
    <!-- content -->

</asp:Content>
