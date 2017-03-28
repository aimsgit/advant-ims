<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmSemesterResultTable1.aspx.vb"
    Inherits="FrmSemesterResultTable1" Title="Semester Result Table" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Result Table</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch No');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=cmbSemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID %>").focus();
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


        function Valid1() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch No');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=cmbSemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlStudent.ClientID %>"), 'Student');
            if (msg != "") {
                document.getElementById("<%=ddlStudent.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate1() {
            var msg = Valid1();
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
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <center>
                        <%--   <h1 class="headingTxt">
                       SEMESTER RESULT TABLE</h1>--%>
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
                                        <asp:DropDownList ID="ddlA_Year" SkinID="ddl" runat="server" DataSourceID="ObjAcademic"
                                            DataTextField="AcademicYear" DataValueField="id" AutoPostBack="True" TabIndex="1"
                                            Visible="false">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                            Width="250px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelect"
                                            TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                        <%--<asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlA_Year" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cmbSemester" TabIndex="3" runat="server" SkinID="ddl" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
                            <center>
                            <table>
                                <tr align="center" >
                                    <td colspan="3" class="btnTd" style="height: 9px" align="center">
                                        <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="4" Text="GENERATE" />
                                       &nbsp; <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                            SkinID="btn" TabIndex="5" Text="VIEW" Visible="true" />
                                       &nbsp; <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="6"
                                            Text="LOCK/UNLOCK" Width="120px" />
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
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblStudent" runat="server" Text="Student* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" AutoPostBack="true"
                                            DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" Width="200" TabIndex="7">
                                            <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                            TypeName="StudentPerformanceDL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td class="btnTd">
                                        <asp:Button ID="BtnAddStd" runat="server" CssClass="ButtonClass" SkinID="btn" Text="ADD"
                                            OnClientClick="return Validate1();" TabIndex="8" />
                                    </td>
                                </tr>
                            </table>
                            </center>
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
                                <div>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                            </table>
                            <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                <asp:GridView ID="GVSemmesterResultTable" runat="server" Width="584px" SkinID="GridView"
                                    AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="100"
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
                                        <asp:TemplateField HeaderText="Student Code" meta:resourcekey="TemplateFieldResource2"
                                            SortExpression="StdCode">
                                            <ItemTemplate>
                                                <asp:Label ID="l1" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("BatchSemResult_ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eligibility">
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("Eligibility") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Non Eligible Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubjectEligibility" runat="server" Text='<%# Bind("SubjectName") %>' />
                                            </ItemTemplate>
                                             <ItemStyle Wrap="true"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Marks">
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("MarksWithGrace") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Result">
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("Result") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Division">
                                            <ItemTemplate>
                                                <asp:Label ID="l6" runat="server" Text='<%# Bind("Division") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GPA">
                                            <ItemTemplate>
                                                <asp:Label ID="l8" runat="server" Text='<%# Bind("CGPA") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CGPA">
                                            <ItemTemplate>
                                                <asp:Label ID="l9" runat="server" Text='<%# Bind("CGPA1") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rank">
                                            <ItemTemplate>
                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("Rank") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                    </asp:Panel>
                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                        <center>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                                                OnClientClick="btnPassword_Click" />
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
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
