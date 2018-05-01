<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateLoco.aspx.cs" Inherits="DLWLASPRO.CreateLoco" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/angular.min.js"></script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="col-xs-12 col-sm-9 content" ng-app="">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar">
                    <span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a>
                   <i class="fa fa-train"></i> Create Loco</h3>
            </div>
            <div class="panel-body">

                <div class="content-row">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <b>Create Form</b>
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
                                            <label for="exampleInputEmail1">In Date</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <div class="input-group">
                                                <asp:CalendarExtender ID="CalendarExtender1" CssClass="calendar" TargetControlID="txtLasInDate" Format="dd/MM/yyyy" PopupButtonID="txtLasInDate" Enabled="True" runat="server"></asp:CalendarExtender>
                                                <asp:TextBox ID="txtLasInDate" class="form-control" runat="server"></asp:TextBox>

                                                <span class="input-group-addon" id="imgPopup"><i class="fa fa-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6 pull-left">
                                            <div class="row">
                                                <div class="col-md-4 pull-left">
                                                    <label for="exampleInputEmail1">From Shop</label>
                                                </div>
                                                <div class="col-md-8 pull-right">
                                                    <asp:DropDownList ID="ddlFromShop" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 pull-right">
                                            <div class="row">
                                                <div class="col-md-3 pull-left">
                                                    <label for="exampleInputEmail1">To Shop</label>
                                                </div>
                                                <div class="col-md-9 pull-right">
                                                    <asp:DropDownList ID="ddlToShop" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">Select Loco Category</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <asp:DropDownList ID="ddlLocoCategory" CssClass="form-control" runat="server">
                                                <asp:ListItem disabled Selected="True">Select Loco Category</asp:ListItem>
                                                <asp:ListItem Value="0">Diesel</asp:ListItem>
                                                <asp:ListItem Value="1">Electric</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">Select Loco Type</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <asp:DropDownList ID="ddlLocoType" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">DLW Serial No</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <input type="text" class="form-control" id="txtDLWSrno" runat="server" placeholder="XXXXXXXXXXXXXXXX">
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">Select Engine Type</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <asp:DropDownList ID="ddlEngineType" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">Select AC System</label>
                                        </div>
                                        <div class="col-md-10 pull-right" onmouseover="getAcSystem()">
                                            <asp:CheckBoxList ID="chkAcSystemList" RepeatDirection="Horizontal" CssClass="checkbox" runat="server">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 pull-left">
                                            <label for="exampleInputEmail1">HP</label>
                                        </div>
                                        <div class="col-md-10 pull-right">
                                            <input type="text" class="form-control" id="txtHP" runat="server" placeholder="XXXXXXXXXXXXXXXX">
                                        </div>
                                    </div>
                                </div>


                                <h4><span id="locotype"></span><span id="dlwsrno"></span><span id="engine"></span><span id="acsystem"></span></h4>

                                <button type="submit" class="btn btn-success pull-right" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick">Create</button>
                                <br />
                                <asp:Label ID="txtalert" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- content -->
    <script>
     
        $("#<%=ddlLocoType.ClientID %>").change(function () {
            document.getElementById("locotype").innerText = $('#<%=ddlLocoType.ClientID %> option:selected').text();
        });
        $("#<%=txtDLWSrno.ClientID %>").on("blur", function () {
            document.getElementById("dlwsrno").innerText = " - " + $("#<%=txtDLWSrno.ClientID %>").val();
        });
        $("#<%=ddlEngineType.ClientID %>").change(function () {
            document.getElementById("engine").innerText = " " + $('#<%=ddlEngineType.ClientID %> option:selected').text();
        });


        function getAcSystem() {

            var checked_checkboxes = $("[id*=chkAcSystemList] input:checked");

            var message = "(";
            checked_checkboxes.each(function () {
                var value = $(this).val();
                var text = $(this).closest("td").find("label").html();
                message += text + ",";

            });
            message = message.slice(0, -1);
            message += ")";
            if (checked_checkboxes.length == 0) { message = ""; }
            document.getElementById("acsystem").innerText = message;

        }

       
    </script>
</asp:Content>
