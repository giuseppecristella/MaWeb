<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="mobile_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Moby-plus</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0;" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link rel="stylesheet" href="css/styles.css">
    <!--Google Webfont -->
    <link href='http://fonts.googleapis.com/css?family=Pontano+Sans' rel='stylesheet'
        type='text/css'>
    <!--Javascript-->

    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="js/jquery.flexslider.js"></script>

    <script type="text/javascript" src="js/jquery.jtweetsanywhere-1.3.1.min.js"></script>

    <script type="text/javascript" src="js/custom.js"></script>

    <!--[if lt IE 9]>
        <script src="js/html5.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div class="moby_wrap">
        <header> 
    <!--SEARCH START-->
    <div id="search_box" style="display: none;">
      <form action="#" class="search">
        <fieldset>
        <input type="text" class="text " placeholder="Search">
        <input type="submit" class="submit">
        </fieldset>
      </form>
    </div>
    <!--SEARCH ENDS-->    
    	<a href="#" class="search_drop"></a> 
    	<a id="logo" href="mplus_home.html"><img src="../img/logo_w.png_" alt=""></a>
        <ul class="primary_nav m_10">
            <li><a href="mplus_about.html"><span class="icon about"></span>Azienda</a></li>
            <li><a href="mplus_portfolio.html"><span class="icon folio"></span>Promozioni</a></li>
            <li><a href="mplus_blog.html"><span class="icon blog"></span>Eventi</a></li>
            <li><a href="mplus_contact.html"><span class="icon contact"></span>Blog</a></li>
        </ul>
    </header>
        <section class="banner m_10">
    	<div class="flexslider">
    	
    	
    	
            <ul class="slides">
            
            
              <asp:Repeater runat="server" ID="rptFotoHOME" DataSourceID="objFotoHOME">
                            <ItemTemplate>
                                <div>
                                     <li><img src='../Handler.ashx?PhotoID=<%# Eval("PhotoID") %>' title="" alt="" /></li>
                                    
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:ObjectDataSource ID="objFotoHOME" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetPhotoSliderHome" TypeName="PhotoManager"></asp:ObjectDataSource>
              <%--  <li><img src="images/banner_1.jpg"/></li>
                <li><img src="images/banner_2.jpg"/></li>
                <li><img src="images/banner_3.jpg"/></li>--%>
            </ul>
        </div>
    </section>
        <div id="content" class="m_10">
            <asp:ObjectDataSource ID="objEventi" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="Tipo" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ListView ID="lvEventi" OnDataBound="IsPagerVisible"
                DataSourceID="objEventi" runat="server">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="block mod_container">
                        <h2>
                            <%#Eval ("Titolo") %></h2>
                            <img src='../<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>' alt=""  />
                        <p>
                            <%#Eval ("Descrizione") %>
                        </p>
                        
                       <a class="more" href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>
                            <img src="images/more.png" /></a>
                        <br class="clear">
                    </div>
                </ItemTemplate>
            </asp:ListView>
           <%-- <div class="block mod_container">
                <h2>
                    Mobile Ready</h2>
                   
                <p>
                    Cras aliquet. Integer faucibus, eros ac molestie placerat, enim tellus varius lacus,
                    nec dictum nunc tortor id urna. Suspendisse dapibus ullamcorper pede. Vivamus ligula
                    ipsum, faucibus at, tincidunt eget, porttitor non, dolor. Ut dui lectus, ultrices
                    ut, sodales tincidunt, viverra sed.
                </p>
                <p>
                    Nisl nec dictum nunc tortor id urna. Suspendisse dapibus ullamcorper pede. Vivamus
                    ligula ipsum, faucibus at, tincidunt eget, porttitor non, dolor.</p>
                <a class="more" href="#">
                    <img src="images/more.png" /></a>
                <br class="clear">
            </div>
            <div class="block mod_container">
                <h2>
                    Vivamus ligula</h2>
                <img src="../images/prova.png" />
                <p>
                    Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Suspendisse urna
                    nibh, viverra non, semper suscipit, posuere a, pede. Aliquam porttitor mauris sit
                    amet orci. Aenean dignissim pellentesque felis.Aliquam porttitor mauris sit amet
                    orci. Aenean dignissim pellentesque felis. viverra non, semper suscipit, posuere
                    a, pede. Aliquam porttitor mauris sit amet orci.</p>
                <a class="more" href="#">
                    <img src="images/more.png" /></a>
                <br class="clear">
            </div>--%>
            
        
            
            <div class="twitter_feed">
            </div>
        </div>
        <footer>
    	<span class="copyright">Copyright 2012. All rights reserved.</span>
        <a href="#top" class="toTop"><img src="images/top.png"/></a>
    </footer>
    </div>
    </form>
    <!--Retina JS-->

    <script type="text/javascript" src="js/retina.js"></script>

</body>
</html>
