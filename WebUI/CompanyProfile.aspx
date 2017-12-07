<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs" Inherits="WebUI.CompanyProfile" %>

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
            <li id="ListItemHome"><a class="navLink">Home</a></li>
            <li id="ListItemViewJobs"><a class="navLink">View Jobs</a></li>
            <li id="ListItemAddJobs"><a class="navLink">Add Jobs</a></li>
        </ul>
    </nav>
    <form id="form1" runat="server">
        <div id="divHome">
            <div class="row">
                <h2 style="margin-left: 80px;">Profile Details:</h2>
            </div>
            <br/><br/>
           <!--Company Id-->
            <div class="row">
                <div class="lCell">
                    CompanyId:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelCompanyId" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--Company Name-->
            <div class="row">
                <div class="lCell">
                    Company Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelCompanyName" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--Company Address-->
            <div class="row">
                <div class="lCell">
                    Address:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelAddress" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--City-->
            <div class="row">
                <div class="lCell">
                    City:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelCity" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--ContactPersonName-->
            <div class="row">
                <div class="lCell">
                    Contact Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelContactPersonName" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--ContactPersonEmail-->
            <div class="row">
                <div class="lCell">
                    Contact Email:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelContactPersonEmail" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--ContactPersonPhone-->
            <div class="row">
                <div class="lCell">
                    Contact Phone:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelContactPersonPhone" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
    <script src="JS/jquery-3.2.1.min.js"></script>
    <script src="JS/CompanyProfileActions.js"></script>
</body>
</html>
