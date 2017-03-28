<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmSEPerformanse.aspx.vb" Inherits="Mfg_frmSEPerformanse" title=" SE Performance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SE Performance</title>
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
                    SE Performance
                </h1>
            </center>
            <center>
            <table>
            <tr>
                        <td align="right">
                            <asp:Label ID="lblBuyer" SkinID="lbl" runat="server" Text="SE Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBuyerName" runat="server" AutoPostBack="true" DataSourceID="ObjBuyer"
                                DataTextField="Party_Name" DataValueField="PartyAutoNo" SkinID="Rsz" TabIndex="1"
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
                            <asp:TextBox ID="txtStartingDate" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                 FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/" TargetControlID="txtStartingDate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                Format="yyyy-MMM-dd" TargetControlID="txtStartingDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" SkinID="lbl" runat="server" Text="End Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                  FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/" TargetControlID="txtEndDate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="yyyy-MMM-dd" TargetControlID="txtEndDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
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
            
                        
            </table>
             <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    &nbsp;
                    <asp:GridView ID="g1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" SkinID="GridView" Width="500px">
                        <Columns>
                            <asp:TemplateField HeaderText="PARTY NAME" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="LabelParty" runat="server" Text='<%#Bind("Party_Name") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SALE INVOICE NO" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSaleInvNo" runat="server" Text='<%#Bind("Sale_Invoice_No") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NET SALE VALUE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="LabelNetSaleV" runat="server" Text='<%#Bind("Sale_Amount","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="SALE DATE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblExpiry" runat="server" Text='<%#Bind("VAT_Invoice_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
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


