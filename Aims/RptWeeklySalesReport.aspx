<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptWeeklySalesReport.aspx.vb"
    Inherits="RptWeeklySalesReport" Title="Weekly Sales Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Weekly Sales Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    WEEKLY SALES REPORT
                </h1>
                <br /> <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblMonth" runat="server" Text="Month&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddl" TabIndex="3">
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblYear" runat="server" Text="Year&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW" />&nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr align="center">
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed" />
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <br />
            <center>
            <asp:Chart ID="Chart1" runat="server" Height="450px" Width="750px" EnableViewState="true">
                        <Legends>
                            <asp:Legend Name="Legend1" BackImageAlignment="TopRight" Docking="Top" LegendStyle="Row"
                                TitleFont="Microsoft Sans Serif, 6pt, style=Bold">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Text="Week Wise Sale Status" Font="Microsoft Sans Serif, 14.25pt">
                            </asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series1" IsValueShownAsLabel="True" Legend="Legend1"
                              LegendText="Week1">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series2" IsValueShownAsLabel="True" Legend="Legend1"
                                LegendText="Week2">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series3" IsValueShownAsLabel="True" Legend="Legend1"
                                LegendText="Week3">
                            </asp:Series>
                     
                        <asp:Series ChartArea="ChartArea1" Name="Series4" IsValueShownAsLabel="True" Legend="Legend1"
                                LegendText="Week4" >
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" >
                                <AxisY Title="Sales In Rupees">
                                </AxisY>
                                <AxisX Title="Branch">
                                    <LabelStyle />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
              </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
