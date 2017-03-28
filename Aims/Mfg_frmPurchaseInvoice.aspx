<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmPurchaseInvoice.aspx.vb"
    Inherits="Mfg_frmPurchaseInvoice" Title="Purchase Invoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Purchase Invoice</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlSupplier.ClientID %>"), 'Supplier');
            if (msg != "") return msg;

            msg = Field50N(document.getElementById("<%=txtPurchInvoiceM.ClientID %>"), 'Purch Inv No');
            if (msg != "") return msg;
            msg = Field250N(document.getElementById("<%=txtRemarksM.ClientID %>"), 'Remarks');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtInvoiceDateM.ClientID %>"), 'Invoice Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEntryDateM.ClientID %>"), 'Entry/Receipt Date');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlPaymentMethod.ClientID %>"), 'Payment Type');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtDiffAmtM.ClientID %>"), 'Difference Amount');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtTaxDiffM.ClientID %>"), 'Tax Difference');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtDiscDiffM.ClientID %>"), 'Disc Difference');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtFlatDiscM.ClientID %>"), 'Flat Difference');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtExciseDiff.ClientID %>"), 'Excise Difference');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtFlatDiscAmtM.ClientID %>"), 'Flat Difference Amt');
            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtRoundOffM.ClientID %>"), 'Round Off');
            if (msg != "") return msg;


            msg = Field50N(document.getElementById("<%=txtDispatchM.ClientID %>"), 'Dispatched From');
            if (msg != "") return msg;
            msg = Field250N(document.getElementById("<%=txtRecvdAddM.ClientID %>"), 'Received Address');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtDispatchToM.ClientID %>"), 'Dispatch To');
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtPaymentDateM.ClientID %>"), 'Payment Date');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtRoundOffM.ClientID %>"), 'Transport No');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRedM.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreenM.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRedM.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreenM.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
       
    </script>

    <script type="text/javascript" language="javascript">
        function Valid1() {

            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID %>"), 'Product');
            if (msg != "") return msg;

            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtQtyrecvd.ClientID %>"), 'Qty Recvd');
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtQtyAccept.ClientID %>"), 'Qty Accept');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlTaxPlan.ClientID %>"), 'TaxPlan');
            if (msg != "") return msg;
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
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
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Purchase Invoice"
                        TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <div>
                                    <center>
                                        <h1 class="headingTxt">
                                            PURCHASE INVOICE
                                        </h1>
                                    </center>
                                </div>
                                <br />
                                <br />
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSupplierM" runat="server" SkinID="lblRsz" Text="Supplier*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSupplier" runat="server" SkinID="ddl" AutoPostBack="True"
                                                    DataSourceID="odsSupplier" DataTextField="Supp_Name" DataValueField="Supp_Id"
                                                    AppendDataBoundItems="true">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsSupplier" runat="server" TypeName="Mfg_DLPurchaseInvoice"
                                                    SelectMethod="GetSupplierDetails"></asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblBalanceM" runat="server" SkinID="lblRsz" Text="Balance&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBalance" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblPurchInvoiceM" runat="server" SkinID="lblRsz" Width="160" Text="Purch Inv No*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPurchInvoiceM" runat="server" SkinID="txt"></asp:TextBox>
                                                <asp:TextBox ID="HIDPURCHINVOICEID" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCreditLimit" runat="server" SkinID="lblRsz" Text="Credit Limit&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditLimitM" Style="text-align: right" runat="server" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblInvoiceDateM" runat="server" SkinID="lblRsz" Text="Invoice Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtInvoiceDateM" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="dateInvoiceDate" runat="server" TargetControlID="txtInvoiceDateM"
                                                    Format="dd-MMM-yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCreditLimitM" runat="server" SkinID="lblRsz" Text="Credit Peroid&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditPeroidM" runat="server" Style="text-align: right" SkinID="txt"
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
                                                <asp:Label ID="lblGRN" runat="server" SkinID="lbl" Text="GRN&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRN" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEntryDateM" runat="server" Width="170px" SkinID="lblRsz" Text="Entry/Receipt Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEntryDateM" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEntryDateM"
                                                    Format="dd-MMM-yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRemarksM" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarksM" runat="server" SkinID="txt" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblPaymentM" runat="server" SkinID="lblRsz" Text="Payment Type*&nbsp;:&nbsp;&nbsp;"
                                                    TabIndex="-1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                                    DataTextField="Payment_Method" DataValueField="PaymentMethodIDAuto" SkinID="ddl">
                                                    <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodDDL"
                                                    TypeName="Mfg_DLPurchaseInvoice"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <b>Other Details</b>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblPOM" runat="server" SkinID="lblRsz" Text="PO NO.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPOM" TabIndex="1" runat="server" SkinID="ddl" DataSourceID="ObjPO"
                                                    DataTextField="Purchase_Order_Number" DataValueField="Purchase_Order_ID" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjPO" runat="server" TypeName="Mfg_DLPurchaseInvoice"
                                                    SelectMethod="GetPurchaseOrder"></asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblReceivedBy" runat="server" SkinID="lblRsz" Text="Received By&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReceivedByM" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDispatchFromM" runat="server" SkinID="lblRsz" Text="Dispatch from&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDispatchM" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblReceivedAddM" runat="server" SkinID="lblRsz" Text="Received Address&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRecvdAddM" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDispatchToM" runat="server" SkinID="lblRsz" Text="Dispatch To&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDispatchToM" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblPaymentDateM" runat="server" SkinID="lblRsz" Text="Payment Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaymentDateM" runat="server" SkinID="txt" MaxLength="11"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="DatePaymentDateM" runat="server" TargetControlID="txtPaymentDateM"
                                                    Format="dd-MMM-yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblTransporationM" runat="server" SkinID="lblRsz" Text="Transportation Mode&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlShipment" runat="server" SkinID="ddl" TabIndex="10" DataTextField="Shipping_Method"
                                                    DataValueField="ShippingAutoNo" AppendDataBoundItems="true" DataSourceID="ObjTransport">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjTransport" runat="server" SelectMethod="DDLTransport"
                                                    TypeName="mfg_PurchaseOrderDL"></asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTransporationNoM" runat="server" SkinID="lbl" Text="Transportation&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTransportation" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <hr />
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblItemsM" runat="server" SkinID="lblRsz" Text="No of Items&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtitemsM" Style="text-align: right" runat="server" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTotalAmount" runat="server" SkinID="lbl" Text="Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalAmount" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMRPValueM" runat="server" SkinID="lblRsz" Text="MRP Value&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMRPValueM" Style="text-align: right" runat="server" SkinID="txt"
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
                                                <asp:Label ID="lblExpValue" runat="server" SkinID="lblRsz" Text="Misc Exp Value&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMiscExpM" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblFlatDiscAmt" runat="server" SkinID="lblRsz" Text="Flat Disc Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalFlatDiscAmt" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblFlatDiscountM" runat="server" SkinID="lblRsz" Text="Flat Discount%&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFlatDiscM" Style="text-align: right" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtFlatDiscM" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblTotalExcise" runat="server" SkinID="lbl" Text="Excise Duty&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalExcise" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblFlatDiscAmtM" runat="server" SkinID="lblRsz" Text="Flat Discount Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFlatDiscAmtM" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.-" TargetControlID="txtFlatDiscAmtM" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblVatAmt" runat="server" SkinID="lbl" Text="VAT Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalVatAmt" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDiffAmtM" runat="server" SkinID="lblRsz" Text="Diff Amount&nbsp;:&nbsp;&nbsp;"
                                                    TabIndex="-1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDiffAmtM" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiffAmtM" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCstAmt" runat="server" SkinID="lbl" Text="CST Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalCSTAmt" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblTaxDiffM" runat="server" SkinID="lblRsz" Text="Tax Diff&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTaxDiffM" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTaxDiffM" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblFinalAmt" runat="server" SkinID="lbl" Text="Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalFinalAmt" Style="text-align: right" runat="server" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDiscDiffM" runat="server" SkinID="lblRsz" Text="Disc Diff&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDiscDiffM" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscDiffM" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDiffAmt" runat="server" SkinID="lbl" Text="Diff Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDiffAmt" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblExicDiffM" runat="server" SkinID="lblRsz" Text="Excise Diff&nbsp;:&nbsp;&nbsp;"
                                                    TabIndex="-1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExciseDiff" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtExciseDiff" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRoundOff" runat="server" SkinID="lbl" Text="Round Off&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalRoundOff" runat="server" Style="text-align: right" SkinID="txt"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRoundOffM" runat="server" SkinID="lblRsz" Text="Round Off&nbsp;:&nbsp;&nbsp;"
                                                    TabIndex="-1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRoundOffM" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtRoundOffM" />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblGrandFinalAmt" runat="server" SkinID="lblRsz" Text="Grand Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalGrandFinalAmt" runat="server" Style="text-align: right"
                                                    SkinID="txt" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </center>
                                <hr />
                                <br />
                                <center>
                                    <table>
                                        <br />
                                        <br />
                                        <tr>
                                            <td class="btnTd" colspan="2">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" CausesValidation="true"
                                                    OnClientClick="return Validate();" SkinID="btn" Text="ADD" />
                                                &nbsp;
                                                <asp:Button ID="BtnView" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                                                &nbsp;
                                                <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                    Text="ADD PRODUCTS" Width="150px" />
                                                &nbsp;
                                                <asp:Button ID="btnPost" runat="server" CssClass="ButtonClass" SkinID="btn" Text="POST" />
                                                &nbsp;
                                                <asp:Button ID="btnReceipt" runat="server" CssClass="ButtonClass" SkinID="btn" Text="PRINT" />
                                                &nbsp;
                                                
                                                 <asp:Button ID="btngrn" runat="server" CssClass="ButtonClass" SkinID="btn" Text="GRN" />
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <div>
                                                        <asp:Label ID="lblRedM" runat="server" SkinID="lblRed"></asp:Label>
                                                        <asp:Label ID="lblGreenM" runat="server" SkinID="lblGreen"></asp:Label>
                                                    </div>
                                                </center>
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
                                    <asp:Panel ID="PanelInvoiceM" runat="server" ScrollBars="Auto" Width="650px" Height="320px">
                                        <asp:GridView ID="GridPurchaseInvoiceM" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="100" SkinID="GridView">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Font-Underline="False" TabIndex="3" Text="Edit"></asp:LinkButton>
                                                        <asp:LinkButton ID="DeleteM" runat="server" CausesValidation="False" CommandName="Delete"
                                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                                            TabIndex="6" Text="Update"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                                            TabIndex="7" Text="Back"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Left" />
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
                                                        <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Supplier">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("PurchMain") %>' />
                                                        <asp:Label ID="lblSuppName" runat="server" Text='<%# Bind("Supp_Name") %>' />
                                                        <asp:Label ID="lblSupppId" runat="server" Visible="false" Text='<%# Bind("Company_Id") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Purch Inv No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPurchInvId" runat="server" Visible="false" Text='<%# Bind("Purchase_Invoice_ID") %>'></asp:Label>
                                                        <asp:Label ID="lblPurchInvNo" runat="server" Text='<%# Bind("Purchase_Invoice_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInvoiceDateGV" runat="server" Text='<%# Bind("VAT_Invoice_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entry Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntryDateGV" runat="server" Text='<%# Bind("Receipt_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        <asp:Label ID="lblPaymentTypeGV" runat="server" Visible="false" Text='<%# Bind("Payment_Type_Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Payment Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="right" />
                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="GRN">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGRNGV" runat="server" Text='<%# Bind("GrandFinal_Amount","{0:n2}") %>'></asp:Label>
                                                        <asp:Label ID="lblRemarksGV" runat="server" Visible="false" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="MRP Values">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="right" />
                                            </asp:TemplateField>--%>
                                                <%--<asp:TemplateField HeaderText="Misc Exp Value">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="right" />
                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Flat Disc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVflatDisc" runat="server" Text='<%# Bind("Flat_Discount","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Flat Disc Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVFlatDiscAmt" runat="server" Text='<%# Bind("Multi_Discount","{0:n2}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVFlatDiscAmtRATE" runat="server" Visible="false" Text='<%# Bind("Multi_Discount","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Diff Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVDiffAmt" runat="server" Text='<%# Bind("Difference_amount","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Diff">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVTaxDiff" runat="server" Text='<%# Bind("TaxDifference","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount Diff">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVDiscountDiff" runat="server" Text='<%# Bind("DiscountDifference","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Excise Diff">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVExciseDiff" runat="server" Text='<%# Bind("ExiseDifference","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Round Off">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoundOFFGV" runat="server" Text='<%# Bind("Paid_Amount","{0:n2}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalAmountM" runat="server" Visible="false" Text='<%# Bind("TotalAmount","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalDiscountAmt" runat="server" Visible="false" Text='<%# Bind("TradeDiscountAmt","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalExciseDuty" runat="server" Visible="false" Text='<%# Bind("ExciseDuty","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalVATAmount" runat="server" Visible="false" Text='<%# Bind("TotalVATAmount","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalCSTAmount" runat="server" Visible="false" Text='<%# Bind("TotalCSTAmount","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalGrandFinalAmt" runat="server" Visible="false" Text='<%# Bind("TotalGrandFinalAmount","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalFinalAmount" runat="server" Visible="false" Text='<%# Bind("TotalFinalAmount","{0:0.00}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalMRPValue" runat="server" Visible="false" Text='<%# Bind("MRPValue","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVRemarksM" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        <asp:Label ID="lblGVPOM" runat="server" Visible="false" Text='<%# Bind("Purchase_Order_ID") %>'></asp:Label>
                                                        <asp:Label ID="lblGVDispatchFrom" runat="server" Visible="false" Text='<%# Bind("Shipment_From") %>'></asp:Label>
                                                        <asp:Label ID="lblGVDispatchTo" runat="server" Visible="false" Text='<%# Bind("Shipment_To") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTransporation" Visible="false" runat="server" Text='<%# Bind("Ship_Method") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTransportNo" runat="server" Visible="false" Text='<%# Bind("Transport_No") %>'></asp:Label>
                                                        <asp:Label ID="lblGVRecievedBy" runat="server" Visible="false" Text='<%# Bind("Recieved_By") %>'></asp:Label>
                                                        <asp:Label ID="lblGVRecievedAddress" runat="server" Visible="false" Text='<%# Bind("Ship_Address") %>'></asp:Label>
                                                        <asp:Label ID="lblGVPaymentDate" runat="server" Visible="false" Text='<%# Bind("Payment_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        <asp:Label ID="lblInvType" runat="server" Visible="false" Text='<%# Bind("InvoiceType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Purchase Invoice Details"
                        TabIndex="2">
                        <ContentTemplate>
                            <center>
                                <h1 class="headingTxt">
                                    ADD DETAILS</h1>
                            </center>
                            <center>
                                <hr />
                                <table class="custTable">
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:RadioButtonList ID="RbProduct" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                SkinID="Themes" Width="398px">
                                                <asp:ListItem Selected="True" Text="Ready Made" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Raw Materials" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Finished Goods" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblProduct" runat="server" SkinID="lblRsz" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDLProduct" SkinID="ddl" runat="server" DataSourceID="ObjProduct"
                                                DataValueField="Product_Id" DataTextField="Product_Name" AutoPostBack="true">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboD"
                                                TypeName="Mfg_DLStockEntry">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="RbProduct" Name="Id" PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblItemsM2" runat="server" SkinID="lblRsz" Text="No of Items&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtitemsM2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblBatchS" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBatch" runat="server" SkinID="txt"></asp:TextBox>
                                            <asp:TextBox ID="HIDBatch" runat="server" Visible="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMRPValueM2" runat="server" SkinID="lblRsz" Text="MRP Value&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMRPValueM2" Style="text-align: right" runat="server" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpiryS" runat="server" Text="Expiry :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtExpiryS" runat="server" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtExpiryS"
                                                Format="dd-MMM-yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblExpValue2" runat="server" SkinID="lblRsz" Text="Misc Exp Value&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMiscExpM2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Text="Purchase Deal :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPurchase" runat="server" Style="text-align: right" Width="55px"></asp:TextBox>
                                            &nbsp;+&nbsp;
                                            <asp:TextBox ID="txtPurchase1" runat="server" Style="text-align: right" Width="55px"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblFlatDiscountM2" runat="server" SkinID="lblRsz" Text="Flat Discount%&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFlatDiscM2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtFlatDiscM2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblQtyRecvd" runat="server" Text="Qty Recvd* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtQtyrecvd" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQtyrecvd" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblFlatDiscAmtM2" runat="server" SkinID="lblRsz" Text="Flat Discount Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFlatDiscAmtM2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789.-" TargetControlID="txtFlatDiscAmtM2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblQtyAcceptS" runat="server" Text="Qty Accept* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtQtyAccept" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQtyAccept" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Tax Diff&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTaxDiffM2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTaxDiffM2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblUnitS" runat="server" Text="Unit&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlUnitS" SkinID="ddl" runat="server" DataSourceID="ObjUnit"
                                                DataTextField="Unit" DataValueField="Unit_ID" AutoPostBack="True">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="getUnit" TypeName="Mfg_DLProductDetails">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblDiffAmtM2" runat="server" SkinID="lblRsz" Text="Diff Amount&nbsp;:&nbsp;&nbsp;"
                                                TabIndex="-1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiffAmtM2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiffAmtM2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPackingS" SkinID="lblRsz" runat="server" Text="Packing&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPackingS" SkinID="txt" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblDiscDiffM2" runat="server" SkinID="lblRsz" Text="Disc Diff&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiscDiffM2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscDiffM2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblMFG" runat="server" SkinID="lblRsz" Text="MFG&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMFG" SkinID="ddl" runat="server" DataSourceID="ObjMFG" DataValueField="Manufacturer_ID"
                                                DataTextField="Manufaturer_Name">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjMFG" runat="server" SelectMethod="GetManufacturerMFG"
                                                TypeName="Mfg_DLStockEntry"></asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblExicDiffM2" runat="server" SkinID="lblRsz" Text="Excise Diff&nbsp;:&nbsp;&nbsp;"
                                                TabIndex="-1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExciseDiff2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtExciseDiff2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblMKT" runat="server" SkinID="lblRsz" Text="MKT&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMKT" SkinID="ddl" runat="server" DataSourceID="ObjMkt" DataValueField="Manufacturer_ID"
                                                DataTextField="Manufaturer_Name">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjMkt" runat="server" SelectMethod="GetManufacturerMKT"
                                                TypeName="Mfg_DLStockEntry"></asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblRoundOffM2" runat="server" SkinID="lblRsz" Text="Round Off&nbsp;:&nbsp;&nbsp;"
                                                TabIndex="-1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoundOffM2" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtRoundOffM2" />
                                            <asp:TextBox ID="HIDPurchaseInvoice" runat="server" Visible="false"></asp:TextBox>
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
                                            <asp:Label ID="lblTotalAmount2" runat="server" SkinID="lbl" Text="Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalAmount2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExchRate" SkinID="lblRsz" runat="server" Text="Exch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtExRate" SkinID="txt" Enabled="false" Style="text-align: right"
                                                runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotalDiscountAmt2" runat="server" SkinID="lblRsz" Text="Trade Disc Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalDicAmt2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPurchRateS" SkinID="lblRsz" runat="server" Text="Purch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPurchRateS" Width="60px" Style="text-align: right" runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPurchRateS" />
                                            <asp:DropDownList ID="ddlPurchRate" runat="server">
                                                <asp:ListItem Selected="True" Value="1">With Excise-I</asp:ListItem>
                                                <asp:ListItem Value="2">Without Excise-E</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblFlatDiscAmt2" runat="server" SkinID="lblRsz" Text="Flat Disc Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalFlatDiscAmt2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                            <asp:TextBox ID="HIDFlatRate" SkinID="txt" runat="server" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExiseS" runat="server" Text="Excise :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtExcise" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtExcise" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotalExcise2" runat="server" SkinID="lbl" Text="Excise Duty&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalExcise2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSaleRate" runat="server" Text="Sale Rate :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSaleRate" runat="server" Style="text-align: right" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtSaleRate" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblVatAmt2" runat="server" SkinID="lbl" Text="VAT Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalVatAmt2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblMRP" runat="server" Text="MRP :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMRP" runat="server" SkinID="txt" Style="text-align: right"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMRP" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblCstAmt2" runat="server" SkinID="lbl" Text="CST Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalCSTAmt2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDiscount" SkinID="lblRsz" runat="server" Text="Discount(%)&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDiscount" SkinID="txt" Style="text-align: right" runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscount" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblFinalAmt2" runat="server" SkinID="lbl" Text="Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalFinalAmt2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDiscountAmt" SkinID="lblRsz" runat="server" Text="Discount Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDiscountAmt" SkinID="txt" Style="text-align: right" runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscountAmt" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblDiffAmt2" runat="server" SkinID="lbl" Text="Diff Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalDiffAmt2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTaxOn" runat="server" SkinID="lblRsz" Text="Tax on*&nbsp;:&nbsp;&nbsp;"></asp:Label>
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
                                            <asp:Label ID="lblRoundOff2" runat="server" SkinID="lbl" Text="Round Off&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalRoundOff2" runat="server" Style="text-align: right" SkinID="txt"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTaxAB" runat="server" SkinID="lblRsz" Text="Tax A/B Disc*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTaxAB" SkinID="ddl" runat="server">
                                                <asp:ListItem Selected="True" Text="A" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblGrandFinalAmt2" runat="server" SkinID="lblRsz" Text="Grand Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalGrandFinalAmt2" runat="server" Style="text-align: right"
                                                SkinID="txt" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTaxPlan" runat="server" SkinID="lblRsz" Text="Tax Plan*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTaxPlan" SkinID="ddl" runat="server" DataSourceID="ObjTaxPlan"
                                                DataValueField="Tax_ID" DataTextField="Tax_Description" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjTaxPlan" runat="server" SelectMethod="getPurchaseTaxPlan"
                                                TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCST" SkinID="lblRsz" runat="server" Text="CST%&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCST" SkinID="txt" Enabled="false" Style="text-align: right" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblVAT" SkinID="lblRsz" runat="server" Text="VAT%&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtVAT" SkinID="txt" Enabled="false" Style="text-align: right" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRemarks" SkinID="lblRsz" runat="server" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRemarks" TextMode="MultiLine" SkinID="txt" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="btnTd" colspan="4" align="center">
                                            <asp:Button ID="btnAdddet" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                                OnClientClick="return Validate1();" SkinID="btn" Text="ADD" />&nbsp;
                                            <asp:Button ID="BtnViewDetails" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                                SkinID="btn" Text="VIEW" />&nbsp;
                                            <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" Text="CLOSE" />&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                                <div>
                                                    <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                                    <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                                </div>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <asp:Panel ID="GridPO" runat="server" Height="300px" ScrollBars="Auto" Width="650px">
                                                    <asp:GridView ID="GVPODetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        PageSize="100" SkinID="GridView">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="EditProduct" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        Font-Underline="False" TabIndex="3" Text="Edit"></asp:LinkButton>
                                                                    <asp:LinkButton ID="DeteteProduct" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                        Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Product">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                                    <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("PRD_ID") %>' />
                                                                    <asp:Label ID="lblGVInvoice" runat="server" Visible="false" Text='<%# Bind("Purchase_Invoice_ID")%>' />
                                                                    <asp:HiddenField ID="lblProductID" runat="server" Value='<%# Bind("Product_ID") %>' />
                                                                    <%--<asp:HiddenField ID="lblGVProductType" runat="server" Value='<%# Bind("Field5") %>'/>--%>
                                                                    <asp:HiddenField ID="HIDExRate" runat="server" Value='<%# Bind("Currency_Factor","{0:0.00}") %>' />
                                                                    <asp:HiddenField ID="HIDCurrency" runat="server" Value='<%# Bind("Currency_Code") %>' />
                                                                    <asp:HiddenField ID="Producttype" runat="server" Value='<%# Bind("ProductType") %>' />
                                                                    <%--<asp:Label ID="lblGVFree" runat="server" Visible="false" Text='<%# Bind("Deal_Free") %>' />--%>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="false" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Batch">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBatchID" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVBatchID" runat="server" Visible="false" Text='<%# Bind("Batch_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty Recvd">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQtyRecvdID" runat="server" Text='<%# Bind("Field9") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVRemarks" runat="server" Visible="false" Text='<%# Bind("Field10") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty Accept">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQtyAccept" runat="server" Text='<%# Bind("Total_Qty") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Free">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFree" runat="server" Text='<%# Bind("Free","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Purch Rate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPRate" runat="server" Text='<%# Bind("Purchase_Rate","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Excise ">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExciseId" runat="server" Text='<%# Bind("Excise_Rebat_On_MRP","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sale Rate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSrate" runat="server" Text='<%# Bind("Sale_Rate","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="MRP">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMRP" runat="server" Text='<%# Bind("MRP","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Bind("Amount","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Expiry">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGVExpiry" runat="server" Text='<%# Bind("ExpiryDate","{0:dd-MMM-yyyy}") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemStyle Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitId" runat="server" Visible="false" Text='<%# Bind("Field2") %>'></asp:Label>
                                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Packing">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGVPacking" runat="server" Text='<%# Bind("Packing_Details")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Deal">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGVQty" runat="server" Text='<%# Bind("Deal_Qty") %>' />
                                                                    +
                                                                    <asp:Label ID="lblGVFree" runat="server" Text='<%# Bind("Deal_Free") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="false" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="MRP Value">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMRPValue" runat="server" Text='<%# Bind("MRPValue","{0:0.00}")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IE">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGVPurchRateIV" runat="server" Text='<%# Bind("DiscountOn_Excise")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalQty" runat="server" Text='<%# Bind("Total_Qty","{0:0.00}") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVMKT" runat="server" Visible="false" Text='<%# Bind("MKT")%>' />
                                                                    <asp:Label ID="lblMktName" runat="server" Visible="false" Text='<%# Bind("MKTName")%>' />
                                                                    <asp:Label ID="lblMfgName" runat="server" Visible="false" Text='<%# Bind("Manufaturer_Name")%>' />
                                                                    <asp:Label ID="lblGVMFG" runat="server" Visible="false" Text='<%# Bind("Manufacturer_ID")%>' />
                                                                    <asp:Label ID="lblGVFlatRate" runat="server" Visible="false" Text='<%# Bind("Flat_Rate")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                <ItemStyle Wrap="false" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vat %">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVat" runat="server" Text='<%# Bind("Purchase_VAT") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVDiscount" runat="server" Visible="False" Text='<%# Bind("Trade_discount") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVDiscountAmt" runat="server" Visible="False" Text='<%# Bind("TradeDiscountAmt","{0:0.00}") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVTaxon" runat="server" Visible="False" Text='<%# Bind("Tax_Str_ID") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVTax" runat="server" Visible="False" Text='<%# Bind("Purchase_Tax_ID") %>'></asp:Label>
                                                                    <%--<asp:Label ID="lblGVVAT" runat="server" Visible="False" Text='<%# Bind("Purchase_VAT") %>'></asp:Label>
                                                                <asp:Label ID="lblGVCST" runat="server" Visible="False" Text='<%# Bind("Purchaes_CST") %>'></asp:Label>--%>
                                                                    <asp:Label ID="lblGVTaxAB" runat="server" Visible="False" Text='<%# Bind("Tax_beforeAfter_Discount") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVVATAmount" runat="server" Visible="False" Text='<%# Bind("Pur_VAT_Amt") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CST %">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCST" runat="server" Text='<%# Bind("Purchaes_CST") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVCSTAmount" runat="server" Visible="false" Text='<%# Bind("Pur_CST_Amt") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Disc %">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Trade_discount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Flat Rate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFlatRateId" runat="server" Text='<%# Bind("Flat_Rate","{0:0.00}")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Final Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGVFinalAmount" runat="server" Text='<%# Bind("Final_Amount","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </center>
                                        </td>
                                    </tr>
                                </table>
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
</html
