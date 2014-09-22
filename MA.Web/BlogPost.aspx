<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="BlogPost.aspx.cs"
    Inherits="BlogPost" Title="Matera Arredamenti - Mobili per la vita" %>

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
                <%-- <div class="one">
                    
                    <div class="intro-pages">
                       
                        <h3>
                            Benvenuti nel nostro<span class="colored">Blog</span>, periodicamente pubblicheremo
                            gli articoli della rubrica Ricerca e Formazione
                            
                        </h3>
                    </div>
                   
                </div>--%>
                <!-- COLUMNS CONTAINER ENDS-->
                <div class="one">
                    <div class="inner-content">
                        <p style="background-image: url('images/footer_shadow_M.png'); background-position: bottom;
                            background-repeat: no-repeat; border: none;" class="intro-pages">
                            <img src="images/blog-1.jpg" alt=" " width="710" height="210" />
                        </p>
                        <asp:Repeater ID="rptBlogPost" DataSourceID="objPost" runat="server">
                            <ItemTemplate>
                                <p>
                                    <h3 class="colored">
                                        <%#Eval("Titolo") %>
                                    </h3>
                                </p>
                                <!--POST TITLE-->
                                <p>
                                
                      
                                <%--
                                    Pubblicato da: <b>Giovanni Matera</b> il
                                    <%# System.Convert.ToDateTime(Eval("Data").ToString()).ToShortDateString() %>
                                    <a href="#"></a>--%>
                                    
                                    
                                    
                                     
                                </p>
                                <!--POST DETAILS-->
                                <!--POST INTRO-->
                                <p class="blog-testo" style="text-align: justify;">
                                    <%# Eval("Testo") %>
                                </p>
                                <p>
                                    <asp:LinkButton runat="server"  ID="lnkbtnPDF" OnClick="CreaPdf">Visualizza Pdf</asp:LinkButton>
                                    | <a target="_blank" href="public/html_articolo_<%# Eval("News_ID")%>.html">Stampa Articolo.
                                    </a>
                                </p>
                                <p style="text-align: right;">
                                    <a href='blog.aspx'>[- Ritorna agli articoli]</a></p>
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
                                <%--<ul style="margin: auto;" class="simple-nav">--%>
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
                                            <%--<a style="text-decoration: none;"  href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>--%>
                                            <h6 class="grigio">
                                                <%#Eval("Titolo") %>
                                            </h6>
                                            <p>
                                                <%# Utility.ShortDesc(Eval("Descrizione").ToString(),250).ToString() %>
                                            </p>
                                           <%-- <a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>
                                                Leggi tutto →</a>--%>
                                              <a href='BlogPost.aspx?Id=<%# Eval("News_ID").ToString()%>'>
                                                Leggi tutto →</a>
                                             </a> 
                                        </div>
                                        <div class="horizontal-line">
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%-- </ul>--%>
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
                    <!-- COLUMNS CONTAINER ENDS-->
                    <!-- COLUMNS CONTAINER ENDS-->
                </div>
            </div>
            <!-- CONTENT ENDS-->
        </div>
        <asp:ObjectDataSource ID="objPost" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByID" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="News_ID" QueryStringField="Id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
