<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmParentManagement.aspx.vb"
    Inherits="frmParentManagement" Title="Parent Management" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Parent Management</title>
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
            msg = Field255(document.getElementById("ctl00_ContentPlaceHolder1_txtstd"), 'Student Code')
            if (msg != "") {
                return msg;
            }
            msg = Field250(document.getElementById("<%=txtstd.ClientID %>"), 'Student Code')
            if (msg != "") {
                document.getElementById("<%=txtstd.ClientID %>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtstdName.ClientID %>"), 1, 'Student Code')
            if (msg != "") {
                document.getElementById("<%=txtstd.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtstdName.ClientID %>"), 1, 'Student Code')
            if (msg != "") {
                document.getElementById("<%=txtstd.ClientID %>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtbatch.ClientID %>"), 'Student Batch')
            if (msg != "") {
                document.getElementById("<%=txtbatch.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtbatch.ClientID %>"), 'Student Batch')
            if (msg != "") {
                document.getElementById("<%=txtbatch.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate1() {
            var msg1 = Valid1();
            if (msg1 != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg1;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
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
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtstd.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtstd.ClientID%>"));
        }
//        function SplitName() {
//            var text = document.getElementById("<%=txtstd.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtstd.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtstdName.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
//                document.getElementById("<%=HidBatch.ClientID%>").innerText = split[3];
//                document.getElementById("<%=txtBatch.ClientID%>").innerText = split[4];
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
                    <%--<center>
                        <h1 class="headingTxt">
                            PARENT/STUDENT MANAGEMENT FORM</h1>
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
                                        <asp:HiddenField ID="HidstdId" runat="server" />
                                        <asp:HiddenField ID="HidBatch" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #9EBA9F; width: 328px; height: 21px;" align="right">
                                        <asp:Label ID="lblstdcode" runat="server" SkinID="lblRsz" Text="Enter Student Code&nbsp;:&nbsp;&nbsp;"
                                            Width="200px"></asp:Label>
                                    </td>
                                    <td style="background-color: #9EBA9F; width: 400px; height: 21px;">
                                        <asp:TextBox ID="txtsrchstd" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td style="background-color: #9EBA9F; width: 400px;" rowspan="2">
                                        <asp:Button ID="Btnsearch" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="2" Text="SEARCH" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #9EBA9F; width: 328px; height: 21px;" align="right">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Search User Name&amp;nbsp;:&amp;nbsp;&amp;nbsp;"></asp:Label>
                                    </td>
                                    <td style="background-color: #9EBA9F; width: 400px; height: 21px;">
                                        <asp:TextBox ID="txtsrchuser" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="Label2" runat="server" Text="User Name Prefix*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz" Width="226px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPrefix" runat="server" SkinID="txt" TabIndex="4" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lbluserid" runat="server" Text="User Name*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtuserid" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblpassword" runat="server" Text="Password*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpassword" runat="server" SkinID="txt" TextMode="Password" TabIndex="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblverpass" runat="server" Text="Verify Password*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtverpass" runat="server" SkinID="txt" TextMode="Password" TabIndex="7"
                                            MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblverpass0" runat="server" SkinID="lblRsz" Text="Password Expiry*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExpDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtExpDate_CalendarExtender" runat="server" TargetControlID="txtExpDate"
                                            Format="dd-MMM-yyyy" Animated="False">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblstd" runat="server" Text="Student Code* :&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtstd" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtstd"
                                            ServicePath="TextBoxExt.asmx" ServiceMethod="getStudentNameBatchByCode" OnClientPopulating="ShowImage"
                                            OnClientPopulated="HideImage" MinimumPrefixLength="3" CompletionInterval="2000"
                                            CompletionListCssClass="completeListStyle" FirstRowSelected="true"
                                            EnableCaching="true">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Type first 3 characters"
                                            runat="server" TargetControlID="txtstd" SkinID="watermark">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="Label3" runat="server" Text="Student Name* :&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtstdName" runat="server" Enabled="false" SkinID="txt" TabIndex="10"></asp:TextBox>
                                        <%--<asp:TextBox ID="txtEmpName" ReadOnly="true" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblbranch" runat="server" Text="Student Batch*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz" Width="220px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbatch" Enabled="false" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 328px" align="right">
                                        <asp:Label ID="lblLoginType" runat="server" Text="Login Type*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"
                                            SkinID="lblRsz" Width="220px"></asp:Label>
                                    </td>
                                    <td>
                                        <%--
                                        <asp:TextBox ID="txtLoginType" Enabled="false" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>--%><asp:DropDownList
                                            ID="ddlLoginType" runat="server" SkinID="ddl" TabIndex="12">
                                            <asp:ListItem Selected="True" Text="Parent" Value="Parent"></asp:ListItem>
                                            <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Privileges*&amp;nbsp;:&amp;nbsp;&amp;nbsp;"></asp:Label>
                                    </td>
                                    <td rowspan="3" align="left">
                                        <asp:CheckBox ID="Chkread" runat="server" Text="Read" TabIndex="13" />
                                        <br />
                                        <asp:CheckBox ID="Chkwrite" runat="server" Text="Write" TabIndex="14" />
                                        <br />
                                        <asp:CheckBox ID="Chkprint" runat="server" Text="Print" TabIndex="15" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddGrid" runat="server" CausesValidation="True" SkinID="btn" Text="ADD"
                                            ToolTip="Add" OnClientClick="return Validate();" CssClass="ButtonClass" TabIndex="16" />
                                        <asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass "
                                            SkinID="btn" TabIndex="17" Text="VIEW" ToolTip="VIEW" />
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
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="760px" Height="300px">
                        <asp:GridView ID="GVParentMngmnt" runat="server" SkinID="GridView" Visible="true"
                            AllowPaging="true" AutoGenerateColumns="False" PageSize="100" EnableSortingAndPagingCallbacks="True"
                            AllowSorting="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" TabIndex="18"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            TabIndex="19" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Code" SortExpression="StudentCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Visible="false" runat="server" Text='<%# Bind("LoginType") %>' />
                                        <asp:Label ID="HidUDID" Visible="false" runat="server" Text='<%# Bind("UserDetailsID") %>' />
                                        <asp:Label ID="lblstdNo" runat="server" Text='<%#Bind("StudentCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstdName" runat="server" Text='<%#Bind("StdName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassword" Visible="false" runat="server" Text='<%# Bind("Password") %>' />
                                        <asp:Label ID="lblusrName" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch Name" SortExpression="Batch_No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBatchName" runat="server" Text='<%#Bind("Batch_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expiry Date" SortExpression="ExpDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpDate" runat="server" Text='<%#Bind("ExpDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Privileges">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrivilages" runat="server" Text='<%#Bind("Privilages") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Login Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLoginType" runat="server" Text='<%#Bind("LoginType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%#Bind("BranchName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                            </Columns>
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
