<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmClientContractTaxInvoice.aspx.vb"
    Inherits="FrmClientContractTaxInvoice" Title="Tax Invoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tax Invoice</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    TAX INVOICE</h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYearTo" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSDate" runat="server" SkinID="lblRSZ" Text="From &nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbFrom" runat="server" SkinID="ddl" TabIndex="3">
                                <%-- <asp:ListItem Value="0" Text="Select"></asp:ListItem>--%>
                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <%--    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="MMM-yyyy" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>--%>
                        </td>
                        <%--   <td>
                                &nbsp;
                            </td>--%>
                        <td align="right">
                            <asp:Label ID="lblEDate" runat="server" SkinID="lblRSZ" Text="To &nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="CmbTo" runat="server" SkinID="ddl" TabIndex="5">
                                <%-- <asp:ListItem Value="0" Text="Select"></asp:ListItem>--%>
                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <%--  <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="MMM-yyyy" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>--%>
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Text="Select Client&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                AppendDataBoundItems="true" DataTextField="MyCo_Name" DataValueField="MyCo_Code"
                                SkinID="ddlRsz" TabIndex="1" Width="260px">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:Button ID="BtnPrint" runat="server" Text="REPORT" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Text="Select Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
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
                            <asp:Label ID="lblInvoiceNo" runat="server" Text=" Invoice No^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInvoiceNo" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Invoice Date* :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInvdate" runat="server" TabIndex="2" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtInvdate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td align="center">
                            <asp:Label ID="lblIncludeHeader" runat="server" SkinID="lbl" Text="Include Header :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="6" runat="server" Checked="true" />
                        </td>
                    </tr>
                    <tr align="center">
                        <td align="center">
                            <asp:Label ID="lblAdvance" runat="server" SkinID="lbl" Text="Advance Invoice :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkAdvance" SkinID="chk" TabIndex="6" runat="server" Checked="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td align="center">
                            <asp:Button ID="btnGenerate" runat="server" Text="GENERATE" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " TabIndex="7" />&nbsp;
                            <asp:Button ID="BtnView" runat="server" Text="VIEW" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " />&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="CLEAR" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " TabIndex="9" OnClientClick="return confirm('Do you want to clear the selected record(s)?')"/>&nbsp;
                            <asp:Button ID="btnPost" runat="server" Text="POST" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " TabIndex="10" />&nbsp;
                            <asp:Button ID="BtnCancel" runat="server" Text="CANCEL INVOICE" SkinID="btnRsz" Width="150px"
                                CssClass="ButtonClass " TabIndex="11" />&nbsp;
                            <asp:Button ID="btnEmail" TabIndex="4" runat="server" Text="SEND EMAIL" SkinID="btnRsz"
                                CommandName="EMAIL" CssClass="ButtonClass" Width="130px"></asp:Button>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed" />
                            <asp:Label ID="lblmsgG" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="600px">
                                <asp:GridView ID="GVTaxInvoice" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                    AllowPaging="True" EnableViewState="true" TabIndex="10" PageSize="100">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkBx" runat="server"></asp:CheckBox>
                                                <asp:Label ID="lblPKID" runat="server" Text='<%# Bind("PID") %>' Visible="false"></asp:Label>
                                                <%--<asp:Label ID="lblPreAudit" runat="server" Text='<%# Bind("PreAudit") %>' Visible="false"></asp:Label>--%>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="BranchName" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="lblBranch_Code" runat="server" Value='<%#Bind("Branchcode") %>' />
                                                <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblYear" runat="server" Text='<%# Bind("FromYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Month" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMonth" runat="server" Text='<%# Bind("FromDate") %>'></asp:Label>
                                                <asp:Label ID="lblMonthNo" runat="server" Text='<%# Bind("Month") %>' Visible="false"></asp:Label>
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
                                                <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("TotalAmount","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Post Status" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTax" runat="server" Text='<%# Bind("Post_Flag") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cancel Status" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Cancel_Flag") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
