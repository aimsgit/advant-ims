<%@ Page Title="MonthWise PurchaseSalesReturn" Language="VB" AutoEventWireup="false" CodeFile="frmMonthWisePurchaseSalesReturnDashboard.aspx.vb" Inherits="frmMonthWisePurchaseSalesReturnDashboard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MonthWise PurchaseSalesReturn</title>
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
                    MONTHWISE PURCHASE SALES RETURN STATUS
                </h1>
                <br />
            </center>
            <center>
                <table>
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
                        <td>
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
                    <%--<Titles>
                            <asp:Title Text="Week Wise Sale Status" Font="Microsoft Sans Serif, 14.25pt">
                            </asp:Title>
                        </Titles>--%>
                    <Series>
                        <asp:Series ChartArea="ChartArea1" Name="Series1" IsValueShownAsLabel="True" Legend="Legend1"
                            LegendText="Purchse value" Color="Green">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Name="Series2" IsValueShownAsLabel="True" Legend="Legend1"
                            LegendText="Sales value" Color="Yellow">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Stock Values In Rupees">
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