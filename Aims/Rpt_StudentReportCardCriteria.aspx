<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_StudentReportCardCriteria.aspx.vb"
    Inherits="Rpt_StudentReportCardCriteria" Title="Student Report Card" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Report Card</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
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
        function ValidReport() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlbranch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlbranch.ClientID%>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlcourse.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlcourse.ClientID%>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlbatch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID%>").focus();
                a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = DropDown(document.getElementById("<%=ddlsem.ClientID %>"), 'Semester');
            //            if (msg != "") return msg;
            //            msg = DropDown(document.getElementById("<%=ddlstucode.ClientID %>"), 'Student Code');
            //            if (msg != "") return msg;
            return true;
        }
        function ValidateReport() {
            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;

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
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="LabelStdrc" runat="server" Text="STUDENT REPORT CARD" SkinID="lblRepRsz"
                                Width="320" Visible="True"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" Width="91px" Text="Branch*&nbsp:&nbsp&nbsp"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlbranch" runat="server" SkinID="ddlL" AutoPostBack="True"
                                            DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Width="91px" Text="Course*&nbsp:&nbsp&nbsp"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlcourse" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode"
                                            Width="200">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" Width="150px" Text="Academic Year*&nbsp:&nbsp&nbsp"
                                            SkinID="lblrsz"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlacadyear" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjYear" DataTextField="AcademicYear" DataValueField="A_Code" Width="200">
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" Width="91px" Text="Batch*&nbsp:&nbsp&nbsp"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlbatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjBatch" DataTextField="Batch_No" DataValueField="BatchID" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label7" runat="server" Width="150px" Text="Semester&nbsp:&nbsp&nbsp"
                                            SkinID="lblrsz"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlsem" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjSem" DataTextField="SemName" DataValueField="SemCode" Width="200">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblass" runat="server" Width="150px" Text="Assessment Type&nbsp:&nbsp&nbsp"
                                            SkinID="lblrsz"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <%--<asp:DropDownList ID="ddlass" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="Objass" DataTextField="AssessmentType" DataValueField="ID" Width="200">
                                        </asp:DropDownList>--%>
                                        <asp:ListBox ID="ddlass" Height="100px" Width="250px" SelectionMode="Multiple" AutoPostBack ="True"
                                    DataValueField="ID" DataTextField="AssessmentType" runat="server" DataSourceID="Objass"
                                    TabIndex="3" CssClass="Listbox"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" Width="91px" Text="Student Code&nbsp:&nbsp&nbsp"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlstucode" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjStuCode" DataTextField="StdCode" DataValueField="STD_ID" Width="200">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblReportType" runat="server" SkinID="lbl" Text="Report Type:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlReportType" runat="server" SkinID="ddlRsz" Width="200">
                                            <asp:ListItem Text="Marks" Value="Marks"></asp:ListItem>
                                            <asp:ListItem Text="Marks&nbsp;and&nbsp;Grade" Value="Marks And Grade"></asp:ListItem>
                                            <asp:ListItem Text="Grade" Value="Grade"></asp:ListItem>
                                            <asp:ListItem Text="Remarks" Value="Remarks"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" Width="200" TabIndex="10">
                                            <asp:ListItem Value="0">Student Name</asp:ListItem>
                                            <asp:ListItem Value="1">Student Code</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="4">
                                        <asp:Button ID="btnReport" runat="server" OnClientClick="return ValidateReport();"
                                            Text="REPORT" commandName="REPORT" SkinID="btn" CssClass="ButtonClass"></asp:Button>&nbsp;
                                        <asp:Button ID="btnBack" commandName="BACK" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <div>
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                            </div>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td style="height: 284px" colspan="2">
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetCourse" TypeName="StudentB">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <%-- <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetYear" TypeName="StudentB">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlcourse" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>--%>
                                        <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="BatchComboReport" TypeName="DLBatchReportCardElect">
                                            <SelectParameters>
                                                <%--<asp:ControlParameter ControlID="ddlacadyear" Name="Aid" Type="Int32" PropertyName="SelectedValue" />--%>
                                                <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlcourse" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjSem" runat="server" SelectMethod="SemesterCombo122"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjStuCode" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetStudentReportCombo1" TypeName="DLReportsR">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlbatch" Name="BatchID" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="Objass" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="getassessment1" TypeName="DLBatchReportCardElect">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

