<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmElectivesMap.aspx.vb"
    Inherits="frmElectivesMap" Title="Electives Map" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Electives Map</title>
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
            var msg, a;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourseName.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourseName.ClientID%>").focus();
                a = document.getElementById("<%=lblCourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatchName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSemester.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>").focus();
                a = document.getElementById("<%=lblSemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlElective.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlElective.ClientID%>").focus();
                a = document.getElementById("<%=lblElective.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msgE.ClientID %>").innerText = msg;
                    document.getElementById("<%=msgS.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msgE.ClientID %>").textContent = msg;
                    document.getElementById("<%=msgS.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }


        function Valid1() {
            var msg, a;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourseName.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourseName.ClientID%>").focus();
                a = document.getElementById("<%=lblCourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatchName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSemester.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>").focus();
                a = document.getElementById("<%=lblSemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlElective.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlElective.ClientID%>").focus();
                a = document.getElementById("<%=lblElective.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlStudent.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlStudent.ClientID%>").focus();
                a = document.getElementById("<%=lblStudent.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msgE.ClientID %>").innerText = msg;
                    document.getElementById("<%=msgS.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msgE.ClientID %>").textContent = msg;
                    document.getElementById("<%=msgS.ClientID %>").textContent = "";

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
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <%--     <center>
                    <h1 class="headingTxt">
                        ELECTIVES MAP
                    </h1>
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
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourseName" runat="server" DataSourceID="ObjCourse" AutoPostBack="true"
                                        DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" Width="250 px"
                                        AppendDataBoundItems="true" TabIndex="1">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblElective" runat="server" SkinID="lbl" Text="Subject* :&nbsp;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                        AppendDataBoundItems="false" Width="200">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" DefaultValue="0"
                                                Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" AutoPostBack="true"
                                        DataTextField="SemName" DataValueField="SemCode" SkinID="ddl" TabIndex="3">
                                        <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlElective" runat="server" DataSourceID="ObjSubject" Width="250px"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="4">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectDDL"
                                        TypeName="TimeTableDl"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <hr />
                        <br />
            </a><a name="bottom">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnGenerate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="5" Text="GENERATE" CommandName="GENERATE" OnClientClick="return Validate();" />
                        </td>
                        <td>
                            <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="6"
                                Text="VIEW" CommandName="VIEW" OnClientClick="return Validate();" />
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="7"
                                Text="CLEAR" CommandName="CLEAR" OnClientClick="return confirm('Do you want to clear the All record(s)?')" />
                        </td>
                        <td>
                            <asp:Button ID="btnLockUnlock" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="8" Text="LOCK/UNLOCK" CommandName="LOCK/UNLOCK" OnClientClick="return Validate();"
                                Width="140px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStudent" runat="server" Text="Student* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" AutoPostBack="true"
                                DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" Width="200">
                                <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                TypeName="StudentPerformanceDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td class="btnTd">
                            <asp:Button ID="BtnGen" runat="server" CssClass="ButtonClass" SkinID="btn" Text="ADD"
                                CommandName="ADD" OnClientClick="return Validate1();" />
                        </td>
                    </tr>
                </table>
                </center>
                <br />
                <hr />
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="170" Text="Elective Subject :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlElecSubj" runat="server" DataSourceID="ObjElecSubject" Width="250px"
                                    DataTextField="Subject_Name" DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="9">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjElecSubject" runat="server" SelectMethod="GetElecSubjectDDl"
                                    TypeName="TimeTableDl">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batchid"
                                            DbType="Int16" />
                                        <asp:ControlParameter ControlID="ddlSemester" PropertyName="SelectedValue" Name="SemId"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="10"
                                    Text="UPDATE" CommandName="UPDATE" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="msgE" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="msgS" runat="server" SkinID="lblGreen"></asp:Label>
                </center>
                <br />
                </Panel>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                            EmptyDataText="No records to display." AllowPaging="True" PageSize="300" PagerStyle-Wrap="False"
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
                                <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        <asp:Label ID="Label13" runat="server" Visible="false" Text='<%# Bind("EMID") %>'></asp:Label>
                                        <asp:Label ID="Label14" runat="server" Visible="false" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Left" SortExpression="StdName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="25px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkElective" runat="server" TabIndex="9" />
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("EMID") %>' />
                                        <%--   <asp:Label ID="LabelElec" runat="server" Text='<%# Bind("Elective_Status") %>' Visible="false"></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Elective Subject" HeaderStyle-HorizontalAlign="Left"
                                    SortExpression="Subject_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblElecSub" runat="server" Text='<%# Bind("Subject_Name") %>' Width="230"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSubject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                            DataValueField="Subject_Code" SkinID="txt">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectCombo"
                                            TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                </asp:panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_Click"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK" CommandName ="OK"
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
                <br />
                <br />
                <br />
                <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
