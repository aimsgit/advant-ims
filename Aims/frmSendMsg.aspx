<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSendMsg.aspx.vb"
    Inherits="frmSendMsg" Title="Approve Message" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Approve Message</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtFromDate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                return msg;
            }
            msg = CompareDate(document.getElementById("<%=txtFromDate.ClientID%>"), document.getElementById("<%=txtToDate.ClientID%>"), 'From Date', 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel runat="server" ID="uppanel">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
            <%--     <center>
                <h1 class="headingTxt">
                    SEND MESSAGE APPROVAL
                </h1>
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
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFromDate" TabIndex="6" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                FilterMode="InvalidChars" FilterType="Custom" InvalidChars="'\:;.<>?+=_)(*&^%$#@!~`"
                                TargetControlID="txtFromDate">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtToDate" TabIndex="6" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" FilterType="Custom" InvalidChars="'\:;.<>?+=_)(*&^%$#@!~`"
                                TargetControlID="txtToDate">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Status&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:DropDownList ID="cmbstatus" runat="server" SkinID="ddl" AutoPostBack="True"
                                DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="1">
                                <asp:ListItem Value="All"> All</asp:ListItem>
                                <asp:ListItem Value="A">Approved</asp:ListItem>
                                <asp:ListItem Value="N">Not Approved</asp:ListItem>
                                <asp:ListItem Value="R">Rejected</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btnShow" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                SkinID="btnRsz" Width="150px" OnClientClick="return Validate();" TabIndex="9"
                                Text="SHOW MESSAGES" />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="GVPanel" runat="server">
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
                        </table>
                        <center >
                        <table >
                        <tr>
                            <td>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                        </table>
                          </center>
                          <table >
                        <tr>
                            <td align="left">
                                <asp:Button ID="Btndelete" Visible="false" runat="server" CausesValidation="True"
                                    CssClass="ButtonClass" SkinID="btn" TabIndex="9" Text="DELETE" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="400px">
                                    <asp:GridView ID="GVSendMsg" runat="server" DataKeyNames="CMID" AllowPaging="True"
                                        AutoGenerateColumns="False" EmptyDataText="There are no records to display."
                                        SkinID="GridView" Style="margin-bottom: 0px" Width="650px" PageSize="100" AllowSorting="True"
                                        EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField SortExpression="center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="ChkAll" TabIndex="7" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                        Width="50px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkRL" TabIndex="8" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Wrap="false" ShowHeader="False" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkApprove" runat="server" TabIndex="2" CausesValidation="False"
                                                        CommandName="Edit" Font-Underline="true" Text="<u>Edit</u>"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkEdit" runat="server" TabIndex="3" CausesValidation="False"
                                                        CommandName="Select" Font-Underline="true" Text="<u>Approve</u>"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkReject" runat="server" TabIndex="4" CausesValidation="False"
                                                        CommandName="Delete" Font-Underline="True" Text="<u>Reject</u>"></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LinkUpdate" runat="server" TabIndex="5" CausesValidation="False"
                                                        CommandName="Update" Font-Underline="true" Text="<u>Update</u>"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkCancel" runat="server" TabIndex="6" CausesValidation="False"
                                                        CommandName="Cancel" Font-Underline="true" Text="<u>Cancel</u>"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Wrap="false" HeaderText="Date" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Date">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("CMIDAuto") %>' />
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    <asp:HiddenField ID="hidCMID" runat="server" Value='<%# Bind("CMID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Message" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("Message") %>' Width="200px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <FTB:FreeTextBox ID="txtMsg" runat="server" AllowHtmlMode="True" BreakMode="LineBreak"
                                                        ButtonSet="Office2003" EnableHtmlMode="false" HtmlModeDefaultsToMonoSpaceFont="True"
                                                        Text='<%# Bind("Message") %>' ShowTagPath="False" Width="400px" EditorBorderColorDark="Black"
                                                        EditorBorderColorLight="Wheat">
                                                    </FTB:FreeTextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approval Status" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Message From" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMsgFrm" runat="server" Text='<%# Bind("MsgFrom") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Communication Mode" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommMode" runat="server" Text='<%# Bind("CommunicationMode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GroupType" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="150px"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGroupType" runat="server" Text='<%# Bind("GroupType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="150px"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="250px"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="250px"
                                                ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Route No" ControlStyle-Width="250px" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRouteName" runat="server" Text='<%# Bind("RouteName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Left"
                                                ControlStyle-Width="250px" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' TextMode="MultiLine"
                                                        Width="150px"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html
