<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudentDetailsDyn.aspx.vb"
    Inherits="RptStudentDetailsDyn" Title="STUDENT DETAILS-AICTE FORMAT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT DETAILS-AICTE FORMAT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                <br />
                    <h1 class="headingTxt">
                        STUDENT DETAILS-AICTE FORMAT
                    </h1>
                </center>
                <center>
                    <table>
                        <tbody>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Panel ID="pnlddl" runat="server" Width="406px">
                                        <table>
                                            <tbody>
                                                <%-- <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLBranch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                                            DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" Width="250">
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                <tr>
                                                    <td align="right" style="height: 15px">
                                                        <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text=" Course* :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" style="height: 15px">
                                                        <asp:DropDownList ID="DDLCourse" runat="server" SkinID="ddlRsz" DataSourceID="ObjCourse"
                                                            DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="True" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLBatch" runat="server" SkinID="ddlRsz" DataSourceID="ObjBatch"
                                                            DataTextField="Batch_No" DataValueField="BatchID" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Button ID="btnAdmission" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                            Text="REPORT" />&nbsp;
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="11"
                                                            Text="BACK" Visible="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                            <ProgressTemplate>
                                                                <div class="PleaseWait">
                                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                                </div>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="Admission" runat="server" Height="300px" ScrollBars="Auto" Width="180px">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GVAdmission" runat="server" AutoGenerateColumns="false" SkinID="GridView">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Column Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblModule" runat="server" Text='<%# Bind("COLUMN_NAME") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                                            TabIndex="3" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBx" runat="server" TabIndex="4" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table>
                        <tbody>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBranch" TypeName="DLReportsR"></asp:ObjectDataSource>--%>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetCourse" TypeName="DLStudentDetAICTE"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertBatchOpenN" TypeName="DLStudentDetAICTE">
                                        <SelectParameters>
                                            <%--<asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" PropertyName="SelectedValue" />--%>
                                            <%-- <asp:ControlParameter ControlID="DDLA_Year" Name="Aid" PropertyName="SelectedValue" />--%>
                                            <asp:ControlParameter ControlID="DDLCourse" Name="CourseID" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
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
