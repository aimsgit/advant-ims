<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_IncomeExpenditure.aspx.vb"
    Inherits="Rpt_IncomeExpenditure" Title="Income Expenditure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Income Expenditure</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID%>").focus()
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
                <br />
                <h1 class="headingTxt">
                    INCOME AND EXPENDITURE
                </h1>
                <br />
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtStartDate"
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
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr align =" center ">
                        <td colspan="2">
                            <asp:Button ID="btnView" runat="server" CausesValidation="True" Text="VIEW" SkinID="btn"
                                CssClass="ButtonClass" TabIndex="16" OnClientClick="return Validate();" />
                            &nbsp;<asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
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
            <br />
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="400px">
                    <asp:GridView ID="GVBalanceSheet" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="100" SkinID="GridView" TabIndex="6">
                        <Columns>
                            <asp:TemplateField HeaderText="Expenditure">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hidAccGroupId" runat="server" Value='<%# Bind("Account_Group") %>' />
                                    <asp:Label ID="LabelAccGroupId1" runat="server" Text='<%# Bind("Account_SubHead") %>'></asp:Label>
                                    <asp:Label ID="LabelAccGroupId12" Visible="false" runat="server" Text='<%# Bind("Account_SubHeadCode") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkLiaAmt" runat="server" CausesValidation="False" CommandName="Edit"
                                        Font-Underline="False" Text='<%# Bind("Amt_Out","{0:n2}")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Income">
                                <ItemTemplate>
                                    <asp:Label ID="LabelAccGroupId2" runat="server" Text='<%# Bind("Account_SubHead") %>'></asp:Label>
                                    <asp:Label ID="LabelAccGroupId22" runat="server" Text='<%# Bind("Account_SubHeadCode") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkAssAmt" runat="server" CausesValidation="False" CommandName="edit"
                                        Font-Underline="False" Text='<%# Bind("Amt_In","{0:n2}")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

