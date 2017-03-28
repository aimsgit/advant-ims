<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentPerformance.aspx.vb"
    Inherits="frmStudentPerformance" Title="STUDENT PERFORMANCE REPORT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT PERFORMANCE REPORT</title>
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
                            <asp:Label ID="LblStdperformance" runat="server" Text="STUDENT PERFORMANCE" SkinID="lblRepRsz"
                                Width="320" Visible="True"></asp:Label>
                        </h1>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:RadioButtonList ID="RbPerfromance" Width="200px" runat="server" AutoPostBack="true"
                                        RepeatDirection="Horizontal" TabIndex="1" Font-Bold="true">
                                        <asp:ListItem Text="Semester" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Overall" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </center>
                            </td>
                        </tr>
                        <tr>
                        <td> &nbsp;
                        </td>
                        <td>
                        &nbsp;
                        </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz" Width ="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                    AppendDataBoundItems="True" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" TabIndex="3"
                                    Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSubject" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True" DataSourceID="ObjSubject"
                                    DataTextField="Subject_Name" DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="4"
                                    Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="2"
                                    AppendDataBoundItems="False" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 9px" align="center">
                                <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                     SkinID="btn" TabIndex="4" Text="REPORT" CommandName="REPORT" />&nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                    Text="BACK" CommandName="BACK" Visible="true" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="BatchPerformanceRptDL">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                    TypeName="StudentPerformanceDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                    TypeName="FeeCollectionBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectforPublish" TypeName="DLReportsR">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" Name="BatchId" Type="Int16" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

