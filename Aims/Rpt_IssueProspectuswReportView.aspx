﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_IssueProspectuswReportView.aspx.vb"
    Inherits="Rpt_IssueProspectuswReportView" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISSUE PROSPECTUS REPORT</title>
</head>
<body>
    <form id="form1" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true"
        Height="28px" Width="654px">
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <center>
        <asp:Label ID="lblerror" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
    </center>
    </form>
</body>
</html>
