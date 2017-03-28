<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptPrincipalDashforMarksSummaryV.aspx.vb" Inherits="RptPrincipalDashforMarksSummaryV" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Marks Summary Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="429px" Width="848px" AsyncRendering="false" SizeToReportContent="true" >
                </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <center>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                </center>
            </center>
        </div>
    </form>
</body>
</html>
