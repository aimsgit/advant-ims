<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptStudentLogBook.aspx.vb"
    Inherits="FrmRptStudentLogBook" Title="Student Log Book" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Log Book</title>
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
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlStudent.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlStudent.ClientID%>").focus();
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
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    return false;
                }
                return true;
            }
        }
    </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
   <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                            <asp:Label ID="LblLog" runat="server" Text="STUDENT LOG BOOK" SkinID="lblRepRsz"
                                Width="320" Visible="True"></asp:Label>
                        </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                    AppendDataBoundItems="True" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLStudentLogBook">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student Name&nbsp;:&nbsp;&nbsp;" width="150px" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="2"
                                    AppendDataBoundItems="False" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameComboAll"
                                    TypeName="DLStudentLogBook">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:Label ID="LblLogType" runat="server" SkinID="lblRsz" Text="Log Type&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlLogtype" runat="server" DataSourceID="ObjDept" DataTextField="LogType"
                                    DataValueField="Log_AutoID" SkinID="ddlRsz" Width="200px" TabIndex="3">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLStudentLogBook" SelectMethod="GetLogTypeAll">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblfdate" runat="server" Text="From Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtfdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lbltdate" runat="server" Text="To Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txttodate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                    CssClass="ButtonClass" OnClientClick="return Validate()"></asp:Button>
                                &nbsp;<asp:Button ID="btnBack" TabIndex="7" runat="server" Text="BACK" CommandName="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
