<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_NewStdMarks.aspx.vb"
    Inherits="frm_NewStdMarks" Title="Student Marks" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Marks</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            //            msg = DropDownForZero(document.getElementById("<%=ddlA_Year.ClientID%>"), 'Academic');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlA_Year.ClientID%>").focus();
            //                return msg;
            //            }
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch No');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlsemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlsubject.ClientID %>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%=ddlsubject.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlassesment.ClientID %>"), 'Assessment');
            if (msg != "") {
                document.getElementById("<%=ddlassesment.ClientID %>").focus();
                return msg;
            }



            //            msg = DropDownForZero(document.getElementById("<%=ddlclass.ClientID %>"), 'Class Type');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlclass.ClientID %>").focus();
            //                return msg;
            //            }

            msg = numeric(document.getElementById("<%=txtMin.ClientID %>"), 'Min Marks');
            if (msg != "") {
                document.getElementById("<%=txtMin.ClientID %>").focus();
                return msg;
            }

            msg = numeric(document.getElementById("<%=txtMax.ClientID %>"), 'Max Marks');
            if (msg != "") {
                document.getElementById("<%=txtMax.ClientID %>").focus();
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
            if (window.clipboardData) {   // Internet Explorer
                var check = window.clipboardData.getData("Text");

                document.getElementById("<%=hiddencode.ClientID %>").value = check
                return (true);
            }
           
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
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
                        <br />
                        <asp:Panel ID="ControlsPanel" runat="server">
                            <center>
                                <table>
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
                                                SkinID="lblRsz" Width="200px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                                DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="240px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblclass" runat="server" Text="Class Type&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlclass" SkinID="ddlRsz" runat="server" DataSourceID="ObjClassType"
                                                DataTextField="classType" DataValueField="code" TabIndex="6" Width="240px">
                                            </asp:DropDownList>
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
                                                DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddl" TabIndex="8">
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
                                            <asp:Label ID="lblIncludeHeader" runat="server" SkinID="lblRsz" Width="150" Text="Calculate Pass/Fail :"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="9" runat="server" Checked="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblIncludeGrade" runat="server" SkinID="lblRsz" Width="150" Text="Calculate Grade :"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkBoxGrade" SkinID="chk" TabIndex="9" runat="server" Checked="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" />
                                            <asp:Button ID="btnUpload" runat="server" Visible="false" SkinID="btn" Width="120px"
                                                Text="Import" OnClick="btnUpload_Click" />&nbsp;
                                        </td>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rbHDR" Visible="false" runat="server">
                                                <asp:ListItem Text="Yes" Value="Yes" Selected="True">
                                                </asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:RadioButtonList>
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
                                            <asp:Button ID="btngenerate" runat="server" Text="GENERATE" SkinID="btnRsz" CssClass="ButtonClass"
                                                Width="120px" OnClientClick="return Validate();" TabIndex="10" />
                                            <asp:Button ID="btnview" runat="server" Text="VIEW" SkinID="btn" CausesValidation="true"
                                                OnClientClick="return Validate();" CssClass="ButtonClass" TabIndex="11" />
                                            <asp:Button ID="BtnUpdate" runat="server" CssClass="ButtonClass" SkinID="Btn" Text="UPDATE"
                                                TabIndex="12" OnClientClick="BtnUpdate_Click" />
                                            <asp:Button ID="btnclear" runat="server" Text="CLEAR" SkinID="btn" CssClass="ButtonClass"
                                                TabIndex="13" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                                            <asp:Button ID="btnlock" runat="server" Text="LOCK / UNLOCK" SkinID="btnRsz" CssClass="ButtonClass"
                                                Width="150px" TabIndex="14" />
                                            <%--<asp:Button ID="ReloadCtl" runat="server" Text="PASTE" SkinID="Btn" CssClass="ButtonClass"
                                                OnClientClick="return pasteContent();" />--%>
                                            <asp:HiddenField ID="hiddencode" runat="server" />
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
                                    <tr>
                                        <td align="left">
                                            <%-- <td align="left">
                                    <asp:Button ID="linkImport" SkinID="btnRsz"  CssClass="ButtonClass" runat="server" OnClientClick="return pasteContent();" Font-Bold="True"> Import from excel sheet</asp:LinkButton>
                                </td>--%>
                                            <asp:Button ID="ReloadCtl" Width="200px" runat="server" Text="IMPORT FROM EXCEL"
                                                SkinID="BtnRsz" CssClass="ButtonClass" OnClientClick="return pasteContent();" />
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
                                </table>
                            </center>
                            <center>
                                <%--Dummy comment--%>
                                <asp:Panel runat="server" ID="pnllabel" Visible="false">
                                    <table>
                                        <tr>
                                            <%-- <td align="left" colspan="2">
                                        <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year :&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="126px" />
                                        <%--</td>
                                    <td align="left">--%>
                                            <%--<asp:Label ID="lblAcademicYearAns" runat="server" SkinID="lbl" />
                                    </td>--%>
                                            <td align="right" colspan="2">
                                                <asp:Label ID="Label2" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="95px" />
                                                </td>
                                    <td align="left">
                                                <asp:Label ID="lblBatchAns" runat="server" SkinID="lblRsz" Width ="250px" />
                                            </td>
                                            <td align="right" colspan="2">
                                                <asp:Label ID="lblAssessmentType" runat="server" Text="Assessment Type :&nbsp;&nbsp;"
                                                    SkinID="lblRsz" Width="145px" />
                                                </td>
                                    <td align="left">
                                                <asp:Label ID="lblAssessmentTypeAns" runat="server" SkinID="lbl" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Label ID="Label3" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="150px" />
                                                </td>
                                    <td align="left">
                                                <asp:Label ID="lblSemesterAns" runat="server" SkinID="lbl" />
                                            </td>
                                            <td align="right" colspan="2">
                                                <asp:Label ID="lblClassType1" runat="server" Text="Class Type :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="120px" />
                                                </td>
                                    <td align="left">
                                                <asp:Label ID="lblClassTypeAns" runat="server" SkinID="lbl" />
                                            </td>
                                        </tr>
                                    <%--</table>
                                    <table>--%>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Label ID="lblSubject1" runat="server" Text="Subject :&nbsp;&nbsp;" Width="145px"
                                                    SkinID="lblRsz" />
                                                </td>
                                    <td align="left">
                                                <asp:Label ID="lblSubjectAns" runat="server" SkinID="lblRsz" Width ="300px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </center>
                            <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                    DataKeyNames="id" SkinID="GridView" PageSize="200" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <RowStyle HorizontalAlign="Left" />
                                    <Columns>
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
                                                    Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtgrade" runat="server" SkinID="txtRsz" Text='<%# Bind("Grade") %>'
                                                    Width="60px" TabIndex="20"></asp:TextBox>
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
                                                <asp:TextBox ID="txtPassFail" runat="server" SkinID="lblRsz" TabIndex="25" Width="50px"
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
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
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
                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                            TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                        <%--<asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlA_Year" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>--%>
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
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ReloadCtl" />
        </Triggers>
    </asp:UpdatePanel>
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>

