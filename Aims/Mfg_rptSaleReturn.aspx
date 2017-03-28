<%@ Page Title="" Language="VB" MasterPageFile="~/Home.master" AutoEventWireup="false" CodeFile="Mfg_rptSaleReturn.aspx.vb" Inherits="Mfg_rptSaleReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                       SALE RETURN
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        
                         <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSupplierM" runat="server" SkinID="lblRsz" Text="Buyer Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                            DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" Width="300px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerCombo" TypeName="MfgSaleInvoiceDL">
                                      
                                  </asp:ObjectDataSource>
                                        
                                    </td>
                        </tr>
                         <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSaleReturnNo" runat="server" SkinID="lblRsz" Text="Sale Return No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        
                                        <asp:DropDownList ID="ddlSaleReturnNo" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="objSaleReturnNo"
                                            DataTextField="SaleReturnNumber" DataValueField="Sale_ReturnMain_ID" runat="server" Width="300px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="objSaleReturnNo" runat="server" SelectMethod="SaleReturnNoCombo" TypeName="MfgSaleInvoiceDL">
                                         <SelectParameters>
                                             <asp:ControlParameter ControlID="DDlBuyer" PropertyName="SelectedValue" Name="PartyID" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                        </tr>
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblstartdate" Width="150px" runat="server" Text="Start Date :&nbsp;&nbsp;"
                                SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtstartdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtstartdate"
                                                Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtstartdate" Enabled="True">
                                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblenddate" runat="server" SkinID="lblRsz" Text="End Date :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtenddate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtenddate"
                                                Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtenddate" Enabled="True">
                                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

