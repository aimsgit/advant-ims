<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmAccountGroupMapping.aspx.vb"
    Inherits="FrmAccountGroupMapping" Title="Account Group Mapping" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Account Group Mapping</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div class="mainBlock">
        <%-- <center>
            <h1 class="headingTxt">
                ACCOUNT HEAD DETAILS</h1>
        </center>--%>
        <center>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" runat="server">
                ACCOUNT GROUP MAPPING
                </asp:Label>
            </h1>
        </center>
        <br />

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="175px" Text="Account Group One*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbAGOne" runat="server" SkinID="ddl" AutoPostBack="True" DataTextField="Acct_Group"
                                    DataValueField="Acct_Group_ID" TabIndex="4">
                                    <asp:ListItem Value="0"> Select</asp:ListItem>
                                    <asp:ListItem Value="1">Assets</asp:ListItem>
                                    <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                    <asp:ListItem Value="3">Income</asp:ListItem>
                                    <asp:ListItem Value="4">Expenses</asp:ListItem>
                                    <asp:ListItem Value="5">Capital Account</asp:ListItem>
                                </asp:DropDownList>
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
                        <tr>
                            <td class="btnTd" colspan="2">
                                <center>
                                    <asp:Button ID="btnLoad" runat="server" SkinID="btn" TabIndex="10" Text="LOAD"
                                        CausesValidation="true" CssClass="ButtonClass" OnClientClick="return Validate();" />&nbsp;
                                    <asp:Button ID="btnView" runat="server" CausesValidation="False" SkinID="btn"
                                        TabIndex="11" Text="VIEW" CssClass="ButtonClass" />&nbsp;
                                    <asp:Button ID="btnUpdate" runat="server" CausesValidation="False" SkinID="btn"
                                        TabIndex="12" Text="UPDATE" CssClass="ButtonClass" />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
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
                    </table>
                </center>
                <br />
                <center>
                    <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                    <asp:Label ID="lblErrorMsg" SkinID="lblRed" runat="server"></asp:Label>
                </center>
                <br />
                <div style="float: left; width: 40%">
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="200px" Height="300px"> 
                        <asp:GridView ID="GV2" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GRIDVIEW" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="25px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkPresent1" runat="server" TabIndex="9" />
                                        <asp:HiddenField ID="IID1" runat="server" Value='<%# Bind("AG_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Group 2" HeaderStyle-HorizontalAlign ="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcct" runat="server" Text='<%# Bind("Acct_Group2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div style="float: left; width: 60%">
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="300px" Height="300px">
                        <asp:GridView ID="GV1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GRIDVIEW" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="25px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("AG_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Sub Group Id" HeaderStyle-HorizontalAlign ="Center" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Acct_Sub_Group_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Group Id" HeaderStyle-HorizontalAlign ="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Acct_Group_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Sub Group" HeaderStyle-HorizontalAlign ="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Acct_Sub_Group") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                </center> <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </ContentTemplate>
            <%--<Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>--%>
        </asp:UpdatePanel>
    </div>

</form>
</body>
</html>
