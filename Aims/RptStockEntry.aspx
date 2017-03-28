<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStockEntry.aspx.vb"
    Inherits="RptStockEntry" Title="Stock Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stock Entry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            STOCK ENTRY
                        </h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStkEntryDate" runat="server" SkinID="lblRsz" Width="200" Text="Stock Entry Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLBranch" runat="server" SkinID="ddlRsz" Width="150" DataSourceID="ObjStkEntryDate"
                                        DataTextField="VAT_Invoice_Date"  AutoPostBack="True"
                                        TabIndex="1">
                                        <asp:ListItem Text="All" Value="0" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStartingDate" runat="server" Text="Starting Date &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" runat="server" SkinID="Rszxtxt" Width="150px" MaxLength="11"
                                        TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEnddate" runat="server" Text="End Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" runat="server" SkinID="Rszxtxt" Width="150px" MaxLength="11"
                                        TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                                        Format="dd-MMM-yyyy" Animated="False">
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
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text=" REPORT"
                                        TabIndex="4" />
                                    <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                        TabIndex="5" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label></div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ObjStkEntryDate" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="RptStockEntrydate" TypeName="Mfg_DLStockEntry"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

