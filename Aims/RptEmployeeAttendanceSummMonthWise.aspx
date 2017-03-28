<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptEmployeeAttendanceSummMonthWise.aspx.vb"
    Inherits="RptEmployeeAttendanceSummMonthWise" Title="Employee Attendance Summary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Attendance Summary</title>
    <link id="link2" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"), 'End Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrormsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrormsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <%--<a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    EMPLOYEE ATTENDANCE SUMMARY - MONTH WISE
                </h1>
                <br />
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStartDate" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tbody>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                    TabIndex="3" OnClientClick="return ValidReport();" />
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                    TabIndex="4" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblerrormsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
