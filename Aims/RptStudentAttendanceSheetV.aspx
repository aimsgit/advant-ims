<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptStudentAttendanceSheetV.aspx.vb"
    Inherits="RptStudentAttendanceSheetV" title="Student Attendance Sheet" %>


    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsas" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance Sheet</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <center>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
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

