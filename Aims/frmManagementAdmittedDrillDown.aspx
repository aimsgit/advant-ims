<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="frmManagementAdmittedDrillDown.aspx.vb"
    Inherits="frmManagementAdmittedDrillDown" Title="Management DashBoard Admitted Drill Down" %>

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
            <tr>
                <td align="right">
                    <asp:Label ID="lblCourse" runat="server" Text="Course&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblCourseBind" runat="server" Text='<%# Bind("CourseName") %>' SkinID="lblRsz"></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td align="right">
                    <asp:Label ID="lblBatch" runat="server" Text="Batch&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblbatchBind" runat="server" Text='<%# Bind("Batch_No") %>' SkinID="lblRsz"></asp:Label>
                </td>
            </tr>--%>
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
                        <asp:Panel ID="Panel1" runat="server" Height="450px" Width="800px" ScrollBars="Auto">
                            <asp:GridView ID="GVDashBoardAdmitted" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView" TabIndex="6" PageSize="100">
                                <Columns>
                                    <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="lblStd_Photo" ImageUrl='<%# Bind("Std_Photo") %>' runat="server" Height="60px"
                                                Width="60px"></asp:Image>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" Height="20px" />
                                    </asp:TemplateField>
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
                                    <asp:TemplateField HeaderText="Contact No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdContactno" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email Id" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdEmail" runat="server" Text='<%# Bind("Std_email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Age" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdAge" runat="server" Text='<%# Bind("StdAge") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdDob" runat="server" Text='<%# Bind("DOB","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdCategory" runat="server" Text='<%# Bind("Std_CategoryName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
