<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptStudParentUserMgmt.aspx.vb"
    Inherits="FrmRptStudParentUserMgmt" Title="Student/Parent User Management" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student/Parent User Management</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        STUDENT/PARENT USER MANAGEMENT
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
                                <asp:Label ID="Label1" runat="server" Text="Course :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataSourceID="ObjCourse1"
                                    DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" Width="250 px"
                                    TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetCourseAll"
                                    TypeName="DLRptStudParenUserMgmt"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DdlBatchName" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataSourceID="ObjBatch" DataTextField="Batch_No" DataValueField="BatchID" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetBatchAll" TypeName="DLRptStudParenUserMgmt">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="CourseID"
                                            DefaultValue="0" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="3" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="4" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
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
