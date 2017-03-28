<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="frmManagementEmployeeDrillDown.aspx.vb"
    Inherits="frmManagementEmployeeDrillDown" Title="Management DashBoard Employee Drill Down" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblBranchName" runat="server" Text="Branch Name&nbsp;:&nbsp;&nbsp;"
                        SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblBranchNameBind" runat="server" Text='<%# Bind("BranchName") %>'
                        SkinID="lblRsz"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblBranchtype" runat="server" Text="Branch Type&nbsp;:&nbsp;&nbsp;"
                        SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblBranchtypeBind" runat="server" Text='<%# Bind("BranchTypeName") %>'
                        SkinID="lblRsz"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
    <table>
        <tr>
            <td align="left">
                <asp:Label ID="lblTeachinfStaff" runat="server" Text="No Of Teaching Staff&nbsp;:&nbsp;&nbsp;"
                    SkinID="lblRsz"></asp:Label>
            </td>
            <td align="left">
                <asp:Label ID="lblTStaff" runat="server" SkinID="lblRsz"></asp:Label>
            </td>
        </tr>
    </table>
    <center>
        <table>
            <tr>
                <td>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
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
                        <asp:Panel ID="Panel1" runat="server" Height="350px" Width="752px" ScrollBars="Auto">
                            <asp:GridView ID="GVDashBoardEmployee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView" TabIndex="6" PageSize="100">
                                <Columns>
                                    <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="lblEmp_Photo" ImageUrl='<%# Bind("Photos") %>' runat="server" Height="60px"
                                                Width="60px"></asp:Image>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" Height="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactNo" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="E Mail">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEMail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Birth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Joining">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOJ" runat="server" Text='<%# Bind("DOJ","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Leaving" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOL" Visible="false" runat="server" Text='<%# Bind("DOL","{0:dd-MMM-yyyy}") %>'></asp:Label>
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
    <table>
        <tr>
            <td align="left">
                <asp:Label ID="lblNoTeachingStaff" runat="server" Text="No Of NonTeaching Staff&nbsp;:&nbsp;&nbsp;"
                    SkinID="lblRsz"></asp:Label>
            </td>
            <td align="left">
                <asp:Label ID="lblNTStaff" runat="server" SkinID="lblRsz"></asp:Label>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <center>
        <table>
            <tr>
                <td>
                    <center>
                        <asp:Panel ID="Panel2" runat="server" Height="350px" Width="752px" ScrollBars="Auto">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView" TabIndex="6" PageSize="100">
                                <Columns>
                                    <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="lblEmp_Photo1" ImageUrl='<%# Bind("Photos") %>' runat="server" Height="60px"
                                                Width="60px"></asp:Image>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" Height="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpCode1" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName1" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactNo1" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="E Mail">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEMail1" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation1" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Birth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOB1" runat="server" Text='<%# Bind("DOB","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Joining">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOJ1" runat="server" Text='<%# Bind("DOJ","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Leaving" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOL1" Visible="false" runat="server" Text='<%# Bind("DOL","{0:dd-MMM-yyyy}") %>'></asp:Label>
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
