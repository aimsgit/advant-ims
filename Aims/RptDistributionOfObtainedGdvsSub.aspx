<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptDistributionOfObtainedGdvsSub.aspx.vb" Inherits="RptDistributionOfObtainedGdvsSub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DISTRIBUTION OF OBTAINED GRADES FOR EACH SUBJECT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <%--<script type="text/javascript" language="javascript">
        function ValidReport() {
            var msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"), 'Course');
            if (msg != "") return msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"), 'Academic Year');
            if (msg != "") return msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEntryDate.ClientID %>"), 'Entry Date');
            if (msg != "") return msg;
            return true;
        }
        function ValidateReport() {

            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>--%>
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelbad" runat="server" Text="DISTRIBUTION OF OBTAINED GRADES FOR EACH SUBJECT" SkinID="lblRepRsz"
                            Width="250" Visible="True"></asp:Label></h1>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:DropDownList ID="DDLBranch" runat="server" SkinID="ddlRsz" Width="250" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" AutoPostBack="True" TabIndex="1">
                                </asp:DropDownList>
                              
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblA_Year" runat="server" Text="Academic Calendar Year*:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLA_Year" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic" Width ="200px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjAcademic" runat="server" TypeName="BLNew_stdMarks" SelectMethod="GetAcademicComboGvsSub">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLBranch" DefaultValue="0" DbType="String" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text=" Course :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddlRsz" DataSourceID="objCourse"
                                    DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="true" Width="200px"
                                    TabIndex="3">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseComboGvsSub"
                                    TypeName="BLNewCoursePlanner">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLBranch" DefaultValue="0" DbType="String" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSemester" TabIndex="4" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    Width="200px" DataValueField="SemCode" DataTextField="SemName" DataSourceID="ObjSemester">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" TypeName="StudentListDB" SelectMethod="insertSemesterGvsSub">
                                    
                                </asp:ObjectDataSource>
                            </td>
                                                     
                        </tr>
                        
                        
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblassesment" runat="server" Text="Assessment Type&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="200px" >
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentComboAllGvsSub"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                        </td>
                    </tr>
                       
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                               
                            </td>
                        </tr>
                    </table>
                    <table>
                    <tr></tr>
                        <tr>
                            <td class="btnTd" colspan="4">
                                <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                &nbsp;
                                <asp:Button ID="btnBack" TabIndex="7" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                </center>
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>