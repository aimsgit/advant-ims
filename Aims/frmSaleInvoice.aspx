<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSaleInvoice.aspx.vb"
    Inherits="frmSaleInvoice" MasterPageFile="~/PopUp.master" Title="Tax Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
         <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    TAX INVOICE</h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblInvoiceNo" runat="server" Text=" Invoice No* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInvoiceNo" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Invoice Date* :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInvdate" runat="server" TabIndex="2" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtInvdate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
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
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td align="center">
                            <asp:Label ID="lblIncludeHeader" runat="server" SkinID="lbl" Text="Include Header :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="6" runat="server" Checked="false" />
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
                            <asp:Button ID="btnView" runat="server" Text="VIEW" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " TabIndex="8" />&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="CLEAR" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " TabIndex="9" />&nbsp;
                            <asp:Button ID="btnPost" runat="server" Text="POST" SkinID="btnRsz" Width="100px"
                                CssClass="ButtonClass " TabIndex="10" />&nbsp;
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
