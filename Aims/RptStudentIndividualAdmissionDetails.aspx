<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudentIndividualAdmissionDetails.aspx.vb"
    Inherits="RptStudentIndividualAdmissionDetails" Title="Student Admission Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Admission Details</title>
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
           
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>");
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>");
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
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
            <center>
            <br />
                <h1 class="headingTxt">
                    <asp:Label ID="Labelst" runat="server" Text="STUDENT INDIVIDUAL ADMISSION REPORT" SkinID="lblRepRsz"
                        Width="450" Visible="True"></asp:Label>
                </h1>
                <br />
                <table>
                  <%--  <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAcdemicYear" runat="server" DataSourceID="ObjAY" DataTextField="AcademicYear"
                                SkinID="ddl" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="A_Code"
                                TabIndex="1">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAY" runat="server" SelectMethod="GetAcademicYear" TypeName="RptStudentAdmissionDetailsBL">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" DataTextField="CourseName" SkinID="ddlRsz"
                                Width="250" DataSourceID="ObjCourse" AutoPostBack="true" DataValueField="Courseid"
                                TabIndex="2">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetCourse" TypeName="RptStudentAdmissionDetailsBL">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBatch" runat="server" DataTextField="Batch_No" SkinID="ddlRsz"
                                Width="250" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="BatchID"
                                TabIndex="3">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStudent" runat="server" DataTextField="Name" SkinID="ddlRsz"
                                Width="250" DataSourceID="ObjStudent" DataValueField="Std_Id" TabIndex="4">
                                <asp:ListItem Value="0"> All</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudent" TypeName="RptStudentAdmissionDetailsBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBatch" Name="BatchID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="REPORT" SkinID="btn" TabIndex="5" CssClass="ButtonClass " CommandName="REPORT" />&nbsp;
                            <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="6"
                                Text="BACK" CommandName="BACK" CssClass="ButtonClass " />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
