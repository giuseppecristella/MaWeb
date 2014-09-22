<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Azienda.aspx.cs" Inherits="mobile_Azienda" %>

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
	<link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600' rel='stylesheet' type='text/css'>
	
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
    <div data-dom-cache="false" data-role="page" class="pages" id="home" data-theme="a">
        <div data-role="header" data-position="fixed">
            <div class="left">
                <a href="Default.aspx" class="showMenu menu-button">
                    <img src="images/menu-button.png" width="16" /></a>
            </div>
            <h1>
                <p class="no-margin">
                    Azienda</p>
                <p class="no-margin">
                    materarredamenti.it</p>
            </h1>
        </div>
        <!-- /header -->
        <div data-role="content" data-theme="a" class="minus-shadow">
          <img src="images/azienda.jpg"/>
            <!--
            <div class="cherry-slider" style="height: 114px;">
                <div anim="slide"anim-speed="200"anim-direction="right"anim-position-right="0"anim-position-top="0" class="anim-item"><img style="opacity: 0.2" src="images/man.png" width="72" /></div>
                <div anim="slide"anim-speed="300"anim-direction="right"anim-position-right="8"anim-position-top="6" class="anim-item"><img style="opacity: 0.4" src="images/man.png" width="82" /></div>
                <div anim="slide"anim-speed="400"anim-direction="right"anim-position-right="16"anim-position-top="12" class="anim-item"><img src="images/man.png" width="92" /></div>
                <div anim="blind"anim-speed="700"anim-direction="up"anim-position-left="30"anim-position-top="0"  class="anim-item"><p class="little-padding aa">ALWAYS</p></div>
                <div anim="blind"anim-speed="600"anim-direction="up"anim-position-left="30"anim-position-top="16"  class="anim-item"><p class="little-padding aa">IN&nbsp;MOTION</p></div>
                <div anim="drop"anim-speed="1200"anim-direction="up"anim-position-left="34"anim-position-top="44"  class="anim-item"><p class="little-padding white-bg gray-border">POWERFULLY</p></div>
            </div>
            -->
            
            
             
            
          <div class="white-content-box">
		<h3>La Nostra Storia</h3>
		<p>La Matera Arredamenti è un’azienda di quelle da manuale dell’imprenditore.
Nasce nel 1976, grazie alla passione e alla tenacia del suo titolare, Giovanni Matera, proveniente da una storica bottega di falegnameria locale.
Sin da piccolo Giovanni, com’era d’uso nelle umili famiglie di paese, è avviato a bottega e lì respira il profumo d’ogni essenza, entra in contatto con la materia viva, impara a darle forma secondo i canoni della migliore tradizione. I suoi gesti quotidiani rivelano da subito l’amore per le cose belle, tanto che le sue produzioni sembrano più oggetti d’arte che semplici mobili.
Dopo circa un ventennio di apprendistato e perfezionamento - vissuto parallelamente anche tra i banchi di scuola, dove consegue il diploma di maturità – il giovane Giovanni si sente pronto per realizzare il sogno che coltiva sin da bambino: creare un’azienda tutta sua; cosa non facile in verità, sia per la mancanza di mezzi sia anche per le oggettive difficoltà burocratiche e di mercato.
Ma il ragazzo è credibile e determinato a realizzare il suo sogno.
Allora, suo padre, non sapendo come aiutarlo, gli dona il suo campo di ceci; ed è proprio su quel campo che oggi si erge una bella azienda, moderna, elegante e in continua espansione: la MATERA ARREDAMENTI.</p>
		</div>
            
            
            
            <ul class="nav-list">
                <li><a  style="font-size: 18px;" href="Mission.aspx">Mission<span>&gt;</span></a></li>
                <li><a  style="font-size: 18px;" href="Servizi.aspx">I nostri Servizi<span>&gt;</span></a></li>
                
            </ul>
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
            <p class="right">&copy; Matera Arredamenti</p>
            <div class="clear">
            </div>
        </div>
    </div>
    <!-- /page -->

    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-34399779-4']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

</script>

    </form>
</body>
</html>
