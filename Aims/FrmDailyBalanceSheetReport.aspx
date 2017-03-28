<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmDailyBalanceSheetReport.aspx.vb"
    Inherits="FrmDailyBalanceSheetReport" Title="Daily Balance Sheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Daily Balance Sheet</title>
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
                <br />
                <h1 class="headingTxt">
                    DAILY BALANCE REPORT
                </h1>
                <br />
                <br />
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server" Visible="false"></asp:Label>
                </h1>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblReportType" runat="server" SkinID="lbl" Text="Report Type :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlReportType" runat="server" SkinID="ddl" DataTextField="Acct_Group"
                                DataValueField="Acct_Group_ID" TabIndex="1">
                                <asp:ListItem Value="0"> All</asp:ListItem>
                                <asp:ListItem Value="1">Cash Report</asp:ListItem>
                                <asp:ListItem Value="2">Bank Report</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnTd">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                CommandName="Report" OnClick="Btnreport_Click" Text="REPORT" SkinID="btn" TabIndex="3"
                                CssClass="ButtonClass" />
                            &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" CommandName="BACK"
                                SkinID="btn" TabIndex="11" Text="BACK" Visible="true" />
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

