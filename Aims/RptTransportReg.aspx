<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptTransportReg.aspx.vb"
    Inherits="RptTransportReg" Title="Transport Registration Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Transport Registration Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<%--<script type="text/javascript" language="javascript">
 function SplitName() {
     var text = document.getElementById("<%=ddlRouteNo.ClientID%>").value;
                  var split = text.split(':');
                  if (split.length > 0) {
                      document.getElementById("<%=ddlRouteNo.ClientID%>").innerText = split[2];
                     
                  }
              } 
               </script>--%>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            TRANSPORT REGISTRATION
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblA_Year" runat="server" Text="Academic Calendar Year*:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="250px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLA_Year" runat="server" SkinID="ddl" DataSourceID="ObjYear"
                                        TabIndex="1" DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRoute_No" runat="server" Text="Route No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRouteNo" runat="server" SkinID="ddl" DataSourceID="ObjRouteNo"
                                        TabIndex="2" DataTextField="RouteName" DataValueField="RouteID" AutoPostBack="True" >
                                        <asp:ListItem Text ="ALL" Value ="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="3" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                    <asp:Button ID="btnAdd" TabIndex="4" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetYear" TypeName="DLReportsR"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjRouteNo" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetRouteNoCombo" TypeName="DLTransportRegDetails"></asp:ObjectDataSource>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
