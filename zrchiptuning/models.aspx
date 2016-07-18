<%@ Page Title="" Language="C#" MasterPageFile="~/zrchiptuningV2.Master" AutoEventWireup="true" CodeBehind="models.aspx.cs" Inherits="zrchiptuning.models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-2 leftColumn hidden-xs">
            <div class="row">
                <div class="col-lg-12 padding-0">
                    <h2>Proizvođači</h2>
                    <asp:HiddenField ID="lblType" runat="server"></asp:HiddenField>
                    <asp:Repeater ID="rptManufacturers" runat="server" OnItemDataBound="rptManufacturers_ItemDataBound">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink NavigateUrl='<%#Eval("url") %>' Text='<%#Eval("name") %>' ID="lnkManufacturer" runat="server"></asp:HyperLink>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="col-sm-10 mainContent col-xs-12">
            <h1 class="heading"><asp:Literal ID="lblManufacturer" runat="server"></asp:Literal></h1>
            <div class="row margin-top-1 margin-bottom-1">
                <asp:Repeater ID="rptModels" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-2 text-center">
                            <asp:HyperLink ID="lnkModel" runat="server" NavigateUrl='<%#Page.Request.RawUrl + "/" + Eval("url") %>' CssClass="thumbnail">
                                <asp:Image ID="imgModel" runat="server" ImageUrl='<%#"/images/car-logos/" + Eval("manufacturerUrl") + "/" + "models/" + Eval("imageUrl") %>' CssClass="img-responsive" />
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
