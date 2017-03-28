<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmResetPwd.aspx.vb" Inherits="frmResetPwd" Title="Reset Password" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reset Password</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src ="js/frmCheck.js" type="text/javascript"></script>
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript">
        function Validate() {
            var msg = passCheck(document.getElementById("<%=txtNewPassword.ClientID %>"), 'New Password')
            var validPass = document.getElementById("<%=validPass.ClientID %>")
            var passInfo = document.getElementById("passInfo")
            if (msg != true) {
                document.getElementById("<%=txtConfmPassword.ClientID %>").focus
                passInfo.innerHTML = msg;
                validPass.value = "false";
                return false;
            }
            else {
                passInfo.innerHTML = "Valid Password";
                passInfo.style.color = "green";
                validPass.value = "true";
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div>
                <%--      <center>
            <h1 class="headingTxt">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RESET PASSWORD</h1>
        </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
            </div>
            <div>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <asp:RadioButtonList ID="RblLoginType" Width="350px" runat="server" AutoPostBack="true"
                                        RepeatDirection="Horizontal" TabIndex="1">
                                        <asp:ListItem Text="Employee" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Parent/Students" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="sPassword" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblusrname" runat="server" Width="150" SkinID="lblRSZ" Text="User Name* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtusername" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblnpw" runat="server" Width="150" SkinID="lblRSZ" Text="New Password* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNewPassword" runat="server" SkinID="txt" Style="margin-left: 0px"
                                     TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblcpw" runat="server" SkinID="lblRSZ" Width="200" Text="Confirm New Password* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtConfmPassword" runat="server" SkinID="txt" TextMode="Password"
                                    TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <label id="passInfo"></label>
                                <asp:HiddenField ID="validPass" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnResetPassword" runat="server" SkinID="btn" Text="SUBMIT" TabIndex="5"
                                    CssClass="ButtonClass " OnClientClick="return Validate()"/>
                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="BACK" SkinID="btn" TabIndex="6"
                                    CssClass="ButtonClass " />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Label ID="lblmsg" runat="server" BackColor="Red" ForeColor="White" Visible="False">Label</asp:Label>
                                <asp:Label ID="lblMsginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </center>
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
