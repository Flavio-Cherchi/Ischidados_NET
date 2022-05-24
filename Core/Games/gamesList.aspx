<%@ Page Language="C#" AutoEventWireup="true" Inherits="gamesList" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="gamesList.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidGameUnsub" />
    <asp:HiddenField runat="server" ID="hidGameDelete" />
    <asp:HiddenField runat="server" ID="hidGameAdd" />
      
<!--  Add request panel -->
<div class="modal fade" id="add" tabindex="-1" role="dialog" aria-labelledby="removeLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
          <p>Vuoi davvero iscriverti a questa partita?</p>
        <asp:label runat="server" id="lblAddPlayer"></asp:label>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancella</button>
                                      <asp:Button ID="btnAddPlayer2" runat="server" OnCommand="ProcessCommand" CommandName="addPlayer" CommandArgument='<%# Eval("i_game_id") %>' CssClass="btn btn-warning"/>
      </div>
    </div>
  </div>
</div>
<!--  End add request panel -->

<!--  Add requestAsk panel -->
<div class="modal fade" id="addRequest" tabindex="-1" role="dialog" aria-labelledby="removeLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
          <p>Vuoi davvero iscriverti a questa partita?</p>
        <asp:label runat="server" id="lblAddPlayerRequest"></asp:label>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancella</button>
                                      <asp:Button ID="btnAddPlayerRequest2" runat="server" OnCommand="ProcessCommand" CommandName="addPlayerRequest" CommandArgument='<%# Eval("i_game_id") %>' CssClass="btn btn-warning"/>
      </div>
    </div>
  </div>
</div>
<!--  End add request panel -->

<!--  Remove request panel -->
<div class="modal fade" id="remove" tabindex="-1" role="dialog" aria-labelledby="removeLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
        <p>Vuoi davvero disiscriverti da questa partita?</p>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancella</button>
                        <asp:Button ID="btnRemovePlayerLast" runat="server"  OnCommand="ProcessCommand" CommandName="removePlayer"
                    Text="Disiscriviti"  CssClass="btn btn-danger"/>
      </div>
    </div>
  </div>
</div>
<!--  End remove request panel -->

<!--  Admin delete request panel -->
<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="deleteLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
        <p>Vuoi davvero eliminare questa partita?</p>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancella</button>
                        <asp:Button ID="btnDeleteGameLast" runat="server"  OnCommand="ProcessCommand" CommandName="deleteGame"
                    Text="Elimina"  CssClass="btn btn-danger"/>
      </div>
    </div>
  </div>
</div>
<!--  End admin delete request panel -->


    <!--  Start page -->
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
                    <a runat="server" id="linkMyGames2" class="btn btn-warning btn-block shadow-lg " href="~/Core/Games/mygames.aspx">Le tue partite</a>
                </div>
            </div>
            <div class="col-lg-3"></div>
        </div>
       </div>    
    
<div class="container-lg animate__animated animate__fadeInUp">
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="row">
<asp:Repeater ID="rep" runat="server" OnItemCommand="Rep_RowCommand">
    <ItemTemplate>
        <div class="col-lg-12 animate__animated <%# Container.ItemIndex % 2 == 0 ? "animate__rotateInDownLeft" : "animate__rotateInDownRight" %>">
     <center>
        <div class="iconicGame">
            <div style="margin:10px;">
    <a href="game.aspx?id=<%# Eval("i_game_id") %>" class="" style="text-decoration: none; color:#ffffff80;">
             <center>   
                 
                 <asp:Image ImageUrl='<%# "https://www.ischidados.it" + Eval("t_img") %>' runat="server" class="img-fluid marginTop10" />

        <h3><%# Eval("t_name") %></h3>
        <h5 id="hType" runat="server">Partita <%# Eval("tipo").ToString().ToLower() %></h5>
        <h5>Master: <%# Eval("master") %></h5>
                 <br />
        
        <h5 style="color:#ffffff80;">Turno <%# Eval("turno attuale") %></h5>
        <h5 style="color:#ffffff80;">Ultimo aggiornamento: <%# Eval("d_modifiedOn").ToString().Substring(0,16) %></h5>
        <h7 style="color:#ffffff80;">Le comunità neutrali hanno un'indole <%# Eval("t_intelligence") %>.</h7>
                 <br /><br />
        <p style="color:#ffffff80; text-align:justify"><%# Eval("t_desc") %></p>


            </center>
    </a>
            <div class="col-lg-3"></div>
            <div class="col-lg-6">
                <asp:Button ID="btnType" runat="server" CommandArgument='<%# Eval("tipo") %>' Visible="false"/>

                  



                <asp:Button ID="btnObserve" runat="server" CommandName="Observe"
                    Text="Osserva" CommandArgument='<%# Eval("i_game_id") %>' CssClass="btn btn-secondary btn-block"/>

                <asp:Button ID="btnRequest" runat="server" Enabled="false" Visible="false"
                    Text="Richiesta in corso" CssClass="btn btn-warning btn-block"/>

                <div runat="server" id="btnAddPlayer" visible="false" style="margin-top:10px;" >
                <button type="button" class="btn btn-warning btn-block" data-toggle="modal" data-target="#add" onclick="add(<%# Eval("i_game_id") %>)">
                  Partecipa
                </button>
                    </div>

                <div runat="server" id="btnAddPlayerRequest" visible="false" style="margin-top:10px;" >
                <button type="button" class="btn btn-warning btn-block" data-toggle="modal" data-target="#addRequest" onclick="add(<%# Eval("i_game_id") %>)">
                  Partecipa
                </button>
                    </div>

                <asp:Button ID="btnManageGame" runat="server" CommandName="manageGame"
                    Text="Gestisci" CommandArgument='<%# Eval("i_game_id") %>' CssClass="btn btn-warning btn-block"/>
                <div runat="server" id="btnRemovePlayer" class="marginTop10"> 
                <button type="button" class="btn btn-danger btn-block" data-toggle="modal" data-target="#remove" onclick="unsub(<%# Eval("i_game_id") %>)">
                  Disiscriviti
                </button>
                    </div>  
                <div runat="server" id="btnDeleteGame" > 
                    <br />
                <button type="button" class="btn btn-danger btn-block" data-toggle="modal" data-target="#delete" onclick="deleteGame(<%# Eval("i_game_id") %>)">
                  Cancella
                </button>
                    </div> 
                <br />
                </div> 
                <div class="col-lg-3"></div>
        </div>
        </div>
     <center>
        </div>
    </ItemTemplate>
</asp:Repeater>
                </div>
            </div>
         <div class="col-lg-1"></div>
    </div>
</div>

        <div class="row">
            <div  class="col-lg-2"></div>
            <div  class="col-lg-8">
                            <div class="panel panel-success" runat="server" >
                                <div class="panel-body scroll-x" >
                                    <asp:GridView ID="Gv" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" 
                                    AllowPaging="true" PageSize="20" 
                                        BorderWidth="0"  >
                                             <Columns>
<asp:TemplateField HeaderText="Partite in corso" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
<ItemTemplate>
    
</ItemTemplate>                          
</asp:TemplateField>
           
                            </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

            </div>
            <div  class="col-lg-2"></div>
         </div>
    
    


</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

    <script>

        function add(id) {
            $('#<%= hidGameAdd.ClientID %>').val(id);
        }

        function unsub(id) {
            $('#<%= hidGameUnsub.ClientID %>').val(id);
        }

        function deleteGame(id) {
            $('#<%= hidGameDelete.ClientID %>').val(id);
        }
        
    </script>
</asp:Content>
