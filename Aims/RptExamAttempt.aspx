<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptExamAttempt.aspx.vb"
    Inherits="RptExamAttempt" Title="Semester Exam Attempts Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Exam Attempts Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourse.ClientID%>"), 'Course');
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLSemester.ClientID%>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=DDLSemester.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlFinalIA.ClientID%>"), 'Final IA');
            if (msg != "") {
                document.getElementById("<%=ddlFinalIA.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlFinalExam.ClientID%>"), 'Final Exam');
            if (msg != "") {
                document.getElementById("<%=ddlFinalExam.ClientID%>");
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
             <br />
                <h1 class="headingTxt">
                    SEMESTER EXAM ATTEMPTS REPORT
                </h1>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Course* :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" AppendDataBoundItems="true" AutoPostBack="True"
                                DataSourceID="ObjCourse1" DataTextField="CourseName" DataValueField="Courseid"
                                SkinID="ddlRsz" TabIndex="1" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetDtaCourse"
                                TypeName="DLNewSemesterMarks"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LabelBtch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                AppendDataBoundItems="False" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNewSemesterMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" DefaultValue="0" Type="Int16"
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSemester" runat="server" Text="Semester* :&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLSemester" SkinID="ddlRsz" DataSourceID="objSemester" DataValueField="SemCode"
                                DataTextField="SemName" AutoPostBack="true" AppendDataBoundItems="false" runat="server"
                                Width="200" TabIndex="3">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Assessment 1* :&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFinalIA" runat="server" DataSourceID="ObjectDataSource1"
                                DataTextField="AssessmentType" SkinID="ddlRsz" AutoPostBack="true" AppendDataBoundItems="true"
                                DataValueField="AssesmentCode" Width="200" TabIndex="4">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetFinalIA"
                                TypeName="DLExamAttempt"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Assessment 2* :&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFinalExam" runat="server" DataSourceID="ObjectDataSource2"
                                DataTextField="AssessmentType" SkinID="ddlRsz" Width="200" AutoPostBack="true"
                                AppendDataBoundItems="true" DataValueField="AssesmentCode" TabIndex="5">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetFinalIA"
                                TypeName="DLExamAttempt"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStudent" runat="server" DataValueField="STDID" DataTextField="StdName"
                                SkinID="ddlRsz" TabIndex="6" DataSourceID="ObjStudent" AutoPostBack="true" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudent1" TypeName="DLNewSemesterMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBatchName" Name="BatchID" DefaultValue="0" Type="Int16"
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" DefaultValue="0" Type="Int16"
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="DDLSemester" Name="SemCode" DefaultValue="0" Type="Int16"
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="REPORT" SkinID="btn" TabIndex="7" CssClass="ButtonClass " />&nbsp;
                            <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="8"
                                Text="BACK" CssClass="ButtonClass " />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>