<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptSummary.aspx.vb" Inherits="rptSummary" Title="Summary Report" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT REGISTER REPORT</title>
    <link href="StyleCR.css" rel="stylesheet" type="text/css" />
    <script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script src="JScript.js" type="text/javascript" language="javascript">
        window.history.forward(1);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <rsweb:ReportViewer ID="RptViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <div align="center">
            <asp:Label ID="lblErrorMsg" runat="server" BackColor="Red" ForeColor="White" />
        </div>
    </form>
</body>
</html>
