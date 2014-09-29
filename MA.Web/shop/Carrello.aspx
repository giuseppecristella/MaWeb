<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Carrello.aspx.cs" Inherits="shop_Carrello" %>

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
        jQuery.noConflict()(function($) {
            $(document).ready(function() {

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

<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div class="center">
            <p class="header-text-left">
                T: +39 821 39 36 E: shop@materarredamenti.it
            </p>
            <ul id="header-icons">
                <li><a href="Customers/Default.aspx">Account Info</a></li>
                <li><a href="Customers/Ordini.aspx">Ordini</a></li>
                <asp:LoginView ID="loginView1" runat="server">
                    <LoggedInTemplate>
                        <li>
                            <asp:LoginName CssClass="colored" runat="server" ID="loginName" FormatString="{0}" />
                            <asp:LoginStatus Style="float: right; margin-left: 10px;" runat="server" ID="logStatus"
                                LoginText="Login" LogoutText="Logout" LogoutPageUrl="~/shop/Catalogo.aspx" CssClass="loginsubmit" />
                        </li>
                    </LoggedInTemplate>
                    <AnonymousTemplate>
                        <li><a href="Accedi.aspx">Accedi</a></li>
                    </AnonymousTemplate>
                </asp:LoginView>
            </ul>
            <div id="container">
                <!--WRAPPER-->
                <div id="header">
                    <!-- HEADER  -->
                    <!-- LOGO -->
                    <a id="logo_v" class="logoArancioCar" title="Homepage" href="#"></a>
                    <!--LOGO ENDS  -->
                    <div id="main_navigation" class="main-menu arancio">
                        <!--  MAIN  NAVIGATION-->
                        <ul id="menuCatShop">
                            <li><a href="design.html" title="Home">Design Casa</a></li>
                            <li><a href="tradizione.html">La Tradizione</a> </li>
                        </ul>
                    </div>
                    <!-- MAIN NAVIGATION ENDS-->
                    <div style="background: #F9B233" class="divCarrello" id="divCarrello">
                        <a href="Carrello.aspx" class="carrello_titolo">
                            <asp:Literal runat="server" ID="ltrTotCart"></asp:Literal></a>
                    </div>
                </div>
                <!-- HEADER ENDS-->
                <!-- MAIN CONTAINER -->
                <div id="content">
                    <div style="padding: 20px 0 20px 0;" class="one">
                        <div class="headline">
                            <h4>
                                Il tuo > Carrello
                            </h4>
                        </div>
                    </div>
                    <div style="min-height: 580px;" class="one">
                        <div style="margin-left: 30px; width: 195px;" class="one-fourth">
                            <p>
                                Stai visualizzando i prodotti che intendi acquistare.
                            </p>
                            <p>
                                Puoi modificare la quantità dei prodotti o cancellarne alcuni.
                                <br />
                                Per confermare queste operazioni clicca il link 'Aggiorna il Carrello'.
                            </p>
                        </div>
                        <div class="three-third">
                            <asp:ListView runat="server" ID="lvCart" OnItemDataBound="lvDataBound">
                                <EmptyDataTemplate>
                                    <div style="float: right; margin: auto; text-align: center; width: 700px;" class="simple-notice">
                                        <strong>Attenzione: </strong>il tuo carrello è vuoto.
                                    </div>
                                </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table class="carrello">
                                        <tr runat="server" id="itemPlaceholder" />
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Image runat="server" ID="imgprod" Width="100" />
                                        </td>
                                        <td>
                                            <fieldset>
                                                <label style="width: 320px;" class="cartLabel">
                                                    <asp:Literal runat="server" ID="lblnomeprod"></asp:Literal></label>
                                                <asp:Label runat="server" ID="lblprezzoun" Style="width: 60px;" class="cartLabel"></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Style="width: 5px;" class="cartLabel_noborder">x</asp:Label>
                                                <asp:TextBox runat="server" ID="txtqta" CssClass="cartLabel" Style="width: 20px;
                                                    height: 20px"></asp:TextBox>
                                                <asp:Label runat="server" ID="lblprezzotot" Style="width: 70px;" class="cartLabel"></asp:Label>
                                            </fieldset>
                                            <br />
                                            <fieldset>
                                                <asp:CheckBox runat="server" ID="chkDelete" Style="float: left;" />
                                                <label style="margin-left: 5px; float: left;">
                                                    voglio eliminare questo articolo dal carrello.</label>
                                                <asp:LinkButton runat="server" Style="float: right;" ID="lnkbtnDettProd" Text="visualizza dettagli articolo" />
                                            </fieldset>
                                            <fieldset>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                            <asp:Panel runat="server" ID="pnlCartTotal">
                                <br />
                                <fieldset runat="server" id="msgError" visible="false" style="text-align: left" class="simple-error">
                                    <strong>Attenzione: </strong>non è stato possibile completare l'operazione in quanto
                                    i prodotti evidenziati in rosso non sono disponbili nella quantità richiesta. Si
                                    prega di consultare la disponibilità nel dettaglio del prodotto.
                                </fieldset>
                                <fieldset>
                                    <asp:LinkButton runat="server" ID="btnUpdateCart" Style="margin-left: 30px;" Text="Aggiorna il Carrello"
                                        OnClick="btnUpdateCart_Click" />
                                    <label class="cartLabel" style="float: right; margin-right: 30px;">
                                        Totale €.&nbsp;
                                        <asp:Literal runat="server" ID="ltrSomma"></asp:Literal></label>
                                </fieldset>
                                <br />
                                <fieldset>
                                    <asp:LinkButton Style="float: right; margin-right: 30px;" CssClass="fancy-button red small"
                                        ID="LinkButton1" runat="server" OnClick="lnkbtncheckout_Click">Conferma ordine</asp:LinkButton>
                                </fieldset>
                                <br />
                                <fieldset>
                                    <asp:LinkButton runat="server" Text="Continua lo shopping" ID="lnkbtnContinueShop"
                                        CssClass="fancy-button_ red small" Style="float: right; margin-right: 30px;"
                                        OnClick="lnkbtnContinueShop_Click"></asp:LinkButton>
                                </fieldset>
                                <div class="clear">
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="one-third">
                        </div>
                        <div class="one-third">
                        </div>
                        <div class="one-third last">
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
                                        <img src="images/pagamenti.png" />
                                        <!--<ul id="our-photos-footer">
                                            <li><a href="#">
                                                <img src="images/clients/1.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li><a href="#">
                                                <img src="images/clients/2.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li><a href="#">
                                                <img src="images/clients/3.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li class="last"><a href="#">
                                                <img src="images/clients/4.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li><a href="#">
                                                <img src="images/clients/5.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li><a href="#">
                                                <img src="images/clients/6.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li><a href="#">
                                                <img src="images/clients/7.jpg" width="40" height="40" alt=" " /></a></li>
                                            <li class="last"><a href="#">
                                                <img src="images/clients/8.jpg" width="40" height="40" alt=" " /></a></li>
                                        </ul>-->
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
                                                marginwidth="0" src="http://maps.google.it/maps?f=q&amp;source=s_q&amp;hl=it&amp;geocode=&amp;q=laterza+via+selva+san+vito+23&amp;aq=&amp;sll=40.354131,18.174294&amp;sspn=0.107007,0.222988&amp;ie=UTF8&amp;hq=laterza+via+selva+san+vito+23&amp;hnear=&amp;radius=15000&amp;t=m&amp;ll=40.619624,16.808159&amp;spn=0.071946,0.071946&amp;output=embed">
                                            </iframe>
                                        </div>
                                    </div>
                                    <!-- COLUMN ENDS-->
                                </div>
                                <!-- COLUMN CONTAINER ENDS-->
                            </div>
                            <div style="width: 100%; padding-left: 30px; padding-top: 30px;" class="left">
                                <p>
                                    <%-- <a style="color: #000;" href="#">Maioliche</a> / <a style="color: #000;" href="#">Succhi di Puglia</a>
                                    / <a style="color: #000;" href="#">Antichi Sapori</a> / <a style="color: #000;" href="#">Specialità</a>
                                    / <a style="color: #000;" href="#">Idee Regalo</a>--%>
                                </p>
                            </div>
                            <!-- FOOTER ENDS-->
                        </div>
                        <!-- FOOTER CONTAINER ENDS-->
                    </div>
                    <!-- FOOTER WRAPPER ENDS-->
                    <div id="copyright-wrapper">
                        <!-- COPYRIGHTS WRAPPER STARTS-->
                        <div id="copyright">
                            <a id="logo-copyright" title="Homepage" href="#"></a>
                            <!--     <div class="right">
                                <p>
                                    <a href="#">Home</a> / <a href="#">Features</a> / <a href="#">Pages</a> / <a href="#">
                                        Portfolio</a> / <a href="#">Blog</a> / <a href="#">Typography &amp; Columns</a>
                                    / <a href="#">Contact</a>
                                </p>
                                <span>© Copyright 2011. All rights reserved. Template created by:<a href="http://themeforest.net/user/trendyWebStar">trendyWebStar</a></span>
                            </div>-->
                        </div>
                        <!-- COPYRIGHTS ENDS-->
                    </div>
                    <!-- COPYRIGHTS WRAPPER ENDS-->
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
