<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="zrchiptuning.administrator._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1>Admin panel</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="btnLoadModels" runat="server" OnClick="btnLoadModels_Click" Text="Load"/>
                <asp:Button ID="btnLoadEngines" runat="server" OnClick="btnLoadEngines_Click" Text="Load" />
                <asp:Button ID="btnCreateSitemap" runat="server" OnClick="btnCreateSitemap_Click" />
            </div>
        </div>
    </div>
</asp:Content>
