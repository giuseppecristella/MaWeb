<%@ Page Title="" Language="C#" MasterPageFile="Default_r.master" AutoEventWireup="true"
    CodeFile="Indirizzi.aspx.cs" Inherits="Indirizzi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div style="margin-top: 20px;" class="one">
        <div style="width: 305px;" class="one-third">
            <h4>
                Metodo di Pagamento</h4>
            <br />
            <p>
                <img width="217" src="images/gestpay.gif" alt=""/>
            </p>
            <br />
            <fieldset>
                <asp:RadioButtonList Style="width: 270px" ID="rdbtnListPayMethods" runat="server">
                </asp:RadioButtonList>
            </fieldset>
        </div>
        <div style="width: 305px;" class="one-third">
            <h4>
                Indirizzo Fatturazione</h4>
            <label>
                Nome</label>
            <asp:TextBox runat="server" class="text" ID="txtbname" />
            <label>
                Cognome</label>
            <asp:TextBox runat="server" class="text" ID="txtblastname" />
            <label>
                Indirizzo</label>
            <asp:TextBox runat="server" class="text" ID="txtbaddress" />
            <label>
                CAP</label>
            <asp:TextBox runat="server" class="text" ID="txtbzip" />
            <label>
                Citta</label>
            <asp:TextBox runat="server" class="text" ID="txtbcity" />
            <label>
                Provincia</label>
            <asp:TextBox runat="server" class="text" ID="txtbstate" />
            <fieldset>
                <label>
                    Tel</label>
                <asp:TextBox runat="server" class="text" ID="txtbphone" />
            </fieldset>
            <br />
            <fieldset>
                <asp:LinkButton runat="server" ID="btnUpdateBilling" CssClass="fancy-button" Text="Modifica indirizzi" OnClick="btnUpdateBilling_Click" />
            </fieldset>
        </div>
        <div style="width: 305px;" class="one-third last">
            <h4>
                Indirizzo Spedizione</h4>
            <label>
                Nome</label>
            <asp:TextBox runat="server" class="text" value="name" ID="txtsname" />
            <label>
                Cognome</label>
            <asp:TextBox runat="server" class="text" ID="txtslastname" />
            <label>
                Indirizzo</label>
            <asp:TextBox runat="server" class="text" ID="txtsaddress" />
            <label>
                CAP</label>
            <asp:TextBox runat="server" class="text" ID="txtszip" />
            <label>
                Città</label>
            <asp:TextBox runat="server" class="text" ID="txtscity" />
            <label>
                Provincia</label>
            <asp:TextBox runat="server" class="text" ID="txtsstate" />
            <fieldset>
                <label>
                    Telefono</label>
                <asp:TextBox runat="server" class="text" ID="txtsphone" />
            </fieldset>
            <br />
        </div>
        <asp:LinkButton runat="server" ID="lnkbtnOrder" CssClass="fancy-button"
            OnClick="lnkbtnOrder_Click">Riepilogo Ordine</asp:LinkButton>
    </div>
</asp:Content>
