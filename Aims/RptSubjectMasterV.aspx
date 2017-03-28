<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSubjectMasterV.aspx.vb" Inherits="RptSubjectMasterV" Title="Subject Details" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Subject Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center >
       <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <center>
            <asp:Label ID="lblmsg" runat="server" skinid="lblRed"></asp:Label>
        </center>
        </center>
    </div>
    </form>
</body>
</html>
