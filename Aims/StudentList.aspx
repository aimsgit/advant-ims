<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentList.aspx.vb"
    Inherits="StudentList" Title="Student Details Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Details Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
        function Valid() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=txtBranchName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtBranchName.ClientID%>").focus();
                a = document.getElementById("<%=lblBranchType.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }


    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                <br>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Labelsr" runat="server" Text="STUDENT REGISTER" SkinID="lblRepRsz"
                                Width="290" Visible="True"></asp:Label></h1>
                        </h1>
                        <br>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        TabIndex="1">
                                        <asp:ListItem Value="1" Selected="True">Summary Report</asp:ListItem>
                                        <asp:ListItem Value="2">Detailed Report</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranchType" runat="server" Text="Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="txtBranchName" TabIndex="2" runat="server" SkinID="ddlL" AutoPostBack="True"
                                        DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                          <%--  <tr>
                                <td align="right">
                                    <asp:Label ID="lblYear" runat="server" Text="Academic Calender Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="txtYearName" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataSourceID="ObjYear" DataTextField="AcademicYear" DataValueField="A_Code" Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" Text="Course&nbsp;:&nbsp;&nbsp;" Width="100px"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="txtCourseName" TabIndex="4" runat="server" SkinID="ddlRsz"
                                        AutoPostBack="True" DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode"
                                        Width="250">
                                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="txtBatchName" TabIndex="5" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataSourceID="ObjBatch" DataTextField="Batch_No" DataValueField="BatchID" Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="6" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetSemester" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="txtBatchName" Name="BatchID" Type="Int32" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Lbldobdoj" runat="server" Text="DOJ/DOL&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbdojdob" runat="server" SkinID="ddl" TabIndex="7" AutoPostBack="true">
                                        <asp:ListItem Value="0">ALL</asp:ListItem>
                                        <asp:ListItem Value="1">DOJ</asp:ListItem>
                                        <asp:ListItem Value="2">DOL</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFromDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="7" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="To Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="8" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSort" runat="server" Text="Sort&nbsp;:&nbsp;&nbsp;" SkinID="lbl" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="9">
                                        <asp:ListItem Value="0">Student Name</asp:ListItem>
                                        <asp:ListItem Value="1">Student Code</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" runat="server" TabIndex="10" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="11" Text="BACK" CommandName="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBranch" TypeName="BLBranchAccessLevel"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertCourse" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetYear1" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport"
                                        TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                            <%--<asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                                Type="Int16" />--%>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                            </tr>
                        </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
