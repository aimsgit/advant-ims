<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudentSemesterMarks.aspx.vb"
    Inherits="RptStudentSemesterMarks" Title="Student Semester Marks" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Semester Marks</title>
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
            //          

            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>").focus(); ;
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
            document.getElementById("<%=ddlBatchName.ClientID%>");
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=DDLSemester.ClientID%>"), 'Semester');
            document.getElementById("<%=DDLSemester.ClientID%>");
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=DDLStudent.ClientID%>"), 'Student');
            document.getElementById("<%=DDLStudent.ClientID%>");
            if (msg != "") return msg;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                            <asp:Label ID="Lblssm" runat="server" Text="STUDENT SEMESTER MARKS" SkinID="lblRepRsz"
                                Width="320" Visible="True"></asp:Label>
                        </h1>
                    <br />
                    <br />
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <%--<tr>
                                <td align="right">
                                    <asp:Label ID="lblAyear" runat="server" SkinID="lblRsz" Text="Academic Year* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLAyear" runat="server" AppendDataBoundItems="true" AutoPostBack="True"
                                        DataSourceID="ObjAyear" DataTextField="AcademicYear" DataValueField="A_Code"
                                        SkinID="ddlRsz" TabIndex="1" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjAyear" runat="server" SelectMethod="GetAyear" TypeName="DLNewSemesterMarks">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Course* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" AppendDataBoundItems="true" AutoPostBack="True"
                                        DataSourceID="ObjCourse1" DataTextField="CourseName" DataValueField="Courseid"
                                        SkinID="ddlRsz" TabIndex="2" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetDtaCourse"
                                        TypeName="DLNewSemesterMarks"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelBtch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="3"
                                        AppendDataBoundItems="False" Width="200">
                                        <%-- <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatch" TypeName="DLNewSemesterMarks">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" DefaultValue="0" Type="Int16"
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester* :&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLSemester" SkinID="ddlRsz" DataSourceID="objSemester" DataValueField="SemCode"
                                        DataTextField="SemName" AutoPostBack="true" AppendDataBoundItems="false" runat="server"
                                        Width="200" TabIndex="4">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLStudent" runat="server" DataValueField="STDID" DataTextField="StdName"
                                        SkinID="ddlRsz" TabIndex="5" DataSourceID="ObjStudent" AutoPostBack="true" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudent" TypeName="DLNewSemesterMarks">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" Name="BatchID" DefaultValue="0" Type="Int16"
                                                PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" DefaultValue="0" Type="Int16"
                                                PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DDLSemester" Name="SemCode" DefaultValue="0" Type="Int16"
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <asp:Button ID="Btnreport" runat="server" CausesValidation="True" CommandName="REPORT"
                                        Text="REPORT" SkinID="btn" TabIndex="6" CssClass="ButtonClass " OnClientClick="return Validate();" />
                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" CommandName="BACK"
                                        TabIndex="7" Text="BACK" />
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
                                <td>
                                    <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
