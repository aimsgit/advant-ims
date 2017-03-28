<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBookReturn.aspx.vb"
    Inherits="BookReturnM" Title="Book Return" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Book Return</title>
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
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
    </script>

    <script type="text/javascript" language="javascript">

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtstuCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtstuCode.ClientID%>"));
        }
//        function SplitName1() {
//            var text = document.getElementById("<%=txtstuCode.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtstuCode.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtstuname.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HIDSTUCODE.ClientID%>").innerText = split[2];
//                document.getElementById("<%=txtduedate.ClientID%>").innerText = "";
//                document.getElementById("<%=txtbukname.ClientID%>").innerText = "";
//            }
//        }

        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtempcode.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtempcode.ClientID%>"));
        }
//        function SplitName2() {
//            var text = document.getElementById("<%=txtempcode.ClientID %>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtempcode.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtempName.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HIDEMPCODE.ClientID%>").innerText = split[2];
//                document.getElementById("<%=txtduedate.ClientID%>").innerText = "";
//                document.getElementById("<%=txtbukname.ClientID%>").innerText = "";
//            }
//        }

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <a name="top">
                    <div align="right">
                        <a href="#bottom">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                </a>
                <div>
                    <%--<center>
                        <h1 class="headingTxt">
                            BOOK RETURN</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <asp:HiddenField ID="HIDSTUCODE" runat="server" />
                    <asp:HiddenField ID="HIDEMPCODE" runat="server" />
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <%-- <td align="right">
                                        <asp:Label ID="Label3" runat="server" Text="Select" SkinID="lbl"></asp:Label>
                                    </td>--%>
                                    <td colspan="2" align="center">
                                        <asp:RadioButtonList ID="rdbcode" TabIndex="1" runat="server" SkinID="RD" AutoPostBack="True"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Student</asp:ListItem>
                                            <asp:ListItem Value="2">Employee</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
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
                                            AutoPostBack="True" DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="2">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="BookMasterDB" SelectMethod="GetDeptType">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblstucode" runat="server" Text="Student Code*  :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtstuCode" TabIndex="3" runat="server" SkinID="txtRsz" Width="200px"
                                            AutoPostBack="true"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                            EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                            OnClientPopulating="ShowImage1" ServiceMethod="getStudentIdName2"
                                            CompletionListCssClass="completeListStyle" ServicePath="TextBoxExt.asmx" TargetControlID="txtstuCode">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                            SkinID="watermark" TargetControlID="txtstuCode" WatermarkText="Type first 3 characters">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblstuname" runat="server" Text="Student Name  :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtstuname" Enabled="false" runat="server" SkinID="txtRsz" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblempcode" Visible="False" runat="server" Text="Employee Code*  :&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="150px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox Visible="false" ID="txtempcode" TabIndex="4" runat="server" SkinID="txtRsz"
                                            Width="200px" AutoPostBack="true">
                                        </asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="Server" CompletionInterval="2000"
                                            EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                            OnClientPopulating="ShowImage2" CompletionListCssClass="completeListStyle"
                                            ServiceMethod="getEmpCodeExt1" ServicePath="TextBoxExt.asmx" TargetControlID="txtempcode">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                            SkinID="watermark" TargetControlID="txtempcode" WatermarkText="Type first 3 characters">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblempName" Visible="False" runat="server" Text="Employee Name  :&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="150px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtempName" Visible="false" Enabled="false" runat="server" SkinID="txtRsz"
                                            Width="200px"></asp:TextBox>
                                           <%-- <asp:HiddenField ID="StdID" runat="server" Visible="False" />
                                    <asp:HiddenField ID="EmpId" runat="server" Visible="False" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblbookcode" runat="server" SkinID="lbl" Text="Book Code*  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cmbBookCode" runat="server" DataValueField="Book_IDAuto" DataTextField="BookCode"
                                            SkinID="ddlRsz" Width="204px" TabIndex="5" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblbukname" SkinID="lbl" Text="Book Name  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtbukname" SkinID="txtRsz" Width="200px" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblduedate" SkinID="lbl" Text="Due Date  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" SkinID="txt" ID="txtduedate" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblreturn" SkinID="lbl" Text="Return Date*  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" SkinID="txt" Enabled="false" ID="txtreturndate"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblTotalDays" SkinID="lbl" Text="Days  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" SkinID="txt" ID="txtDays" TabIndex="6"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtDays">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblFineday" SkinID="lbl" Text="Fine/Day  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" SkinID="txt" ID="txtFineday" TabIndex="7" AutoPostBack="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtFineday">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblfine" SkinID="lbl" Text="Total Fine  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" SkinID="txt" ID="txtfine" TabIndex="8"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtfine">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <br />
                                        <asp:Button ID="btnSave" TabIndex="9" CausesValidation="false" runat="server" Text="SUBMIT"
                                            SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                        &nbsp;<asp:Button ID="btnDetails" TabIndex="10" runat="server" Text="VIEW" CausesValidation="False"
                                            SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
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
                                <td colspan="2">
                                    <center>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed"></asp:Label>
                                        <br />
                                    </center>
                                </td>
                            </tr>
                            </tbody>
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GV_BookReturn" runat="server" SkinID="GridView" AllowPaging="True"
                                DataKeyNames="ID" AutoGenerateColumns="False" PageSize="100" AllowSorting="True"
                                EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                        <ItemTemplate>
                                            <asp:Label ID="HID" runat="server" Visible="false" Text='<%# Bind("Dept_Id") %>'></asp:Label>
                                            <asp:Label ID="lbldept" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                        <ItemTemplate>
                                            <asp:Label ID="HID" runat="server" Visible="false" Text='<%# Bind("ID") %>'></asp:Label>
                                            <asp:Label ID="lblStucode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStuname" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpcode" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpname" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Code" SortExpression="BookCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbukcode" runat="server" Text='<%# Bind("BookCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Name" SortExpression="BookName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbukname" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Due Date" SortExpression="ReturnDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblduedate" runat="server" Text='<%# Bind("ReturnDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Return Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreturndate" runat="server" Text='<%# Bind("ActualReturnDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <%--  <asp:TemplateField HeaderText="Fine">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfine" runat="server" Text='<%# Bind("Fine") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
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
    </center>

</form>
</body>
</html>
