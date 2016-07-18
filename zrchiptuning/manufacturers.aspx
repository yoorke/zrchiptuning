<%@ Page Title="" Language="C#" MasterPageFile="~/zrchiptuningV2.Master" AutoEventWireup="true" CodeBehind="manufacturers.aspx.cs" Inherits="zrchiptuning.manufacturers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-2 leftColumn hidden-xs">
            <div class="row">
                <div class="col-lg-12 padding-0">
                    <h2>Kategorije vozila</h2>
                    <ul>
                        <li>
                            <img src="/images/cars.gif" class="hidden-sm" />
                            <a href="/vozila/putnicka">Putnička</a>
                        </li>
                        <li>
                            <img src="/images/suv.gif" class="hidden-sm" />
                            <a href="/vozila/suv">SUV</a>
                        </li>
                        <li>
                            <img src="/images/trucks.gif" class="hidden-sm" />
                            <a href="/vozila/kamioni">Kamioni</a>
                        </li>
                        <li>
                            <img src="/images/comercial.gif" class="hidden-sm" />
                            <a href="/vozila/komercijalna">Komercijalna</a>
                        </li>
                        <li>
                            <img src="/images/motorcycles.gif" class="hidden-sm" />
                            <a href="/vozila/motocikli">Motocikli</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div><!--leftColumn-->
        <div class="col-sm-10 mainContent col-xs-12">
            <h1 class="heading"><asp:Literal ID="lblTypeName" runat="server"></asp:Literal></h1>
            <div class="row margin-top-1 margin-bottom-1">
                <asp:Repeater ID="rptManufacturers" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-2 thumb">
                            <asp:HyperLink ID="lnkManufacturer" runat="server" NavigateUrl='<%#Page.Request.RawUrl + "/" + Eval("url") %>' CssClass="thumbnail">
                                <asp:Image ID="imgManufacturer" runat="server" ImageUrl='<%# "/images/car-logos/" + Eval("imageUrl").ToString().Substring(0, Eval("imageUrl").ToString().IndexOf(".png")) + "/" + Eval("imageUrl") %>' CssClass="img-responsive" />
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div><!--mainContent-->
    </div><!--row-->
</asp:Content>
