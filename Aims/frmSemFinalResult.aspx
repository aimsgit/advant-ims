<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSemFinalResult.aspx.vb"
    Inherits="frmSemFinalResult" Title="Semester Final Result" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>mester Final Result</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

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
                <center>
                    <%--  <h1 class="headingTxt">
                        SEMESTER RESULT</h1>--%>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
            </div>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year* :&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="200px" Visible="false"></asp:Label>
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
                            <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbBatch" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="true"
                                DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="240px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSem" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbSemester" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true" Width="240">
                            </asp:DropDownList>
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
                                    <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
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
                                OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="4" Text="SUBMIT" />
                            <div>
                                <center>
                                   <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
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
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="Gridsubject" runat="server" Width="500px" SkinID="GridView" AllowPaging="true"
                                AutoGenerateColumns="False" Visible="false" PageSize="200" AllowSorting="True"
                                EnableSortingAndPagingCallbacks="True" DataSourceID="ObjSubject">
                                <Columns>
                                    <asp:TemplateField ControlStyle-Width="25px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkPresent" Checked="true" runat="server" TabIndex="9" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Include Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="AssessType" runat="server" Text='<%# Bind("Subject_Name") %>' />
                                            <asp:HiddenField ID="Label1" runat="server" Value='<%# Bind("Subject_Code") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectGridFinalResult"
                                TypeName="DLNew_StudentMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmbBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                    <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFinalAsessment" runat="server" Text="Final Assessment :&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFinalAsessment" TabIndex="5" runat="server" SkinID="ddlRsz"
                                AutoPostBack="True" DataValueField="ID" DataTextField="AssessmentType" Width="240">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnTd" style="height: 9px" align="center">
                            <asp:Button ID="btnCalc" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                SkinID="btnRsz" TabIndex="6" Text="CALCULATE" />
                        </td>
                    </tr>
                </table>
                <center >
                <table>
                    <tr>
                        <td colspan="2">
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
                    </center>
                    <table >
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                    SkinID="GridView" PageSize="200" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Student Code" SortExpression="StudentCode">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("StudentCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name" SortExpression="StudentName">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("StudentName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[1]" ControlStyle-Width="100">
                                            <%--<HeaderTemplate>
                                    <asp:Label ID="lblValueA1" runat="server" Text='<%# Bind("[A1]") %>'></asp:Label></HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue1" runat="server" Text='<%# Bind("[M1]") %>'></asp:Label>
                                                <asp:Label ID="lblMax1" Visible="false" runat="server" Text='<%# Bind("[Max1]") %>'></asp:Label>
                                                <asp:Label ID="lblMin1" Visible="false" runat="server" Text='<%# Bind("[Min1]") %>'></asp:Label>
                                                <asp:Label ID="BatchCode1" Visible="false" runat="server" Text='<%# Bind("BatchCode1") %>'></asp:Label>
                                                <asp:Label ID="SemId1" Visible="false" runat="server" Text='<%# Bind("SemId1") %>'></asp:Label>
                                                <asp:Label ID="StdId1" Visible="false" runat="server" Text='<%# Bind("StdId1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[2]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue2" runat="server" Text='<%# Bind("[M2]") %>'></asp:Label>
                                                <asp:Label ID="lblMax2" Visible="false" runat="server" Text='<%# Bind("[Max2]") %>'></asp:Label>
                                                <asp:Label ID="lblMin2" Visible="false" runat="server" Text='<%# Bind("[Min2]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[3]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue3" runat="server" Text='<%# Bind("[M3]") %>'></asp:Label>
                                                <asp:Label ID="lblMax3" Visible="false" runat="server" Text='<%# Bind("[Max3]") %>'></asp:Label>
                                                <asp:Label ID="lblMin3" Visible="false" runat="server" Text='<%# Bind("[Min3]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[4]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue4" runat="server" Text='<%# Bind("[M4]") %>'></asp:Label>
                                                <asp:Label ID="lblMax4" Visible="false" runat="server" Text='<%# Bind("[Max4]") %>'></asp:Label>
                                                <asp:Label ID="lblMin4" Visible="false" runat="server" Text='<%# Bind("[Min4]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[5]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue5" runat="server" Text='<%# Bind("[M5]") %>'></asp:Label>
                                                <asp:Label ID="lblMax5" Visible="false" runat="server" Text='<%# Bind("[Max5]") %>'></asp:Label>
                                                <asp:Label ID="lblMin5" Visible="false" runat="server" Text='<%# Bind("[Min5]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[6]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue6" runat="server" Text='<%# Bind("[M6]") %>'></asp:Label>
                                                <asp:Label ID="lblMax6" Visible="false" runat="server" Text='<%# Bind("[Max6]") %>'></asp:Label>
                                                <asp:Label ID="lblMin6" Visible="false" runat="server" Text='<%# Bind("[Min6]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[7]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue7" runat="server" Text='<%# Bind("[M7]") %>'></asp:Label>
                                                <asp:Label ID="lblMax7" Visible="false" runat="server" Text='<%# Bind("[Max7]") %>'></asp:Label>
                                                <asp:Label ID="lblMin7" Visible="false" runat="server" Text='<%# Bind("[Min7]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[8]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue8" runat="server" Text='<%# Bind("[M8]") %>'></asp:Label>
                                                <asp:Label ID="lblMax8" Visible="false" runat="server" Text='<%# Bind("[Max8]") %>'></asp:Label>
                                                <asp:Label ID="lblMin8" Visible="false" runat="server" Text='<%# Bind("[Min8]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[9]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue9" runat="server" Text='<%# Bind("[M9]") %>'></asp:Label>
                                                <asp:Label ID="lblMax9" Visible="false" runat="server" Text='<%# Bind("[Max9]") %>'></asp:Label>
                                                <asp:Label ID="lblMin9" Visible="false" runat="server" Text='<%# Bind("[Min9]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[10]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue10" runat="server" Text='<%# Bind("[M10]") %>'></asp:Label>
                                                <asp:Label ID="lblMax10" Visible="false" runat="server" Text='<%# Bind("[Max10]") %>'></asp:Label>
                                                <asp:Label ID="lblMin10" Visible="false" runat="server" Text='<%# Bind("[Min10]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[11]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue11" runat="server" Text='<%# Bind("[M11]") %>'></asp:Label>
                                                <asp:Label ID="lblMax11" Visible="false" runat="server" Text='<%# Bind("[Max11]") %>'></asp:Label>
                                                <asp:Label ID="lblMin11" Visible="false" runat="server" Text='<%# Bind("[Min11]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[12]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue12" runat="server" Text='<%# Bind("[M12]") %>'></asp:Label>
                                                <asp:Label ID="lblMax12" Visible="false" runat="server" Text='<%# Bind("[Max12]") %>'></asp:Label>
                                                <asp:Label ID="lblMin12" Visible="false" runat="server" Text='<%# Bind("[Min12]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[13]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue13" runat="server" Text='<%# Bind("[M13]") %>'></asp:Label>
                                                <asp:Label ID="lblMax13" Visible="false" runat="server" Text='<%# Bind("[Max13]") %>'></asp:Label>
                                                <asp:Label ID="lblMin13" Visible="false" runat="server" Text='<%# Bind("[Min13]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[14]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue14" runat="server" Text='<%# Bind("[M14]") %>'></asp:Label>
                                                <asp:Label ID="lblMax14" Visible="false" runat="server" Text='<%# Bind("[Max14]") %>'></asp:Label>
                                                <asp:Label ID="lblMin14" Visible="false" runat="server" Text='<%# Bind("[Min14]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[15]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue15" runat="server" Text='<%# Bind("[M15]") %>'></asp:Label>
                                                <asp:Label ID="lblMax15" Visible="false" runat="server" Text='<%# Bind("[Max15]") %>'></asp:Label>
                                                <asp:Label ID="lblMin15" Visible="false" runat="server" Text='<%# Bind("[Min15]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[16]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue16" runat="server" Text='<%# Bind("[M16]") %>'></asp:Label>
                                                <asp:Label ID="lblMax16" Visible="false" runat="server" Text='<%# Bind("[Max16]") %>'></asp:Label>
                                                <asp:Label ID="lblMin16" Visible="false" runat="server" Text='<%# Bind("[Min16]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[17]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue17" runat="server" Text='<%# Bind("[M17]") %>'></asp:Label>
                                                <asp:Label ID="lblMax17" Visible="false" runat="server" Text='<%# Bind("[Max17]") %>'></asp:Label>
                                                <asp:Label ID="lblMin17" Visible="false" runat="server" Text='<%# Bind("[Min17]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[18]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue18" runat="server" Text='<%# Bind("[M18]") %>'></asp:Label>
                                                <asp:Label ID="lblMax18" Visible="false" runat="server" Text='<%# Bind("[Max18]") %>'></asp:Label>
                                                <asp:Label ID="lblMin18" Visible="false" runat="server" Text='<%# Bind("[Min18]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[19]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue19" runat="server" Text='<%# Bind("[M19]") %>'></asp:Label>
                                                <asp:Label ID="lblMax19" Visible="false" runat="server" Text='<%# Bind("[Max19]") %>'></asp:Label>
                                                <asp:Label ID="lblMin19" Visible="false" runat="server" Text='<%# Bind("[Min19]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[20]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue20" runat="server" Text='<%# Bind("[M20]") %>'></asp:Label>
                                                <asp:Label ID="lblMax20" Visible="false" runat="server" Text='<%# Bind("[Max20]") %>'></asp:Label>
                                                <asp:Label ID="lblMin20" Visible="false" runat="server" Text='<%# Bind("[Min20]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[21]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue21" runat="server" Text='<%# Bind("[M21]") %>'></asp:Label>
                                                <asp:Label ID="lblMax21" Visible="false" runat="server" Text='<%# Bind("[Max21]") %>'></asp:Label>
                                                <asp:Label ID="lblMin21" Visible="false" runat="server" Text='<%# Bind("[Min21]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[22]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue22" runat="server" Text='<%# Bind("[M22]") %>'></asp:Label>
                                                <asp:Label ID="lblMax22" Visible="false" runat="server" Text='<%# Bind("[Max22]") %>'></asp:Label>
                                                <asp:Label ID="lblMin22" Visible="false" runat="server" Text='<%# Bind("[Min22]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[23]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue23" runat="server" Text='<%# Bind("[M23]") %>'></asp:Label>
                                                <asp:Label ID="lblMax23" Visible="false" runat="server" Text='<%# Bind("[Max23]") %>'></asp:Label>
                                                <asp:Label ID="lblMin23" Visible="false" runat="server" Text='<%# Bind("[Min23]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[24]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue24" runat="server" Text='<%# Bind("[M24]") %>'></asp:Label>
                                                <asp:Label ID="lblMax24" Visible="false" runat="server" Text='<%# Bind("[Max24]") %>'></asp:Label>
                                                <asp:Label ID="lblMin24" Visible="false" runat="server" Text='<%# Bind("[Min24]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[25]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue25" runat="server" Text='<%# Bind("[M25]") %>'></asp:Label>
                                                <asp:Label ID="lblMax25" Visible="false" runat="server" Text='<%# Bind("[Max25]") %>'></asp:Label>
                                                <asp:Label ID="lblMin25" Visible="false" runat="server" Text='<%# Bind("[Min25]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[26]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue26" runat="server" Text='<%# Bind("[M26]") %>'></asp:Label>
                                                <asp:Label ID="lblMax26" Visible="false" runat="server" Text='<%# Bind("[Max26]") %>'></asp:Label>
                                                <asp:Label ID="lblMin26" Visible="false" runat="server" Text='<%# Bind("[Min26]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[27]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue27" runat="server" Text='<%# Bind("[M27]") %>'></asp:Label>
                                                <asp:Label ID="lblMax27" Visible="false" runat="server" Text='<%# Bind("[Max27]") %>'></asp:Label>
                                                <asp:Label ID="lblMin27" Visible="false" runat="server" Text='<%# Bind("[Min27]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[28]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue28" runat="server" Text='<%# Bind("[M28]") %>'></asp:Label>
                                                <asp:Label ID="lblMax28" Visible="false" runat="server" Text='<%# Bind("[Max28]") %>'></asp:Label>
                                                <asp:Label ID="lblMin28" Visible="false" runat="server" Text='<%# Bind("[Min28]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[29]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue29" runat="server" Text='<%# Bind("[M29]") %>'></asp:Label>
                                                <asp:Label ID="lblMax29" Visible="false" runat="server" Text='<%# Bind("[Max29]") %>'></asp:Label>
                                                <asp:Label ID="lblMin29" Visible="false" runat="server" Text='<%# Bind("[Min29]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[30]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue30" runat="server" Text='<%# Bind("[M30]") %>'></asp:Label>
                                                <asp:Label ID="lblMax30" Visible="false" runat="server" Text='<%# Bind("[Max30]") %>'></asp:Label>
                                                <asp:Label ID="lblMin30" Visible="false" runat="server" Text='<%# Bind("[Min30]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[31]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue31" runat="server" Text='<%# Bind("[M31]") %>'></asp:Label>
                                                <asp:Label ID="lblMax31" Visible="false" runat="server" Text='<%# Bind("[Max31]") %>'></asp:Label>
                                                <asp:Label ID="lblMin31" Visible="false" runat="server" Text='<%# Bind("[Min31]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[32]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue32" runat="server" Text='<%# Bind("[M32]") %>'></asp:Label>
                                                <asp:Label ID="lblMax32" Visible="false" runat="server" Text='<%# Bind("[Max32]") %>'></asp:Label>
                                                <asp:Label ID="lblMin32" Visible="false" runat="server" Text='<%# Bind("[Min32]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[33]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue33" runat="server" Text='<%# Bind("[M33]") %>'></asp:Label>
                                                <asp:Label ID="lblMax33" Visible="false" runat="server" Text='<%# Bind("[Max33]") %>'></asp:Label>
                                                <asp:Label ID="lblMin33" Visible="false" runat="server" Text='<%# Bind("[Min33]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[34]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue34" runat="server" Text='<%# Bind("[M34]") %>'></asp:Label>
                                                <asp:Label ID="lblMax34" Visible="false" runat="server" Text='<%# Bind("[Max34]") %>'></asp:Label>
                                                <asp:Label ID="lblMin34" Visible="false" runat="server" Text='<%# Bind("[Min34]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[35]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue35" runat="server" Text='<%# Bind("[M35]") %>'></asp:Label>
                                                <asp:Label ID="lblMax35" Visible="false" runat="server" Text='<%# Bind("[Max35]") %>'></asp:Label>
                                                <asp:Label ID="lblMin35" Visible="false" runat="server" Text='<%# Bind("[Min35]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="[36]" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue36" runat="server" Text='<%# Bind("[M36]") %>'></asp:Label>
                                                <asp:Label ID="lblMax36" Visible="false" runat="server" Text='<%# Bind("[Max36]") %>'></asp:Label>
                                                <asp:Label ID="lblMin36" Visible="false" runat="server" Text='<%# Bind("[Min36]") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Marks" ControlStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TotalMarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Percentage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalPer" runat="server" Text='<%# Bind("TotalMarksPer") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Result">
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
                   <center >
                   <table >
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="4" Text="UPDATE" />
                            <%--<asp:Button ID="Button1" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="4"
                                Text="VIEW" />--%>
                        </td>
                    </tr>
                </table>
                </center>
                <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerCombo"
                    TypeName="DLBatchSemester"></asp:ObjectDataSource>
                <%--<asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                            Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
                <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo1"
                    TypeName="FeeCollectionBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                            DbType="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                    TypeName="DLSemFinalResult"></asp:ObjectDataSource>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>
