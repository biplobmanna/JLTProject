<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebUI.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mera Job Search - Register</title>
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
            <li><a class="navLink" href="login.aspx">Login</a></li>
        </ul>
    </nav>

    <!--Form Creation and working-->
    <form id="Form1" runat="server">
        <!--Choosing Category-->
        <div class="row">
            <div class="lCell">
                Choose Category:
            </div>
            <div class="rCell">
                &nbsp;<asp:DropDownList ID="DropDownListCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCategory_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Job Seeker</asp:ListItem>
                    <asp:ListItem>Company</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <!--Job Seeker Section-->
        <div id="DivJobSeekerRegister" runat="server">
            <!--Name-->
            <div class="row">
                <div class="lCell">
                    Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Name Required!" ForeColor="Red" ControlToValidate="TextBoxName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Username-->
            <div class="row">
                <div class="lCell">
                    Username:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ErrorMessage="Username Required!" ForeColor="Red" ControlToValidate="TextBoxUsername"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Details-->
            <div class="row">
                <div class="lCell">
                    Details:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <!--City-->
            <div class="row">
                <div class="lCell">
                    City:
                </div>
                <div class="rCell">
                    &nbsp;<asp:DropDownList ID="DropDownListCity" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <!--Category-->
            <div class="row">
                <div class="lCell">
                    Job Category:
                </div>
                <div class="rCell">
                    &nbsp;<asp:DropDownList ID="DropDownJobCategory" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <!--Password-->
            <div class="row">
                <div class="lCell">
                    Password:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password Required!" ForeColor="Red" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Confirm Password-->
            <div class="row">
                <div class="lCell">
                    Re-enter Password:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxRePassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRePassword" runat="server" ErrorMessage="Enter Password!S" ControlToValidate="TextBoxRePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Passwords dont Match!" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxRePassword" ForeColor="Red"></asp:CompareValidator>
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

        <div id="DivCompanyRegister" runat="server" visible="False">
            <!--Register for Company-->
            <!--Company Name-->
            <div class="row">
                <div class="lCell">
                    Company Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxCompanyName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompanyName" runat="server" ErrorMessage="Name Required!" ForeColor="Red" ControlToValidate="TextBoxCompanyName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Username-->
            <div class="row">
                <div class="lCell">
                    Username:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxUsernameCompany" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompanyUsername" runat="server" ErrorMessage="Username Required!" ForeColor="Red" ControlToValidate="TextBoxUsernameCompany"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Company Address-->
            <div class="row">
                <div class="lCell">
                    Address:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxAddressCompany" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompanyAddress" runat="server" ErrorMessage="Address Required!" ForeColor="Red" ControlToValidate="TextBoxAddressCompany"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--City-->
            <div class="row">
                <div class="lCell">
                    City:
                </div>
                <div class="rCell">
                    &nbsp;<asp:DropDownList ID="DropDownListCompanyCity" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <!--Contact Person Name-->
            <div class="row">
                <div class="lCell">
                    Contact Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxCompanyContactPersonName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContactPersonName" runat="server" ErrorMessage="Name Required!" ForeColor="Red" ControlToValidate="TextBoxCompanyContactPersonName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Contact Person Email-->
            <div class="row">
                <div class="lCell">
                    Contact Email:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxCompanyContactPersonEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Invalid Email!" ControlToValidate="TextBoxCompanyContactPersonEmail" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContactPersonEmail" runat="server" ErrorMessage="Email Required!" ForeColor="Red" ControlToValidate="TextBoxCompanyContactPersonEmail"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Contact Person Phone-->
            <div class="row">
                <div class="lCell">
                    Contact Phone:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxCompanyContactPersonPhone" runat="server" Width="110px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ErrorMessage="Invalid Phone Number!" ForeColor="Red" ValidationExpression="\d{10}" ControlToValidate="TextBoxCompanyContactPersonPhone"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContactPersonPhone" runat="server" ErrorMessage="Phone Number Required!" ForeColor="Red" ControlToValidate="TextBoxCompanyContactPersonPhone"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Password-->
            <div class="row">
                <div class="lCell">
                    Password:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxCompanyPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompanyPassword" runat="server" ErrorMessage="Password Required!" ForeColor="Red" ControlToValidate="TextBoxCompanyPassword"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--Confirm Password-->
            <div class="row">
                <div class="lCell">
                    Re-enter Password:
                </div>
                <div class="rCell">
                    &nbsp;<asp:TextBox ID="TextBoxCompanyRePassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompanyRePassword" runat="server" ErrorMessage="Enter Password!" ControlToValidate="TextBoxCompanyRePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorCompanyPassword" runat="server" ErrorMessage="Passwords dont match!" ControlToCompare="TextBoxCompanyPassword" ControlToValidate="TextBoxCompanyRePassword" ForeColor="Red"></asp:CompareValidator>
                </div>
            </div>
            <!--Submit Company-->
            <div class="row" style="height: 50px;">
                <div class="lCell">
                    &nbsp;
                </div>
                <div class="rCell">
                    <asp:Button ID="ButtonSubmitCompany" runat="server" Text="Submit" OnClick="ButtonSubmitCompany_Click" />
                </div>
            </div>
        </div>
    </form>
</body>

</html>
