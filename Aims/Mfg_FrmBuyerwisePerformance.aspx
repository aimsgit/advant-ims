<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmBuyerwisePerformance.aspx.vb"
    Inherits="Mfg_FrmBuyerwisePerformance" Title="Buyer wise Perfomance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Buyer wise Perfomance</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        BUYER WISE PERFORMANCE
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblbuyer" runat="server" SkinID="lbl" Text="Buyer&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                    DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" TabIndex="1"
                                    Width="300px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerComboAll" TypeName="Mfg_DLBuyerwiseSale">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
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

