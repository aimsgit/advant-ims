<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShopWiseSaleReport.aspx.vb"
    Inherits="ShopWiseSaleReport" Title="Shop Wise Sale Report" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Shop Wise Sale Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
                        SHOP WISE STATUS
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:HiddenField ID="HidBranchId" runat="server" />
                                    <asp:Label ID="lblBranchName" SkinID="lblRsz" runat="server" Text="Branch Name*&nbsp;:&nbsp;&nbsp;"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlRsz"
                                        AutoPostBack="True" DataSourceID="ObjBranchName" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBranchName" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBranchCombo" TypeName="DL_ShopWiseSalesReport"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFromDate" runat="server" Text="From Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
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
                                    <asp:Label ID="lblToDate" runat="server" Text="To Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
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
                                <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                    <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        SkinID="btnRsz" TabIndex="4" Text="VIEW" />
                                    <%--<asp:Button ID="btnBack" TabIndex="5" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>--%>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
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
                    <asp:Chart ID="Chart1" runat="server" Height="350px" Width="750px" EnableViewState="true">
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
                            <asp:Series ChartArea="ChartArea1" Name="Series1" IsValueShownAsLabel="True" Legend="Legend1"
                              LegendText="Purchase" LabelAngle="-90" >
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series2" IsValueShownAsLabel="True" Legend="Legend1"
                                LegendText="Sale" LabelAngle="-90">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series3" IsValueShownAsLabel="True" Legend="Legend1"
                                LegendText="Stock" LabelAngle="-90">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BackImageAlignment="Top">
                                <AxisY Title="In Rupees">
                                </AxisY>
                                <AxisX Title="Branch">
                                    <LabelStyle Angle="-90" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
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

