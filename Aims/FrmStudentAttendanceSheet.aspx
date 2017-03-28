<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmStudentAttendanceSheet.aspx.vb"
    Inherits="FrmStudentAttendanceSheet" Title="STUDENT ATTENDANCE SHEET" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT ATTENDANCE SHEET</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script src="js/Tvalidate.js" type="text/javascript"> </script>

        

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <br />
                        <h1 class="headingTxt">
                            STUDENT ATTENDANCE SHEET
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lblRsz" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlBatchName" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="true"
                                        DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="230px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSemester" runat="server" SkinID="lblRsz" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="Left">
                                        <asp:DropDownList ID="ddlSemester" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="True" Width="230px">
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
                                        <asp:Label ID="Label9" runat="server" Text="Subject *&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSubjectName" TabIndex="4" runat="server" SkinID="ddlRsz"
                                            DataValueField="Subject_Code" DataTextField="Subject_Name" DataSourceID="ObjSubject"
                                            Width="230px" AutoPostBack="false">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                                            TypeName="DLNew_StudentMarks">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlBatchName" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                                <asp:ControlParameter ControlID="ddlSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
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
                        <%-- <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchComboForum"
                            TypeName="DLReportStudAtt"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                            TypeName="DLReportStudAtt">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBatchName" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>


</form>
</body>
</html>
