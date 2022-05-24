<%@ Page Language="C#" AutoEventWireup="true" Inherits="_default" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="default.aspx.cs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-lg animate__animated animate__fadeIn">

    <div class="row" style="margin-top:-20px;">
        
    <!--
        <div class="col-sm-3">
        
                <div runat="server" id="divIsOnlineLeft"  class="customJumbotron col-md-12 d-block d-sm-none">
                    <p>
                          <a runat="server" id="linkNewGameLeft" class="btn btn-warning btn-block" href="~/Core/Games/gameNew.aspx">Crea una nuova partita</a>
                    </p>
                    <p runat="server" id="linkMyGamesLeft">
                        <a runat="server" id="A4" class="btn btn-warning btn-block" href="~/Core/Games/mygames.aspx">Le tue partite</a>
                    </p>
                </div>

                <div runat="server" id="div2" class="customJumbotron col-md-12 d-none d-lg-block">
                    <h2>Regolamento</h2>
                    <p>
                        Cos'è un punto esperienza? E una indole? Le comunità quanti personaggi principali possono avere? Controlla!
                    </p>
                    <p>
                    <a runat="server" id="A2" class="btn btn-dark btn-block" href="~/regulation.aspx">Regolamento</a>
                    </p>
                </div>

                <div runat="server" id="div3"  class="customJumbotron col-md-12 d-none d-lg-block">
                    <h2>Cos'è Ischidados GdR?</h2>
                    <p>
                        Scopri com'è nato Ischidados GdR!
                    </p>
                    <p>
                    <a runat="server" id="A1" class="btn btn-dark btn-block" href="~/about.aspx">Cos'è Ischidados GdR?</a>
                    </p>
                </div>
        
        </div>
        -->

        <div class="col-md-8">
    <div runat="server" id="divImgDefault" class="customJumbotron">
        <center>
            <h2 runat="server" id="divWelcomeH1"></h2>
            <h4 runat="server" id="divWelcomeH2">Il primo gdr zombie ambientato in Sardegna</h4>
        <asp:Image runat="server" ID="imgDefault" CssClass="img-fluid rounded5" />
            <h5 runat="server" id="divMarketingH3">Scegli i tuoi personaggi, crea la tua comunità, alleati o sottomettiti, fino a ricreare la civiltà!</h5>
        </center>
    </div>
        </div>

        <div class="col-md-4" >
        <center><h3 class="customJumbotron d-md-none" runat="server" id="divWelcomeResponsive" style="margin-bottom:30px; margin-top:10px;"></h3></center>

                <div runat="server" id="divIsOnlineRight"  class="customJumbotron">
                    <center>
                            <h5 class="card-title">Pannello personale</h5>
                    </center>
                    <p>
        <asp:LinkButton  CssClass="colorwarningNotRead btn btn-warning btn-block  animate__animated  animate__flash"  runat="server" ID="btnNewMessage" OnCommand="ProcessCommand" CommandName="message" Text="Hai dei nuovi messaggi!" Visible="false"/>
                    </p>
                    <p>
                          <a runat="server" id="linkNewGameRight" class="btn btn-warning btn-block shadow-lg " href="~/Core/Games/gameNew.aspx">Crea una nuova partita</a>
                    </p>
                    <p runat="server" id="linkMyGamesRight">
                        <a runat="server" id="linkMyGames2" class="btn btn-warning btn-block shadow-lg " href="~/Core/Games/mygames.aspx">Le tue partite</a>
                    </p>
                    <p runat="server" id="linkMyProfile">
                        <a runat="server" id="linkMyProfile2" class="btn btn-warning btn-block shadow-lg " href="~/Core/Users/profile.aspx">Il tuo profilo</a>
                    </p>
                </div>

<div runat="server" id="divStatistic" class="customJumbotron card" >
    <center>
     <h5 class="card-title">Pannello globale</h5>
    </center>
      <p class="">
    <a runat="server" id="linkRegulation" href="~/Regulation.aspx" class="btn btn-warning btn-block shadow-lg">Regolamento</a>
  </p>

  <p runat="server" id="divGameList" class="">
    <a runat="server" id="linkGameList" href="~/Core/Games/gamesList.aspx" class="btn btn-warning btn-block shadow-lg">Partite in corso</a>
  </p>

  <p runat="server" id="divForum" class="">
    <a runat="server" id="linkForum" href="~/Core/Forum/forum.aspx" class="btn btn-warning btn-block shadow-lg">Forum</a>
  </p>

  <p class="">
    <a runat="server" id="linkUserLIst" href="~/Core/Users/usersList.aspx" class="btn btn-warning btn-block shadow-lg">Giocatori presenti</a>
  </p>

</div>

    <div runat="server" id="div1" class="customJumbotron card" style="margin-top:-2px;">
    <h5 class="card-title">Visita BoPItalia!</h5>
    <p class="card-text">Vai alla community italiana degli amanti dei giochi Paradox!</p>
    <a href="https://bopitalia.org/" class="btn btn-warning btn-block shadow-lg">Vai a BoPItalia</a>
  </div>
</div>

                

                
        </div>
    <!-- <div class="customJumbotron row">
        <div class="col-md-4">
            <h2>Primo titolo</h2>
            <p>
                Prima descrizione
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Primo pulsante &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Secondo titolo</h2>
            <p>
                Seconda descrizione
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Secondo pulsante &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Terzo titolo</h2>
            <p>
                Terza descrizione
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Terzo pulsante &raquo;</a>
            </p>
        </div>
    </div> -->
    </div>


        </div>
</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
 

</asp:Content>
