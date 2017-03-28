<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmSaleInvoicSummaryRpt.aspx.vb" Inherits="Mfg_frmSaleInvoicSummaryRpt" title="Sale Invoice Summary " %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Invoice Summary</title>
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
                   Sale Invoice Summary
                </h1>
            </center>
            
            <center>
               <table>
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
                                Format="dd-MMM-yyyy" TargetControlID="txtStartingDate" Enabled="True">
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
                                Format="dd-MMM-yyyy" TargetControlID="txtEndDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                  
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
            </center> 
             </ContentTemplate> 
             </asp:UpdatePanel> 

</form>
</body>
</html>

