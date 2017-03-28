<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBookIssuedV.aspx.vb" Inherits="frmBookIssuedV" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Issue Details Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="606px"  AsyncRendering="false" SizeToReportContent="true"
        Width="932px">
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                
    </form>
</body>
</html>
