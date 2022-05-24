<%@ Page Language="C#" AutoEventWireup="true" Inherits="working" MasterPageFile="~/Masterpage.master" EnableViewStateMac="false"  Codebehind="working.aspx.cs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container animate__animated  animate__wobble">
    <div class="row">
    <div  class="col-lg-4"></div>
        <div  class="col-lg-4 divFather">
        <img class="img-fluid" runat="server" id="imgDefault" src="https://i.pinimg.com/236x/c3/c5/53/c3c5539dfd1a0a2d1fb7561699f942b8--funny-things-funny-stuff.jpg" alt="Error img" />
            </div>
    <div  class="col-lg-4"></div>
        </div>
</div>
</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

</asp:Content>
