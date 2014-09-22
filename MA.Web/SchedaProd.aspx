<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchedaProd.aspx.cs" Inherits="SchedaProd"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link rel="stylesheet" href="App_Themes/standard/Newstyle.css" type="text/css" media="screen, projection" />
<link rel="stylesheet" href="css/mainstyles.css" type="text/css" media="screen, projection" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- contact form block -->
                <div style="padding-top: 30px; padding-left: 17px; padding-bottom: 10px;">
                    <div id="contact" style="width: 700px;" class="panel">
                        <div style="margin: auto;" class="panel-content">
                            <asp:Image Style="width: 350px; border: solid 5px #d3d3d3; float: right; margin-top: 15px;"
                                ID="fotoProdotto" runat="server" />
                            <h1>
                                Scheda Prodotto</h1>
                            <p>
                                <b style="color: #bf0000;">Modello: </b>
                                <asp:Label runat="server" ID="lblModello" Text=""></asp:Label>
                            </p>
                            <p style="width: 200px;">
                                <b style="color: #bf0000;">Descrizione: </b>
                                <asp:Label runat="server" ID="lblDesc" Text=""></asp:Label>
                            </p>
                            <p>
                                <b style="color: #bf0000;">Prezzo listino: </b>€.<asp:Label runat="server" ID="lblListino"
                                    Text=""></asp:Label>
                            </p>
                            <p>
                                <b style="color: #bf0000;">Prezzo Scontato: </b>€. <b>
                                    <asp:Label runat="server" ID="lblSconto" Font-Bold="true" Text=""></asp:Label></b>
                            </p>
                            <br />
                            <br />
                            <p style="z-index: 2">
                                Se sei interessato al prodotto compila i seguenti campi,&nbsp; invia i tuoi dati
                                e sarai contattato.</p>
                            <p>
                                <asp:Label Style="text-align: right;" Width="50px" ID="nome" runat="server" Text="Nome: "></asp:Label>
                                &nbsp;
                                <asp:TextBox AutoPostBack="false" Style="z-index: 3; width: 150px;" CssClass="input"
                                    ID="txtNome" runat="server"></asp:TextBox>
                                <asp:Label Style="text-align: right;" Width="70px" ID="Label1" runat="server" Text="Cognome: "></asp:Label>
                                &nbsp;
                                <asp:TextBox AutoPostBack="false" Style="z-index: 3; width: 150px;" CssClass="input"
                                    ID="txtCognoome" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label Style="text-align: right;" Width="50px" ID="Label2" runat="server" Text="Tel: "></asp:Label>
                                &nbsp;
                                <asp:TextBox AutoPostBack="false" Style="z-index: 3; width: 150px;" CssClass="input"
                                    ID="txtTel" runat="server"></asp:TextBox>
                                <asp:Label Style="text-align: right;" Width="70px" ID="Label3" runat="server" Text=" Email: "></asp:Label>
                                &nbsp;
                                <asp:TextBox AutoPostBack="false" Style="z-index: 3; width: 150px;" CssClass="input"
                                    ID="txtMail" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <asp:CheckBox ID="chkPrivacy" runat="server" />
                                Si presto il consenso al trattamento dei dati personali D.Lgs. 196/03
                                <asp:Button ID="btnInvio" runat="server" OnClick="inviaMailInfo" CssClass="searchsubmit"
                                    Text="INVIA" />
                            </p>
                            <p>
                                <asp:Label CssClass="notification success" ID="lblSuccess" Visible="false" runat="server"
                                    Text=""></asp:Label>
                                <asp:Label CssClass="notification error" ID="lblErrore" Visible="false" runat="server"
                                    Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
