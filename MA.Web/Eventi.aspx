<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="eventi.aspx.cs" Inherits="Eventi" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

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
            <div id="content">
                <div class="intro-pages">
                    <blockquote>
                        <h3>
                            Tutti gli eventi promossi dalla <span class="colored">Matera Arredamenti</span>
                            per contribuire alla crescita<br />
                            civile, sociale e culturale della Comunità e del Territorio.</h3>
                    </blockquote>
                </div>
                <div id="portfolio">
                    <div class="portfolio-container_ok">
                        <ul>
                            <asp:ObjectDataSource ID="objEventi" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
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
                                    <div class="one">
                                        <div class="inner-content">
                                                <p style="background-image: url('images/footer_shadow_M.png'); background-position: bottom;
                                                          background-repeat: no-repeat;border:none;
                                                          padding-top:0;width:710px; height: 259px;" class="intro-pages">
                                                        <a href="<%# FriendlyUrl.Href("~/EventoDettaglio/",Eval("News_ID"),Eval("Titolo")) %>">
                                                   
                                                    <img src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>' alt=""  />
                                                </a>
                                            </p>
                                        </div>
                                        <div style="height: 245px;" class="one-fourth last">
                                            <h6 class="colored">
                                                <%#Eval ("Titolo") %></h6>
                                            <p class="testo_cl_dx">
                                                <%# Helper.GetShortStringAndCleanTags(Eval("Descrizione").ToString(),300) %>
                                            </p>
                                        </div>
                                        <a href="<%# FriendlyUrl.Href("~/EventoDettaglio/",Eval("News_ID"),Eval("Titolo")) %>">
                                                Leggi tutto →</a>
                                    </div>
                                    <div class="horizontal-line">
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                    </div>
                </div>
            </div>
            <asp:DataPager runat="server" ID="pagerEventi" PageSize="5" PagedControlID="lvEventi">
                <Fields>
                    <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                        NumericButtonCssClass="my-blog-pagination" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
