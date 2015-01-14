<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EventoDettaglio.aspx.cs"
    Inherits="EventoDettaglio" Title="Matera Arredamenti - Mobili per la vita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="js/jquery.prettyPhoto.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery.noConflict()(function($) {
            $(document).ready(function() {
                $("a[rel^='prettyPhoto']").prettyPhoto({ opacity: 0.80,
                    hideflash: false, modal: true, default_width: 710, default_height: 525, overlay_gallery: false
                });
                $('#pnlGallery #clients li').show();
                $('#pnlGallery').slider
            ({
                nav: 'ul.slider-nav',
                items: 'clients',
                wrapper_class: 'clients-wrapper',
                visible: 5,
                auto_delay: 400,
                /* auto_slide: true,
                
                speed: 4000,*/
                slide: 4
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
        <li><a class="sel" href="eventi.aspx">Eventi</a></li>
        <li><a href="ListaNozze.aspx">Lista Nozze</a></li>
        <li><a style="font-weight: bold;" href="javascript:scegliShop();">Shop</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="wrapper_pepp">
        <div id="container">
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <!-- COLUMNS CONTAINER ENDS-->
                <div class="one">
                    <div class="inner-content">
                        <p style="background-image: url('images/footer_shadow_M.png'); background-position: bottom;
                            background-repeat: no-repeat; border: none;" class="intro-pages">
                            <asp:Repeater ID="Repeater1" DataSourceID="objPost" runat="server">
                                <ItemTemplate>
                                    <img src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>' alt=" " />
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <%-- <div class="horizontal-line">
                        </div>--%>
                        <asp:Repeater ID="rptBlogPost" DataSourceID="objPost" runat="server">
                            <ItemTemplate>
                                <p style="float: left;">
                                    <h3 class="colored">
                                        <%#Eval("Titolo") %>
                                    </h3>
                                </p>
                                <!--POST TITLE-->
                                <!--POST DETAILS-->
                                <!--POST INTRO-->
                                <p class="blog-testo" style="text-align: justify;">
                                    <%# Eval("Testo") %>
                                </p>
                                <p style="text-align: right;">
                                    <a href='eventi.aspx'>[- Ritorna agli Eventi]</a></p>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div id="pnlGallery" style="float: left; width: 100%;" runat="server">
                            <ul id="clients">
                                <asp:ListView DataSourceID="objGallery" OnDataBound="isPagerVisGallery" runat="server"
                                    ID="lvGallery" OnItemCreated="_itemCreated">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <li runat="server" id="liGallery"><a href="Handler.ashx?PhotoID=<%# Eval("PhotoID") %>.jpg&W_=620&H_=415"
                                            rel="prettyPhoto[pp_gal]" title=''>
                                            <img src="Handler.ashx?PhotoID=<%# Eval("PhotoID") %>.jpg&W_=80&H_=70" width="80"
                                                height="70" alt=" " /></a></li>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
                        </div>
                        <div class="clear-line">
                        </div>
                        <asp:DataPager runat="server" ID="dpGallery" PageSize="36" PagedControlID="lvGallery">
                            <Fields>
                                <asp:NumericPagerField CurrentPageLabelCssClass="my-blog-pagination-current" NumericButtonCssClass="my-blog-pagination" />
                            </Fields>
                        </asp:DataPager>
                        <div style="width: 100%; height: 100px; float: left; position: relative;">
                            <div class="clear-line">
                            </div>
                            <asp:Literal runat="server" ID="ltrSocial" Text=""></asp:Literal>
                        </div>
                    </div>
                    <div class="one-fourth last">
                        <h4 class="blog-category intro-pages">
                            Tutti gli eventi</h4>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="updFB">
                            <ContentTemplate>
                                <!-- LATEST POSTS UL-->
                                <asp:ListView DataSourceID="objPostList" OnDataBound="isPagerVis" runat="server"
                                    ID="lvLastFromBlog">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <%--   <a style="text-decoration: none;"  href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.aspx'> </a>--%>
                                        <div class="one-fourth last">
                                            <p>
                                                <img width="212px;" style="border: 1px solid #efefef;" src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>'
                                                    alt=" " />
                                            </p>
                                            <h6 class="grigio">
                                                <%#Eval("Titolo") %>
                                            </h6>
                                            <p>
                                                <%# Utility.ShortDesc(Eval("Descrizione").ToString(),250).ToString() %>
                                            </p>
                                            <%--<a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.aspx'>
                                                Leggi tutto →</a>--%>

                                            <a href='EventoDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                Leggi tutto →</a>
                                        </div>
                                        <div class="horizontal-line">
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <div class="clear-line">
                                </div>
                                <asp:DataPager runat="server" ID="pagerEventi" PageSize="5" PagedControlID="lvLastFromBlog">
                                    <Fields>
                                        <asp:NumericPagerField CurrentPageLabelCssClass="my-blog-pagination-current" NumericButtonCssClass="my-blog-pagination" />
                                    </Fields>
                                </asp:DataPager>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div style="height: 40px; width: 217px;">
                        </div>
                    </div>
                    <!-- COLUMNS CONTAINER ENDS-->
                </div>
            </div>
            <!-- CONTENT ENDS-->
        </div>
        <asp:ObjectDataSource ID="objPost" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByID" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="News_ID" SessionField="BlogPostID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="objPostList" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="Tipo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
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
    </div>
</asp:Content>
