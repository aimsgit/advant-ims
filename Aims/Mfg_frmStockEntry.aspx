<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmStockEntry.aspx.vb"
    Inherits="Mfg_frmStockEntry" Title="Stock Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stock Entry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtEntryDate.ClientID %>"), 'Entry Date');
            if (msg != "") return msg;

            msg = Field250N(document.getElementById("<%=txtRemarks.ClientID %>"), 'Remarks');
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
       
    </script>

    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID %>"), 'Product');
            if (msg != "") return msg;

            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtquantity.ClientID %>"), 'Qty');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlUnit.ClientID %>"), 'Unit');
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
                <div>
                    <center>
                        <h1 class="headingTxt">
                            STOCK ENTRY
                        </h1>
                    </center>
                </div>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEntry" runat="server" Width="150" SkinID="lblRsz" Text="Entry Date*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntryDate" runat="server" SkinID="txt" MaxLength="22" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="datetxtEntryDate" runat="server" TargetControlID="txtEntryDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td align="right" width="50px">
                                <asp:Label ID="lblSO" runat="server" SkinID="lbl" Width="50px" Text="SO^&nbsp;:&nbsp;&nbsp;"
                                    TabIndex="-1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSO" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataSourceID="ObjSO" DataTextField="Sale_Order_Number" DataValueField="Sales_Order_ID"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSO" runat="server" TypeName="Mfg_DLStockEntry" SelectMethod="GetSalesOrder">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTranscation" runat="server" SkinID="lblRsz" Text="Transaction Type&nbsp;:&nbsp;&nbsp;"
                                    TabIndex="-1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTranscation" runat="server" DataTextField="Payment_Method"
                                    DataValueField="PaymentMethodID" AppendDataBoundItems="true" SkinID="ddl" TabIndex="3">
                                    <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                    <asp:ListItem Value="2">Consignment</asp:ListItem>
                                    <asp:ListItem Value="3">Received Items</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="50px">
                                <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"
                                    TabIndex="-1" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="4" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="HidInvoice" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="HidInvoiceNO" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="HidPost" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <center>
                   <table class="custTable">
                        <tr>
                        <td align ="right" >
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTotalAmt" runat="server" SkinID="lblRsz"  Text="Total Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtTotalAmt" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAddVatAmt" runat="server" SkinID="lblRsz" Width ="150px" Text="Add Vat Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAddVatAmt" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right">
                                        <asp:Label ID="lblFinlAmt" runat="server" SkinID="lblRsz"  Text="Final Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFinlAmt" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                 
                               
                              </table> 
                                </td>
                                
                                <td align ="left" >
                                 <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRound" runat="server" SkinID="lbl" Text="Round Off&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRound" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblGrndTtl" runat="server" SkinID="lblRsz" Width="180px" Text="Grand Total Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtGrand" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLessDiscAmt" runat="server" Width ="180px" SkinID="lblRsz" Text="Less Discount Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtLessDiscAmt" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                
                               
                              </table> 
                                
                                
                                </td>
                            </table>
                    </center>
                <center>
                    <table>
                        <caption>
                            <br />
                            <br />
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="ADD" />
                                    &nbsp;
                                    <asp:Button ID="BtnStockView" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="6" Text="VIEW" />
                                    &nbsp;
                                    <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="7" Text="ADD PRODUCTS" Width="130" />
                                    &nbsp;
                                    <asp:Button ID="btnPost" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                        Text="POST" />
                                    &nbsp;
                                    <asp:Button ID="btnPrint" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                        Text="PRINT" />
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
                        </caption>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="PanelStock" runat="server" ScrollBars="Auto" Width="650px">
                        <asp:GridView ID="GridStockEntryM" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" SkinID="GridView">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Font-Underline="False" TabIndex="9" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="DeleteM" runat="server" TabIndex="10" CausesValidation="False"
                                            CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Font-Underline="False"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                            TabIndex="6" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                            TabIndex="7" Text="Back"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                            Width="50px" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkRL" runat="server" TabIndex="6" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entry Date">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("PurchMain") %>' />
                                        <asp:Label ID="lblGVEntrydate" runat="server" Text='<%# Bind("VAT_Invoice_Date","{0:dd-MMM-yyyy}") %>' />
                                        <asp:Label ID="lblgvinvoiceId" runat="server" Visible="false" Text='<%# Bind("Purchase_Invoice_ID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGVTranscationID" runat="server" Visible="false" Text='<%# Bind("TransactionType") %>'></asp:Label>
                                        <asp:Label ID="lblGVTranscationType" runat="server" Text='<%# Bind("Field3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SO">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGVSOID" runat="server" Visible="false" Text='<%# Bind("SO_ID") %>'></asp:Label>
                                        <asp:Label ID="lblGVSO" runat="server" Text='<%# Bind("Sale_Order_Number") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGVRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Posted">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <asp:Panel ID="Details" runat="server">
                    <div>
                        <br />
                        <hr />
                        <center>
                            <h1 class="headingTxt">
                                ADD STOCK ENTRY DETAILS</h1>
                        </center>
                        <center>
                            <center>
                                <hr />
                                <table class="custTable">
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:RadioButtonList ID="RbProduct" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                SkinID="Themes" TabIndex="11" Width="398px">
                                                <asp:ListItem Selected="True" Text="Raw Materials" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="ReadyMade" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Finished Goods" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCurrency" runat="server" SkinID="lbl" Text="Currency&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCurrency" TabIndex="12" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                                AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="Mfg_DLStockEntry">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label5" SkinID="lbl" runat="server" Text="Packing&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPacking" Enabled="false" TabIndex="13" SkinID="txt" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExchRate" SkinID="lbl" runat="server" Text="Exch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtExRate" SkinID="txt" runat="server" TabIndex="14"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label7" SkinID="lbl" runat="server" Text="Sale Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSaleRate" SkinID="txt" runat="server" TabIndex="15"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblProduct" runat="server" SkinID="lbl" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDLProduct" SkinID="ddl" runat="server" DataSourceID="ObjProduct"
                                                DataValueField="Product_Id" DataTextField="Product_Name" TabIndex="16" AutoPostBack="true">
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
                                            <asp:Label ID="Label6" SkinID="lbl" runat="server" Text="Purch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBox2" SkinID="txt" runat="server" TabIndex="17"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label11" Width="150px" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBatch" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                                            <asp:TextBox ID="HIDBatch" runat="server" Visible="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" SkinID="lbl" runat="server" Text="MRP&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMRP" SkinID="txt" runat="server" TabIndex="19"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpirydate" Width="150px" runat="server" Text="Expiry :&nbsp;&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtExpiry" runat="server" SkinID="txt" TabIndex="20"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label9" SkinID="lbl" runat="server" Text="Discount(%)&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDiscount" SkinID="txt" runat="server" TabIndex="21"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Text="Purchase Deal* :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPurchase" runat="server" TabIndex="22" Width="58px"></asp:TextBox>
                                            &nbsp;+&nbsp;
                                            <asp:TextBox ID="txtPurchase1" runat="server" TabIndex="23" Width="57px"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label12" SkinID="lbl" runat="server" Text="Discount Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDiscountAmt" SkinID="txt" runat="server" TabIndex="24"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblQty" runat="server" SkinID="lbl" Text="Quantity*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtquantity" SkinID="txt" runat="server" TabIndex="25"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="Tax on*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTaxOn" SkinID="ddlRsz" runat="server" TabIndex="26">
                                                <asp:ListItem Selected="True"  Text="Purchase Price with tax on free goods" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Purchase Price without tax on free goods" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="MRP with tax on free goods" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="MRP without tax on free goods" Value="4"></asp:ListItem>
                                                
                                                
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label16" runat="server" Text="Unit*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="170px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlUnit" SkinID="ddl" runat="server" TabIndex="27" DataSourceID="ObjUnit"
                                                DataTextField="Unit" DataValueField="Unit_ID" AutoPostBack="True">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="getUnit" TypeName="Mfg_DLProductDetails">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="Tax A/B Disc&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTaxAB" SkinID="ddl" runat="server" TabIndex="28">
                                                <asp:ListItem Selected="True" Text="A" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="MFG&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMFG" SkinID="ddl" runat="server" TabIndex="29" DataSourceID="ObjMFG"
                                                DataValueField="Manufacturer_ID" DataTextField="Manufaturer_Name">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjMFG" runat="server" SelectMethod="GetManufacturerMFG"
                                                TypeName="Mfg_DLStockEntry"></asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="Tax Plan*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTaxPlan" SkinID="ddl" TabIndex="30" runat="server" DataSourceID="ObjTaxPlan"
                                                DataValueField="Tax_ID" DataTextField="Tax_Description" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjTaxPlan" runat="server" SelectMethod="getPurchaseTaxPlan"
                                                TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="MKT&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMKT" SkinID="ddl" runat="server" TabIndex="31" DataSourceID="ObjMkt"
                                                DataValueField="Manufacturer_ID" DataTextField="Manufaturer_Name">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjMkt" runat="server" SelectMethod="GetManufacturerMKT"
                                                TypeName="Mfg_DLStockEntry"></asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbltaxVAT" runat="server" SkinID="lbl" Text="VAT%&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtVAT" Enabled="false" SkinID="txt" TabIndex="32" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblGodown" runat="server" SkinID="lbl" Text="Godown&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlGoDown" TabIndex="33" runat="server" Enabled="false" SkinID="ddl"
                                                AutoPostBack="True">
                                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbltaxCST" runat="server" SkinID="lbl" Text="CST%&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCST" Enabled="false" SkinID="txt" runat="server" TabIndex="34"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="HidFlatRate" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRack" runat="server" SkinID="lbl" Text="Rack No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlRack" TabIndex="35" runat="server" Enabled="false" SkinID="ddl"
                                                AutoPostBack="True">
                                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="HidMInvoice" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
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
                                        <td class="btnTd" colspan="4" align="center">
                                            <asp:Button ID="btnAdddet" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                                OnClientClick="return Validate1();" SkinID="btn" TabIndex="36" Text="ADD" />&nbsp;
                                            <asp:Button ID="btnView" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                                SkinID="btn" TabIndex="37" Text="VIEW" />&nbsp;
                                            <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" TabIndex="38" Text="CLOSE" />&nbsp;
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
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        Font-Underline="False" TabIndex="39" Text="Edit"></asp:LinkButton>
                                                                    <asp:LinkButton ID="DeteteStock" runat="server" CausesValidation="False" TabIndex="40"
                                                                        CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
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
                                                                    <asp:HiddenField ID="HIDExRate" runat="server" Value='<%# Bind("FlatRate_AD") %>' />
                                                                    <asp:HiddenField ID="HIDCurrency" runat="server" Value='<%# Bind("Currency") %>' />
                                                                    <asp:HiddenField ID="Producttype" runat="server" Value='<%# Bind("ProductType") %>' />
                                                                    <asp:Label ID="lblGVBatch" Visible="false" runat="server" Text='<%# Bind("Batch") %>' />
                                                                    <asp:Label ID="lblGVBatchID" Visible="false" runat="server" Text='<%# Bind("Batch_Id") %>' />
                                                                    <asp:Label ID="lblGVQty" Visible="false" runat="server" Text='<%# Bind("Deal_Qty") %>' />
                                                                    <asp:Label ID="lblGVFree" runat="server" Visible="false" Text='<%# Bind("Deal_Free") %>' />
                                                                    <asp:Label ID="lblGVExpiry" runat="server" Visible="false" Text='<%# Bind("ExpiryDate","{0:dd-MMM-yyyy}") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitId" runat="server" Visible="false" Text='<%# Bind("Field2") %>'></asp:Label>
                                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalQty" runat="server" Text='<%# Bind("Total_Qty","{0:0.00}") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVMKT" runat="server" Visible="false" Text='<%# Bind("MKT")%>' />
                                                                    <asp:Label ID="lblMktName" runat="server" Visible="false" Text='<%# Bind("MKTName")%>' />
                                                                    <asp:Label ID="lblMfgName" runat="server" Visible="false" Text='<%# Bind("Manufaturer_Name")%>' />
                                                                    <asp:Label ID="lblGVMFG" runat="server" Visible="false" Text='<%# Bind("Manufacturer_ID")%>' />
                                                                    <asp:Label ID="lblGVFlatRate" runat="server" Visible="false" Text='<%# Bind("Flat_Rate")%>' />
                                                                    <asp:Label ID="lblGVPacking" runat="server" Visible="false" Text='<%# Bind("Packing_Details")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Purch Rate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPRate" runat="server" Text='<%# Bind("Purchase_Rate", "{0:n2}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sale Rate">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSrate" runat="server" Text='<%# Bind("Sale_Rate", "{0:n2}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="MRP">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMRP" runat="server" Text='<%# Bind("MRP", "{0:n2}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Bind("Amount", "{0:n2}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vat %">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVat" runat="server" Text='<%# Bind("Purchase_VAT","{0:0.00}") %>'></asp:Label>
                                                                   
                                                                    
                                                                    <asp:Label ID="lblGVDiscount" runat="server" Visible="False" Text='<%# Bind("Trade_discount") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVDiscountAmt" runat="server" Visible="False" Text='<%# Bind("TradeDiscountAmt") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVTaxon" runat="server" Visible="False" Text='<%# Bind("Tax_Str_ID") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVTax" runat="server" Visible="False" Text='<%# Bind("Purchase_Tax_ID") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVVAT" runat="server" Visible="False" Text='<%# Bind("Purchase_VAT") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVCST" runat="server" Visible="False" Text='<%# Bind("Purchaes_CST") %>'></asp:Label>
                                                                    <asp:Label ID="lblGVTaxAB" runat="server" Visible="False" Text='<%# Bind("Tax_beforeAfter_Discount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CST %">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCST" runat="server" Text='<%# Bind("Purchaes_CST","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Disc %">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Trade_discount","{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Final Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGVFinalAmount" runat="server" Text='<%# Bind("Final_Amount", "{0:n2}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            
                                                             <asp:TemplateField HeaderText="Amount" Visible ="false" >
                                                                <ItemTemplate>
                                                                
                                                                <asp:Label ID="lblVatAMT" runat="server" Text='<%# Bind("Pur_VAT_Amt","{0:0.00}") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                                   </asp:TemplateField>               
                                                                   <asp:TemplateField HeaderText="DisAmount" Visible ="false" >
                                                                <ItemTemplate>
                                                                
                                                                <asp:Label ID="lblDescAmt" runat="server" Text='<%# Bind("TradeDiscountAmt","{0:0.00}") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                                   </asp:TemplateField>                                                       
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                </asp:Panel>
                <%--</table>--%>
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
