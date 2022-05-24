<%@ Page Language="C#" AutoEventWireup="true" Inherits="login" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="login.aspx.cs" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div class="container-lg animate__animated animate__fadeIn">
<div class="middle-box text-center">
<div class="panel panel-primary">
               <asp:Panel ID="panSearch" runat="server" DefaultButton="btnLogin" Width="100%" >
                      <div class="row">
            <div  class="col-lg-4">
                
        <div class="row">         
        <div class="col-lg-12">
            <p>TEMPORANEO</p>
        <asp:Button class="btn btn-block btn-warning" ID="Button1" runat="server" OnCommand="ProcessCommand" CommandName="temporary" Text="Entra come admin" CommandArgument="1"/><br />

        <asp:Button class="btn btn-block btn-warning" ID="Button2" runat="server" OnCommand="ProcessCommand" CommandName="temporary" Text="Entra come Asd" CommandArgument="2"/><br />

        <asp:Button class="btn btn-block btn-warning" ID="Button3" runat="server" OnCommand="ProcessCommand" CommandName="temporary" Text="Entra come Thanatos" CommandArgument="3"/><br />

        <asp:Button class="btn btn-block btn-warning" ID="Button4" runat="server" OnCommand="ProcessCommand" CommandName="temporary" Text="Entra come Terenzio" CommandArgument="4"/><br />
        </div>
            </div>  
            </div> 
    <div  class="col-lg-4">
<div class="customJumbotron">
    <div class="customSuccess">
    <asp:Label ID="lblSuccess" runat="server" Visible="false" />
        </div>
<div class="form-group">
    <label><b>Username</b></label>
                <asp:TextBox class="form-control" runat="server" ID="t_username" MaxLength="25" onblur="this.value=removeSpaces(this.value);"   ></asp:TextBox>
</div>

<div class="form-group">
    <label><b>Password</b></label>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="t_password"   ></asp:TextBox>
            <asp:label class="hiddenOnlyInCell form-check-label" runat="server" ID="lblShowPsw"   Text="Mostra password"  ontouchend="hidePasswordMobile()" ontouchstart="showPasswordMobile()" ></asp:label>

            <asp:CheckBox class="showOnlyInCell form-check-label" runat="server" ID="CheckBox2"   Text="Mostra password"  onclick="showPassword()"></asp:CheckBox>
</div>

<div class="form-group customWarning" runat="server" id="lblNotFound" visible="false">
        <label>Credenziali non valide, riprovare.</label>
</div>             

        <div class="row">         
        <div class="col-lg-12">
                <asp:Button class="btn btn-block btn-dark" ID="btnLogin" runat="server" OnCommand="ProcessCommand" CommandName="login" Text="Login"/>
                <div class="customWarning">
            <asp:Label ID="lblNotActive" runat="server" Visible="false" />
                    </div>
        </div>
            </div>  
<div class="row" style="margin-right: 5px;">       
    <div class="col-lg-12 " >
                    <asp:CheckBox class="form-check-label" runat="server" ID="b_rememberMe"   Text="Rimani loggato" TextAlign="Left"></asp:CheckBox>
    </div>
</div>

         
  
    <div class="row">       
     <div class="col-lg-12 ">
            <div class="m-b-md">
                <a href="../Users/modifyPassword.aspx">Credenziali Dimenticate?</a>
            </div>
        </div>
   

        <br />
<div class="col-lg-12 ">
            <div class="m-b-md">
                <a href="../Users/register.aspx">Sei nuovo? Registrati!</a>
            </div>
        </div>
         </div> 
 
</div>  
    </div> 
    <div  class="col-lg-4"></div> 
    </div>        
    </asp:Panel>
        </div> 
    </div> 
    </div>


                              

    

 </asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
      <script>
        function showPassword() {
            var x = document.getElementById("<%= t_password.ClientID %>");
      if (x.type === "password") {
          x.type = "text";
      } else {
          x.type = "password";
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
        
        function removeSpaces(string) {
            return string.split(' ').join('');
        }

      </script>
</asp:Content>




