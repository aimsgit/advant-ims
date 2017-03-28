<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_rptSEAnalysis.aspx.vb"
    Inherits="Mfg_rptSEAnalysis" Title="SE ANALYSIS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SE ANALYSIS</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlSelect.ClientID %>"), 'Sale Type ');
            if (msg != "") {
                document.getElementById("<%=ddlSelect.ClientID %>").focus();
                return msg;
            } 
          
            return true;
            }
      
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
            <div>
                <center>
                    <h1 class="headingTxt">
                        SE ANALYSIS
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSelectId" runat="server" SkinID="lbl" Text="Sale Type*:"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:DropDownList ID="ddlSelect" runat="server" SkinID="ddl" Width="250px" DataTextField="SE"
                                     AutoPostBack="true" TabIndex="1">
                                    <asp:ListItem Value="0"> Select</asp:ListItem>
                                    <asp:ListItem Text="Company Wise sale" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Supplier Wise sale" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Invoice Wise sale" Value="3"></asp:ListItem>
                                    <%--<asp:ListItem Text = "Daily sale" Value ="4"></asp:ListItem>--%>
                                    <asp:ListItem Text="Product Wise sale" Value="5"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMfg" runat="server" SkinID="lbl" Text="Company :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:DropDownList ID="ddlMfg" runat="server" Width="250px" DataSourceID="ObjMfg"
                                    DataTextField="Manufaturer_Name" SkinID="ddl" AutoPostBack="true" DataValueField="Manufacturer_ID"
                                    TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjMfg" runat="server" SelectMethod="GetManufacturer" TypeName="DLRptManufacturer">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstartdate" Width="150px" runat="server" Text="Start Date :"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="txtstartdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
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
                                <asp:Label ID="lblenddate" runat="server" SkinID="lblRsz" Text="End Date :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="txtenddate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
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
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn" OnClientClick="return Validate();"
                                    CssClass="ButtonClass"></asp:Button>&nbsp;
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
