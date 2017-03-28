<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Frm_NewStdMarksElective.aspx.vb"
    Inherits="Frm_NewStdMarksElective" Title="Student Marks" EnableEventValidation="false"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Marks</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">

        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
        function Valid() {
            var msg;

            //            msg = DropDownForZero(document.getElementById("<%=ddlA_Year.ClientID%>"), 'Academic');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlA_Year.ClientID%>").focus();
            //                return msg;
            //            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlbatch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                a = document.getElementById("<%=lblbatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlsemester.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                a = document.getElementById("<%=lblsemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlsubject.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlsubject.ClientID %>").focus();
                a = document.getElementById("<%=lblsubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlassesment.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlassesment.ClientID %>").focus();
                a = document.getElementById("<%=lblassesment.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            msg = ValidateDateMul(document.getElementById("<%=TxtAssessmentDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtAssessmentDate.ClientID %>").focus();
                a = document.getElementById("<%=Label5.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = numericMul(document.getElementById("<%=txtMin.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMin.ClientID %>").focus();
                a = document.getElementById("<%=lblMin.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = numericMul(document.getElementById("<%=txtMax.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMax.ClientID %>").focus();
                a = document.getElementById("<%=lblmax.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }

    </script>

    <script type="text/javascript" language="javascript">
        function pasteContent() {

        }
    </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                BackColor="#E2E3BB">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Student Marks" TabIndex="1">
                    <ContentTemplate>
                        <a name="top">
                            <div align="right">
                                <a href="#bottom">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                            </div>
                        </a>
                        <div>
                            <%--      <center>
                    <h1 class="headingTxt">
                        ENTER STUDENT MARKS</h1>
                </center>--%>
                            <center>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                                </h1>
                            </center>
                            <asp:Panel ID="ControlsPanel" runat="server">
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:LinkButton ID="LinkButton1" ForeColor="Blue" runat="server" Font-Underline="true"
                                                    Text="Data Entry Status" CommandName="Status" Font-Size="11" OnClick="ViewDataStatus" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblA_Year" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;"
                                                    SkinID="lblRsz" Visible="false"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlA_Year" SkinID="ddlRsz" runat="server" DataSourceID="ObjAcademic"
                                                    DataTextField="AcademicYear" DataValueField="id" TabIndex="1" Width="240px" AutoPostBack="true"
                                                    Visible="false">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                                    DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                                    Width="240px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                                    DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                                    Width="240px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <asp:Label ID="lblsubject" runat="server" Text="Subject*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlsubject" SkinID="ddlRsz" runat="server" DataSourceID="ObjSubject"
                                                    DataTextField="Subject_Name" DataValueField="Subject_Code" TabIndex="4" Width="240px"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblassesment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                                    SkinID="lblRsz" Width="190px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                                    DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="240px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" Text="Assessment Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    meta:resourcekey="Label8Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtAssessmentDate" TabIndex="6" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="TxtAssessmentDate"
                                                    Format="dd-MMM-yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblmax" runat="server" Text="Max Marks*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtmax" SkinID="txt" runat="server" TabIndex="7" MaxLength="4">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMin" runat="server" Text="Min Marks*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMin" SkinID="txt" runat="server" TabIndex="8" MaxLength="4">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label4" runat="server" Text="Subject Subgroup :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                                    DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddl" TabIndex="9"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGrpCombo"
                                                    TypeName="DLSubjectSubGrpMapping">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlsubject" DefaultValue="0" Name="Subject" PropertyName="SelectedValue"
                                                            Type="Int16" />
                                                        <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="batch" PropertyName="SelectedValue"
                                                            Type="Int16" />
                                                        <asp:ControlParameter ControlID="ddlsemester" DefaultValue="0" Name="Semester" PropertyName="SelectedValue"
                                                            Type="Int16" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" DataTextField="StdName"
                                                    DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="10" AppendDataBoundItems="False"
                                                    Width="240">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo2"
                                                    TypeName="StudentPerformanceDL">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                                        <asp:ControlParameter ControlID="ddlSubjectSubGrp" Name="Subgrp" Type="Int16" PropertyName="SelectedValue" />
                                                        <asp:ControlParameter ControlID="ddlsubject" DefaultValue="0" Name="Subject" PropertyName="SelectedValue"
                                                            Type="Int16" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblIncludeHeader" runat="server" SkinID="lblRsz" Width="150" Text="Calculate Pass/Fail :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="11" runat="server" Checked="false" />
                                            </td>
                                            <td align="left">
                                                <b>&nbsp;&nbsp;&nbsp;Note:</b> For 2 and more attempts
                                                <br />
                                                &nbsp;&nbsp;&nbsp;Select Student Combo
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblIncludeGrade" runat="server" SkinID="lblRsz" Width="260" Text="Calculate Grade :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ChkBoxGrade" SkinID="chk" TabIndex="12" runat="server" Checked="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCalculateGrade" runat="server" SkinID="lblRsz" Width="260" Text="Calculate Grade Point :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="ChkcalculateGradePoint" SkinID="chk" TabIndex="13" runat="server"
                                                    Checked="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btngenerate" runat="server" Text="GENERATE" SkinID="btnRsz" CommandName="GENERATE"
                                                    CssClass="ButtonClass" Width="120px" OnClientClick="return Validate();" TabIndex="13" />
                                                <asp:Button ID="btnview" runat="server" Text="VIEW" CommandName="VIEW" SkinID="btn"
                                                    CausesValidation="true" OnClientClick="return Validate();" CssClass="ButtonClass"
                                                    TabIndex="14" />
                                                <asp:Button ID="BtnUpdate" runat="server" CssClass="ButtonClass" SkinID="Btn" Text="UPDATE"
                                                    CommandName="UPDATE" TabIndex="15" OnClientClick="BtnUpdate_Click" />
                                                <asp:Button ID="btnclear" runat="server" Text="CLEAR" SkinID="btn" CssClass="ButtonClass"
                                                    CommandName="CLEAR" TabIndex="16" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                                                <asp:Button ID="btnlock" runat="server" Text="LOCK/UNLOCK" SkinID="btnRsz" CssClass="ButtonClass"
                                                    CommandName="LOCK" Width="150px" TabIndex="17" />
                                                <asp:HiddenField ID="hiddencode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <%-- <td align="left">
                                    <asp:Button ID="linkImport" SkinID="btnRsz"  CssClass="ButtonClass" runat="server" OnClientClick="return pasteContent();" Font-Bold="True"> Import from excel sheet</asp:LinkButton>
                                </td>--%>
                                                <asp:Button ID="ReloadCtl" Width="200px" runat="server" Text="IMPORT FROM EXCEL"
                                                    SkinID="BtnRsz" Visible="false" CommandName="IMPORT1" CssClass="ButtonClass"
                                                    OnClientClick="return pasteContent();" />
                                                <asp:Button ID="btnimport" Width="200px" runat="server" Text="IMPORT FROM EXCEL"
                                                    CommandName="IMPORT1" SkinID="BtnRsz" CssClass="ButtonClass" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <br />
                                            <div>
                                                <center>
                                                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                        <ProgressTemplate>
                                                            <div class="PleaseWait">
                                                                <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </center>
                                            </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                                <asp:Label ID="lblerror" runat="server" SkinID="lblRed" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <center>
                                    <%--Dummy comment--%>
                                    <asp:Panel runat="server" ID="pnllabel" Visible="false">
                                        <table>
                                            <tr>
                                                <%--<td align="left" colspan="2">
                                        <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year :&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="126px" />
                                        <%--</td>
                                    <td align="left">--%>
                                                <%-- <asp:Label ID="lblAcademicYearAns" runat="server" SkinID="lbl" />
                                    </td>--%>
                                                <td align="right" colspan="2">
                                                    <asp:Label ID="Label2" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz"
                                                        Width="95px" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="lblBatchAns" runat="server" SkinID="lblRsz" Width="250px" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="lblAssessmentType" runat="server" Text="Assessment Type :&nbsp;&nbsp;"
                                                        SkinID="lblRsz" Width="150px" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="lblAssessmentTypeAns" runat="server" SkinID="lbl" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Label ID="Label3" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lblRsz"
                                                        Width="95px" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="lblSemesterAns" runat="server" SkinID="lblRsz" Width="250px" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="label10" runat="server" Text="Assessment Date :&nbsp;&nbsp;" Width="150px"
                                                        SkinID="lblRsz" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="lblAssessmentDate" runat="server" SkinID="lblRsz" Width="100px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Label ID="lblSubject1" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lblRsz"
                                                        Width="95px" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="lblSubjectAns" runat="server" SkinID="lblRsz" Width="250px" />
                                                </td>
                                            </tr>
                                        </table>
                                </center>
                            </asp:Panel>
                            </center>
                            <center>
                                <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        DataKeyNames="id" SkinID="GridView" PageSize="200" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <RowStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Max Marks">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelMax" runat="server" Text='<%# Bind("MaxMarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Min Marks">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelMin" runat="server" Text='<%# Bind("MinMarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Actual Marks">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtactmarks" runat="server" SkinID="txtRsz" Text='<%# Bind("ActualMarks") %>'
                                                        Width="60px" TabIndex="16"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Exam Attendance">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEamAttdId" runat="server" Text='<%# Bind("LookUpAutoID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblEamAttdName" runat="server" Text='<%# Bind("Data") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlExamAttend" runat="server" DataSourceID="objExamAttend"
                                                        DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddlRsz" Width="100px">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="objExamAttend" runat="server" SelectMethod="ExamAttendance"
                                                        TypeName="DLStdMarksElective"></asp:ObjectDataSource>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtgrade" runat="server" TabIndex="30" SkinID="txtRsz" Text='<%# Bind("Grade") %>'
                                                        Width="60px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade Point">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtgradePoint" runat="server" TabIndex="30" SkinID="txtRsz" Text='<%# Bind("GradePoint") %>'
                                                        Width="60px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="%Marks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Labelmarks" runat="server" Text='<%# Bind("Percentage","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pass/Fail">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPassFail" runat="server" SkinID="lblRsz" TabIndex="30" Width="50px"
                                                        Text='<%# Bind("Pass_Fail") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="lblRsz" TabIndex="30" Width="50px"
                                                        Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelSubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assessment Type" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelAsst" runat="server" Text='<%# Bind("AssessmentType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class Type" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelClass" runat="server" Text='<%# Bind("classType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Semester" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelSemester" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblbatch" Visible="false" runat="server" Text='<%# Bind("BatchID") %>'></asp:Label>
                                                    <asp:Label ID="LabelBatch" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Academic Year" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="LabelAcademic" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                    <asp:Label ID="lblassessdate" runat="server" Text='<%# Bind("AssessmentDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                            <center>
                                <asp:Button ID="RptButton" runat="server" SkinID="btnRsz" Text="REPORT" OnClientClick="return Validate();"
                                    CssClass="ButtonClass" />
                            </center>
                            </asp:Panel>
                            <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                            <%--<asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="GetSemesterCombo"
                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>--%>
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                                TypeName="DLNew_StudentMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                    <asp:ControlParameter ControlID="ddlsemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjClassType" runat="server" SelectMethod="GetClassCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                            <%-- <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlA_Year" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                            Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                                TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
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
                                                        CommandName="OK" OnClientClick="btnPassword_click" />
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
                                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                            </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Import Student Marks"
                    TabIndex="2">
                    <ContentTemplate>
                        <div>
                            <center>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Labelism" runat="server" Text="IMPORT STUDENT MARKS" SkinID="lblRepRsz"
                                        Width="280" Visible="True"></asp:Label>
                                </h1>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblpaste" SkinID="lblRsz" runat="server" Text="Paste Data"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="ChkGrade" runat="server" Visible="True" Text="Grade" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:TextBox ID="txtData" runat="server" Enabled="True" TextMode="MultiLine" Width="300px"
                                                Height="300px"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="300px" Height="300px">
                                                <asp:GridView ID="GridView2" SkinID="GridView" runat="server">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("StudentCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Actual Marks" SortExpression="StdName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("ActualMarks") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="GridView3" SkinID="GridView" runat="server">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentCode" runat="server" Text='<%# Bind("StudentCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Grade" SortExpression="Grade">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <center>
                                    <br />
                                    <asp:Label ID="lblRed" runat="server" SkinID="lblRed" />
                                    <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen" />
                                </center>
                            </center>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="ReloadCtl" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <center>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" CommandName="EXPORT" />
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <asp:Button ID="btnparse" runat="server" SkinID="btnRsz" CausesValidation="true"
                CssClass="ButtonClass" Text="PARSE DATA" Height="26px" CommandName="PARSE" />
            <asp:Button ID="Btnback" SkinID="btnRsz" runat="server" CausesValidation="true" CssClass="ButtonClass"
                Text="IMPORT" Height="26px" CommandName="IMPORT" /></asp:Panel>
    </center>
    </form>
</body>
</html>
