<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="errore.aspx.cs" Inherits="errore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMenu" runat="Server">
    <ul class="navigation">
        <li><a href="default.aspx">Home</a></li>
        <li><a href="azienda.html" title="">AZIENDA</a></li>
        <li><a href="servizi.html">SERVIZI</a></li>
        <li><a href="eventi.html?Tipo=1">EVENTI</a></li>
        <li><a href="RicForm.aspx?Tipo=0">RICERCA E FORMAZIONE</a></li>
        <li><a href="questionario.aspx">QUESTIONARIO</a></li>
        <li><a href="contact.aspx">CONTATTACI</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="Server">
    <div style="width: 620px;" class="notification error png_bg">
        <%--<a href="#" class="close"><img src="admin_MA/resources/images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>--%>
        <div>
            <p>
                Errore inserimento indirizzo e-mail.</p>
        </div>
    </div>
    <div id="contact" class="panel">
        <div class="panel-content">
            <p>
                <b style="color: #bf0000; text-align: center">Attenzione:</b> L'indirizzo email
                inserito non rispetta il formato corretto. Verificare che sia stato digitato correttamente
                es. <b style="color: #bf0000; text-align: center">nome@host</b>.<br />
                Inserirlo nuovamente se si desidera iscriversi o cancellarsi dal nostro servizio
                di Newsletter.
            </p>
            <%--<div style="padding: 10px 10px 5px 11px;">
               <img src="images/logoMA_banner.jpg"/ alt=""/>
               </div>--%>
            <div style="text-align: center;">
                <asp:TextBox ID="txtNewsLettererr" Width="180px" onfocus="if(this.value=='indirizzo email...'){this.value=''};"
                    onblur="if	(this.value==''){this.value='indirizzo email...'};" runat="server"
                    Text="indirizzo email..."></asp:TextBox>
                <asp:Button ID="btnIndietro" CssClass="pulsante" runat="server" Text="Continua" OnClick="btnIndietro_Click" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
