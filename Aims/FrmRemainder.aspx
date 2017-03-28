<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRemainder.aspx.vb" Inherits="FrmRemainder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reminder</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label><br />
                    <br />
                </h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td align="center" colspan="2" valign="top">
                            <asp:Button ID="btnLoad" TabIndex="2" runat="server" CssClass="ButtonClass" 
                                SkinID="btnrsz" Width="150" Text="LOAD REMINDERS" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" valign="top">
                            <asp:Button ID="BtnSend" TabIndex="2" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btnrsz" Width="150" Text="SEND REMINDERS" />
                        </td>
                        <tr align="center">
                            <td align="Center" valign="top">
                                <asp:CheckBox ID="CheckSMS" runat="server" AutoPostBack="true" TabIndex="3" Text="SMS"
                                    Value="1" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckEmail" runat="server" AutoPostBack="true" TabIndex="4" Text="Email"
                                    Value="2" />
                                <br />
                            </td>
                        </tr>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblRed1" runat="server" Text="" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblGreen1" runat="server" Text="" SkinID="lblGreen"></asp:Label>
                    </td>
                </tr>
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
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td align="center" colspan="2" rowspan="6" valign="top">
                            <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Height="300px" Width="700px">
                                <asp:GridView ID="GVName" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="500px">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                    Text="ALL" Width="20px" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkIndividual" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Center" Visible="true">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblID" runat="server" Text='<%# Bind("ClientID") %>' Visible="false"></asp:Label>--%>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                <%--<asp:Label ID="lblEmp_Code" runat="server" Text='<%# Bind("Emp_Code") %>' Visible="false"></asp:Label>--%>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email ID" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("ContactEmailID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCellPhone" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Date" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle horizontalalign="Center" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("TotalAmount","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle horizontalalign="Right" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pending Days" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpending" runat="server" Text='<%# Bind("PendingDays") %>'></asp:Label>
                                            </ItemTemplate>
                                           <ItemStyle    />
                                            <ItemStyle HorizontalAlign ="Right" Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </center>
            </center> <a name="Bottom">
                <div align="right">
                    <a href="#Top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
