<%@ Page Title="Batch Report Card Criteria" Language="VB" 
    AutoEventWireup="false" CodeFile="Rpt_BatchReportCardCriteria.aspx.vb" Inherits="Rpt_BatchReportCardCriteria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Report Card Criteria</title>
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
            msg = DropDownMul(document.getElementById("<%=txtBranchName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtBranchName.ClientID%>").focus();
                a = document.getElementById("<%=lblBranchType.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDown(document.getElementById("<%=txtCourseName.ClientID %>"), 'Course');
            if (msg != "") {
                document.getElementById("<%=txtCourseName.ClientID%>").focus();
                a = document.getElementById("<%=lblCourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID%>").focus();
                a = document.getElementById("<%=lblbatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlsubject.ClientID%>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%=ddlsubject.ClientID%>").focus();
                a = document.getElementById("<%=lblsubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlassesment.ClientID%>"), 'Assessment');
            if (msg != "") {
                document.getElementById("<%=ddlassesment.ClientID%>").focus();
                a = document.getElementById("<%=lblassesment.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>").focus();
                a = document.getElementById("<%=lblsemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true; ;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
         
    </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="LblBatchReport" runat="server" Text="BATCH REPORT CARD" SkinID="lblRepRsz"
                                Width="320" Visible="True"></asp:Label>
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        TabIndex="1">
                                        <asp:ListItem Value="1" Selected="True">Batch Report Card</asp:ListItem>
                                        <asp:ListItem Value="2">Marks Analysis</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <asp:Panel ID="Panel1" runat="server">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBranchType" runat="server" Text="Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="txtBranchName" TabIndex="2" runat="server" SkinID="ddlL" AutoPostBack="True"
                                            DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCourse" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="txtCourseName" TabIndex="3" runat="server" SkinID="ddlRsz"
                                            AutoPostBack="True" DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode"
                                            Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblA_Year" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlA_Year" SkinID="ddlRsz" runat="server" DataSourceID="ObjAcademic"
                                        DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True" TabIndex="4"
                                        Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="5"
                                            Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblsemester" runat="server" Text="Semester&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                            DataTextField="SemName" DataValueField="SemCode" TabIndex="6" Width="250" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblsubject" runat="server" Text="Subject&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlsubject" SkinID="ddlRsz" runat="server" DataSourceID="ObjSubject"
                                            DataTextField="Subject_Name" DataValueField="Subject_Code" TabIndex="7" Width="250"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblassesment" runat="server" Text="Assessment Type&nbsp;:&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="170px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" DataValueField="ID" TabIndex="8" Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblReportType" runat="server" SkinID="lblRsz" Width="200px" Text="Report Type:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlReportType" runat="server" SkinID="ddlRsz" Width="200" TabIndex="9">
                                            <asp:ListItem Text="Marks" Value="Marks"></asp:ListItem>
                                            <asp:ListItem Text="Marks&nbsp;and&nbsp;Grade" Value="Marks And Grade"></asp:ListItem>
                                            <asp:ListItem Text="Grade" Value="Grade"></asp:ListItem>
                                            <asp:ListItem Text="Remarks" Value="Remarks"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" Width="200" TabIndex="10">
                                            <asp:ListItem Value="0">Student Name</asp:ListItem>
                                            <asp:ListItem Value="1">Student Code</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblFrmMarks" runat="server" Text="From" />&nbsp;
                                        <asp:Label ID="lblToMarks" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblMarks" runat="server" SkinID="lblRsz" Width="200px" Text="Marks :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFrmMarks" runat="server" SkinID="txtRsz" Width="20" TabIndex="11"
                                            MaxLength="3" /><
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtFrmMarks">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="txtToMarks" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="12" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtToMarks">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="markspanel" runat="server">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBranch1" runat="server" Text="Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlbranch1" TabIndex="2" runat="server" SkinID="ddlL" AutoPostBack="True"
                                            DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCourse1" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCourse1" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode"
                                            Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblA_Year" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlA_Year" SkinID="ddlRsz" runat="server" DataSourceID="ObjAcademic"
                                        DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True" TabIndex="4"
                                        Width="250">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblYear" runat="server" SkinID="lblRSZ" Text="Year of Joining* &nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlYearTo" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                            DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="4" Width="250px" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlSelectYear"
                                            TypeName="DLClientContractMaster"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBatch1" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:ListBox ID="ListBox1" Height="50px" Width="250px" SelectionMode="Multiple" DataValueField="BatchID"
                                            runat="server" TabIndex="5"></asp:ListBox>
                                        &nbsp;
                                        <asp:Button ID="Btn1" runat="server" Text=">>" SkinID="btnRsz" Width="32" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSem1" runat="server" Text="Semester&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSem1" SkinID="ddlRsz" runat="server" DataTextField="SemName"
                                            DataValueField="SemCode" TabIndex="6" Width="250" AutoPostBack="true">
                                            <asp:ListItem Text="All" Value="0" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSubj1" runat="server" Text="Subject&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSubj1" SkinID="ddlRsz" runat="server" DataTextField="Subject_Name"
                                            DataValueField="Subject_Code" TabIndex="7" Width="250" AutoPostBack="true">
                                            <asp:ListItem Text="All" Value="0" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAtype1" runat="server" Text="Assessment Type&nbsp;:&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="170px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlAType1" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" DataValueField="ID" TabIndex="8" Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRptType" runat="server" SkinID="lblRsz" Width="200px" Text="Report Type:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlRptType1" runat="server" SkinID="ddlRsz" Width="200" TabIndex="9">
                                            <asp:ListItem Text="Marks" Value="Marks"></asp:ListItem>
                                            <asp:ListItem Text="Marks&nbsp;and&nbsp;Grade" Value="Marks And Grade"></asp:ListItem>
                                            <asp:ListItem Text="Grade" Value="Grade"></asp:ListItem>
                                            <asp:ListItem Text="Remarks" Value="Remarks"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSort1" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSort1" runat="server" SkinID="ddl" Width="200" TabIndex="10">
                                            <asp:ListItem Value="0">Student Name</asp:ListItem>
                                            <asp:ListItem Value="1">Student Code</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:RadioButtonList ID="RBMarks1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                            TabIndex="11">
                                            <asp:ListItem Value="1" Selected="True">Marks   </asp:ListItem>
                                            <asp:ListItem Value="2">Percentage</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Width="150px" Text="Marks/Percentage Range :"
                                            Visible="false"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblMarksheadingFrm1" runat="server" Text="From" />&nbsp;
                                        <asp:Label ID="lblMarksheadingTo1" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblMarksheadingFrm2" runat="server" Text="From" />&nbsp;
                                        <asp:Label ID="lblMarksheadingTo2" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblMarksheadingFrm3" runat="server" Text="From" />&nbsp;
                                        <asp:Label ID="lblMarksheadingTo3" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblMarksheadingFrm4" runat="server" Text="From" />&nbsp;
                                        <asp:Label ID="lblMarksheadingTo4" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblMaksAnalysis" runat="server" SkinID="lblRsz" Width="250px" Text="Marks/Percentage Range :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <td>
                                        <asp:TextBox ID="TxtFrm1" runat="server" SkinID="txtRsz" Width="20" TabIndex="12"
                                            MaxLength="3" /><
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm1">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtTo1" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo1">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtFrm2" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="14" /><
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm2">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtTo2" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="15" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo2">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtFrm3" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="16" /><
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm3">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtTo3" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="17" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo3">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtFrm4" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="18" /><
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm4">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtTo4" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                            TabIndex="19" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo4">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="btnReport" TabIndex="13" runat="server" Text="REPORT" CommandName="REPORT"
                                        SkinID="btn" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>  
                                    <asp:Button ID="btnMarksAnalysis" TabIndex="19" runat="server" Text="STUDENT MARKS ANALYSIS"
                                        CommandName="STUDENTMARKS" SkinID="btnRsz" Width="190" CssClass="ButtonClass">
                                    </asp:Button>    
                                    &nbsp;<asp:Button ID="btnAdd" TabIndex="20" runat="server" Text="BACK" CommandName="BACK"
                                        SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="insertCourse" TypeName="DLBatchReportCardElect">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--  <asp:ObjectDataSource ID="ObjAcademic" runat="server" TypeName="DLBatchReportCardElect"
                        SelectMethod="insertYear">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>--%>
                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport"
                        TypeName="DLBatchReportCardElect">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                            <%--<asp:ControlParameter ControlID="ddlA_Year" PropertyName="SelectedValue" Name="Aid"
                                DefaultValue="0" Type="Int16" />--%>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                        TypeName="DLBatchReportCardElect">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                DbType="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSubject" runat="server" TypeName="DLBatchReportCardElect"
                        SelectMethod="GetSubjectComboAll1">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="BatchId"
                                DefaultValue="0" Type="Int16" />
                            <asp:ControlParameter ControlID="ddlSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjAssesment" runat="server" TypeName="DLBatchReportCardElect"
                        SelectMethod="getassessment1">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
