<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BinCard.aspx.vb"
    Inherits="BinCard" Title="Bin Card" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bin Card</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLPRODUCT.ClientID%>"), 'Product');
            if (msg != "") {
                document.getElementById("<%=DDLPRODUCT.ClientID%>").focus();
                return msg;

            }
            return true;
        }

        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    BIN CARD</h1>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblProduct" runat="server" SkinID="lblRsz" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLPRODUCT" runat="server" DataSourceID="ObjProduct1" DataTextField="Product_Name"
                                Width="200" DataValueField="Product_Id" SkinID="ddlRsz" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductBinCard"
                                TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <br />
                    </caption>
                </table>
            </center>
            <center>
                <table>
                    <tr align="center">
                        <td class="btnTd" colspan="3">
                            <br />
                            <asp:Button ID="btnReport" runat="server" CausesValidation="true" CommandName="Report"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="5"
                                Text="REPORT" />
                            <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                            </asp:Button>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>

