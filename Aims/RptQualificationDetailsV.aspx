<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptQualificationDetailsV.aspx.vb"
    Inherits="RptQualificationDetailsV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Qualification Details</title>
</head>
<body>
    <form id="form2" runat="server">
    <div align="center">
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </div>
    </form>
</body>
</html>
