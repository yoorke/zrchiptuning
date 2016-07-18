<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.Master" AutoEventWireup="true" CodeBehind="loadData.aspx.cs" Inherits="zrchiptuning.administrator.loadData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <asp:DropDownList ID="cmbManufacturers" runat="server"></asp:DropDownList>
        <asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" />
        <asp:Button ID="btnLoadMcChip" runat="server" OnClick="btnLoadMcChip_Click" Text="Load from McChip" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolderFooter" runat="server">
</asp:Content>
