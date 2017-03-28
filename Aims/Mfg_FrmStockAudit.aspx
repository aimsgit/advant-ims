<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmStockAudit.aspx.vb"
    Inherits="Mfg_FrmStockAudit" Title="STOCK AUDIT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STOCK AUDIT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID %>").focus()
                return msg;
            }
            return true;
        }

        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLRM.ClientID %>"), 'Product');
            if (msg != "") {
                document.getElementById("<%=DDLRM.ClientID %>").focus()
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLBatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=DDLBatch.ClientID %>").focus()
                return msg;
            }

            msg = Field1(document.getElementById("<%=txtCountDiff.ClientID %>"), 'Count Difference');
            if (msg != "") {
                document.getElementById("<%=txtCountDiff.ClientID %>").focus()
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
            }
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
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="STOCK AUDIT" TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        STOCK AUDIT
                                    </h1>
                                </center>
                                <br />
                                <br />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblStockAuditNo" runat="server" SkinID="lblRsz" Text="Stock Audit No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStockAuditNo" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSupplierM" runat="server" SkinID="lblRsz" Text="Supplier&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSupplier" runat="server" SkinID="ddl" AutoPostBack="True"
                                                DataSourceID="odsSupplier" DataTextField="Supp_Name" DataValueField="Supp_Id"
                                                AppendDataBoundItems="True">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsSupplier" runat="server" TypeName="Mfg_DLPurchaseInvoice"
                                                SelectMethod="GetSupplierDetails"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDate" runat="server" SkinID="lblRsz" Text="Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" SkinID="txt" MaxLength="11"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtDate"
                                                Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtDate" Enabled="True">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:TextBox ID="HidInvoice" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="HidInvoiceNO" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <br />
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="5" class="btnTd">
                                            <%-- <asp:Button ID="btnADDSaleInvoice" runat="server" Text="ADD" CssClass="ButtonClass "
                                            SkinID="btn" OnClientClick="return Validate();" />--%>
                                            <asp:Button ID="btnViewSaleInvoice" runat="server" Text="VIEW" CausesValidation="False"
                                                SkinID="btn" CssClass="ButtonClass" />
                                            <asp:Button ID="btnAddDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                Text="ADD DETAILS" Width="130px" OnClientClick="return Validate();" />
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
                            <br>
                                <br>
                                    <br></br>
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" Height="320px" ScrollBars="Auto" Width="650px">
                                            <asp:GridView ID="GvSaleInvoice" runat="server" align="center" AllowPaging="True"
                                                AutoGenerateColumns="False" PageSize="100" SkinID="GridView">
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <center>
                                                                <asp:LinkButton ID="LnkbtnSelect" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Text="Select"></asp:LinkButton>
                                                            </center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                                            TabIndex="6" Text="Update"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                                            TabIndex="7" Text="Back"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Stock Audit No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAuditNo" runat="server" Text='<%# Bind("Field7") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Supplier">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                                            <asp:Label ID="lblsuppid" runat="server" Text='<%# Bind("Company_ID") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date_In","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                    <br></br>
                                </br>
                            </br>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="STOCK AUDIT DETAILS"
                        TabIndex="3">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        STOCK AUDIT DETAILS
                                        <br />
                                        <br />
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblItemDesc" runat="server" SkinID="lblRsz" Text="Product* :&nbsp;&nbsp;"
                                                    Width="200"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DDLRM" runat="server" DataTextField="Product_Name" Width="200"
                                                    DataValueField="Product_Id" SkinID="ddlRsz" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <%--<asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductComboD"
                                                TypeName="Mfg_DLStockAudit">
                                                </asp:ObjectDataSource>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DDLBatch" SkinID="ddl" runat="server" DataSourceID="ObjBatch"
                                                    DataValueField="Batch_ID" DataTextField="Batch" AppendDataBoundItems="false"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchCombo" TypeName="Mfg_DLStockAudit">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="DDLRM" Name="ProductId" PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblQtyStock" Width="150px" runat="server" Text="Qty In Stock* :&nbsp;&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQtyStock" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQtyStock">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCountDiff" SkinID="lblRsz" runat="server" Text="Count Difference&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcount" SkinID="txtRsz" runat="server" Text="+" Width="30" MaxLength="1"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="+-" TargetControlID="txtcount">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:TextBox ID="txtCountDiff" SkinID="txtRsz" runat="server" Width="115"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtCountDiff">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <%--<asp:TextBox ID="HidMInvoice" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPurchaseInvId" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPRDID" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPackingDetails" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="DealQty" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="RefDate" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPurchaseRate" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtTradeDisc" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtFlatDisc" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPurchaseTaxStrId" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPurTaxBeforeAfterDisc" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtpurchaseTaxPlan" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPurchaseVAT" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPurchaseCST" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="AuditFlag" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtFlatRate" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtCurrencyCode" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtCurrencyFactor" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtSaleRate" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtMRP" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtStkDiff" SkinID="txt" runat="server" Visible="false"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlRemarks" SkinID="ddl" runat="server">
                                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    <asp:ListItem Text="Expired" Value="Expired"></asp:ListItem>
                                                    <asp:ListItem Text="Damaged" Value="Damaged"></asp:ListItem>
                                                    <asp:ListItem Text="Breakage" Value="Breakage"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <br />
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
                                                <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                                <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
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
                                    <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="700px" Height="300px">
                                        <asp:GridView ID="GVProdDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
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
                                                <asp:TemplateField HeaderText="Product">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="lblStkId" runat="server" Value='<%# Bind("Stock_ID") %>'></asp:HiddenField>
                                                        <asp:HiddenField ID="QtyinStk" runat="server" Value='<%# Bind("Field6") %>'></asp:HiddenField>
                                                        <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product_Name") %>' Width="100"></asp:Label>
                                                        <asp:HiddenField ID="lblProdId" runat="server" Value='<%# Bind("Product_ID") %>'
                                                            Visible="false"></asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Batch">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>' Width="100"></asp:Label>
                                                        <asp:HiddenField ID="lblBatchId" runat="server" Value='<%# Bind("Batch_ID") %>' Visible="false">
                                                        </asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Expiry">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExpiry" runat="server" Width="100" Text='<%# Bind("ExpiryDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty In">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQtyIn" runat="server" Width="50" Text='<%# Bind("Qty_In") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty Out">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQtyOut" runat="server" Width="50" Text='<%# Bind("Qty_Out") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemarks" runat="server" Width="50" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Discount%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("Trade_Discount") %>'></asp:Label>
                                                    <asp:Label ID="lblTradeDiscAmt" runat="server" Text='<%# Bind("TradeDiscAmt")  %>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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