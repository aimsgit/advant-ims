<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmClientContractMonthlyRun.aspx.vb"
    Inherits="frmClientContractMonthlyRun" Title="Monthly Run" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Monthly Run</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="javascript" type="text/javascript">
        function Valid() {
            var msg;
            //            msg = DropDownForZero(document.getElementById("<%=DdlSelectClient.ClientID %>"), 'Select Client');
            //            if (msg != "") return msg;
            //            msg = DropDownForZero(document.getElementById("<%=DdlSelectBranch.ClientID %>"), 'Select Branch');
            //            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
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
                <h1 class="headingTxt">
                    MONTHLY RUN</h1>
            </center>
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="600px">
                <center>
                    <table>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Text="Select Client&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                    AppendDataBoundItems="true" DataTextField="MyCo_Name" DataValueField="MyCo_Code"
                                    SkinID="ddlRsz" TabIndex="1" Width="260px">
                                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                    TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Text="Select Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    TabIndex="2" AppendDataBoundItems="False" DataValueField="BranchCode" DataTextField="BranchName"
                                    DataSourceID="ObjSelectBranch" Width="260px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectBranch" runat="server" SelectMethod="GetBranchComboAll1"
                                    TypeName="DLClientContractMaster">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlSelectClient" DefaultValue="0" Name="Mycode"
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblfrmMonth" runat="server" SkinID="lbl" Text="From Month* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlfrmMonth" runat="server" AutoPostBack="true" SkinID="ddl"
                                    TabIndex="3">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTomonth" runat="server" SkinID="lbl" Text="To Month* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddltomonth" runat="server" AutoPostBack="true" SkinID="ddl"
                                    TabIndex="4">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;&nbsp;<asp:Label ID="lblFrmYear" runat="server" SkinID="lbl" Text="From Year* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlFrmYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="5">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;<asp:Label ID="lblToYear" runat="server" SkinID="lbl" Text="To Year* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddltoYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="6">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ddlYear"
                                    TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <table>
                            <tr align="center">
                                <td align="center">
                                    <asp:Button ID="btnGen" runat="server" CssClass="ButtonClass " SkinID="btnRsz" Width="120px"
                                        TabIndex="7" Text="GENERATE" CausesValidation="true" OnClientClick="return validate();" />&nbsp;
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass " SkinID="btn" TabIndex="8"
                                        Text="VIEW" />&nbsp;
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass " SkinID="btn" TabIndex="9"
                                        Text="UPDATE" />&nbsp;
                                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" SkinID="btnRsz" Width="100px"
                                        CssClass="ButtonClass " TabIndex="9" OnClientClick="return confirm('Do you want to clear the selected record(s)?')" />&nbsp;
                                    <asp:Button ID="btnLockUnlock" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btnRsz" Width="120" TabIndex="8" Text="LOCK/UNLOCK" Enabled="False" />
                                </td>
                            </tr>
                        </table>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr style="width: 620px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                        AllowPaging="True" EnableViewState="true" TabIndex="10" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Client" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="lblClient" runat="server" Value='<%#Bind("ClientID") %>' />
                                                    <asp:Label ID="lblselectClient" runat="server" Text='<%# Bind("MyCo_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BranchName" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="lblBranch_Code" runat="server" Value='<%#Bind("Branch_Code") %>' />
                                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Month" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonth" runat="server" Text='<%# Bind("Month") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Count" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstdcount" runat="server" Text='<%# Bind("STDCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SMS Count" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsmsCount" runat="server" Text='<%# Bind("SMSCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Count" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemailCount" runat="server" Text='<%# Bind("EmailCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice No.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtInvNo" runat="server" Text='<%# Bind("InvoiceNo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Amount" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("InvoiceAmount","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTax" runat="server" Text='<%# Bind("Tax","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pre Audit" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBx" runat="server"></asp:CheckBox>
                                                    <asp:Label ID="lblPKID" runat="server" Text='<%# Bind("PKID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblPreAudit" runat="server" Text='<%# Bind("PreAudit") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Received" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBx1" runat="server"></asp:CheckBox>
                                                    <asp:Label ID="lblReceived" runat="server" Text='<%# Bind("Received") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
            </asp:Panel>
            </td> </tr> </table> </center> </center>
            <center>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false" DefaultButton="btnPassword">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                            OnClientClick="btnPassword_click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
