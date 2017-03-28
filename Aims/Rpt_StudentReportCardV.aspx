<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_StudentReportCardV.aspx.vb" Inherits="Rpt_StudentReportCardV" Title="Student Report Card" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Result Sheet Report</title>
    <link href="StyleCR.css" rel="stylesheet" type="text/css" />
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script src="JScript.js" type="text/javascript" language="javascript">
        window.history.forward(1);</script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="lblmsg" runat="server" ForeColor="White" BackColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
