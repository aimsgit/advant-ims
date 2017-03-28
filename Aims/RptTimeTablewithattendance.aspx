<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptTimeTablewithattendance.aspx.vb"
    Inherits="RptTimeTablewithattendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DAYWISE ATTENDANCE MISSED REPORT</title>
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

          
            msg = ValidateDateMul(document.getElementById("<%=txtdate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtdate.ClientID %>").focus();
                a = document.getElementById("<%=lbldate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;

        }
        function Validate1() {
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

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <br />
                        <h1 class="headingTxt">
                            DAYWISE ATTENDANCE MISSED REPORT
                        </h1>
                        <br>
                    </center>
                    <center>
                        <table>
                           <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblbatch" runat="server" SkinID="lbl" Text="Batch* :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbatch" runat="server" TabIndex="1" DataValueField="BatchID"
                                        DataTextField="Batch_No" DataSourceID="objbatch" SkinID="ddl" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objbatch" runat="server" SelectMethod="getBatch" TypeName="DLTimeTableWithattendance">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td align="right">
                                    <asp:Label ID="lblsem" runat="server" SkinID="lbl" Text="Semester* :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlsem" runat="server" SkinID="ddl" TabIndex="2" DataSourceID="objCourse"
                                        DataValueField="SemCode" DataTextField="SemName" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objcourse" runat="server" SelectMethod="GetDtaCourse" TypeName="DLTimeTableWithattendance">
                                     <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbldate" runat="server" SkinID="lblrsz" Width="200px" Text="Attendance Date* :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtdate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txtdate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtdate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" runat="server" OnClientClick="return Validate1();" TabIndex="4"
                                        Text="REPORT" SkinID="btn" CommandName="REPORT" CssClass="ButtonClass"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="5" Text="BACK" CommandName="BACK"
                                        SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnsendsms" runat="server" SkinID="btn" Text="SEND SMS" TabIndex="6"
                                        OnClientClick="return Validate1();" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
                                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>
