<%@ Page Title="" Language="C#" MasterPageFile="~/zrchiptuningV2.Master" AutoEventWireup="true" CodeBehind="engine.aspx.cs" Inherits="zrchiptuning.engine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-2 leftColumn hidden-xs">
            <div class="row">
                <div class="col-lg-12 padding-0">
                    <h2><asp:Literal ID="lblModel" runat="server"></asp:Literal></h2>
                    <asp:HiddenField ID="lblType" runat="server" />
                    <asp:HiddenField ID="lblManufacturerUrl" runat="server" />
                    <asp:HiddenField ID="lblModelUrl" runat="server" />
                    <asp:Repeater ID="rptEngines" runat="server" OnItemDataBound="rptEngines_ItemDataBound">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="lnkEngine" runat="server" NavigateUrl='<%#Eval("url") %>' Text='<%#Eval("name") + " " + Eval("powerKw") + "kw" %>'></asp:HyperLink>
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
            <div class="row margin-top-1">
                <div class="col-lg-6">
                    <h1 class="heading"><asp:Literal ID="lblEngine" runat="server"></asp:Literal></h1>
                </div>
                <div class="col-lg-6">
                    <asp:Image ID="imgModel" runat="server" CssClass="img-responsive pull-right" />
                </div>
            </div>
            <div class="row">
                
            </div>
            <div class="stage">
                <h2>Stage 1</h2>
                
                <div class="row margin-top-1">
                    <div class="col-lg-12">
                        <asp:GridView ID="dgvEngine" runat="server" AutoGenerateColumns="false" CssClass="table engine table-condensed table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Parametri">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParameter" runat="server" Text='<%#Eval("parameter") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fabrički" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSeries" runat="server" Text='<%#Eval("series") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chiptuning" ItemStyle-CssClass="bold" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChiptuning" runat="server" Text='<%#Eval("chiptuning") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razlika" ItemStyle-CssClass="red bold" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDifference" runat="server" Text='<%#Eval("difference") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <p><strong>Stage 1</strong> chip tuning je klasičan chip tuning koji se sastoji u remapiranju fabričkih mapa, odnosno zameni
                            sa optimizovanim mapama. Motor ostaje u granicama ekoloških normi i optimalne potrošnje, ne dolazi do opterećenja
                            motora i turbo punjača i do njihovog većeg habanja. Ova vrsta chiptuninga može da se primenjuje i na motorima koji su
                            prešli dosta kilometara, a održavanje motora se svodi na fabričko održavanje.
                        </p>
                    </div>
                </div>
            </div>
            <div class="stage" id="stage2" runat="server">
                <h2 id="lblStage2" runat="server">Stage 2</h2>

                <div class="row margin-top-1">
                    <div class="col-lg-12">
                        <asp:GridView ID="dgvEngineStage2" runat="server" AutoGenerateColumns="false" CssClass="table engine table-condensed table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Parametri">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParameter" runat="server" Text='<%#Eval("parameter") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fabrički" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSeries" runat="server" Text='<%#Eval("series") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chiptuning" ItemStyle-CssClass="bold" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChiptuning" runat="server" Text='<%#Eval("chiptuning") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razlika" ItemStyle-CssClass="red bold" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDifference" runat="server" Text='<%#Eval("difference") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <p><strong>Stage 2</strong> chip tuning je namenjen onima koji žele više snage iz motora. Da bi se uradio <strong>stage 2</strong>
                            chip tuning potrebno je da motor i turbo punjač budu u savršenom stanju. Ovaj vid chiptuning-a uključuje i zamenu
                            pojedinih mehaničkih komponenti, pored klasičnog remapiranja centralne jedinice. Koje komponente se menjaju, zavisi od
                            modela.

                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
