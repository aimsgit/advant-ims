<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudAttendance.aspx.vb"
    Inherits="RptStudAttendance" Title="STUDENT ATTENDANCE REGISTER(WITH CLASS TYPE)" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT ATTENDANCE REGISTER(WITH CLASS TYPE)</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        STUDENT ATTENDANCE REGISTER(WITH CLASS TYPE)</h1>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label1" runat="server" Text="Branch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlL" TabIndex="1"
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label3" runat="server" Text="Academic Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Style="margin-left: 0px" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAcademic" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCourse" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="txtCourseName" TabIndex="3" runat="server" SkinID="ddlRsz"
                                    AutoPostBack="True" DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode"
                                    Width="250">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label15" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbBatch" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="200">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSemester" AutoPostBack="true" TabIndex="4" runat="server"
                                    SkinID="ddlRsz" DataValueField="SemCode" DataTextField="SemName" DataSourceID="ObjSemester"
                                    Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSubject" TabIndex="5" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="lblclasstype" runat="server" Text="Class Type :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClasstype" TabIndex="6" runat="server" SkinID="ddlRsz" DataValueField="code"
                                    DataTextField="classType" DataSourceID="ObjClassType" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="7"
                                    AppendDataBoundItems="False" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMonth" runat="server" Text="Month :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" TabIndex="8" runat="server" AutoPostBack="True" SkinID="ddlRsz"
                                    AppendDataBoundItems="False" Width="200">
                                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="btnTd" align="center">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="11"
                                    Text="REPORT" Visible="true" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="12" Text="BACK" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <div>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </div>
                        <caption>
                            &nbsp;<%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" tabIndex="1" runat="server" ValidationGroup="Submit" ErrorMessage="Subject Field Null" ControlToValidate="cmbBatch">*</asp:RequiredFieldValidator>--%>
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                                    <%-- <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>--%>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertCourse" TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport"
                                        TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                            <%--<asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                                Type="Int16" />--%>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboSelect"
                                        TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboAll1"
                                        TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="cmbbatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjClassType" runat="server" SelectMethod="GetClassCombo1"
                                        TypeName="DLResult">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                        TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="cmbBatch" Name="BatchId" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" DisplayMode="List"
                                                EnableTheming="false" EnableViewState="false" ShowMessageBox="true" ShowSummary="false"
                                                TabIndex="1" ValidationGroup="Save" />
                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" EnableViewState="False"
                                                TabIndex="-1" ValidationGroup="Submit" />
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </caption>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

