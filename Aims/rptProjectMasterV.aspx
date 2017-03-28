<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptProjectMasterV.aspx.vb" Inherits="rptProjectMasterV" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project Master</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <rsweb:ReportViewer ID="ReportViewer2" runat="server" height="514px" AsyncRendering ="false" SizeToReportContent ="true" >
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    </form>
</body>
</html>
