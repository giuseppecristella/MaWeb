<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Contatti.aspx.cs"
    Inherits="contact" Title="Matera Arredamenti - Mobili per la vita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=ABQIAAAAAKhnZ3dsoP1Nlv4X641D8BRuwj8lzoMFOKv-Vh5uh4y0vqtVuxTb7x6npQfmkyJzji1CUipnnISx9g"
        type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNavigoss" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div class="wrapper_pepp">
        <div id="container">
            <!-- MAIN CONTAINER -->
            <!-- HEADER ENDS-->
            <!--  HEADER ENDS-->
            <div id="content">
                <!-- COLUMNS CONTAINER ENDS-->
                <div class="one">
                    <div style="border: none; background-image: url('images/footer_shadow.png'); background-position: bottom;
                        background-repeat: no-repeat;" class="intro-pages">
                        <div id="Gmap" style="width: 960px; height: 350px">
                        </div>
                    </div>
                </div>
                <div class="one">
                    <div class="horizontal-line">
                    </div>
                    <div class="one-half">
                        <form action="" id="contact-form" method="post">
                        <fieldset>
                            <label>
                                Nome <span class="required">*</span></label>
                            <asp:TextBox Width="200" AutoPostBack="false" CssClass="text requiredField" ID="name"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="simple-error" ControlToValidate="name" ID="rfvName"
                                runat="server" ErrorMessage="Inserire nome."></asp:RequiredFieldValidator>
                        </fieldset>
                        <fieldset>
                            <label>
                                Email <span class="required">*</span></label>
                            <asp:TextBox Width="200" AutoPostBack="false" CssClass="text requiredField email"
                                ID="email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="simple-error" ControlToValidate="email" ID="rfvMail"
                                runat="server" ErrorMessage="Inserire un indirizzo e-mail valido."></asp:RequiredFieldValidator>
                        </fieldset>
                        <fieldset>
                            <label>
                                Oggetto <span class="required">*</span></label>
                            <asp:TextBox Width="200" AutoPostBack="false" CssClass="text requiredField subject"
                                ID="oggetto" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator Style="z-index: 3" CssClass="simple-error" ControlToValidate="oggetto"
                                ID="rfvOggetto" runat="server" ErrorMessage="Inserire l'oggetto del messaggio."></asp:RequiredFieldValidator>
                        </fieldset>
                        <fieldset>
                            <label>
                                Messaggio <span class="required">*</span></label>
                            <asp:TextBox AutoPostBack="false" TextMode="MultiLine" CssClass="text requiredField"
                                ID="messaggio" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            <asp:RequiredFieldValidator CssClass="simple-error" ControlToValidate="messaggio"
                                ID="rfvmessaggio" runat="server" ErrorMessage="Inserire il testo del messaggio da inviare."></asp:RequiredFieldValidator>
                            <asp:Panel ID="notificationSucc" runat="server" Visible="false">
                                <div class="simple-success">
                                    <div>
                                        <asp:Label ID="lblInvioOK" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="notificationErr" runat="server" Visible="false">
                                <div class="simple-error">
                                    <div>
                                        <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                        </fieldset>
                        <fieldset>
                            <br />
                            <asp:Button ID="btnInvioMail" CssClass="fancy-button red small" runat="server" Text="invia"
                                OnClick="btnInvioMail_Click" />
                        </fieldset>
                        <fieldset>
                        </fieldset>
                        </form>
                        <!--END form ID contact_form-->
                    </div>
                    <div class="one-half last">
                        <h3>
                            Venite a trovarci</h3>
                        <p>
                            Venite a visitare il nostro Showroom, a Laterza, in via Selva San Vito 23.<br />
                            Vi stupiremo con le nostre tante soluzioni d’arredo e se siete di fuori città<br />
                            sarete nostri graditi ospiti a pranzo.
                        </p>
                        <div class="one-fourth">
                            <p>
                                <strong>Dove Siamo</strong>
                            </p>
                            <p>
                                Via Selva San Vito, 23
                                <br />
                                74014 - Laterza (TA)<br />
                            </p>
                            <p>
                                <strong>Info</strong>
                            </p>
                            <p>
                                Tel / Fax: (+39) 099 82 16 774<br />
                                Cell: (+39) 338 49 01 627
                                <br />
                                E-Mail: <a href="mailto:info@materarredamenti.it">info@materarredamenti.it</a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
