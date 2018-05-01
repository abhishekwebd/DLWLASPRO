<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateAdmin.ascx.cs" Inherits="DLWLASPRO.UserControls.CreateAdmin" %>


  <div class="content-row">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <b>Create Admin</b>
                                <asp:Label ID="Label1" runat="server" CssClass="pull-right"></asp:Label>
                            </div>

                            <div class="panel-options">
                                <a class="bg" data-target="#sample-modal-dialog-1" data-toggle="modal" href="#sample-modal"><i class="entypo-cog"></i></a>
                                <a data-rel="collapse" href="#"><i class="entypo-down-open"></i></a>
                                <a data-rel="close" href="#!/tasks" ui-sref="Tasks"><i class="entypo-cancel"></i></a>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div role="form">
                                <div class="form-group ">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">Full Name</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="imgPopup"><i class="fa fa-pencil"></i></span>
                                                <asp:TextBox ID="txtFullName" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="row">
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
                                        <div class="col-md-6 pull-right">
                                            <div class="row">
                                                <div class="col-md-4 pull-left">
                                                    <label for="exampleInputEmail1">Password</label>
                                                </div>
                                                <div class="col-md-8 pull-right">
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
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
                                                    <label for="exampleInputEmail1">Employee  No</label>
                                                </div>
                                                <div class="col-md-8 pull-right">
                                                    <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control" placeholder="Employee No"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 pull-right">
                                            <div class="row">
                                                <div class="col-md-4 pull-left">
                                                    <label for="exampleInputEmail1">Select Shop</label>
                                                </div>
                                                <div class="col-md-8 pull-right">
                                                    <asp:DropDownList ID="ddlShop" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                  
                                
                                   <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6 pull-left">
                                            <asp:CheckBox ID="chkCanCreateAdmin" CssClass="checkbox" Text="Can Create Admin" runat="server" />
                                        </div>
                                        <div class="col-md-6 pull-right">
                                        
                                             <button type="submit" class="btn btn-primary pull-right" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick">Save</button>
                               
                                        </div>

                                    </div>

                                </div>
                               


                                <br />
                                <asp:Label ID="txtalert" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>