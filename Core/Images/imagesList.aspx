<%@ Page Language="C#" AutoEventWireup="true" Inherits="imagesList" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="imagesList.aspx.cs" %>

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
        <asp:DropDownList id="ddType"  runat="server" class="form-control chosen-select">
            <asp:ListItem Selected="True" Value="0"> Tutte </asp:ListItem>
            <asp:ListItem Value="Avatar"> Avatar </asp:ListItem>
            <asp:ListItem Value="Comunità"> Comunità </asp:ListItem>
            <asp:ListItem Value="Icone"> Icone </asp:ListItem>
            <asp:ListItem Value="Immagini di copertina"> Immagini di copertina </asp:ListItem>
            <asp:ListItem Value="Insediamenti"> Insediamenti </asp:ListItem>
            <asp:ListItem Value="Personaggi"> Personaggi </asp:ListItem>
            <asp:ListItem Value="Segnali stradali"> Segnali stradali </asp:ListItem>
            <asp:ListItem Value="Zombie"> Zombie </asp:ListItem>

        </asp:DropDownList>
    </div>  <br /><br />
    <div class="col-lg-2">
            <asp:Button ID="btnSearch" runat="server" OnCommand="ProcessCommand" CommandName="LoadTable" Text="Esegui" CssClass="btn btn-dark btn-block" />
    </div>
</div>  
</div>

<div class="animate__animated animate__headShake">
    <div class="row">
<asp:Repeater ID="repPeople" runat="server" >
    <ItemTemplate>
        <div class="col-xl-2 col-lg-3 col-md-4 col-sm-12 divFather" runat="server" id="divImg">
            <asp:LinkButton runat="server" ID="linkImage" OnCommand="ProcessCommand" CommandName="linkImage" />
            <asp:HiddenField ID="hidI_image_id" runat="server" Value='<%#Eval("i_image_id") %>' />
            <asp:HiddenField ID="hidT_tag" runat="server" Value='<%#Eval("t_tag") %>' />
            <asp:HiddenField ID="hidT_sex" runat="server" Value='<%#Eval("t_sex") %>' />
            <asp:HiddenField ID="hidT_uploadedBy" runat="server" Value='<%#Eval("t_uploadedBy") %>' />
            <img src='<%# Eval("t_url") %>' runat="server" class="imgListed animate__animated"/>
            </div>
    </ItemTemplate>
</asp:Repeater>
    </div>
</div>

<%--<asp:Image ImageUrl='<%# "https://www.ischidados.it/assets/" + Eval("t_url") %>' runat="server" Height="180" Width="180" />
<br />
<asp:Label ID="t_uploadedByLabel" runat="server" Text='<%# Eval("t_uploadedBy") %>' />--%>

               



            </div>
         </div>
     </div>


</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

</asp:Content>
