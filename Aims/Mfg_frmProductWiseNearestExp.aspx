<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmProductWiseNearestExp.aspx.vb" Inherits="frmProductWiseNearestExp" title="Nearest Expiry" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Nearest Expiry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 <asp:UpdatePanel ID="UpdatePanal1" runat="server">
 <ContentTemplate >
 <center>
                <h1 class="headingTxt">
                    NEAREST EXPIRY
                </h1>
            </center>
             <center>
                <table>
                <tr>
                 <td align="right">
                            <asp:Label ID="lblProduct" runat="server" SkinID="lbl" Text="Product&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlProduct" runat="server" Width="250px" DataSourceID="ObjProduct" 
                                DataTextField="Product_Name" SkinID="ddlRsz" AutoPostBack="true" DataValueField="Product_Id"
                                TabIndex="1">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="GetProduct" TypeName="DLProductDetails">
                            </asp:ObjectDataSource>
                        </td>
                </tr>
                <tr>
                <td align="right">
                            <asp:Label ID="lblPurchaseInvNo"  runat="server"  SkinID="lblRsz" Text="Purchase Inv.No&nbsp:&nbsp&nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="dllPurchaseInvNo" runat="server" Width="250px" DataSourceID="ObjProductInv"
                                DataTextField="Purchase_Invoice_No" SkinID="ddlRsz" AutoPostBack="true" DataValueField="Purchase_Invoice_ID"
                                TabIndex="1">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProductInv" runat="server" SelectMethod="GetPurchaseInvoiceDetails" TypeName="DLProductDetails">
                            <SelectParameters>
                             <asp:ControlParameter ControlID="ddlProduct" PropertyName="SelectedValue" Name="productId" />
                            </SelectParameters>
                            </asp:ObjectDataSource>
                                                       
                        </td>
                
                </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStartingDate" SkinID="lbl" runat="server" Text="Start Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartingDate" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
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
            
 </ContentTemplate>
 </asp:UpdatePanel> 

</form>
</body>
</html>


