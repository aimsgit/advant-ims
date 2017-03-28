<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MfgFrmSaleInvoice.aspx.vb"
    Inherits="MfgFrmSaleInvoice" Title="Sale Invoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Invoice</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDlBuyer.ClientID %>"), 'Buyer');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEntryDate.ClientID %>"), 'Entry Date');
            if (msg != "") return msg;

            msg = ValidateDate(document.getElementById("<%=txtInvDate.ClientID %>"), 'Invoice Date');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlPaymentMethod.ClientID %>"), 'Payment Method');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtSaleInvNo.ClientID %>"), 'Sale Invoice No');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
       
    </script>

    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLRM.ClientID %>"), 'Item Description');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=DDLBatch.ClientID %>"), 'Batch');
            if (msg != "") return msg;
            msg = Field1(document.getElementById("<%=txtTotalQty1.ClientID %>"), 'Total Qty');
            if (msg != "") return msg;
            msg = Field1(document.getElementById("<%=lblMRP.ClientID %>"), 'MRP');
            if (msg != "") return msg;

            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblRed.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblRed.ClientID %>").innerText = "";
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                    BackColor="#E2E3BB">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="SALE INVOICE" TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        SALE INVOICE
                                    </h1>
                                </center>
                                <br />
                                <br />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblbuyer" runat="server" SkinID="lblRsz" Text="Buyer*^&nbsp;:&nbsp;&nbsp;"
                                                Width="200"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                                DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" Width="300px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerComboD" TypeName="MfgSaleInvoiceDL">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSaleInvNo" runat="server" SkinID="lblRsz" Text="Sale Invoice No.*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSaleInvNo" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Balance&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtbal" runat="server" Style="text-align: right" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblInvDate" runat="server" SkinID="lblRsz" Text="Invoice Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtInvDate" runat="server" SkinID="txt" MaxLength="11"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtInvDate"
                                                    Enabled="True">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtInvDate" Enabled="True">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label9" runat="server" SkinID="lblRsz" Text="Credit Limit&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditLim" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceType" runat="server" SkinID="lblRsz" Text="Invoice Type&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlIVType" runat="server" AppendDataBoundItems="true" SkinID="ddl">
                                                    <asp:ListItem Selected="True" Value="CASH Invoice">CASH Invoice</asp:ListItem>
                                                    <asp:ListItem Value="Cash Tax Invoice">Cash Tax Invoice</asp:ListItem>
                                                    <asp:ListItem Value="Credit Invoice">Credit Invoice</asp:ListItem>
                                                    <asp:ListItem Value="Credit Tax Invoice">Credit Tax Invoice</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Text="Credit Period&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditPer" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblse" runat="server" SkinID="lbl" Text="SE&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DdlSE" runat="server" DataSourceID="ObjSE" DataTextField="MR_Name"
                                                    DataValueField="MR_ID" SkinID="ddl">
                                                    <asp:ListItem Value="0" Text="Select">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjSE" runat="server" SelectMethod="GetSECobmo" TypeName="SupplierDB">
                                                </asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblEntryDate" runat="server" SkinID="lblRsz" Text="Entry Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEntryDate" runat="server" SkinID="txt" MaxLength="11"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtEntryDate"
                                                    Enabled="True">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtEntryDate" Enabled="True">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Text="Payment Method*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                                    DataTextField="Payment_Method" DataValueField="PaymentMethodIDAuto" AutoPostBack="true"
                                                    SkinID="ddl">
                                                    <%--  <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodDDL"
                                                    TypeName="MfgSaleInvoiceDL"></asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblSO" runat="server" SkinID="lbl" Text="SO No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSO" runat="server" SkinID="ddl" AutoPostBack="True" DataSourceID="ObjSO"
                                                    DataTextField="Sale_Order_Number" DataValueField="Sales_Order_ID" AppendDataBoundItems="false">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjSO" runat="server" TypeName="MfgSaleInvoiceDL" SelectMethod="GetSalesOrder">
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDd" runat="server" SkinID="lblRsz" Text="CC/DC/DD/Chq No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDd" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTranscation" runat="server" SkinID="lblRsz" Text="Transaction Type&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTransaction" runat="server" AppendDataBoundItems="true"
                                                    SkinID="ddl">
                                                    <asp:ListItem Selected="True" Value="1">Consignment</asp:ListItem>
                                                    <asp:ListItem Value="2">Normal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBank" runat="server" SkinID="lblRsz" Text="Bank&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                                    DataValueField="Bank_IDAuto" SkinID="ddl">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="BankComboDDL" TypeName="MfgSaleInvoiceDL">
                                                </asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblFlatDisc" runat="server" SkinID="lblRsz" Text="Flat Discount %&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFlatDisc" Style="text-align: right" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtFlatDisc">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBranch" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                                    AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblFlatDiscAmt" runat="server" SkinID="lblRsz" Text="Flat Disc Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFlatDiscAmt" Style="text-align: right" runat="server" AutoCompleteType="Disabled"
                                                    SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtFlatDiscAmt">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMRPValue" runat="server" SkinID="lblRsz" Text="MRP Value&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMRPValue" Style="text-align: right" runat="server" AutoCompleteType="Disabled"
                                                    SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMRPValue">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblNoOfItem" runat="server" SkinID="lbl" Text="No Of Item&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNoOfItem" Style="text-align: right" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtNoOfItem">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCurrntRecAmt" runat="server" SkinID="lblRsz" Text="Current Rec Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCurRecAmt" Style="text-align: right" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtCurRecAmt">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblFreightChrg" runat="server" SkinID="lblRsz" Text="Freight Charge&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFreightChrg" Style="text-align: right" runat="server" AutoCompleteType="Disabled"
                                                    SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtFreightChrg">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCreditNote" runat="server" SkinID="lblRsz" Text="Credit Note&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditNote" runat="server" Style="text-align: right" AutoCompleteType="Disabled"
                                                    SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtCreditNote">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDebitNote" runat="server" SkinID="lblRsz" Text="Debit Note&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDebitNote" runat="server" Style="text-align: right" AutoCompleteType="Disabled"
                                                    SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDebitNote">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td align="right">
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" AutoCompleteType="Disabled"
                                                    SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <table>
                                        <tr>
                                            <td>
                                                <b>OTHER DETAILS </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblChallan" runat="server" SkinID="lblRsz" Text="Challan No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtchallan" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtchallan">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDispatchdfrom" runat="server" SkinID="lblRsz" Text="Dispatched From&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdispatchdfrom" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRemarksodr" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarksodr" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDispatchdTo" runat="server" SkinID="lblRsz" Text="Dispatched To&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDispatchdTo" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblTransport" runat="server" SkinID="lblRsz" Text="Transport/Lr No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTransport" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTransport">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblReceivedAddrss" runat="server" SkinID="lblRsz" Text="Received Address&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReceivdAddress" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSentBy" runat="server" SkinID="lblRsz" Text="Sent By&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSentBy" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTransportBy" runat="server" SkinID="lblRsz" Text="Transport Mode&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DdlTransportBy" runat="server" DataSourceID="ObjTransportBy"
                                                    DataTextField="Shipping_Method" DataValueField="ShippingAutoNo" SkinID="ddl">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjTransportBy" runat="server" SelectMethod="transportationComboD"
                                                    TypeName="MfgSaleInvoiceDL"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblReceivedDate" runat="server" SkinID="lblRsz" Text="Received Date&nbsp;:&nbsp;&nbsp;"
                                                    Width="140px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReceivedDate" runat="server" SkinID="txt" MaxLength="11"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtReceivedDate"
                                                    Enabled="True">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtReceivedDate" Enabled="True">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="HidInvoice" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="HidInvoiceNO" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <%--   <asp:Panel ID="TotalCalculation" runat="server">--%>
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    <b>Additional Details</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblTotalAmount" runat="server" SkinID="lblRsz" Text="Total Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalAmount" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblTotalDiscountAmt" runat="server" SkinID="lblRsz" Text="Trade Disc Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalDicAmt" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Flat Disc Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalFlatDiscAmt" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblvatAmt" runat="server" SkinID="lblRsz" Text="VAT Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtvatAmt" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblcstAmt" runat="server" SkinID="lblRsz" Text="CST Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalcstAmt" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblafc" runat="server" SkinID="lblRsz" Text="Frieght Charges&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtafc" runat="server" Style="text-align: right" SkinID="txt" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFinalAmt" runat="server" SkinID="lblRsz" Text="Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalFinalAmt" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblRoundOff" runat="server" SkinID="lblRsz" Text="Round Off&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalRoundOff" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblGrandFinalAmt" runat="server" SkinID="lblRsz" Text="Grand Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalGrandFinalAmt" Style="text-align: right" runat="server"
                                                        SkinID="txt" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblProfitLoss" runat="server" SkinID="lblRsz" Text="Profit/Loss&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtProfitLoss" Style="text-align: right" runat="server" SkinID="txt"
                                                        Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                    <%--  </asp:Panel>--%>
                                    <br />
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td colspan="5" class="btnTd">
                                                <asp:Button ID="btnADDSaleInvoice" runat="server" Text="ADD" CssClass="ButtonClass "
                                                    CausesValidation="true" SkinID="btn" OnClientClick="return Validate();" />
                                                <asp:Button ID="btnViewSaleInvoice" runat="server" Text="VIEW" CausesValidation="False"
                                                    SkinID="btn" CssClass="ButtonClass" />
                                                <asp:Button ID="btnAddDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                    Text="ADD DETAILS" Width="130px" />
                                                <asp:Button ID="Btnposttostock" runat="server" Text="POST " CssClass="ButtonClass "
                                                    CausesValidation="true" SkinID="btnRsz" />
                                                <asp:Button ID="btnreceipt" runat="server" Text="PRINT " CssClass="ButtonClass "
                                                    CausesValidation="true" SkinID="btnRsz" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                </br>
                                <center>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="320px">
                                        <asp:GridView ID="GvSaleInvoice" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="100" SkinID="GridView" align="center">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:LinkButton ID="LkEdit" runat="server" TabIndex="6" CausesValidation="False"
                                                                CommandName="Edit" Text="Edit" />
                                                            <asp:LinkButton ID="LkDelete" runat="server" TabIndex="7" CausesValidation="False"
                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" />
                                                        </center>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                                            TabIndex="6" Text="Update"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                                            TabIndex="7" Text="Back"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" TabIndex="5" OnCheckedChanged="CheckAll"
                                                            Width="50px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkRL" runat="server" TabIndex="6" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPostStatus" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSE" runat="server" Text='<%# Bind("MR_ID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="IDPaymentMethod" runat="server" Text='<%# Bind("PaymentMethod_Id") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblChequeNo" runat="server" Visible="false" Text='<%# Bind("Cheque_No")%>' />
                                                        <asp:HiddenField ID="lblBank" runat="server" Value='<%# Bind("Bank") %>' />
                                                        <%--<asp:HiddenField ID="lblGVProductType" runat="server" Value='<%# Bind("Field5") %>'/>--%>
                                                        <asp:HiddenField ID="HIDBranch" runat="server" Value='<%# Bind("Branch") %>' />
                                                        <asp:HiddenField ID="HIDField1" runat="server" Value='<%# Bind("Field1") %>' />
                                                        <asp:Label ID="lblSOID" Visible="false" runat="server" Text='<%# Bind("SO_ID") %>' />
                                                        <asp:Label ID="lblTransactionType" runat="server" Visible="false" Text='<%# Bind("TransactionType") %>' />
                                                        <asp:Label ID="lblFlatDiscountSale" runat="server" Visible="false" Text='<%# Bind("Flat_Discount_Sale","{0:0.00}") %>' />
                                                        <asp:Label ID="lblCurrReceivedAmt" runat="server" Text='<%# Bind("CurrReceivedAmt","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:HiddenField ID="HFreightCharge" runat="server" Value='<%# Bind("Freight_Charge","{0:0.00}") %>' />
                                                        <asp:Label ID="lblMultiDiscount" runat="server" Visible="false" Text='<%# Bind("Multi_Discount","{0:0.00}")%>' />
                                                        <asp:HiddenField ID="HidReceivedAmount" runat="server" Value='<%# Bind("Received_Amount","{0:0.00}") %>' />
                                                        <%--<asp:HiddenField ID="lblGVProductType" runat="server" Value='<%# Bind("Field5") %>'/>--%>
                                                        <asp:HiddenField ID="HidChallanNo" runat="server" Value='<%# Bind("Challan_No") %>' />
                                                        <asp:HiddenField ID="HidNote" runat="server" Value='<%# Bind("Note") %>' />
                                                        <asp:HiddenField ID="HidTransportNo" runat="server" Value='<%# Bind("Transport_No") %>' />
                                                        <asp:Label ID="lblSentBy" Visible="false" runat="server" Text='<%# Bind("Sent_By") %>' />
                                                        <asp:HiddenField ID="HidShipmentFrom" runat="server" Value='<%# Bind("Shipment_From") %>' />
                                                        <asp:HiddenField ID="HidShipmentTo" runat="server" Value='<%# Bind("Shipment_To") %>' />
                                                        <asp:HiddenField ID="HidShipAddress" runat="server" Value='<%# Bind("Ship_Address") %>' />
                                                        <asp:Label ID="lblShipMethod" Visible="false" runat="server" Text='<%# Bind("Ship_Method") %>' />
                                                        <asp:Label ID="lblReceiptDate" Visible="false" runat="server" Text='<%# Bind("Receipt_Date","{0:dd-MMM-yyyy}") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sale Invoice No">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="SSID" runat="server" Value='<%# Bind("SaleMain_ID") %>' Visible="false" />
                                                        <asp:Label ID="lblSaleInvoiceNo" runat="server" Text='<%# Bind("Sale_Invoice_No") %>'></asp:Label>
                                                        <asp:Label ID="lblsaleinvoiceID" runat="server" Text='<%# Bind("Field2") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTotalAmt" runat="server" Text='<%# Bind("Field4","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTradeDiscAmt" runat="server" Text='<%# Bind("PatientName","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblFlatDiscAmt" runat="server" Text='<%# Bind("DoctorName","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblVatAmt" runat="server" Text='<%# Bind("Patient_ID","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblCSTAmt" runat="server" Text='<%# Bind("Doctor_ID","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAddFC" runat="server" Text='<%# Bind("VAT_Invoice_No","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTotFinalAmt" runat="server" Text='<%# Bind("FinalAmount","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblRoundOff" runat="server" Text='<%# Bind("Tax_BeforeAfter_Discount","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblProfitLoss" runat="server" Text='<%# Bind("Receipt_Method","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblCurrentRate" runat="server" Text='<%# Bind("Deliver_by","{0:0.00}") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("VAT_Invoice_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInvoiceType" runat="server" Text='<%# Bind("Field5") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Buyer" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBuyer" runat="server" Text='<%# Bind("Party_Id") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblBuyerName" runat="server" Text='<%# Bind("Party_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="No Of Item">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNoofItem" runat="server" Text='<%# Bind("Field1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" HeaderText="Invoice Value">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInvValue" runat="server" Text='<%# Bind("FinalAmount","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entry Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntryDate1" runat="server" Text='<%# Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblremarks1" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="SALE INVOICE DETAILS"
                        TabIndex="3">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        SALE INVOICE DETAILS
                                        <br />
                                        <br />
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblItemDesc" runat="server" SkinID="lblRsz" Text="Item Description* :&nbsp;&nbsp;"
                                                    Width="200"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DDLRM" runat="server" DataSourceID="ObjProduct1" DataTextField="Product_Name"
                                                    Width="200" DataValueField="Product_Id" SkinID="ddlRsz" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductComboD"
                                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DDLBatch" SkinID="ddl" runat="server" DataSourceID="ObjBatch"
                                                    DataValueField="Batch_ID" DataTextField="Batch" AppendDataBoundItems="false"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchCombo" TypeName="MfgSaleInvoiceDL">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="DDLRM" Name="ProductId" PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTotalQty" Width="150px" runat="server" Text="Total Qty* :&nbsp;&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTotalQty1" Style="text-align: right" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTotalQty1">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMRP" SkinID="lbl" runat="server" Text="MRP*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMRP" SkinID="txt" Style="text-align: right" runat="server"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMRP">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDeal" runat="server" SkinID="lblRsz" Text="Deal* :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDeal" runat="server" Style="text-align: right" TabIndex="12"
                                                    Width="55px"></asp:TextBox>
                                                &nbsp;+&nbsp;
                                                <asp:TextBox ID="txtDeal1" runat="server" Style="text-align: right" TabIndex="13"
                                                    Width="60px"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDeal">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDeal1">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblTradeRate" SkinID="lbl" runat="server" Text="Trade Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTradeRate" SkinID="txt" Style="text-align: right" runat="server"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTradeRate">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDiscount" SkinID="lblRsz" runat="server" Text="Discount(%)&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDiscount" SkinID="txt" Style="text-align: right" runat="server"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="filterAmountPaid" runat="server" FilterMode="ValidChars"
                                                    FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscount">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDiscountAmt" SkinID="lbl" runat="server" Text="Discount Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDiscountAmt" SkinID="txt" Style="text-align: right" runat="server"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscountAmt">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTaxPlan" runat="server" SkinID="lblRsz" Text="Tax Plan*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlTaxDesc" SkinID="ddl" runat="server" DataSourceID="ObjTax"
                                                    DataValueField="Tax_ID" DataTextField="Tax_Description" AutoPostBack="true">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjTax" runat="server" SelectMethod="TaxDesc" TypeName="MfgSaleInvoiceDL">
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblTaxon" runat="server" SkinID="lblRsz" Text="Tax on*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlTaxOn" SkinID="ddlRsz" runat="server">
                                                    <asp:ListItem Selected="True" Text="MRP with tax on free goods" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="MRP without tax on free goods" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Purchase Price with tax on free goods" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Purchase Price without tax on free goods" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTaxAB" runat="server" SkinID="lblRsz" Text="Tax A/B Disc&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlTaxAB" SkinID="ddlRsz" runat="server">
                                                    <asp:ListItem Selected="True" Text="A" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="HidMInvoice" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtTotalQty" runat="server" Visible="false" SkinID="txt"></asp:TextBox>
                                                <asp:TextBox ID="txtmargin" runat="server" Visible="false" SkinID="txt"></asp:TextBox>
                                                <asp:TextBox ID="txtpurchRate" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtCST" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtVAT" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="HIDFlatRate" SkinID="txt" runat="server" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblPacking" runat="server" SkinID="lblRsz" Text="Packing :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPackint" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblMFG" runat="server" SkinID="lblRsz" Text="MFG :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMFG" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMKT" runat="server" SkinID="lblRsz" Text="MKT :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMKT" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCnvFact" runat="server" SkinID="lblRsz" Text="Conv Fact :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCnvFact" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblpurchRate1" runat="server" SkinID="lblRsz" Text="Purchase Rate :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPurchRate1" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblExpences" runat="server" SkinID="lblRsz" Text="Expenses :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtExpenses" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMRP1" runat="server" SkinID="lblRsz" Text="MRP:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMRP1" runat="server" Style="text-align: right" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblQty" runat="server" SkinID="lblRsz" Text="Qty In Stock :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQty" runat="server" Style="text-align: right" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblVAT" runat="server" SkinID="lblRsz" Text="VAT :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtVAT1" runat="server" Style="text-align: right" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCST" runat="server" SkinID="lblRsz" Text="CST :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCST1" runat="server" Style="text-align: right" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblOfrPeriod" runat="server" SkinID="lblRsz" Text="Offer Period :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtOffrPeriod" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCurrentRate" runat="server" SkinID="lblRsz" Text="Current Rate :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCurrentRate" Style="text-align: right" runat="server" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCurrency" runat="server" SkinID="lblRsz" Text="Currency&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlCurrency" Enabled="false" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                                    AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="Mfg_DLStockEntry">
                                                </asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblExchRate" runat="server" SkinID="lblRsz" Text="Exch Rate :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtExchRate" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                                <asp:HiddenField ID="HIDPurchaseInvoiceMain" runat="server"/>
                                                <asp:HiddenField ID="HIDPurchaseInvoiceDetails" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td colspan="5" class="btnTd">
                                                <asp:Button ID="btnAddSaleInvoiceDetails" runat="server" Text="ADD" CssClass="ButtonClass "
                                                    CausesValidation="true" SkinID="btn" OnClientClick="return Validate1();" />
                                                <asp:Button ID="btnViewSaleInvoiceDetails" runat="server" Text="VIEW" CausesValidation="False"
                                                    SkinID="btn" CssClass="ButtonClass" />
                                                <%-- <asp:Button ID="Button3" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                    Text="ADD PRODUCT" Width="130px" TabIndex="12" />--%>
                                                <asp:Button ID="BtnClose" runat="server" Text="CLOSE" CssClass="ButtonClass " CausesValidation="true"
                                                    SkinID="btnRsz" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGreen" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblRed" runat="server" SkinID="lblGreen"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <center>
                                    <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="500px" Height="300px">
                                        <asp:GridView ID="GVSaleInvoiceDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="100" SkinID="GridView" Width="300px" align="center">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:LinkButton ID="LkSaliInvoiceEdit" runat="server" TabIndex="6" CausesValidation="False"
                                                                CommandName="Edit" Text="Edit" />
                                                            <asp:LinkButton ID="LkSaliInvoiceDelete" runat="server" TabIndex="7" CausesValidation="False"
                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" />
                                                        </center>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="SSID" runat="server" Value='<%# Bind("SaleSub_ID") %>' Visible="false" />
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Product_Id") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Batch">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                                        <asp:Label ID="lblBatchId" runat="server" Text='<%# Bind("Batch_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <HeaderStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="MFG">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMFG" runat="server" Text='<%# Bind("Manufaturer_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Packing">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPacking" runat="server" Text='<%# Bind("Packing_Details") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Expiry">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExpiry" runat="server" Text='<%# Bind("Expiry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotQty" runat="server" Text='<%# Bind("Quantity_Confirmed") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Deal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDeal" runat="server" Text='<%# Bind("Deal_Qty") %>'></asp:Label>
                                                        +
                                                        <asp:Label ID="lblFree" runat="server" Text='<%# Bind("Deal_Free") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty_Sale") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Free">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFree_Sale" runat="server" Text='<%# Bind("Free_Sale") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="MRP">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMRP" runat="server" Text='<%# Bind("MRP","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("Trade_Discount") %>'></asp:Label>
                                                        <asp:Label ID="lblTradeDiscAmt" runat="server" Text='<%# Bind("TradeDiscAmt")  %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Trade Rate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTradeRate" runat="server" Text='<%# Bind("Sale_Rate","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Tax_BeforeAfter_Discount") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Tax_Str_ID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Field9") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblFlatdiscAmt" runat="server" Text='<%# Bind("FlatDiscAmt") %>' Visible="false"></asp:Label>
                                                        <%--<asp:Label ID="lblFinalAmt" runat="server" Text='<%# Bind("CST") %>' Visible="false"></asp:Label>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Margin">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMargin" runat="server" Text='<%# Bind("Margin","{0:0.00}") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Sale_Amount","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VAT%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVAT" runat="server" Text='<%# Bind("VAT","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVVATAmount" Visible="false" runat="server" Text='<%# Bind("Sale_VAT_Amt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CST%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCST" runat="server" Text='<%# Bind("CST","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVCSTAmount" Visible="false" runat="server" Text='<%# Bind("Sale_CST_Amt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Final Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotFinalAmt" runat="server" Text='<%# Bind("Sale_Final_Amount","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblPurchaseInvoiceMain" runat="server" Text='<%# Bind("Purchase_Invoice_ID") %>'></asp:Label>
                                                        <asp:Label ID="lblPurchaseInvoiceDetails" runat="server" Text='<%# Bind("PRD_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>