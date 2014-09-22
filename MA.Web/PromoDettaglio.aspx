<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PromoDettaglio.aspx.cs"
    Inherits="PromoDettaglio" Title="Matera Arredamenti - Mobili per la vita" %>
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
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <!-- COLUMNS CONTAINER ENDS-->
                <div class="one">
                    <div class="inner-content">
                        <asp:Repeater ID="rptPromo" DataSourceID="objPromo" runat="server">
                            <ItemTemplate>
                                <p>
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
                                    <a href='promozioni.aspx'>[- Ritorna alle Promozioni]</a></p>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal runat="server" ID="ltrSocial" Text=""></asp:Literal>
                        <!--PAGINATION ENDS-->
                    </div>
                    <div class="one-fourth last">
                        <h4 class="blog-category intro-pages">
                            Tutte le Promozioni</h4>
                        <asp:ListView ID="rptPromozioni" DataSourceID="objPromoss" runat="server">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="one-fourth last">
                                    <p>
                                        <img width="212px;" style="border: 1px solid #efefef;" src='<%#(Eval("UrlFotoHome").ToString().Replace("\\","/")) %>'
                                            alt=" " />
                                    </p>
                                    <h6 class="grigio">
                                        <%#Eval ("Titolo") %>
                                    </h6>
                                    <p>
                                        <%# Utility.ShortDesc(Eval("Testo").ToString(),300).ToString() %>
                                        ...
                                    </p>
                                    <%--a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.aspx'>--%>
                                        <a href='PromoDettaglio.aspx?Id=<%# Eval("News_ID").ToString()%>'>
                                        Scopri tutti i dettagli →</a>
                                </div>
                                <div class="horizontal-line">
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <div class="clear-line">
                        </div>
                        <asp:DataPager runat="server" ID="pagerPromo" PageSize="3" PagedControlID="rptPromozioni">
                            <Fields>
                                <asp:NumericPagerField CurrentPageLabelCssClass="my-blog-pagination-current" NumericButtonCssClass="my-blog-pagination" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                    <!-- COLUMNS CONTAINER ENDS-->
                </div>
            </div>
            <!-- CONTENT ENDS-->
        </div>
        <asp:ObjectDataSource ID="objPromoss" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="5" Name="Tipo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="objPromo" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByID" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="News_ID" QueryStringField="Id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
