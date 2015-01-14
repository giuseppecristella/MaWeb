<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="BlogPost.aspx.cs"
    Inherits="BlogPost" Title="Matera Arredamenti - Mobili per la vita" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <!-- COLUMNS CONTAINER ENDS-->
                <div class="one">
                    <div class="inner-content">
                        <p style="background-image: url('images/footer_shadow_M.png'); background-position: bottom;
                            background-repeat: no-repeat; border: none;" class="intro-pages">
                            <asp:Image runat="server" ImageUrl="~/images/blog-1.jpg" alt=" " width="710" height="210"/>
                        </p>
                        <asp:Repeater ID="rptBlogPost" DataSourceID="objPost" runat="server">
                            <ItemTemplate>
                                <p>
                                    <h3 class="colored">
                                        <%#Eval("Titolo") %>
                                    </h3>
                                </p>
                                <p>
                                </p>
                                <p class="blog-testo" style="text-align: justify;">
                                    <%# Eval("Testo") %>
                                </p>
                                <p>
                                    <asp:LinkButton runat="server"  ID="lnkbtnPDF" OnClick="CreatePDF">Visualizza Pdf</asp:LinkButton>|
                                    <a target="_blank" href="<%# GetPrintUrl(Eval("News_ID").ToString()).ToString() %>.html">Stampa Articolo.
                                    </a>
                                     
                                </p>
                                <p style="text-align: right;">
                                    <a href="<%# FriendlyUrl.Href("~/Blog") %>">[- Ritorna agli articoli]</a></p>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal runat="server" ID="ltrSocial" Text=""></asp:Literal>
                        <!--PAGINATION ENDS-->
                    </div>
                    <div class="one-fourth last">
                        <h4 class="blog-category intro-pages">
                            Tutti gli articoli</h4>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="updFB">
                            <ContentTemplate>
                                <asp:ObjectDataSource ID="objPostList" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="0" Name="Tipo" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <!-- LATEST POSTS UL-->
                                <asp:ListView DataSourceID="objPostList" runat="server" ID="lvLastFromBlog">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div class="one-fourth last">
                                            <h6 class="grigio">
                                                <%#Eval("Titolo") %>
                                            </h6>
                                            <p>
                                                <%# Utility.ShortDesc(Eval("Descrizione").ToString(),250) %>
                                            </p>
                                              <a href="<%# FriendlyUrl.Href("~/BlogPost/",Eval("News_ID"),Eval("Titolo")) %>">
                                                Leggi tutto →</a>
                                        </div>
                                        <div class="horizontal-line">
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:DataPager runat="server" ID="pagerFB" PageSize="5" PagedControlID="lvLastFromBlog">
                                    <Fields>
                                        <asp:NumericPagerField CurrentPageLabelCssClass="my-blog-pagination-current" NumericButtonCssClass="my-blog-pagination" />
                                    </Fields>
                                </asp:DataPager>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear-line">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:ObjectDataSource ID="objPost" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByID" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="News_ID" SessionField="BlogPostID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
