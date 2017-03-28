<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmStudentAttendanceBySubject.aspx.vb" 
Inherits="frmStudentAttendanceBySubject" title="Student Attendance By Subject" EnableEventValidation="false"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance By Subject</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <script type="text/javascript" language="javascript">
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
            //            msg = DropDownForZero(document.getElementById("<%=cmbAcademic.ClientID%>"), 'Academic');
            //            if (msg != "") {
            //                document.getElementById("<%=cmbAcademic.ClientID%>").focus();
            //                return msg;
            //            }
//            msg = DropDownForZeroMul(document.getElementById("<%=cmbBatch.ClientID%>"));
//            if (msg != "") {
//                document.getElementById("<%=cmbBatch.ClientID%>").focus();
//                a = document.getElementById("<%=Label15.ClientID %>").innerHTML;
//                msg = Spliter(a) + " " + ErrorMessage(msg);
//                return msg;
//            }

//            msg = DropDownForZeroMul(document.getElementById("<%=cmbSemester.ClientID%>"));
//            if (msg != "") {
//                document.getElementById("<%=cmbSemester.ClientID%>").focus();
//                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
//                msg = Spliter(a) + " " + ErrorMessage(msg);
//                return msg;
//            }
            //msg = DropDownForZero(document.getElementById("<%=cmbSubject.ClientID%>"), 'Subject');
            //if (msg != "") return msg;

            msg = ValidateDateMul(document.getElementById("<%=TxtAttdate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=TxtAttdate.ClientID%>").focus();
                a = document.getElementById("<%=Label5.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
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
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" 
                CssClass="ajax__tab_xp" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="STUDENT ATTENDANCE"
                    TabIndex="1">
                    <ContentTemplate>
                        <a name="top">
                            <div align="right">
                                <a href="#bottom">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                            </div>
                        </a>
                        <div>
                            <center>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                                </h1>
                            </center>
                            <asp:Panel ID="ControlsPanel" runat="server">
                                <center>
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:LinkButton ID="LinkButton3" ForeColor="Blue" runat="server" Font-Underline="True"
                                                    Text="Data Entry Status" CommandName="StatusE" Font-Size="11pt" 
                                                    OnClick="ViewDataStatus" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label3" runat="server" Text="Academic Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Style="margin-left: 0px" Width="200px" Visible="False"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cmbAcademic" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                                    DataValueField="id" DataTextField="AcademicYear" 
                                                    DataSourceID="ObjAcademic" Width="240px"
                                                    Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label15" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl" 
                                                    Style="margin-left: 0px" Visible="False"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cmbBatch" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                                    DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" 
                                                    Width="230px" Visible="False" >
                                                </asp:DropDownList>
                                            </td>
                                           <td align="right">
                                                <asp:Label ID="Label8" runat="server" Text="Semester :&nbsp;&nbsp;" 
                                                    SkinID="lbl" Visible="False"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cmbSemester" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                                    DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="True" 
                                                    Width="230px" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                      </tr>
                                        <tr>
                                           
                                            <td align="right" valign="top">
                                                <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="220px" AutoPostBack="false">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label4" runat="server" Text="Period No. :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
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
                                                <asp:Label ID="Label5" runat="server" Text="Attendance Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="170px" meta:resourcekey="Label8Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtAttdate" TabIndex="6" runat="server" SkinID="txt" 
                                                    AutoPostBack="True"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="TxtAttdate"
                                                    Format="dd-MMM-yyyy" Enabled="True">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="Attndate" runat="server" ClearMaskOnLostFocus="False"
                                                    ClipboardEnabled="False" Mask="99-LLL-9999"
                                                    TargetControlID="TxtAttdate" CultureAMPMPlaceholder="" 
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label2" runat="server" Text="Subject Subgroup :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="170px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                                    DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddl" TabIndex="8">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGroupCombo"
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
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonClass"
                                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="9" Text="GENERATE"
                                                    CommandName="GENERATE" />&nbsp;
                                                <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                                    SkinID="btn" TabIndex="10" Text="VIEW" CommandName="VIEW" />&nbsp;
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                    TabIndex="14" Text="UPDATE" CommandName="UPDATE" Enabled="False" />&nbsp;
                                                <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="11"
                                                    Text="CLEAR" CommandName="CLEAR" OnClientClick="return confirm('Do you want to delete the selected record(s)?')"
                                                    Enabled="False" Width="90px" />&nbsp;
                                                <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="12"
                                                    Text="LOCK/UNLOCK" CommandName="LOCK" Width="120px" Enabled="False" />&nbsp;
                                                <asp:Button ID="btnSendMsg" runat="server" CssClass="ButtonClass" Enabled="False"
                                                    Width="120px" SkinID="btnRsz" TabIndex="13" Text="SEND MESSAGE" CommandName="MESSAGE"
                                                    OnClientClick="return confirm('Do you want to send message to all absentees?')" />
                                                   <br>
                                                   </br>
                                                <asp:Button ID="BtnAddDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                    TabIndex="15" Text="ADD INDIVIDUAL ATTENDANCE" CommandName="ATTENDANCE" Width="220px"
                                                    OnClientClick="return Validate();" />
                                                <br />
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
                                    </table>
                                  
                                        </asp:Panel><asp:Panel runat="server" ID="pnllabel" Visible="False">
                                          <center>
                                            <table >
                                                <tr>
                                              
                                                    <!--  <td align="right" colspan="2">
                                                        <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz" Width ="95px"/>
                                                    </td>
                                                   <td align="left" colspan="2">
                                                        <asp:Label ID="lblBatchAns" runat="server" SkinID="lblRsz" Width="250px" />
                                                    </td> -->                                                  
                                                    <td align="right" colspan="2">
                                                        <asp:Label ID="lblSubject1" runat="server" Text="Subject :&nbsp;&nbsp;" Width="145px"
                                                            SkinID="lblRsz" />
                                                            
                                                   <td align="left" colspan="2"> 
                                                         <asp:Label ID="lblSubjectAns" runat="server" SkinID="lblRsz" Width="300px"/>
                                                    </td>
                                                    
                                                    <td align="right" colspan="2">
                                                        <asp:Label ID="lblAttendanceDate" runat="server" Text="Attendance Date :&nbsp;&nbsp;"
                                                            SkinID="lblRsz" Width="150px" />
                                                     </td>
                                                     <td align="left" colspan="2">
                                                        <asp:Label ID="lblAttendanceDateAns" runat="server" SkinID="lbl" />
                                                    </td>
                                                    
                                                   
                                                    
                                                </tr>
                                               <!--   <tr>
                                              
                                               
                                                  <td align="right" colspan="2">
                                                        <asp:Label ID="lblSemester" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl" Width ="95px"/>
                                                   </td>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="lblSemesterAns" runat="server" SkinID="lbl" />
                                                    </td>
                                                    
                                                </tr> -->
                                            </table>
                                        </asp:Panel>
                                    </center>
                                    
                                    <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="600px">
                                    <center >
                                        <asp:GridView ID="GVStdAttd" runat="server" Width="584px" SkinID="GridView" DataKeyNames="Id"
                                            AllowPaging="True" AutoGenerateColumns="False" PageSize="200"
                                            AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                            Text="Present" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
                                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("id") %>' />
                                                        <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("Present") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="25px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l9" runat="server" Text='<%# Bind("StdName") %>' />
                                                    </ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l8" runat="server" Text='<%# Bind("StdCode") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("Subject_Name") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Date" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind("AttendanceDate","{0:dd-MMM-yyyy}") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Period No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l7" runat="server" Text='<%# Bind("PeriodNo") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' MaxLength="10"
                                                            Width="75" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Semester">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("SemName") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Batch" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Academic Year" Visible="False" 
                                                    meta:resourcekey="TemplateFieldResource2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                          </center>
                                    </asp:Panel>
                                  
                                   <center>  <asp:Button ID="RptButton" runat="server" SkinID="btnRsz" Text="REPORT" OnClientClick="return Validate();"
                                        CssClass="ButtonClass" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:Button ID="RptAttendanceBtn" runat="server" SkinID="btnRsz" Text="ATTENDANCE REPORT" OnClientClick="return Validate();"
                                        width= "200px" CssClass="ButtonClass" />
                                        
                                        </center>
                                        
                                        
                                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicComboBySub"
                                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlanComboSelectAll"
                                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemCombo"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <!--GetSubComboBatchPlanner -- Previous used combo for Subject  -->
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubCombo"
                                        TypeName="DLNew_StudentMarks">
                                    </asp:ObjectDataSource>
                                </center>
                            </asp:Panel>
                        </div>
                        <asp:Panel ID="PasswordPanel" runat="server" Visible="False" DefaultButton="btnPassword">
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
                        <a name="bottom">
                            <div align="right">
                                <a href="#top">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            </div>
                        </a>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="ATTENDANCE INDIVIDUAL"
                    TabIndex="2">
                    <ContentTemplate>
                        <a name="top">
                            <div align="right">
                                <a href="#bottom">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                            </div>
                        </a>
                        <center>
                            <div class="mainBlock">
                                <center>
                                    <h1 class="headingTxt">
                                        <asp:Label ID="LabelAi" runat="server" Text="ATTENDANCE INDIVIDUAL" SkinID="lblRepRsz"
                                            Width="280" Visible="True"></asp:Label>
                                    </h1>
                                    <br/>
                                    <br/>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlStudent" runat="server" DataTextField="StdName" DataValueField="STD_ID"
                                                    SkinID="ddlRsz" TabIndex="2" AppendDataBoundItems="False" Width="240">
                                                </asp:DropDownList>
                                                <%--<asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                                    TypeName="StudentPerformanceDL">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="cmbBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                        
                                            <td class="btnTd" colspan="2">
                                            <br/>
                                                <asp:Button ID="BtnGen" runat="server" CssClass="ButtonClass" SkinID="btn" Text="ADD"
                                                    CommandName="ADD" ValidationGroup="ADD" TabIndex="19" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div>
                                        <center>
                                            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </div>
                                    <center>
                                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                    </center>
                                </center>
                            </div>
                            <a name="bottom">
                                <div align="right">
                                    <a href="#top">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                                </div>
                            </a>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="ExportPanel" runat="server">
        <center>
            <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                SkinID="btnRsz" Text="EXPORT TO EXCEL" CommandName="EXPORT" Width="170" />
        </center>
    </asp:Panel>


</form>
</body>
</html>
