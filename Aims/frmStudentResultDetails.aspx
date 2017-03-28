<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentResultDetails.aspx.vb"
    Inherits="frmStudentResultDetails" Title="Student Result Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Result Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = DropDown(document.getElementById("<%=txtBranchName.ClientID %>"), 'Branch');
            if (msg != "") return msg;
            msg = DropDownForZero (document.getElementById("<%=txtCourseName.ClientID %>"), 'Course');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch');
            if (msg != "") return msg;
//            msg = DropDown(document.getElementById("<%=ddlsubject.ClientID%>"), 'Subject');
//            if (msg != "") return msg;
//            msg = DropDown(document.getElementById("<%=ddlassesment.ClientID%>"), 'Assessment');
//            if (msg != "") return msg;
//            msg = DropDown(document.getElementById("<%=ddlclass.ClientID%>"), 'Class Type');
//            if (msg != "") return msg;
//            msg = DropDown(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
//            if (msg != "") return msg;
            return true; ;
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
                    <center>
                        <h1 class="headingTxt">
                            STUDENT RESULT
                            <br />
                            <br />
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranchType" runat="server" Text="Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="txtBranchName" TabIndex="2" runat="server" SkinID="ddlL" AutoPostBack="True"
                                        DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" Width="100px"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="txtCourseName" TabIndex="2" runat="server" SkinID="ddlRsz"
                                        AutoPostBack="True" DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode"
                                        Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblA_Year" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="170px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlA_Year" SkinID="ddlRsz" runat="server" DataSourceID="ObjAcademic"
                                        DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True" Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblsemester" runat="server" Text="Semester&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" SkinID="ddlRsz" AutoPostBack="true" runat="server"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode" Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblsubject" runat="server" Text="Subject&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlsubject" SkinID="ddlRsz" runat="server" DataSourceID="ObjSubject"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblclass" runat="server" Text="Class Type&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlclass" SkinID="ddl" runat="server" DataSourceID="ObjClassType"
                                        DataTextField="classType" DataValueField="code">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblassesment" runat="server" Text="Assessment Type&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassesment" SkinID="ddl" runat="server" DataSourceID="ObjAssesment"
                                        DataTextField="AssessmentType" DataValueField="ID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="12">
                                        <asp:ListItem Value="0">Student Name</asp:ListItem>
                                        <asp:ListItem Value="1">Student Code</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="9" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnAdd" TabIndex="11" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
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
                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetCourse" TypeName="StudentB">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--<asp:ObjectDataSource ID="ObjAcademic" runat="server" TypeName="StudentB" SelectMethod="GetYear">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>--%>
                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport" TypeName="DLBatchReportCardElect">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                            <%--<asp:ControlParameter ControlID="ddlA_Year" PropertyName="SelectedValue" Name="Aid"
                                DefaultValue="0" Type="Int16" />--%>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo122"
                        TypeName="FeeCollectionBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                DbType="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSubject" runat="server" TypeName="DLResult" SelectMethod="SubjectComboALL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="BatchId"
                                DefaultValue="0" Type="Int16" />
                            <asp:ControlParameter ControlID="ddlSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjClassType" runat="server" TypeName="DLResult" SelectMethod="GetClassCombo1">
                    <SelectParameters>
                    <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                    </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjAssesment" runat="server" TypeName="DLResult" SelectMethod="GetAssesmentCombo1">
                    <SelectParameters>
                    <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                    </SelectParameters>
                    </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

