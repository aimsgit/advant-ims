<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBookIssue.aspx.vb"
    Inherits="frmBookIssue" Title="Book Issued Details" %>

<%--
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Book Issued Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBranchType.ClientID %>"), 'Branch Name');
            if (msg != "") {
                document.getElementById("<%=ddlBranchType.ClientID %>").focus(); 
            return msg; }
            
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
            if (msg != "") {
                document.getElementById("<%=txtStdCode.ClientID %>").focus();
                return msg;
            }
            msg = NameField100N(document.getElementById("<%=txtStdName.ClientID %>"), 'Student Name');
            if (msg != "") {
                document.getElementById("<%=txtStdName.ClientID %>").focus();
                return msg;
            }
            //            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtEmpCode.ClientID %>"), 'Employee Code');
            //            if (msg != "") {
            //                document.getElementById("<%=txtEmpCode.ClientID %>").focus();
            //                return msg;
            //            }
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtBookCode.ClientId %>"), 'Book Code');
            if (msg != "") {
                document.getElementById("<%=txtBookCode.ClientId %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtIssueDate.ClientID %>"), 'Issue Date');
            if (msg != "") {
                document.getElementById("<%=txtIssueDate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtDueDate.ClientID %>"), 'Due Date');
            if (msg != "") {
                document.getElementById("<%=txtDueDate.ClientID %>").focus();
                return msg;
            }
            msg = CompareDate(document.getElementById("<%=txtDueDate.ClientID %>"), document.getElementById("<%=txtIssueDate.ClientID %>"), 'Due Date', 'Issue Date');
            if (msg != "") {
                document.getElementById("<%=txtDueDate.ClientID %>"), document.getElementById("<%=txtIssueDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
       
    </script>

    <script type="text/javascript" language="javascript">

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
        }
        //        function SplitName1() {
        //            var text = document.getElementById("<%=txtStdCode.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtStdCode.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtStdName.ClientID%>").innerText = split[1];
        //                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
        //            }
        //        }

        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtEmpCode.ClientID%>"));
        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtEmpCode.ClientID%>"));
        }
        //        function SplitName2() {
        //            var text = document.getElementById("<%=txtEmpCode.ClientID %>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtEmpCode.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtEmpName.ClientID%>").innerText = split[1];
        //                document.getElementById("<%=HidEmp.ClientID%>").innerText = split[2];
        //            }
        //        }
        function ShowImage3() {
            GlbShowSImage(document.getElementById("<%=txtBookCode.ClientID%>"));

        }
        function HideImage3() {
            GlbHideSImage(document.getElementById("<%=txtBookCode.ClientID%>"));
        }
        //        {
        //            function SplitName3() {
        //                var text = document.getElementById("<%=txtBookCode.ClientID%>").value;
        //                var split = text.split(':');
        //                if (split.length > 0) {
        //                    document.getElementById("<%=txtBookCode.ClientID%>").innerText = split[0];
        //                    document.getElementById("<%=txtBookName.ClientID%>").innerText = split[1];
        //                    document.getElementById("<%=HidBook.ClientID%>").innerText = split[2];
        //                }
        //            }
        //        }
   
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>--%>
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                   <center>
                    <h1 class="headingTxt">
                        BOOK ISSUE DETAILS
                    </h1>
                </center>
                    <%--<center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>--%>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <%-- <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Book Issued To:" SkinID="lbl"></asp:Label>
                            </td>--%>
                                <td colspan="2" align="center">
                                    <asp:RadioButtonList ID="RBUsers" runat="server" SkinID="RD" AutoPostBack="True"
                                        RepeatDirection="Horizontal" TabIndex="1">
                                        <asp:ListItem Value="Student" Selected="True">Student</asp:ListItem>
                                        <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranchType" runat="server" Text="Branch Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranchType" TabIndex="2" runat="server" SkinID="ddlRsz"
                                        AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertBranchCombo" TypeName="DLIssueLibrary"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                        AutoPostBack="true" DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="3">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="BookMasterDB" SelectMethod="GetDeptType">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpCode" runat="server" SkinID="lblRsz" Text="Employee Code* :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpCode" runat="server" TabIndex="4" SkinID="txtRsz" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                        OnClientPopulating="ShowImage2" ServiceMethod="getEmpCodeExt1" CompletionListCssClass="completeListStyle"
                                        ServicePath="TextBoxExt.asmx" TargetControlID="txtEmpCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                        SkinID="watermark" TargetControlID="txtEmpCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" Text="Employee Name :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtRsz" Width="200px" Enabled="False"></asp:TextBox>
                                    <asp:HiddenField ID="StdID" runat="server" Visible="False" />
                                    <asp:HiddenField ID="EmpId" runat="server" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStdCode" runat="server" SkinID="lblRsz" Text="Student Code* :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStdCode" runat="server" TabIndex="5" SkinID="txtRsz" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                        OnClientPopulating="ShowImage1" ServiceMethod="getStudentIdName1" CompletionListCssClass="completeListStyle"
                                        ServicePath="TextBoxExt.asmx" TargetControlID="txtStdCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                        SkinID="watermark" TargetControlID="txtStdCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStdName" runat="server" SkinID="lblRsz" Text="Student Name :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStdName" runat="server" Enabled="false" SkinID="txtRsz" Width="200px"
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBook" runat="server" SkinID="lblRsz" Text="Book Code* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBookCode" runat="server" AutoPostBack="true" SkinID="txtRsz"
                                        Width="200px" TabIndex="6"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage3"
                                        OnClientPopulating="ShowImage3" ServiceMethod="getBookNameExtN" CompletionListCssClass="completeListStyle"
                                        ServicePath="TextBoxExt.asmx" TargetControlID="txtBookCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                        SkinID="watermark" TargetControlID="txtBookCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBookName" runat="server" SkinID="lblRsz" Text="Book Name :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBookName" runat="server" SkinID="txtRsz" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblIssue" runat="server" SkinID="lblRsz" Text="Issue Date* :&nbsp;&nbsp;"
                                        Width="113px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIssueDate" runat="server" CssClass=" " SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblReturn" runat="server" SkinID="lblRsz" Text="Due Date* :&nbsp;&nbsp;"
                                        Width="114px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDueDate" runat="server" CssClass=" " SkinID="txt" TabIndex="7"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2" align="center">
                                    <asp:Button ID="btnSave" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="btn" TabIndex="8" Text="ADD" />
                                    &nbsp;
                                    <asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="btn" TabIndex="9" Text="VIEW" />
                                    <ajaxToolkit:MaskedEditExtender ID="meeDOB" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="txtIssueDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="meeDOJ" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="txtDueDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtIssueDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtDueDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
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
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmp" runat="server" />
                                    <asp:HiddenField ID="HidBook" runat="server" />
                                    <asp:HiddenField ID="HidstdId" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </center>
            </a>
            <center>
                <table>
                    <tr>
                        <td align="center">
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GVBookIssue" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                    SkinID="Gridview" Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True"
                                    EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" TabIndex="10"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="deptH" runat="server" Value='<%#Bind("Dept_Id") %>' />
                                                <asp:Label ID="lblDeptid" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Std Code" SortExpression="StdCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Bind("ID")%>'></asp:Label>
                                                <asp:HiddenField ID="StdHidden" runat="server" Value='<%#Bind("STD_ID") %>' />
                                                <asp:Label ID="lblStuCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Std Name" SortExpression="StdName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStuName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp Code" SortExpression="Emp_Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIDEmp" runat="server" Visible="false" Text='<%# Bind("ID")%>'></asp:Label>
                                                <asp:HiddenField ID="EmpIdHidden" runat="server" Value='<%#Bind("EmpID") %>' />
                                                <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp Name" SortExpression="Emp_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Book Code" InsertVisible="False" SortExpression="BookCode">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="BID" runat="server" Value='<%# Bind("Book_IDAuto") %>' />
                                                <asp:Label ID="lblBookCode" runat="server" Text='<%# Bind("BookCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Book Name" SortExpression="BookName">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="BID1" runat="server" Value='<%# Bind("Book_IDAuto") %>' />
                                                <asp:Label ID="lblBookName" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Issue Date" SortExpression="IssueDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssueDate" runat="server" Text='<%# Bind("IssueDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Due Date" SortExpression="ReturnDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReturnDate" runat="server" Text='<%# Bind("ReturnDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle HorizontalAlign ="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
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
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
