<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmBalanceSheetReportaspx.aspx.vb"
    Inherits="FrmBalanceSheetReportaspx" Title="Balance Sheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Balance Sheet</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"), 'End Date');
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
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <%--  <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    BALANCE SHEET
                </h1>
                <br />
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                            <asp:Label ID="Label2" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnView" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="VIEW" SkinID="btn" CssClass="ButtonClass" TabIndex="16" />
                            &nbsp;<asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                CommandName="Report" OnClick="Btnreport_Click" Text="REPORT" SkinID="btn" CssClass="ButtonClass"
                                TabIndex="15" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
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
            <br />
            <center>
                <%--<asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="350px" Height="300px">--%>
                <asp:GridView ID="GVBalanceSheet" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="100" SkinID="GridView" TabIndex="6">
                    <Columns>
                        <asp:TemplateField HeaderText="Account Group">
                            <ItemTemplate>
                                <asp:HiddenField ID="hidAccGroupId" runat="server" Value='<%# Bind("Acct_Group_ID") %>' />
                                <asp:Label ID="LabelAccGroupId1" Width="50" runat="server" Text='<%# Bind("Acct_Group2") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Sub Group">
                            <ItemTemplate>
                                <asp:HiddenField ID="hidAccSubGroupId" runat="server" Value='<%# Bind("Acct_Sub_Group_ID") %>' />
                                <asp:Label ID="lblLiabilities" Width="150" runat="server" Text='<%# Bind("Acct_Sub_Group") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkLiaAmt" runat="server" CausesValidation="False" CommandName="Edit"
                                    Font-Underline="False" Text='<%# Bind("Amount","{0:n2}")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Group">
                            <ItemTemplate>
                                <asp:Label ID="LabelAccGroupId2" Width="50" runat="server" Text='<%# Bind("Acct_Group2") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Sub Group">
                            <ItemTemplate>
                                <asp:Label ID="lblAsset" runat="server" Width="150" Text='<%# Bind("Acct_Sub_Group") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkAssAmt" runat="server" CausesValidation="False" CommandName="edit"
                                    Font-Underline="False" Text='<%# Bind("Amount","{0:n2}")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Wrap="false" />
                            <HeaderStyle HorizontalAlign="right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table>
                    <tr>
                        <td style="width: 145px;" align="left">
                            <asp:Label ID="lblGrandTotal" runat="server" Text="GrandTotal&nbsp;:&nbsp;&nbsp;"
                                Visible="false" Width="100" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td style="width: 140px;" align="right">
                            <asp:Label ID="lblSumLia" runat="server" Text='<%# Bind("LblSumLiab") %>' SkinID="lblRsz"
                                Width="180"></asp:Label>
                        </td>
                        <td style="width: 330px;" align="right">
                            <asp:Label ID="lblSumAsset" runat="server" Text='<%# Bind("LblSumAsset") %>' SkinID="lblRsz"
                                Width="280"></asp:Label>
                        </td>
                    </tr>
                </table>
                <%-- </asp:Panel>--%>
            </center>
            <%--<a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" />
                    </a>
                    
                </div>
            </a>--%>
            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
