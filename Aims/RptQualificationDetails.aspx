<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptQualificationDetails.aspx.vb"
    Inherits="RptQualificationDetails" Title="Qualification Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Qualification Details</title>
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
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatchName.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>").focus();
                a = document.getElementById("<%=LabelBtch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=DDLStudent.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=DDLStudent.ClientID%>").focus();
                a = document.getElementById("<%=lblStudent.ClientID %>").innerHTML;
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
            <div>
                <center>
                <br />
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelqd" runat="server" Text="QUALIFICATION DETAILS" SkinID="lblRepRsz"
                            Width="290" Visible="True"></asp:Label></h1>
                    <br />
                    <br />
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Course* :&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataSourceID="ObjCourse1"
                                        DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" TabIndex="1"
                                        AppendDataBoundItems="true" Width="250px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetDtaCourse"
                                        TypeName="CourseDB"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelBtch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                        AppendDataBoundItems="False" Width="250px">
                                        <%-- <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLQualficationDtsRpt">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" DefaultValue="0" Type="Int16"
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLStudent" runat="server" DataValueField="STD_ID" DataTextField="StdName"
                                        SkinID="ddlRsz" TabIndex="3" DataSourceID="ObjStudent" AutoPostBack="true" Width="250px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentDDL"
                                        TypeName="feeCollectionDL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                        CommandName="REPORT" OnClick="Btnreport_Click" Text="REPORT" SkinID="btn" TabIndex="4"
                                        CssClass="ButtonClass " />
                                    &nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        CommandName="BACK" TabIndex="5" Text="BACK" />
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
