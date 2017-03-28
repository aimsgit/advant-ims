<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBatchReport.aspx.vb"
    Inherits="frmBatchReport" Title="Batch Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
 
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                <br />
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelbd" runat="server" Text="BATCH DETAILS" SkinID="lblRepRsz" Width="250"
                            Visible="True"></asp:Label>
                    </h1>
                </center>
                <table>
                   
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
                                <asp:Label ID="lblcourse" runat="server" Text="Course:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbCourse" TabIndex="1" runat="server" SkinID="ddlRsz" DataSourceID="objCourse"
                                    AppendDataBoundItems="true" DataTextField="CourseName" DataValueField="CourseCode"
                                    Width="200">
                                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="Label3" runat="server" Text="Academic Calendar Year :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Style="margin-left: 0px" Width="250px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbAcademic" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="3" runat="server" Text="REPORT" SkinID="btn" CommandName="REPORT" 
                                    CssClass="ButtonClass"></asp:Button>&nbsp;
                                <asp:Button ID="btnBack" TabIndex="4" runat="server" Text="BACK" CommandName="BACK"  SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                        </tr>
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAllAcademicCombo"
                                    TypeName="DBatchReport"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo"
                                    TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                            </td>
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
