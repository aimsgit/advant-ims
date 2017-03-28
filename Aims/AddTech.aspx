<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddTech.aspx.vb" Inherits="AddTech" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD TECHNICAL SUPPORT</title>
    <style type="text/css">
        .style1
        {
            height: 34px;
        }
        .style2
        {
            width: 318px;
        }
    </style>
</head>
<body>

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <center>
        <form id="form1" runat="server" class="style2" align="left" style="float:left">
        <br />
        <br />
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <center>
                            <h3 style="color: #800000;">
                                ADD TECHNICAL SUPPORT</h3>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblusername" runat="server" Text="USERNAME  : " ForeColor="Maroon"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtuser" runat="server" SkinID="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblpass" runat="server" Text="PASSWORD  : " ForeColor="Maroon"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtpass" runat="server" TextMode="Password" SkinID="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblrepass" runat="server" Text="RE-TYPE PASSWORD  : " ForeColor="Maroon"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtrepass" runat="server" TextMode="Password" SkinID="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp
                    </td>
                    <td align="left">
                        &nbsp
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style1">
                        <asp:Button ID="btnAdd" runat="server" Text="ADD" Width="100px" Height="30px" ForeColor="Maroon"
                            Font-Bold="True" />
                    </td>
                    <td align="left" class="style1">
                        <asp:Button ID="btnCancel" runat="server" Text="CLOSE" Width="100px" Height="30px"
                            ForeColor="Maroon" Font-Bold="True" OnClientClick="javascript:window.close()" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <center>
                            <asp:Label ID="Lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </center>
</body>
</html>
