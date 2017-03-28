<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Treeview.aspx.vb"
    Inherits="Treeview" Title="Tree View Details" %>

<%--%<@ Register Src="~/usercontroles/wuc_treeview.ascx" TagName="wuc_treeview" TagPrefix="ucl1" %>
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tree View Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <div class="mainBlock">
        <center>
            <h1 class="headingTxt">
                ADD/UPDATE IN TREE VIEW</h1>
        </center>
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Width="351px" Text="Add new links to tree view -"
                                        SkinID="lbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="75px">
                                        <asp:GridView ID="GridView2" runat="server" SkinID="GridView" AutoGenerateColumns="False"
                                            PageSize="1">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" SelectText="Insert Child" />
                                                <asp:CommandField ShowDeleteButton="True" DeleteText="Update Parent" />
                                                <asp:TemplateField HeaderText="Parent ID" SortExpression="Parent_ID">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" SkinID="txt" Width="50" Text='<%# Bind("Parent_ID") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Child ID" SortExpression="Child_ID">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" SkinID="txt" Width="50" Text='<%# Bind("Child_ID") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Title">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server" SkinID="txt" Text='<%# Bind("Title") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parent Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server" SkinID="txt" Text='<%# Bind("Parent_Name") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Link Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox5" runat="server" SkinID="txt" Text='<%# Bind("LinkName") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox6" runat="server" SkinID="txt" Visible="false" Text='<%# Bind("Form_ID") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Width="351px" Text="Update the links in  tree view-"
                                        SkinID="lbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="700px" Height="200px">
                                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AutoGenerateColumns="false"
                                            AllowPaging="False" ShowFooter="true">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" SelectText="Update" ShowDeleteButton="True" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="lblId" runat="server" Value='<%# Bind("ID") %>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parent ID" SortExpression="Parent_ID">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" SkinID="txt" Width="50" Text='<%# Bind("Parent_ID") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Child ID" SortExpression="Child_ID">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" SkinID="txt" Width="50" Text='<%# Bind("Child_ID") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Title">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server" SkinID="txt" Text='<%# Bind("Title") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parent Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server" SkinID="txt" Text='<%# Bind("Parent_Name") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Link Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox5" runat="server" SkinID="txt" Text='<%# Bind("LinkName") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox6" runat="server" SkinID="txt" Text='<%# Bind("Form_ID") %>'
                                                            Visible="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:LinkButton ID="LinkButton12" runat="server">Previous</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" runat="server"> 1 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server"> 2 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server"> 3 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server"> 4 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" runat="server"> 5 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton6" runat="server"> 6 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton7" runat="server"> 7 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton8" runat="server"> 8 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton9" runat="server"> 9 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton10" runat="server">10 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton13" runat="server">11</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton14" runat="server">12</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton15" runat="server">13</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton16" runat="server">14 </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton17" runat="server">15</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton18" runat="server">16</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton19" runat="server">17</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton20" runat="server">18</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton21" runat="server">19</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton22" runat="server">20</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton11" runat="server" Text="Next"> </asp:LinkButton>
                                    <%-- <asp:LinkButton ID="LinkButton13" runat="server"> 13 </asp:LinkButton>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="msginfo" runat="server" Text="" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="TreeViewB"
            SelectMethod="GetTreeView1"></asp:ObjectDataSource>
    </div>
    <center>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label12" Visible="true" runat="server" SkinID="lblRsz" Width="720px"></asp:Label>
                </td>
            </tr>
        </table>
    </center>

</form>
</body>
</html>

