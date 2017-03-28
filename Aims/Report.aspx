<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Report.aspx.vb"
    Inherits="Report" Title="Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reports</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div>
                    <h1 class="headingTxt">
                        REPORTS
                    </h1>
                    <%-- <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>--%>
                    <table>
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/download.jpg"
                                    TabIndex="1" AutoPostBack="true" Width="25px" />
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtSearchKey" runat="server" SkinID="txt" TabIndex="2" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender" runat="server"
                                    SkinID="watermark" TargetControlID="txtSearchKey" WatermarkText="Search">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblModule" runat="server" Text="Module Name^&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlModule" runat="server" DataSourceID="objModule" SkinID="ddlRsz"
                                    DataValueField="Parent_ID" DataTextField="Parent_Name" TabIndex="3" Width="250"
                                    AppendDataBoundItems="true" AutoPostBack="true">
                                    <asp:ListItem Value="0"> Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objModule" runat="server" TypeName="UserDetailsDB" SelectMethod="GetParentNameddl">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="800px" Height="600px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label" runat="server" SkinID="lblred"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GrdReport" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="1000" SkinID="GridView" Width="700px">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HFRid" runat="server" Value='<%# Bind("RID") %>'></asp:HiddenField>
                                                    <asp:HiddenField ID="HFParentId" runat="server" Value='<%# Bind("ParentID") %>'>
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="HFChildId" runat="server" Value='<%# Bind("ChildID") %>'></asp:HiddenField>
                                                    <asp:HiddenField ID="HFLinkName" runat="server" Value='<%# Bind("LinkName") %>'>
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="HFQryStr" runat="server" Value='<%# Bind("qrystring") %>'></asp:HiddenField>
                                                    <asp:HiddenField ID="HFHeading" runat="server" Value='<%# Bind("heading") %>'></asp:HiddenField>
                                                    <asp:HiddenField ID="HFDirectLink" runat="server" Value='<%# Bind("DirectLink") %>'>
                                                    </asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Module Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParentName" runat="server" Text='<%# Bind("ParentName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="true" HeaderText="Report Name" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" CommandName="Edit"
                                                        Text='<%# Bind("ChildName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="true" HeaderText="Remarks" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <%-- <div style="float: right; width: 50%">
                <h1 class="headingTxt">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT
                    BRANCH
                </h1>
                <%-- <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                     <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="380px" Height="645px">
                <table class="custTable">
                    <tbody>
                     
                        <tr>
                            <td style="height: 6px" colspan="2" align="center">
                                <asp:Label ID="lblParentBranch" runat="server" SkinID="lblRsz" Text="You are Here"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 6px" align="center">
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
                                <asp:TreeView ID="TreeView1" runat="server" SelectedNodeStyle-ForeColor="Red" SelectedNodeStyle-Font-Bold="true"
                                    Font-Underline="False">
                                </asp:TreeView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 6px">
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
                            <td colspan="2" style="height: 6px">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" SkinID="btn" CssClass="ButtonClass "
                                    TabIndex="4" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
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
                </asp:Panel>
            </div> --%>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
