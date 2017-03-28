<%@ Page Title="" Language="VB" AutoEventWireup="false"
    CodeFile="frmRollTesting.aspx.vb" Inherits="frmRollTesting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <script language="JavaScript" type="text/javascript">
     function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlInstitute.ClientID %>"), 'Select Institute');
            if (msg != "") {
                document.getElementById("<%=ddlInstitute.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlBranch.ClientID %>"), 'Select Branch');
            if (msg != "") {
                document.getElementById("<%=ddlBranch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlRole.ClientID %>"), 'Select Role');
            if (msg != "") {
                document.getElementById("<%=ddlRole.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
            }
            return true;
        }

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        ROLE TESTING FORM
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblInstitute" runat="server" Text="Select Institute* :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlInstitute" runat="server" DataTextField="BranchName" DataSourceID="ObjInstitute"
                                        DataValueField="BranchCode" Width="240px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjInstitute" runat="server" SelectMethod="GetInstitute"
                                        TypeName="RollTestingDL"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranch" runat="server" Text="Select Branch* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" DataTextField="BranchName" DataSourceID="ObjBranch"
                                        DataValueField="BranchCode" Width="240px" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="GetBranchRollTesting"
                                        TypeName="RollTestingDL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlInstitute" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRoll" runat="server" Text="Select Role(s)* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlRole" runat="server" DataTextField="UserRole" DataSourceID="ObjRole"
                                            DataValueField="RoleCode" Width="240px" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjRole" runat="server" SelectMethod="GetRole" TypeName="RollTestingDL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="2" Text="VIEW" Width="100px" OnClientClick="return Validate();"  />
                                </td>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="4" Text="REPORT" Width="100px" OnClientClick="return Validate();"  />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <div>
                            <center>
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </center>
                        </div>
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="500px">
                            <div style="float: Left; width: 50%">
                                <h3>
                                    Roles As Defined in Branch</h3>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Role" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserRole" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Child Link" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChildName" runat="server" Text='<%# Bind("ChildName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="float: Right; width: 50%">
                                <h3>
                                    Roles As Defined in SuperAdmin</h3>
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Role" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserRole1" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Child Link" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChild1" runat="server" Text='<%# Bind("ChildName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                </asp:Panel>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                        </a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
