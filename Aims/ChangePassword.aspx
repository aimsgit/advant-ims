<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb"
    Inherits="ChangePassword" Title="Change Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Password</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        CHANGE PASSWORD</h1>
                </center>
            </div>
            <div>
                <center>
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:Label ID="lblpw" runat="server" SkinID="lbl" Text="Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" SkinID="txt" Width="92%" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblnpw" runat="server" SkinID="lbl" Text="New Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" SkinID="txt" Width="92%" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblcpw" runat="server" SkinID="lbl" Text="Confirm New Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfmPassword" runat="server" SkinID="txt" Width="92%" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnChangePassword" runat="server" SkinID="btn" OnClick="btnCreate_Click"
                                    Text="SAVE" CssClass="btnStyle" />
                                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" SkinID="btn" CssClass="btnStyle" />
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <center>
                    <div class="errMgs">
                        <asp:Label ID="lblResults" runat="server" Visible="false">Results:</asp:Label></div>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>

