<%@ Page Language="C#" AutoEventWireup="true" Inherits="myGames" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="myGames.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidGameUnsub" />
  
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
        <p>Vuoi davvero disiscriverti da questa partita?</p>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancella</button>
<asp:Button ID="btnRemovePlayerLast" runat="server"  OnCommand="ProcessCommand" CommandName="removePlayer" Text="Disiscriviti"  CssClass="btn btn-danger"/>
      </div>
    </div>
  </div>
</div>

    <div class="container-lg animate__animated animate__fadeIn">
        <div class="row">
            <div class="col-lg-3"></div>
            <div runat="server" id="divNewGame" class="col-lg-3">
                <div class="text-center"  style="margin-bottom:10px">
                    <asp:Button ID="btnNewGame" runat="server" OnCommand="ProcessCommand" CommandName="newGame" Text="Nuova partita" CssClass="btn btn-warning btn-block shadow-lg" />  
                </div>
            </div>
            <div runat="server" id="div1" class="col-lg-3">
                <div class="text-center"  style="margin-bottom:10px">
                    <a runat="server" id="linkGameList" href="~/Core/Games/gamesList.aspx" class="btn btn-warning btn-block shadow-lg">Partite in corso</a>
                </div>
            </div>
            <div class="col-lg-3"></div>
        </div>
        </div>         
<div class="container-lg animate__animated animate__zoomIn">
        <!-- Games as admin -->
        <div class="row" runat="server" id="divAsAdmin">
            <div  class="col-lg-3"></div>
            <div  class="col-lg-6">
                            <div class="panel panel-success" runat="server" >
                                <div class="panel-body scroll-x" >
                                    
        <asp:GridView ID="GvAdmin" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" 
                                    AllowPaging="true" PageSize="20" 
                                        BorderWidth="0" OnRowCommand="GVAdmin_RowCommand">
                                             <Columns>
<asp:TemplateField HeaderText="Partite come master" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
<ItemTemplate>
    <a href="game.aspx?id=<%# Eval("i_game_id") %>" class="" style="text-decoration: none; color:#ffffff80;">
             <center>   <asp:Image ImageUrl='<%# "https://www.ischidados.it" + Eval("t_img") %>' runat="server" Width="500" class="img-fluid" />
        <h1><%# Eval("t_name") %></h1>
        <h3>Turno <%# Eval("turno attuale") %></h3>
        <p><%# Eval("t_desc") %></p>
            </center>
    </a>
    <center>
                <asp:Button ID="btnManageGame" runat="server" CommandName="manageGame"
                    Text="Gestisci" CommandArgument='<%# Eval("i_game_id") %>' CssClass="btn btn-warning btn-block"/>
</center>
</ItemTemplate>                          
</asp:TemplateField>
           
                            </Columns>
                                    </asp:GridView>

                                </div>
                            </div>

            </div>
            <div  class="col-lg-3"></div>
         </div>

        <!-- Games as player -->
        <div class="row" runat="server" id="divAsPlayer">
            <div  class="col-lg-3"></div>
            <div  class="col-lg-6">
                            <div class="panel panel-success" runat="server" >
                                <div class="panel-body scroll-x" >
<asp:GridView ID="GvPlayer" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" BorderWidth="0" OnRowCommand="GVPlayer_RowCommand">
                                             <Columns>
<asp:TemplateField HeaderText="Partite come giocatore" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
<ItemTemplate>
    <a href="game.aspx?id=<%# Eval("i_game_id") %>" class="" style="text-decoration: none; color:#ffffff80;">
             <center>   <asp:Image ImageUrl='<%# "https://www.ischidados.it" + Eval("t_img") %>' runat="server" Width="500" class="img-fluid" />
        <h1><%# Eval("t_name") %></h1>
        <h3>Master: <%# Eval("master") %></h3>
        <h3>Turno <%# Eval("turno attuale") %></h3>
        <p><%# Eval("t_desc") %></p>
            </center>
    </a>
    <center>
<asp:Button ID="btnObserve" runat="server" CommandName="observe" Text="Entra" CommandArgument='<%# Eval("i_game_id") %>' CssClass="btn btn-warning btn-block"/><br>
                    <div runat="server" id="btnRemovePlayer" > 
                <button type="button" class="btn btn-danger btn-block" data-toggle="modal" data-target="#exampleModal" onclick="unsub(<%# Eval("i_game_id") %>)">
                  Disiscriviti
                </button>
                    </div>  
</center>
</ItemTemplate>                          
</asp:TemplateField>
           
                            </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

            </div>
            <div  class="col-lg-3"></div>
         </div>
     </div>


</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

        <script>

        function unsub(id) {
            $('#<%= hidGameUnsub.ClientID %>').val(id);
        }
        
        </script>
</asp:Content>
