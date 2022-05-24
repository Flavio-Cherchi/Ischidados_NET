<%@ Page Language="C#" AutoEventWireup="true" Inherits="elenco_test" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="elenco_test.aspx.cs" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"> 
</asp:Content>

<asp:Content ID="Breadcrumb" runat="server" ContentPlaceHolderID="BreadcrumbContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:HiddenField runat="server" ID="hidSchedaDaCancellare" />
  <div class="wrapper wrapper_content">
  <div class="container-lg animate__animated animate__headShake">   

<div class="row">
<div class="col-lg-12">
    <div class="wrapper wrapper-content">
        <div class="customBox">
            <div class="customBox-content">
                    <asp:Panel ID="p" runat="server" DefaultButton="btnRicerca">
                             
<div class="panel panel-primary">


<div class="panel-body">
    <div class="row">
        <div class="col-lg-12">

            <p class="text-primary">.text-primary</p>
<p class="text-secondary">.text-secondary</p>
<p class="text-success">.text-success</p>
<p class="text-danger">.text-danger</p>
<p class="text-warning">.text-warning</p>
<p class="text-info">.text-info</p>
<p class="text-light bg-dark">.text-light</p>
<p class="text-dark">.text-dark</p>
<p class="text-muted">.text-muted</p>
<p class="text-white bg-dark">.text-white</p>

<div class="p-3 mb-2 bg-primary text-white">.bg-primary</div>
<div class="p-3 mb-2 bg-secondary text-white">.bg-secondary</div>
<div class="p-3 mb-2 bg-success text-white">.bg-success</div>
<div class="p-3 mb-2 bg-danger text-white">.bg-danger</div>
<div class="p-3 mb-2 bg-warning text-dark">.bg-warning</div>
<div class="p-3 mb-2 bg-info text-white">.bg-info</div>
<div class="p-3 mb-2 bg-light text-dark">.bg-light</div>
<div class="p-3 mb-2 bg-dark text-white">.bg-dark</div>
<div class="p-3 mb-2 bg-white text-dark">.bg-white</div>

            <div class="customJumbotron">
                <div class="p-3 mb-2 bg-primary text-white">.bg-primary</div>
<div class="p-3 mb-2 bg-secondary text-white">.bg-secondary</div>
<div class="p-3 mb-2 bg-success text-white">.bg-success</div>
<div class="p-3 mb-2 bg-danger text-white">.bg-danger</div>
<div class="p-3 mb-2 bg-warning text-dark">.bg-warning</div>
<div class="p-3 mb-2 bg-info text-white">.bg-info</div>
<div class="p-3 mb-2 bg-light text-dark">.bg-light</div>
<div class="p-3 mb-2 bg-dark text-white">.bg-dark</div>
<div class="p-3 mb-2 bg-white text-dark">.bg-white</div>
            </div>
<div class="panel-heading">
    Esempio Uno 
</div>
<div class="form-inline">                                    
<div class="form-group">
    <label><b>Test Text</b></label>
    <asp:TextBox TextMode="MultiLine" class="form-control" runat="server" ID="tTest1"   ></asp:TextBox>
</div>

<div class="form-group">
    <label><b>Test DropDown</b></label>
         <asp:DropDownList multiple="multiple" id="ddTest1" runat="server" class="form-control chosen-select">
            <asp:ListItem Selected="True" Value="0"> Zero </asp:ListItem>
            <asp:ListItem Value="1"> Uno </asp:ListItem>
            <asp:ListItem Value="2"> Due </asp:ListItem>
            <asp:ListItem Value="3">  Tre </asp:ListItem>
            <asp:ListItem Value="4"> Quattro </asp:ListItem>
         </asp:DropDownList>
</div>
</div>
     <hr /> 
<div class="panel-heading">
    Esempio Due 
</div>
<div class="form-group">
    <label><b>Test Text</b></label>
    <asp:TextBox TextMode="MultiLine" class="form-control" runat="server" ID="TextBox1"   ></asp:TextBox>
</div>

<div class="form-group">
    <label><b>Test DropDown</b></label>
         <asp:DropDownList multiple="multiple" id="DropDownList1" runat="server" class="form-control chosen-select">
            <asp:ListItem Selected="True" Value="0"> Zero </asp:ListItem>
            <asp:ListItem Value="1"> Uno </asp:ListItem>
            <asp:ListItem Value="2"> Due </asp:ListItem>
            <asp:ListItem Value="3">  Tre </asp:ListItem>
            <asp:ListItem Value="4"> Quattro </asp:ListItem>
         </asp:DropDownList>
</div>
<hr />
<div class="panel-heading">
    Esempio Tre 
</div>
<div class="form-group">
    <label><b>Test Text</b></label>
    <asp:TextBox class="form-control" runat="server" ID="TextBox2"   ></asp:TextBox>
</div>

<div class="form-group">
    <label><b>Test DropDown</b></label>
         <asp:DropDownList id="DropDownList2" runat="server" class="form-control chosen-select">
            <asp:ListItem Selected="True" Value="0"> Zero </asp:ListItem>
            <asp:ListItem Value="1"> Uno </asp:ListItem>
            <asp:ListItem Value="2"> Due </asp:ListItem>
            <asp:ListItem Value="3">  Tre </asp:ListItem>
            <asp:ListItem Value="4"> Quattro </asp:ListItem>
         </asp:DropDownList>
</div>
<hr />
<div class="panel-heading">
    Esempio Quattro 
</div>
<div class="form-inline">                                    
<div class="form-group">
    <label><b>Test Text</b></label>
    <asp:TextBox class="form-control" runat="server" ID="TextBox3"   ></asp:TextBox>
</div>

<div class="form-group">
    <label><b>Test DropDown</b></label>
         <asp:DropDownList id="DropDownList3" runat="server" class="form-control chosen-select">
            <asp:ListItem Selected="True" Value="0"> Zero </asp:ListItem>
            <asp:ListItem Value="1"> Uno </asp:ListItem>
            <asp:ListItem Value="2"> Due </asp:ListItem>
            <asp:ListItem Value="3">  Tre </asp:ListItem>
            <asp:ListItem Value="4"> Quattro </asp:ListItem>
         </asp:DropDownList>
</div>
</div>
            <hr />
<div class="panel-heading">
    Esempio Cinque
</div>
<div class="form-inline">
<div class="form-group">
    <asp:RadioButtonList runat="server" ID="rb1"  RepeatDirection="Vertical">
        <asp:ListItem Text="Primo" Value="0" />
        <asp:ListItem Text="Secondo" Value="1" />  
    </asp:RadioButtonList>
</div>
</div>

            <hr />
<div class="form-group">
    <label><b>Primo Test CheckBox</b></label>
    <asp:CheckBox ID="CheckBox1" runat="server" />

    <label><b>Secondo Test CheckBox</b></label>
    <asp:CheckBox ID="CheckBox2" runat="server" />
</div>
<div class="form-group">
    <label><b>Test CheckBoxList</b></label>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
         <asp:ListItem>Item 1</asp:ListItem>
        <asp:ListItem>Item 2</asp:ListItem>
        <asp:ListItem>Item 3</asp:ListItem>
        <asp:ListItem>Item 4</asp:ListItem>
    </asp:CheckBoxList>

</div>

</div>            
</div>                        
                                
<div class="row">
<div class="col-lg-12">
                                        
<asp:Button ID="btnRicerca" runat="server" OnCommand="ProcessCommand" CommandName="LoadTable" Text="Esegui" CssClass="btn btn-dark" OnClientClick="aspnetForm.target ='_self';"/>

</div>
</div> 

<hr />

<div class="row" runat="server" id="divAzioni" visible="true"> 
<div class="col-lg-12 text-center"  style="margin-bottom:10px" >
    <asp:Button ID="btnInserimenti" runat="server" OnCommand="ProcessCommand" CommandName="FiltraInserimenti" Text="Test numero uno" CssClass="btn btn-w-m btn-primary" />                                      
    <asp:Button ID="btnModifiche" runat="server" OnCommand="ProcessCommand" CommandName="FiltraModifiche" Text="Test numero due" CssClass="btn btn-w-m btn-primary  " />                                      
    <asp:Button ID="btnCessazioni" runat="server" OnCommand="ProcessCommand" CommandName="FiltraCessazioni" Text="Test numero tre" CssClass="btn btn-w-m btn-primary  " />
                                       
</div>  
</div>     
                        </div>  

                              
                    </div>  
                        </asp:Panel>
                <div class="row">
                <div class="col-lg-12 text-center"  style="margin-bottom:10px" visible="true" id="divNuovaScheda" runat="server">
                    <asp:Button ID="Button1" runat="server" OnCommand="ProcessCommand" CommandName="nuovaScheda" Text="Pagina di test" CssClass="btn btn-primary btn-block" Visible ="true" />  
                </div>

                           

                </div>

                <div class="panel panel-success" runat="server" >
                    <div class="panel-heading">
                            Elenco test
                    </div>
                    <div class="panel-body scroll-x" >
                        <asp:GridView ID="Gv" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" 
                        AllowPaging="true" PageSize="20" 
                                OnRowDataBound="GV_RowDataBound">
                                    <Columns>
                    <asp:BoundField DataField="t_name" HeaderText="Titolo" ItemStyle-HorizontalAlign="Left"  />
                    <asp:BoundField DataField="t_desc" HeaderText="Descrizione" ItemStyle-HorizontalAlign="Left"  />
                    <asp:BoundField DataField="i_master_id" HeaderText="Master" ItemStyle-HorizontalAlign="Left"  />
                    <asp:BoundField DataField="t_CreatedOn" HeaderText="Data inizio" ItemStyle-HorizontalAlign="Left"  />
                </Columns>
                        </asp:GridView>
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

