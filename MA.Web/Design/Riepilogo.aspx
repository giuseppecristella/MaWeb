<%@ Page Title="" Language="C#" MasterPageFile="Default_r.master" AutoEventWireup="true"
    CodeFile="Riepilogo.aspx.cs" Inherits="Riepilogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div style="padding: 20px 0 20px 0;" class="one">
        <div class="headline">
            <h4>
                Il tuo Ordine
            </h4>
        </div>
    </div>
    <div class="one">
        <div style="margin-left: 30px; width: 195px;" class="one-fourth">
            <p>
                Stai visualizzando il riepilogo dei prodotti che intendi acquistare.
            </p>
            <p>
                I prezzi si intendono IVA inclusa.
                <br />
                Per procedere con l'operazione di pagamento clicca il tasto 'Vai a Pagare'.
            </p>
        </div>
        <div class="three-third">
            <asp:Label runat="server" ID="lblSella"></asp:Label>
            <asp:ListView runat="server" ID="lvCart" OnItemDataBound="lvCartOnItemDataBound">
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
                                <label style="width: 320px;" class="cartLabel">
                                    <asp:Literal runat="server" ID="lblnomeprod"></asp:Literal></label>
                                <asp:Label runat="server" ID="lblprezzoun" Style="width: 60px;" class="cartLabel"></asp:Label>
                                <asp:Label runat="server" ID="Label1" Style="width: 5px;" class="cartLabel_noborder">x</asp:Label>
                                <asp:Label runat="server" ID="txtqta" CssClass="cartLabel" Style="width: 20px; height: 20px"></asp:Label>
                                <asp:Label runat="server" ID="lblprezzotot" Style="width: 70px;" class="cartLabel"></asp:Label>
                            </fieldset>
                            <br />
                            <fieldset>
                                <asp:LinkButton runat="server" Style="float: right;" ID="lnkbtnDettProd" Text="visualizza dettagli articolo" />
                            </fieldset>
                            <fieldset>
                            </fieldset>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <fieldset>
                <label class="cartLabel" style="float: right; margin-right: 30px;">
                    Spese di spedizione €.&nbsp;
                    <asp:Literal runat="server" ID="ltrSped"></asp:Literal></label>
                <asp:Label runat="server" ID="Label1" Style="width: 5px; float: right" class="cartLabel_noborder">+</asp:Label>
                <label class="cartLabel" style="float: right">
                    Subtotale €.&nbsp;
                    <asp:Literal runat="server" ID="ltrSubTot"></asp:Literal></label>
            </fieldset>
            <br />
            <fieldset>
                <label class="cartLabel" style="float: right; margin-right: 30px;">
                    Totale €.&nbsp;
                    <asp:Literal runat="server" ID="ltrSomma"></asp:Literal></label>
            </fieldset>
            <br />
            <fieldset>
                <asp:LinkButton runat="server" Text="Vai a pagare" ID="lnkbtnOrder" CssClass="fancy-button red small"
                    Style="float: right; margin-right: 30px;" OnClick="lbOrder_Click"></asp:LinkButton>
            </fieldset>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
