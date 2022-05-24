<%@ Page Language="C#" AutoEventWireup="true" Inherits="game" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="game.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidGameId" />
    <asp:HiddenField runat="server" ID="hidI_image_id" Value="0" />
    <asp:HiddenField runat="server" ID="hidI_intelligence_id" Value="1" />

<!--  Game delete panel -->
<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="deleteLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
        <p>Vuoi davvero eliminare questa partita?</p>
         <p>Se confermi, ti verrà richiesto una seconda volta per sicurezza.</p>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancella</button>
                <asp:Button ID="btnDeleteGame" runat="server" OnCommand="ProcessCommand" CommandName="deleteGamePending" Text="Elimina partita" CssClass="btn btn-danger" />  
      </div>
    </div>
  </div>
</div>
<!--  End game delete panel -->

 <div class="container-fluid animate__animated animate__fadeIn">
               <div class="customJumbotron">
                   <div class="row">
                   <div class="col-lg-3"></div>
                   <div class="col-lg-6" style="margin-bottom:10px;">
<div runat="server" id="divConfirmDelete" visible="false">
    <p>Attenzione, questo è l'ultimo step per l'eliminazione della partita. Nessun dato sarà più recuperabile: verranno anche eliminate le comunità dei giocatori e i loro personaggi.</p
    <p>Una mail verrà inviata a tutti i partecipanti per segnalare la cessazione della partita. Sei davvero sicuro di voler procedere?</p>

                <asp:Button ID="btnNoConfirmDelete" runat="server" OnCommand="ProcessCommand" CommandName="deleteGameForgive" Text="Annulla" CssClass="btn btn-warning btn-block" />  

                <asp:Button ID="btnConfirmDelete" runat="server" OnCommand="ProcessCommand" CommandName="deleteGameConfirm" Text="Elimina partita" CssClass="btn btn-danger btn-block" />  
</div>
                       </div>
                   <div class="col-lg-3"></div>
                      
                       </div>
<!------------------ TITLE & IMAGINE & CALENDAR ------------------>
                   <div class="row">
                       <div class="col-lg-12">
<center>
<asp:Label ID="tName" runat="server" Text="tName" Font-Names="Comic Sans MS" Font-Bold="true" Font-Size="X-Large"></asp:Label>
</center>
                       </div>
                       <br /><br />

                       <div class="col-lg-12">
<center>
    <asp:Image runat="server" ID="coverImg" CssClass="coverBorder img-fluid" />
</center>
                       </div>

                      <div class="col-lg-12">
<center>
<asp:Label ID="tCalendar" runat="server" Text="tCalendar" Font-Names="Comic Sans MS" Font-Bold="true" Font-Size="X-Large" CssClass="marginTop10"></asp:Label>
    <br />
<asp:Label ID="tNature" runat="server" Text="tNature" Font-Names="Comic Sans MS" Font-Bold="true" Font-Size="Large" CssClass="marginTop10"></asp:Label>
</center>
                       </div>
                       </div>
                   <br />
<!------------------ END TITLE & IMAGINE & CALENDAR ------------------>

<!------------------ ADMIN SECTION ------------------>

        <div class="col-lg-12 text-center"  style="margin-bottom:10px">   
           <asp:Label ID="lblError" runat="server" CssClass="customWarning" Visible="false" />
           </div>

                   <div class="row" runat="server" id="divMaster">
                       <div class="col-lg-12">
        <center>
      <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
        Pannello master
      </button>
    </center>

    <div class="collapse" id="collapseExample">
      <div class="card card-body customJumbotron">
     
        <div class="col-lg-12 text-center"  style="margin-bottom:10px">
            <hr />
            <asp:Button ID="btnNewTurn" runat="server" OnCommand="ProcessCommand" CommandName="newTurn" Text="Turno successivo" CssClass="btn btn-secondary btn-block" />  
        </div>
          <div class="col-lg-12">
<div class="row">
  <!-- Change Image panel -->
<div class="col-lg-6">
      <button runat="server" id="btnModifyAvatar" class="btn btn-warning dark-block marginBottom5 btn-block" type="button" data-toggle="collapse" data-target="#collapseExample2" aria-expanded="false" aria-controls="collapseExample2">
        Crea neutrale (manuale)
      </button>

  


   
    <!-- collapsed buttons -->
    <div class="collapse" id="collapseExample2">

<!-- Title -->
<div class="row">
<div class="col-lg-2"></div>
<div class="col-lg-8">
       <center>
           <div><b>Nome della comunità</b></div>
        <asp:TextBox class="form-control" runat="server" ID="txtSettlementName" MaxLength="50"  ></asp:TextBox>
        </center>
</div>
<div  class="col-lg-2"></div>
</div>
    <br />
<!-- Game description -->
<div class="row">
<div class="col-lg-12">
    <center>
        <div><b>Descrizione facoltativa:</b></div>
    <asp:TextBox TextMode="MultiLine" Rows="6" class="form-control" runat="server" ID="txtSettlementDesc"  MaxLength="1000" ></asp:TextBox>
    </center>
</div>

</div>

<!-- Images -->
<div class="row">
<div class="col-lg-12">

    <br />
    <center>
      <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#collapseExample3" aria-expanded="false" aria-controls="collapseExample3">
        Logo della comunità
      </button>
    </center>
    <div class="collapse" id="collapseExample3">
      <div class="card card-body customJumbotron">
        

          <div class="form-group"> 
              <div class="form-inline" style="height: 150px; overflow-y: scroll;"> 
<asp:Repeater ID="repLogo" runat="server" >
    <ItemTemplate>
        <div id="<%#Eval("i_image_id") %>" class="col-md-4 col-sm-6 divFather" onclick="GetImageId(<%#Eval("i_image_id") %>)">
            <img src='<%# "https://www.ischidados.it" + Eval("t_url") %>' runat="server" style="border-radius:5px; margin:5px; max-width:100%;" class="img-fluid"/>
            </div>
    </ItemTemplate>
</asp:Repeater>
              </div>
          </div>
    




      </div>
    </div>

  
</div>

</div>


        <br />
        <div class="form-group">
            <div class="form-inline">
                <div class="col-lg-3"></div>
        <div class="col-lg-3 text-center"  style="margin-bottom:10px">
            <asp:Button ID="Button1" runat="server" OnCommand="ProcessCommand" CommandName="newSettlement" Text="Crea" CssClass="btn btn-warning btn-block" />  
        </div>
                <div class="col-lg-3"></div>
            </div>
        </div>
    <br />
    </div>
    <!-- end collapsed buttons-->
</div> 
      
        
                           <!-- End Change Image panel -->
<div class="col-lg-6">
            <asp:Button ID="Button2" runat="server" OnCommand="ProcessCommand" CommandName="newSettlementRandom" Text="Crea neutrale (auto)" CssClass="btn btn-warning btn-block" />

    
        </div>
</div>
          

          </div>

          <!-- WARNING - Delete button -->
        <div class="col-lg-12 text-center"  style="margin-top:5px">
            <button type="button" class="btn btn-danger btn-block" data-toggle="modal" data-target="#delete">
        Elimina partita
                </button>
            <hr />
        </div>
          <!-- END WARNING - Delete button -->
                    
      </div>
    </div>
                          
                       </div>

                       </div>
    
<!------------------ END ADMIN SECTION ------------------>

                   <br>








<!--------------------------------------------------->
<!------------------ TWO SECTION ------------------>
<!--------------------------------------------------->
<div class="row" runat="server" id="divThreeSection">

<!------------------ 01 - SETTLEMENTS ------------------>
<div runat="server" id="div1" class="col-lg-9">
    
        
        <center>
            <asp:Label ID="lbl01" runat="server" Text="Comunità" Font-Names="Comic Sans MS" Font-Bold="true" Font-Size="X-Large"></asp:Label>
        </center>
        <br />
             
             <div class="row">
        
<asp:Repeater ID="repSettlements" runat="server" OnItemCommand="RepSettlements_ItemCommand">
    <ItemTemplate>

        <div class="col-lg-6 " style="margin-bottom:10px;">
   <hr />
<center>
      <asp:LinkButton runat="server" id="btnSettlement" OnCommand="ProcessCommand" CommandName="toSettlement" cssClass="gameListLink">   
<div class="rounded5 card bg-secondary" >
       <img src='<%# "https://www.ischidados.it" + Eval("t_img") %>' runat="server" class="card-img-top img-fluid gameListLink" />

  <div class="card-body ">
    <p class="card-text">
<asp:HiddenField ID="hidI_user_id" runat="server" Value='<%#Eval("i_settlement_id") %>' />
                <center><h4><%#Eval("t_name") %></h4>
                    
        
         
              
            
                 
                <table style="margin-left:20px;">
<thead>
  <tr>
   <td colspan="2" style="text-align:center"><h5>Popolazione: <%#Eval("settlementSpecsList[0].i_population" ) %> </h5></td>
  </tr>
</thead>
<tbody>
  <tr>
   <td style="text-align:start">Cibo: <%#Eval("settlementSpecsList[0].i_food") %> </td>
      <td style="text-align:start">Medicinali: <%#Eval("settlementSpecsList[0].i_drug") %> </td>
  </tr>
  <tr>
   <td style="text-align:end">Utensili: <%#Eval("settlementSpecsList[0].i_tool") %> </td>
   <td style="text-align:end">Armi: <%#Eval("settlementSpecsList[0].i_weapon") %> </td>
  </tr>
</tbody>
</table>
    </p>
  </div>
    <div class="rounded25 card-footer bg-transparent border-light">
        <span class="gameListLink" style="margin-right:15px;"><i class="fa fa-area-chart" aria-hidden="true"></i></span>
        <span class="gameListLink" style="margin-left:15px;"><i class="fa fa-trash" aria-hidden="true"></i></span>


    </div>
</div>
            </asp:LinkButton> 
    </center>

          

</center>
           
            </div>
         
    </ItemTemplate>
</asp:Repeater>
                  
                      </div>
         
   
    <br />
</div>
<!------------------ 01 - SETTLEMENTS ------------------>

<!------------------ 02 - PLAYER LIST ------------------>
<div runat="server" id="divPlayerList" class="col-lg-3">
        <center>
    <asp:Label ID="lblUsers" runat="server" Text="Giocatori" Font-Names="Comic Sans MS" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            </center>
        <br />
    <hr />
     <div class="card text-white bg-secondary card-body playerInfo btn btn-block">
<asp:Repeater ID="repPlayers" runat="server" OnItemCommand="RepPlayers_ItemCommand">
    <ItemTemplate>
          
         <asp:LinkButton runat="server" id="btnHidden" CssClass="gameListLink playerInfo"   OnCommand="ProcessCommand" CommandName="toProfile" >   

 
        <p class="card-text ">
            <asp:HiddenField ID="hidI_user_id" runat="server" Value='<%#Eval("i_user_id") %>' />
            <img src='<%# "https://www.ischidados.it" + Eval("t_img") %>' runat="server" class="rounded25 playerImg" />
              <h4 style="margin-left:5px;"><%#Eval("t_username") %></h4></p>
     
</asp:LinkButton> 

           
    </ItemTemplate>
</asp:Repeater>
     </div>
         <br />
</div>
<!------------------ 02 - END PLAYER LIST ------------------>
    
</div>
<!--------------------------------------------------->
<!---------------- END TWO SECTION ---------------->
<!--------------------------------------------------->


</div>             
</div>

    
</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

     <script>
         var ListSelected = [];


         function GetImageId(idElement) {
             ListSelected.push(idElement);

             for (var i = 0; i < ListSelected.length; i++) {
                 document.getElementById(ListSelected[i]).classList.remove("selectedImage");
             }

             document.getElementById(idElement).classList.add("selectedImage");
             document.getElementById("<%= hidI_image_id.ClientID %>").value = idElement;
         }

        function AIGame(idElement) {
            switch (idElement) {
                case 1:
                    color("AI1");
                    blackAndWhite("AI2");
                    blackAndWhite("AI3");
                    blackAndWhite("AI4");
                    blackAndWhite("AI5");
                    blackAndWhite("AI6");
                    break;
                case 2:
                    blackAndWhite("AI1");
                    color("AI2");
                    blackAndWhite("AI3");
                    blackAndWhite("AI4");
                    blackAndWhite("AI5");
                    blackAndWhite("AI6");
                    break;
                case 3:
                    blackAndWhite("AI1");
                    blackAndWhite("AI2");
                    color("AI3");
                    blackAndWhite("AI4");
                    blackAndWhite("AI5");
                    blackAndWhite("AI6");
                    break;
                case 4:
                    blackAndWhite("AI1");
                    blackAndWhite("AI2");
                    blackAndWhite("AI3");
                    color("AI4");
                    blackAndWhite("AI5");
                    blackAndWhite("AI6");
                    break;
                case 5:
                    blackAndWhite("AI1");
                    blackAndWhite("AI2");
                    blackAndWhite("AI3");
                    blackAndWhite("AI4");
                    color("AI5");
                    blackAndWhite("AI6");
                    break;
                case 6:
                    blackAndWhite("AI1");
                    blackAndWhite("AI2");
                    blackAndWhite("AI3");
                    blackAndWhite("AI4");
                    blackAndWhite("AI5");
                    color("AI6");
                    break;
                default:
            }
            document.getElementById("<%= hidI_intelligence_id.ClientID %>").value = idElement;
         }

         function color(idElement) {
             var element = document.getElementById(idElement);
             element.classList.remove("blackAndWhite");
             element.classList.add("animate__rotateIn");
             element.classList.remove("animate__flash");
         }

         function blackAndWhite(idElement) {
             var element = document.getElementById(idElement);
             element.classList.add("blackAndWhite");
             element.classList.remove("animate__rotateIn");
             element.classList.add("animate__flash");
             //setTimeout(() => { element.classList.remove("animate__rotateOut"); }, 600);
         }

     </script>

</asp:Content>
