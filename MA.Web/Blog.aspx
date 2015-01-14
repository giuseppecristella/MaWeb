<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs"
    Inherits="Blog" Title="Matera Arredamenti - Mobili per la vita" %>

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
                <div class="one">
                    <div class="clear">
                    </div>
                    <div class="intro-pages">
                        <img src="img/immagine-blog.jpg" />
                        <h3>
                        </h3>
                    </div>
                    <%-- --%>
                </div>
                <div id="portfolio_ok">
                    <div class="portfolio-container_ok" id="columns">
                        <ul>
                            <asp:ListView runat="server" ID="lvBlogPosts" OnItemDataBound="lvBlogPostsOnItemDataBound">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <li class="one-fourth web">
                                        <div style="height: 265px;">
                                            <asp:Literal ID="ltrItemBlog" runat="server"></asp:Literal>
                                            
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                    </div>
                    <div class="one">
                        <asp:DataPager runat="server" ID="pagerBlogPost" PageSize="12" PagedControlID="lvBlogPosts"
                            OnPreRender="OnPagerPrerender">
                            <Fields>
                                <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                                    NumericButtonCssClass="my-blog-pagination" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </div>
        </div>
        <asp:ObjectDataSource ID="objPostList" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="Tipo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
