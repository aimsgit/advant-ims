<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSalaryRepay.aspx.vb" Inherits="RptSalaryRepay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Salary Repay Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script type="text/javascript" language="javascript">
        function ValidReport() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlYear.ClientID %>"), 'Year');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlMonth.ClientID %>"), 'Month');
            if (msg != "") return msg;
           
            return true;
        }
        function ValidateReport() {

            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    SALARY REPAY REPORT
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
                            <asp:ObjectDataSource ID="ObjDept1" runat="server" TypeName="DLRptIndividualEmployeeDetails"
                                SelectMethod="GetDepartmentSal"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    </table>
                    <br />
                    <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblyear" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmonth" runat="server" SkinID="lblRSZ" Text="Month&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddl" TabIndex="3">
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
                      </table>
                      <table >
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="btnReport" runat="server" OnClientClick="return ValidateReport();"
                                CssClass="ButtonClass" SkinID="btn" Text="REPORT" />&nbsp;
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

