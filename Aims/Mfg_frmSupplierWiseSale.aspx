<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmSupplierWiseSale.aspx.vb"
    Inherits="Mfg_frmSaleInvoiceSummary" Title="Supplire Wise Sale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Supplier Wise Sale</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanal1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    SUPPLIER WISE SALE
                </h1>
            </center>
            &nbsp;
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBuyer" SkinID="lbl" runat="server" Text="Supplier&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBuyerName" runat="server" AutoPostBack="true" DataSourceID="ObjBuyer"
                                DataTextField="Supp_Name" DataValueField="Supp_Id" SkinID="ddlRsz" TabIndex="1"
                                Width="250px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="GetBuyerNameDetails"
                                TypeName="Mfg_DLBuyerDetails"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStartingDate" SkinID="lbl" runat="server" Text="Start Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                             <asp:TextBox ID="txtStartingDate" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                  FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/" TargetControlID="txtStartingDate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtStartingDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" SkinID="lbl" runat="server" Text="End Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                  FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/" TargetControlID="txtEndDate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtEndDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="2">
                            <asp:Button ID="btnReport" runat="server" CausesValidation="False" CommandName="Insert"
                                CssClass="ButtonClass" SkinID="btn" TabIndex="14" Text="REPORT" />
                            &nbsp;<asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="15" Text="BACK" />
                                
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
            </center>
            &nbsp
            <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    &nbsp;
                    <asp:GridView ID="g1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="100" SkinID="GridView" Width="368px">
                        <Columns>
                         <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" TabIndex="15" runat="server" CausesValidation="false"
                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" TabIndex="16" CausesValidation="false"
                                            CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>71    
                                        <asp:Label ID="lblBuyer" runat="server" Text='<%#Bind("Party_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

