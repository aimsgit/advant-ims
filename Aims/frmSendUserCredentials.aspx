<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSendUserCredentials.aspx.vb"
    Inherits="frmSendUserCredentials" Title="Send User Credentials" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Send User Credentials</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlGroup.ClientID %>"), 'Group');
            if (msg != "") {
                document.getElementById("<%=ddlGroup.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblGreen1.ClientID %>").innerText = "";
                    document.getElementById("<%=lblRed1.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblGreen1.ClientID %>").innerText = "";
                    document.getElementById("<%=lblRed1.ClientID %>").textContent = msg;
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%--     <center>
                <h1 class="headingTxt">
                    COMMUNICATION CENTER
                </h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label><br />
                    <br />
                </h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                            <asp:Label ID="lblUserDetails" runat="server" Text="User Group*&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddlGroup" TabIndex="1" runat="server" AppendDataBoundItems="true"
                                AutoPostBack="True" SkinID="ddl">
                                <asp:ListItem Selected="True" Value="0">Select Group</asp:ListItem>
                                <asp:ListItem Value="1">Student</asp:ListItem>
                                <asp:ListItem Value="7">Parents</asp:ListItem>
                                <asp:ListItem Value="2">Employees</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left" valign="top">
                            <asp:CheckBox ID="CheckSMS" runat="server" AutoPostBack="true" TabIndex="3" Text="SMS"
                                Value="1" />
                            <br />
                            <asp:CheckBox ID="CheckEmail" runat="server" AutoPostBack="true" TabIndex="4" Text="Email"
                                Value="2" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" valign="top">
                            <asp:Button ID="btnSend" TabIndex="2" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btn" Text="SEND" />
                            <asp:Button ID="BtnPrint" TabIndex="2" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btn" Text="PRINT" Visible="false" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblRed1" runat="server" Text="" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblGreen1" runat="server" Text="" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </center>
                <table>
                    <tr>
                        <td align="center" colspan="2" rowspan="6" valign="top">
                            <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Height="300px" Width="500px">
                                <asp:GridView ID="GVName" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="ID" PageSize="100" SkinID="GridView" Width="280px" EnableSortingAndPagingCallbacks="True"
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                    Text="ALL" Width="20px" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkIndividual" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Select Name" Visible="true" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                <asp:Label ID="lblEmp_Code" runat="server" Text='<%# Bind("Emp_Code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group Name" Visible="true" SortExpression="GroupName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <%--<asp:ObjectDataSource ID="ObjName" runat="server" SelectMethod="GetNameCombo" TypeName="BLCommunication">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlGroup" Name="GroupID" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>--%>&nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <a name="Bottom">
                <div align="right">
                    <a href="#Top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
