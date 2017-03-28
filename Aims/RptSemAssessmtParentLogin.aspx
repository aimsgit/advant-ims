<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSemAssessmtParentLogin.aspx.vb"
    Inherits="RptSemAssessmtParentLogin" Title="Semester Assessment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Assessment</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            SEMESTER ASSESSMENT</h1>
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
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lblRsz" Text="Course* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:TextBox ID="txtCrs" runat="server" SkinID="txtRsz" Width="200" TabIndex="1"
                                        Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBatch" runat="server" SkinID="txtRsz" Width="200" TabIndex="2"
                                        Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="3" runat="server" AutoPostBack="True"
                                        DataTextField="SemName" DataValueField="SemCode" Width="200" SkinID="ddlRsz">
                                    </asp:DropDownList>
                                    <%-- <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                        DataTextField="Subject_Name" Width="200" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
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
                                    <asp:TextBox ID="txtStd" runat="server" TabIndex="6" SkinID="txtRsz" Width="200"></asp:TextBox>
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
                                    <asp:Button ID="btnReport" runat="server" TabIndex="10" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
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

