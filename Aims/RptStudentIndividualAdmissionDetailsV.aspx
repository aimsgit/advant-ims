<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptStudentIndividualAdmissionDetailsV.aspx.vb" Inherits="RptStudentIndividualAdmissionDetailsV" title="StudentIndividualAdmissionDetails" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT INDIVIDUAL ADMISSION DETAILS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:reportviewer id="ReportViewer11" runat="server" asyncrendering="false" sizetoreportcontent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <center>
            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
        </center>
    
    </form>
</body>
</html>
