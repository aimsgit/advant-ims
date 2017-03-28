<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBalanceSheetDrillDown.aspx.vb" EnableEventValidation="false"
    Inherits="frmBalanceSheetDrillDown" %>

<%@ Register Src="~/usercontroles/wuc_Themes_Select.ascx" TagName="wuc_Themes_Select"
    TagPrefix="ucl2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script language="javascript" type="text/javascript">

    function openNewWin(url) {

        var x = window.open(url, 'mynewwin', 'width=900,height=700,scrollbars=yes,location=no,resizable =yes');

        x.focus();

    }

</script>

<head runat="server">
    <title>Balance Sheet DrillDown A/c Heads</title>
</head>
<br />
<br />
<br />
<br />
<body style="background-color: #E2E3BB;">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="form1" runat="server">
    <center>
        <div>
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblAccGrp" runat="server" Text="Account Group&nbsp;:&nbsp;&nbsp;"
                            SkinID="lblRsz"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblAccGrpBind" runat="server" Text='<%# Bind("Acct_Group") %>' SkinID="lblRsz"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblAccSub" runat="server" Text="Account Sub Group&nbsp;:&nbsp;&nbsp;"
                            SkinID="lblRsz"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblAccSubBind" runat="server" Text='<%# Bind("Acct_Sub_Group") %>'
                            SkinID="lblRsz"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
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
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Height="500px" Width="650px">
                <asp:GridView ID="GVBalanceSheetFirstDD" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="100" SkinID="GridView" TabIndex="6">
                    <Columns>
                        <asp:TemplateField HeaderText="Party Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="lblPartyNameid" runat="server" Value='<%# Bind("Party_Id_Name") %>' />
                                <asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Head-Type">
                            <ItemTemplate>
                                <asp:HiddenField ID="hidAccHeadCode" runat="server" Value='<%# Bind("Account_Code") %>' />
                                <asp:Label ID="lblHeadTyp" runat="server" Text='<%# Bind("Head_Type") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit">
                            <ItemTemplate>
                                <asp:LinkButton ID="Link" runat="server" CausesValidation="False" CommandName="Edit"
                                    Font-Underline="False" Text='<%# Bind("Amt_In","{0:n2}")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Debit">
                            <ItemTemplate>
                                <asp:LinkButton ID="Link2" runat="server" CausesValidation="False" CommandName="Edit"
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
    <center>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" CommandName="EXPORT" />
        </asp:Panel>
    </center>
    </form>
</body>
</html>
