<%@ Page Language="C#" MasterPageFile="~/zrchiptuningv2.Master" AutoEventWireup="true" CodeBehind="customPage.aspx.cs" Inherits="zrchiptuning.customPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="lblHeader" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-2 leftColumn">
            <div class="row">
                <div class="col-lg-12 padding-0">
                    <a href="/chip-tuning/povecanje-snage"><h2>Povećanje snage</h2>
                        <img src="/images/taho.jpg" class="img-responsive" />
                    </a>
                    <p>Softverska optimizacija centralne jedinice. Masimalna snaga za veće uživanje u vožnji.</p>
                    <a href="/chip-tuning/smanjenje-potrosnje-goriva"><h2>Smanjenje potrošnje</h2>
                        <img src="/images/lowerconsuption.jpg" class="img-responsive" />
                    </a>
                    <p>Efikasnija i jeftinija vožnja uz smanjenje potrošnje do <strong>15%</strong></p>
                    <a href="/chip-tuning/eko-chip-tuning-kamioni"><h2>Eko chiptuning</h2>
                        <img src="/images/trucktuning.jpg" class="img-responsive" />
                    </a>
                    <p>Veći profit uz smanjenje troškova</p>
                </div>
            </div>
        </div>
        
        <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12 mainContent" id="customPage">
            <h1 class="heading"><asp:Literal ID="lblHeading" runat="server"></asp:Literal></h1>
        
            <div id="divContent" runat="server"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolderFooter" runat="server">
    <asp:Literal ID="lblFooter" runat="server"></asp:Literal>
</asp:Content>
