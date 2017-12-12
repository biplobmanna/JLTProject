<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobSeekerProfile.aspx.cs" Inherits="WebUI.JobSeekerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mera Job Search - Login</title>
    <link href="CSS/layoutStyle.css" rel="stylesheet" />
    <link href="CSS/RegisterLayout.css" rel="stylesheet" />
    <script src="JS/jquery-3.2.1.min.js"></script>

</head>
<body>
    <header>
        <h2 class="mainHeader">Mera Job Search</h2>
    </header>
    <nav id="mainNav">
        <ul class="menuList">
            <li id="ListItemHome"><a class="navLink">Home</a></li>
            <li id="ListItemViewJobs"><a class="navLink">View Jobs</a></li>
            <li id="ListItemAppliedJobs"><a class="navLink">Applied Jobs</a></li>
            <li><a class="navLink" href="index.aspx">Logout</a></li>
        </ul>
    </nav>
    <form id="form1" runat="server">
        <!--Home Div-->
        <div id="divHome">
            <div class="row">
                <h2 style="margin-left: 80px;">Profile Details:</h2>
            </div>
            <br />

            <label id="LabelHidden" runat="server" hidden="hidden"></label>

            <!--JobSeeker Id-->
            <div class="row">
                <div class="lCell">
                    JobSeekerId:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelJobSeekerId" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--JobSeekerName Name-->
            <div class="row">
                <div class="lCell">
                    Name:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelJobSeekerName" runat="server" Text=""></asp:Label>
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
            <!--Details-->
            <div class="row">
                <div class="lCell">
                    Details:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelDetails" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <!--JobCategory-->
            <div class="row">
                <div class="lCell">
                    Job Category:
                </div>
                <div class="rCell">
                    &nbsp;<asp:Label ID="LabelJobCategory" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <!--View Jobs Div-->
        <div id="divViewJobs">
            <div class="row">
                <h2 style="margin-left: 80px;">Jobs:</h2>
            </div>
            <br />
            <div class="row">
                <div class="lCell">
                    Select City:
                </div>
                <div class="rCell">
                    &nbsp;<asp:DropDownList ID="DropDownListCity" runat="server"></asp:DropDownList>
                    &nbsp;<asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                    &nbsp;<asp:Button ID="ButtonApplyJob" runat="server" Text="Apply" OnClick="ButtonApplyJob_Click" />
                </div>
            </div>
            <div class="row" style="margin-left: 80px;">
                <asp:GridView ID="GridViewJobs" runat="server" Width="423px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxJobSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="20px" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
        <!--Applied Jobs View-->
        <div id="divAppliedJobsView">
            <div class="row">
                <h2 style="margin-left: 80px;">Applied Jobs:</h2>
            </div>
            <br />
            <div class="row" style="margin-left: 80px;">
                <asp:GridView ID="GridViewAppliedJobs" runat="server" Width="419px">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="20px" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </form>

    <script src="JS/JobSeekerProfileActions.js"></script>

</body>
</html>
