<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="newsletter.aspx.cs" Inherits="newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="wrapper_pepp">
        <div id="container">
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <div class="one">
                    <!-- COLUMNS CONTAINER STARTS-->
                    <div class="intro-pages">
                        <!-- INTRO DIV STARTS-->
                        <blockquote>
                            <h3>
                                Iscriviti alle nostre Newsletters per rimanere sempre aggiornato
                                <br />
                                su tutte le <span class="colored">promozioni</span> e su gli <span class="colored">eventi</span>
                                da noi proposti.
                            </h3>
                        </blockquote>
                    </div>
                    <!-- INTRO ENDS-->
                </div>
                <div class="one">
                    <p>
                        <span class="higlight">Iscrizione alle Newsletters</span>
                    </p>
                    <p>
                        Gentile utente, se desidera registrare l'indirizzo e-mail:
                        <asp:Label CssClass="colored" runat="server" ID="lblMail" Text=""></asp:Label>
                        nei nostri database per l'iscrizione al servizio di Newsletter, presti il consenso
                        e prema il tasto 'iscriviti'</p>
                    <p>
                        <b>DICHIARAZIONE DI CONSENSO</b><br />
                        Letta l'informativa di cui sopra ai sensi dell'art. 13 del D. lgs. 30 giugno 2003,
                        n. 196: per quanto riguarda il trattamento dei dati personali per l'invio, da parte
                        della Newsletter elettronica, l’invio di materiale pubblicitario e promozionale
                        dei propri prodotti e servizi e di quelli delle società partner del Comitato, per
                        indagini di rilevazione e per la partecipazione a ulteriori operazioni di promozione.
                    </p>
                    <div class="clear-line">
                    </div>
                    <div class="right">
                        <asp:CheckBox ID="CheckBoxcons" runat="server" />Presto il consenso &nbsp;
                        <asp:Button ID="btnIscrivi" CssClass="fancy-button red small" runat="server" Text="Iscriviti"
                            OnClick="btnIscrivi_Click" />
                    </div>
                    <asp:Panel ID="notificationSucc" runat="server" Visible="false">
                        <div class="simple-success one-half">
                            <div>
                                <asp:Label ID="lblNewslOK" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="notificationpnl" runat="server" Visible="false">
                        <div class="simple-error one-half">
                            <%--<a href="#" class="close"><img src="admin_MA/resources/images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>--%>
                            <div>
                                <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="horizontal-line">
                    </div>
                    <div class="one">
                        <p>
                            <span class="higlight">Cancellazione dalle Newsletters</span>
                        </p>
                        <p>
                            Se non desidera più ricevere le nostre Newsletters selezioni il tasto 'Cancella'
                            e il Suo indirizzo e-mail sarà cancellato da questo servizio.&nbsp;
                        </p>
                        <p class="right">
                            <asp:Button ID="btnCancella" CssClass="fancy-button red small" runat="server" Text="Cancella"
                                OnClick="btnCancella_Click" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
