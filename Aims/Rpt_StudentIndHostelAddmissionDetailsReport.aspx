<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_StudentIndHostelAddmissionDetailsReport.aspx.vb"
    Inherits="Rpt_StudentIndHostelAddmissionDetailsReport" Title="Student Hostel Admission Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Hostel Admission Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourse.ClientID%>"), 'Course');
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>");
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
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
                    STUDENT INDIVIDUAL HOSTEL ADMISSION DETAILS
                </h1>
                <br />
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBranch" runat="server" Text="Branch Name*^&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlL" AutoPostBack="True"
                                DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="insertBranchCombo_Adminition"
                                TypeName="StudentIndHostelAdmissionDetailsDL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" DataTextField="CourseName" SkinID="ddlRsz"
                                Width="250" DataSourceID="ObjCourse" AutoPostBack="true" DataValueField="Courseid"
                                TabIndex="2">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourseAdd" TypeName="CourseDB">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="Branchcode"
                                        DefaultValue="0" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBatch" runat="server" DataTextField="Batch_No" SkinID="ddlRsz"
                                Width="250" DataSourceID="ObjBatch" AutoPostBack="true" DataValueField="BatchID"
                                TabIndex="3">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatch" TypeName="StudentIndHostelAdmissionDetailsDL">
                                <SelectParameters>
                                
                                <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="Branchcode"
                                        DefaultValue="0" />
                                     
                                
                                    <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" PropertyName="SelectedValue"
                                        Type="Int32" />
                                        
                                        
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStudent" runat="server" DataTextField="Name" SkinID="ddlRsz"
                                Width="250" DataSourceID="ObjStudent" DataValueField="Std_Id" TabIndex="4">
                                <asp:ListItem Value="0"> ALL</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudent" TypeName="StudentIndHostelAdmissionDetailsDL">
                                <SelectParameters>
                                
                                
                                
                                    <asp:ControlParameter ControlID="ddlBatch" Name="Batch" PropertyName="SelectedValue"
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
                                Text="REPORT" SkinID="btn" TabIndex="5" CssClass="ButtonClass " />&nbsp;
                            <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="6"
                                Text="BACK" CssClass="ButtonClass " />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>