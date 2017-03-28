<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAssetDetailsReport.aspx.vb"
    Inherits="RptAssetDetailsReport" Title="Asset Details Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Details Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <br />
                    <h1 class="headingTxt">
                        ASSET DETAILS REPORT</h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAssetType" runat="server" SkinID="lblRsz" Text="Asset Type :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType" DataValueField="AssetType_IDAuto"
                                    AppendDataBoundItems="true" DataTextField="AssetType_Name" SkinID="ddl" TabIndex="1"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                    TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSupplier" runat="server" SkinID="lblRsz" Text="Supplier :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsupplier" runat="server" DataSourceID="cmbsupplier" DataValueField="Supp_Id_Auto"
                                    DataTextField="Supp_Name" AppendDataBoundItems="True" SkinID="ddl" TabIndex="2">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="cmbsupplier" runat="server" SelectMethod="GetSuppliercombo"
                                    TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblManufrcturer" runat="server" SkinID="lbl" Text="Manufacturer :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlmanufacturer" runat="server" DataSourceID="cmbmanufacturer"
                                    DataValueField="ManuFacturerCode" DataTextField="ManuFacturer" AppendDataBoundItems="True"
                                    SkinID="ddl" TabIndex="3">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="cmbmanufacturer" runat="server" SelectMethod="GetManufacturercombo"
                                    TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblGRNNo" runat="server" SkinID="lbl" Text="GRN No :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlgrnno" runat="server" DataSourceID="objgrnno"
                                    DataValueField="GRN_No" AppendDataBoundItems="True"
                                    SkinID="ddl" TabIndex="4">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objgrnno" runat="server" SelectMethod="GetGRNNo"
                                    TypeName="AssetDetailsDB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPurchFromDate" runat="server" SkinID="lblRsz" Text="Purchase From Date :&nbsp;&nbsp"
                                    Width="180"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" AutoCompleteType="Disabled"
                                    SkinID="txt" TabIndex="5"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                        runat="server" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'"
                                        TargetControlID="txtFromDate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPurchToDate" runat="server" SkinID="lblRsz" Text="Purchase To Date :&nbsp;&nbsp"
                                    Width="180"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDate" runat="server" MaxLength="11" AutoCompleteType="Disabled"
                                    SkinID="txt" TabIndex="6"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                        runat="server" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'"
                                        TargetControlID="txtToDate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td class="btnTd" align="center">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="7"
                                    Text="REPORT" Visible="true" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="8" Text="BACK" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                                        <asp:Label ID="msginfo" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                    </table>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>


</form>
</body>
</html>

