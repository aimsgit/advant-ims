<%@ Page Title="Student Progress Report" Language="VB"
    AutoEventWireup="false" CodeFile="RptStudentProgress.aspx.vb" Inherits="RptStudentProgress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Progress Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
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
                msg = DropDownForZeroMul(document.getElementById("<%=ddlbatch.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=ddlbatch.ClientID %>").focus();
                    a = document.getElementById("<%=lblbatch.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
                msg = DropDownForZeroMul(document.getElementById("<%=ddlSemester.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=ddlSemester.ClientID %>").focus();
                    a = document.getElementById("<%=lblsemester.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
                msg = DropDownForZeroMul(document.getElementById("<%=ddlassessment.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=ddlassessment.ClientID %>").focus();
                    a = document.getElementById("<%=lblAssessment.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
            }
            function Validate() {
                var msg = Valid();
                if (msg == undefined) {
                    return true;
                }
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

            }
        </script>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="LblSpr" runat="server" Text="STUDENT PROGRESS REPORT" SkinID="lblRepRsz"
                                Width="350" Visible="True"></asp:Label>
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbatch" SkinID="ddl" runat="server" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLStudentProgress">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" SkinID="ddl" AutoPostBack="true" runat="server"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode" Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                                        TypeName="DLStudentProgress">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch_No"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAssessment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassessment" SkinID="ddl" runat="server" DataSourceID="ObjAssesment"
                                        DataTextField="AssessmentType" DataValueField="ID" TabIndex="3" Width="240px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                        TypeName="DLStudentProgress"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student &nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLStudent" runat="server" DataValueField="STDID" DataTextField="StdName"
                                        SkinID="ddlRsz" TabIndex="5" DataSourceID="ObjStudent" AutoPostBack="true" Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudent" TypeName="DLStudentProgress">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch_No"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFromDate" runat="server" SkinID="lblRsz" Text="Attendance From Date  :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFromDateExt" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtFromDateExt"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" SkinID="lblRsz" Text="Attendance To Date  :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToDateExt" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <ajaxToolkit:CalendarExtender ID="ToDateExt" runat="server" TargetControlID="txtToDateExt"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="9" runat="server" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnBack" TabIndex="11" runat="server" Text="BACK" SkinID="btn"  CommandName="BACK" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
