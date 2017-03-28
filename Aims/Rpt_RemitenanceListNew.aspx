<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_RemitenanceListNew.aspx.vb" Inherits="Rpt_RemitenanceListNew" title="REMITTANCE LIST" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>REMITTANCE LIST</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script type="text/javascript" language="javascript">
        function ValidReport() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlItem.ClientID %>"), 'Items');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlYear.ClientID %>"), 'Year');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlMonth.ClientID %>"), 'Month');
            if (msg != "") return msg;

            return true;
        }
        function ValidateReport() {

            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    REMITTANCE LIST
                </h1>
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblItem" runat="server" Text="Items* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlItem" runat="server" SkinID="ddlRsz" DataTextField="Data" Width ="250px"
                                DataValueField="LookUpAutoID" TabIndex="1" DataSourceID="cmbItem">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="cmbItem" runat="server" SelectMethod="GetItemddl"
                                TypeName="AssetDetailsDB"></asp:ObjectDataSource>
                        </td>
                      
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label48" runat="server" Text="Mode Of Payment :&nbsp;&nbsp" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlpaymentmethod" runat="server" SkinID="ddl" DataTextField="Payment_Method"
                                DataValueField="PaymentMethodID" TabIndex="2" DataSourceID="cmbpaymentmethod">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="cmbpaymentmethod" runat="server" SelectMethod="GetPaymentMethodcombo12"
                                TypeName="AssetDetailsDB"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBank" runat="server" SkinID="lbl" Text="Bank :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                DataValueField="Bank_IDAuto" AppendDataBoundItems="true" SkinID="ddl" TabIndex="3">
                                <%--<asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>--%>
                                <%--<asp:ListItem Value="*">Others</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="BankComboD" TypeName="DLAnnualSalaryStatment">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblyear" runat="server" SkinID="lbl" Text="Year :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="4">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblmonth" runat="server" SkinID="lbl" Text="Month :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddl" TabIndex="5">
                                <asp:ListItem Text="January" Value="January"></asp:ListItem>
                                <asp:ListItem Text="February" Value="February"></asp:ListItem>
                                <asp:ListItem Text="March" Value="March"></asp:ListItem>
                                <asp:ListItem Text="April" Value="April"></asp:ListItem>
                                <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                <asp:ListItem Text="June" Value="June"></asp:ListItem>
                                <asp:ListItem Text="July" Value="July"></asp:ListItem>
                                <asp:ListItem Text="August" Value="August"></asp:ListItem>
                                <asp:ListItem Text="September" Value="September"></asp:ListItem>
                                <asp:ListItem Text="October" Value="October"></asp:ListItem>
                                <asp:ListItem Text="November" Value="November"></asp:ListItem>
                                <asp:ListItem Text="December" Value="December"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="center" >
                        <td colspan="5">
                            <asp:Button ID="btnReport" runat="server" OnClientClick="return ValidateReport();"
                                CssClass="ButtonClass" SkinID="btn" Text="REPORT" TabIndex="7" />&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="7"
                                Text="BACK" Visible="true" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed" />
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

