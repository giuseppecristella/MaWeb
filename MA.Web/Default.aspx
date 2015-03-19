<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="Default" Title="Matera Arredamenti - Mobili per la vita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="shadowbox-3.0.3/shadowbox.css">

    <script type="text/javascript" src="shadowbox-3.0.3/shadowbox.js"></script>

    <script src="js/prova_nuovo_slider.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(function () {
                // open a welcome message as soon as the window loads
            });
            if ($('#nuovo_slider_prova ul li').size() > 0) { jQuery("#nuovo_slider_prova ul").bxSlider({ infiniteLoop: true, pager: false, controls: true, auto: true, autoHover: true, speed: '800', pause: '4000', displaySlideQty: 4, moveSlideQty: 1 }); }
            $(".slider").slideshow({
                width: 960,
                height: 380,
                delay: 5500, // in ms
                transition: 'fade'/*['barLeft', 'barRight', 'rain', 'fountain']*/
            });
            //sliderLoghi_1
            $("#sliderLoghi_1").slideshow({
                width: 168,
                height: 150,
                delay: 8500, // in ms   
                transition: 'fade'/*['barLeft', 'barRight', 'rain', 'fountain']*/
            });
            $("#sliderLoghi_2").slideshow({
                width: 168,
                height: 150,
                delay: 8500, // in ms   
                transition: 'fade'/*['barLeft', 'barRight', 'rain', 'fountain']*/
            });
            $("#sliderLoghi_3").slideshow({
                width: 168,
                height: 150,
                delay: 8500, // in ms
                transition: 'fade'/*['barLeft', 'barRight', 'rain', 'fountain']*/
            });
            $("#sliderLoghi_4").slideshow({
                width: 168,
                height: 150,
                delay: 8500, // in ms
                transition: 'fade'/*['barLeft', 'barRight', 'rain', 'fountain']*/
            });
            $("#sliderLoghi_5").slideshow({
                width: 168,
                height: 150,
                delay: 8500, // in ms
                transition: 'fade'/*['barLeft', 'barRight', 'rain', 'fountain']*/
            });
        });
    </script>

    <script src="js/jquery.prettyPhoto.js" type="text/javascript"></script>

    <script type="text/javascript">
        Shadowbox.init({
            // let's skip the automatic setup because we don't have any
            // properly configured link elements on the page
            skipSetup: true
        });
    </script>

    <%--<script type="text/javascript">
        window.onload = function() {
            // open a welcome message as soon as the window loads
            Shadowbox.open({
                content: '<div style="background:#fff;width:350px;height:350px;" id="welcome-msg">Welcome to my website!</div>',
                player: ".aspx",
                title: "Welcome",
                height: 350,
                width: 350
            });
        };
    </script>--%>

    <script type="text/javascript">
        jQuery.noConflict()(function ($) {
            $(document).ready(function () {
                $("a[rel^='prettyPhoto']").prettyPhoto({
                    opacity: 0.80,
                    hideflash: false, modal: true, default_width: 710, default_height: 525
                });
                $('div.portfolio-container ul.portfolio-container-items li').show();
                $('div.portfolio-container').slider
            ({
                nav: 'ul.slider-nav',
                items: 'ul.portfolio-container-items',
                wrapper_class: 'clients-wrapper',
                visible: 5,
                auto_delay: 400,
                slide: 4
            });
            });
        });
    </script>

</asp:Content>
<asp:Content ID="ContentNavigoss" runat="server" ContentPlaceHolderID="ContentPlaceHolderNavigoss">
    <ul>
        <li><a href="azienda.aspx">Azienda</a></li>
        <li><a href="servizi.aspx">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a href="promozioni.aspx">Promozioni</a></li>
        <li><a href="eventi.aspx">Eventi</a></li>
        <li><a href="ListaNozze.aspx">Lista Nozze</a></li>
        <li><a style="font-weight: bold;" href="javascript:scegliShop();">Shop</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <!--WRAPPER-->
    <div class="wrapper_pepp">
        <div id="container">
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <%--  INIZIO POPUP--%>
                <div style="display: none; width: 800px; line-height: 20px;" id="divpopupShop" class="__inner-content">
                    <a href="shop/Catalogo.aspx">
                        <img src="images/pop-up.png" /></a>
                </div>
                <div style="display: none; line-height: 20px;" runat="server" id="divpopup" class="inner-content">
                    <p style="border-bottom: none;" class="intro-pages">
                        <asp:Repeater ID="Repeater1" DataSourceID="objPost" runat="server">
                            <ItemTemplate>
                                <img src='Handler.ashx?Path=~/<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>&W_=710&H_=210'
                                    alt=" " />
                            </ItemTemplate>
                        </asp:Repeater>
                    </p>
                    <div class="horizontal-line">
                    </div>
                    <asp:Repeater ID="rptBlogPost" DataSourceID="objPost" runat="server">
                        <ItemTemplate>
                            <p>
                                <h3>
                                    <%#Eval("Titolo") %>
                                </h3>
                            </p>
                            <p style="text-align: justify;">
                                <%# Eval("Testo") %>
                            </p>
                            <p style="text-align: right;">
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal runat="server" ID="ltrSocial" Text=""></asp:Literal>
                    <!--PAGINATION ENDS-->
                </div>
                <%--  FINE POPUP--%>
                <%--  <a href="http://www.apple.com?iframe=true&width=500&height=250" rel="prettyPhoto[iframes]">Apple.com</a>--%>
                <div class="one">
                    <div class="clear-line">
                    </div>
                    <div style="height: 10px; background-image: url('images/footer_shadow.png'); background-position: bottom; background-repeat: no-repeat;"
                        class="slider">
                        <asp:Repeater runat="server" ID="rptFotoHOME" DataSourceID="objFotoHOME">
                            <ItemTemplate>
                                <div>
                                    <%-- <div class="caption">
                                        <%# Eval("Caption") %>
                                    </div>--%>
                                    <%--    <a href="_index.aspx"></a>--%>
                                    <img src='Handler.ashx?PhotoID=<%# Eval("PhotoID") %>' title="" alt="" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:ObjectDataSource ID="objFotoHOME" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetPhotoSliderHome" TypeName="PhotoManager"></asp:ObjectDataSource>
                    </div>
                </div>
                <div class="one-fifth">
                    <div id="sliderLoghi_1">
                        <div>
                            <a href='http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_82/Page_1/Ambient_-1_Type_-1_Designer_-1'>
                                <img src="img/armobil_logo.png" alt="" width="168" height="145" class="portfolio-img pretty-box" />
                            </a>
                        </div>
                        <div>
                            <a href='http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_85/Page_1/Ambient_-1_Type_-1_Designer_-1'>
                                <img src="img/birex_logo.png" alt="" width="168" height="145" class="portfolio-img pretty-box" />
                            </a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_97/Page_1/Ambient_-1_Type_-1_Designer_-1">
                                <img src="img/bontempi_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_409/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/piombini_logo.jpg" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_133/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/callesella_logo.jpg" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                    </div>
                </div>
                <div class="one-fifth">
                    <div id="sliderLoghi_2">
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_109/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/calligaris_logo.jpg" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_116/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/cattelan_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_127/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/ciacci_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_140/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/colombini_logo.png" alt=" " width="168" height="145" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_170/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/doimo_city_logo.png" alt=" " width="168" height="145" /></a>
                        </div>
                    </div>
                </div>
                <div class="one-fifth">
                    <div id="sliderLoghi_3">
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_171/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/doimo_salotti_logo.png" alt=" " width="168" height="145" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_11/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/dorelan_logo.jpg" alt=" " width="168" height="145" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_2262/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/falmec_logo.png" alt=" " width="168" height="145" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_208/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/febal_logo.jpg" alt=" " width="168" height="145" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_2267/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/novamobili_logo.jpg" alt=" " width="168" height="145" /></a>
                        </div>
                    </div>
                </div>
                <div class="one-fifth">
                    <div id="sliderLoghi_4">
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_408/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/pianca_logo.png" alt=" " width="168" height="145" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_421/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/presotto_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_1769/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/riflessi_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_472/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/slamp_logo.jpg" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_475/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/snaidero_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                    </div>
                </div>
                <div class="one-fifth last">
                    <div id="sliderLoghi_5">
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_1579/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/stilema_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_2236/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/stones_logo.jpg" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>
                        <div>
                            <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_1788/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                class="portfolio-item-preview">
                                <img src="img/stosa_logo.png" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                        </div>

                    </div>
                </div>
                <div class="horizontal-line">
                </div>
                <div id="portfolio">
                    <div class="one-third">
                        <a href="javascript:scegliShop();" class="tasto shop"></a>
                    </div>
                    <div class="one-third">
                        <a href="#" class="tasto magazine"></a>
                    </div>
                    <div class="one-third last">
                        <a href="http://www.materaservice.it" target="_blank" class="tasto traslochi"></a>
                    </div>
                    <div class="line-separator"></div>
                    <div class="one-third">
                        <a href="javascript:scegliShop();" class="tasto shop"></a>
                    </div>
                    <div class="one-third">
                        <a href="#" class="tasto magazine"></a>
                    </div>
                    <div class="one-third last">
                        <a href="http://www.materaservice.it" target="_blank" class="tasto traslochi"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- CONTAINER ENDS-->
    <asp:ObjectDataSource ID="objPost" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetNewsPopUp" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter"></asp:ObjectDataSource>
</asp:Content>
