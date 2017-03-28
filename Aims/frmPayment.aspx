<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPayment.aspx.vb"
    Inherits="frmPayment" Title="Payment Method" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment Method</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtPaymentMethod.ClientID%>"), 'Payment Method');
            document.getElementById("<%=txtPaymentMethod.ClientID%>").focus();
            if (msg != "") return msg;
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        //   function Validate(){
        //  var msg=Valid();
        //  if(msg!=true){
        //   if(navigator.appName=="Microsoft Internet Explorer")
        //{
        // document.getElementById("<%=msginfo.ClientID %>").innerText=msg;
        // return false;
        //}
        //else  if(navigator.appName == "Netscape")
        //{  
        // document.getElementById("<%=msginfo.ClientID %>").textContent=msg;
        // return false;
        //}   
        // return true;
        //  } 
        //  }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        PAYMENT METHOD</h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label1" runat="server" Text="Payment Method* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtPaymentMethod" runat="server" SkinID="lbl" TabIndex ="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="ADD" CssClass="ButtonClass" SkinID="btn" TabIndex ="2"
                                    OnClientClick="return Validate();" />&nbsp
                                <asp:Button ID="btnDetails" runat="server" Text="VIEW" CssClass="ButtonClass" SkinID="btn" TabIndex ="3" />&nbsp
                                &nbsp
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    &nbsp;</center>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                                        <asp:GridView ID="GridPayment" runat="server" AutoGenerateColumns="False" EnableViewState="true"
                                            SkinID="gridview" Visible="true" AllowPaging="true" PageSize="100">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" CommandName="Edit"
                                                            Text="Edit"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="true" CommandName="delete"
                                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <%--  <asp:BoundField DataField="PaymentMethodID" HeaderText="Payment Method Id" SortExpression="PaymentMethodID" ReadOnly="True" />
                                <asp:BoundField DataField="Payment_Method" HeaderText="Payment Method" SortExpression="Payment_Method" />--%>
                                                <asp:TemplateField HeaderText="Payment Method" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" Visible="false" runat="server" Text='<%# Bind("PaymentMethodID") %>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </center>
                                <asp:HiddenField ID="paymentid" runat="server" />
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