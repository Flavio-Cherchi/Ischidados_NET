<%@ Page Language="C#" AutoEventWireup="true" Inherits="community" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false" CodeBehind="community.aspx.cs" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Breadcrumb" runat="server" ContentPlaceHolderID="BreadcrumbContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="hidSchedaDaCancellare" />
    <div class="wrapper wrapper_content">
        <div class="container-lg animate__animated">

            <div class="row">
                <div class="col-lg-12">
                    <div class="wrapper wrapper-content">
                        <div class="customBox">
                            <div class="customBox-content">

                                <div class="panel panel-primary">
                                    <div class="row">
                                        <div class="col-lg-6 text-center" style="margin-bottom: 10px">
                                            <asp:Label ID="lblError" runat="server" Visible="false" />
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-lg-6 text-center" style="margin-bottom: 10px"></div>
                                        <div class="col-lg-5 text-center" style="margin-bottom: 10px">
                                            <div class="form-inline">
                                                <label style="margin-right: 10px;"><b>Altezza</b></label>
                                                <asp:DropDownList ID="ddY" runat="server" class="form-control chosen-select">
                                                    <asp:ListItem Selected="True" Value="1"> 1 </asp:ListItem>
                                                    <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                    <asp:ListItem Value="3">  3 </asp:ListItem>
                                                    <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                    <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    <asp:ListItem Value="6"> 6 </asp:ListItem>
                                                    <asp:ListItem Value="7"> 7 </asp:ListItem>
                                                    <asp:ListItem Value="8"> 8 </asp:ListItem>
                                                    <asp:ListItem Value="9"> 9 </asp:ListItem>
                                                    <asp:ListItem Value="10"> 10 </asp:ListItem>
                                                </asp:DropDownList>

                                                <label style="margin-left: 10px; margin-right: 10px;"><b>Lunghezza</b></label>
                                                <asp:DropDownList ID="ddX" runat="server" class="form-control chosen-select">
                                                    <asp:ListItem Selected="True" Value="1"> 1 </asp:ListItem>
                                                    <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                    <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                    <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                    <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    <asp:ListItem Value="6"> 6 </asp:ListItem>
                                                    <asp:ListItem Value="7"> 7 </asp:ListItem>
                                                    <asp:ListItem Value="8"> 8 </asp:ListItem>
                                                    <asp:ListItem Value="9"> 9 </asp:ListItem>
                                                    <asp:ListItem Value="10"> 10 </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-1 text-center" style="margin-bottom: 10px">
                                            <asp:Button ID="btnInserimenti" runat="server" OnCommand="ProcessCommand" CommandName="create" Text="Crea" CssClass="btn btn-w-m btn-primary" />

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6 text-center" style="margin-bottom: 10px">
                                            <asp:GridView ID="gv" runat="server" ShowHeader="false"
                                                AutoGenerateColumns="false" EmptyDataText="No records Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Img">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("1") %>' Width="150"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Img">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("2") %>' Width="150" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Img">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("3") %>' Width="150" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Img">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("4") %>' Width="150" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Img">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image4" runat="server" ImageUrl='<%# Eval("5") %>' Width="150" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
    </div>



</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
</asp:Content>

