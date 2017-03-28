<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptTimeSheet.aspx.vb" Inherits="RptTimeSheet" title="Time Sheet" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Time Sheet</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
             <br />
                <h1 class="headingTxt">
                 TIME SHEET
                </h1>
                <br />
                <table>
                    <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" SkinID="lblRsz" Text="Employee Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmployeeName" runat="server" AppendDataBoundItems="true"
                                    AutoPostBack="true" DataSourceID="ObjEmployee" DataTextField="EmpName" DataValueField="EmpID"
                                    SkinID="ddlRsz" TabIndex="1" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmployee" runat="server" SelectMethod="GetEmployeeCombo"
                                    TypeName="LessonPlanDL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchComboR" TypeName="LessonPlanDL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" TabIndex="3"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1R"
                                    TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" DataSourceID="ObjSubject"
                                    DataTextField="Subject_Name" DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="4"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectR" TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSemester" PropertyName="SelectedValue" Name="Sem"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                   
                    <tr>
                        <td colspan="2" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" 
                                Text="REPORT" SkinID="btn" TabIndex="5" CssClass="ButtonClass " />&nbsp;
                            <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="6"
                                Text="BACK" CssClass="ButtonClass " />
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

