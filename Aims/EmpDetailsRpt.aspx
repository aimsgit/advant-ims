<%@ Page Language="VB" AutoEventWireup="false" Inherits="EmpDetailsRpt" Title="Employee Details" CodeFile="EmpDetailsRpt.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
    <script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
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
                <div>
                    <center>
                        <h1 class="headingTxt">EMPLOYEE DETAILS
                        </h1>
                    </center>
                    <br />
                </div>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLFacutlyDevelopment"
                                    SelectMethod="GetDeptTypeAll"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblGrade" runat="server" Text="Salary Code :&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlGrade" runat="server" SkinID="ddl" TabIndex="3" DataSourceID="objGrade"
                                    DataTextField="Grade" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objGrade" runat="server" SelectMethod="GetGrade" TypeName="EmpTransD"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDesig" runat="server" Text="Designation :&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="ddl" TabIndex="2" DataSourceID="odsDesig"
                                    DataTextField="Designation" DataValueField="Designation_ID"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsDesig" runat="server" SelectMethod="DesignationNEW" TypeName="EmpTransD">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlGrade" PropertyName="Selectedvalue"
                                            Name="SalaryCode" DefaultValue="0" />
                                    </SelectParameters>

                                </asp:ObjectDataSource>
                            </td>
                        </tr>

                        <tr>
                            <td align="right">
                                <asp:Label ID="Lbldobdoj" runat="server" Text="DOJ/DOR :&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbdojdob" runat="server" SkinID="ddl" TabIndex="4" AutoPostBack="true">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="1">DOJ</asp:ListItem>
                                    <asp:ListItem Value="2">DOR</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFromDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="5" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtFromDate"></ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="6" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="True"
                                    Format="dd-MMM-yyyy" TargetControlID="txtToDate"></ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="7">
                                    <asp:ListItem Value="0">Employee Name</asp:ListItem>
                                    <asp:ListItem Value="1">Employee Code</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tbody>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="btnTd">
                                    <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                        TabIndex="8" OnClientClick="return Validate();" />
                                    &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                    TabIndex="9" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>