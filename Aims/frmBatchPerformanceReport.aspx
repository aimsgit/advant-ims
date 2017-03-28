<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBatchPerformanceReport.aspx.vb"
    Inherits="frmBatchPerformanceReport" Title="BATCH PERFORMANCE REPORT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BATCH PERFORMANCE REPORT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
 
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <h1 class="headingTxt">
            <asp:Label ID="LblBatchPReport" runat="server" Text="BATCH PERFORMANCE REPORT" SkinID="lblRepRsz"
                Width="350" Visible="True"></asp:Label>
        </h1>
    </center>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table class="custtable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Course*  :&nbsp;&nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlcourse" runat="server" AppendDataBoundItems="False" DataValueField="Courseid"
                                DataTextField="CourseName" SkinID="ddlRsz" TabIndex="1" DataSourceID="objcourse"
                                AutoPostBack="true" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester  :&nbsp;&nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSemester" runat="server" AppendDataBoundItems="False" DataValueField="SemCode"
                                DataTextField="SemName" SkinID="ddlRsz" TabIndex="1" DataSourceID="objSemester"
                                AutoPostBack="true" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblass" runat="server" Width="170px" Text="Assessment Type*&nbsp:&nbsp&nbsp"
                                SkinID="lblrsz"></asp:Label>
                        </td>
                        <td colspan="3" align="left">
                            <asp:DropDownList ID="ddlass" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                DataSourceID="Objass" DataTextField="AssessmentType" DataValueField="ID" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Subject  :&nbsp;&nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlsubject" runat="server" DataValueField="Subject1" DataTextField="Subject_Name"
                                SkinID="ddlRsz" TabIndex="2" DataSourceID="ObjSubject" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Batch1*  :&nbsp;&nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch1" runat="server" AppendDataBoundItems="False" DataValueField="BatchID"
                                DataTextField="Batch_No" SkinID="ddlRsz" TabIndex="3" DataSourceID="ObjBatch1"
                                Width="200">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Batch2  :&nbsp;&nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch2" runat="server" AppendDataBoundItems="False" DataValueField="BatchID"
                                DataTextField="Batch_No" SkinID="ddlRsz" TabIndex="4" DataSourceID="ObjBatch2"
                                Width="200">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="btRpt" CausesValidation="true" runat="server" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                TabIndex="4" CssClass="ButtonClass"></asp:Button>
                            <asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" TabIndex="5" CommandName="BACK" CssClass="ButtonClass">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                <asp:Label ID="lblErrorMsg" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="objcourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SelectCourseSemester"
        TypeName="DLBatchReportCardElect">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlcourse" Name="courseid" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjBatch1" runat="server" SelectMethod="GetBatch1Combo"
        TypeName="BatchPerformanceRptDL">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlcourse" Name="courseid" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjBatch2" runat="server" SelectMethod="GetBatch1Combo"
        TypeName="BatchPerformanceRptDL">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlcourse" Name="courseid" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="SelectCourseSemSubject"
        TypeName="DLBatchReportCardElect">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlcourse" Name="Courseid" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlSemester" Name="Semid" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Objass" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="SelectNewAssessment" TypeName="DLBatchReportCardElect"></asp:ObjectDataSource>

</form>
</body>
</html>
