<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptCalEventsold.aspx.vb"
    Inherits="RptCalEventsold" Title="Calendar Of Events" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Calendar Of Events</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtFrmDate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFrmDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        CALENDAR OF EVENTS</h1>
                    <br />
                </center>
            </div>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtFrmDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" runat="server" Text=" To Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtToDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnTd">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="REPORT" SkinID="btn" TabIndex="3" CssClass="ButtonClass" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <div id="div2" runat="server">
                    <asp:Calendar ID="Calendar1" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" BorderWidth="0px" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar2" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar3" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar4" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar5" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar6" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar7" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar8" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar9" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar10" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar11" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar12" runat="server" NextMonthText="" PrevMonthText="" ShowGridLines="True"
                        Width="604px" FirstDayOfWeek="Monday" SelectMonthText="" SelectWeekText="" ShowNextPrevMonth="False"
                        BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px">
                        <WeekendDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#FF99CC" />
                        <DayHeaderStyle BackColor="#FFFF99" />
                        <TitleStyle BackColor="#003399" ForeColor="White" />
                    </asp:Calendar>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
