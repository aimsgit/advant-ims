﻿<%@ Page Language="VB" AutoEventWireup="false" 
CodeFile="RptCalOfEventsV.aspx.vb" Inherits="RptCalOfEventsV" title="CALENDAR OF EVENTS" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CALENDAR OF EVENTS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
            </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Label ID="lblMsg" runat="Server" SkinID="lbl" BackColor="Red" ForeColor="White"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>

