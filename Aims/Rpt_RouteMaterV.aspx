﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_RouteMaterV.aspx.vb"
    Inherits="Rpt_RouteMaterV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Route Master</title>
</head>
<body>
    <div>
        <form id="form1" runat="server">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </form>
    </div>
    <center>
        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
    </center>
</body>
</html>
