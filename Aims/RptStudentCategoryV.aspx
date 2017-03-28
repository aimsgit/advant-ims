<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudentCategoryV.aspx.vb" 
Inherits="RptStudentCategoryV" Title= "Student Category" %>

 


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Category</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </form>
        <center>
        <asp:Label runat ="server"  ID="lblmsg" BackColor="Red" ForeColor="White"></asp:Label></center>
</body>
</html>
