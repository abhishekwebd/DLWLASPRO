<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WorkFlowMaster.aspx.cs" Inherits="DLWLASPRO.WorkFlowMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 col-sm-9 content">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar"><span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a>Work Flow Master</h3>
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
                            <div class="form-group">
                                <label for="exampleInputEmail1">Select Loco Category</label>
                                <asp:DropDownList ID="ddlLocoCategory" CssClass="form-control" runat="server">
                                    <asp:ListItem disabled Selected="True">--Select Loco Category--</asp:ListItem>
                                    <asp:ListItem Value="0">Diesel</asp:ListItem>
                                    <asp:ListItem Value="1">Electric</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Shop Name</label>
                                <asp:DropDownList ID="ddlShopName" AppendDataBoundItems="true" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="exampleInputPassword1">Serial Number</label>
                                <input type="text" class="form-control" id="txtSrno" runat="server" placeholder="Enter Serial Number" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Head Name</label>
                                <input type="text" class="form-control" id="txtHeadName" runat="server" placeholder="Enter Head Name" />
                            </div>

                            <div class="form-group">
                                <label for="exampleInputPassword1">Priority</label>
                                <input type="text" class="form-control" id="txtPriority" runat="server" placeholder="Enter Priority" />
                            </div>

                            <button type="submit" class="btn btn-info" onserverclick="btnSubmit_ServerClick" runat="server" id="btnSubmit">Submit</button>
                            <br />
                            <asp:Label ID="txtalert" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="content-row">
                    <div class="panel panel-default">
                        <asp:GridView ID="grdWorkFlow" CssClass="table table-hover" runat="server" OnRowDataBound="grdWorkFlow_RowDataBound" OnRowEditing="grdWorkFlow_RowEditing" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Srno" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Serial Number" DataField="srno" HeaderStyle-CssClass="text-center" />
                                <asp:BoundField HeaderText="Head Name" DataField="Head" HeaderStyle-CssClass="text-center" />
                                <asp:TemplateField HeaderText="ShopName" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lblShopCode" runat="server" Value='<%# Eval("ShopId") %>' />
                                        <asp:DropDownList ID="ddlShop" runat="server"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Priority" DataField="priority" HeaderStyle-CssClass="text-center" />
                                <asp:TemplateField HeaderText="LocoCategory" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="lblLocoCategory" Value='<%# Eval("LocoCategory")%>' />
                                        <asp:DropDownList ID="ddlLocoCategory" runat="server">
                                            <asp:ListItem Value="0">Diesel</asp:ListItem>
                                            <asp:ListItem Value="1">Electric</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deactive" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="Code" Value='<%# Eval("Code")%>' />
                                        <asp:CheckBox ID="chkDeactive" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsDeactive"))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Control System" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" Text="Update/Delete" runat="server" CommandName="Edit" CssClass="btn btn-warning " />
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
</asp:Content>
