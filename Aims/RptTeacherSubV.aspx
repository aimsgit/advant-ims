﻿<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptTeacherSubV.aspx.vb"
    Inherits="RptTeacherSubV" Title="TEACHER SUBJECT MAP" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TEACHER SUBJECT MAP</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="true"
            AsyncRendering="false">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <center>
            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>