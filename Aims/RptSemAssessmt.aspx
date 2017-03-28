<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSemAssessmt.aspx.vb"
    Inherits="RptSemAssessmt" Title="Semester Assessment Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Assessment Report</title>
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
           
            msg = DropDownForZeroMul(document.getElementById("<%=ddlcourseName.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlcourseName.ClientID%>").focus();
                a = document.getElementById("<%=lblcourse.ClientID %>").innerHTML;
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

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                       <h1 class="headingTxt">
                            <asp:Label ID="LblsemAss" runat="server" Text="SEMESTER ASSESSMENT" SkinID="lblRepRsz"
                                Width="320" Visible="True"></asp:Label>
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
                                    <asp:Label ID="lblcourse" runat="server" SkinID="lblRsz" Text="Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlcourseName" runat="server" AutoPostBack="True" DataSourceID="ObjCourse"
                                        DataTextField="CourseName" DataValueField="CourseCode" SkinID="ddlRsz" TabIndex="1"
                                        Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="insertCourse" TypeName="RptDeptWiseConsolidatedFeedbackScore">
                                    </asp:ObjectDataSource>
                                </td>
                            
                        </tr>
                             <tr>
                            <td align="right" >
                                <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td>
                                   <asp:DropDownList ID="ListBatch" TabIndex="3" runat="server" AutoPostBack="True"
                                        DataSourceID="ObjBatch" DataTextField="Batch_No" DataValueField="BatchID" Width="200"
                                        SkinID="ddlRsz">
                                    </asp:DropDownList>
                              <%--  <asp:ListBox ID="" Height="50px" Width="250px" SelectionMode="Multiple" AutoPostBack ="True"
                                    DataValueField="" DataTextField="" runat="server" DataSourceID=""
                                    TabIndex="3" CssClass="Listbox"></asp:ListBox>--%>
                            </td>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport"
                                TypeName="RptDeptWiseConsolidatedFeedbackScore">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlcourseName" Name="CourseCode" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </tr>
                         <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="3" runat="server" AutoPostBack="True"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode" Width="200"
                                        SkinID="ddlRsz">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboAss"
                                        TypeName="FeeCollectionBL">
                                       <%-- <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>--%>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                        DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="DLReportsR">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ListBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="ddlsemester" DefaultValue="0" Name="SemCode" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblass" runat="server" Width="150px" Text="Assessment Type&nbsp:&nbsp&nbsp"
                                        SkinID="lblrsz"></asp:Label>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlass" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="5" DataSourceID="Objass" DataTextField="AssessmentType" DataValueField="ID"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="Objass" runat="server" SelectMethod="getassessmentAll"
                                        TypeName="DLBatchReportCardElect"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                        DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="6"
                                        AppendDataBoundItems="False" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                        TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ListBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRptType" runat="server" Text="Report Type:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRptType" runat="server" SkinID="ddl" TabIndex="7">
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
                                    <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="8">
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
                                    <asp:Button ID="btnReport" runat="server" OnClientClick="return Validate1();" TabIndex="10" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                        CssClass="ButtonClass" ></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="11" Text="BACK" CommandName="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
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

