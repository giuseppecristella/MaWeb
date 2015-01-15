﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Blog_detail.aspx.cs" Inherits="mobile_Blog_detail" %>

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
<%--	<link rel="stylesheet" href="css/add2home.css">--%>
	
	
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
	   <img id="splash-bg" src="images/splash/splash-alternate.png" alt="splash image"/>
	   <img id="splash-title" src="images/splash/main.png" alt="splash title" />
	 </div> 
  <!-- end splash screen -->
	<!--<div id="menu">
		<form action="search.html"><h3><input id="search" type="text" placeholder="Search" /> </h3></form>
		<ul>
			<li class="active"><a href="./" adata-transition="slidedown" class="contentLink">Home</a></li>
			<li><a href="company-profile.html" adata-transition="slidedown" class="contentLink">Company Profile</a></li>
			<li><a href="products-services.html"adata-transition="slidedown" class="contentLink">Products &amp; Services</a></li>
			<li><a href="portfolio.html" adata-transition="slidedown" class="contentLink">Portfolio</a></li>
			<li><a href="news-events.html" adata-transition="slidedown" class="contentLink">News &amp; Events</a></li>
			<li><a href="gallery.html" adata-transition="slidedown" class="contentLink">Gallery</a></li>
			<li><a href="typography.html" adata-transition="slidedown" class="contentLink">Typography</a></li>
			<li><a href="blog.html" adata-transition="slidedown" class="contentLink">Wordpress Blog</a></li>
			<li><a href="twitter.html" adata-transition="slidedown" class="contentLink">Twitter Feeds</a></li>
			<li><a href="video-channel.html" adata-transition="slidedown" class="contentLink">Video Channel</a></li>
			<li><a href="contact-us.html" adata-transition="slidedown" class="contentLink">Contact Us</a></li>
			<li><a href="about.html" adata-transition="slidedown" class="contentLink">About</a></li>
                        <li><a href="404.html" adata-transition="slidedown" class="contentLink">404</a></li>
		</ul>
	</div>--><div data-dom-cache="false" data-role="page" class="pages" id="home" data-theme="a">
	<div data-role="header" data-position="fixed">
            <div class="left">
                <a href="default.aspx" class="showMenu menu-button"><img src="images/menu-button.png" width="16" /></a>
                 <a href="#" class="back-button"><img src="images/back-button.png" width="40" /></a>
            </div>
             <h1><p class="no-margin">BLOG</p><p class="no-margin">materarredamenti.it</p></h1>
            
	</div>
        
        <!-- /header -->
    
	<div data-role="content" data-theme="a" class="minus-shadow">
           
	    
	    
	    
	    
            <div class="white-content-box">
            
             <asp:Repeater DataSourceID="objPost" runat="server" ID="rptblog">
        <ItemTemplate>
        <h1><%#Eval("Titolo") %></h1>
            <p>  <%# System.Convert.ToDateTime(Eval("Data").ToString()).Day.ToString() %> <%# Utility.GetMonth(System.Convert.ToDateTime (Eval("Data")).Month.ToString()) %></p>
            
            
 
            
           
           
           <p> <%#Eval("Testo") %></p>
           <br/>
           <a href="blog.aspx">[-] Ritorna agli articoli</a>
           
        </ItemTemplate>
    </asp:Repeater>
            
            
            
            
		 
 		 
		
		 
	    
	    
	    
	    
	    
	    
	    
	    
	    
	</div><!-- /content -->
        
        <div class="bread-crumb">
            <ul>
                <li><a data-transition="pop" href="index.html"><img src="images/bc-home.png" width="16" /></a></li>
                <li><span>Typography</span></li>
            </ul>
        </div>
        <div data-role="footer" data-position="fixed">
    <div class="footer-actions">
        <a href="tel://0998216774"><img src="images/icons/phone.png"></a>
        <a target="_blank" href="http://www.facebook.com/riten.vagadiya"><img src="images/icons/fb.png"></a>
        <a href="mContatti.aspx"><img src="images/icons/location.png"></a>
        <div class="clear"></div>
    </div>
                <p class="right">&copy; Matera Arredamenti</p>

    <div class="clear"></div>
</div></div><!-- /page -->
</div>
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
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    <asp:ObjectDataSource ID="objPost" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataByID" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="News_ID" QueryStringField="Id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
