<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmPendingSo.aspx.vb" Inherits="Mfg_frmPendingSo" title=" Pending SO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pending SO</title>
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
                    Pending SO
                </h1>
            </center>
            &nbsp;
            <center>
            <table>
            <tr>
                        <td align="right">
                            <asp:Label ID="lblBuyer" SkinID="lbl" runat="server" Text="Buyer Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBuyerName" runat="server" AutoPostBack="true" DataSourceID="ObjBuyer"
                                DataTextField="Party_Name" DataValueField="Party_Id" SkinID="Rsz" TabIndex="1"
                                Width="250px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="GetBuyerNameDetails1"
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
            </ContentTemplate> 
            </asp:UpdatePanel> 


</form>
</body>
</html>
