<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudentAttendanceSummMonthWise.aspx.vb" 
Inherits="RptStudentAttendanceSummMonthWise" Title="STUDENT ATTENDANCE SUMMARY" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT ATTENDANCE SUMMARY - MONTH WISE</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> 
</script>
<script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Jinapriya
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
        function ValidReport() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatchName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
                       return true;
        }
        function ValidateReport() {
            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrormsg.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=lblerrormsg.ClientID %>").textContent = msg;

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
                        <asp:Label ID="LabelStdAt" runat="server" Text="STUDENT ATTENDANCE SUMMARY - MONTH WISE" SkinID="lblRepRsz"
                            Width="400" Visible="True"></asp:Label>
                    </h1>
                </center>
                <center>
                    <br />
                    <br />
                       
                    <table id="table1" class="custTable">
                    
                      <%--  <tr>
                        <td align="right">
                            <asp:Label ID="lblAcademicYear" runat="server" SkinID="lblRsz" Text="Academic Calendar Year*  :&nbsp;"
                                Width="250px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlacadmeic_year" runat="server" AutoPostBack="True" DataSourceID="odsaccyear"
                                DataTextField="AcademicYear" DataValueField="id" SkinID="ddl" TabIndex="1">
                                <%--<asp:ListItem Value="0">AppendDataBoundItems="True" Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsaccyear" runat="server" SelectMethod="GetAcademicCombo"
                                TypeName="BLNew_stdMarks"></asp:ObjectDataSource>
                        </td>
                    </tr>--%>
                     <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                        AppendDataBoundItems="False" Width="200">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport" TypeName="DLStudAttendanceSummary">
                                    </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="2" runat="server" AutoPostBack="True"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode" Width="200"
                                        SkinID="ddlRsz">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboAsses"
                                        TypeName="DLStudAttendanceSummary">
                                       <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                         </table> 
                          <table>
                    <tbody>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                    TabIndex="3" OnClientClick="return ValidReport();" />
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                    TabIndex="4" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblerrormsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                      </center>       
                  </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</form>
</body>
</html>