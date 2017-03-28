<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LogIn.aspx.vb" Inherits="LogIn" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Advant Institute Management System</title>
    <link rel="shortcut icon" href="~/Images/favicon.png" type="image/x-icon" />
    <style type="text/css" media="all">
        .extraGlow
        {
            color: white;
            text-shadow: 0 0 30px yellow , 0 0 70px yellow;
        }
        #news-container
        {
            width: 560px;
            height: 400px;
            margin: 2px;
            margin-top: -5px;
        }
        #news-container ul li div
        {
        }
        .style1
        {
            height: 19px;
        }
        .style2
        {
            position: absolute;
            z-index: 200;
            top: -30px;
            left: 26px;
        }
    </style>
    <style type="text/css">
        .txtLogin
        {
            display: inline-block;
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            padding: 3px 5px;
            border: 1px solid #b7b7b7;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            font: normal 16px/normal "Times New Roman" , Times, serif;
            color: #000000;
           
        }
        .lblRed
        {
            border-radius: 3px;
            font-family: Arial;
            font-size: 14px;
            background-color: #f7e3e3;
            color: #c11d1d;
            text-align: center;
        }
    </style>

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/jquery.vticker-min.js"></script>

    <script type="text/javascript">
        $(function() {
            //$('#news-container').vTicker({
            //    speed: 1500,
            //    pause: 6000,
            //    animation: 'scroll',
            //    mousePause: true,
            //    showItems: 1
            });
        });

        function openwd() {

            window.open('ChatLogin.aspx', '', 'width=565,left=300,top=200,height=440,scrollbars=true').focus


        }
        function openwd1() {

            window.open('ForgotPassword.aspx', '', 'width=565,left=300,top=200,height=300,scrollbars=true').focus


        }
       
    </script>

    <link href="styleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server" autocomplete="false">

    <div>
        <asp:Panel ID="Panel3" runat="server">
            <center>
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <a href="http://www.advant-tech.com" target="_blank">
                                <asp:Image ID="Image1" runat="server" Height="80px" Style="position: absolute; z-index: 200;
                                    top: 2px;" ImageUrl="~/Images/mainlog.png" Width="927px" />
                            </a>
                            <%-- <asp:Label runat="server" ID="lblTest" align="right" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspAdvant Techservices India Private Limited"
                                ForeColor="WhiteSmoke" Font-Names="monotype corsiva" Font-Size="35px" Style="position: absolute;
                                z-index: 200; top: 31px; filter: Glow(Color=#000000, Strength=5);
                                width: 898px; left: 0px;" />--%>
                            <asp:Image ID="Image2" runat="server" Height="80px" ImageUrl="~//img1.jpg" DataSourceID="Objimg"
                                Width="927px" DataValueField="image" />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table style="margin-bottom: 0px" width="900px">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" ForeColor="#33CC33" Font-Names="Comic Sans MS"
                                Font-Size="X-Large" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="border: thin solid #C0C0C0" class="style1">
                            <div id="news-container">
                                <ul>
                                    <li>
                                        <div>
                                            <br />
                                            &nbsp;&nbsp;<asp:Label ID="lblHighlights" runat="server" Text="Highlights" Font-Bold="false"
                                                Font-Size="small" Font-Names="Calibri" ForeColor="#666666" />
                                            <br />
                                            <br />
                                            <asp:BulletedList ID="BulletedList1" DataSourceID="ObjNE" DataTextField="ContentText"
                                                DataValueField="L_ID" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                                ForeColor="#666666">
                                            </asp:BulletedList>
                                            <br />
                                            <br />
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <br />
                                            &nbsp;&nbsp;<asp:Label ID="lblBenefits" runat="server" Text="Benefits" Font-Bold="false"
                                                Font-Size="small" Font-Names="Calibri" ForeColor="#666666" />
                                            <br />
                                            <br />
                                            <asp:BulletedList ID="BulletedList2" DataSourceID="ObjObj" DataTextField="ContentText"
                                                DataValueField="L_ID" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                                ForeColor="#666666">
                                            </asp:BulletedList>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </td>
                        <td class="style1">
                        </td>
                        <td align="center" style="border: thin solid #799BFF" colspan="2" class="style1">
                            <asp:Panel ID="Panel1" runat="server">
                                <table>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="font-family: Calibri;"
                                                Text="User ID :" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserId" runat="server" SkinID="txt" CssClass="txtLogin" Width="138px"
                                                Height="15px" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="font-family: Calibri;"
                                                Text="Password :" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPassword" runat="server" SkinID="txt" CssClass="txtLogin" TextMode="Password"
                                                Width="138px" Height="15px" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="1">Staff</asp:ListItem>
                                                <asp:ListItem Value="2">Parent</asp:ListItem>
                                                <asp:ListItem Value="3">Student</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnLogin" runat="server" BackColor="#CC0000" BorderStyle="Outset"
                                                CssClass="ButtonClass" ForeColor="White" Height="20px" Text="LOGIN" Width="84px"
                                                Font-Names="Calibri" />
                                        </td>
                                        <%--  <td>--%>
                                        <td>
                                            <asp:LinkButton ID="log1" runat="server" Text="Log1" Visible="false" />
                                        </td>
                                        <%--    </td>--%>
                                        <%--<tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text=" I agree to " />
                                        <asp:HyperLink ID="HyperLink1" runat="server">terms & conditions</asp:HyperLink>
                                    </td>
                                </tr>--%>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblNumberOfAttempts" runat="server" Text='<%# "The application locks a user out after <B>" & Membership.Provider.MaxInvalidPasswordAttempts & " </B>failed login attempts." %>'
                                                    Visible="False" Width="290px" ForeColor="Red"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblResults" runat="server" CssClass="lblRed" Visible="False" Width="290px">Result : </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <%--<asp:LinkButton ID="Forgot" runat="server" Text="Forgot Your Password?" />--%>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="openwd1();" Text="Forgot Your Password?"
                                                    Font-Names="Calibri" />
                                            </td>
                                        </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="justify" rowspan="3">
                            <%--<img src="Images/new.gif" /><a href="Result.aspx">Click here for Leadership Program
                                Result from MOHE </a>--%>
                        </td>
                        <td rowspan="3">
                        </td>
                        <td rowspan="3">
                            <img id="image_chat" src="images/chat.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Button ID="Button2" runat="server" Enabled="true" Text="CHAT" Width="102px"
                                BackColor="#70A600" ForeColor="White" Height="33px" OnClientClick="openwd();" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label7" runat="server" ForeColor="#33CC33" Font-Names="Comic Sans MS"
                                Font-Size="X-Large" align="left" />
                        </td>
                        <td>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Label ID="Lable6" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                ForeColor="#666666" Text="For Support Call: IN : +91 80 28605859, +91 80 28604289"
                                Style="font-family: Calibri; text-align: center" Width="350px" />
                            <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                ForeColor="#666666" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspSL : +94 77 7725771, +94 77 8108153"
                                Style="font-family: Calibri; text-align: center" Width="350px" />
                            <asp:Label ID="Lable7" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                ForeColor="#666666" Text="&nbsp&nbsp&nbspSkype Id: IN : advant.support2, advantaims"
                                Style="font-family: Calibri; text-align: center" Width="350px" />
                            <asp:Label ID="Lable8" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                ForeColor="#666666" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspSL : advant.srilanka, cbmis.colombo"
                                Style="font-family: Calibri; text-align: center" Width="350px" />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <%--<a name="bottom">--%>
                    <table>
                        <tr>
                            <td style="border: thin solid #C0C0C0" align="left">
                                <asp:BulletedList ID="BulletedList3" DataSourceID="ObjN0" DataTextField="ContentText"
                                    DataValueField="L_ID" runat="server" Font-Bold="false" Font-Size="small" Font-Names="Calibri"
                                    ForeColor="#666666" Width="885px" Style="margin-left: 0px; margin-bottom: 0px" Height="16px">
                                </asp:BulletedList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#6A8FFF">
                                <asp:Label ID="Label5" runat="server" Text="Copyright Advant Techservices India Private Limited"
                                    ForeColor="White"></asp:Label>
                                <a href="http://www.advant-tech.com" target="_blank" style="color: #FFFFFF">www.advant-tech.com</a>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ObjectDataSource ID="ObjNE" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetLogInNewsEvents" TypeName="UserDetailsDB"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjN0" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetLogInNotice" TypeName="UserDetailsDB"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjObj" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetLogInObj" TypeName="UserDetailsDB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                <%--</a>--%>
            </center>
        
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false" DefaultButton="btnok">
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <a href="http://www.advant-tech.com" target="_blank">
                                <asp:Image ID="Image3" runat="server" Height="80px" Style="position: absolute; z-index: 200;
                                    top: 2px;" ImageUrl="~/Images/mainlog.png" Width="900px" />
                            </a>
                            <%-- <asp:Label runat="server" ID="lblTest" align="right" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspAdvant Techservices India Private Limited"
                                ForeColor="WhiteSmoke" Font-Names="monotype corsiva" Font-Size="35px" Style="position: absolute;
                                z-index: 200; top: 31px; filter: Glow(Color=#000000, Strength=5);
                                width: 898px; left: 0px;" />--%>
                            <asp:Image ID="Image4" runat="server" Height="80px" ImageUrl="~//img1.jpg" DataSourceID="Objimg"
                                Width="936px" DataValueField="image" />
                        </td>
                    </tr>
                </table>
                <%-- <table>
                    <tr>
                        <td align="left">&nbsp&nbsp&nbsp&nbsp
                            <a href="http://www.advant-tech.com" target="_blank">
                                <asp:Image ID="Image3" runat="server" Height="50px" Style="position: absolute; z-index: 200;
                                    top: 20px;" ImageUrl="~/Images/log.gif" Width="50px" />
                            </a>
                           <asp:Label runat="server" ID="Label1" align="right" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspAdvant Techservices India Private Limited"
                                ForeColor="WhiteSmoke" Font-Names="monotype corsiva" Font-Size="35px" Style="position: absolute;
                                z-index: 200; top: 31px; filter: Glow(Color=#000000, Strength=5);
                                width: 898px; left: 153px;" />
                            <asp:Image ID="Image4" runat="server" Height="80px" ImageUrl="~//img1.jpg" DataSourceID="Objimg"
                                Width="900px" DataValueField="image" />
                        </td>
                    </tr>
                </table>--%>
                <h1 class="headingTxt">
                    <asp:Label ID="lblBranch" Text="" runat="server"></asp:Label>
                </h1>
            </center>
            <%-- </div>--%>
            <h1 class="headingTxt">
                <asp:Label ID="Label6" Text="" runat="server"></asp:Label>
            </h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="BtnBack" />
                </Triggers>
                <ContentTemplate>
                    <center>
                        <div style="width: 50%">
                            <table align="center">
                                <tr>
                                    <td align="left">
                                        <h3 class="headingTxt">
                                            <asp:Label ID="Lblheading" Text=" Please Enter Security Password" runat="server"></asp:Label>
                                        </h3>
                                    </td>
                                </tr>
                                <%--<tr>
                        <td colspan="2" align="center">
                            <h3 class="headingTxt">
                                <asp:Label ID="lblEnter" Text="Enter your Branch security password" runat="server"></asp:Label>
                            </h3>
                        </td>
                    </tr>--%>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table align="center">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSPassword" runat="server" Font-Bold="True" Style="font-family: Calibri;"
                                            Text="Secure Password :" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtSPassword" runat="server" SkinID="txt" CssClass="txtLogin" TextMode="Password"
                                            Width="138px" Height="14px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnok" runat="server" CssClass="ButtonClass" Text="OK" SkinID="btn" />
                                        <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" Text="BACK" SkinID="btn" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblSResult" runat="server" ForeColor="Red" Visible="False" Width="290px">Result : </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
