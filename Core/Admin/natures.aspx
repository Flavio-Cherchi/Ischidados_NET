<%@ Page Language="C#" AutoEventWireup="true" Inherits="natures" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="natures.aspx.cs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="container-lg animate__animated animate__fadeIn">
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
    <div class="col-lg-6 text-center"  style="margin-bottom:10px" visible="true" id="div1" runat="server">
        <asp:Button ID="btnNatures" runat="server" OnCommand="ProcessCommand" CommandName="natures" Text="Indoli e abilità" CssClass="btn btn-success btn-block"/>  
    </div>
    <div class="col-lg-6 text-center"  style="margin-bottom:10px" visible="true" id="div3" runat="server">
        <asp:Button ID="btnTraits" runat="server" OnCommand="ProcessCommand" CommandName="traits" Text="Tratti" CssClass="btn btn-success btn-block"/>  
    </div>
</div>
 <br />
<div class="animate__animated animate__headShake">
    <div class="row">
<asp:Repeater ID="RepNatures" runat="server" OnItemCommand="Repeater_ItemCommand">
    
    <ItemTemplate>
        <div class="col-lg-3 col-md-6 col-sm-12" id="divImg" >
<asp:HiddenField ID="hidI_nature_id" runat="server" Value='<%#Eval("i_nature_id") %>' />


        <asp:LinkButton runat="server" id="btnHidden" OnCommand="ProcessCommand" CommandName="selectSkillsPerNature"  >            

            
            <center><img src='<%# "https://www.ischidados.it" + Eval("t_url") %>' runat="server" class="imgListed2 animate__animated" /></center>


            <br />
            <center><b><%#Eval("t_nature") %></b></center>
            </asp:LinkButton> 

            <br /><br />
            </div>
            
    </ItemTemplate>
</asp:Repeater>
    </div>
</div>
 

<div class="panel-heading"></div>
<div class="panel-body scroll-x" >
        <asp:GridView ID="GvSkills" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" Visible="false"
        AllowPaging="true" PageSize="20" >
            <Columns>
<asp:BoundField DataField="t_skill" HeaderText="Abilità" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="t_nature" HeaderText="Indole d'appartenenza" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="i_value_start" HeaderText="Valore iniziale" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="i_value_min" HeaderText="Valore minimo" ItemStyle-HorizontalAlign="Left"  />
<asp:BoundField DataField="i_value_max" HeaderText="Valore massimo" ItemStyle-HorizontalAlign="Left"  />

            </Columns>
        </asp:GridView>
</div>
<div class="panel-heading"></div>
<div class="panel-body scroll-x" >
        <asp:GridView ID="GvTraits" runat="server" CssClass="table table-bordered table-striped table-dark" AutoGenerateColumns="false" Visible="false" 
        AllowPaging="true" PageSize="20" >
            <Columns>
<asp:BoundField DataField="t_trait" HeaderText="Tratto" ItemStyle-HorizontalAlign="Left"  />
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

</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent"> 


</asp:Content>
