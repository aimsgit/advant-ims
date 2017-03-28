<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmchangepassword.aspx.vb"
    Inherits="frmchangepassword" Title="Change Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Password</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = validateStr(document.getElementById("<%=txtNewPassword.ClientID %>"), 6, 'New Password')
            if (msg != "") {
                document.getElementById("<%=txtNewPassword.ClientID %>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtNewPassword.ClientID %>"), 6, 'New Password')
            if (msg != "") {
                document.getElementById("<%=txtNewPassword.ClientID %>").focus();
                return msg;
            }
            msg = maxlength(document.getElementById("<%=txtNewPassword.ClientID %>"), 15, 'New Password')
            if (msg != "") {
                document.getElementById("<%=txtNewPassword.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <div>
                <%-- <center>
            <h1 class="headingTxt">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CHANGE PASSWORD</h1>
        </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
            </div>
            <div>
                <center>
                    <table class="custTable">
                        <tr>
                            <td colspan="2" style="height: 4px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblpw" runat="server" Width="200" SkinID="lblRSZ" Text="Current Password* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" SkinID="txt" TextMode="Password"
                                    TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblnpw" runat="server" Width="150" SkinID="lblRSZ" Text="New Password* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" SkinID="txt" Style="margin-left: 0px"
                                    TabIndex="2" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblcpw" runat="server" Width="190" SkinID="lblRSZ" Text="Confirm New Password* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfmPassword" runat="server" SkinID="txt" TextMode="Password"
                                    TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" style="height: 17px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" style="height: 17px">
                                <asp:Button ID="btnChangePassword" TabIndex="4" runat="server" SkinID="btn" Text="SUBMIT"
                                    CssClass="ButtonClass " />
                                &nbsp;<asp:Button ID="btnCancel" TabIndex="5" runat="server" Text="BACK" SkinID="btn"
                                    CssClass="ButtonClass " />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" style="height: 17px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
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
