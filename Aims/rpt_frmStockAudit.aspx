<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_frmStockAudit.aspx.vb"
    Inherits="rpt_frmStockAudit" Title="STOCK AUDIT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STOCK AUDIT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    STOCK AUDIT
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custTable">
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
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <asp:Button ID="btnReport" runat="server" CausesValidation="False" CommandName="Insert"
                                CssClass="ButtonClass"  SkinID="btn" TabIndex="14"
                                Text="REPORT" />
                            &nbsp;<asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="15" Text="BACK" />
                        </td>
                </table>
            </center>
            <table>
                <tr>
                    <td>
                        &nbsp;
                    </td>
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
