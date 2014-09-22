<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shadow.aspx.cs" Inherits="shadow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Matera Arredamenti - mobili per la vita</title>
    <meta name="google-site-verification" content="DlFMFUeCnP1k0kgsQVQP4RdC-InOjfP_Pbaz0u4hc78" />
    <meta name="keywords" content="matera arredamenti,arredamenti,matera arredamenti laterza, arredamenti laterza, arredamenti taranto, arredamenti uffici, mobili, mobili taranto, mobili laterza, arredamenti matera, arredamenti giardino " />
    <meta name="description" content="Soddisfare il cliente è il Nostro Primo Patrimonio, Vendiamo Qualità, Consulenza ed Emozioni." />
    <meta name="Distribution" content="Global" />
    <meta name="Author" content="Giovanni Matera" />
    <meta name="language" content="italian" />
    <meta name="robots" content="index,follow" />
    <asp:Literal runat="server" ID="ltrMetaFB"></asp:Literal>
    <!--CSS FILES STARTS-->
    <link rel="shortcut icon" type="image/gif" href="images/favicon.png" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/prettyPhoto.css" type="text/css" media="screen" />
    <link href="css/slider.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/jquery.slider.css" />
    <%--    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Crimson+Text:regular,regularitalic,600,600italic,bold,bolditalic'
        type='text/css' />--%>
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Droid+Sans:regular,regularitalic,600,600italic,bold,bolditalic'
        type='text/css' />
    <%-- <link href='http://fonts.googleapis.com/css?family=PT+Sans+Narrow:bold:400,700' rel='stylesheet' type='text/css'/>--%>
    <link href="css/delicious/stylesheet.css" rel="stylesheet" type="text/css" />
    <!--CSS FILES ENDS-->

    <script type="text/javascript">        document.getElementsByTagName('html')[0].className += ' js';</script>

    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>

    <script type="text/javascript" src="js/slider.js"></script>

    <script type="text/javascript" src="js/jquery.slider.js"></script>

    <script type="text/javascript" src="js/custom.js"></script>

    <script type="text/javascript">
        //<![CDATA[
        function load() {
            var Gmap = document.getElementById("Gmap");
            if (Gmap != null) {
                if (GBrowserIsCompatible()) {
                    var map = new GMap2(document.getElementById("Gmap"));
                    map.addControl(new GSmallMapControl());
                    map.addControl(new GMapTypeControl());
                    var center = new GLatLng(40.621861, 16.804956);
                    map.setCenter(center, 16);
                    // L'opzione title di Gmarker fa apparire una stringa al passaggio sul marker
                    var marker = new GMarker(center, { title: 'Matera Arredamenti' });
                    map.addOverlay(marker);
                    //	GEvent.addListener(marker, "click", function() {
                    marker.openInfoWindowHtml("<label><b>Matera Arredamenti</b><br><br>Via Selva San Vito, n. 23<Br />74014 - Laterza (TA) </label>");
                    //  });
                }
            }
        }
        //]]>
    </script>

    <script type="text/javascript">
        jQuery(document).ready(function($) {
            $(function() {
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

    <link rel="stylesheet" type="text/css" href="shadowbox-3.0.3/shadowbox.css">

    <script type="text/javascript" src="shadowbox-3.0.3/shadowbox.js"></script>

    <script type="text/javascript">
        Shadowbox.init({
            // let's skip the automatic setup because we don't have any
            // properly configured link elements on the page
            skipSetup: true
        });
    </script>

    <script type="text/javascript">
        function scegliShop() {
            Shadowbox.open({
                content: '<div style="margin:40px auto 0 auto;width:500px;text-align:center;"><h1>Quale Shop vuoi visitare?</h1></div><div class="dark"><a href="/shop/design.html"><img src="images/dark.png" alt="" border="0" /></a></div><div class="light"><a href="/shop/tradizione.html"><img src="images/light.png" alt="" border="0" /></a></div>',
                player: "html",
                title: "",
                height: 600,
                width: 960
            });
        }
          
    </script>

    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-12761769-1");
            pageTracker._trackPageview();
        } catch (err) { }</script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="background: #fff;" id="header_pattern">
    </div>
    <div class="head_bar">
        <div class="center">
            <a style="margin-top: -20px; background: #fff;" id="logo" title="Homepage" href="index.html">
                <img style="margin-left: auto; margin-right: auto;" src="img/logo_w.png" alt=" " /></a>
            <div id="main_navigation" style="float: left; margin-left: 10px; margin-top: 3px;"
                class="main-menu">
                <ul>
                    <li><a href="azienda.html">Azienda</a></li>
                    <li><a href="servizi.html">Servizi</a> </li>
                    <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
                    <li><a href="promozioni.html">Promozioni</a></li>
                    <li><a href="eventi.html">Eventi</a></li>
                    <li><a href="suggerimenti.html">Suggerimenti</a></li>
                    <li><a style="font-weight: bold;" href="javascript:scegliShop();">Shop</a></li>
                </ul>
            </div>
            <%--ICONE--%>
            <div style="text-align: left; float: left; margin-left: 55px;">
                <div style="margin-top: -8px;" class="social_icons">
                    <%--<a href="default.aspx" class="social-home">home</a>--%>
                    <a href="contattaci.html" class="social-mail">mail</a> <a href="shop/blog.html" class="social-blog">
                        blog</a> <a href="il nostro canale youtube.html" class="social-youtube">youtube</a>
                    <a target="_blank" href="http://www.facebook.com/matearredamenti" class="social-facebook">
                        Facebook</a>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="wrapper">
        <div style="border-bottom: 1px solid #fff;" id="header">
            <!--close one div-->
        </div>
        <div class="wrapper_pepp">
            <div id="container">
                <!-- MAIN CONTAINER -->
                <!-- HEADER ENDS-->
                <!--  HEADER ENDS-->
                <div id="content">
                    <div class="one">
                        <div class="clear-line">
                        </div>
                        <div style="height: 10px; background-image: url('images/footer_shadow.png'); background-position: bottom;
                            background-repeat: no-repeat;" class="slider">
                            <asp:Repeater runat="server" ID="rptPromozioni" DataSourceID="objPromo">
                                <ItemTemplate>
                                    <div>
                                        <div class="caption">
                                            <%# Eval("Descrizione") %>
                                        </div>
                                        <a href='PromoDettaglio.aspx?Id=<%# Eval("News_ID") %>'>
                                            <img src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>' alt="" />
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:ObjectDataSource ID="objPromo" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetEventiHome" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="5" Name="Tipo" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:Repeater runat="server" ID="rptFotoHOME" DataSourceID="objFotoHOME">
                                <ItemTemplate>
                                    <div>
                                        <%-- <div class="caption">
                                        <%# Eval("Caption") %>
                                    </div>--%>
                                        <%--    <a href="_index.html"></a>--%>
                                        <img src='Handler.ashx?PhotoID=<%# Eval("PhotoID") %>' title="" alt="" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:ObjectDataSource ID="objFotoHOME" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetPhotoSliderHome" TypeName="PhotoManager"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <div id="portfolio">
                        <!-- COLUMNS CONTAINER STARTS-->
                        <!-- INTRO DIV STARTS-->
                        <!-- INTRO ENDS-->
                    </div>
                    <!-- COLUMNS CONTAINER ENDS-->
                    <div style="border: none;" class="horizontal-line">
                    </div>
                    <!--LOGHI PRODOTTI-->
                    <div id="sliderLoghi_1" style="height: 145px;" class="one-fifth">
                        <a href="shop/Catalogo.html">
                            <img src="images/shop.png" alt="" width="168" class="portfolio-img pretty-box" /></a>
                    </div>
                    <div class="one-fifth">
                        <div id="sliderLoghi_2">
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
                            <div>
                                <a href="http://www.wm4pr.com/it/Result/Shop_19582_Manufacturer_109/Page_1/Ambient_-1_Type_-1_Designer_-1"
                                    class="portfolio-item-preview">
                                    <img src="img/calligaris_logo.jpg" alt=" " width="168" height="145" class="portfolio-img pretty-box" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="one-fifth">
                        <div id="sliderLoghi_3">
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
                        </div>
                    </div>
                    <div class="one-fifth">
                        <div id="sliderLoghi_4">
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
                        </div>
                    </div>
                    <div class="one-fifth last">
                        <div id="sliderLoghi_5">
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
                </div>
            </div>
        </div>
        <!-- CONTAINER ENDS-->
        <%-- </div>--%>
    </div>
    <div id="bottom_section">
        <div id="footer">
            <div class="one">
                <div style="height: 15px; display: block;">
                </div>
                <div class="one-fourth">
                    <h6>
                        Newsletter</h6>
                    <!-- COLUMN STARTS-->
                    <!-- SOCIAL LINKS STARTS-->
                    <div class="button_container text_white">
                        <asp:TextBox runat="server" ID="txtNL_1" Text="indirizzo e-mail" CssClass="newsletter"
                            onclick="if(this.value=='indirizzo e-mail') {this.value='';}" onblur="if(this.value=='') {this.value='indirizzo e-mail';}"></asp:TextBox>
                        <asp:LinkButton runat="server" ID="imgNL_1" CssClass="fancy-button_ small_ red_ searchsubmit"
                            Text="iscriviti" OnClick="_goNewsLetter" />
                    </div>
                    <br />
                    <p style="color: #BABDC0;">
                        <span style="color: #fff;">Iscriviti alla Newsletter</span> per rimanere sempre
                        aggiornato su tutte le nostre promozioni.
                    </p>
                    <%-- <h5>
                        Social</h5>--%>
                    <ul class="social-links">
                        <li>
                            <p>
                            </p>
                        </li>
                        <li>
                            <%--<img src="images/youtube.png" width="16" height="16" alt="#" /><a style="color:#fff;"  href="video.aspx">Youtube
                            </a>--%>
                        </li>
                    </ul>
                </div>
                <div class="one-fourth">
                    <!-- COLUMN STARTS-->
                    <h6>
                        Info</h6>
                    <ul class="social-links">
                        <!-- SOCIAL LINKS STARTS-->
                        <li class="address">
                            <div style="width: 25px; float: left; height: 16px;">
                                <img style="margin-left: 3px;" src="images/address.png" alt="#" />
                            </div>
                            <span style="color: #BABDC0;">&nbsp;Via Selva San Vito 23</span></li>
                        <li class="address">
                            <img src="images/iphone.png" alt="#" /><span style="color: #BABDC0;">Laterza, Taranto
                                74014</span> </li>
                        <li class="address">
                            <img src="images/mail_ok.png" alt="#" /><a style="color: #BABDC0; height: 6px;" href="mailto:#">info@materarredamenti.it</a>
                        </li>
                        <li class="address">
                            <img src="images/tel.png" alt="#" /><span style="color: #BABDC0;">+39 099 82 16 774</span>
                        </li>
                        <li class="address">
                            <div style="width: 28px; float: left; height: 16px;">
                                <img style="margin-left: 3px;" src="images/iphone2.png" alt="#" />
                            </div>
                            <span style="color: #BABDC0;">+39 338 49 01 627</span> </li>
                    </ul>
                </div>
                <div class="one-fourth last">
                    <h6>
                        Siamo aperti:</h6>
                    <p>
                        <span style="color: #BABDC0;">dal lunedi al sabato</span>
                    </p>
                    <p>
                        M: <span style="color: #BABDC0;">9,00 - 12,30 |</span> P: <span style="color: #BABDC0;">
                            16,00 - 20,30</span>
                    </p>
                    <p>
                        La domenica siamo aperti su appuntamento.
                    </p>
                </div>
                <div class="one-fourth last">
                    <blockquote style="color: #BABDC0;">
                        Venite a visitare il nostro Showroom a Laterza.<br />
                        Vi stupiremo con le nostre tante soluzioni d’arredo e se siete di fuori città sarete
                        nostri graditi ospiti a pranzo.
                    </blockquote>
                </div>
            </div>
        </div>
        <div id="footer-copy">
            <div class="center">
                <div style="text-align: center; color: #babdc0;" class="one">
                    © 2012 - Matera Arredamenti
                    <%-- <span style="font-style:italic;font-size:12px;">
                     web dev <a href="http://zoom2design.com" target="_blank">zoom2design</a></span>  --%>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
