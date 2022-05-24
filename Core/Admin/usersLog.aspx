<%@ Page Language="C#" AutoEventWireup="true" Inherits="usersLog" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="usersLog.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      
    <div class="container-lg">
        <div class="row">
            <div  class="col-lg-12">

<%--<asp:HiddenField ID="hidI_image_id" runat="server" Value='<%#Eval("i_image_id") %>' />
<asp:HiddenField ID="hidT_tag" runat="server" Value='<%#Eval("t_tag") %>' />
<asp:HiddenField ID="hidT_sex" runat="server" Value='<%#Eval("t_sex") %>' />--%>

<div class="form-group customJumbotron">                          
<div class="row">
    <div class="col-lg-4">
        <asp:Literal runat="server" id="ltlCounter"/>
    </div>
    <div class="col-lg-4">
        <asp:Literal runat="server" id="ltlType"/>
    </div>
    <div class="col-lg-2">
        <asp:DropDownList id="ddUsers"  runat="server" class="form-control chosen-select">
        </asp:DropDownList>
    </div>  <br /><br />
    <div class="col-lg-2">
            <asp:Button ID="btnSearch" runat="server" OnCommand="ProcessCommand" CommandName="LoadTable" Text="Cerca" CssClass="btn btn-dark btn-block" />
    </div>
</div>  
</div>

<div class="col-lg-12 animate__animated animate__headShake ">
        <asp:GridView ID="Gv" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" data-placeholder="Scegli ..." AllowPaging="false" PageSize="20" OnPageIndexChanging="Gv_PageIndexChanging" ClientIDMode="Static">
            <Columns>
<asp:BoundField DataField="i_user_id" HeaderText="Id" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="t_user" HeaderText="User" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="t_page" HeaderText="Pagina Visitata" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="d_date" HeaderText="Data" ItemStyle-HorizontalAlign="Left"  />
            </Columns>
        </asp:GridView>
</div>
            </div>
         </div>
     </div>

</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">


     <script type="text/javascript">
         $(document).ready(function () {
             $('[id*=Gv]').DataTable({
                 responsive: true,
                 "pageLength": 50,
                 "order": [[3, "d_data"]],
                 "language": {
                     "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Italian.json"
                 }
             });
         });





     </script>

</asp:Content>