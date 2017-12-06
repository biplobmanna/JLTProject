﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebUI.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mera Job Search - Login</title>
    <link href="CSS/layoutStyle.css" rel="stylesheet" />
    <link href="CSS/RegisterLayout.css" rel="stylesheet" />
</head>
<body>

    <header>
        <h2 class="mainHeader">Mera Job Search</h2>
    </header>
    <nav id="mainNav">
        <ul class="menuList">
            <li><a class="navLink" href="index.aspx">Home</a></li>
            <li><a class="navLink" href="register.aspx">Register</a></li>
            <li><a class="navLink" href="login">Login</a></li>
        </ul>
    </nav>

    <!--Form Creation and working-->
    <section class="register">
        <form id="form1" runat="server">
            <!--Username-->
            <div class="row">
                <div class="lCell">
                    Username:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                </div>
            </div>
            <!--Password-->
            <div class="row">
                <div class="lCell">
                    Password:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="height: 50px;">
                <div class="lCell">&nbsp;
                    </div>
                <div class="rCell">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" />
                </div>
            </div>
        </form>
    </section>
</body>
</html>