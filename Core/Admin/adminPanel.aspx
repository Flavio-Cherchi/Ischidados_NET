<%@ Page Language="C#" AutoEventWireup="true" Inherits="adminPanel" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false" CodeBehind="adminPanel.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-lg animate__animated animate__fadeIn">
        <div class="wrapper wrapper_content">
            <div class="row">
                <asp:Panel class="alert alert-danger alert-dismissabl text-center " runat="server" Visible="false" ID="divmessaggiopopup">
                    <asp:Label ID="lblmessaggiopopup" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="wrapper wrapper-content">
                        <div class="customBox">
                            <div class="customBox-content">

                                <div class="row">
                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="testCharacters" runat="server" OnCommand="ProcessCommand" CommandName="testCharacters" Text="Personaggi - test" CssClass="btn btn-light btn-block" />

                                    </div>

                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="btnUsersLog" runat="server" OnCommand="ProcessCommand" CommandName="usersLog" Text="Log utenti" CssClass="btn btn-light btn-block" />

                                    </div>
           <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="btnCommunity" runat="server" OnCommand="ProcessCommand" CommandName="community" Text="Comunità" CssClass="btn btn-success btn-block" />

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="btnNatures" runat="server" OnCommand="ProcessCommand" CommandName="natures" Text="Indoli, abilità e tratti" CssClass="btn btn-warning btn-block" />
                                    </div>

                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="btnTest" runat="server" OnCommand="ProcessCommand" CommandName="test" Text="Pagina di testing" CssClass="btn btn-secondary btn-block" />
                                    </div>

                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="btnGames" runat="server" OnCommand="ProcessCommand" CommandName="games" Text="Gestione partite" CssClass="btn btn-danger btn-block" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="btnCharacters" runat="server" OnCommand="ProcessCommand" CommandName="characters" Text="Personaggi" CssClass="btn btn-info btn-block" />
                                    </div>

                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <asp:Button ID="BtnImages" runat="server" OnCommand="ProcessCommand" CommandName="images" Text="Immagini" CssClass="btn btn-success btn-block" />
                                    </div>

                                    <div class="col-lg-3 text-center" style="margin-bottom: 10px">
                                        <a runat="server" id="linkRegulation123" class="btn btn-block btn-dark" href="~/test/testAnello.html">Test su anello</a>
                                    </div>

                                </div>




                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
</asp:Content>
