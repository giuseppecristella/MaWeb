<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="azienda.aspx.cs"
    Inherits="Azienda" Title="Matera Arredamenti - Mobili per la vita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        jQuery(document).ready(function($) {
            $(".slider").slideshow({
                width: 360,
                height: 350,
                transition: ['barLeft', 'barRight', 'rain', 'fountain']
            });
        });
    </script>

    <script type="text/javascript">

        $(document).ready(function($) {
            $('div.portfolio-container ul.portfolio-container-items li').show();

            $('div.portfolio-container').slider
	({
	    nav: 'ul.slider-nav',
	    items: 'ul.portfolio-container-items',
	    wrapper_class: 'clients-wrapper',
	    visible: 5,
	    slide: 4
	});    

        }); 
    </script>

</asp:Content>
<asp:Content ID="ContentNavigoss" runat="server" ContentPlaceHolderID="ContentPlaceHolderNavigoss">
    <ul>
        <li><a class="sel" href="azienda.aspx">Azienda</a></li>
        <li><a href="servizi.aspx">Servizi</a> </li>
        <li><a href="http://www.wm4pr.com/it/Home/Index3/19582">Prodotti</a> </li>
        <li><a href="promozioni.aspx">Promozioni</a></li>
        <li><a href="eventi.aspx">Eventi</a></li>
        <li><a href="ListaNozze.aspx">Lista Nozze</a></li>
        <li><a style="font-weight: bold;" href="javascript:scegliShop();">Shop</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <!--WRAPPER-->
    <div class="wrapper_pepp">
        <div id="container">
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <div class="one">
                    <!-- COLUMNS CONTAINER STARTS-->
                    <div style="border: none;" class="intro-pages">
                        <!-- INTRO DIV STARTS-->
                        <div class="one-half">
                            <%--                        <img style="width: 460px; height: 365px; overflow: hidden;" src="images/2.jpg" />
--%>
                            <iframe width="460" height="365" src="http://www.youtube.com/embed/ye2I8WvFx90" frameborder="0"
                                allowfullscreen></iframe>
                        </div>
                        <div class="one-half last">
                            <h5>
                                <b>La Nostra Storia</b></h5>
                            <p>
                                La <b>Matera Arredamenti</b> è un’azienda di quelle da manuale dell’imprenditore.<br />
                                Nasce nel 1976, grazie alla passione e alla tenacia del suo titolare, <b>Giovanni Matera,</b>
                                proveniente da una storica bottega di falegnameria locale.<br />
                                Sin da piccolo Giovanni, com’era d’uso nelle umili famiglie di paese, è avviato
                                a bottega e lì respira il profumo d’ogni essenza, entra in contatto con la materia
                                viva, impara a darle forma secondo i canoni della migliore tradizione. I suoi gesti
                                quotidiani rivelano da subito l’amore per le cose belle, tanto che le sue produzioni
                                sembrano più oggetti d’arte che semplici mobili.
                                <br />
                                Dopo circa un ventennio di apprendistato e perfezionamento - vissuto parallelamente
                                anche tra i banchi di scuola, dove consegue il diploma di maturità – il giovane
                                Giovanni si sente pronto per realizzare il sogno che coltiva sin da bambino: creare
                                un’azienda tutta sua; cosa non facile in verità, sia per la mancanza di mezzi sia
                                anche per le oggettive difficoltà burocratiche e di mercato.
                                <br />
                                Ma il ragazzo è credibile e determinato a realizzare il suo sogno.
                                <br />
                                Allora, suo padre, non sapendo come aiutarlo, gli dona il suo campo di ceci; ed
                                è proprio su quel campo che oggi si erge una bella azienda, moderna, elegante e
                                in continua espansione: la <b>MATERA ARREDAMENTI.</b>
                            </p>
                        </div>
                    </div>
                    <div class="horizontal-line">
                    </div>
                    <!-- INTRO ENDS-->
                </div>
                <!-- COLUMNS CONTAINER ENDS-->
                <div class="one">
                    <h5>
                        <b>La nostra Mission</b></h5>
                    <div class="one-half">
                        <blockquote style="color: #666666;">
                            <%--                            <img src="PortableStudio/images/avatar-4.jpg" alt=" " width="60" height="60" class="img-align-left" />
--%>
                            <p>
                                <span class="higlight">Il nostro business è garantire serenità.</span> Di conseguenza
                                la gente deve potersi fidare di noi e non può farlo se non agiamo in modo eticamente
                                responsabile e non sviluppiamo con i nostri clienti delle relazioni corrette e positive
                                che li lascino entusiasti del servizio ricevuto.</p>
                            <br />
                        </blockquote>
                    </div>
                    <div class="one-half last">
                        <blockquote style="color: #666666;">
                            <span class="higlight">Rispettare ogni persona e le sue idee</span> incoraggiare
                            lo spirito di iniziativa dei suoi collaboratori, offrendo loro crescita professionale
                            e benessere economico.
                        </blockquote>
                    </div>
                    <div class="clear-line">
                    </div>
                    <div class="one-half">
                        <!-- INTRO DIV STARTS-->
                        <blockquote style="color: #666666;">
                            <span class="higlight">Contribuire allo sviluppo della comunità</span> esercitando
                            funzioni di guida nella pratica dei nostri valori.
                        </blockquote>
                    </div>
                    <div class="one-half last">
                        <!-- INTRO DIV STARTS-->
                        <blockquote style="color: #666666;">
                            <span class="higlight">Il Cliente è il Nostro Primo Patrimonio,</span> Vendiamo
                            Qualità Consulenza ed Emozioni.
                        </blockquote>
                    </div>
                </div>
                <!-- COLUMNS CONTAINER ENDS-->
                <div style="border: none;" class="horizontal-line">
                </div>
                <!--LOGHI PRODOTTI-->
            </div>
        </div>
        <!-- CONTAINER ENDS-->
    </div>
</asp:Content>
