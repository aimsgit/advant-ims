<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_ProffessionTaxV.aspx.vb" Inherits="Rpt_ProffessionTaxV" title="Profession Tax Report" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Profession Tax Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="true"
            AsyncRendering="false">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </div>
    <center>
        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed" BackColor="Red" ForeColor="White"></asp:Label>
    </center>
    </form>
</body>
</html>
