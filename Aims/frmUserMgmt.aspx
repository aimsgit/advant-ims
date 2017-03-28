<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmUserMgmt.aspx.vb"
    Inherits="frmUserMgmt" Title="User Management" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Management</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtuserid.ClientID %>"), 'User Name')
            if (msg != "") {
                document.getElementById("<%=txtuserid.ClientID %>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtpassword.ClientID %>"), 6, 'Password')
            if (msg != "") {
                document.getElementById("<%=txtpassword.ClientID %>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtverpass.ClientID %>"), 6, 'Verify Password')
            if (msg != "") {
                document.getElementById("<%=txtverpass.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtExpDate.ClientID%>"), 'Password Expiry');
            if (msg != "") {
                document.getElementById("<%=txtExpDate.ClientID%>").focus();
                return msg;
            }
            msg = Field255(document.getElementById("ctl00_ContentPlaceHolder1_txtemp"), 'Employee Code')
            if (msg != "") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtemp").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtemp.ClientID %>"), 'Employee Code')
            if (msg != "") {
                document.getElementById("<%=txtemp.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtbranch.ClientID %>"), 'Employee branch office')
            if (msg != "") {
                document.getElementById("<%=txtbranch.ClientID %>").focus();
                return msg;
            }
            msg = Field250(document.getElementById("<%=txtbranch.ClientID %>"), 'Employee branch office')
            if (msg != "") {
                document.getElementById("<%=txtbranch.ClientID %>").focus();
                return msg;
            }
            msg = Field255(document.getElementById("<%=txtbranch.ClientID %>"), 'Employee branch office')
            if (msg != "") {
                document.getElementById("<%=txtbranch.ClientID %>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlAccessLevel.ClientID %>"), 'Access Level');
            if (msg = "") {
                document.getElementById("<%=ddlAccessLevel.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=ddlAccessLevel.ClientID %>"), 'Access Level');
            if (msg = "") {
                document.getElementById("<%=ddlAccessLevel.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Valid1() {
            var msg1;
            msg1 = DropDown(document.getElementById("<%=ddlRoles.ClientID %>"), 'Roles');
            if (msg1 = "") {
                document.getElementById("<%=ddlRoles.ClientID %>").focus();
                return msg1;
            }
            msg1 = NameField100(document.getElementById("<%=ddlRoles.ClientID %>"), 'Roles');
            if (msg1 = "") {
                document.getElementById("<%=ddlRoles.ClientID %>").focus();
                return msg1;
            }
            return true;
        }
        function Validate1() {
            var msg1 = Valid1();
            if (msg1 != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg1;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg1;
                    return false;
                }
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtemp.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtemp.ClientID%>"));
        }
//        function SplitName() {
//            var text = document.getElementById("<%=txtemp.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=HidempId.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtemp.ClientID%>").innerText = split[1];
//                document.getElementById("<%=txtEmpName.ClientID%>").innerText = split[2];
//                document.getElementById("<%=txtbranch.ClientID%>").innerText = split[3];
//                document.getElementById("<%=HidBanch.ClientID%>").innerText = split[4];
//                document.getElementById("<%=ddlAccessLevel.ClientID %>").focus();
//            }
//        }
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
                            USER MANAGEMENT FORM</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <asp:Panel ID="addpanel" runat="server">
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td style="width: 328px">
                                        <asp:HiddenField ID="HidempId" runat="server" />
                                        <asp:HiddenField ID="HidBanch" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #9EBA9F; width: 328px; height: 21px;" align="right">
                                        <asp:Label ID="lblempcode" runat="server" SkinID="lblRsz" Text="Enter Employee Code*&nbsp;:&nbsp;&nbsp;"
                                            Width="200px"></asp:Label>
                                    </td>
                                    <td style="background-color: #9EBA9F; width: 400px; height: 21px;">
                                        <asp:TextBox ID="txtsrchemp" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td style="background-color: #9EBA9F; width: 400px;" rowspan="2">
                                        <asp:Button ID="Btnsearch" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="3" Text="SEARCH" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #9EBA9F; width: 328px; height: 21px;" align="right">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Search User Name&amp;nbsp;:&amp;nbsp;&amp;nbsp;"></asp:Label>
                                    </td>
                                    <td style="background-color: #9EBA9F; width: 400px; height: 21px;">
                                        <asp:TextBox ID="txtsrchuser" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="Label2" runat="server" Text="User Name Prefix*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz" Width="226px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPrefix" runat="server" SkinID="txt" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lbluserid" runat="server" Text="User Name*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtuserid" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblpassword" runat="server" Text="Password*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpassword" runat="server" SkinID="txt" TextMode="Password" TabIndex="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblverpass" runat="server" Text="Verify Password*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtverpass" runat="server" SkinID="txt" TextMode="Password" TabIndex="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblverpass0" runat="server" SkinID="lblRsz" Text="Password Expiry*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExpDate" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtExpDate_CalendarExtender" runat="server" TargetControlID="txtExpDate"
                                            Format="dd-MMM-yyyy" Animated="False">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblemp" runat="server" Text="Employee Code* :&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtemp" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtemp"
                                            ServicePath="TextBoxExt.asmx" ServiceMethod="GetBranchName" OnClientPopulating="ShowImage"
                                            OnClientPopulated="HideImage" MinimumPrefixLength="3" CompletionInterval="2000"
                                            CompletionListCssClass="completeListStyle" FirstRowSelected="true"
                                            EnableCaching="true">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Type first few characters"
                                            runat="server" TargetControlID="txtemp" SkinID="watermark">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="Label3" runat="server" Text="Employee Name* :&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmpName" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                        <%--<asp:TextBox ID="txtEmpName" ReadOnly="true" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblbranch" runat="server" Text="Employee's Branch Office*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz" Width="220px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbranch" runat="server" SkinID="txtRsz" Width="250"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <table class="custTable" style="background-color: White">
                                <tr>
                                    <td style="background-color: #9EBA9F; height: 27px; font-weight: bold">
                                        <center>
                                            <asp:Label ID="lblaccess" runat="server" SkinID="lbl" Text="ACCESS LEVEL"></asp:Label>
                                        </center>
                                    </td>
                                    <td style="background-color: #9EBA9F; height: 27px; font-weight: bold">
                                        <center>
                                            <asp:Label ID="lblroles" runat="server" SkinID="lbl" Text="ROLES"></asp:Label>
                                        </center>
                                    </td>
                                    <td style="background-color: #9EBA9F; height: 27px; font-weight: bold">
                                        <center>
                                            <asp:Label ID="lblprivilages" runat="server" SkinID="lbl" Text="PRIVILEGES"></asp:Label>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlAccessLevel" runat="server" DataSourceID="ObjectDataSource1"
                                            AppendDataBoundItems="true" DataTextField="AccessLevel" DataValueField="AccessCode"
                                            SkinID="ddl" TabIndex="9">
                                            <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetAccessTypesDDL" TypeName="BLUserManagement"></asp:ObjectDataSource>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="ObjectDataSource2" AppendDataBoundItems="true"
                                            DataTextField="UserRole" DataValueField="RoleCode" SkinID="ddl" TabIndex="10">
                                            <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetRolesDDL" TypeName="BLUserManagement">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="U" SessionField="BranchID" Type="Object" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:CheckBox ID="Chkread" runat="server" Text="Read" TabIndex="11" />
                                        <br />
                                        &nbsp;&nbsp;<asp:CheckBox ID="Chkwrite" runat="server" Text="Write" TabIndex="12" />
                                        <br />
                                        &nbsp;
                                        <asp:CheckBox ID="Chkprint" runat="server" Text="Print" TabIndex="13" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <center>
                                            <asp:Button ID="BtnaddRoles" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btnRsz" Text="ADD" ToolTip="Add Access level &amp; role" Width="48px"
                                                OnClientClick="return Validate1();" TabIndex="14" />
                                            <asp:Button ID="BtnRemove" runat="server" CausesValidation="False" CssClass="ButtonClass "
                                                SkinID="btnRsz" Text="REMOVE" ToolTip="Remove Access Level &amp; Role" Width="73px" />
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="RoleAddIndex" runat="server" Height="16px" SelectionMode="Multiple" CssClass="Listbox" Visible="False" Width="16px">
                                        </asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="LBRoles" runat="server" Width="158px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddGrid" runat="server" CausesValidation="True" SkinID="btn" Text="ADD"
                                            ToolTip="Add" OnClientClick="return Validate();" CssClass="ButtonClass" TabIndex="15" />
                                        <asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass "
                                            SkinID="btn" TabIndex="16" Text="VIEW" ToolTip="VIEW" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--<asp:LinkButton ID="lkbtn_clrsession" runat="server" CausesValidation="False" 
                                        Font-Bold="True" Font-Underline="True" ForeColor="#30502E" Visible="false">Clear Session</asp:LinkButton>--%>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </asp:Panel>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="clearpanel" runat="server" Visible="false">
                                        <table>
                                            <tr>
                                                <td>
                                                    <td style="background-color: #9EBA9F; width: 328px; height: 21px;">
                                                        <asp:Label ID="lblclear" runat="server" SkinID="lbl" Text="User Name"></asp:Label>
                                                    </td>
                                                    <td style="background-color: #9EBA9F; width: 400px; height: 21px;">
                                                        <asp:TextBox ID="txtclear" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                                    </td>
                                                    <td style="background-color: #9EBA9F; width: 400px; height: 21px;">
                                                        <asp:Button ID="btnclear" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                            SkinID="btn" Text="CLEAR" TabIndex="17" />
                                                        <asp:Button ID="btnback" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                            SkinID="btn" TabIndex="17" Text="BACK" />
                                                    </td>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
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
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
                <style type="text/css">
                    .completeListStyle
                    {
                        height: 100px;
                        width: 50px;
                        overflow: auto;
                        list-style-type: disc;
                        padding-left: 17px;
                        background-color: #FFF;
                        border: 1px solid DarkGray;
                        text-align: left;
                        font-size: small;
                        color: black;
                    }
                </style>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" Visible="true" runat="server" SkinID="lblRsz" Width="720px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GVUserMngmnt" runat="server" SkinID="GridView" Visible="true" AllowPaging="true"
                            PagerStyle-CssClass="TableClass" AutoGenerateColumns="False" AllowSorting="true"
                            OnSortCommand="" PageSize="100" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"  Visible="False"  CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User ID" SortExpression="UserName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
                                        <asp:Label ID="HidUDID" Visible="false" runat="server" Text='<%# Bind("UserDetailsID") %>' />
                                        <asp:Label ID="lblPassword" Visible="false" runat="server" Text='<%# Bind("Password") %>' />
                                        <asp:Label ID="lblCode" Visible="false" runat="server" Text='<%# Bind("BranchCode") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Code" SortExpression="EmployeeNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpNo" runat="server" Text='<%#Bind("EmployeeNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmp_Name" runat="server" Text='<%#Bind("EmployeeName") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchCode" runat="server" Text='<%#Bind("BranchTypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%#Bind("Branch") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Access level">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAL" runat="server" Text='<%#Bind("AccessLevel") %>'></asp:Label>
                                        <asp:Label ID="lblALcode" runat="server" Text='<%#Bind("AccessCode") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roles">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoles" Width="100px" Visible="false" runat="server" Text='<%#Bind("Roles") %>'></asp:Label>
                                        <asp:Label ID="lblRolesName" Width="150px" runat="server" Text='<%#Bind("RolesName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Privileges">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrivilages" runat="server" Text='<%#Bind("Privilages") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expiry Date" SortExpression="ExpDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpDate" runat="server" Width="140px" Text='<%#Bind("ExpDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="TableClass"></PagerStyle>
                        </asp:GridView>
                    </asp:Panel>
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

</form>
</body>
</html>
