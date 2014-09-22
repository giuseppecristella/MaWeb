<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="eventi.aspx.cs" Inherits="Eventi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul>
        <li><a href="azienda.aspx">Azienda</a></li>
        <li><a href="servizi.aspx">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a href="promozioni.aspx">Promozioni</a></li>
        <li><a class="sel" href="eventi.aspx">Eventi</a></li>
        <li><a href="ListaNozze.aspx">Lista Nozze</a></li>
        <li><a style="font-weight: bold;" href="javascript:scegliShop();"">Shop</a></li>
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
                <div class="intro-pages">
                    <blockquote>
                        <h3>
                            Tutti gli eventi promossi dalla <span class="colored">Matera Arredamenti</span>
                            per contribuire alla crescita<br />
                            civile, sociale e culturale della Comunità e del Territorio.</h3>
                    </blockquote>
                </div>
                <div id="portfolio">
                    <!--END filtering-nav-->
                    <div class="portfolio-container_ok">
                        <ul>
                            <asp:ObjectDataSource ID="objEventi" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="Tipo" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ListView ID="lvEventi" OnItemDataBound="lvEventiItemDataBound" OnDataBound="IsPagerVisible"
                                DataSourceID="objEventi" runat="server">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div class="one">
                                        <div class="inner-content">
                                                <p style="background-image: url('images/footer_shadow_M.png'); background-position: bottom;
                        background-repeat: no-repeat;border:none;padding-top:0px;width:710px; height: 259px;" class="intro-pages">
                                                <%--<a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.aspx'>--%>
                                                    <a href='EventoDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                    <img src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>' alt=""  />
                                                </a>
                                            </p>
                                        </div>
                                        <div style="height: 245px;" class="one-fourth last">
                                            <h6 class="colored">
                                                <%#Eval ("Titolo") %></h6>
                                            <p class="testo_cl_dx">
                                                <%# Utility.ShortDesc(Eval("Descrizione").ToString(),300).ToString() %>
                                            </p>
                                            
                                            <%-- <a 
                                            
                                            href='EventoDettaglio.aspx?Id=<%# Eval("News_ID")%>'>Leggi tutto →</a>--%>
                                        </div>
                                        <%--<a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.aspx'>
                                                Leggi tutto →</a>--%>
                                        <a href='EventoDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                Leggi tutto →</a>
                                    </div>
                                    <div class="horizontal-line">
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                        <!--END ul-->
                    </div>
                    <!--END portfolio-wrap-->
                </div>
            </div>
            <asp:DataPager runat="server" ID="pagerEventi" PageSize="5" PagedControlID="lvEventi">
                <Fields>
                    <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                        NumericButtonCssClass="my-blog-pagination" />
                </Fields>
            </asp:DataPager>
            <!-- CONTENT ENDS-->
        </div>
    </div>
</asp:Content>
