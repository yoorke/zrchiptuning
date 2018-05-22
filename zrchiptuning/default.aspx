<%@ Page Language="C#" MasterPageFile="~/zrchiptuningV2.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="zrchiptuning.defaultV2" Title="Zrchiptuning - Chip tuning poslednje generacije" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-2 leftColumn">
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
                    <h2>Kontakt</h2>
                        <a href="/kontakt">
                            <img src="/images/contact.jpg" />
                        </a>
                    <h2>Facebook</h2>
                    <div class="fb-page" data-href="https://www.facebook.com/CHIP-Tuning-Zrenjanin-1472675699681819" data-width="180" data-height="400" data-small-header="true" data-adapt-container-width="true" data-hide-cover="true" data-show-facepile="true" data-show-posts="false">
                        <div class="fb-xfbml-parse-ignore"><blockquote cite="https://www.facebook.com/CHIP-Tuning-Zrenjanin-1472675699681819"><a href="https://www.facebook.com/CHIP-Tuning-1472675699681819">zrchiptuning</a></blockquote></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-10 mainContent">
            <div class="row padding-top-1 padding-bottom-1">
                <div class="col-lg-12">
                    <p class="heading">
                        <strong>ZrChipTuning</strong> centar - nudimo Vam softversku optimizaciju i <strong>chip tuning</strong> poslednje generacije za putnička vozila, 
                        kamione, komercijalna vozila i van-ove. <strong>Chip tuning</strong> visokog kvaliteta i ECO-optimizacija obezbediće Vam više snage,
                        manju potrošnju, kao i neprocenjivo uživanje u vožnji.
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <!--<ul>-->
                        <div class="h2Wrapper">
                            <a href="/chip-tuning/povecanje-snage"><h2 class="heading">Povećanje snage motora</h2></a>
                            <img src="/images/gauges1.png" />
                        </div>
                        <p>
                            Kada se spomene <strong>chip tuning</strong> prvo se pomisli na povećanje snage motora.
                        </p>
                        <p>
                            Optimizacijom mapa koje se nalaze u centralnoj jedinici motora, postiže se povećanje obrtnog momenta, kao i
                            povećanje snage motora do 30%, a sve to u granicama koje je propisao proizvođač vozila.
                        </p>
                        <p class="more"><a href="/chip-tuning/povecanje-snage">Pročitajte više...</a></p>
                        <!--<p>
                            Sve to za posledicu ima bolje ubrzanje na nižem broju obrtaja, dok se pri višim obrtajima oseti dodatna snaga
                            motora koja omogućava postizanje veće maksimalne brzine. A sve to znači više uživanja u vožnji i više rezerve
                            snage.
                            <!--Our long-term experience and success in the field of software development and software optimization for 
                            petrol and diesel engines guarantees the highest quality. Improvement and adjustment of our own software 
                            development is performed in our state of the art research and development centre.-->
                        <!--</p>-->
                        <div class="h2Wrapper">
                            <a href="/chip-tuning/smanjenje-potrosnje-goriva"><h2 class="heading">Manja potrošnja goriva - ECO chip tuning</h2></a>
                            <img src="/images/gauges1.png" />
                        </div>
                        <p>
                            Kako se postiže smanjenje potrošnje goriva?
                            <ul>
                                <li>Povećanjem obrtnog momenta na nižim obrtajima motora</li>
                                <li>Optimizacijom količine usisanog vazduha</li>
                                <li>Optimizacijom procesa sagorevanja</li>
                            </ul>
                            <p class="more"><a href="/chip-tuning/smanjenje-potrosnje-goriva">Pročitajte više...</a></p>
                            <!--When using mcchip-dkr eco the foremost thing is, of course, lower fuel consumption!
                            How do we achieve fuel consumption reduction?
                            Due to increased engine torque at lower rotating speed.
                            Due to air masses optimization.
                            Due to combustion process optimization.-->
                        </p>
                        <!--<div class="h2Wrapper">
                            <h2 class="heading">Povećana profitabilnost</h2>
                            <img src="/images/gauges1.png" />
                        </div>
                        <p>
                            Your truck or your fleet of trucks has enormous potential savings that can be enabled with the help of truck 
                            ECO Tuning, and that brings fuel savings up to 15%. It becomes even more important to recognize that fact
                            and act accordingly, because the costs of transport companies are steadily growing. Not just fuel costs, but 
                            also costs for other inventory materials, increased road tolls, etc. day by day add complexity to the work in 
                            this industry. Due to optimization of truck fuel consumption, you can use your vehicle more effectively and 
                            achieve greater power at low rotating speed, which leads to lower fuel consumption and therefore means economy 
                            from 2 to 5 litres per 100 km. 

                            We will be happy to explain to you in more detail the principle of functioning by phone 0 22 56/69 95 67 or answer your questions by E-Mail. 
   
                            Click here to go to our database on optimization of truck fuel consumption.
                        </p>-->
                        <%--<div class="h2Wrapper">
                            <h2>ECO chiptuning</h2>
                            <img src="/images/gauges1.png" />
                        </div>
                        <p>
                            dwd wedewd wedwed wedew
                        </p>--%>
                    <!--</ul>-->
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="fpBox">
                        <h2 class="box">Dyno Test</h2>
                        <a href="/dyno-test">
                            <img src="/images/dynotest.jpg" class="img-responsive" alt="Dyno test" />
                        </a>
                        <p class="desc">ZrChipTuning pruža mogućnost merenja snage vozila na dinamometru (dyno) novije generacije.</p>
                        <p class="desc">Jedna smo od dve firme u Srbiji koje imaju mogućnost da izmere snagu na vozilima sa <strong>4x4</strong> pogonom.</p>
                        <%--<div class="soon">
                            Uskoro
                        </div>--%>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="fpBox">
                            <h2 class="box">Pronađi vozilo</h2>
                            <div class="fpBoxContent">
                                <div class="pleaseWait" id="findVehiclePleaseWait" style="display:none"><img src="/images/loader.gif" /></div>
                                <div role="form" class="form-horizontal">
                                    <div class="form-group">
                                        <label for="cmbVehicleType" class="control-label col-sm-3">Tip:</label>
                                        <div class="col-sm-9">
                                            <select name="cmbVehicleType" id="cmbVehicleType" class="form-control">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmbManufacturer" class="control-label col-sm-3">Marka:</label>
                                        <div class="col-sm-9">
                                            <select name="cmbManufacturer" id="cmbManufacturer" class="form-control">
                                                <option>Audi</option>
                                                <option></option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmbModel" class="control-label col-sm-3">Model:</label>
                                        <div class="col-sm-9">
                                            <select name="cmbModel" id="cmbModel" class="form-control">
                                                <option></option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmbEngine" class="control-label col-sm-3">Motor:</label>
                                        <div class="col-sm-9">
                                            <select name="cmbEngine" id="cmbEngine" class="form-control">
                                        
                                            </select>
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
<asp:Content ContentPlaceHolderID="contentPlaceHolderFooter" runat="server">
    <script src="/js/zrchiptuning.js"></script>
</asp:Content>