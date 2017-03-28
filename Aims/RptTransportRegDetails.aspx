<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptTransportRegDetails.aspx.vb" Inherits="RptTransportRegDetails" title="Transport Registration Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Transport Registration Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

 <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbAcademic.ClientID%>"), 'Academic Year')
            if (msg != "") return msg;
            
            msg = DropDownForZero(document.getElementById("<%=cmbRoute.ClientID%>"), 'Route Name')
            if (msg != "") return msg;
            
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
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
                        TRANSPORT REGISTRATION DETAILS</h1>
                </center>
                <center>
                    <table>
                        <tr>
                      <td>&nbsp;&nbsp;</td>
                      </tr><tr>
                            <td align="right">
                                <asp:Label ID="LblAcademic" runat="server" Text="Academic Year* :&nbsp;&nbsp;" SkinID="lblRsz" ></asp:Label>
                            </td>
                           <td>
                                <asp:DropDownList ID="cmbAcademic" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                                </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                        TypeName="DLTransportRegDetails"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblRoute" runat="server" Text="Route Name* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbRoute" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True" DataValueField="RouteIDAuto"
                                    DataTextField="RouteName" DataSourceID="ObjRoute" >
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjRoute" runat="server" SelectMethod="GetRouteCombo"
                        TypeName="DLTransportRegDetails"></asp:ObjectDataSource>
                            </td>
                        </tr>
                       </table>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                             <td class="btnTd">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                    ValidationGroup="Validate" OnClientClick="return Validate();" TabIndex="3" />
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                    TabIndex="4" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
 </div>
</ContentTemplate>
</asp:UpdatePanel>

</form>
</body>
</html>

