<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_AccountHeadLedger.aspx.vb"
    Inherits="Rpt_AccountHeadLedger" Title="Account Head Ledger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Account Head Ledger</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtfromdate.ClientID%>"), 'Start Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txttodate.ClientID%>"), 'End Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <%--    <center>
        <h1 class="headingTxt">
            ACCOUNT HEAD LEDGER</h1>
    </center>--%>
    <center>
        <h1 class="headingTxt">
            <asp:Label ID="Lblheading" runat="server"></asp:Label>
        </h1>
    </center>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table class="custtable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="175px" Text="Account Group :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbAGOne" runat="server" SkinID="ddlRsz" DataTextField="Acct_Group"
                                DataValueField="Acct_Group_ID" TabIndex="1" Width="250">
                                <asp:ListItem Value="0"> All</asp:ListItem>
                                <asp:ListItem Value="1">Assets</asp:ListItem>
                                <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                <asp:ListItem Value="3">Income</asp:ListItem>
                                <asp:ListItem Value="4">Expenses</asp:ListItem>
                                <asp:ListItem Value="5">Capital Account</asp:ListItem>
                                <asp:ListItem Value="6">Account Receivables</asp:ListItem>
                                <asp:ListItem Value="7">Account Payable</asp:ListItem>
                                <asp:ListItem Value="8">Cash Receipts</asp:ListItem>
                                <asp:ListItem Value="9">Cash Payments</asp:ListItem>
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
                            <asp:Label ID="lblfromdate" runat="server" SkinID="lbl" Text="Start Date*  :&nbsp;&amp;nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtfromdate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtfromdate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbltodate" runat="server" SkinID="lbl" Text="End Date*  :&nbsp;&amp;nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txttodate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    </table>
                    <table>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="btRpt" CausesValidation="true" runat="server" Text="REPORT" SkinID="btn"
                                CommandName="Report" TabIndex="5" CssClass="ButtonClass" OnClick="btRpt_Click"
                                OnClientClick="return Validate();" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
            </center>
            <center>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
