<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_InvoiceStatusV.aspx.vb" Inherits="Rpt_InvoiceStatusV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invoice Status</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <rsweb:ReportViewer ID="RptInvoiceStatus" runat="server" SizeToReportContent="true" AsyncRendering="false">
            </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
