<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMonthlySalary.aspx.vb"
    Inherits="frmMonthlySalary" Title="MonthlyDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Monthly Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
        <caption>
            <h1>
                MONTHLY DETAILS PAYROLL</h1>
        </caption>
        <tr>
            <td style="height: 20px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Panel runat="server" ID="Panel1" SkinID="Pnl">
                    <asp:GridView ID="gvMonthlyDeatilsPayRoll" runat="server" SkinID="GridView" DataKeyNames="Emp_Id"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <%#Eval("Emp_Name")%>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work Days">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWorkDays" runat="server" Width="60px" Text='<%# Bind("WorkDay") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AdvStl Deduction">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAdvStlDeduction" runat="server" Width="70px" Text='<%# Bind("AdvStlDeduction") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tax Deduction">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxDeduction" runat="server" Text='<%# Bind("Tax_Dedution") %>' Width="60px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Income Tax Deduction">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtITTaxDeduction" runat="server" Width="60px" Text='<%# Bind("ITTaxDeduction") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Deduction">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOtherDeduction" runat="server" Width="60px" Text='<%# Bind("OtherDeduction") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incentives">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIncentives" runat="server" Width="60px" Text='<%# Bind("Incentives") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OtherPay">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOtherPay" runat="server" Width="60px" Text='<%# Bind("OtherPay") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="55px" Text='<%# Bind("Remarks")%>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" Width="55px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="center">
                <asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" />
                <asp:Button ID="btnSave" runat="server" Text="SAVE" SkinID="btn" />
            </td>
            <td>
            </td>
        </tr>
    </table>

</form>
</body>
</html>