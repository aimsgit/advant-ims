<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAccountPayable.aspx.vb" Inherits="RptAccountPayable" title="Account Payable Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Account Payable Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
     function Valid() {
         var msg;
         msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');
         if (msg != "") return msg;
         msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"), 'End Date');
         if (msg != "") return msg;
         return true;
     }
     function Validate() {
         var msg = Valid();
         if (msg != true) {
             if (navigator.appName == "Microsoft Internet Explorer") {
                 document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                 return false;
             }
             else if (navigator.appName == "Netscape") {
                 document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                 return false;
             }
         }
         return true;
     }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                   ACCOUNT PAYABLE REPORT
                </h1>
                <br />
                <table>
                
                    <tr>
                            <td align="right">
                                <asp:Label ID="lblPartyType" runat="server" SkinID="lblRsz" Text="Party Type&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlPartyType" SkinID="ddl" AutoPostBack="true" DataSourceID="ObjPType"
                                    DataTextField="Name" DataValueField="Id" runat="server" Width="200px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPType" runat="server" SelectMethod="PartyTypeCombo" TypeName="MfgSaleInvoiceDL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" Text="Party Name :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align ="left">
                                                <asp:DropDownList ID="ddlPartyName" runat="server" SkinID="ddl" DataSourceID="ObjParty_Name"
                                                    AutoPostBack="True" DataValueField="ID" DataTextField="Name" Width ="200px">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjParty_Name" runat="server" SelectMethod="GetPartyNameddl1"
                                                    TypeName="Mfg_DLStockIssue">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlPartyType" Name="Name" Type="String" PropertyName="SelectedValue" />
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

</form>
</body>
</html>

