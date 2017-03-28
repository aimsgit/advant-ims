<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="frmManagementFeeCollectionDrillDown.aspx.vb"
    Inherits="frmManagementFeeCollectionDrillDown" Title="Management DashBoard Fee Collection DrillDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblBranchName" runat="server" Text="Branch Name&nbsp;:&nbsp;&nbsp;"
                        SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblBranchNameBind" runat="server" Text='<%# Bind("BranchName") %>'
                        SkinID="lblRsz"></asp:Label>
                </td>
                <td style="width: 120px;" align="center">
                    &nbsp;
                </td>
                <td rowspan="4">
                    <asp:Panel ID="panNote" runat="server">
                        <table class="TimeTable">
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:Label ID="lblNote" runat="server" Width="200px">NOTE :
                                        <asp:BulletedList ID="BulletedList1" runat="server">
                                            <asp:ListItem>Negative(-) values implies Discount</asp:ListItem>
                                            <asp:ListItem>Positive(+) values implies Fine </asp:ListItem>
                                        </asp:BulletedList>
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblBranchtype" runat="server" Text="Branch Type&nbsp;:&nbsp;&nbsp;"
                        SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblBranchtypeBind" runat="server" Text='<%# Bind("BranchTypeName") %>'
                        SkinID="lblRsz"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblCourse" runat="server" Text="Course&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblCourseBind" runat="server" Text='<%# Bind("CourseName") %>' SkinID="lblRsz"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <%--<tr>
                <td align="left">
                    <asp:Label ID="lblBatch" runat="server" Text="Batch&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblbatchBind" runat="server" Text='<%# Bind("Batch_No") %>' SkinID="lblRsz"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td colspan="3">
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
        </table>
    </center>
    <center>
        <table>
            <tr>
                <td>
                    <center>
                        <asp:Panel ID="Panel1" runat="server" Height="450px" Width="800px" ScrollBars="Auto">
                            <asp:GridView ID="GVDashBoardFeeCollection" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView" TabIndex="6" PageSize="100">
                                <Columns>
                                    <asp:TemplateField HeaderText="Student Code" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdCode" Text='<%# Bind("StdCode") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" Height="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Fee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotFee" runat="server" Text='<%# Bind("TotalFee","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Collected">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("Amount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount/Fine">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDisc" runat="server" Text='<%# Bind("Discount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance Fee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBal" runat="server" Text='<%# Bind("Balance","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Payment Method">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactNo" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque/DD No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChqNo" runat="server" Text='<%# Bind("ChequeNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque/DD Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChqDate" runat="server" Text='<%# Bind("Cheque_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeDate" runat="server" Text='<%# Bind("Fee_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receipt No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOJ" runat="server" Text='<%# Bind("ReceiptNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
