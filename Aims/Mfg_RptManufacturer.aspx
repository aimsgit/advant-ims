<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_RptManufacturer.aspx.vb" Inherits="Mfg_RptManufacturer" title="Manufacturer Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manufacturer Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        MANUFACTURER DETAILS
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMfg" runat="server" SkinID="lbl" Text="Manuf/Comp :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp<asp:DropDownList ID="ddlMfg" runat="server" DataSourceID="ObjMfg" DataTextField="Manufaturer_Name"
                                    SkinID="ddl" AutoPostBack="true" DataValueField="Manufacturer_ID" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjMfg" runat="server" SelectMethod="GetManufacturer" TypeName="DLRptManufacturer">
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
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
