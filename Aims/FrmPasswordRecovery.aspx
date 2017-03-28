<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmPasswordRecovery.aspx.vb" Inherits="FrmPasswordRecovery" title="Password Recovery" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Password Recovery</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        PASSWORD RECOVERY
                                    </h1>
                                </center>
                                <br />
                                <br />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblbuyer" runat="server" SkinID="lblRsz" Text="Password*^&nbsp;:&nbsp;&nbsp;"
                                                Width="200"></asp:Label>
                                        </td>
                                        <td align="left">
                                             <td>
                                                <asp:TextBox ID="txtpassword" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td class="btnTd">
                                                <asp:Button ID="btnRecovery" runat="server" Text="SHOW" CssClass="ButtonClass "
                                                    SkinID="btn" />
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                </ContentTemplate>
                                </asp:UpdatePanel>


</form>
</body>
</html>


