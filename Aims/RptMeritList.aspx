<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptMeritList.aspx.vb"
    Inherits="RptMeritList" Title="MERIT LIST" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MERIT LIST</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                <br />
                    <h1 class="headingTxt">
                        MERIT LIST
                    </h1>
                    <br />
                </center>
                <center>
                    <table>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" TabIndex="1">
                                    <asp:ListItem Value="1" Selected="True">Marks &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="2">GPA</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCourse" runat="server" SkinID="lblRsz" Text="Course :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="Left">
                                <asp:DropDownList ID="ddlCourseName" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                    DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                    SkinID="ddlRsz" TabIndex="2" Width="250">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="Left">
                                <asp:ListBox ID="ListBox1" Height="200px" Width="250px" SelectionMode="Multiple"
                                    DataValueField="BatchID" runat="server" TabIndex="3"></asp:ListBox>
                                &nbsp;
                                <asp:Button ID="Btn1" runat="server" Text=">>" SkinID="btnRsz" Width="32" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="Left">
                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" SkinID="ddlRsz"
                                    DataTextField="SemName" DataValueField="SemCode" TabIndex="4" Width="250">
                                    <asp:ListItem Text="Select" Value="0" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%--  <tr>
                            <td align="right">
                                <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSubject" runat="server" DataTextField="Subject_Name" DataValueField="Subject_Code"
                                    SkinID="ddlRsz" TabIndex="1" Width="250">
                                    <asp:ListItem Text="All" Value="0" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblassesment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                    DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="250px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTop" runat="server" SkinID="lbl" Text="Top :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTop" runat="server" SkinID="txtRsz" Width="30" TabIndex="5" MaxLength="3" />
                                &nbsp;&nbsp;
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtTop">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:Label ID="lblBottom" runat="server" SkinID="lblRsz" Width="80" Text="Bottom :&nbsp;&nbsp;"></asp:Label>
                                <asp:TextBox ID="txtBottom" runat="server" SkinID="txtRsz" Width="30" TabIndex="6"
                                    MaxLength="3" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtBottom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                        
                        <td colspan="3" align="center">
                            <asp:CheckBox ID="chkMale" runat="server" Text="Male" TabIndex="7" />
                            &nbsp;
                            <asp:CheckBox ID="chkFemale" runat="server" Text="Female" TabIndex="8" />
                        </td>
                        <td align="left"></td>
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
                                <asp:Button ID="btnAdd" TabIndex="10" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetCoursemMeritList"
                        TypeName="CourseDB"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetMeritListBatchCombo"
                        TypeName="TimeTableDl">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--<asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboMeritList"
                        TypeName="FeeCollectionDL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ListBox1" PropertyName="SelectedValue" Name="BatchID"
                                DbType="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>--%>
                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="DLReportsR">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ListBox1" Name="Batchid" PropertyName="SelectedValue"
                                Type="Int16" />
                            <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

