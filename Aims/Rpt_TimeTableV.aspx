<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_TimeTableV.aspx.vb"
    Inherits="Rpt_TimeTableV" Title="Time Table" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" ="server">
    <title>Time Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<center> --%>
        <table>
            <tr align="left">
                <td class="btnTd" colspan="2">
                    <rsweb:ReportViewer ID="ReportViewer2" runat="server" AsyncRendering="false" SizeToReportContent="true"
                        ShowBackButton="false" ShowPageNavigationControls="False" ShowPrintButton="false"
                        ShowToolBar="false" ShowDocumentMapButton="False" ShowExportControls="False"
                        ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                        ShowZoomControl="False">
                    </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td align="left">
                    <asp:Calendar ID="Calender1" runat="server" BackColor="White" BorderColor="Black"
                        OnDayRender="Calendar1_DayRender" BorderWidth="1px" FirstDayOfWeek="Monday" Font-Names="Verdana"
                        Font-Size="Medium" ForeColor="#663399" Height="261px" ShowGridLines="True" Width="700px"
                        BorderStyle="Double" CellSpacing="1">
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="false" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <WeekendDayStyle BackColor="Silver" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                        <TodayDayStyle BackColor="#33CCFF" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <DayHeaderStyle BackColor="#FFFF99" Font-Bold="True" Height="1px" />
                        <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC"/>
                    </asp:Calendar>
                </td>
            </tr>
            <tr align="left">
                <td class="btnTd" colspan="2">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
                    </rsweb:ReportViewer>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                </td>
            </tr>
        </table>
    </div>
    <center>
        <asp:Label ID="lblmsg" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
    </center>
    </form>
</body>
</html>
