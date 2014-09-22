<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mVideo.aspx.cs" Inherits="mobile_Video" %>

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
       
       
       
		        <asp:ObjectDataSource ID="objVideo" runat="server" 
                        SelectMethod="youtubeToDataTable" TypeName="Utility"></asp:ObjectDataSource>
		
		
		
	
       
       
           
	<div data-role="content" data-theme="a" class="minus-shadow">
		
		<img style="margin-top: -31px;" class="absolute" src="images/shadow-invert.png" />
		<div class="gallery-collection white-content-box">
		<%--	<h2>Cyclist Advertures</h2>
			<ul class="gallery column-split  one-column">
				<li>
					<li><iframe src="http://player.vimeo.com/video/30669223" width="95%" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></li>
				</li>
			</ul>
			<div class="clear"></div>
			<br/>
			<h2>More Advertures</h2>
			<ul class="gallery column-split  two-column">
				<li><iframe src="http://player.vimeo.com/video/941386" width="95%" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></li>
				<li><iframe src="http://player.vimeo.com/video/48227936" width="95%" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></li>
			</ul>
			<div class="clear"></div>
			<Br/>
			<h2>Some More Videos</h2>--%>
			<ul class="gallery column-split   two-column">
				 <asp:ListView DataSourceID="objVideo" runat="server" ID="lvYouTube">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate> 
                                          <li> <a title='<%#Utility.ShortDesc(Eval("Title").ToString(), 100).ToString()%>' href='<%#Eval("WatchPage") %>'>
                                            <img width="210" height="145"
                                                       src='<%#Eval("Thumbnails") %>' /> </a>
                                       
                                       
                                            <%-- <%#Utility.ShortDesc(Eval("Title").ToString(), 10).ToString()%>
                                       <%# Eval("ViewCount") %> --%>
                                       
                                      
 </li> 
                                 </ItemTemplate>
                            </asp:ListView>
			
				<%--<li><iframe src="http://player.vimeo.com/video/941386" width="95%" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></li>
				<li><iframe src="http://player.vimeo.com/video/48227936" width="95%" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></li>
				<li><iframe src="http://player.vimeo.com/video/1159080" width="95%" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></li>--%>
			</ul>
			
			<div class="clear"></div>
		</div>


	</div><!-- /content -->
  
       
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
