<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="servizi.aspx.cs" Inherits="Servizi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
    <ul>
        <li><a href="azienda.aspx">Azienda</a></li>
        <li><a class="sel" href="servizi.aspx">Servizi</a> </li>
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
                    <!-- COLUMNS CONTAINER STARTS-->
                    <div class="intro-pages">
                        <!-- INTRO DIV STARTS-->
                        <blockquote>
                            <h3>
                                La <span class="colored">Matera Arredamenti</span> è attenta ad ogni tua esigenza
                                <br />
                                e ti propone i migliori servizi per soddisfare la tua voglia d&#39;arredo.</h3>
                        </blockquote>
                    </div>
                    <!-- INTRO ENDS-->
                </div>
                <div id="portfolio_ok">
                    <!--END filtering-nav-->
                    <div class="portfolio-container_ok" id="columns">
                        <ul>
                            <li class="one-fourth web">
                                <p>
                                    <img src="images/ser-1.png" alt=" " width="210" height="145" class="portfolio-img pretty-box" />
                                </p>
                                <h5 style="height: 40px;" class="colored">
                                    Progettazione computerizzata</h5>
                                <p>
                                    Consulenza e progettazione personalizzata di elementi di arredo per ogni tipo di
                                    ambiente, curata da uno staff di professionisti in grado di risolvere ogni tipo
                                    di problematica.</p>
                            </li>
                            <li class="one-fourth logo">
                                <p>
                                    <img src="images/ser-2.png" alt=" " width="210" height="145" class="portfolio-img pretty-box" />
                                </p>
                                <h5 style="height: 40px;" class="colored">
                                    Trasporto e montaggio gratuito!</h5>
                                <p>
                                    Trasporto e montaggio effettuato da squadre specializzate, con l'ausilio di montacarichi
                                    esterno per l'accesso ai piani rialzati.
                                </p>
                            </li>
                            <li class="one-fourth video">
                                <p>
                                    <img src="images/ser-3.png" alt=" " width="210" height="145" class="portfolio-img pretty-box" />
                                </p>
                                <h5 style="height: 40px;" class="colored">
                                    Finanziamenti rateali personalizzabili</h5>
                                <p>
                                    La soluzione più adatta a soddisfare le tue esigenze.</p>
                            </li>
                            <li class="one-fourth web">
                                <p>
                                    <img src="images/ser-4.png" alt=" " width="210" height="145" class="portfolio-img pretty-box" />
                                </p>
                                <h6 style="height: 40px;" class="colored">
                                    Assistenza post-vendita</h6>
                                <p>
                                    Assistenza post vendita per tutti i tipi di arredi venduti.
                                </p>
                            </li>
                        </ul>
                        <!--END ul-->
                    </div>
                    <!--END portfolio-wrap-->
                </div>
            </div>
            <!-- CONTENT ENDS-->
        </div>
    </div>
</asp:Content>
