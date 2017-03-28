<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmAcknowledgement.aspx.vb"
    Inherits="FrmAcknowledgement" Title="ACKNOWLEDGEMENT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ACKNOWLEDGEMENT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    ACKNOWLEDGMENT</h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LKReport" runat="server" Text="<u>Print Acknowledgement</u>"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LKMail" runat="server" Text="<u>Send Acknowledgement by E-Mail</u>"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LKSMS" runat="server" Text="<u>Send Acknowledgement by SMS</u>"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblred"></asp:Label>
                            <asp:Label ID="lblmsgg" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnClose" CssClass="ButtonClass" SkinID="btn" runat="server" Text="CLOSE">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right" style="width: 413px">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
