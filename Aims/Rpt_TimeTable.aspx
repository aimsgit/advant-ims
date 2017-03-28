<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_TimeTable.aspx.vb"
    Inherits="Rpt_TimeTable" Title="Time Table Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Time Table Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                <br />
                    <center>
                        <h1 class="headingTxt">
                            TIME TABLE
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lblRsz" Text="Course* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlCourseName" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                        SkinID="ddlRsz" TabIndex="1" Width="200">


                                       <%-- <asp:ListItem Value="0">Select</asp:ListItem>--%>

                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1" Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                        DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" TabIndex="1" Width="200">
                                        <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                    <td align="right"><asp:Label ID="lblWeeks" runat="server" SkinID="lbl" Text="Week No&nbsp;:&nbsp;&nbsp;"></asp:Label></td>  
                                    <td>
                                        <asp:DropDownList ID="ddlWeekNo" runat="server" AutoPostBack="true" 
                                            DataSourceID="ObjWeek" DataTextField="WeekName" DataValueField="WeekNo" 
                                            SkinID="ddlRsz" TabIndex="2" Width="200">
                                        </asp:DropDownList>
                
                                </td>
                                
                                <tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSubject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                        DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="1" Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTeacher" runat="server" SkinID="lblRsz" Text="Teacher :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlTeacher" runat="server" AppendDataBoundItems="true" DataSourceID="objTeacher"
                                        DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" TabIndex="1" Width="200">
                                        <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
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
                        </table>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                            TypeName="FeeCollectionBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                    DbType="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjWeek" runat="server" SelectMethod="GetWeekNo"
                                    TypeName="DLReportsR"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectforPublish" TypeName="DLReportsR">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBatchName" Name="Batchid" PropertyName="SelectedValue"
                                    Type="Int16" />
                                <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                    Type="Int16" />     
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="objTeacher" runat="server" SelectMethod="GetLecturercombo"
                            TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>


</form>
</body>
</html>

