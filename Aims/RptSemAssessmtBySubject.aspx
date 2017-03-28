<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSemAssessmtBySubject.aspx.vb"
    Inherits="RptSemAssessmtBySubject" Title="SEMESTER ASSESSMENT BY SUBJECT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SEMESTER ASSESSMENT BY SUBJECT</title>
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

            msg = ValidateDateMul(document.getElementById("<%=txtFrmDate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtFrmDate.ClientID%>").focus();
                a = document.getElementById("<%=lblFrmDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMul(document.getElementById("<%=txtTodate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtTodate.ClientID%>").focus();
                a = document.getElementById("<%=lblToDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownMul(document.getElementById("<%=cmbSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSubject.ClientID%>").focus();
                a = document.getElementById("<%=Label9.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="LblsemAss" runat="server" Text="SEMESTER ASSESSMENT BY SUBJECT" SkinID="lblRepRsz"
                                Visible="True"></asp:Label>
                        </h1>
                        <br>
                    </center>
                    <center>
                        <table class="custTable">
                            <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblYear" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="170px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlYearName" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataSourceID="ObjYear" DataTextField="AcademicYear" DataValueField="A_Code" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetYear" TypeName="DLReportsR"></asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFrmDate" runat="server" SkinID="lblRSZ" Text=" From Date*:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txtRSZ" Width="190" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrmDate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" SkinID="lblRSZ" Text=" To Date*:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTodate" runat="server" SkinID="txtRSZ" Width="190" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTodate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <%--   <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="3" runat="server" AutoPostBack="True"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode" Width="200"
                                        SkinID="ddlRsz">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="SubjectId"
                                        DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="DLRptSemAssessmtBySubject">
                                    <%--<SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="ddlSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>--%>
                                </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblass" runat="server" Width="150px" Text="Assessment Type&nbsp:&nbsp&nbsp"
                                        SkinID="lblrsz"></asp:Label>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlass" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="4" DataSourceID="Objass" DataTextField="AssessmentType" DataValueField="ID"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="Objass" runat="server" SelectMethod="getassessmentAll"
                                        TypeName="DLRptSemAssessmtBySubject"></asp:ObjectDataSource>
                                </td>
                            </tr>
                           <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" 
                                        DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="6"
                                        AppendDataBoundItems="False" Width="200">
                                    </asp:DropDownList>
                                    <%--<asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                        TypeName="DLRptSemAssessmtBySubject">
                                        <SelectParameters>
                                            <%--<asp:ControlParameter ControlID="cmbSubject" Name="Subject" Type="Int16" PropertyName="SelectedValue" />--%>
                                            <%--<asp:ControlParameter ControlID="cmbSubject" Name="Subject" Type="Int16" PropertyName="SelectedValue" />--%>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRptType" runat="server" Text="Report Type:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRptType" runat="server" SkinID="ddl" TabIndex="5">
                                        <asp:ListItem Value="0">Marks</asp:ListItem>
                                        <asp:ListItem Value="1">Percentage</asp:ListItem>
                                        <asp:ListItem Value="2">Grade</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSort" runat="server" Text="Sort By :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="6" AutoPostBack ="true " > 
                                        <asp:ListItem Value="0">Student Name</asp:ListItem>
                                        <asp:ListItem Value="1">Student Code</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" runat="server" TabIndex="7" Text="REPORT" SkinID="btn" 
                                        CommandName="REPORT" CssClass="ButtonClass" OnClientClick="return Validate();"  ></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="8" Text="BACK" CommandName="BACK"
                                        SkinID="btn" CssClass="ButtonClass"></asp:Button>
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
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                             <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
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
