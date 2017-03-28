<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_AdmissionCriteria.aspx.vb"
    Inherits="Rpt_AdmissionCriteria" Title="Admission Criteria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admission Criteria</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    ADMISSION CRITERIA
                </h1>
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" Text="Course Type :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbCourseType" TabIndex="25" runat="server" SkinID="ddl" AutoPostBack="True"
                                DataSourceID="ObjCourseType" DataTextField="CourseType" DataValueField="CourseType_ID"
                                AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" Text="Course Name :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCourse" TabIndex="26" runat="server" SkinID="ddlRsz" DataSourceID="ObjCourse"
                                DataTextField="CourseName" DataValueField="Courseid" Width="200px" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="0" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="btnReport" runat="server" OnClientClick="return ValidateReport();"
                                CssClass="ButtonClass" CommandName="REPORT" SkinID="btn" Text="REPORT" />&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" CommandName="BACK" SkinID="btn" TabIndex="11"
                                Text="BACK" Visible="true" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed" />
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="ObjCourseType" runat="server" TypeName="CourseDB" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetCourseTypeExt"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjCourse" runat="server" TypeName="CourseDB" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetCourseByTypeExt">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbCourseType" DefaultValue="0" Name="Course_ID"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>