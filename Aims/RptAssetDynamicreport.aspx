<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAssetDynamicreport.aspx.vb" Inherits="RptAssetDynamicreport" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dynamic Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="LblError" runat="server" SkinID="lblRed"></asp:Label>
        <br />
        <asp:Label ID="lblerr" runat="server" SkinID="lblred" Text=" No records to display."
            Visible="False"></asp:Label>
        <br />
    </div>
    <div>
        <center>
            <table>
                <tr>
                    <td style="width: 130px; height: 60px;" align="center">
                        <asp:Image ID="Image1" runat="server" Style="width: auto; height: 100%" />
                    </td>
                    <td>
                        <asp:Panel ID="HeaderPanel" Visible="true" Height="65px" Width="840px" runat="server"
                            HorizontalAlign="Center">
                            <asp:Label ID="lblSmallTitle" Visible="true" SkinID="lblBig" runat="server" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                            <br />
                            <asp:Label ID="lblTitle" Visible="true" runat="server" SkinID="lblSB" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" align="center">
                          <asp:Button ID="Button1" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
            <br />
                         
            <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="footerpanel" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldate" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldescription" runat="server" Text="Software by Advant Techservices India Private Limited (WebSite: www.advant-tech.com) Ph. No: (+91) 080 28605859"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
    
</body>
</html>
