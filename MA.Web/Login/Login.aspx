<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    Title="materarredamenti.it Admin Panel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HeadLogin" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="robots" content="index,follow" />
    <meta name="Author" content="matera arredamenti" />
    <meta http-equiv="imagetoolbar" content="no" />
    <title>materarredamenti.it Admin Panel</title>
    <!-- **********   CSS   ********** -->
    <link rel="stylesheet" href="css/reset.css" type="text/css" />
    <link rel="stylesheet" href="css/screen.css" type="text/css" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/ico" />
    <!-- **********   JAVASCRIPTS   ********** -->

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/jquery.visualize.js"></script>

    <script type="text/javascript" src="js/jquery.wysiwyg.js"></script>

    <script type="text/javascript" src="js/tiny_mce/jquery.tinymce.js"></script>

    <script type="text/javascript" src="js/jquery.fancybox.js"></script>

    <script type="text/javascript" src="js/jquery.idtabs.js"></script>

    <script type="text/javascript" src="js/jquery.datatables.js"></script>

    <script type="text/javascript" src="js/jquery.jeditable.js"></script>

    <script type="text/javascript" src="js/jquery.ui.js"></script>

    <script type="text/javascript" src="js/jquery.jcarousel.js"></script>

    <script type="text/javascript" src="js/jquery.validate.js"></script>

    <script type="text/javascript" src="js/cufon.js"></script>

    <script type="text/javascript" src="js/Zurich_Condensed_Lt_Bd.js"></script>

    <script type="text/javascript" src="js/script.js"></script>

    <!--   ********** BROWSER FIXSES Stylesheet   ********** -->
    <!--[if IE 7]>
	<link rel="stylesheet" type="text/css" href="css/ie7.css" />
<![endif]-->
</head>
<body class="login">
    <form id="LoginPage" runat="server">
    <div class="login-box">
        <div class="login-border">
            <div class="login-style">
                <div class="login-header">
                    <div class="logo clear">
                        <img src="images/ico_administration_48.png" alt="" class="picture" />
                        <span class="textlogo"><span class="title">materarredamenti.it</span> <span class="text">Admin Panel</span> </span>
                    </div>
                </div>
                <div class="login-inside">
                    <div class="login-data">
                        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Admin/Default.aspx" OnLoginError="LoginError" OnLoggedIn="btnLogin_Click">
                            <LayoutTemplate>
                                <div class="row clear">
                                    <label for="user">
                                        Username:</label>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="row clear">
                                    <label for="password">
                                        Password:</label>
                                    <asp:TextBox ID="Password" CssClass="text" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </div>
                                <asp:Button CssClass="button" ID="LoginButton" runat="server" CommandName="Login"
                                    Text="Login" ValidationGroup="Login1" />
                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                </div>
                <div class="login-footer clear">
                    <div id="DivInfo" runat="server" visible="true" class="notification attention" style="border-width: 0px;">
                        <div>
                            <asp:Label runat="server" ID="ContattiNotificationInfo" Visible="true" Text="All fields are required."></asp:Label>
                        </div>
                    </div>
                    <div id="DivError" runat="server" visible="false" class="notification error" style="border-width: 0px;">
                        <div>
                            <asp:Label runat="server" ID="ContattilblNotificationErr" Visible="false" Text="Error: Check Username / Password"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="login-links">
        <p>
            <strong>&copy; 2012 Copyright materarredamenti.it </strong>- All rights
            reserved.</p>
    </div>
    </form>
</body>
</html>
