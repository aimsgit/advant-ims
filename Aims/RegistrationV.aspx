<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistrationV.aspx.vb" Inherits="RegistrationV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admission Report</title>
    <link href="StyleCR.css" rel="stylesheet" type="text/css" />
 <script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script src="JScript.js" type="text/javascript" language="javascript">
        window.history.forward(1);
        //history.go(1);
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td>
                    <asp:Label ID="LblError" runat="server" SkinID="lblRed"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" SizeToReportContent="true">
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
