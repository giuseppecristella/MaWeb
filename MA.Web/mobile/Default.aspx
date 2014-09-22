<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="mobile_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Matera Arredamenti Mobile</title>
    <meta id="extViewportMeta" name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <!-- Home screen icon  Mathias Bynens mathiasbynens.be/notes/touch-icons -->
    <!-- For iPhone 4 with high-resolution Retina display: -->
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/icon.png">
    <!-- For first-generation iPad: -->
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/icon.png">
    <!-- For non-Retina iPhone, iPod Touch, and Android 2.1+ devices: -->
    <link rel="apple-touch-icon-precomposed" href="images/icon.png">
    <!-- For nokia devices: -->
    <link rel="shortcut icon" href="images/icon.png">
    <link rel="stylesheet" href="css/reset.css">
    <link rel="stylesheet" href="css/ui-lightness/jquery-ui-1.8.24.custom.css" />
    <link rel="stylesheet" href="css/themes/default/RSVmain.min.css" />
    <link rel="stylesheet" href="css/themes/default/jquery.mobile.structure-1.1.1.min.css" />
    <link rel="stylesheet" href="css/flexslider.css">
    <link rel="stylesheet" href="css/photoswipe.css">
    <%--<link rel="stylesheet" href="css/add2home.css">--%>
    <link rel="stylesheet/less" href="css/style.css">
    <!-- fonts -->
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600'
        rel='stylesheet' type='text/css'>

    <script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>

    <script src="js/jquery-ui-1.8.24.custom.min.js"></script>

    <script type="text/javascript" src="js/jquery.mobile-1.1.1.min.js"></script>

    <script type="text/javascript" src="js/less-1.3.0.min.js"></script>

    <!--<script type="text/javascript" src="js/jquery-ui-effects.js"></script>-->

    <script src="js/helper.js"></script>

    <script src="js/jquery.flexslider-min.js"></script>

    <script src="js/iphone-style-checkboxes.js"></script>

    <script src="js/klass.min.js"></script>

    <script src="js/code.photoswipe.jquery-3.0.5.min.js"></script>

    <

    <script src="http://maps.google.com/maps/api/js?sensor=false"></script>

    <script type="text/javascript" src="js/app.js?v=30"></script>

</head>
<body>
    <form id="form1" runat="server">
    <!-- Splash screen -->
    <div id="splash">
        <img id="splash-bg" src="images/splash/splash-alternate.png" alt="splash image" />
        <img id="splash-title" src="images/splash/main.png" alt="splash title" />
    </div>
    <!-- end splash screen -->
    <div data-cache="never" data-role="page" class="pages" id="home" data-theme="a">
        <div data-role="content" data-theme="a" class="minus-shadow">
        <img src="images/header_mobile.png"/>
            <ul class="nav-list">
                <asp:Literal ID="ltrMenu" runat="server"></asp:Literal>
                <li><a style="font-size: 18px;" href="Azienda.aspx"><b>Azienda</b><span>&gt;</span></a></li>
                <li><a style="font-size: 18px;" href="mProdotti.aspx"><b>Prodotti</b><span>&gt;</span></a></li>
                 <li><a style="font-size: 18px;" href="promozioni.aspx"><b>Promozioni</b><span>&gt;</span></a></li>
                <li><a style="font-size: 18px;" href="mEventi.aspx"><b>Eventi</b><span>&gt;</span></a></li>
                <li><a style="font-size: 18px;" href="Blog.aspx"><b>Blog</b><span>&gt;</span></a></li>
                <li><a style="font-size: 18px;" href="mvideo.aspx"><b>Video</b><span>&gt;</span></a></li>
                <li><a style="font-size: 18px;" href="mhomeShopr.aspx"><b>Shop Design</b><span>&gt;</span></a></li>
                <li><a style="font-size: 18px;" href="mhomeShopv.aspx"><b>Shop Tradizione</b><span>&gt;</span></a></li>
                 <li><a style="font-size: 18px;" target="_blank" href="http://www.materaservice.it"><b>Matera Traslochi</b><span>&gt;</span></a></li>
                <%--    <li><a href="history.html">History<span>&gt;</span></a></li>
                <li><a href="management-team.html">Management Team<span>&gt;</span></a></li>--%>
            </ul>
           <%-- <div class="menu-blocks">
                <a class="menu-block" href="Azienda.aspx" data-transition="pop">
                    <img src="images/menu/intro.png" />
                    <span>Azienda</span> </a><a class="menu-block" href="../Prodotti.aspx" data-transition="pop">
                        <img src="images/menu/products.png" />
                        <span>Prodotti</span> </a><a class="menu-block" href="promozioni.aspx" data-transition="pop">
                            <img src="images/menu/portfolio.png" />
                            <span>Promozioni</span> </a><a class="menu-block" href="mEventi.aspx" data-transition="pop">
                                <img src="images/menu/news.png" />
                                <span>Eventi</span> </a><a class="menu-block" href="Blog.aspx" data-transition="pop">
                                    <img src="images/menu/gallery.png" />
                                    <span>Blog</span> </a><a class="menu-block" href="elements.html" data-transition="pop">
                                        <img src="images/menu/elements.png" />
                                        <span>Video</span> </a><a class="menu-block" href="mContatti.aspx" data-transition="pop">
                                            <img src="images/menu/blog.png" />
                                            <span>Contatti</span> </a><a class="menu-block" href="mvideo.aspx" data-transition="pop">
                                                <img src="images/menu/videos.png" />
                                                <span>Shop Tradizione</span> </a><a class="menu-block" href="twitter.html" data-transition="pop">
                                                    <img src="images/menu/twitter.png" />
                                                    <span>Shop Design</span> </a>
                <div class="clear">
                </div>
            </div>--%>
            <div class="website-heading">
                <p class="head">
                    Matera Arredamenti</p>
                <p class="subhead">
                    Mobili per la vita</p>
            </div>
        </div>
        <!-- /content -->
        <div data-role="footer" data-position="fixed">
            <div class="footer-actions">
                <a href="tel://0998216774">
                    <img src="images/icons/phone.png"></a> <a target="_blank" href="https://www.facebook.com/matearredamenti">
                        <img src="images/icons/fb.png"></a> <a href="mcontatti.aspx">
                            <img src="images/icons/location.png"></a>
                <div class="clear">
                </div>
            </div>
            <p class="right">
                &copy; Matera Arredamenti</p>
            <div class="clear">
            </div>
        </div>
    </div>
    <!-- /page -->

    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-XXXXXXXXX-X']); //enter your google analytics account number here
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

</script>

    </form>
    <!--Retina JS-->

    <script type="text/javascript" src="js/retina.js"></script>

</body>
</html>
