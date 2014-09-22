<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ListaNozze.aspx.cs" Inherits="ListaNozze" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul>
        <li><a href="azienda.aspx">Azienda</a></li>
        <li><a href="servizi.aspx">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a href="promozioni.aspx">Promozioni</a></li>
        <li><a href="eventi.aspx">Eventi</a></li>
        <li><a class="sel" href="ListaNozze.aspx">Lista Nozze</a></li>
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
                    <!-- COLUMNS CONTAINER STARTS-->
                    <div class="intro-pages">
                        <!-- INTRO DIV STARTS-->
                        <blockquote>
                            <h3>
                                Lista Nozze da Matera Arredamenti!
                                <br />
                                Per realizzare insieme <span class="colored">il sogno</span> dei futuri sposi!</h3>
                        </blockquote>
                    </div>
                    <!-- INTRO ENDS-->
                </div>
                <div class="one-third">
                    <p>
                        <img src="images/suggCasa.png" alt=" " width="300" height="170" class="portfolio-img pretty-box" />
                    </p>
                    <%--<h5 style="text-align: center" class="colored">
                        per la CASA</h5>--%>
               <%--     <blockquote>
                        Una serie di idee e consigli per la vostra casa proposte per voi dalla Matera Arredamenti.
                    </blockquote>--%>
                    <div class="horizontal-line">
                    </div>
                    <ul>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="updCasa">
                            <ContentTemplate>
                                <asp:ListView runat="server" ID="lvCasa" OnDataBound="_isPagerVisible" DataSourceID="objCasa">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <li style="height: 235px">
                                            <h6>
                                                <%# Eval("Titolo") %>
                                            </h6>
                                            <p>
                                                <%#Eval("Descrizione") %>
                                            </p>
                                            <%--<a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>
                                                [+ Leggi Tutto]</a> --%>
                                            <a href='ListaNozzeDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                [+ Leggi Tutto]</a> 

                                        </li>
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ul>
                </div>
                <div class="one-third">
                    <p>
                        <img src="images/suggCucina.png" alt=" " width="300" height="170" class="portfolio-img pretty-box" />
                    </p>
                    <%--<h5 style="text-align: center" class="colored">
                        per la CUCINA</h5>
                    <blockquote>
                        Le ricette per la buona cucina e la buona salute scelte per voi dalla Matera Arredamenti.
                        <br />
                    </blockquote>--%>
                    <div class="horizontal-line">
                    </div>
                    <ul>
                        <asp:UpdatePanel runat="server" ID="updCucina">
                            <ContentTemplate>
                                <asp:ListView runat="server" ID="lvCucina"  OnDataBound="_isPagerVisibleCucina" DataSourceID="objCucina">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <li style="height: 235px">
                                            <h6>
                                               
                                                    <%# Eval("Titolo") %> </h6>
                                            <p>
                                                <%#Eval("Descrizione") %>
                                            </p>
                                             <a href='ListaNozzeDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                [+ Leggi Tutto]</a>
                                          <%--  <a href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>[+ Vedi Lista Nozze]</a>--%> </li>
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ul>
                </div>
                <div class="one-third last">
                    <p>
                        <img src="images/suggManu.png" alt=" " width="300" height="170" class="portfolio-img pretty-box" />
                    </p>
                   <%-- <h5 style="text-align: center" class="colored">
                        per la MANUTENZIONE</h5>--%>
                   <%-- <blockquote>
                        La Matera Arredamenti vi offre utilissimi consigli per rendere i vostri mobili...<br />
                        mobili per la vita.
                    </blockquote>--%>
                    <div class="horizontal-line">
                    </div>
                    <ul>
                        <asp:UpdatePanel runat="server" ID="updManu">
                            <ContentTemplate>
                                <asp:ListView runat="server"   OnDataBound="_isPagerVisibleManu" ID="lvManutenzione"
                                    DataSourceID="objManutenzione">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <li style="height: 235px">
                                            <h6>
                                                
                                                    <%# Eval("Titolo") %> </h6>
                                            <p>
                                                <%#Eval("Descrizione") %>
                                            </p>
                                             <a href='ListaNozzeDettaglio.aspx?Id=<%# Eval("News_ID").ToString() %>'>
                                                [+ Leggi Tutto]</a>
                                          <%--  <a  href='<%# Eval("Titolo").ToString().Replace("%","").Replace("?","").Replace(" ","-") %>.html'>[+ Vedi Lista Nozze]</a>--%> </li>
                                        <div class="horizontal-line">
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:DataPager runat="server" ID="pagerManu" PageSize="3" PagedControlID="lvManutenzione">
                                    <Fields>
                                        <asp:NumericPagerField NextPreviousButtonCssClass="my-blog-pagination" CurrentPageLabelCssClass="my-blog-pagination-current"
                                            NumericButtonCssClass="my-blog-pagination" />
                                    </Fields>
                                </asp:DataPager>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ul>
                </div>
                <asp:ObjectDataSource ID="objCasa" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="2" Name="Tipo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCucina" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="4" Name="Tipo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objManutenzione" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetListaNews" TypeName="DataSetVepAdminTableAdapters.NewsTableAdapter">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3" Name="Tipo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <!-- CONTENT ENDS-->
        </div>
    </div>
</asp:Content>
