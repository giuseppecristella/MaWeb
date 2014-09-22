<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Offerte.aspx.cs" Inherits="Offerte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul>
        <li><a href="azienda.html">Azienda</a></li>
        <li><a href="servizi.html">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a href="promozioni.html">Promozioni</a></li>
        <li><a class="sel" href="Offerte.aspx">Offerte</a></li>
        <li><a href="eventi.html">Eventi</a></li>
        <li><a href="suggerimenti.html">Suggerimenti</a></li>
        <li><a href="#" title="Home">Matera Traslochi</a> </li>
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
                <asp:ObjectDataSource ID="objOfferte" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetProdotti" TypeName="DataSetMateraArredamentiTableAdapters.OutletTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="ProdottoID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProdottoNome" Type="String" />
                        <asp:Parameter Name="ProdottoDescHome" Type="String" />
                        <asp:Parameter Name="ProdottoDescScheda" Type="String" />
                        <asp:Parameter Name="ProdottoPrezzo" Type="Decimal" />
                        <asp:Parameter Name="ProdottoPrezzoSconto" Type="Decimal" />
                        <asp:Parameter Name="ProdottoInVetrina" Type="Boolean" />
                        <asp:Parameter Name="ProdottoFoto" Type="String" />
                        <asp:Parameter Name="ProdottoID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProdottoNome" Type="String" />
                        <asp:Parameter Name="ProdottoDescHome" Type="String" />
                        <asp:Parameter Name="ProdottoDescScheda" Type="String" />
                        <asp:Parameter Name="ProdottoPrezzo" Type="Decimal" />
                        <asp:Parameter Name="ProdottoPrezzoSconto" Type="Decimal" />
                        <asp:Parameter Name="ProdottoInVetrina" Type="Boolean" />
                        <asp:Parameter Name="ProdottoFoto" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <div id="portfolio">
                    <!--END filtering-nav-->
                    <div class="portfolio-container_ok" id="columns">
                        <ul>
                            <asp:ListView runat="server" ID="lvOfferte" DataSourceID="objOfferte">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <li class="one-fourth web">
                                        <p>
                                            <a href='<%#Eval("ProdottoFoto") %>' class="portfolio-item-preview" data-rel="prettyPhoto">
                                                <img src='<%# Eval("ProdottoFoto") %>' alt=" " width="210" height="145" class="portfolio-img pretty-box" /></a>
                                        </p>
                                        <h5 class="colored">
                                            <%# Utility.ShortDesc(Eval("ProdottoNome").ToString(),50).ToString() %>
                                        </h5>
                                        <p>
                                            <%#Eval("ProdottoDescHome") %></p>
                                        <p>
                                            <%--                                            <%# Utility.ShortDesc(Eval("ProdottoDescScheda").ToString(),80).ToString() %> ...
--%>
                                            Prezzo Listino: <span style="text-decoration: line-through">€.
                                                <%# Eval("ProdottoPrezzo") %></span>
                                        </p>
                                        <p>
                                            Offerta Matera Arredamenti: <span style="color: #F01E31;">€.
                                                <%#Eval("ProdottoPrezzoSconto") %></span></p>
                                        <a href='OffertaDettaglio.aspx?Id=<%#Eval("ProdottoID") %>'>Dettaglio Offerta →</a>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                        <!--END ul-->
                    </div>
                    <!--END portfolio-wrap-->
                </div>
            </div>
            <!--PAGINATION-->
            <asp:DataPager runat="server" ID="pagerOfferte" PageSize="12" PagedControlID="lvOfferte">
                <Fields>
                    <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                        NumericButtonCssClass="my-blog-pagination" />
                </Fields>
            </asp:DataPager>
            <!-- CONTENT ENDS-->
        </div>
    </div>
</asp:Content>
