
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAnnualSalaryStatementVNew.aspx.vb"
    Inherits="RptAnnualSalaryStatementVNew" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Annual Salary Statment</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </div>
    <center>
        <asp:Label ID="lblerr" runat="server" SkinID="lblRed"></asp:Label>
    </center>
    </form>
</body>
</html>
