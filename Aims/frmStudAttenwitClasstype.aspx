<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudAttenwitClasstype.aspx.vb"
    Inherits="frmStudAttenwitClasstype" Title="Student Attendance" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            //            msg = DropDownForZero(document.getElementById("<%=cmbAcademic.ClientID%>"), 'Academic');
            //            if (msg != "") {
            //                document.getElementById("<%=cmbAcademic.ClientID%>").focus();
            //                return msg;
            //            }
            msg = DropDownForZero(document.getElementById("<%=cmbBatch.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=cmbBatch.ClientID%>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=cmbSemester.ClientID%>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID%>").focus();
                return msg;
            }
            //msg = DropDownForZero(document.getElementById("<%=cmbSubject.ClientID%>"), 'Subject');
            //if (msg != "") return msg;
            //            msg = DropDownForZero(document.getElementById("<%=ddlClasstype.ClientID%>"), 'Class Type');
            //            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=TxtAttdate.ClientID%>"), 'Attendance Date');
            if (msg != "") {
                document.getElementById("<%=TxtAttdate.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%--   <center>
                    <h1 class="headingTxt">
                        ENTER STUDENT ATTENDANCE</h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Academic Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Style="margin-left: 0px" Width="200px" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbAcademic" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic" Width="240"
                                        Visible="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbBatch" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="true"
                                        DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="240px">
                                        <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSemester" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                        DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true" Width="240">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                        DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="240" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblclasstype1" runat="server" Text="Class Type :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlClasstype" TabIndex="5" runat="server" SkinID="ddlRsz" DataValueField="code"
                                        DataTextField="classType" DataSourceID="ObjClassType" Width="240">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Attendance Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        meta:resourcekey="Label8Resource1"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtAttdate" TabIndex="6" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="TxtAttdate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="Attndate" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="TxtAttdate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Period No. :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <%--  <asp:TextBox ID="TxtSessioncount" TabIndex="7" runat="server" SkinID="Txt" ReadOnly="False">
                                    </asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlPeriod" runat="server" SkinID="ddl" TabIndex="7">
                                        <asp:ListItem Text="None" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Subject Subgroup :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                        DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddl" TabIndex="8">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGrpCombo"
                                        TypeName="DLSubjectSubGrpMapping">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="cmbSubject" DefaultValue="0" Name="Subject" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="cmbBatch" DefaultValue="0" Name="batch" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="Semester" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
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
                        </table>
                        <table>
                            <tr>
                                <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                    <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="9" Text="GENERATE" />
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="btnrsz" TabIndex="10" Text="VIEW" Visible="true" />
                                    <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11"
                                        Text="CLEAR" OnClientClick="return confirm('Do you want to delete the selected record(s)?')"
                                        Enabled="False" Width="90px" />
                                    <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="12"
                                        Text="LOCK/UNLOCK" Width="120px" Enabled="False" />
                                    <asp:Button ID="btnSendMsg" runat="server" CssClass="ButtonClass" Enabled="False"
                                        Width="120px" SkinID="btnRsz" TabIndex="13" Text="SEND MESSAGE" OnClientClick="return confirm('Do you want to send message to all absentees?')" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="14" Text="UPDATE" Enabled="False" />
                                    <br />
                                    <div>
                                        <center>
                                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        Processing your request..please wait...
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <center>
                            <%--<asp:Panel runat="server" ID="pnllabel" Visible="false">
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year :&nbsp;&nbsp;"
                                                SkinID="lbl" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblAcademicYearAns" runat="server" SkinID="lbl" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblBatchAns" runat="server" SkinID="lbl" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblSemesterAns" runat="server" SkinID="lbl" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblAttendanceDate" runat="server" Text="Attendance Date :&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="200px" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblAttendanceDateAns" runat="server" SkinID="lbl" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblClassType" runat="server" Text="Class Type :&nbsp;&nbsp;" SkinID="lbl" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblClassTypeAns" runat="server" SkinID="lbl" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblSubject" runat="server" Text="Subject Name:&nbsp;&nbsp;" SkinID="lbl" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblSubjectAns" runat="server" SkinID="lbl" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>--%><asp:Panel runat="server" ID="pnllabel" Visible="false">
                                <table>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="95px" />
                                            </td>
                                    <td align="left">
                                            <asp:Label ID="lblBatchAns" runat="server" SkinID="lblRsz" Width ="250px" />
                                        </td>
                                        <td align="right" colspan="2">
                                            <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year :&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width ="150px" Visible="false" />
                                            </td>
                                    <td align="left">
                                            <asp:Label ID="lblAcademicYearAns" runat="server" SkinID="lbl" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Label ID="lblSemester" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="95px" />
                                            </td>
                                    <td align="left">
                                            <asp:Label ID="lblSemesterAns" runat="server" SkinID ="lbl"/>
                                        </td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <td align="right" colspan="2">
                                            <asp:Label ID="lblAttendanceDate" runat="server" Text="Attendance Date :&nbsp;" SkinID="lblRsz"
                                                Width="145px" />
                                            </td>
                                    <td align="left">
                                            <asp:Label ID="lblAttendanceDateAns" runat="server" SkinID="lblRsz" Width ="200px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Label ID="lblSubject1" runat="server" Text="Subject :&nbsp;&nbsp;" Width="145px"
                                                SkinID="lblRsz" />
                                            </td>
                                    <td align="left">
                                            <asp:Label ID="lblSubjectAns" runat="server" SkinID="lblRsz" Width ="300px" />
                                        </td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <td align="right" colspan="2">
                                            <asp:Label ID="Label6" runat="server" Text="Class Type:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="93px" />
                                            </td>
                                    <td align="left">
                                            <asp:Label ID="lblClassTypeAns" runat="server" SkinID="lblRsz" Width ="200px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </center>
                        <center >
                        <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVStdAttd" runat="server" Width="584px" SkinID="GridView" DataKeyNames="Id"
                                AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="200"
                                AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ControlStyle-Width="25px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                Text="Present" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("id") %>' />
                                            <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("Present") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" ControlStyle-Width="200px" SortExpression="StdName">
                                        <ItemTemplate>
                                            <asp:Label ID="l9" runat="server" Text='<%# Bind("StdName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                        <ItemTemplate>
                                            <asp:Label ID="l8" runat="server" Text='<%# Bind("StdCode") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("Subject_Name") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClassType" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Expr1") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Attendance Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("AttendanceDate","{0:dd-MMM-yyyy}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Period No">
                                        <ItemTemplate>
                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("PeriodNo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="Elective" SortExpression="Elective_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblElective" runat="server" Text='<%# Bind("Elective_Name") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' MaxLength="10"
                                                Width="75" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Semester" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("SemName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batch" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Academic Year" Visible="false" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        </center>
                        <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                        <%--    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>--%>
                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                            TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo1"
                            TypeName="FeeCollectionBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                                    DbType="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                            TypeName="DLNew_StudentMarks">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cmbBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                    Type="Int16" />
                                <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjClassType" runat="server" SelectMethod="GetClassCombo"
                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                    </center>
                </asp:Panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_click"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                            OnClientClick="btnPassword_click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="ExportPanel" runat="server">
        <center>
            <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
        </center>
    </asp:Panel>

</form>
</body>
</html>

