<%@ Page Language="C#" AutoEventWireup="true" Inherits="error" MasterPageFile="~/Masterpage.master" EnableViewStateMac="false"  Codebehind="error.aspx.cs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-lg animate__animated  animate__wobble">
        <div class="row">
    <div  class="col-lg-4"></div>
        <div  class="col-lg-4 divFather">
        <img class="img-fluid" runat="server" id="imgDefault" src="/Assets/img/infrastructure/error.jpg" alt="Error img" />
            </div>
    <div  class="col-lg-4"></div>
        </div>
</div>
</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

</asp:Content>

