<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mEventoDettaglio.aspx.cs"
    Inherits="mobile_EventoDett" %>

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
    <div data-dom-cache="false" data-role="page" class="pages" id="home" data-theme="a">
        <div data-role="header" data-position="fixed">
            <div class="left">
                <a href="Default.aspx" class="showMenu menu-button">
                    <img src="images/menu-button.png" width="16" /></a>
                     <a href="mEventi.aspx" class="back-button"><img src="images/back-button.png" width="40" /></a>
            </div>
            <h1>
                <p class="no-margin">
                    Eventi</p>
                <p class="no-margin">
                    materarredamenti.it</p>
            </h1>
        </div>
        <!-- /header -->
        <div data-role="content" data-theme="a" class="minus-shadow">
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
            <div class="gallery-collection white-content-box">
                <ul class="gallery column-split  one-column">
                    <asp:Repeater DataSourceID="objPromo" runat="server" ID="Repeater1">
                        <ItemTemplate>
                            <li>
                                <img src='../<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>' alt="" />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <asp:ObjectDataSource ID="objPromo" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetDataByID" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="1" Name="News_ID" QueryStringField="Id" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <div class="clear">
            </div>
            <div class="white-content-box">
                <asp:Repeater DataSourceID="objPromo" runat="server" ID="rptpromo">
                    <ItemTemplate>
                        <h1>
                            <%#Eval("Titolo") %></h1>
                        <p>
                            <%#Eval("Testo") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            
            
            
            
            
            <div class="gallery-collection" data-ajax="false">
			 
		 
			<ul class="gallery photoswipe column-split  four-column">
			
			   <asp:ListView DataSourceID="objGallery" runat="server"
                ID="lvGallery">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                
                <li><a data-ajax="false" href="../Handler.ashx?PhotoID=<%# Eval("PhotoID") %>.jpg&"><img src="../Handler.ashx?PhotoID=<%# Eval("PhotoID") %>.jpg&W_=202&H_=112" alt="" /></a></li>

                
                    
                </ItemTemplate>
            </asp:ListView>
			
			<asp:ObjectDataSource ID="objGallery" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetPhotoByNewsID"
            TypeName="DataSetVepAdminTableAdapters.PhotosTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_PhotoID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AlbumID" Type="Int32" />
                <asp:Parameter Name="Caption" Type="String" />
                <asp:Parameter Name="BytesOriginal" Type="Object" />
                <asp:Parameter Name="BytesFull" Type="Object" />
                <asp:Parameter Name="BytesPoster" Type="Object" />
                <asp:Parameter Name="BytesThumb" Type="Object" />
                <asp:Parameter Name="Original_PhotoID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="NewsID" QueryStringField="Id" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AlbumID" Type="Int32" />
                <asp:Parameter Name="Caption" Type="String" />
                <asp:Parameter Name="BytesOriginal" Type="Object" />
                <asp:Parameter Name="BytesFull" Type="Object" />
                <asp:Parameter Name="BytesPoster" Type="Object" />
                <asp:Parameter Name="BytesThumb" Type="Object" />
            </InsertParameters>
        </asp:ObjectDataSource>
				
			</ul>
			<div class="clear"></div>
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
