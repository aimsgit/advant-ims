<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptNewStudAttendwitDate.aspx.vb"
    Inherits="RptNewStudAttendwitDate" Title="Student Attendance Register Datewise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance Register Datewise</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
            <br />
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="LabelStdAt" runat="server" Text="STUDENT ATTENDANCE REGISTER DATEWISE"
                            SkinID="lblRepRsz" Width="520" Visible="True"></asp:Label>
                    </h1>
                </center>
                <center>
                    
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
                        <%-- <tr>
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
                                <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="insertCourse" TypeName="DLBatchReportCardElect">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label15" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBatch" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
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
                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Subject Subgroup :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                    DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddlRsz"
                                    TabIndex="4" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGrpComboAllNew1"
                                    TypeName="DLSubjectSubGrpMapping">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbSubject" DefaultValue="0" Name="Subject" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="ddlBranch" DefaultValue="0" Name="BranchCode" PropertyName="SelectedValue"
                                                Type="String" />
                                        <asp:ControlParameter ControlID="ddlBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFromDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="6" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="7" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="8">
                                    <asp:ListItem Value="0">Student Name</asp:ListItem>
                                    <asp:ListItem Value="1">Student Code</asp:ListItem>
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
                                    Text="REPORT" CommandName="REPORT" Visible="true" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="12" CommandName="BACK" Text="BACK" />
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
                                        <asp:Label ID="msginfored" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
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
                                        SelectMethod="GetBranchByUID" TypeName="BranchManager"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="insertBatch" TypeName="DLBatchReportCardElect">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <%--<asp:ControlParameter ControlID="ddlA_Year" PropertyName="SelectedValue" Name="Aid"
                                DefaultValue="0" Type="Int16" />--%>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="Semesterddl"
                                        TypeName="feeCollectionDL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" PropertyName="SelectedValue"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectSelect"
                                        TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" PropertyName="SelectedValue"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="ddlBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                                Type="Int16" />
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
