<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateOperator.ascx.cs" Inherits="DLWLASPRO.UserControls.CreateOperator" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="content-row">

    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-title">
                <b>Create Operator</b>
                <asp:Label ID="Label1" runat="server" CssClass="pull-right"></asp:Label>
            </div>

            <div class="panel-options">
                <a class="bg" data-target="#sample-modal-dialog-1" data-toggle="modal" href="#sample-modal"><i class="entypo-cog"></i></a>
                <a data-rel="collapse" href="#"><i class="entypo-down-open"></i></a>
                <a data-rel="close" href="#!/tasks" ui-sref="Tasks"><i class="entypo-cancel"></i></a>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="panel-body">
            <div role="form">
                <div class="form-group ">
                    <div class="row">
                          <div class="col-md-6 pull-left">
                            <div class="row">
                        <div class="col-md-4 pull-left">
                            <label for="exampleInputEmail1">Full Name</label>
                        </div>
                        <div class="col-md-8 pull-right">
                          
                                <asp:TextBox ID="txtFullName" class="form-control" runat="server"></asp:TextBox>
                        
                        </div>
                                </div></div>
                        
                           <div class="col-md-6 pull-left">
                            <div class="row">
                                <div class="col-md-4 pull-left">
                                    <label for="exampleInputEmail1">Username</label>
                                </div>
                                <div class="col-md-8 pull-right">
                                    <asp:TextBox ID="txtUsername" placeholder="Username" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>



                <div class="form-group">
                    <div class="row">
                        <div class="col-md-6 pull-left">
                            <div class="row">
                                <div class="col-md-4 pull-left">
                                    <label for="exampleInputEmail1">Password</label>
                                </div>
                                <div class="col-md-8 pull-right">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 pull-left">
                                    <label for="exampleInputEmail1">Employee  No</label>
                                </div>
                                <div class="col-md-8 pull-right">
                                    <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" placeholder="Employee No"></asp:TextBox>
                                </div>
                            </div>
                                     <div class="row">
                                <div class="col-md-4 pull-left">
                                    <label for="exampleInputEmail1">Select Shop</label>
                                </div>
                                <div class="col-md-8 pull-right">
                                    <asp:DropDownList ID="ddlShop" OnSelectedIndexChanged="ddlShop_SelectedIndexChanged"  AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                   <asp:ListItem disabled>Select Shop </asp:ListItem>
                                         </asp:DropDownList>
                                </div>
                            </div>
                               <div class="row">
                                <div class="col-md-4 pull-left">
                                    <label for="exampleInputEmail1">Select Loco Category</label>
                                </div>
                                <div class="col-md-8 pull-right">
                             
                                    <asp:CheckBox ID="chkDiesel" runat="server" OnCheckedChanged="chkDiesel_CheckedChanged"  Text="Diesel"  AutoPostBack="true" CssClass="form-control " /> 
                                    <asp:CheckBox ID="chkElectric" runat="server"  OnCheckedChanged="chkElectric_CheckedChanged" AutoPostBack="true" Text="Electric" CssClass="form-control " /> 
                                </div>
                            </div>
                     

                                       <button type="submit" class="btn btn-primary pull-right" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick">Save</button>
                        </div>

                             <div class="col-md-6 ">
                            <div class="panel panel-default">
                        <div class="panel-heading">
                          <h3 class="panel-title">WorkFlow</h3>
                        </div>
                        <div class="panel-body">
                            <asp:CheckBoxList ID="chkWorkFlowList" runat="server" CssClass="checkbox"></asp:CheckBoxList>
                        </div>
                      </div>

                        </div>
                     
                    </div>
                </div>

                <br />
                <asp:Label ID="txtalert" runat="server"></asp:Label>
            </div>
        </div>
            </ContentTemplate>
            </asp:UpdatePanel>
    </div>

</div>
