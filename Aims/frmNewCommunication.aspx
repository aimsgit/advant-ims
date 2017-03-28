<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmNewCommunication.aspx.vb"
    Inherits="frmNewCommunication" Title="Communication" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Communication</title>
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
//            msg = NameField(document.getElementById("<%=txtmessage.ClientID %>"), 'Message');
//            if (msg != "") {
//                document.getElementById("<%=txtmessage.ClientID %>").focus();
//                return msg;
//            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
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
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
                <br />
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBranchType" runat="server" Text="Branch :&nbsp;&nbsp;" SkinID="lbl"
                                Width="100px"></asp:Label>
                        </td>
                        <td align="Left">
                            <asp:DropDownList ID="txtBranchName" TabIndex="1" runat="server" SkinID="ddlRsz"
                                Width="250px" AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName"
                                DataValueField="BranchCode">
                            </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                            <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="BranchCombo" TypeName="DLReportsR"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="lblTo" runat="server" SkinID="lblRsz" Text="To* :&nbsp;&nbsp;" Width="50px"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="ddlGroup" TabIndex="8" runat="server" AppendDataBoundItems="true"
                                DataValueField="Id" AutoPostBack="true" DataTextField="Name" SkinID="ddl">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Student"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Parent"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Employee"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objGroup" runat="server" SelectMethod="GetGroupMail" TypeName="DLCommunicationModule">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            <%--</center>
            <center>--%>
                <hr />
                <table>
                    <tr>
                        <td align="left" colspan="2" rowspan="6" valign="top">
                            <asp:Panel ID="GVPanel" runat="server" Height="250px" ScrollBars="Auto" Width="700px">
                                <asp:GridView ID="GVName" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="ID" PageSize="100" SkinID="GridView" Width="700px" TabIndex="9">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                    Text="ALL" Width="20px" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkIndividual" runat="server" />
                                            </ItemTemplate>
                                            <ControlStyle Width="20px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBranchcode" runat="server" Text='<%# Bind("BranchCode") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBranchname" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email ID" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContact" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <hr />
            <%--</center>
            <center>--%>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblreport" runat="server" SkinID="lblRsz" Text="Report :&nbsp;&nbsp;"
                                Width="80px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlreport" TabIndex="8" runat="server" AppendDataBoundItems="true"
                                DataValueField="Id" AutoPostBack="true" DataTextField="Name" SkinID="ddlRsz" Width="250px">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Management Dashboard - Tabular"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Management Dashboard - Graphical"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="lblmessage" runat="server" SkinID="lblRsz" Text="Message* :&nbsp;&nbsp;"
                                Width="90px"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2">
                            <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" SkinID="txtRsz" Width="400px" Height="70px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" colspan="2">
                            <asp:RadioButtonList ID="rblist1" runat="server" EnableTheming="True" RepeatLayout="Table"
                                TextAlign="Right" RepeatDirection="Horizontal" CellPadding="10">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
         <%--   </center>
            <center>--%>
                <table>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnView" TabIndex="10" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btnRsz" Text="VIEW MAIL" Width="160px" />
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnPublish" TabIndex="10" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btnRsz" Text="SEND MAIL" Width="160px" />
                        </td>
                    </tr>
                </table>
          <%--  </center>
            <center>--%>
                <table>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblcorrect" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp
                        </td>
                    </tr>
                </table>
           <%-- </center>
            <center>--%>
                <table>
                    <tr>
                        <td align="left" colspan="2" rowspan="6" valign="top">
                            <asp:Panel ID="MsgPanel" runat="server" Height="250px" ScrollBars="Auto" Width="700px">
                                <asp:GridView ID="GVMsg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNgames="ID" PageSize="100" SkinID="GridView" Width="700px" TabIndex="9">
                                    <Columns>
                                        <asp:TemplateField HeaderText="To" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblto" Width="400px" runat="server" Text='<%# Bind("To") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="True" />
                                            <HeaderStyle Wrap="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Message" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMessage" Width="400px" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="True" />
                                            <HeaderStyle Wrap="True" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
