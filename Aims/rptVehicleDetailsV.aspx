<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptVehicleDetailsV.aspx.vb"
    Inherits="rptVehicleDetailsV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vehicle details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" BackColor="Red" ForeColor="White" Visible="False"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
