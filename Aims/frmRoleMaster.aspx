<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRoleMaster.aspx.vb"
    Inherits="frmRoleMaster" Title="Role Master" EnableEventValidation="false" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Role Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            msg = Field50(document.getElementById("<%=txtUserRole.ClientID %>"), 'User Role');
            if (msg != "") {
                document.getElementById("<%=txtUserRole.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblgreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblgreen.ClientID %>").innerText = "";
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
                <div>
                    <%--  <center>
                        <h1 class="headingTxt">
                            ROLE MASTER</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td style="width: 70px">
                                    &nbsp;
                                </td>
                                <td style="width: 70px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="User Role* :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUserRole" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 70px">
                                    &nbsp;
                                </td>
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
                                    <asp:Button ID="Btnadd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" Text="ADD" Width="82px" TabIndex="2" />
                                    <asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass "
                                        SkinID="btn" TabIndex="3" Text="VIEW" Width="84px" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
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
                    <center>
                        <div>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="200px" Height="300px">
                                <asp:GridView ID="GVRoleMaster" runat="server" SkinID="GridView" Visible="true" AllowPaging="true"
                                    PagerStyle-CssClass="TableClass" AutoGenerateColumns="False" AllowSorting="true"
                                    OnSortCommand="" PageSize="100" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    TabIndex="4" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    TabIndex="5" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Role" SortExpression="UserRole">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserRole" runat="server" Text='<%#Bind("UserRole") %>'></asp:Label>
                                                <asp:Label ID="Label5" Visible="false" runat="server" Text='<%#Bind("UserRoleID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="TableClass"></PagerStyle>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </center>
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
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>
