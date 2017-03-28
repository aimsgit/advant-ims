<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmInstituteBranchCount.aspx.vb"
    Inherits="frmInstituteBranchCount" Title="INSTITUTE WISE BRANCH COUNT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>INSTITUTE WISE BRANCH COUNT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

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
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="600px" Height="700px">
                                    <asp:GridView ID="GVInstituteList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" ForeColor="Black" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Institute Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                    <asp:Label ID="lblHOCode" runat="server" Visible="false" Text='<%# Bind("HOCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Zone">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblZone" runat="server" CommandName="EDIT" Text='<%# Bind("Zone") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Regional Office">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblRO" runat="server" CommandName="DELETE" Text='<%# Bind("RO") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hub">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblHUB" runat="server" CommandName="UPDATE" Text='<%# Bind("HUB") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCENTER" runat="server" CommandName="CANCEL" Text='<%# Bind("CENTER") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
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

</form>
</body>
</html>
