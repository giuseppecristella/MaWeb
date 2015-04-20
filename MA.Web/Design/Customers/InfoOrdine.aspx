<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Customers/Default.master"
    AutoEventWireup="true" CodeFile="InfoOrdine.aspx.cs" Inherits="Ordini" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">

    <div style="padding: 20px 0 20px 0;" class="one">
        <div class="headline">
            <h4>Dettaglio ordine n.
                                <asp:Label runat="server" ID="lblNumOrdine"></asp:Label></h4>
        </div>
    </div>

    <div class="one">
        <asp:ListView runat="server" ID="lvOrders" OnItemDataBound="lvDataBound">
            <EmptyDataTemplate>
                <div class="ribbonbig" style="margin-bottom: 300px;">
                    <div class="lijevo fl" style="padding-left: 20px;">
                        <div class="bigtitle">
                            Nessun ordine disponibile
                        </div>
                    </div>
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
                        <fieldset>
                            <label style="width: 140px;" class="cartLabel">
                                ID:&nbsp; <span class="nero">
                                    <asp:Literal runat="server" ID="ltrProdId"></asp:Literal></span></label>
                            <label style="width: 400px;" class="cartLabel">
                                Prodotto:&nbsp; <span class="nero">
                                    <asp:Literal runat="server" ID="ltrnomeprod"></asp:Literal></span>
                            </label>
                            <label style="width: 90px;" class="cartLabel">
                                Qta:&nbsp; <span class="nero">
                                    <asp:Literal runat="server" ID="txtqtaprod"></asp:Literal></span></label>
                            <label style="width: 100px;" class="cartLabel">
                                Prezzo&nbsp;€.&nbsp;<span class="nero">
                                    <asp:Literal runat="server" ID="ltrprezzoun"></asp:Literal></span></label>
                            <label style="width: 100px;" class="cartLabel">
                                Totale&nbsp;€.&nbsp;<span class="nero">
                                    <asp:Literal runat="server" ID="ltrprezzotot"></asp:Literal></span></label>
                        </fieldset>
                        <br />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <fieldset style="margin-right: 30px;">
            <label class="cartLabel" style="float: right">
                Spese di spedizione&nbsp;€.&nbsp;<span class="nero">
                    <asp:Literal runat="server" ID="ltrSped"></asp:Literal></span></label>
            <label class="cartLabel" style="float: right">
                Subtotale&nbsp;€.&nbsp;<span class="nero">
                    <asp:Literal runat="server" ID="ltrSubTot"></asp:Literal></span></label>
        </fieldset>
        <br />
        <fieldset style="margin-right: 30px;">
            <label class="cartLabel" style="float: right">
                Totale&nbsp;€.&nbsp;<span class="nero">
                    <asp:Literal runat="server" ID="ltrSomma"></asp:Literal></span></label>
        </fieldset>
        <br />
    </div>
    <div style="margin-left: 30px;" class="one-fourth">
        <h6>Indirizzo spedizione:</h6>
        <asp:Literal runat="server" ID="ltrSpedNome"></asp:Literal><br />
        <asp:Literal runat="server" ID="ltrSpedIndirizzo"></asp:Literal><br />
        <asp:Literal runat="server" ID="ltrSpedCap"></asp:Literal><br />
        <asp:Literal runat="server" ID="ltrSpedCitta"></asp:Literal><br />
    </div>
    <div class="one-fourth">
        <h6>Indirizzo fatturazione:</h6>
        <fieldset>
            <asp:Literal runat="server" ID="ltrBillNome"></asp:Literal>
        </fieldset>
        <fieldset>
            <asp:Literal runat="server" ID="ltrBillIndirizzo"></asp:Literal>
        </fieldset>
        <fieldset>
            <asp:Literal runat="server" ID="ltrBillCap"></asp:Literal>
        </fieldset>
        <fieldset>
            <asp:Literal runat="server" ID="ltrBillCitta"></asp:Literal>
        </fieldset>

    </div>
    <div class="one-half last">
    </div>

</asp:Content>
