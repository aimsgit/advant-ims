<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PopFileSelection.aspx.vb"
    Inherits="PopFileSelection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Selection</title>
    <base target="_self" />
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="javascript">
        function changeparent() {
            var selects = document.getElementById('Listfile');
            if (document.getElementById('Listfile').value == "")
                window.returnValue = '';
            else
                window.returnValue = selects.options[selects.selectedIndex].value;
            window.close()
        } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="480px" Height="300px">
                        <asp:ListBox ID="Listfile" runat="server" Width="445px" Height="295px"></asp:ListBox>
                    </asp:Panel>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnok" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                        OnClientClick="javascript:changeparent();" TabIndex="7" />
                    &nbsp;
                    <asp:Button ID="btnclose" runat="server" CssClass="ButtonClass" SkinID="btn" Text="CLOSE"
                        TabIndex="8" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
