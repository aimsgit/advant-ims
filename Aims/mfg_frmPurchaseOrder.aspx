<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mfg_frmPurchaseOrder.aspx.vb"
    Inherits="mfg_frmPurchaseOrder" Title="Purchase Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Purchase Order</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlSupplier.ClientID %>"), 'Supplier');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtPONo.ClientID %>"), 'PO No');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtPODate.ClientID %>"), 'PO Date');
            if (msg != "") return msg;
            return true;
        }

        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID %>"), 'Product');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlUnit.ClientID %>"), 'Unit');
            if (msg != "") return msg;
            msg = Field1(document.getElementById("<%=txtQuantity.ClientID %>"), 'Quantity');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo2.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg2.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo2.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg2.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
       
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <center>
                        <h1 class="headingTxt">
                            PURCHASE ORDER
                        </h1>
                    </center>
                    <br />
                    <br />
                    <hr />
                    <asp:Panel ID="PurchaseOrder" runat="server">
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSupplier" runat="server" SkinID="lbl" Text="Supplier*^&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSupplier" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                            DataSourceID="odsSupplier" DataTextField="Supp_Name" DataValueField="Supp_Id"
                                            AppendDataBoundItems="true">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsSupplier" runat="server" TypeName="mfg_PurchaseOrderDL"
                                            SelectMethod="GetSupplierDetails"></asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblPOVALDate" runat="server" SkinID="lblRsz" Text="PO Validity Date&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1" Width="140px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPOVALDate" runat="server" SkinID="txt" MaxLength="22" TabIndex="5"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                            Format="dd-MMM-yyyy" TargetControlID="txtPOVALDate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAddress" runat="server" SkinID="lbl" Text="Address&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" SkinID="txt" MaxLength="22" TabIndex="2"
                                            TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Text="Payment Method&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1" Width="140px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                            DataTextField="Payment_Method" DataValueField="PaymentMethodID" AppendDataBoundItems="true"
                                            SkinID="ddl" TabIndex="6">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodComboD"
                                            TypeName="mfg_PurchaseOrderDL"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPONo" runat="server" SkinID="lbl" Text="PO No*^&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPONo" runat="server" SkinID="txt" MaxLength="22" TabIndex="3"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblDivideOrder" runat="server" SkinID="lblRsz" Text="Divide Order&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDivideOrder" runat="server" SkinID="txt" MaxLength="22" TabIndex="7">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" ValidChars="1234567890. " TargetControlID="txtDivideOrder">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPODate" runat="server" SkinID="lblRsz" Text="PO Date*^&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPODate" runat="server" SkinID="txt" MaxLength="22" TabIndex="4"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                            Format="dd-MMM-yyyy" TargetControlID="txtPODate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblEmail" runat="server" SkinID="lbl" Text="Email&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" SkinID="txt" Enabled="false" MaxLength="22"
                                            TabIndex="8"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" MaxLength="22" TextMode="MultiLine"
                                            TabIndex="9">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <hr />
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="200px" Text="Purchase Requisition No :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPurchaseReqNo" runat="server" DataSourceID="ObjPurchaseReqNo"
                                            DataTextField="PurchaseRequisitionNo" DataValueField="PurchaseRequisitionNoId"
                                            SkinID="ddlRsz" TabIndex="1" Width="205" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjPurchaseReqNo" runat="server" SelectMethod="PuurchaseRequisitionNo1"
                                            TypeName="DLPurchaseRequisition"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <hr />
                        <b>Other Details : </b>
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTransp" runat="server" SkinID="lblRsz" Text="Transportation Mode&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlShipment" runat="server" SkinID="ddl" TabIndex="10" DataTextField="Shipping_Method"
                                            DataValueField="ShippingAutoNo" AppendDataBoundItems="true" DataSourceID="ObjTransport">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjTransport" runat="server" SelectMethod="DDLTransport"
                                            TypeName="mfg_PurchaseOrderDL"></asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblShipment" runat="server" SkinID="lblRsz" Text="Shipment Address&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtShipment" runat="server" SkinID="txt" MaxLength="22" TabIndex="11"
                                            TextMode="MultiLine">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <hr />
                        <center>
                            <table>
                                <br />
                                <br />
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="12" Text="ADD PO" />
                                        &nbsp;
                                        <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="13"
                                            Text="VIEW PO" />
                                        &nbsp;
                                        <asp:Button ID="LinkAddDtls" Text="ADD PRODUCT" runat="server" CssClass="ButtonClass"
                                            SkinID="btnRsz" Width="130px" TabIndex="14"></asp:Button>
                                        &nbsp;
                                        <asp:Button ID="btnPost" Text="POST" runat="server" CssClass="ButtonClass" SkinID="btn"
                                            TabIndex="15"></asp:Button>
                                        &nbsp;
                                        <asp:Button ID="btnPrint" Text="PRINT" runat="server" CssClass="ButtonClass" SkinID="btn"
                                            TabIndex="16"></asp:Button>
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
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
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
                    </asp:Panel>
                    <asp:Panel ID="GV1Panel" runat="server" ScrollBars="Auto" Width="650px" Visible="false">
                        <asp:GridView ID="GVPurchaseOrderDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="200" SkinID="GridView">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Font-Underline="False" Text="Edit" TabIndex="28"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" TabIndex="29"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle Font-Underline="False" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ControlStyle Font-Underline="False" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" TabIndex="5" OnCheckedChanged="CheckAll"
                                            Width="50px" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkPO" runat="server" TabIndex="6" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                        <asp:HiddenField ID="POMainID" runat="server" Value='<%# Bind("POMain_ID") %>' />
                                        <asp:HiddenField ID="HIDSUPPID" runat="server" Value='<%# Bind("Company_ID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PO No.">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HIDAddress" runat="server" Value='<%# Bind("Supp_Address") %>' />
                                        <asp:Label ID="lblPONo" runat="server" Text='<%# Bind("Purchase_Order_Number") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PO Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPODate" runat="server" Text='<%# Bind("PO_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PO Validity Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValid" runat="server" Text='<%# Bind("Valid_Upto","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Method">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HIDPayment_ID" runat="server" Value='<%# Bind("Payment_ID") %>' />
                                        <asp:Label ID="lblPayment" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Divide Order">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivideOrder" runat="server" Text='<%# Bind("Field1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="E-Mail">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEMail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transportation Mode">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HIDTransportMode" runat="server" Value='<%# Bind("Ship_Method_ID") %>' />
                                        <asp:Label ID="lblTransportMode" runat="server" Text='<%# Bind("Shipping_Method") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shipment Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipmentAdd" Width="100px" runat="server" Text='<%# Bind("Ship_Address") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Post Status">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HIDPost" runat="server" Value='<%# Bind("Posted_To_Stock") %>' />
                                        <asp:Label ID="lblPost" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="AddDetails" runat="server" Visible="false">
                        <center>
                            <h1 class="headingTxt">
                                ADD PRODUCT
                            </h1>
                            <hr />
                            <table class="custTable">
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:RadioButtonList ID="RbProduct" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                            SkinID="Themes" TabIndex="16" Width="398px">
                                            <asp:ListItem Selected="True" Text=" Raw Materials" Value="1"></asp:ListItem>
                                            <asp:ListItem Text=" ReadyMade" Value="2"></asp:ListItem>
                                            <asp:ListItem Text=" Finished Goods" Value="3"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCurrency" runat="server" SkinID="lbl" Text="Currency&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCurrency" TabIndex="17" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                            AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblExchRate" SkinID="lbl" runat="server" Text="Exch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExRate" SkinID="txt" runat="server" TabIndex="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblProduct" runat="server" SkinID="lbl" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLProduct" SkinID="ddlRsz" runat="server" DataSourceID="ObjProduct"
                                            DataValueField="Product_Id" DataTextField="Product_Name" AutoPostBack="true"
                                            TabIndex="19" Width="250px">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboD1"
                                            TypeName="mfg_PurchaseOrderDL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="RbProduct" Name="Id" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                             <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlPurchaseReqNo" Name="PId" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblUnit" runat="server" SkinID="lbl" Text="Unit*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUnit" SkinID="ddl" runat="server" DataSourceID="ObjUnit"
                                            DataValueField="Unit_ID" DataTextField="Unit" TabIndex="20">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="UnitCombo" TypeName="mfg_PurchaseOrderDL">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Quantity Requested&nbsp;:&nbsp;&nbsp;" Width="175"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQtyReq" SkinID="txt" runat="server" TabIndex="21" ReadOnly="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtQtyReq">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblQuntity" runat="server" SkinID="lbl" Text="Quantity*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuantity" SkinID="txt" runat="server" TabIndex="21"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtQuantity">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblUnitRate" runat="server" SkinID="lblRsz" Text="Unit Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUnitRate" SkinID="txt" runat="server" TabIndex="22"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td class="btnTd" colspan="2" align="center">
                                        <asp:Button ID="BtnADD2" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                            OnClientClick="return Validate1();" SkinID="btnRsz" TabIndex="23" Text="ADD PRODUCT"
                                            Width="120px" />&nbsp;
                                        <asp:Button ID="BtnViewProduct" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="24" Text="VIEW PRODUCT" Width="120px" />&nbsp;
                                        <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="25" Text="CLOSE" />&nbsp;
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
                                                <asp:Label ID="msginfo2" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblmsg2" runat="server" SkinID="lblGreen"></asp:Label>
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
                    </asp:Panel>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px">
                        <asp:GridView ID="GVPODetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" SkinID="GridView">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Font-Underline="False" Text="Edit" TabIndex="26"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" TabIndex="27"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle Font-Underline="False" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ControlStyle Font-Underline="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HIDProdType" runat="server" Value='<%# Bind("ProductType") %>' />
                                        <asp:HiddenField ID="HIDProductID" runat="server" Value='<%# Bind("Product_Id") %>' />
                                        <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                        <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("PODetailSubID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Manufacturer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblManufac" runat="server" Text='<%# Bind("Manufaturer_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Currency">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrency" runat="server" Text='<%# Bind("Currency_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exchange Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExchRate" runat="server" Text='<%# Bind("Buy_Conversion_Rate","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HIDUnit_ID" runat="server" Value='<%# Bind("Unit_ID") %>' />
                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitRate" runat="server" Text='<%# Bind("Currency_Rate","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estimated Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstimatedValue" runat="server" Text='<%# Bind("EstimatedValue","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Type" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdTypeCode" runat="server" Text='<%# Bind("ProductType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdType" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <a name="Bottom">
                        <div align="right">
                            <a href="#Top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                        </div>
                    </a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</form>
</body>
</html>