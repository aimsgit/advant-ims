<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpttrialbalance.aspx.vb"
    Inherits="rpttrialbalance" Title="Trial Balance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Trial Balance</title>
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

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <%--    <h1 class="headingTxt">
            TRIAL BALANCE
        </h1>--%>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblsdate" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                            <asp:Label ID="lbledate" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
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
                            <asp:Button ID="btnView" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="VIEW" SkinID="btn" CssClass="ButtonClass" TabIndex="3" />
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                CommandName="Report" OnClick="Btnreport_Click" Text="REPORT" SkinID="btn" TabIndex="4"
                                CssClass="ButtonClass" />
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
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="400px">
                    <asp:GridView ID="GVTrialBalance" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="100" SkinID="GridView" TabIndex="6">
                        <Columns>
                            <asp:TemplateField HeaderText="Account Sub Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" Width="150px" runat="server" Visible="false" Text='<%# Bind("Acct_SubGroup_ID") %>'></asp:Label>
                                    <%--<asp:HiddenField ID="hidAccGroupId" runat="server" Value='<%# Bind("Acct_SubGroup_ID") %>' />--%>
                                    <asp:Label ID="LabelAccGroupId" runat="server" Text='<%# Bind("Acct_Sub_Group") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit">
                                <%--   <ItemTemplate>
                                
                                <asp:Label ID="lblcredit" Width="150" runat="server" Text='<%# Bind("Amt_In","{0:n2}") %>'></asp:Label>
                            </ItemTemplate>
                              <ItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link" Width="150px" runat="server" CausesValidation="False" CommandName="Edit"
                                        Font-Underline="False" Text='<%# Bind("Amt_In","{0:n2}")   %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Debit">
                                <%--  <ItemTemplate>
                            
                              <asp:Label ID="lbldebit" Width="150" runat="server" Text='<%# Bind("Amt_Out","{0:n2}") %>'></asp:Label>
                            </ItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link2" Width="150px" runat="server" CausesValidation="False" CommandName="Edit"
                                        Font-Underline="False" Text='<%# Bind("Amt_Out","{0:n2}")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
      <center>
  
</form>
</body>
</html>

