<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PermissionMaster.aspx.cs" Inherits="DLWLASPRO.PermissionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 col-sm-9 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar">
                    <span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a>Permission Master</h3>
            </div>
            <div class="panel-body">
                <div class="content-row">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <b>Create Form</b>
                            </div>
                            <div class="panel-options">
                                <a class="bg" data-target="#sample-modal-dialog-1" data-toggle="modal" href="#sample-modal"><i class="entypo-cog"></i></a>
                                <a data-rel="collapse" href="#"><i class="entypo-down-open"></i></a>
                                <a data-rel="close" href="#!/tasks" ui-sref="Tasks"><i class="entypo-cancel"></i></a>
                            </div>
                        </div>
                        <div class="panel-body">
                            <form role="form">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Module Name</label>
                                    <input type="text" class="form-control" id="txtModulename" runat="server" placeholder="Enter Module Name">
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Category</label>
                                    <input type="text" class="form-control" id="txtcategory" runat="server" placeholder="Category" />
                                </div>
                                <button type="submit" class="btn btn-info" runat="server" onserverclick="btnSubmit_ServerClick" id="btnSubmit">Submit</button>
                                <br />
                                <asp:Label ID="txtalert" runat="server"></asp:Label>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="content-row">
                    <div class="panel panel-default">
                        <asp:GridView ID="grdPermissionMaster" CssClass="table table-hover" OnRowEditing="grdPermissionMaster_RowEditing"  runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Srno" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Module Name" DataField="Modulename" HeaderStyle-CssClass="text-center" />
                                <asp:BoundField HeaderText="Category" DataField="Categoryame" HeaderStyle-CssClass="text-center" />
                                <asp:TemplateField HeaderText="Deactive" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="Code" Value='<%# Eval("Code")%>' />
                                        <asp:CheckBox ID="chkDeactive" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsDeactive"))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Control System" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" Text="Update/Delete" runat="server" CommandName="Edit" CssClass="btn btn-warning" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" Text="Update" OnClick="OnUpdate" runat="server" CssClass="btn btn-success" />
                                        <asp:LinkButton ID="LinkButton3" Text="Cancel" OnClick="OnCancel" runat="server" CssClass="btn btn-danger " />
                                        <asp:LinkButton ID="LinkButton4" Text="Delete" OnClick="OnDelete" runat="server" CssClass="btn btn-danger " />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- content -->

</asp:Content>
