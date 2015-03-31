<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dettaglio.aspx.cs" Inherits="shop_Dettaglio" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <link rel="stylesheet" href="../css/prettyPhoto.css" type="text/css" media="screen" />
    <link href="../css/slider.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/jquery.slider.css" />
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Droid+Sans:regular,regularitalic,600,600italic,bold,bolditalic'
        type='text/css' />
    <%-- <link href='http://fonts.googleapis.com/css?family=PT+Sans+Narrow:bold:400,700' rel='stylesheet' type='text/css'/>--%>
    <link href="../css/delicious/stylesheet.css" rel="stylesheet" type="text/css" />
    <!--CSS FILES ENDS-->

    <script type="text/javascript">        document.getElementsByTagName('html')[0].className += ' js';</script>

    <script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>

    <script type="text/javascript" src="../js/slider.js"></script>

    <script type="text/javascript" src="../js/jquery.slider.js"></script> 

    <script type="text/javascript" src="../js/custom.js"></script>

    <script src="../js/jquery.prettyPhoto.js" type="text/javascript"></script>

    <script type="text/javascript">
        /***************************************************
        PRETTY PHOTO
        ***************************************************/
        jQuery.noConflict()(function ($) {
            $(document).ready(function () {

                $("a[rel^='prettyPhoto']").prettyPhoto({ opacity: 0.80, default_width: 500, default_height: 344, hideflash: false, modal: false });

            });
        });

    </script>

</head>

<script type="text/javascript">
    var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
    document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>

<script type="text/javascript">
    try {
        var pageTracker = _gat._getTracker("UA-12761769-1");
        pageTracker._trackPageview();
    } catch (err) { }</script>

<body onload="load()">
    <form id="form1" runat="server">
        <div id="wrapper">
            <div class="center">
                <p class="header-text-left">
                    T: +39 821 39 36 E: shop@materarredamenti.it
                </p>
                <ul id="header-icons">
                    <li><a href="<%= FriendlyUrl.Href("~/Design/Customers/Default") %>">Account Info</a></li>
                    <li><a href="<%= FriendlyUrl.Href("~/Design/Customers/Ordini") %>">Ordini</a></li>
                    <asp:LoginView ID="loginView1" runat="server">
                        <LoggedInTemplate>
                            <li>
                                <asp:LoginName CssClass="colored" runat="server" ID="loginName" FormatString="{0}" />
                                <asp:LoginStatus Style="float: right; margin-left: 10px;" runat="server" ID="logStatus"
                                    LoginText="Login" LogoutText="Logout" LogoutPageUrl="/Design/Default.aspx" CssClass="loginsubmit" />
                            </li>
                        </LoggedInTemplate>
                        <AnonymousTemplate>
                            <li><a href="<%= FriendlyUrl.Href("~/Design/accedi") %>">Accedi</a></li>
                        </AnonymousTemplate>
                    </asp:LoginView>
                </ul>
                <div id="container"> 
                    <!--WRAPPER-->
                    <div id="header">
                        <a id="logo_v" class="logoRosso" title="Homepage"
                            href="/shop"></a>
                        <div id="main_navigation" class="main-menu rosso">
                            <ul runat="server" id="menuCatShop">
                            </ul>
                        </div>
                        <div style="background: #D10A11;" id="carrello">
                            <a href="Carrello.aspx" class="carrello_titolo">
                                <asp:Literal runat="server" ID="ltrTotCart"></asp:Literal></a>
                        </div>
                    </div>
                    <!-- MAIN CONTAINER -->
                    <div id="content">
                        <div style="padding: 20px 0 20px 0;" class="one">
                            <div class="headline">
                                <h4>
                                    <asp:Label runat="server" ID="lblNomeCatProd"></asp:Label>
                                    <span>
                                        <asp:Label runat="server" ID="lblNomeProd">&nbsp;>&nbsp; </asp:Label></span></h4>
                            </div>
                        </div>
                        <div style="min-height: 580px" class="one">
                            <div style="margin-left: 30px;" class="one-half">
                                <img runat="server" style="border: 1px solid #dfdfdf;" width="450" src="" alt=""
                                    id="mainImage" />
                                <div class="clear-line">
                                </div>
                                <asp:Repeater OnItemDataBound="rptImages_OnItemDataBound" runat="server" ID="rptImages">
                                    <ItemTemplate>
                                        <ul id="clients">
                                            <li><a runat="server" id="prettyThumb" rel="prettyPhoto" href="#">
                                                <img height="63" runat="server" id="imgThumb" src="images/product-thumb.png" alt="" /></a>
                                            </li>
                                        </ul>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="clear-line">
                                </div>
                                <div class="one-half">
                                    <asp:Repeater OnItemDataBound="rptProdAssociati_OnItemDataBound" Visible="false" runat="server"
                                        ID="rptProdAssociati">
                                        <HeaderTemplate>
                                            <h4>Potrebbero anche interessarti:
                                            </h4>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <ul style="float: left;" id="clients">
                                                <li><a runat="server" id="linkProd" href="#">
                                                    <img height="63" runat="server" id="imgProdAss" src="" alt="" />
                                                </a></li>
                                            </ul>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="one-half last dettaglio-prodotto">
                                <asp:Literal runat="server" ID="prodDescription"></asp:Literal>
                                <label>
                                    Prezzo: €.
                                <asp:Literal runat="server" ID="prodPrice"></asp:Literal></label>
                                <label>
                                    Produttore:
                                <asp:Literal runat="server" ID="prodProduttore"></asp:Literal></label>
                                <label>
                                    Pezzi disponibili:
                                <asp:Literal runat="server" ID="prodScorte"></asp:Literal>
                                </label>
                                <label>
                                    <asp:Literal runat="server" ID="prodDisponibilità"></asp:Literal>
                                </label>
                                <div class="clear-line">
                                </div>
                                <asp:ImageButton runat="server" ID="btnaddTocart" ImageUrl="images/tasto-carrello.png"
                                    Style="border: none;" CssClass="btnImageCart" Text="Aggiungi al Carrello" OnClick="btnaddTocart_Click" />
                                <div class="clear">
                                </div>
                                <div class="clear-line">
                                </div>
                            </div>
                        </div>
                        <div runat="server" id="divSpotRosso" visible="false" style="padding: 20px 0 5px 0; height: 70px;">
                            <!-- HEADER  -->
                            <!-- LOGO -->
                            <a style="background: transparent url('images/logo-design.png') no-repeat; display: block; float: left; width: 220px; height: 70px; text-indent: -9999px;"
                                id="A1" title="Homepage"
                                href="design.html"></a>
                            <!--LOGO ENDS  -->
                            <div style="background: #D10A11; margin-left: 5px; float: left; width: 614px; height: 70px;">
                                <p class="visita_shop">
                                    Entra e visita il nostro Shop dedicato all'Arredamento! Mille idee ti aspettano!
                                </p>
                            </div>
                            <div style="float: left; width: 120px; height: 70px;">
                                <a style="background: #D10A11 url('images/entra-rosso.png') no-repeat; position: relative; height: 70px; margin-top: 0px; text-indent: 60px; display: block;"
                                    href="design.html"
                                    class="_carrello_titolo"></a>
                            </div>
                        </div>
                        <div runat="server" id="divSpotVerde" visible="false" style="padding: 20px 0 5px 0; height: 70px;">
                            <!-- HEADER  -->
                            <!-- LOGO -->
                            <a class="banner-tradizione-logo" id="A2" title="Homepage"
                                href="#"></a>
                            <!--LOGO ENDS  -->
                            <div style="background: #76A227; margin-left: 5px; float: left; width: 614px; height: 70px;">
                                <p class="visita_shop">
                                    Entra e visita il nostro Shop Tradizione! Mille idee ti aspettano!
                                </p>
                            </div>
                            <div style="float: left; width: 120px; height: 70px;">
                                <a style="background: #76A227 url('images/entra-rosso.png') no-repeat; position: relative; height: 70px; margin-top: 0px; text-indent: 60px; display: block;"
                                    href="tradizione.html"
                                    class="_carrello_titolo"></a>
                            </div>
                        </div>
                        <div id="footer-wrapper">
                            <!-- FOOTER WRAPPER STARTS-->
                            <div id="footer-container">
                                <!-- FOOTER CONTAINER STARTS-->
                                <div id="footer">
                                    <!-- FOOTER STARTS-->
                                    <div class="one">
                                        <!-- COLUMN CONTAINER STARTS-->
                                        <div style="margin-left: 30px; margin-right: 10px;" class="one-fourth">
                                            <!-- COLUMN STARTS-->
                                            <strong>Metodi di Pagamento</strong>
                                            <img src="<%= Page.ResolveClientUrl("images") %>/pagamenti.png" />
                                        </div>
                                        <!-- COLUMN ENDS-->
                                        <div style="margin-right: 10px;" class="one-fourth">
                                            <strong style="padding-left: 10px;">Termini e condizioni</strong>
                                            <ul class="simple-nav">
                                                <li><a href="#">Shop Design</a></li>
                                                <li><a href="#">Shop Tradizione</a></li>
                                                <li><a href="#">Pagamenti</a></li>
                                                <li><a href="#">Spedizioni</a></li>
                                            </ul>
                                            <!--END UL-->
                                        </div>
                                        <!-- COLUMN ENDS-->
                                        <div style="margin-right: 10px;" class="one-fourth">
                                            <!-- COLUMN STARTS-->
                                            <strong style="padding-left: 10px;">Contatti</strong>
                                            <ul style="padding-left: 10px;" id="footer-info">
                                                <li>A: Via Selva S. Vito, 23 - Laterza (TA)</li>
                                                <li>T: + 39 099 82 16 774</li>
                                                <li>C: +39 338 49 01 627 </li>
                                                <li>E: <a href="#">info@materarredamenti.it</a></li>
                                                <li>E-2: <a href="#">shop@materarredamenti.it</a></li>
                                                <!-- SOCIAL LINKS ENDS-->
                                            </ul>
                                        </div>
                                        <!-- COLUMN ENDS-->
                                        <div class="one-fourth last">
                                            <!-- COLUMN STARTS-->
                                            <!-- COLUMN STARTS-->
                                            <strong style="padding-left: 10px;">Dove Siamo</strong>
                                            <div id="Gmap__" style="width: 215px; height: 150px">
                                                <iframe width="215" height="150" frameborder="0" scrolling="no" marginheight="0"
                                                    marginwidth="0" src="http://maps.google.it/maps?f=q&amp;source=s_q&amp;hl=it&amp;geocode=&amp;q=laterza+via+selva+san+vito+23&amp;aq=&amp;sll=40.354131,18.174294&amp;sspn=0.107007,0.222988&amp;ie=UTF8&amp;hq=laterza+via+selva+san+vito+23&amp;hnear=&amp;radius=15000&amp;t=m&amp;ll=40.619624,16.808159&amp;spn=0.071946,0.071946&amp;output=embed"></iframe>
                                            </div>
                                        </div>
                                        <!-- COLUMN ENDS-->
                                    </div>
                                    <!-- COLUMN CONTAINER ENDS-->
                                </div>
                                <div style="width: 100%; padding-left: 30px; padding-top: 30px;" class="left">
                                    <p>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div id="copyright-wrapper">
                            <!-- COPYRIGHTS WRAPPER STARTS-->
                            <div id="copyright">
                                <a id="logo-copyright" title="Homepage" href="#"></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--   </div>--%>
    </form>
</body>
</html>
