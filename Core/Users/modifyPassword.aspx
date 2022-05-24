<%@ Page Language="C#" AutoEventWireup="true" Inherits="modifyPassword" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="modifyPassword.aspx.cs" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div class="container-lg animate__animated animate__fadeInDown">
<div class="middle-box text-center animate__animated fadeInDown">
<div class="panel panel-primary">
               
                      <div class="row">
            <div  class="col-lg-4"></div> 
    <div  class="col-lg-4">
<div class="customJumbotron">

    <div class="customSuccess">
    <asp:Label ID="lblSuccess" runat="server" Visible="false" />
        </div>

    <div class="customSuccess">
    <asp:Label ID="lblError" runat="server" Visible="false" />
    </div>

<div runat="server" id="divEmail">
<div class="form-group">
    <label><b>Se hai dimenticato la password, puoi crearne una nuova. Inserisci la tua mail per continuare</b></label>
                <asp:TextBox class="form-control" runat="server" ID="t_email" MaxLength="75"  ></asp:TextBox>
    <asp:Label ID="lblErrorEmail" runat="server" CssClass="customWarning" Visible="false" />
</div>

        <div class="row">         
            <div class="col-lg-12">
                <asp:Button class="btn btn-block btn-warning" ID="btnCheckMail" runat="server" OnCommand="ProcessCommand" CommandName="checkMail" Text="Invia e-mail"/>
            </div>
        </div>  

</div>
<div runat="server" id="divPassword" visible="false">
<div class="form-group">
    <label><b>Password</b></label>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="t_password" MaxLength="50"  ></asp:TextBox>
    <div class="customWarning">
    <asp:Label ID="lblErrorPassword" runat="server" Visible="false" />
        </div>
</div>

<div class="form-group">
        <label><b>Conferma password</b></label>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="t_conf_password"  ></asp:TextBox>
    <div class="customWarning">
<asp:Label ID="lblErrorPasswordConfirm" runat="server" Visible="false" />
        </div>
            <asp:label class="hiddenOnlyInCell form-check-label" runat="server" ID="lblShowPsw"   Text="Mostra password"  ontouchend="hidePasswordMobile()" ontouchstart="showPasswordMobile()" ></asp:label>

            <asp:CheckBox class="showOnlyInCell form-check-label" runat="server" ID="CheckBox2"   Text="Mostra password"  onclick="showPassword()"></asp:CheckBox>
</div>

        <div class="row">         
             <div class="col-lg-12">
                <asp:Button class="btn btn-block btn-warning" ID="btnChangePassword" runat="server" OnCommand="ProcessCommand" CommandName="changePassword" Text="Modifica password"/>
                <br />
            </div>
        </div>  

</div>         

</div>  
</div> 
    
    <div  class="col-lg-4"></div> 
    </div>        
    
        </div> 
    </div> 
    </div>


                              

    

 </asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
     <script>
        function showPassword() {
            var x = document.getElementById("<%= t_password.ClientID %>");
            var y = document.getElementById("<%= t_conf_password.ClientID %>");
      if (x.type === "password") {
          x.type = "text";
          y.type = "text";
      } else {
          x.type = "password";
          y.type = "password";
      }
         }

         function showPasswordMobile() {
             var x = document.getElementById("<%= t_password.ClientID %>");
                  x.type = "text";
          }

          function hidePasswordMobile() {
              var x = document.getElementById("<%= t_password.ClientID %>");
              x.type = "password";
          }

     </script>
</asp:Content>




