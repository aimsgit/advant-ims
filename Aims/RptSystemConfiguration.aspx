<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSystemConfiguration.aspx.vb" Inherits="RptSystemConfiguration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System Configuration</title>
     <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript">
    function Valid() {
        var msg;
        msg = DropDownForZero(document.getElementById("<%=DdlSelectClient.ClientID%>"), 'Select Client');
        if (msg != "") return msg;
        msg = DropDownForZero(document.getElementById("<%=DdlSelectBranch.ClientID%>"), 'Select Branch');
        if (msg != "") return msg;
      
        return true;
    }


    function Validate() {
        var msg = Valid();
        if (msg != true) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                return false;
            }
            else if (navigator.appName == "Netscape") {
            document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
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
                        SYSTEM CONFIGURATION
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                      <tr>
                        <td align="right">
                            <asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Width="180px" Text="Select Client*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                DataTextField="MyCo_Name" DataValueField="MyCo_Code" SkinID="ddlRsz" TabIndex="1"
                                Width="260px">
                                <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Width="180px" Text="Select Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" TabIndex="2"
                                AppendDataBoundItems="False" DataValueField="BranchCode" DataTextField="BranchName"
                                DataSourceID="ObjSelectBranch" Width="260px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectBranch" runat="server" SelectMethod="GetBranchCombo"
                                TypeName="BLClientContractMaster">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlSelectClient" DefaultValue="0" Name="Mycode"
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                      <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" OnClientClick="return Validate();" TabIndex="2" runat="server"  Text="REPORT" SkinID="btn"
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

