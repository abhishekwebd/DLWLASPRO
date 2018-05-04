<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ABRack_Mgmt.ascx.cs" Inherits="DLWLASPRO.UserControls.ABRack_Mgmt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<div class="col-xs-12 col-sm-9 content">
    <div class="panel panel-default">
        <%--<div class="panel-heading">
            <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar"><span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel"></span></a><i class="glyphicon glyphicon-list-alt"></i>Shop Master</h3>
        </div>--%>
         
        <div class="panel-body" style="padding:0px;">
            <div class="content-row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="panel-title">
                        AB Rack

                                
                           
                        </div>
                        <div class="panel-options">
                            <a class="bg" data-target="#sample-modal-dialog-1" data-toggle="modal" href="#sample-modal"><i class="entypo-cog"></i></a>
                            <a data-rel="collapse" href="#"><i class="entypo-down-open"></i></a>
                            <a data-rel="close" href="#!/tasks" ui-sref="Tasks"><i class="entypo-cancel"></i></a>
                        </div>
                    </div>

                    <div class="panel-body" >
                        <form role="form">
                               <div class="form-group">
                                <label for="exampleInputEmail1">Date of Fitment</label>
                                   <div class="input-group">
                                       <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateofFitment" CssClass="calendar"  Format="dd/MM/yyyy" PopupButtonID="txtDateofFitment" Enabled="True"></asp:CalendarExtender>
                                                <asp:TextBox ID="txtDateofFitment" class="form-control" runat="server"></asp:TextBox>

                                                <span class="input-group-addon" id="imgPopup"><i class="fa fa-calendar"></i></span>
                                            </div>

                            </div>
                                 <div class="form-group">
                                <label for="exampleInputPassword1">Make</label>
                                <input type="text" class="form-control" id="txtShopNo" runat="server" placeholder="Make" />
                            </div>
                                <div class="form-group">
                                <label for="exampleInputPassword1">Serial No</label>
                                <input type="text" class="form-control" id="txtShortname" runat="server" placeholder="Serial No" />
                            </div>
                         
                        
                       
                            <div class="form-group">
                                <label for="exampleInputPassword1">Secton</label>
                                <asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                             <div class="form-group">
                                <label for="exampleInputPassword1">Remark Shortage</label>
                                <input type="text" class="form-control" id="Text2" runat="server" placeholder="Remark" />
                            </div>
                            <button type="submit" class="btn btn-info" runat="server" id="btnSubmit">Save</button>
                            <br />
                            <asp:Label ID="txtalert" runat="server"></asp:Label>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
