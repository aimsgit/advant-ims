﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_RptMfg_ComWiseSaleaspxV.aspx.vb" Inherits="Mfg_RptMfg_ComWiseSaleaspxV" %>

  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manufacturer/Company Wise Sales</title>
</head>
<body >
  <form id="form1" runat="server">
    <div align="right">
    </div>
    <div align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager><br />
       <asp:Label ID="lblmsg" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
    </div>
    </form>
</body>
</html> 