<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptTechEmpDetails.aspx.vb"
    Inherits="RptTechEmpDetails" Title="Technical Employee Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>New Payroll Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlDept.ClientID %>"), 'Department');
            if (msg != "") {
                document.getElementById("<%=ddlDept.ClientID %>").focus();
                return msg;
            }
            return true;
        }

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
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server" Text="TECHNICAL EMPLOYEE DETAILS AICTE FORMAT"></asp:Label>
                    </h1>
                </center>
                <br />
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
                                                        <asp:Label ID="lblDept" runat="server" Text="Department* :&nbsp;" SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                                            DataValueField="DeptID" SkinID="ddlRsz" Width="155px" TabIndex="1">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLRptTechEmpDetails"
                                                            SelectMethod="GetDeptType"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblDesig" runat="server" Text="Designation :&nbsp;" SkinID="lblRsz"
                                                            Width="150px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="ddl" TabIndex="2" DataSourceID="odsDesig"
                                                            DataTextField="Designation" DataValueField="Designation_ID" AppendDataBoundItems="True"
                                                            AutoPostBack="True">
                                                            <asp:ListItem Value="0">All</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="odsDesig" runat="server" SelectMethod="Designation" TypeName="DLRptTechEmpDetails">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblGrade" runat="server" Text="Salary Grade :&nbsp;" SkinID="lblRsz"
                                                            Width="150px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlGrade" runat="server" SkinID="ddl" TabIndex="3" DataSourceID="objGrade"
                                                            DataTextField="Grade" DataValueField="Grade_Auto" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="objGrade" runat="server" SelectMethod="GetGrade" TypeName="DLRptTechEmpDetails">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                        <td align="right">
                            <asp:Label ID="Lbldobdoj" runat="server" Text="DOJ/DOL :&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbdojdob" runat="server" SkinID="ddl" TabIndex="4" AutoPostBack="true">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">DOJ</asp:ListItem>
                                <asp:ListItem Value="2">DOL</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                                                <%--tr>
                        <td align="right">
                            <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFromDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                TabIndex="5" MaxLength="11"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtToDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                TabIndex="6" MaxLength="11"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>--%><%--
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="7">
                                                            <asp:ListItem Value="0">Employee Name</asp:ListItem>
                                                            <asp:ListItem Value="1">Employee Code</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                               <%-- </tr>--%>
                                                <%-- </table>
                                        <br />
                                        <table>
                                            <tbody>--%>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="btnTd" align="right" colspan="2">
                                                        <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                                            TabIndex="8" OnClientClick="return Validate();" />
                                                        &nbsp;
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                                            TabIndex="9" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" >
                                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

