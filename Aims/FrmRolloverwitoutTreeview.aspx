<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="FrmRolloverwitoutTreeview.aspx.vb"
    Inherits="FrmRolloverwitoutTreeview" Title="Roll Over/Student Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlFromCourse.ClientID %>"), 'From Course');
            if (msg != "") {
                document.getElementById("<%=ddlFromCourse.ClientID %>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlFromBatch.ClientID %>"), 'From Batch');
            if (msg != "") {
                document.getElementById("<%=ddlFromBatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlToCourse.ClientID %>"), 'To Course');
            if (msg != "") {
                document.getElementById("<%=ddlToCourse.ClientID %>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlToBatch.ClientID %>"), 'To Batch');
            if (msg != "") {
                document.getElementById("<%=ddlToBatch.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginf.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginf.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
       
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%-- <center>
                    <h1 class="headingTxt">
                        ROLL OVER/STUDENT TRANSFER
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:RadioButtonList ID="RbTYPE" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        SkinID="Themes1" TabIndex="1">
                                        <asp:ListItem Selected="True" Text="Roll Over"></asp:ListItem>
                                        <asp:ListItem Text="Batch Transfer"></asp:ListItem>
                                        <asp:ListItem Text="Forum Transfer"></asp:ListItem>
                                        <asp:ListItem Text="Branch Transfer"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <%--</table>
                        <table>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDate" runat="server" SkinID="lblRsz" Text="Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" AutoCompleteType="Disabled" MaxLength="20"
                                        SkinID="txt" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CE1" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtdate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" SkinID="lbl" Text=" From Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtfrmBranch" runat="server" AutoPostBack="true" DataSourceID="ObjFromBranch"
                                            SkinID="txtRsz" TabIndex="3" Width="250px"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="To Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlToBrch" runat="server" AutoPostBack="True" DataSourceID="ObjToBranch"
                                            DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="6"
                                            Width="250px">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="From Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlFromCourse" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            DataSourceID="ObjCourse2" DataTextField="CourseName" DataValueField="Courseid"
                                            SkinID="ddlRsz" Width="250 px" TabIndex="4">
                                            <%-- <asp:ListItem Value="0">Select</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="To Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlToCourse" runat="server" AutoPostBack="True" DataTextField="CourseName"
                                            DataValueField="Courseid" SkinID="ddlRsz" Width="250 px" TabIndex="7">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="From Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlFromBatch" runat="server" AutoPostBack="true" DataSourceID="ObjFromBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="5"
                                            Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="To Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlToBatch" runat="server" AutoPostBack="true" DataSourceID="ObjToBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="8"
                                            Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto" Width="250px">
                                            <asp:GridView ID="GVRollOver" runat="server" AllowPaging="true" AllowSorting="True"
                                                AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="100"
                                                SkinID="GridView">
                                                <Columns>
                                                    <asp:TemplateField SortExpression="center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                                TabIndex="5" Width="50px" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkRL" runat="server" TabIndex="6" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                            <asp:HiddenField ID="STD_ID" runat="server" Value='<%# Bind("StdId") %>' />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("STD_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Batch">
                                                        <ItemTemplate>
                                                            <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnRollOver" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="8" Text="ROLL OVER -&gt;"
                                                        Width="110px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnRollBack" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="9" Text="&lt;- ROLL BACK"
                                                        Width="110px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnStdBatchTransfer" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="8" Enabled="false"
                                                        Text="BATCH TRANSFER -&gt;" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnforum" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="7" Text="FORUM TRANSFER -&gt;"
                                                        Width="150px" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btntransfer" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="7" Text="BRANCH TRANSFER -&gt;"
                                                        Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnLock" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="10" Text="LOCK/UNLOCK"
                                                        Width="150px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="center" colspan="2">
                                        <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Auto" Width="250px">
                                            <asp:GridView ID="GVRollOver2" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                                PageSize="100" SkinID="GridView">
                                                <Columns>
                                                    <asp:TemplateField SortExpression="center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="ChkAll2" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll2"
                                                                TabIndex="8" Width="50px" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkRL2" runat="server" TabIndex="9" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="stdcode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                            <asp:HiddenField ID="STD_ID" runat="server" Value='<%# Bind("STD_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Batch">
                                                        <ItemTemplate>
                                                            <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress3">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    Processing your request..Please wait...
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <center>
                                            <asp:Label ID="msginf" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        </center>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                    <asp:ObjectDataSource ID="ODSRollOver" runat="server" DataObjectTypeName="Student"
                        SelectMethod="GetStudentsForRollOver" TypeName="StudentManager">
                        <SelectParameters>
                            <asp:SessionParameter Name="instID" SessionField="InstituteID" />
                            <asp:SessionParameter Name="branchID" SessionField="BranchID" />
                            <asp:Parameter Name="corsID" />
                            <asp:Parameter Name="batchID" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetDataCourse"
                        TypeName="CourseDB">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlToBrch" Name="BranchCode" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourse2" runat="server" SelectMethod="GetDtaCourse"
                        TypeName="CourseDB"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjToBatch" runat="server" SelectMethod="BatchAYComboD"
                        TypeName="DLRollOver">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlToCourse" DefaultValue="0" Name="Courseid" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjFromBatch" runat="server" SelectMethod="BatchAYComboD"
                        TypeName="DLRollOver">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlFromCourse" DefaultValue="0" Name="Courseid"
                                PropertyName="SelectedValue" Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjToBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetBranchTypecombo" TypeName="EmpTranferB"></asp:ObjectDataSource>
                </asp:Panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Password*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" OnTextChanged="btnPassword_Click" SkinID="txt"
                                            TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" OnClientClick="btnPassword_Click"
                                            SkinID="btn" Text="OK" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
                </br> <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
