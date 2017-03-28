<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmBatchSemAssesmentResult.aspx.vb"
    Inherits="FrmBatchSemAssesmentResult" Title="Batch Semester Result" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Semester Result</title>
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
            msg = DropDownForZeroMul(document.getElementById("<%=ddlbatch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
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
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <center>
                    <%-- <h1 class="headingTxt">
                        ASSESSMENT RESULT</h1>--%>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    <br />
                </center>
                <hr />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblnote" runat="server" Text="Step 1: Select Batch,Semester,Subject(s) and Assessment types for which the marks need to be processed.On click of submit,the desired marks will get loaded in the table given below.If the data displayed is not correct,you can change your selections and submit again."
                                SkinID="lblRSZ" Width="763"></asp:Label>
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td align="Right">
                                <asp:Label ID="LblBatch" runat="server" Text="Select Batch* :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DdlBatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    TabIndex="1" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="objBatchPlanner"
                                    Width="240">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerCombo"
                                    TypeName="DLBatchSemester"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSemester" TabIndex="2" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                    DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true" Width="240">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo2"
                                    TypeName="FeeCollectionBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlBatch" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSubject" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="240" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner1"
                                    TypeName="DLNew_StudentMarks">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
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
                        <asp:GridView ID="GVSemResult" runat="server" Width="300px" SkinID="GridView" AllowPaging="true"
                            AutoGenerateColumns="False" Visible="true" PageSize="200" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkPresent" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assessment Type" ControlStyle-Width="125px">
                                    <ItemTemplate>
                                        <asp:Label ID="AssessType" runat="server" Text='<%# Bind("AssessmentType") %>' />
                                        <asp:HiddenField ID="Label1" runat="server" Value='<%# Bind("ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </table>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:RadioButtonList ID="rbSelect" runat="server" Width="500px" RepeatDirection="Vertical"
                                    TabIndex="4">
                                    <asp:ListItem Selected="True" Text="Load Actual Marks" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Load % Marks" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="2" class="btnTd" style="height: 9px" align="right">
                                <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="SUBMIT" CommandName="SUBMIT" />
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td colspan="2" class="btnTd1" style="height: 9px" align="left">
                                <asp:Button ID="Button1" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="SUBMIT" Visible="false" />
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
                    <hr />
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="Step 2: Select the operation to be done using the radio button.Select the semester and Assessment type where the processed marks need to be stored.On click of calculate,the calculations will be done and put in the 'Total Marks %/Avg' column.Once you find that the operation is correct,put Max and Min Marks and click Update button to save the marks in the database."
                                    SkinID="lblRSZ" Width="763"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbladdSem" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAddsem" TabIndex="6" runat="server" SkinID="ddl" DataValueField="SemCode"
                                    DataTextField="SemName" DataSourceID="ObjSemester1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester1" runat="server" SelectMethod="SemesterCombo1"
                                    TypeName="FeeCollectionBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlBatch" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblassesment" runat="server" Text="Assessment Type* :&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlassesment" SkinID="ddl" runat="server" DataTextField="AssessmentType"
                                    DataValueField="ID" TabIndex="7">
                                </asp:DropDownList>
                                <%-- <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblmaxmarks" runat="server" Text="Max Marks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmaxmarks" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtmaxmarks">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMinmarks" runat="server" Text="Min Marks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMinmarks" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMinmarks">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBestOf" runat="server" Text="Best Of :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBestOf" runat="server" SkinID="txt" TabIndex="10" MaxLength="2"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtBestOf">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:RadioButtonList ID="RBType" runat="server" Width="300px" RepeatDirection="Vertical"
                                    TabIndex="4">
                                    <asp:ListItem Selected="True" Text="Calculation for Best Of" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Calculation for Weightage Of Assessment" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 140px">
                            </td>
                            <td colspan="4" class="btnTd" style="height: 9px" align="left">
                                <asp:Button ID="btnCalculate" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="20" Text="CALCULATE"
                                    CommandName="CALCULATE" />
                                <asp:Button ID="BtnRoundOff" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="21"
                                    Text="ROUND OFF" Visible="true" CommandName="ROUND" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="22"
                                    Text="UPDATE" CommandName="UPDATE" Visible="true" />
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblWeightage" runat="server" Text="% Weightage For Assessment :&nbsp;&nbsp;"
                                SkinID="lblRsz"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                ID="txtt1" runat="server" SkinID="txtRsz" TabIndex="11" Width="35" MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt2" runat="server" SkinID="txtRsz" TabIndex="12" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt2">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt3" runat="server" SkinID="txtRsz" TabIndex="13" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt3">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt4" runat="server" SkinID="txtRsz" TabIndex="14" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt4">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt5" runat="server" SkinID="txtRsz" TabIndex="15" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt5">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt6" runat="server" SkinID="txtRsz" TabIndex="16" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt6">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt7" runat="server" SkinID="txtRsz" TabIndex="17" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt7">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt8" runat="server" SkinID="txtRsz" TabIndex="18" Width="35"
                                MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt8">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            %<asp:TextBox ID="txtt9" runat="server" SkinID="txtRsz" TabIndex="19" Width="35"
                                MaxLength="6"></asp:TextBox>%
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtt9">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                            </td>
                        </tr>
                    </table>
                    <%-- <table>
                        <tr>
                            <td>
                                <center>
                                    <asp:GridView ID="GvWeightage" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                        SkinID="GridView" TabIndex="6" PageSize="10">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" " HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGTotal" runat="server" Text="% Weightage for Assessment" Width="200px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assmt1">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssmt1" runat="server" SkinID="lblRsz" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assmt2">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssmt2" runat="server" SkinID="lblRsz" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assmt3">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssmt3" runat="server" SkinID="lblRsz" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assmt4">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssmt4" runat="server" SkinID="lblRsz" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assmt5">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssmt5" runat="server" SkinID="lblRsz" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assmt6">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssmt6" runat="server" SkinID="lblRsz" Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />--%>
                    <asp:Panel ID="Panel2" runat="server" Height="250px" Width="770px" ScrollBars="Auto">
                        <asp:GridView ID="GVStdAttd" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                            SkinID="GridView" TabIndex="6" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="Student Code">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HidStdId" runat="server" Value='<%# Bind("StdId") %>' />
                                        <%--<asp:HiddenField ID="HidBatch" runat="server" Value='<%# Bind("BatchCode") %>' />
                                        <asp:HiddenField ID="HidSEmid" runat="server" Value='<%# Bind("SemId") %>' />
                                        <asp:HiddenField ID="HidAssesmentId" runat="server" Value='<%# Bind("AssesmentId") %>' />--%>
                                        <asp:Label ID="lblstdcode" runat="server" Text='<%# Bind("StudentCode") %>'></asp:Label>
                                        <asp:Label ID="lblStdId" runat="server" Text='<%# Bind("StdId") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name" ControlStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstdname" runat="server" Text='<%# Bind("StudentName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Name" ControlStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubjectname" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                        <asp:Label ID="lblSubjectId" runat="server" Text='<%# Bind("Subjectid") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls1" runat="server" Text='<%# Bind("[A2]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub" runat="server" Text='<%# Bind("[6]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls23" runat="server" Text='<%# Bind("A3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub1" runat="server" Text='<%# Bind("[8]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls3" runat="server" Text='<%# Bind("A4") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub2" runat="server" Text='<%# Bind("[10]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls4" runat="server" Text='<%# Bind("A5") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub3" runat="server" Text='<%# Bind("[12]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls5" runat="server" Text='<%# Bind("A6") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub4" runat="server" Text='<%# Bind("[14]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls6" runat="server" Text='<%# Bind("A7") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub5" runat="server" Text='<%# Bind("[16]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls7" runat="server" Text='<%# Bind("A8") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub6" runat="server" Text='<%# Bind("[18]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls8" runat="server" Text='<%# Bind("A9") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub7" runat="server" Text='<%# Bind("[20]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assmt">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls9" runat="server" Text='<%# Bind("A10") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub8" runat="server" Text='<%# Bind("[22]") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="txtTotalMarks" runat="server" Text='<%# Bind("TotalMarks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Marks %/Avg">
                                    <ItemTemplate>
                                        <asp:Label ID="txtTotalMarksPer" runat="server" Text='<%# Bind("TotalMarksPer","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade" ControlStyle-Width="50" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="txtGrade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
