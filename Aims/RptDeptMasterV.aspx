﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptDeptMasterV.aspx.vb" Inherits="BranchrptV" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department Master Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="502px" Width="739px" AsyncRendering="False" SizeToReportContent="True" >
        <LocalReport EnableExternalImages="True">
        </LocalReport>
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
