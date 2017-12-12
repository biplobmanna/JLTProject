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
            <li><a class="navLink" href="index.aspx">Logout</a></li>
        </ul>
    </nav>
    <form id="form1" runat="server">
        <label id="LabelHidden" runat="server" hidden="hidden"></label>
        <!--Div Home-->
        <div id="divHome">
            <div class="row">
                <h2 style="margin-left: 80px;">Profile Details:</h2>
            </div>
            <br />
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
        <!--View Jobs Section-->
        <div id="divViewJobs">
            <div class="row">
                <h2 style="margin-left: 80px;">Jobs Details:</h2>
            </div>
            <div class="row">
                <asp:GridView ID="GridViewDisplayJobDetails" runat="server" Width="663px" OnSelectedIndexChanged="GridViewDisplayJobDetails_SelectedIndexChanged" AutoGenerateSelectButton="True">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <HeaderStyle BackColor="#009999" Font-Bold="True" ForeColor="White" Font-Size="20px" />
                </asp:GridView>
            </div>
        </div>
        <!--Add Jobs-->
        <div id="divAddJobs">
            <div class="row">
                <h2 style="margin-left: 80px;">Add Jobs:</h2>
            </div>
            <br />
            <!--Job Name-->
            <div class="row">
                <div class="lCell">
                    Job Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxJobName" runat="server"></asp:TextBox>
                </div>
            </div>
            <!--Job Category-->
            <div class="row">
                <div class="lCell">
                    Job Category:
                </div>
                <div class="rCell">
                    &nbsp;<asp:DropDownList ID="DropDownListJobCategory" runat="server"></asp:DropDownList>
                </div>
            </div>
            <!--Submit Button-->
            <div class="row" style="height: 50px;">
                <div class="lCell">
                    &nbsp;
                </div>
                <div class="rCell">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
                </div>
            </div>
        </div>

        <!--Show People who applied for Jobs-->
        <div id="divJobApplicants">
            <div class="row">
                <h2 style="margin-left: 80px;">
                    <label id="LabelJobApplicantsHeader" runat="server"></label>
                </h2>
            </div>
            <div class="row">
                <asp:GridView ID="GridViewJobApplicants" runat="server" Width="666px">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <HeaderStyle BackColor="#009999" Font-Size="20px" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="JS/jquery-3.2.1.min.js"></script>
    <script src="JS/CompanyProfileActions.js"></script>
</body>
</html>
