<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptDeptWiseConsolidatedFeedback.aspx.vb"
    Inherits="RptDeptWiseConsolidatedFeedback" Title="DEPARTMENT WISE FEEDBACK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DEPARTMENT WISE FEEDBACK</title>
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
                a = document.getElementById("<%=lblcourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSem1.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlSem1.ClientID%>").focus();
                a = document.getElementById("<%=lblSem1.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
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
                        DEPARTMENT WISE FEEDBACK
                    </h1>
                    <br />
                    <br />
                </center>
                <center>
                    <table>
                        <tr>
                            <caption>
                                <td align="right">
                                    <asp:Label ID="lblcourse" runat="server" SkinID="lblRsz" Text="Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="True" DataSourceID="ObjCourse"
                                        DataTextField="CourseName" DataValueField="CourseCode" SkinID="ddlRsz" TabIndex="1"
                                        Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="insertCourse" TypeName="RptDeptWiseConsolidatedFeedbackScore">
                                    </asp:ObjectDataSource>
                                </td>
                            </caption>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td>
                                <asp:ListBox ID="ListBatch" Height="50px" Width="250px" SelectionMode="Multiple"
                                    AutoPostBack="True" DataValueField="BatchID" DataTextField="Batch_No" runat="server"
                                    DataSourceID="ObjBatch" TabIndex="3" CssClass="Listbox"></asp:ListBox>
                            </td>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport"
                                TypeName="RptDeptWiseConsolidatedFeedbackScore">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlcourse" Name="CourseCode" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSem1" runat="server" Width="150px" Text="Semester*&nbsp:&nbsp&nbsp"
                                    SkinID="lblrsz"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:DropDownList ID="ddlSem1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataTextField="SemName" DataValueField="SemCode" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <caption>
                                <td align="right">
                                    <asp:Label ID="lblfaculty" runat="server" SkinID="lblRsz" Text="Faculty&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlfaculty" runat="server" AutoPostBack="True" DataSourceID="objfaculty"
                                        DataTextField="EmpName" DataValueField="EID" SkinID="ddlRsz" TabIndex="1" Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objfaculty" runat="server" SelectMethod="FeedBackFacultyDDL"
                                        TypeName="RptDeptWiseConsolidatedFeedbackScore">
                                        <%-- <SelectParameters>
                                    <asp:ControlParameter ControlID="ListBatch" Name="Batch" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>--%>
                                    </asp:ObjectDataSource>
                                </td>
                            </caption>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="5">
                                <asp:Button ID="btnReport" runat="server" OnClientClick="return Validate();" CssClass="ButtonClass"
                                    CommandName="REPORT" SkinID="btn" Text="REPORT" />&nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" CommandName="BACK"
                                    SkinID="btn" TabIndex="3" Text="BACK" Visible="true" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
