<%@ Page Title="" Language="C#" MasterPageFile="~/zrchiptuningV2.Master" AutoEventWireup="true" CodeBehind="engines.aspx.cs" Inherits="zrchiptuning.engines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-2 leftColumn hidden-xs">
            <div class="row">
                <div class="col-lg-12 padding-0">
                    <h2><asp:Literal ID="lblManufacturer" runat="server"></asp:Literal></h2>
                    <asp:HiddenField ID="lblType" runat="server" />
                    <asp:HiddenField ID="lblManufacturerUrl" runat="server" />
                    <asp:Repeater ID="rptModels" runat="server" OnItemDataBound="rptModels_ItemDataBound">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="lnkModel" runat="server" NavigateUrl='<%#Eval("url") %>' Text='<%#Eval("name") %>'></asp:HyperLink>
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
            <div class="row">
                <div class="col-lg-6">
                    <h1 class="heading"><asp:Literal ID="lblModel" runat="server"></asp:Literal></h1>
                </div>
                <div class="col-lg-6">
                    <asp:Image ID="imgModel" runat="server" CssClass="img-responsive pull-right" />
                </div>
            </div>
            <%--<asp:Repeater ID="rptEngines" runat="server">
                <ItemTemplate>
                    <div class="col-sm-2 thumb">
                        <asp:HyperLink ID="lnkEngine" runat="server" NavigateUrl='<%#Page.Request.RawUrl + "/" + Eval("url") %>'>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>--%>
            <asp:GridView ID="dgvEngines" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed table-striped table-hovered margin-top-1 engines">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblEngineID" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motor">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkEngine" runat="server" NavigateUrl='<%#Page.Request.RawUrl + "/" + Eval("url") %>'>
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Radna zapremina" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblCapacity" runat="server" Text='<%#Eval("capacity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Snaga" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblPower" runat="server" Text='<%#Eval("powerKw") + " kW/" + Eval("powerKs") + "ks" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkEngine" runat="server" Text="Odaberi"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
