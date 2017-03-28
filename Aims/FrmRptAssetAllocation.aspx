<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptAssetAllocation.aspx.vb"
    Inherits="FrmRptAssetAllocation" Title="Asset Allocation Report" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Allocation Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDateN(document.getElementById("<%=txtfromdate.ClientID%>"), 'Issued Date From ');
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txttodate.ClientID%>"), 'Issued Date To');
            if (msg != "") return msg;
            return true;
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

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                <br />
                    <h1 class="headingTxt">
                        ASSET ALLOCATION</h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                    TabIndex="1">
                                    <asp:ListItem Value="0" Selected="True">Employee</asp:ListItem>
                                    <asp:ListItem Value="1">Department</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan = "2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblAssetType" runat="server" SkinID="lblRsz" Text="Asset Type :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType"
                                    DataValueField="AssetType_IDAuto" AppendDataBoundItems="true" DataTextField="AssetType_Name"
                                    SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                              
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblName" runat="server" SkinID="lblRsz" Text="Asset Name :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:DropDownList ID="ddlAssetName" runat="server" DataSourceID="cmbAssetName"
                                    DataValueField="AssetCode" DataTextField="AssetName" SkinID="ddlRsz" TabIndex="2" Width="100px"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Issued Date From :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="txtfromdate" runat="server" SkinID="txtRsz" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Issued Date To :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="txttodate" runat="server" SkinID="txtRsz" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                                </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtfromdate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
            </div>
              <asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                    TypeName="DLRptAssetAllocation"></asp:ObjectDataSource>
                                    
            <asp:ObjectDataSource ID="cmbAssetName" runat="server" SelectMethod="GetAssetNamecombo"
                                    TypeName="DLRptAssetAllocation">
              <SelectParameters>
             <asp:ControlParameter ControlID="ddlassetType" DefaultValue="0" Name="AssetType"
                                            PropertyName="SelectedValue" Type="Int16" />
               </SelectParameters>
             </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

