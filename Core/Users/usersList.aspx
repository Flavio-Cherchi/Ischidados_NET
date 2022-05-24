<%@ Page Language="C#" AutoEventWireup="true" Inherits="usersList" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="usersList.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidSchedaDaCancellare" />
      
    <div class="container-lg animate__animated ">
                            
        <div class="row">
            <div  class="col-lg-2"></div>
            <div  class="col-lg-8">
                            <div class="panel panel-success" runat="server" >
                                <div class="panel-body scroll-x" >
                                    <asp:GridView ID="Gv" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" 
                                    AllowPaging="true" PageSize="20" 
                                        BorderWidth="0"  OnRowCommand="GV_RowCommand">
                                            <RowStyle CssClass="animate__animated animate__fadeInRight" />
    <AlternatingRowStyle CssClass="animate__animated animate__fadeInLeft" />
                                             <Columns>
<asp:TemplateField HeaderText="Giocatori presenti" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
<ItemTemplate>
    <center>
            <img src="<%# Eval("t_img")%>" class="border5 img-fluid" style="max-height:120px; width:120px;"/>
        <h5><%# Eval("Username") %> <a href="mailto:<%# Eval("Email") %>"><i class="fa fa-envelope" aria-hidden="true"></i></a></h5>
        <h6><%# Eval("Ruolo") %></h6>
        <p>Attivo dal: <%# Eval("Data Registrazione") %></p>
            </center>

                <asp:Button ID="btnProfile" runat="server" CommandName="profile"
                    Text="Profilo" CommandArgument='<%# Eval("i_user_id") %>' CssClass="btn btn-warning shadow-lg btn-block"/>
                <asp:Button ID="btnMessage" runat="server" CommandName="message"
                    Text="Messaggio" CommandArgument='<%# Eval("i_user_id") %>' CssClass="btn btn-warning shadow-lg btn-block"/>
                <asp:Button ID="btnManageUser" runat="server" CommandName="manageUser"
                    Text="Modifica" CommandArgument='<%# Eval("i_user_id") %>' CssClass="btn btn-danger btn-block"/>
                <asp:Button ID="btnDeactivatePlayer" runat="server" CommandName="deactivatePlayer"
                    Text="Disattiva" CommandArgument='<%# Eval("i_user_id") %>' CssClass="btn btn-danger btn-block"/>
            </ItemTemplate>
        </asp:TemplateField>  
                            </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

            </div>
            <div  class="col-lg-2"></div>
         </div>
     </div>


</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">

</asp:Content>
