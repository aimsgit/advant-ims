<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCoursePlannerRpt.aspx.vb"
    Inherits="frmCoursePlannerRpt" Title="Course Planner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course Planner</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
            <br />
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelcp" runat="server" Text="COURSE PLAN" SkinID="lblRepRsz"
                                        Width="250" Visible="True"></asp:Label>
                        
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcourse" runat="server" Text="Course:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" TabIndex="1" runat="server" SkinID="ddlRsz" DataSourceID="objCourse"
                                    DataTextField="CourseName" DataValueField="CourseCode" AppendDataBoundItems="true" Width="200">
                                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                            <td><br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                               
                                <asp:Button ID="BtnRpt" TabIndex="2" runat="server" Text="REPORT" CausesValidation="True" CommandName="REPORT"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
                            </td>
                            <td align="left">
                                &nbsp;<asp:Button ID="BtnBack" TabIndex="3" runat="server" Text="BACK" CausesValidation="False" CommandName="BACK"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo"
                                    TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
