<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_AnnualDeduction.aspx.vb" Inherits="Rpt_AnnualDeduction" title="Annual Deduction Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Annual Deduction Report</title>
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
                   ANNUAL DEDUCTION REPORT
                </h1>
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDept" runat="server" Text="Department&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept1" DataTextField="DeptName"
                                DataValueField="DeptID" SkinID="ddlRsz" Width="200px" TabIndex="2" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDept1" runat="server" TypeName="DLRptAnnualDeduction"
                                SelectMethod="GetDepartment"></asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" Text="Employee Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlEmpName" runat="server" DataSourceID="ObjEmpName" DataTextField="Emp_Name"
                                DataValueField="EmpID" SkinID="ddlRsz" Width="200px" TabIndex="5" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjEmpName" runat="server" TypeName="DLRptAnnualDeduction"
                                SelectMethod="GetEmpNameCombo">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlDept" DefaultValue="0" Name="DeptId" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="DLRptAnnualDeduction">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYearTo" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSDate" runat="server" SkinID="lblRSZ" Text="From &nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFrom" runat="server" SkinID="ddl" TabIndex="3">
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblEDate" runat="server" SkinID="lblRSZ" Text="To &nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlTo" runat="server" SkinID="ddl" TabIndex="5">
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align ="center" >
                            <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT" />&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="11"
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
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>


