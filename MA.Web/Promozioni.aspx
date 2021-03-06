﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="promozioni.aspx.cs" Inherits="Promozioni" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul>
        <li><a href="azienda.aspx">Azienda</a></li>
        <li><a href="servizi.aspx">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a class="sel" href="promozioni.aspx">Promozioni</a></li>
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
                        <blockquote>
                            <h3>
                                Visita questa pagina e resta aggiornato su tutte le nostre fantastiche promozioni.<br />
                                La <span class="colored">Matera Arredamenti</span> ti offrirà quella più adatta
                                a te.</h3>
                        </blockquote>
                    </div>
                </div>
                <asp:ObjectDataSource ID="objPromo" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="5" Name="Tipo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ListView ID="lvPromo" OnDataBound="IsPagerVisible" DataSourceID="objPromo" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="one">
                            <div class="inner-content">
                                <p style="background-image: url('images/footer_shadow_M.png'); background-position: bottom;
                                    background-repeat: no-repeat; border: none; padding-top: 0px; width: 710px; height: 259px;"
                                    class="intro-pages">
                                    <a href="<%# FriendlyUrl.Href("PromoDettaglio", Eval("News_ID"), Eval("Titolo")) %>" >
                                        <img style="margin: auto;" src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>'
                                            alt="" /></a>

                                </p>
                            </div>
                            <div style="height: 245px;" class="one-fourth last">
                                <h6 class="colored">
                                    <%#Eval ("Titolo") %></h6>
                                <p class="testo_cl_dx">
                                    <%# Helper.GetShortStringAndCleanTags(Eval("Descrizione").ToString(),300) %>
                                </p>
                            </div>
                             <a href="<%# FriendlyUrl.Href("PromoDettaglio", Eval("News_ID"), Eval("Titolo")) %>">
                                        Scopri tutti i dettagli →</a>
                        </div>
                        <div class="horizontal-line">
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <asp:DataPager runat="server" ID="pagerPromo" PageSize="5" PagedControlID="lvPromo">
                <Fields>
                    <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                        NumericButtonCssClass="my-blog-pagination" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
