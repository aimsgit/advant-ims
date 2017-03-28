<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmBalanceSheetDashboard.aspx.vb"
    Inherits="FrmBalanceSheetDashboard" Title="Balance Sheet Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Balance Sheet Dashboard</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=Txtfdate.ClientID%>"), 'Start Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=Txttodate.ClientID%>"), 'End Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=ErrMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=ErrMsg.ClientID %>").textContent = msg;
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        BALANCE SHEET DASHBOARD
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFromDate" runat="server" Text="From Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                        TargetControlID="Txtfdate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" Text="To Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                        TargetControlID="Txttodate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnGenerate" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="4" Text="GENERATE" />
                                    &nbsp; <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                        Text="BACK" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                            <ProgressTemplate>
                                <div class="PleaseWait">
                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="ErrMsg" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                        </table>
                    </center>
                </asp:Panel>
                <br />
                <br />
                
                
                <center>
                    <asp:Panel ID="Panel2" runat="server" Height="500px" Width="750px" ScrollBars="Auto">
                        <asp:Chart ID="Chart1" runat="server" Height="450px" Width="750px"
                         EnableViewState="true">
                            <Legends>
                                <asp:Legend Name="Legend1" BackImageAlignment="TopRight" Docking="Top" LegendStyle="Row"
                                    TitleFont="Microsoft Sans Serif, 6pt, style=Bold">
                                </asp:Legend>
                            </Legends>
                            <Titles>
                                <%--<asp:Title Text="Shop Wise Status" Font="Microsoft Sans Serif, 14.25pt">
                            </asp:Title>--%>
                            </Titles>
                            <Series>
                                <asp:Series Name="Series1" IsValueShownAsLabel="True" Legend="Legend1" LegendText="Assets & Liabilities"
                                    LabelAngle="-90" IsVisibleInLegend="false">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BackImageAlignment="Top">
                                    <AxisY Title="In Rupees">
                                    </AxisY>
                                    <AxisX Title="Account Sub Group">
                                        <LabelStyle Angle="-90" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </asp:Panel>
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
