<%@ Page Title="Asset Dynamic Report" Language="VB" AutoEventWireup="false"
    CodeFile="frmAssetDynamicReport.aspx.vb" Inherits="frmAssetDynamicReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Dynamic Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        ASSET DETAILS REPORT
                    </h1>
                </center>
                <center>
                    <table>
                        <tbody>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Panel ID="pnlddl" runat="server" Width="406px">
                                        <table>
                                            <tbody>
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
                                                
                                                <%--<tr>
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
                                                </tr>--%>
                                                <%--<tr>
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
                                                --%>
                                                <tr>
                                                    <%--<td align="right">
                                                        &nbsp;
                                                    </td>--%>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Button ID="btnAdmission" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                            Text="REPORT" />&nbsp;
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="11"
                                                            Text="BACK" Visible="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                            <ProgressTemplate>
                                                                <div class="PleaseWait">
                                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                                </div>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="Admission" runat="server" Height="300px" ScrollBars="Auto" Width="180px">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GVAdmission" runat="server" AutoGenerateColumns="false" SkinID="GridView">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Column Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblModule" runat="server" Text='<%# Bind("COLUMN_NAME") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                                            TabIndex="3" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBx" runat="server" TabIndex="4" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                  
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
