<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RPT_FinanForm.aspx.vb"
    Inherits="RPT_FinanForm" Title="General Ledger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>General Ledger</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"), 'End Date');
            if (msg != "") {
                document.getElementById("<%=txtEndDate.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
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
            <center>
                <%-- <h1 class="headingTxt">
            GENERAL LEDGER
        </h1>--%>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="175px" Text="Account Group :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbAGOne" runat="server" SkinID="ddl" DataTextField="Acct_Group"
                                DataValueField="Acct_Group_ID" TabIndex="4" AutoPostBack="true">
                                <asp:ListItem Value="0"> All</asp:ListItem>
                                <asp:ListItem Value="1">Assets</asp:ListItem>
                                <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                <asp:ListItem Value="3">Income</asp:ListItem>
                                <asp:ListItem Value="4">Expenses</asp:ListItem>
                                <asp:ListItem Value="5">Capital Account</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td align="right">
                            <asp:Label ID="lblAccSubGrp" runat="server" Text="Account Sub Group :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="170"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbAcctOne" runat="server" SkinID="ddlRsz" DataTextField="Acct_Sub_Group"
                                DataValueField="Acct_Sub_Group_ID" TabIndex="2" Width="200">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblProjectName" runat="server" Text="Project Name :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLProjectName" TabIndex="2" runat="server" SkinID="ddlRsz"
                                DataSourceID="ObjProjectName" DataValueField="ProjectID_Auto" DataTextField="Project_Name"
                                AppendDataBoundItems="true" Width="250">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProjectName" runat="server" SelectMethod="GetProjectName"
                                TypeName="DayBookManager"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnTd">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                CommandName="Report" OnClick="Btnreport_Click" Text="REPORT" SkinID="btn" TabIndex="3"
                                CssClass="ButtonClass " />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
