<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmIncomeExpenditureDrillDown2.aspx.vb"
    EnableEventValidation="false" Inherits="FrmIncomeExpenditureDrillDown2" %>

<%@ Register Src="~/usercontroles/wuc_Themes_Select.ascx" TagName="wuc_Themes_Select"
    TagPrefix="ucl2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Income And Expenditure DrillDown Day Book</title>
</head>
<br />
<br />
<br />
<br />
<body style="background-color: #E2E3BB;">
    <form id="form1" runat="server">
    <div>
        <center>
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
        </center>
        <center>
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="500px">
                <asp:GridView ID="GVBalanceSheetDD2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="100" SkinID="GridView" TabIndex="6">
                    <Columns>
                        <asp:TemplateField HeaderText="Bill Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Bill_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bill No">
                            <ItemTemplate>
                                <asp:Label ID="lblBillNo" runat="server" Text='<%# Bind("Bill_No") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cheque No">
                            <ItemTemplate>
                                <itemtemplate>
                                <asp:Label ID="lblChNo" runat="server" Text='<%# Bind("Cheque_No") %>'></asp:Label>
                            </itemtemplate>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Description">
                            <ItemTemplate>
                                <asp:Label ID="lblItemDescription" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Party Type">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyType" runat="server" Text='<%# Bind("PartyType") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Party Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit">
                            <ItemTemplate>
                                <asp:Label ID="lblCredit" runat="server" Text='<%# Bind("Amt_In","{0:n2}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Debit">
                            <ItemTemplate>
                                <asp:Label ID="lblDebit" runat="server" Text='<%# Bind("Amt_Out","{0:n2}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </center>
    </div>
    </form>
</body>
</html>
