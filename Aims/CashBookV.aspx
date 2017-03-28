<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CashBookV.aspx.vb" Inherits="CashBookV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CashBook</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <rsweb:ReportViewer ID="RptCashBook" runat="server" SizeToReportContent="true" AsyncRendering="false">
            </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
