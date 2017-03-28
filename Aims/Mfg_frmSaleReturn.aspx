<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmSaleReturn.aspx.vb"
    Inherits="Mfg_frmSaleReturn" Title="Sale Return" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Return</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
//            msg = DropDownForZero(document.getElementById("<%=DDlBuyer.ClientID %>"), 'Buyer');
//            if (msg != "") return msg;

            msg = Field50(document.getElementById("<%=txtReturnNo.ClientID %>"), 'Return No');
            if (msg != "") return msg;
            msg = Field250N(document.getElementById("<%=txtRemaks.ClientID %>"), 'Remarks');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtReturnDate.ClientID %>"), 'Return Date');
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

            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID %>"), 'Batch');
            if (msg != "") return msg;

            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtReturnedQty.ClientID %>"), 'Qty Recvd');
            if (msg != "") return msg;
            msg = Field250N(document.getElementById("<%=txtRemarks.ClientID %>"), 'Remarks');
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
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                BackColor="#E2E3BB">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Sale Return" TabIndex="1">
                    <ContentTemplate>
                        <div>
                            <center>
                                <h1 class="headingTxt">
                                    SALE RETURN
                                </h1>
                            </center>
                        </div>
                        <br />
                        <br />
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSupplierM" runat="server" SkinID="lblRsz" Text="Buyer&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                            DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" Width="300px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerComboD" TypeName="MfgSaleInvoiceDL">
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemaks" runat="server" TextMode="MultiLine" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblReturnNo" runat="server" SkinID="lblRsz" Text="Return No*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReturnNo" runat="server" SkinID="txt"></asp:TextBox>
                                        <asp:TextBox ID="HidReturnId" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblReturnDate" runat="server" SkinID="lblRsz" Text="Return Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReturnDate" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="ReturnDate" runat="server" TargetControlID="txtReturnDate"
                                            Format="dd-MMM-yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </center>
                        <center>
                            <table>
                                <br />
                                <br />
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" Text="ADD" />
                                        &nbsp;
                                        <asp:Button ID="BtnView" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                                        &nbsp;
                                        <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            Text="ADD PRODUCTS" Width="130" />
                                        &nbsp;
                                        <asp:Button ID="btnPost" runat="server" CssClass="ButtonClass" SkinID="btn" Text="POST" />
                                        &nbsp;
                                         <asp:Button ID="btnprint" runat="server" CssClass="ButtonClass" SkinID="btn" Text="PRINT" />
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
                            <asp:Panel ID="PanelReturnM" runat="server" ScrollBars="Auto" Width="650px" Height="320px">
                                <asp:GridView ID="GridPurchaseReturnM" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="DeleteM" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" Font-Underline="False"></asp:LinkButton>
                                            </ItemTemplate>
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
                                        <asp:TemplateField HeaderText="Buyer">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("SaleReturnMainID") %>' />
                                                <asp:Label ID="lblSuppName" runat="server" Text='<%# Bind("Party_Name") %>' />
                                                <asp:Label ID="lblSupppId" runat="server" Visible="false" Text='<%# Bind("Party_ID") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPurchReturnId" runat="server" Visible="false" Text='<%# Bind("Sale_ReturnMain_ID") %>'></asp:Label>
                                                <asp:Label ID="lblPurchReturnNo" runat="server" Text='<%# Bind("SaleReturnNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="false" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReturnInvoiceDateGV" runat="server" Text='<%# Bind("SaleReturnDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarksGV" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Sale Return Details"
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
                                        <asp:Label ID="lblProduct" runat="server" SkinID="lblRsz" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDLProduct" SkinID="ddlRsz"  Width="200px"  runat="server" DataValueField="Product_Id"
                                            DataTextField="Product_Name" AutoPostBack="true">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="GetSupplierStock"
                                            TypeName="Mfg_DLPurchaseReturn">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="RbProduct" Name="Id" PropertyName="SelectedValue" />
                                               <asp:ControlParameter ControlID="ddlSupplier"   DefaultValue="0"  Name="Supp_Id"  Type="Int16" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>--%>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblInvoiceNo" runat="server" SkinID="lblRsz" Text="Invoice No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtInvoiceNO" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                        <asp:TextBox ID="HidTxtInvoiceId" runat="server" Visible="false" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBatchS" runat="server" Text="Batch* :&nbsp;&nbsp;"  SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlBatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                            DataValueField="Batchid" DataTextField="BatchNo" Width="200px" AutoPostBack="true">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchDDL" TypeName="Mfg_DLSaleReturn">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DDLProduct" Name="Id" PropertyName="SelectedValue" />
                                                <%--<asp:ControlParameter ControlID="ddlSupplier"   DefaultValue="0"  Name="Supp_Id"  Type="Int16" PropertyName="SelectedValue" />--%>
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblInvoiceDate" SkinID="lblRsz" runat="server" Text="Invoice Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtInvoiceDate" SkinID="txt" Enabled="false" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblReturnQty" runat="server" Text="Returned Qty* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReturnedQty" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtReturnedQty" />
                                    </td>
                                   
                                   <td align="right">
                                        <asp:Label ID="lblExpiry" runat="server" Text="Expiry Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtExpiryDate" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblProductRemarks" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                   
                                    <td align="right">
                                        <asp:Label ID="lblFlatRate" runat="server" Text="Flat Rate :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFlatRate" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
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
                                        <asp:Label ID="lblQtyInStock" SkinID="lblRsz" runat="server" Text="Qty in Stock&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQtyIn" SkinID="txt" Enabled="false" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblExchRate" SkinID="lblRsz" runat="server" Text="Exch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtExRate" SkinID="txt" Enabled="false" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblUsedQty" SkinID="lblRsz" runat="server" Text="Used Qty&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtUsedQty" SkinID="txt" Enabled="false" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtstockid" SkinID="txt" Visible="false" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtPrd_id" SkinID="txt" Visible="false" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                    </td>
                                    <td align="left">
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td align="right">
                                    </td>
                                    <td align="left">
                                    </td>
                                   
                                </tr>
          <%--                      <tr>
                                    <td align="right">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblNetUsable" runat="server" SkinID="lblRsz" Text="Net Usable Qty&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNetUsableQty" SkinID="txt" Enabled="false" runat="server"></asp:TextBox>
                                    </td>
                                </tr>--%>
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
                                                <asp:GridView ID="GVPRDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    PageSize="100" SkinID="GridView">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="EditProduct" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                                <asp:LinkButton ID="DeteteProduct" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                    Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Inv No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVPurchaseInvoiceNO" runat="server" Text='<%# Bind("Sale_Invoice_No") %>'></asp:Label>
                                                                <asp:Label ID="GVPurchaseInvoiceID" runat="server" Visible="false" Text='<%# Bind("Field2")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Product">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                                <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("SRID") %>' />
                                                                
                                                                <asp:HiddenField ID="GVSupplier" runat="server" Value='<%#Bind("Party_ID") %>' />
                                                                <asp:Label ID="lblGVReturnId" runat="server" Visible="false" Text='<%# Bind("SaleReturn_ID")%>' />
                                                                <asp:HiddenField ID="lblProductID" runat="server" Value='<%# Bind("Product_ID") %>' />
                                                                <%--<asp:HiddenField ID="lblGVProductType" runat="server" Value='<%# Bind("Field5") %>'/>--%>
                                                                <%-- <asp:Label ID="GVlblBatchId" runat="server" Visible="false" Text='<%# Bind("Batch_ID")%>' />
                                                                <asp:Label ID="GVlblBatch" runat="server"  Text='<%# Bind("Batch")%>' />
                                                                --%>
                                                                <asp:Label ID="GVlblStockId" runat="server" Visible="false" Text='<%# Bind("Stock_ID")%>' />
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
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Currency">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVCurrencycode" runat="server" Visible="false" Text='<%# Bind("Currency_Code") %>'></asp:Label>
                                                                <asp:Label ID="GVCurrency" runat="server" Text='<%# Bind("Currency_Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Exchange Rate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVlblExchangeRate" runat="server" Text='<%# Bind("Currency_Factor","{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Expiry">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGVExpiry" runat="server" Text='<%# Bind("Expiry","{0:dd-MMM-yyyy}") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Qty Returned">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQtyRecvdID" runat="server" Text='<%# Bind("Return_Qty") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat Rate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVLblFlat_Rate" runat="server" Text='<%# Bind("FlatRate","{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Adjustment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVlblAdjustment" runat="server" Text='<%# Bind("Adjustment","{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                <asp:Label ID="GVlblBatchID" runat="server" Visible="false" Text='<%# Bind("BatchCmd") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
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
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

