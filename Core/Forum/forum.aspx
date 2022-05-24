<%@ Page Language="C#" AutoEventWireup="true" Inherits="forum" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="forum.aspx.cs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-lg animate__animated animate__fadeIn">

    <div class="row" style="margin-top:-20px;">

        <div class="col-md-8">

        
<asp:Repeater ID="rep" runat="server" OnItemCommand="Repeater_ItemCommand">
    
    <ItemTemplate>
       <div class="col-md-12 customJumbotron">
<asp:HiddenField ID="hidSectionId" runat="server" Value='<%#Eval("i_section_id") %>' />
<asp:HiddenField ID="hidIsClosed" runat="server" Value='<%#Eval("isClosed") %>' />
<asp:HiddenField ID="hidIsVisible" runat="server" Value='<%#Eval("isVisible") %>' />
<asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("i_last_user_id") %>' />
<asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("i_last_message_id") %>' />

            <div class="card text-white bg-dark">
  <div class="card-body">
      <asp:LinkButton runat="server" id="LinkButton1" OnCommand="ProcessCommand" CommandName="goToThread"  >
    <h5 class="card-title"><%#Eval("t_title") %></h5>
    <p class="card-text">Per presentarsi ed avere aggiornamenti sui giochi e le novità.</p>
      </asp:LinkButton>
      <hr />
      <label class="card-subtitle mb-2">Ultimo intervento:</label>
          <asp:LinkButton runat="server" id="linkProfile" OnCommand="ProcessCommand" CommandName="goToThread"  >
    <a href="#" class="card-link"><%#Eval("t_username") %></a>
              </asp:LinkButton>
      <asp:LinkButton runat="server" id="linkThread" OnCommand="ProcessCommand" CommandName="goToThread"  >
    <a href="#" class="card-link"><%#Eval("t_body") %> - <%#Eval("i_last_message_createdOn") %></a>
          </asp:LinkButton>

  </div>
</div>
          
            

   

</div>
    </ItemTemplate>
</asp:Repeater>
  

        </div>

        <div class="col-md-4" >
        <center><h3 class="customJumbotron d-md-none" runat="server" id="divWelcomeResponsive" style="margin-bottom:30px; margin-top:10px;"></h3></center>

                <div runat="server" id="divIsOnlineRight"  class="customJumbotron">
                    <center>
                            <h5 class="card-title">Pannello laterale</h5>
                    </center>

                    <p>
                          <a runat="server" id="linkNewGameRight" class="btn btn-warning btn-block shadow-lg " href="~/Core/Games/gameNew.aspx">To do</a>
                    </p>
                </div>



</div>

                

                
        </div>
    </div>



</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
 

</asp:Content>
