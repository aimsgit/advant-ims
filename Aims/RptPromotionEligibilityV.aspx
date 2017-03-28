<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptPromotionEligibilityV.aspx.vb"
    Inherits="RptPromotionEligibilityV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Promotion Eligibilty</title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div>
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="506px" AsyncRendering="false"
            SizeToReportContent="true" Width="756px">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="lblErrorMsg" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
    </center>
    </form>
</body>
</html>
