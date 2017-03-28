<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAssetTransfer.aspx.vb"
    Inherits="RptAssetTransfer" Title="Asset Transfer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Transfer</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <br/>
                        <h1 class="headingTxt">
                            ASSET TRANSFER</h1>
                        <br/>
                        <br/>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Asset Type*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType" DataValueField="AssetType_IDAuto"
                                        AppendDataBoundItems="true" DataTextField="AssetType_Name" SkinID="ddl" TabIndex="1"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="0">All</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                        TypeName="AssetDetailsB"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAssetName" runat="server" SkinID="lblRsz" Text="Asset Name*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAssetName" runat="server" DataSourceID="ObjAssetName" DataValueField="AssetDet_ID_Auto"
                                        DataTextField="AssetCode" SkinID="ddl" TabIndex="2" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjAssetName" runat="server" SelectMethod="GetAssetNameAll"
                                        TypeName="DLAssetTransferNew">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlassetType" DefaultValue="0" Name="Assettype"
                                                PropertyName="SelectedValue" Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="From Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFrmDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="3" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtFrmDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="To Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="4" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" runat="server" TabIndex="10" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="11" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                        </div>
                                    </center>
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

