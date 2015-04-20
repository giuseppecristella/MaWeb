<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Default_r.master" AutoEventWireup="true" CodeFile="Carrello.aspx.cs" Inherits="Design_Carrello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div id="content">
        <div style="padding: 20px 0 20px 0;" class="one">
            <div class="headline">
                <h4>Il tuo Carrello
                </h4>
            </div>
        </div>
        <div style="min-height: 580px;" class="one">
            <div style="width: 195px;" class="one-fourth">
                <p>
                    Stai visualizzando i prodotti che intendi acquistare.
                </p>
                <p>
                    Puoi modificare la quantità dei prodotti o cancellarne alcuni.
                                <br />
                    Per confermare queste operazioni clicca il link 'Aggiorna il Carrello'.
                </p>
            </div>
            <div class="three-third">
                <asp:ListView runat="server" ID="lvCart" OnItemDataBound="lvDataBound">
                    <EmptyDataTemplate>
                        <div style="float: right; margin: auto; text-align: center; width: 700px;" class="simple-notice">
                            <strong>Attenzione: </strong>il tuo carrello è vuoto.
                        </div>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <table class="carrello">
                            <tr runat="server" id="itemPlaceholder" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Image runat="server" ID="imgprod" Width="100" />
                            </td>
                            <td>
                                <fieldset>
                                    <asp:HiddenField runat="server" ID="hfProductId" />
                                    <label style="width: 365px;" class="cartLabel">
                                        <asp:Literal runat="server" ID="lblnomeprod"></asp:Literal></label>
                                    <asp:Label runat="server" ID="lblprezzoun" Style="width: 60px;" class="cartLabel"></asp:Label>
                                    <asp:Label runat="server" ID="Label1" Style="width: 5px;" class="cartLabel_noborder">x</asp:Label>
                                    <asp:TextBox runat="server" ID="txtqta" CssClass="cartLabel" Style="width: 20px; height: 20px"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblprezzotot" Style="width: 70px;" class="cartLabel"></asp:Label>
                                </fieldset>
                                <br />
                                <fieldset>
                                    <asp:CheckBox runat="server" ID="chkDelete" Style="float: left;" />
                                    <label style="margin-left: 5px; float: left;">
                                        desidero eliminare questo articolo dal carrello</label>
                                    <asp:LinkButton runat="server" Style="float: right;" ID="lnkbtnDettProd" Text="visualizza dettagli articolo" />
                                </fieldset>
                                <fieldset>
                                </fieldset>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <asp:Panel runat="server" ID="pnlCartTotal">
                    <br />
                    <fieldset runat="server" id="msgError" visible="false" style="text-align: left" class="simple-error">
                        <strong>Attenzione: </strong>non è stato possibile completare l'operazione in quanto
                                    i prodotti evidenziati in rosso non sono disponbili nella quantità richiesta. Si
                                    prega di consultare la disponibilità nel dettaglio del prodotto.
                    </fieldset>
                    <fieldset>
                        <asp:LinkButton runat="server" ID="btnUpdateCart" Text="Aggiorna il Carrello"
                            OnClick="btnUpdateCart_Click" />
                        <label class="cartLabel" style="float: right; margin-right: 30px;">
                            Tot.&nbsp;
                                        <asp:Literal runat="server" ID="ltrSomma"></asp:Literal></label>
                    </fieldset>
                    <br />
                    <fieldset>
                        <asp:LinkButton Style="float: right; margin-right: 30px;" CssClass="fancy-button red small"
                            ID="LinkButton1" runat="server" OnClick="lnkbtncheckout_Click">Conferma ordine</asp:LinkButton>
                    </fieldset>
                    <br />
                    <fieldset>
                        <asp:LinkButton runat="server" Text="Continua lo shopping" ID="lnkbtnContinueShop"
                            CssClass="fancy-button red small" Style="float: right; margin-right: 30px;"
                            OnClick="lnkbtnContinueShop_Click"></asp:LinkButton>
                    </fieldset>
                    <div class="clear">
                    </div>
                </asp:Panel>
            </div>
            <div class="one-third">
            </div>
            <div class="one-third">
            </div>
            <div class="one-third last">
            </div>
        </div>
    </div>
</asp:Content>

