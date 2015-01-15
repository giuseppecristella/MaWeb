<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Video.aspx.cs" Inherits="Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript">
        jQuery.noConflict()(function($) {
            $(document).ready(function() {

                $("a[rel^='prettyPhoto']").prettyPhoto({ opacity: 0.80, default_width: 800, default_height: 450, show_title: false, overlay_gallery: false, theme: 'facebook', hideflash: false, modal: false,
                    social_tools: "<div class='pp_social'><div class='twitter'><a href='http://twitter.com/share' class='twitter-share-button' data-count='none'>Tweet</a><script type='text/javascript' src='http://platform.twitter.com/widgets.js'" + '>' + '<' + "/script></div><div class='facebook'><iframe src='//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fwww.xpuremotorsports.com&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21&amp;appId=311343627994' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:450px; height:21px;' allowTransparency='true'></iframe></div></div>"
                });
            });
        });   
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="wrapper_pepp">
        <div id="container">
            <div id="content">
                <div class="one">
                    <div class="intro-pages">
                        <img src="images/youtube_large.png" alt="" height="90" class="right" />
                        <blockquote>
                            <h3>
                                Tutti i video proposti dalla <span class="colored">Matera Arredamenti</span>
                                <br />
                                direttamente dal nostro canale You Tube.
                            </h3>
                        </blockquote>
                    </div>
                </div>
                <div id="portfolio_ok">
                    <asp:ObjectDataSource ID="objVideo" runat="server" SelectMethod="YouTubeToDataTable"
                        TypeName="Utility"></asp:ObjectDataSource>
                    <div class="portfolio-container_ok" id="columns">
                        <ul>
                            <asp:ListView DataSourceID="objVideo" runat="server" ID="lvYouTube">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <li class="one-fourth">
                                        <div style="height: 350px;">
                                            <p>
                                                <a rel="prettyPhoto" target="_blank" title='<%#Helper.GetShortStringAndCleanTags(Eval("Title").ToString(), 300).ToString()%>'
                                                    href='<%#Eval("WatchPage") %>'>
                                                    <img width="210" height="145" class="portfolio-img pretty-box" alt="" title="" src='<%#Eval("Thumbnails") %>' />
                                                </a>
                                            </p>
                                            <h6 style="height: 90px; font-size: 19px; line-height: 20px;">
                                                <%#Helper.GetShortStringAndCleanTags(Eval("Title").ToString(), 80).ToString()%>...</h6>
                                            <p>
                                                <%# Eval("ViewCount") %>
                                                visualizzazioni</p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                    </div>
                </div>
                <asp:DataPager runat="server" ID="pagerYT" PageSize="8" PagedControlID="lvYouTube">
                    <Fields>
                        <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                            NumericButtonCssClass="my-blog-pagination" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </div>
</asp:Content>
