<%@ Page Language="C#" AutoEventWireup="true" Inherits="profile" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="profile.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidSchedaDaCancellare" />
      
    <div class="container-lg animate__animated animate__fadeIn">
               <div class="customJumbotron">
                   
                   <div class="row">
                       <div class="col-lg-12">
                           <center><asp:Label Text="" runat="server" ID="lblmsg" Visible="false" />
                            <h1><asp:Literal Text="" runat="server" id="ltlUsername"/></h1></center>
                           <br />
                       </div>

                       <!-- Left side: image panel -->
                       <div class="col-lg-6">
                           <!-- Image -->
                           <div class="col-lg-12">
                               <div class="col-lg-6">
                   <asp:Image ImageUrl="temp" runat="server" id="imgProfile"  CssClass="img-fluid rounded25"/>
                                   </div>
                            </div>
                        <!-- End Image -->
<br />

                            <!-- Change Image panel -->
<div class="col-lg-12">

    
    <div class="col-lg-6">
    
      <button runat="server" id="btnModifyAvatar" class="btn btn-warning dark-block marginBottom5 btn-block" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
        Modifica Avatar
      </button>

    </div> 
    
    <!-- collapsed buttons -->
    <div class="collapse" id="collapseExample">

    <div runat="server" visible="false" id="temporaryToDelete">
        <div class="col-lg-6">
    <div runat="server" id="divUpload">
    <asp:FileUpload style="margin-top:10px; margin-bottom: 5px;" ID="FileUpload1" runat="server"  CssClass="btn btn-dark btn-block" />
    </div>              
        </div>


        <div class="col-lg-6">
                    <asp:Button ID="btnChangeImg" runat="server" OnCommand="ProcessCommand" CommandName="changeImg" Text="Carica immagine da file" CssClass="btn btn-warning dark-block marginBottom5 btn-block"/> 
        </div>
</div>
    <div class="col-lg-6">
                    <asp:Button ID="btnDefaultImg1" runat="server" OnCommand="ProcessCommand" CommandName="noImg" Text="Nessun avatar" CssClass="btn btn-warning dark-block marginBottom5 btn-block"/>  
    </div>

    <div class="col-lg-6">
                    <asp:Button ID="btnDefaultImg3" runat="server" OnCommand="ProcessCommand" CommandName="randomImg" Text="Random" CssClass="btn btn-warning dark-block marginBottom5 btn-block"/>  
    </div>
    <div class="col-lg-6">
                    <asp:Button ID="btnDefaultImg2"  runat="server" OnCommand="ProcessCommand" CommandName="defaultImg" Text="Scegli un avatar" CssClass="btn btn-warning dark-block marginBottom5 btn-block"/>
    </div>
    <br />
    </div>
    <!-- end collapsed buttons-->
</div>         
                           <!-- End Change Image panel -->

                           <!-- Change password panel -->
                                       <div class="col-lg-12">
                                           <div class="col-lg-6">
                               <div runat="server" id="divChangePsw">
                    <a class="btn btn-warning btn-block" href="../Users/modifyPassword.aspx">Modifica password</a>
                                   </div>
                                </div>
                            </div> 
                           <!-- End Change password panel -->

                           </div>
                       <!-- End Left side: image panel-->

                       <!-- Right side-->
                       <div class="col-lg-6"> 
                           
                           <table class="tg">
<thead>
  <tr>
    <th>



    </th>
  </tr>
</thead>
<tbody>
  <tr>
    <td>

        <asp:Literal Text="" runat="server" id="ltlEmail"/>

    </td>
  </tr>
  <tr>
    <td>

        <asp:Literal Text="" runat="server" id="ltlDate"/>

    </td>
  </tr>
  <tr>
    <td>

        <asp:Literal Text="" runat="server" id="ltlDateMod"/>

    </td>
  </tr>
</tbody>
</table>


<br />


                <!-- Messages panel -->
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <asp:Button ID="btnMyProfile"  runat="server" OnCommand="ProcessCommand" CommandName="toMyMessages" Text="Vai ai tuoi messaggi di posta" CssClass="btn btn-warning dark-block marginBottom5 btn-block"/>

                        <asp:Button ID="btnNotMyProfile"  runat="server" OnCommand="ProcessCommand" CommandName="sendAMessage" Text="Manda un messaggio" CssClass="btn btn-warning dark-block marginBottom5 btn-block"/>
                    </div>
                </div> 
                <!-- End Messages panel -->



                           </div>
                       <!-- End Right side-->
                       </div>
              </div>             
     </div>


</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

</asp:Content>
