<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptVoucherForm.aspx.vb"
    Inherits="RptVoucherForm" Title="Print Voucher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print Voucher</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=cmbAGOne.ClientID %>"), 'Voucher Type');
            document.getElementById("<%=cmbAGOne.ClientID%>").focus();
            if (msg != "") return msg;

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
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
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
                    PRINT VOUCHERS
                </h1>
                <br />
                <br />
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="175px" Text="Voucher Type* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAGOne" runat="server" SkinID="ddl" AutoPostBack="True" DataTextField="Acct_Group"
                                DataValueField="Acct_Group_ID" TabIndex="1">
                                <asp:ListItem Value="0"> Select</asp:ListItem>
                                <asp:ListItem Value="1">Cash Payment Vouchers</asp:ListItem>
                                <asp:ListItem Value="2">Bank Payment Vouchers</asp:ListItem>
                                <asp:ListItem Value="3">Cash Receipt</asp:ListItem>
                                <asp:ListItem Value="4">Bank Receipt</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="From Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text=" To Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="From Serial :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="160px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlS1" TabIndex="4" runat="server" SkinID="ddl" DataSourceID="objSerial"
                                DataValueField="DayBook_ID" DataTextField="Bill_No">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="To Serial :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="160px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlS2" TabIndex="5" runat="server" SkinID="ddl" DataSourceID="objSerial"
                                DataValueField="DayBook_ID" DataTextField="Bill_No">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objSerial" runat="server" SelectMethod="GetSerial" TypeName="DayBookDB">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmbAGOne" PropertyName="SelectedValue" Name="AGOne" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnTd">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                CommandName="Report" Text="REPORT" SkinID="btn" TabIndex="6" CssClass="ButtonClass" />
                            &nbsp;<asp:Button ID="BtnBack" runat="server" CausesValidation="True" CommandName="Report"
                                Text="BACK" SkinID="btn" TabIndex="7" CssClass="ButtonClass" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

