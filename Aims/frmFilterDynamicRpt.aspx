<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmFilterDynamicRpt.aspx.vb"
    Inherits="frmFilterDynamicRpt" Title="ADMISSION REGISTER" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ADMISSION REGISTER</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        ADMISSION REGISTER
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
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLBranch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                                            DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" Width="250" TabIndex="1">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblA_Year" runat="server" Text="Academic Year*:&nbsp;&nbsp;" SkinID="lblRsz"
                                                            Width="150px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLA_Year" runat="server" SkinID="ddl" DataSourceID="ObjYear"
                                                            DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="right" style="height: 15px">
                                                        <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text=" Course :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" style="height: 15px">
                                                        <asp:DropDownList ID="DDLCourse" runat="server" SkinID="ddlRsz" DataSourceID="ObjCourse"
                                                            DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="True" Width="200" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLBatch" runat="server" SkinID="ddlRsz" DataSourceID="ObjBatch"
                                                            DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" Width="200" TabIndex="3">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label1" runat="server" Text="Fee Collected :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlFeecollected" runat="server" SkinID="ddl" AppendDataBoundItems="true"
                                                            DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="4">
                                                            <asp:ListItem Value="A">All</asp:ListItem>
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblGender" runat="server" SkinID="lbl" Text="Gender :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLGender" runat="server" SkinID="ddl" TabIndex="5">
                                                            <asp:ListItem Text="All" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Male" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Female" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--    <td align="right">
                                                        <asp:Label ID="lblCountry" runat="server" SkinID="lbl" Text="Country :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLCountry" runat="server" SkinID="ddl" DataSourceID="objCountry"
                                                            DataTextField="Country" DataValueField="countryId" TabIndex="7">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="objCountry" runat="server" TypeName="EnquiryManager" SelectMethod="getCountry">
                                                        </asp:ObjectDataSource>--%>
                                                    <td align="right">
                                                        <asp:Label ID="lblCountry" runat="server" Text="Country :&nbsp;" SkinID="lbl"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:DropDownList ID="DDLCountry" runat="server" AppendDataBoundItems="True" DataSourceID="ObjCountry"
                                                            DataTextField="Country" AutoPostBack="true" DataValueField="countryId" SkinID="ddl"
                                                            TabIndex="6">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjCountry" runat="server" SelectMethod="CountryCombo1"
                                                            TypeName="StudentDB"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--<td align="right">
                                                        <asp:Label ID="lblState" runat="server" SkinID="lbl" Text="Province/State :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLState" runat="server" DataSourceID="ObjState" DataTextField="StateName"
                                                            DataValueField="StateId" SkinID="ddl">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                                            SelectMethod="GetState1" TypeName="EnquiryDB">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="DDLCountry" Name="CountryId" PropertyName="SelectedValue" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </td>--%>
                                                    <td align="right">
                                                        <asp:Label ID="lblState" runat="server" SkinID="lbl" Text="Province/State :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:DropDownList ID="DDLState" runat="server" DataSourceID="ObjState" DataTextField="StateName"
                                                            DataValueField="StateId" SkinID="ddl" TabIndex="7" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjState" runat="server" SelectMethod="GetStateEmpMaster1"
                                                            TypeName="StudentDB">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" Name="countryId"
                                                                    DefaultValue="0" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
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
                                                        <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Button ID="btnAdmission" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                                            Text="REPORT" />&nbsp;
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="9"
                                                            Text="BACK" Visible="true" />
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
                                                                            TabIndex="10" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBx" runat="server" TabIndex="11" />
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
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBranch" TypeName="DLReportsR"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetCourse" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <%--            <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetYear" TypeName="DLReportsR"></asp:ObjectDataSource>--%>
                                    <%--<asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBatch1" TypeName="StudentB">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DDLA_Year" Name="Aid" Type="Int32" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DDLCourse" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertBatchOpenN" TypeName="StudentListDB">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" PropertyName="SelectedValue" />
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
