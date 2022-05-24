<%@ Page Language="C#" AutoEventWireup="true" Inherits="messages" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="messages.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidNewMessage" />
      
<div class="modal fade" id="remove" tabindex="-1" role="dialog" aria-labelledby="removeLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content customMessage">
      <div class="modal-body">
        <p>Vuoi davvero eliminare questo messaggio?</p>
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">

        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-warning" data-dismiss="modal">No</button>
                        <asp:Button ID="btnDeleteMessage" runat="server"  OnCommand="ProcessCommand" CommandName="delete"
                    Text="Elimina"  CssClass="btn btn-danger"/>
      </div>
    </div>
  </div>
</div>

    <div class="container-fluid">
        <div class="row animate__animated animate__fadeIn">
            <div  class="col-lg-2"></div>
             <div  class="col-lg-10">
                 <div class="row">
            <div runat="server" id="divReceivedMessages" class="col-lg-4">
                <div class="text-center"  style="margin-bottom:10px">
                    <asp:button CssClass="btn btn-warning btn-block" Text="Messaggi ricevuti" ID="btnReceivedMessages" runat="server" OnCommand="ProcessCommand" CommandName="receivedMessages" />
                </div>
            </div>
                        <div runat="server" id="divSentMessages" class="col-lg-4">
                <div class="text-center"  style="margin-bottom:10px">
                    <asp:button CssClass="btn btn-dark btn-block" Text="Messaggi inviati" ID="btnSentMessages" runat="server" OnCommand="ProcessCommand" CommandName="sentMessages" />
                </div>
            </div>
            <div runat="server" id="divNewMessage" class="col-lg-4">
                <div class="text-center"  style="margin-bottom:10px">
                    <asp:button CssClass="btn btn-dark btn-block" Text="Nuovo messaggio" ID="btnNewMessage" runat="server" OnCommand="ProcessCommand" CommandName="newMessage" />
                </div>
            </div>
                </div>
             </div>
        </div>
                            
        <div class="row animate__animated animate__headShake">


            <div  class="col-lg-4 ">
                <div runat="server" id="firstPage"> 
                            <div class="panel panel-success" runat="server" >
                                <div class="panel-body" style="max-height:600px;" >
                                    <asp:GridView ID="GvReceived" runat="server" CssClass="table table-bordered table-striped table-dark" AlternatingRowStyle-VerticalAlign="Middle" AutoGenerateColumns="false"  ShowHeader="False"
                                    AllowPaging="true" PageSize="20" >
                                             <Columns>
                                                 <asp:HyperLinkField DataNavigateUrlFields="b_isRead"  DataTextField="t_sender" ><ControlStyle CssClass="colorWarning"/></asp:HyperLinkField>
                                                <asp:HyperLinkField DataNavigateUrlFields="i_message_id,b_isRead" DataNavigateUrlFormatString="messages.aspx?id={0}&msg=received&resp=1&read={1}" DataTextField="linkString" ><ControlStyle CssClass="borderedAccountList btn btn-block btn-outline-warning colorWarning"/></asp:HyperLinkField>
                                            </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="GvSent" runat="server" CssClass="table table-bordered table-striped table-dark" AlternatingRowStyle-VerticalAlign="Middle" AutoGenerateColumns="false" ShowHeader="False"
                                    AllowPaging="true" PageSize="20" Visible="false">
                                             <Columns>
                                                 <asp:HyperLinkField DataNavigateUrlFields="i_message_id" DataNavigateUrlFormatString="messages.aspx?id={0}&msg=sent&resp=1" DataTextField="t_recipient_list" ><ControlStyle CssClass="colorWarning"/></asp:HyperLinkField>
                                                <asp:HyperLinkField DataNavigateUrlFields="i_message_id" DataNavigateUrlFormatString="messages.aspx?id={0}&msg=sent&resp=1" DataTextField="linkString" ><ControlStyle CssClass="borderedAccountList btn btn-block btn-outline-warning"/></asp:HyperLinkField>
                                            </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

            </div>
                <br />
                <b></b>
                <!-- NEW MESSAGE LABEL -->

        </div>
            <div  class="col-lg-8">
                        <div runat="server" id="divMessage" class="animate__animated  animate__fadeInUp">
                            <table class="table table-active table-bordered table-dark">
                                <tbody>
                                    <tr>
                                        <th>
                                              <div style="float:right;" data-toggle="modal" data-target="#remove">
                  <i class="fa fa-trash" aria-hidden="true"></i>
                </div>
                            <i class="fa fa-user" aria-hidden="true"></i> <asp:label id="lblSender" runat="server" /> 
                                            </th>
                                        </tr>
                                    <tr>
                                        <th>
                            <i class="fa fa-user" aria-hidden="true"></i> <asp:label id="lblRecipient" runat="server" />
                                            </th>
                                    </tr>
                                    <tr>
                                        <th>
                            <asp:label id="lblSubject" runat="server" />
                                            </th>
                                    </tr>
                                    <tr>
                                        <th>
                            <asp:label id="lblContent" runat="server" />
                                            </th>
                                    </tr>
                                    <tr>
                                        <th>
                          <asp:HiddenField runat="server" ID="hidI_Message_id" />
                <asp:Button ID="btnReply" runat="server" CommandName="reply"
                    Text="Rispondi" OnCommand="ProcessCommand" CssClass="btn btn-warning btn-block"/>
                    <div runat="server" id="DivBtnDelete" class="marginTop10"> 
                    </div>  
                                            </th>
                                    </tr>
                                </tbody>
                                </table>
                        </div>

                <div runat="server" id="newMessage" visible="false" class="animate__animated  animate__fadeInUp">
    <div class="row">
                    <div  class="col-lg-12">
    <div class="customMessage">   
    <div class="row">
    <div  class="col-lg-12">
        <div class="input-group">
            <label style="margin-right:10px;"><b>Destinatari:</b></label>
<asp:ListBox runat="server" class="form-control chosen-select" SelectionMode="Multiple" ID="ddRecipients" >
</asp:ListBox>
            
        </div>
    </div>
    <div  class="col-lg-12">
        <div class="form-group">
            <label><b>Oggetto:</b></label>
            <asp:TextBox class="form-control" runat="server" ID="t_subject"   ></asp:TextBox>
        </div>
    </div>
    </div>
    <div class="row">
    <div  class="col-lg-12">
        <div class="form-group">
            <label><b>Messaggio:</b></label>
            <asp:TextBox TextMode="MultiLine" class="form-control" runat="server" ID="t_content"   ></asp:TextBox>
        </div>
    </div>
    </div>

    <div class="row">
    <div  class="col-lg-12">
            <div class="col-lg-12 text-center"  style="margin-bottom:10px">
                <asp:Button ID="btnSendMessage" runat="server" OnCommand="ProcessCommand" CommandName="sendMessage" Text="Invia" CssClass="btn btn-dark btn-block" />  
            </div>
    </div>
    </div>
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
