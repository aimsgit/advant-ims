<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_RptStockStmt.aspx.vb"
    Inherits="Mfg_RptStockStmt" Title="Stock Statement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stock Statement</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    STOCK STATEMENT</h1>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCompany" runat="server" SkinID="lblRsz" Text="Company&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCompany" SkinID="ddl" runat="server" TabIndex="7" DataSourceID="ObjCompany"
                                DataTextField="Manufaturer_Name" DataValueField="Manufacturer_ID" AutoPostBack="True">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCompany" runat="server" SelectMethod="GetCompany" TypeName="Mfg_DLProductDetails">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblstartdate" Width="150px" runat="server" Text="Start Date :&nbsp;&nbsp;"
                                SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtstartdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtstartdate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtstartdate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblenddate" runat="server" SkinID="lblRsz" Text="End Date :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtenddate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtenddate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtenddate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <br />
                    </caption>
                </table>
            </center>
            <center>
                <table>
                    <tr align="center">
                        <td class="btnTd" colspan="3">
                            <br />
                            <asp:Button ID="btnReport" runat="server" CausesValidation="true" CommandName="Report"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="5"
                                Text="REPORT" />
                            <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                            </asp:Button>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>
