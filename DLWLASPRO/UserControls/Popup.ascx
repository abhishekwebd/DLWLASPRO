<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Popup.ascx.cs" Inherits="DLWLASPRO.UserControls.Popup" %>
<asp:Panel ID="Panel1" runat="server" Visible="false">


<style>
    .modal
    {
        top:40%;
    }
</style>
<script type="text/javascript">
    $(window).on('load', function () {
        $('#exampleModal').modal('show');
    });
</script>
<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel" style="color:green;" runat="server" visible="false"><i class="fa-check fa"></i> Success</h5>
        <h5 class="modal-title" id="exampleModalLabel2" style="color:red;" runat="server" visible="false"><i class="fa-ban  fa"></i> Failure</h5>
        <h5 class="modal-title" id="exampleModalLabel3" style="color:orange;" runat="server" visible="false"><i class="fa-warning  fa"></i> Warning</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <asp:Label runat="server" ID="txtalert"  Font-Size="Large" CssClass="text-green"></asp:Label>
          <br /><br /><br />
      </div>
  <%--    <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>--%>
    </div>
  </div>
</div>

    </asp:Panel>