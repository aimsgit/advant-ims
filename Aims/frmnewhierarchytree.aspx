<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmnewhierarchytree.aspx.vb"
    Inherits="frmnewhierarchytree" Title="Select Branch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Select Branch</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel runat="server" ID="UP1">
        <ContentTemplate>
            <div>
                <div align="right">
                </div>
                <%--   <center>
                    <h1 class="headingTxt">
                        SELECT BRANCH</h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <table class="custTable">
                        <tbody>
                            <tr>
                                <td style="height: 6px" align="center" colspan="2">
                                    <asp:Label ID="lblParentBranch" runat="server" SkinID="lblRsz" Text="You are Here"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="height: 6px">
                                    <asp:LinkButton ID="GotoParent" runat="server" SkinID="lb">Go to Native Branch</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 6px">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblOffice" runat="server" Text="Office :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddloffice" runat="server" SkinID="ddl" AutoPostBack="True"
                                        TabIndex="1">
                                        <asp:ListItem Value="1">Individual</asp:ListItem>
                                        <asp:ListItem Value="2">All</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblHO" runat="server" SkinID="lblRSZ" Text="HO :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlHO" runat="server" AutoPostBack="true" DataSourceID="ObjHO"
                                        DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" Width="250"
                                        TabIndex="2">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjHO" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetHO" TypeName="BLslssbhierarchytreeview"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranchName" runat="server" SkinID="lblRsz" Width="150px" Text="Branch Name :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="ListBox1" Height="200px" Width="400px" SelectionMode="Single" runat="server"
                                        TabIndex="3" DataSourceID="ObjBranchName" DataTextField="BranchName" DataValueField="BranchCode"
                                        Visible="false"></asp:ListBox>
                                    <asp:TreeView ID="TreeView1" runat="server"  SelectedNodeStyle-ForeColor="Red" SelectedNodeStyle-Font-Bold="true"
                                        Font-Underline="False">
                                    </asp:TreeView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="height: 6px">
                                    <asp:ObjectDataSource ID="ObjBranchName" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="FillListView" TypeName="BLslssbhierarchytreeview">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlHO" DbType="String" Name="HO" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="height: 6px">
                                    <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" SkinID="btn" CssClass="ButtonClass "
                                        TabIndex="4" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    &nbsp;<asp:Label ID="lblmsg" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
            </div>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
