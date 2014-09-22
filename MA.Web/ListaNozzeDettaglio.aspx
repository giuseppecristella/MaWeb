<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ListaNozzeDettaglio.aspx.cs"
    Inherits="ListaNozzeDettaglio" Title="Matera Arredamenti - Mobili per la vita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul>
        <li><a href="azienda.aspx">Azienda</a></li>
        <li><a href="servizi.aspx">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a href="promozioni.aspx">Promozioni</a></li>
        <li><a href="eventi.aspx">Eventi</a></li>
        <li><a class="sel" href="suggerimenti.aspx">Lista Nozze</a></li>
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
                            <img src="images/suggerimenti.jpg" alt=" " width="710" height="210" />
                        </p>
                        <asp:Repeater ID="rptPromo" DataSourceID="objSuggerimento" runat="server">
                            <ItemTemplate>
                                <p>
                                    <h3>
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
                                    <a href='listanozze.aspx'>[- Elenco Liste Nozze]</a></p>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div style="height:180px;">
                        <asp:Literal runat="server" ID="ltrSocial" Text=""></asp:Literal></div>
                    </div>
                    <div class="one-fourth last">
                        <div class="clear-line">
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                       <%-- <img src="images/suggCasa.png" alt=" " width="217" />--%>
                      <%--  <h4 class="blog-category intro-pages">
                            Casa</h4>--%>
                            <asp:UpdatePanel runat="server" ID="updCasa"><ContentTemplate>
                        <asp:ListView ID="lvCasa" OnDataBound="_isPagerVisible" DataSourceID="objCasa" runat="server">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="one-fourth last">
                                    <h6 class="grigio">
                                        
                                            <%#Eval ("Titolo") %> </h6>
                                    <p>
                                        <%# Utility.ShortDesc(Eval("Descrizione").ToString(),300).ToString() %>
                                         
                                         
                                       
                                    </p>
                                     <a href='ListaNozzeDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                [+ Leggi Tutto]</a>
                                  <%--   <a  href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>[+ Vedi Lista Nozze]</a>--%>
                                </div>
                                   
                                <div class="horizontal-line">
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:DataPager runat="server" ID="pagerCasa" PageSize="3" PagedControlID="lvCasa">
                            <Fields>
                                <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                                    NumericButtonCssClass="my-blog-pagination" />
                            </Fields>
                        </asp:DataPager>
                        </ContentTemplate></asp:UpdatePanel>
                        <div class="clear-line">
                        </div>
                        <div style="border:none;" class="horizontal-line">
                        </div>
                       <%-- <img src="images/suggCucina.png" alt=" " width="217" />--%>
                    <%--    <h4 class="blog-category intro-pages">
                            Cucina</h4>--%>
                            <asp:UpdatePanel runat="server" ID="updCucina"><ContentTemplate>
                        <asp:ListView ID="lvCucina" OnDataBound="_isPagerVisibleCucina" DataSourceID="objCucina"
                            runat="server">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="one-fourth last">
                                    <h6 class="grigio">
                                        
                                            <%#Eval ("Titolo") %> </h6>
                                    <p>
                                        <%# Utility.ShortDesc(Eval("Descrizione").ToString(),300).ToString() %>
                                        
                                        
                                    </p>
                                     <a href='ListaNozzeDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                [+ Leggi Tutto]</a>
                                    <%--<a  href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>[+ Vedi Lista Nozze]</a>--%>
                                </div>
                                   
                                <div class="horizontal-line">
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:DataPager runat="server" ID="pagerCucina" PageSize="3" PagedControlID="lvCucina">
                            <Fields>
                                <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                                    NumericButtonCssClass="my-blog-pagination" />
                            </Fields>
                        </asp:DataPager>
                        </ContentTemplate></asp:UpdatePanel>
                       <div style="border:none;" class="horizontal-line">
                     <%--   <img src="images/suggManu.png" alt=" " width="217" />--%>
                       <%-- <h4 class="blog-category intro-pages">
                            Manutenzione</h4>--%>
                            <asp:UpdatePanel runat="server" ID="updManu"><ContentTemplate>
                        <asp:ListView ID="lvManu" OnDataBound="_isPagerVisibleManu" DataSourceID="objManu"
                            runat="server">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="one-fourth last">
                                    <h6 class="grigio">
                                        
                                            <%#Eval ("Titolo") %> </h6>
                                    <p>
                                        <%# Utility.ShortDesc(Eval("Descrizione").ToString(),3100).ToString() %>
                                        
                                        
                                    </p>
                                     <a href='ListaNozzeDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                [+ Leggi Tutto]</a>
                                   <%-- <a  href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>[+ Vedi Lista Nozze]</a>--%>
                                </div>
                                   
                                <div class="horizontal-line">
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:DataPager runat="server" ID="pagerManu" PageSize="3" PagedControlID="lvManu">
                            <Fields>
                                <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                                    NumericButtonCssClass="my-blog-pagination" />
                            </Fields>
                        </asp:DataPager>
                        </ContentTemplate></asp:UpdatePanel>
                        <div style="border:none;" class="horizontal-line">
                    </div>
                    <!-- COLUMNS CONTAINER ENDS-->
                </div>
            </div>
            <!-- CONTENT ENDS-->
        </div>
        <asp:ObjectDataSource ID="objCasa" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="Tipo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="objCucina" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="Tipo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="objManu" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetListaNews" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="Tipo" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="objSuggerimento" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByID" TypeName="DataSetMateraArredamentiTableAdapters.NewsTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="News_ID" QueryStringField="Id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
