﻿<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeFile="FrmIncmExpen.aspx.vb"
    Inherits="FrmIncmExpen" %>

<%@ Register Src="~/usercontroles/wuc_Themes_Select.ascx" TagName="wuc_Themes_Select"
    TagPrefix="ucl2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script language="javascript" type="text/javascript">

    function openNewWin(url) {

        var x = window.open(url, 'mynewwin', 'width=900,height=700,scrollbars=yes,location=no,resizable =yes');

        x.focus();

    }

</script>

<head id="Head1" runat="server">
    <title>Income & Expenditure DrillDown</title>
</head>
<br />
<br />
<br />
<br />
<body style="background-color: #E2E3BB;">
    <form id="form1" runat="server">
    <center>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="msginfo" SkinID="lblRed" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
            <br />
            <br />
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Height="500px" Width="650px">
                <asp:GridView ID="GVBalanceSheetFirstDD" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="100" SkinID="GridView" TabIndex="6">
                    <Columns>
                        <asp:TemplateField HeaderText="Head-Type">
                            <ItemTemplate>
                                <asp:HiddenField ID="hidAccHeadCode" runat="server" Value='<%# Bind("Account_Code") %>' />
                                <asp:HiddenField ID="hidAccSubGroupId" runat="server" Value='<%# Bind("Acct_SubGroup_ID") %>' />
                                <asp:Label ID="lblHeadTyp" runat="server" Text='<%# Bind("Head_Type") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkLiaAmt" runat="server" CausesValidation="False" CommandName="edit"
                                    Font-Underline="False" Text='<%# Bind("Amt_In","{0:n2}")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Debit">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkLiaAmt1" runat="server" CausesValidation="False" CommandName="Edit"
                                    Font-Underline="False" Text='<%# Bind("Amt_Out","{0:n2}")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </center>
    </form>
</body>
</html>
