<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_Rpt_SaleInvoice.aspx.vb" Inherits="Mfg_Rpt_SaleInvoice" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Sale Invoice Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </div>
    <center>
       <asp:Label ID="lblmsg" runat="server" SkinID="lblRed" BackColor="Red"></asp:Label>
    </center>   
    </form>
</body>
</html>
