<%@ Page Language="C#" AutoEventWireup="true" Inherits="gameNew" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="gameNew.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <asp:HiddenField runat="server" ID="hidTypeOfGame" Value="1" />
    <asp:HiddenField runat="server" ID="hidI_image_id" Value="0" />
    <asp:HiddenField runat="server" ID="hidI_intelligence_id" Value="1" />
      
    <div class="container-lg animate__animated animate__fadeIn">

<div class="row">
<div  class="col-lg-2"></div>
<div  class="col-lg-8">
<div class="customJumbotron"> 
 
<!---->
<!-- Title -->
<div class="row">
<div class="col-lg-2"></div>
<div class="col-lg-8">
       <center>
           <asp:Label ID="lblError" runat="server" CssClass="customWarning" Visible="false" />
           <div><b>Titolo della partita</b></div>
        <asp:TextBox class="form-control" runat="server" ID="tName" MaxLength="50"  ></asp:TextBox>
        </center>
</div>
<div  class="col-lg-2"></div>
</div>
    <br />
<!-- Game description & kind of game -->
<div class="row">
<div class="col-lg-6">
    <center>
        <div><b>Descrizione facoltativa:</b></div>
    <asp:TextBox TextMode="MultiLine" Rows="6" class="form-control" runat="server" ID="tDesc"  MaxLength="1000" ></asp:TextBox>
    </center>
</div>
<div class="col-lg-6">

  <div class="form-group">
    <center><div><b>Tipo di partita:</b></div></center>
    <div class="form-inline">
        <div class="col-4">
            <center>
            <img id="typeGame1" onclick="TypeGame(1)" class="thumbOn" src="../../assets/img/infrastructure/ThumbZombie.jpg" alt="typeGameImg" style="width:100px; margin-left:-12px;" />
            <label><b>Aperta a tutti</b></label>
            </center>
        </div>
        <div class="col-4">
            <center>
            <img id="typeGame2" onclick="TypeGame(2)" class="thumbOff" src="../../assets/img/infrastructure/ThumbZombie.jpg" alt="typeGameImg" style="width:100px; margin-left:-12px;" />
            <label><b>Sotto invito</b></label>
            </center>
        </div>
        <div class="col-4">
            <center>
            <img id="typeGame3" onclick="TypeGame(3)" class="thumbOff" src="../../assets/img/infrastructure/ThumbZombie.jpg" alt="typeGameImg" style="width:100px; margin-left:-12px;" />
            <label><b>Gioco in solitaria</b></label>
            </center>
        </div>
    </div>
</div>

</div>
</div>

<!-- Images -->
<div class="row">
<div class="col-lg-12">

    <br />
    <center>
      <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
        Immagine di copertina
      </button>
    </center>
    <div class="collapse" id="collapseExample">
      <div class="card card-body customJumbotron">
        

          <div class="form-group"> 
              <div class="form-inline" style="height: 150px; overflow-y: scroll;"> 
<asp:Repeater ID="repPeople" runat="server" >
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
<div class="col-lg-6">

</div>
</div>

<!-- AI -->
    <br />
<div class="row">
<div class="col-lg-12">

  <div class="form-group">
    <center><div><b>Seleziona indole dominante dei neutrali:</b></div></center>
    <div class="form-inline">
        <div class="col-4">
            <center>
            <img id="AI1" onclick="AIGame(1)" class="animate__animated" src="../../Assets/img/items/questionMark.png" alt="AIGameImg" style="width:80px;" />
            <label><b>Random</b></label>
            </center>
        </div>
        <div class="col-4">
            <center>
            <img id="AI2" onclick="AIGame(2)" class="blackAndWhite animate__animated animate__flash" src="../../Assets/img/items/cooperation.png" alt="AIGameImg" style="width:80px;"/>
            <label><b>Collabotariva</b></label>
            </center>
        </div>
        <div class="col-4">
            <center>
            <img id="AI3" onclick="AIGame(3)" class="blackAndWhite animate__animated animate__flash" src="../../Assets/img/items/autarchy.png" alt="AIGameImg" style="width:80px;"/>
            <label><b>Autarchica</b></label>
            </center>
        </div>
</div>
      <br />
<div class="form-inline">
        <div class="col-4">
            <center>
            <img id="AI4" onclick="AIGame(4)" class="blackAndWhite animate__animated animate__flash" src="../../Assets/img/items/profiteer.png" alt="AIGameImg" style="width:80px;"/>
            <label><b>Opportunista</b></label>
            </center>
        </div>
        <div class="col-4">
            <center>
            <img id="AI5" onclick="AIGame(5)" class="blackAndWhite animate__animated animate__flash" src="../../Assets/img/items/violence2.png" alt="AIGameImg" style="width:80px;"/>
            <label><b>Violenta</b></label>
            </center>
        </div>
        <div class="col-4">
            <center>
            <img id="AI6" onclick="AIGame(6)" class="blackAndWhite animate__animated animate__flash" src="../../Assets/img/items/mix2.png" alt="AIGameImg" style="width:80px;"/>
            <label><b>Equilibrata</b></label>
            </center>
        </div>
    </div>
</div>

</div>
</div>

<!-- Start game! -->
<div class="row">
<div  class="col-lg-12">
            <br />
        <div class="col-lg-12 text-center"  style="margin-bottom:10px">
            <asp:Button ID="btnNewGame" runat="server" OnCommand="ProcessCommand" CommandName="newGame" Text="Crea partita" CssClass="btn btn-secondary btn-block" />  
        </div>
</div>
</div>

</div>
<div class="col-lg-2"></div>
</div>
</div>

</div>


</div>      


            <div  class="col-lg-8"></div>
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

        function TypeGame(idElement) {
            switch (idElement) {
                case 1:
                    up("typeGame1");
                    down("typeGame2");
                    down("typeGame3");
                    break;
                case 2:
                    down("typeGame1");
                    up("typeGame2");
                    down("typeGame3")
                    break;
                case 3:
                    down("typeGame1");
                    down("typeGame2");
                    up("typeGame3");
                    break;
                default:
            }
            document.getElementById("<%= hidTypeOfGame.ClientID %>").value = idElement;
        }

        function down(idElement) {
            var element = document.getElementById(idElement);
            element.classList.add("thumbOff");
            element.classList.remove("thumbOn");
        }

        function up(idElement) {
            var element = document.getElementById(idElement);
            element.classList.add("thumbOn");
            element.classList.remove("thumbOff");
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
