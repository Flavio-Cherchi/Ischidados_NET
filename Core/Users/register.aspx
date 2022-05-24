<%@ Page Language="C#" AutoEventWireup="true" Inherits="register" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="register.aspx.cs" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div class="container-lg animate__animated animate__fadeIn">
<div class="middle-box text-center">
<div class="panel panel-primary">
               <asp:Panel ID="panSearch" runat="server" DefaultButton="btnLogin" Width="100%" >
                      <div class="row">
            <div  class="col-lg-4"></div> 
    <div  class="col-lg-4">
<div class="customJumbotron">

<div class="form-group">
    <label><b>Username</b></label>
                <asp:TextBox class="form-control" runat="server" ID="t_username" MaxLength="25" onblur="this.value=removeSpaces(this.value);"  ></asp:TextBox>
    <div class="customWarning">
    <asp:Label ID="lblErrorUsername" runat="server" Visible="false" />
        </div>
</div>

<div class="form-group">
    <label><b>E-mail</b></label>
                <asp:TextBox class="form-control" TextMode="Email" runat="server" ID="t_email" MaxLength="75"  ></asp:TextBox>
    <div class="customWarning">
    <asp:Label ID="lblErrorEmail" runat="server" Visible="false" />
</div>
    </div>

<div class="form-group">
    <label><b>Password</b></label>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="t_password" MaxLength="50"  ></asp:TextBox>
    <div class="customWarning">
    <asp:Label ID="lblErrorPassword" runat="server" Visible="false" />
</div>
    </div>

<div class="form-group">
        <label><b>Conferma password</b></label>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="t_conf_password"   ></asp:TextBox>

    <div class="customWarning">
<asp:Label ID="lblErrorPasswordConfirm" runat="server" Visible="false" />
        </div>
            <asp:label class="hiddenOnlyInCell form-check-label" runat="server" ID="lblShowPsw"   Text="Mostra password"  ontouchend="hidePasswordMobile()" ontouchstart="showPasswordMobile()" ></asp:label>

            <asp:CheckBox class="showOnlyInCell form-check-label" runat="server" ID="CheckBox2"   Text="Mostra password"  onclick="showPassword()"></asp:CheckBox>
</div>
    <div class="customWarning">
<asp:Label ID="lblErrorAlready" runat="server" Visible="false" />
</div>             



        <div class="row">         
        <div class="col-lg-6">
                <asp:Button class="btn btn-block btn-dark" ID="btnLogin" runat="server" OnCommand="ProcessCommand" CommandName="login" Text="Login" Visible="false"/>
        </div>
            <div class="col-lg-12">
                <asp:Button class="btn btn-block btn-dark" ID="btnRegister" runat="server" OnCommand="ProcessCommand" CommandName="register" Text="Registrati" style="margin-bottom:-20px;"/>
                <br />
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
                <a href="../Users/login.aspx">Già registrato? Vai al login!</a>
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

        function removeSpaces(string) {
            return string.split(' ').join('');
        }

    </script>
</asp:Content>




