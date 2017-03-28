<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RPT_FacultyTimeUtilization.aspx.vb"
    Inherits="RPT_FacultyTimeUtilization" Title="Faculty Time Utilization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Faculty Time Utilization</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
            </br>
                <h1 class="headingTxt">
                    FACULTY TIME UTILIZATION
                </h1>
            </center>
            </br>
            <asp:Panel ID="ControlsPanel" runat="server">
                <center>
                    <table class="custTable">
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" SkinID="lbl" Text="Faculty Name :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DdlFaculty" runat="server" TabIndex="1" AutoPostBack="true"
                                    DataValueField="EmpID" DataTextField="Emp_Name" DataSourceID="ObjFaculty" SkinID="ddlRsz"
                                    Width="200">
                                </asp:DropDownList>
                            </td>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lblRsz" Text="Course :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" DataSourceID="ObjCourse"
                                        DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" TabIndex="2"
                                        AppendDataBoundItems="true" Width="200">
                                    </asp:DropDownList>
                                </td>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="3"
                                            Width="200">
                                        </asp:DropDownList>
                                    </td>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                                DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" TabIndex="4"
                                                Width="200">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDLSubject" runat="server" DataSourceID="ObjSubject" AppendDataBoundItems="false"
                                                DataTextField="Subject_Name" DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="5"
                                                Width="200">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
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
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tbody>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" runat="server" TabIndex="6" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" TabIndex="7" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 191px">
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="lblerror" runat="server" SkinID="lblRed" />
                                    <asp:ObjectDataSource ID="objTeacher" runat="server" SelectMethod="GetLecturercombo"
                                        TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse1"
                                        TypeName="CourseDB"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo1"
                                        TypeName="TimeTableDl">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                                        TypeName="TimeTableDl">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="DLRptFacultyTimeUtilization">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatch" Name="Batchid" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="cmbSemester" Name="SemId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <%--<asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="SubjectComboD1"
                                        TypeName="DLRptFacultyTimeUtilization">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="cmbSemester" PropertyName="SelectedValue" Name="Semester"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 191px">
                                    <asp:ObjectDataSource ID="ObjFaculty" SelectMethod="GetFacultyCombo" TypeName="DLRptFacultyTimeUtilization"
                                        runat="server"></asp:ObjectDataSource>
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
                                <td>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

