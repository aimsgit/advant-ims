<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="frmLeaveApplicationwitoutTreeview.aspx.vb"
    Inherits="frmLeaveApplicationwitoutTreeview" Title="Leave Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlleavetype.ClientID %>"), 'Leave Type');
            document.getElementById("<%=ddlleavetype.ClientID %>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtleavefrom.ClientID %>"), 'Leave From');
            //            document.getElementById("<%=txtleavefrom.ClientID %>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtleaveto.ClientID %>"), 'Leave To');
            //            document.getElementById("<%=txtleaveto.ClientID %>").focus();
            if (msg != "") return msg;
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }

                return true;
            }
        }
      
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--   <center>
                    <h1 class="headingTxt">
                        LEAVE APPLICATION
                    </h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Application date :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtApplicationDate" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="Employee Code :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtEmpCode" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Employee Name :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtEmpName" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" SkinID="lblRsz" Text="Leave Type* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlleavetype" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataSourceID="odsleave" DataTextField="Leave_Type" DataValueField="TypeID" AppendDataBoundItems="true">
                                        <%-- <asp:ListItem Value="0" Text="Select"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsleave" runat="server" TypeName="LeaveDB" SelectMethod="GetLeaveType">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Total/Balance Leave :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtbalnceLeave" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Leave From* :&nbsp;&nbsp;"
                                        TabIndex="-1" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtleavefrom" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtleavefrom"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                &nbsp;&nbsp;
                                <td>
                                    <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        TabIndex="1">
                                        <asp:ListItem Value="1" Selected="True">Fore Noon</asp:ListItem>
                                        <asp:ListItem Value="2">After Noon</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Leave To* :&nbsp;&nbsp;"
                                        TabIndex="-1" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtleaveto" runat="server" SkinID="txt" TabIndex="4" AutoPostBack="True"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtleaveto"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                &nbsp;&nbsp;
                                <td>
                                    <asp:RadioButtonList ID="RBReport1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        TabIndex="1">
                                        <asp:ListItem Value="1">Fore Noon</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">After Noon</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="No Of Days Applied :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtNoofdaysappl" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Reason For Leave :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Txtreason" runat="server" SkinID="txt" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmpId" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btnsave" runat="server" Text="ADD" SkinID="btnRsz" OnClientClick="return Validate();"
                                        CssClass="ButtonClass" TabIndex="6" />
                                    &nbsp;<asp:Button ID="btnDetail" runat="server" Text="VIEW" SkinID="btnRsz" CssClass="ButtonClass"
                                        TabIndex="7" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
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
                                <td>
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
            </a></center>
            <div>
                <a name="bottom">
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="Gvleaveapp" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="LR_ID" SkinID="GridView" PageSize="100" EnableSortingAndPagingCallbacks="True"
                                AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Application Date" SortExpression="DateEntry">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateEntry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type" SortExpression="Leave_Type">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Visible="false" Text='<%# Bind("LeaveTypes") %>'></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Leave_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("LeaveFrom","{0:dd-MMM-yyyy}") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("LeaveTo","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Days Applied" SortExpression="DaysApplied">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("DaysApplied") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reason for Leave" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Width="200px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Applicant Remarks" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Width="200px" Text='<%# Bind("feedback") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approval Status" SortExpression="AppStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAppStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approver Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAppRemarks" runat="server" Text='<%# Bind("Approver_Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                    <div align="right">
                </a><a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
