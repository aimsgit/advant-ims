<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmLeaveTypes.aspx.vb"
    Inherits="FrmLeaveTypes" Title="Leave Type" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Leave Type</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlleavefor.ClientID %>"), 'Leave For');
            if (msg != "") {
                document.getElementById("<%=ddlleavefor.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtLeavetype.ClientID%>"), 'LeaveType');
            document.getElementById("<%=txtLeavetype.ClientID%>")
            if (msg != "") return msg;
            msg = Field30(document.getElementById("<%=txtleavecode.ClientID %>"), 'Leave Type Code');
            document.getElementById("<%=txtleavecode.ClientID%>")
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msgInfo.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msgInfo.ClientID %>").textContent = "";

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
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--<center>
                        <h1 class="headingTxt">
                            LEAVE TYPE</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblleavefor" runat="server" SkinID="lblRsz" Text="Leave For* :&nbsp;&nbsp;"
                                            Width="180px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlleavefor" runat="server" SkinID="ddl" TabIndex="1">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="S">Student</asp:ListItem>
                                            <asp:ListItem Value="E">Employee</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLeavetype" runat="server" Text="Leave Type* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLeavetype" runat="server" TabIndex="2" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblleavetypecode" runat="server" Text="Leave Type Code* :&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="180px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtleavecode" runat="server" TabIndex="3" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDescrptn" runat="server" SkinID="lblRsz" Text="Leave Description :&nbsp;&nbsp;"
                                            Width="180px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescription" runat="server" TabIndex="4" SkinID="txt" MaxLength="60"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPaid" runat="server" SkinID="lblRsz" Text="Paid  :&nbsp;&nbsp;"
                                            Width="180px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlpaid" runat="server" SkinID="ddl" TabIndex="5">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <center>
                                    <tr>
                                        <td colspan="2" class="btnTd">
                                            <br />
                                            <asp:Button ID="btnSave" runat="server" Text="ADD" SkinID="btn" TabIndex="6" OnClientClick="return Validate();"
                                                ValidationGroup="save" CssClass="ButtonClass"></asp:Button>
                                            <asp:Button ID="btnDetails" runat="server" Text="VIEW" SkinID="btn" TabIndex="7"
                                                CssClass="ButtonClass"></asp:Button>
                                            <br />
                                        </td>
                                    </tr>
                                </center>
                            </tbody>
                        </table>
                    </center>
            </a>
            <center>
                <table>
                    <tr>
                        <td colspan="2">
                            <center>
                                <div>
                                    <br />
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="msgInfo" runat="server" SkinID="lblGreen"></asp:Label>
                                </div>
                            </center>
                        </td>
                    </tr>
                </table>
            </center>
            <a name="bottom">
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TY_ID"
                            SkinID="Gridview" Visible="True" AllowPaging="True" PageSize="100" meta:resourcekey="GridView1Resource1"
                            Height="1px" Width="298px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                            TabIndex="7" Text="Edit" meta:resourcekey="EditButtonResource1"></asp:LinkButton>
                                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                            TabIndex="8" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            meta:resourcekey="DeleteButtonResource1"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave Type" meta:resourcekey="TemplateFieldResource3"
                                    SortExpression="Leave_Type">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="LID" runat="server" Value='<%#Bind("TY_ID")%>'></asp:HiddenField>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Leave_Type") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code" meta:resourcekey="TemplateFieldResource3" SortExpression="LeaveTypeCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("LeaveTypeCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave Description" meta:resourcekey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("LeaveDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paid" meta:resourcekey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("PaidStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave For" meta:resourcekey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveFor" runat="server" Text='<%# Bind("Leave_For") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890/-/@/#/$/%/^/&/*/(/)/:/;/+"
                        TargetControlID="txtLeavetype">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </a>
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
