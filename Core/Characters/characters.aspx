<%@ Page Language="C#" AutoEventWireup="true" Inherits="characters" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="characters.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-lg animate__animated animate__headShake">
     <div class="wrapper wrapper_content">
        <div class="row">
            <asp:Panel class="alert alert-danger alert-dismissabl text-center " runat="server" visible="false" id="divmessaggiopopup" >
                    <asp:Label ID="lblmessaggiopopup" runat="server"></asp:Label>
            </asp:Panel>
        </div>   
        <div class="row">
            <div class="col-lg-12">
                <div class="wrapper wrapper-content">
                    <div class="customBox">
                        <div class="customBox-content">



                               <div class="row">
                        <div class="col-lg-6"></div>
                            <div class="col-lg-3 text-center"  style="margin-bottom:10px" visible="true" id="div1" runat="server">
                                <asp:Button ID="btnRicerca" runat="server" OnCommand="ProcessCommand" CommandName="research" Text="Ricerca" CssClass="btn btn-dark btn-block" Visible ="true" />  
                            </div>

                            <div class="col-lg-3 text-center"  style="margin-bottom:10px" visible="true" id="divNuovaScheda" runat="server">
                                <asp:Button ID="Button1" runat="server" OnCommand="ProcessCommand" CommandName="newChar" Text="Nuovo personaggio" CssClass="btn btn-dark btn-block" Visible ="true" />  
                            </div>
                            </div>
                            </div>

<div class="row">
<asp:Repeater ID="Rep" runat="server" >
    <ItemTemplate>
        <div class="col-md-4 col-sm-12" runat="server" id="divImg">
            <center><img src='<%# "https://www.ischidados.it" + Eval("t_url") %>' runat="server" class="imgListed animate__animated"/></center>
            <br />
            <ItemTemplate><%#Eval("fullName") %></ItemTemplate>
            <br />
            <ItemTemplate><%#Eval("t_desc") %></ItemTemplate>
            <br />
            <ItemTemplate><%#Eval("t_sex").ToString() == "1" ? "Uomo" : "Donna" + " " + Eval("i_age") %></ItemTemplate>
              </div>
            </tr>
        </table>                
    </ItemTemplate>
</asp:Repeater>
</div>



                       </div>
                    </div>
                </div>
            </div>
         </div>
        </div>
</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent"> 

</asp:Content>
