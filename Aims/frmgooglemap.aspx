<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmgooglemap.aspx.vb" Inherits="frmgooglemap"
    Title="Google Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TRANSPORT LOCATION</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlRouteName.ClientID%>"), 'RouteName');
            if (msg != "") {
                document.getElementById("<%=ddlRouteName.ClientID%>").focus();
                return msg;
            }

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
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = "";
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
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        TRANSPORT LOCATION
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRouteName" runat="server" Text="Route Name*&nbsp:&nbsp; " SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRouteName" runat="server" AutoPostBack="True" DataSourceID="objRouteName"
                                    DataTextField="RouteName" DataValueField="RouteIDAuto" SkinID="ddl" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objRouteName" runat="server" SelectMethod="GetRouteName"
                                    TypeName="DLTransportAndroid"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="right">
                                <asp:Label ID="lblDate" runat="server" Text="Date*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtDate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <center>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="btn" Text="VIEW" ValidationGroup="VIEW" TabIndex="4" />
                                </td>
                            </tr>
                        </center>
                    </table>
                    <center>
                        <br />
                        <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                        <br />
                        <br />
                    </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
