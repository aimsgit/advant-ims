<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmDueSlip.aspx.vb"
    Inherits="frmDueSlip" Title="Due Slip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Due Slip</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanal1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    DUE SLIP
                </h1>
            </center>
            <center>
                <table>
                    <tr>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBuyerName" runat="server" SkinID="lbl" Text="Buyer Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBuyerName" runat="server" AutoPostBack="true" DataSourceID="ObjBuyer"
                                DataTextField="Party_Name" DataValueField="Party_Id" SkinID="ddlRsz" TabIndex="1"
                                Width="250px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="GetBuyerNameDetails1"
                                TypeName="Mfg_DLBuyerDetails"></asp:ObjectDataSource>
                        </td>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSaleInvNo" runat="server" SkinID="lblRSZ" Text="Sale Invoice No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSaleInvNo" runat="server" AutoPostBack="true" DataSourceID="ObjSaleInvNo"
                                    DataTextField="Sale_Invoice_No" DataValueField="Sale_Invoice_ID" SkinID="ddlRsz"
                                    TabIndex="1" Width="250px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSaleInvNo" runat="server" SelectMethod="GetSaleInvNoDetails"
                                    TypeName="DLSalesOrderMfg">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBuyerName" PropertyName="SelectedValue" Name="Party_Id" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStartingDate" runat="server" SkinID="lbl" Text="From Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtStartingDate" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                        Enabled="True" FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/"
                                        TargetControlID="txtStartingDate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtStartingDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEndDate" runat="server" SkinID="lbl" Text="To Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        Enabled="True"  FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/"
                                        TargetControlID="txtEndDate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                        Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtEndDate" >
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td colspan="2">
                                        <asp:Button ID="btnReport" runat="server" CausesValidation="False" CommandName="Insert"
                                            CssClass="ButtonClass" SkinID="btn" TabIndex="14" Text="REPORT" />
                                        &nbsp;<asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="15" Text="BACK" />
                                    </td>
                                </tr>
                            </tr>
                        </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>
