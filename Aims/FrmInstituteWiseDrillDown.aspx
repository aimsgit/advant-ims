<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="FrmInstituteWiseDrillDown.aspx.vb"
    Inherits="FrmInstituteWiseDrillDown" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <center>
                <h3 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h3>
            </center>
            <center>
                <table>
                    <tbody>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblCorrect" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Visible="false">
                                    <asp:GridView ID="GVZoneList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" ForeColor="Black" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Zone">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                    <%--<asp:Label ID="lblZone" runat="server" CommandName="EDIT" Text='<%# Bind("Zone") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Regional Office">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRO" runat="server" Text='<%# Bind("RO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hub">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHUB" runat="server" Text='<%# Bind("HUB") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCENTER" runat="server" Text='<%# Bind("CENTER") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Visible="false">
                                    <asp:GridView ID="GVRO" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" ForeColor="Black" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Regional Office">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                    <asp:Label ID="lblRO" Visible="false" runat="server" Text='<%# Bind("RO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hub">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHUB" runat="server" Text='<%# Bind("HUB") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCENTER" runat="server" Text='<%# Bind("CENTER") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Visible="false">
                                    <asp:GridView ID="GVHUB" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" ForeColor="Black" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Hub">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                    <asp:Label ID="lblHUB" Visible="false" runat="server" Text='<%# Bind("HUB") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCENTER" runat="server" Text='<%# Bind("CENTER") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Panel ID="panel4" runat="server" ScrollBars="Auto" Visible="false">
                                    <asp:GridView ID="GVCenter" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" ForeColor="Black" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                    <asp:Label ID="lblCENTER" runat="server" Visible="false" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
