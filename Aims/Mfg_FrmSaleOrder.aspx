<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmSaleOrder.aspx.vb"
    Inherits="FrmSaleOrderMfg" Title="Sale Order/Quotation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Order/Quotation</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDlBuyer.ClientID %>"), 'Buyer');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtSO_NO.ClientID %>"), 'SO No');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtSODate.ClientID %>"), 'SO Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate1() {

            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID %>"), 'Product');
            if (msg != "") return msg;
            msg = Field1(document.getElementById("<%=txtQuantity.ClientID %>"), 'Quantity');
            if (msg != "") return msg;
            msg = numeric(document.getElementById("<%=txtEstimatedprice.ClientID %>"), 'Estimated Price');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg1.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg1.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg1.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg1.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <%--  <h1 class="headingTxt">
                    QUOTATION/SALE ORDER</h1>--%>
                    <asp:Label ID="lblQuotation" runat="server" Font-Bold="True" SkinID="lbl" Text="QUOTATION"
                        Font-Size="15pt"></asp:Label>
                </center>
                <center>
                    <asp:Label ID="lblSaleorderHeader" Font-Bold="True" runat="server" Text="SALE ORDER"
                        Font-Size="15pt" SkinID="lbl"></asp:Label>
                </center>
                <hr />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbuyer" runat="server" SkinID="lbl" Text="Buyer*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                    DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" TabIndex="1"
                                    Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblSOValidity" runat="server" SkinID="lblRsz" Text="SO Validity&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSOValidity" runat="server" SkinID="txt" MaxLength="11" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSOValidity"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Label ID="lblBuyerAddress" runat="server" SkinID="lbl" Text="Buyer Address&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBuyerAddress" runat="server" SkinID="txt" TabIndex="3" ReadOnly="True"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblpaymentMethod" runat="server" SkinID="lblRsz" Width="150" Text="Payment Method&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDlPaymentMethod" DataSourceID="ObjPaymentMethod" DataTextField="Payment_Method"
                                    DataValueField="PaymentMethodID" runat="server" SkinID="ddl" TabIndex="4">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Label ID="lblSO_NO" runat="server" SkinID="lbl" Text="SO No*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSO_NO" runat="server" AutoPostBack="true" TabIndex="5"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarkss" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Label ID="lblSODAte" runat="server" SkinID="lblRsz" Text="SO Date*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSODate" runat="server" MaxLength="11" TabIndex="7"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSODate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblInvoiceNo" runat="server" SkinID="lblRsz" Text="Invoice No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInvoiceNo" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <hr />
                </center>
                <table>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="right">
                            <b>Other Details :</b>&nbsp;&nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <caption>
                        <center>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTransportDate" runat="server" SkinID="lblRsz" Text="Transport Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTransportDate" runat="server" SkinID="txt" MaxLength="11" TabIndex="9"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                        TargetControlID="txtTransportDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTransportBy" runat="server" SkinID="lblRsz" Text="Transport By&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlTransportBy" runat="server" DataSourceID="ObjTransportBy"
                                        DataTextField="Shipping_Method" DataValueField="ShippingAutoNo" SkinID="ddl"
                                        TabIndex="10">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblShippingAddress" runat="server" SkinID="lblRsz" Text="Shipping Address&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtShippingAddress" runat="server" SkinID="txt" TabIndex="11" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="5">
                                    <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerComboD" TypeName="DLSalesOrderMfg">
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjTransportBy" runat="server" SelectMethod="transportationComboD"
                                        TypeName="DLSalesOrderMfg"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodComboD"
                                        TypeName="DLSalesOrderMfg"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </center>
                    </caption>
                </table>
                <hr />
                <center>
                    <table>
                        <tr>
                            <td colspan="5" class="btnTd">
                                <asp:Button ID="btnADD" runat="server" Text="ADD" CssClass="ButtonClass " CausesValidation="true"
                                    SkinID="btn" OnClientClick="return Validate1();" TabIndex="12" />
                                <asp:Button ID="btnView" runat="server" Text="VIEW" CausesValidation="False" SkinID="btn"
                                    CssClass="ButtonClass" TabIndex="13" />
                                <asp:Button ID="btnAddDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    Text="ADD PRODUCT" Width="130px" TabIndex="14" />
                                <asp:Button ID="Btnposttostock" runat="server" Text="POST " CssClass="ButtonClass "
                                    CausesValidation="true" SkinID="btnRsz" TabIndex="15" />
                                <asp:Button ID="btnPrint" runat="server" Text="PRINT " CssClass="ButtonClass " CausesValidation="true"
                                    SkinID="btnRsz" TabIndex="16" />
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="180px">
                                    <asp:GridView ID="GridViewSO" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" PageIndex="100">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="true" CommandName="Edit"
                                                        TabIndex="16" Text="Edit" />
                                                    <asp:LinkButton ID="Button3" runat="server" CausesValidation="true" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="17"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                        Width="50px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chkbox" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpost" runat="server" Text='<%#Bind("Posted_To_Stock1") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buyer">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSales_Order_ID" runat="server" Text='<%#Bind("Sales_Order_ID") %>'
                                                        Visible="false"></asp:Label>
                                                    <asp:Label ID="lblParty_ID" runat="server" Text='<%#Bind("Party_ID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblParty_Name" Width="100" runat="server" Text='<%#Bind("Party_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buyer Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParty_Address" Width="200" runat="server" Text='<%#Bind("Party_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SO NO">
                                                <ItemStyle Wrap="false" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSales_Order_ID1" runat="server" Text='<%#Bind("Sale_Order_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SO Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSODate" runat="server" Text='<%# Bind("Sale_Order_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SO Validity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValid_Upto" runat="server" Text='<%# Bind("Valid_Upto","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Payment Method">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaymentMethodIDAuto" runat="server" Text='<%#Bind("PaymentMethodIDAuto") %>'
                                                        Visible="false"></asp:Label>
                                                    <asp:Label ID="lblPayment_Methods" runat="server" Text='<%#Bind("Payment_Method") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sale Invoice No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSale_Invoice_No" runat="server" Text='<%#Bind("Field1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Shipping Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShip_Address" Width="200px" runat="server" Text='<%#Bind("Ship_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Transport By">
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLShip_Method" runat="server" Text='<%#Bind("Ship_Method") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblShipping_Method" runat="server" Text='<%#Bind("Shipping_Method") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Transport Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShip_Date" runat="server" Text='<%#Bind("Ship_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server">
                        <center>
                            <center>
                                <h1 class="headingTxt">
                                    ADD PRODUCT</h1>
                            </center>
                            <hr />
                            <table>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:RadioButtonList ID="RbProduct" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                            SkinID="Themes" TabIndex="18" Width="398px">
                                            <asp:ListItem Selected="True" Text="ReadyMade" Value="1"></asp:ListItem>
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
                                        <asp:Label ID="lblProduct" runat="server" SkinID="lbl" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLProduct" runat="server" AutoPostBack="true" DataSourceID="ObjProduct"
                                            DataTextField="Product_Name" DataValueField="Product_Id" SkinID="ddlRsz" TabIndex="19"
                                            Width="270px">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblQuntity" runat="server" SkinID="lbl" Text="Quantity*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQuantity" runat="server" SkinID="txt" TabIndex="20"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtQuantity">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblEstimatedprice" Width="200px" runat="server" SkinID="lblRsz" Text="Estimated Price&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEstimatedprice" runat="server" SkinID="txt" TabIndex="21"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtEstimatedprice">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCurrency" runat="server" SkinID="lbl" Text="Currency&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cmbCurrency" runat="server" AutoPostBack="true" DataSourceID="ObjMC"
                                            DataTextField="Currency_Name" DataValueField="Currency_Code" SkinID="ddl" TabIndex="22">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbltxtExRate" SkinID="lbl" runat="server" Text="Exch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtExRate" SkinID="txt" runat="server" ReadOnly="True" TabIndex="23"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboDD"
                                            TypeName="DLSalesOrderMfg">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="RbProduct" Name="Id" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="UnitCombo" TypeName="mfg_PurchaseOrderDL">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td class="btnTd" colspan="2" align="center">
                                        <asp:Button ID="Btnadd1" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                            SkinID="btnRsz" TabIndex="24" Text="ADD PRODUCT" OnClientClick="return Validate();"
                                            Width="120px" />
                                        <asp:Button ID="BtnView1" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btnRsz" TabIndex="25" Width="120px" Text="VIEW PRODUCT" />
                                        <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btnRsz" TabIndex="26" Text="CLOSE" />&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <div>
                                                <asp:Label ID="LblMsg1" runat="server" SkinID="lblGreen"></asp:Label>
                                                <asp:Label ID="lblErrorMsg1" runat="server" SkinID="lblRed"></asp:Label>
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
                        <asp:Panel ID="panel" runat="server" ScrollBars="Auto" Width="600px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                SkinID="GridView" PageIndex="100">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Button1" runat="server" CausesValidation="true" CommandName="Edit"
                                                TabIndex="27" Text="Edit" />
                                            <asp:LinkButton ID="Button3" runat="server" CausesValidation="true" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="28"
                                                Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSODetailSubID" runat="server" Visible="false" Text='<%#Bind("SODetailSubID") %>'></asp:Label>
                                            <asp:Label ID="lblProductID" runat="server" Visible="false" Text='<%#Bind("Product_ID") %>'></asp:Label>
                                            <asp:Label ID="lblProduct_Name" runat="server" Text='<%#Bind("Product_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity_Ordered" runat="server" Text='<%# Bind("Quantity_Ordered") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estimated Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCurrency_Rate" runat="server" Text='<%#Bind("Currency_Rate","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Currency">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcurrencycode" runat="server" Visible="false" Text='<%#Bind("Currency_Code1") %>'></asp:Label>
                                            <asp:Label ID="lblCurrency_Name" runat="server" Text='<%#Bind("Currency_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Exchange Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCurrency_Factor" runat="server" Text='<%#Bind("Currency_Factor","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRBProduct" Visible="false" runat="server" Text='<%#Bind("Field2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </asp:Panel>
                </center>
                <style type="text/css">
                    .completeListStyle
                    {
                        height: 100px;
                        width: 50px;
                        overflow: auto;
                        list-style-type: disc;
                        padding-left: 17px;
                        background-color: #FFF;
                        border: 1px solid DarkGray;
                        text-align: left;
                        font-size: small;
                        color: black;
                    }
                </style>
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