<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmbranchconfig.aspx.vb"
    Inherits="frmbranchconfig" Title="Branch Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Branch Configuration</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--    <center>
                    <h1 class="headingTxt">
                        &nbsp;&nbsp;BATCH SEMESTER MAP
                    </h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="Config_AutoNo" PageSize="100" SkinID="GridView" Visible="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Font-Underline="False" Text="Edit" TabIndex="3"></asp:LinkButton>
                                                            <%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                        Text="Delete" Font-Underline="False"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                                                Text="Update" TabIndex="6"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                Text="Back" TabIndex="7"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemStyle Wrap="false" />
                                                        
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblConfigID" runat="server" Visible="false" Text='<%# Bind("Config_AutoNo") %>'></asp:Label>
                                                            <asp:Label ID="LblName" runat="server" Text='<%# Bind("Config_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBranch" runat="server" Visible="false" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                                            <asp:Label ID="LblValue" Width="200px" runat="server" Text='<%# Bind("Config_Value") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtvalue" runat="server" SkinID="txt" TabIndex="5" Text='<%# Bind("Config_Value") %>'
                                                                Width="50px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblDate" runat="server" Text='<%# Bind("Date_Value","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblDesc" runat="server" Text='<%# Bind("Config_Description") %>'></asp:Label>
                                                            <asp:Label ID="lblReadOnly" runat="server" Visible="false" Text='<%# Bind("ReadOnly") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        </asp:Panel>
                    </center>
                    <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetBatchCombo"
                    TypeName="BatchSemesterMapBL"></asp:ObjectDataSource>--%>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getBatchPlannerCombo"
                        TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="BLCreateBatch"
                        SelectMethod="GetCreateBatchAcademicYearCombo"></asp:ObjectDataSource>
            </a>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

