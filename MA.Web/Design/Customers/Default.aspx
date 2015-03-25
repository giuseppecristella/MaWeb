<%@ Page Title="" Language="C#" MasterPageFile="~/Design/Customers/Default.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="shop_Customers_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWrapper" runat="Server">
    <div style="padding: 20px 0 20px 0; min-height: 580px;" class="one">
        <div style="margin-left: 30px; width: 305px;" class="one-third">
            <h4>Dati Utente</h4>
            <fieldset>
                <label>Nome:</label>
                <asp:Label runat="server" ID="lblNome"></asp:Label>
            </fieldset>
            <fieldset>
                <label>Cognome:</label>
                <asp:Label runat="server" ID="lblCognome"></asp:Label>
            </fieldset>
            <fieldset>
                <label>E-mail:</label>
                <asp:Label runat="server" ID="lblEmail"></asp:Label>
            </fieldset>
        </div>
        <div style="width: 305px;" class="one-third">
            <h4>Indirizzo Fatturazione</h4>
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
            <label>
                Tel</label>
            <asp:TextBox runat="server" class="text" ID="txtbphone" />
        </div>
        <div style="width: 305px;" class="one-third last">
            <h4>Indirizzo Spedizione</h4>
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

            <fieldset>
                <asp:Button runat="server" ID="btnUpdateBilling" CssClass="fancy-button red small"
                    Text="Modifica indirizzi" OnClick="btnUpdateCustomerAddresses_Click" />
            </fieldset>
        </div>
    </div>
</asp:Content>
