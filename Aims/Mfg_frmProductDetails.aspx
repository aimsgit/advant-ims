<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmProductDetails.aspx.vb"
    Inherits="Mfg_frmProductDetails" Title="Product Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%= txtProduct.ClientID %>"), 'Product');
            if (msg != "") {
                document.getElementById("<%= txtProduct.ClientID %>").focus();
                return msg;
            }
            msg = OneChar(document.getElementById("<%= txtCode.ClientID %>"), 'Code');
            if (msg != "") {
                document.getElementById("<%= txtCode.ClientID %>").focus();
                return msg;
            }

            msg = Field50N(document.getElementById("<%= txtPacking.ClientID %>"), 'Packing Details');
            if (msg != "") {
                document.getElementById("<%= txtPacking.ClientID %>").focus();
                return msg;
            }

            msg = numeric(document.getElementById("<%= txtReorder.ClientID %>"), 'Reorder Level');
            if (msg != "") {
                document.getElementById("<%= txtReorder.ClientID %>").focus();
                return msg;
            }

            msg = Field250N(document.getElementById("<%= txtRemarks.ClientID %>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%= txtRemarks.ClientID %>").focus();
                return msg;
            }

            //            msg = DropDownForZero(document.getElementById("<%= ddlUnit.ClientID %>"), 'Unit');
            //            if (msg != "") {
            //                document.getElementById("<%= ddlUnit.ClientID %>").focus();
            //                return msg;
            //            }
            //            msg = DropDownForZero(document.getElementById("<%= ddlPurchase.ClientID %>"), 'Purchase Tax Plan');
            //            if (msg != "") {
            //                document.getElementById("<%= ddlPurchase.ClientID %>").focus();
            //                return msg;
            //            }

            //            msg = FeesField(document.getElementById("<%= txtPurchase.ClientID %>"), 'Purchase Deal');
            //            if (msg != "") {
            //                document.getElementById("<%= txtPurchase.ClientID %>").focus();
            //                return msg;
            //            }
            //            msg = FeesField(document.getElementById("<%= txtPurchase1.ClientID %>"), 'Purchase Deal');
            //            if (msg != "") {
            //                document.getElementById("<%= txtPurchase1.ClientID %>").focus();
            //                return msg;
            //            }
            //            msg = FeesField(document.getElementById("<%= txtPurchaseRate.ClientID %>"), 'Purchase Rate');
            //            if (msg != "") {
            //                document.getElementById("<%= txtPurchaseRate.ClientID %>").focus();
            //                return msg;
            //            }
            //            msg = FeesField(document.getElementById("<%= txtMRP.ClientID %>"), 'MRP');
            //            if (msg != "") {
            //                document.getElementById("<%= txtMRP.ClientID %>").focus();
            //                return msg;
            //            }
            //            msg = FeesField(document.getElementById("<%= txtSales.ClientID %>"), 'Sale Rate');
            //            if (msg != "") {
            //                document.getElementById("<%= txtSales.ClientID %>").focus();
            //                return msg;
            //            }
            msg = FeesFieldN(document.getElementById("<%= txtpurch.ClientID %>"), 'Purch Flat Rate');
            if (msg != "") {
                document.getElementById("<%= txtpurch.ClientID %>").focus();
                return msg;
            }
            //            msg = FeesField(document.getElementById("<%= txtDiscount.ClientID %>"), 'Purchase Discount');
            //            if (msg != "") {
            //                document.getElementById("<%= txtDiscount.ClientID %>").focus();
            //                return msg;
            //            }
            msg = numeric(document.getElementById("<%= txtDiscount.ClientID %>"), 'Purchase Discount');
            if (msg != "") {
                document.getElementById("<%= txtDiscount.ClientID %>").focus();
                return msg;
            }
            //            msg = DropDownForZero(document.getElementById("<%= ddlsaletax.ClientID %>"), 'Sale Tax Plan');
            //            if (msg != "") {
            //                document.getElementById("<%= ddlsaletax.ClientID %>").focus();
            //                return msg;
            //            }
            msg = ValidateDateN(document.getElementById("<%= txtoffperiod.ClientID %>"), 'Offer Period');
            if (msg != "") {
                document.getElementById("<%= txtoffperiod.ClientID %>").focus();
                return msg;
            }
            //            msg = FeesField(document.getElementById("<%= txtsaleDiscount.ClientID %>"), 'Sale Discount');
            //            if (msg != "") {
            //                document.getElementById("<%= txtsaleDiscount.ClientID %>").focus();
            //                return msg;
            //            }
            msg = numeric(document.getElementById("<%= txtsaleDiscount.ClientID %>"), 'Sale Discount');
            if (msg != "") {
                document.getElementById("<%= txtsaleDiscount.ClientID %>").focus();
                return msg;
            }
            //            msg = FeesField(document.getElementById("<%= txtsaleDeal.ClientID %>"), 'Sale Deal');
            //            if (msg != "") {
            //                document.getElementById("<%= txtsaleDeal.ClientID %>").focus();
            //                return msg;
            //            }
            //            msg = FeesField(document.getElementById("<%= txtSaleDeal1.ClientID %>"), 'Sale Deal');
            //            if (msg != "") {
            //                document.getElementById("<%= txtSaleDeal1.ClientID %>").focus();
            //                return msg;
            //            }
            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        PRODUCT DETAILS
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:RadioButtonList ID="RbTYPE" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    SkinID="Themes1" Height="20px" Width="398px" TabIndex="1">
                                    <asp:ListItem Selected="True" Value="1" Text="Ready Made "></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Raw Material"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Finished Goods"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" Width="150px" runat="server" Text="Product*^ :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProduct" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Code* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCode" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcatagry" runat="server" Text="Category :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" SkinID="ddl" runat="server" TabIndex="4" DataSourceID="ObjDescription1"
                                    DataTextField="Data" DataValueField="LookUpAutoID" AppendDataBoundItems="true">
                                    <%--  <asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDescription1" runat="server" SelectMethod="GetCategory"
                                    TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDescription" runat="server" Text="Description&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDescription" SkinID="ddl" runat="server" TabIndex="4" DataSourceID="ObjDescription"
                                    DataTextField="Description" DataValueField="Desc_Id" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Packing Details :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPacking" runat="server" SkinID="txt" MaxLength="15" TabIndex="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Supplier&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSupplier" SkinID="ddl" runat="server" DataSourceID="ObjSupplier"
                                    DataTextField="Supp_Name" TabIndex="6" DataValueField="Supp_Id" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" Text="Manuf/Company&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCompany" SkinID="ddl" runat="server" TabIndex="7" DataSourceID="ObjCompany"
                                    DataTextField="Manufaturer_Name" DataValueField="Manufacturer_ID" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Text="Reorder Level :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtReorder" runat="server" SkinID="txt" MaxLength="10" TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterMode="validChars" FilterType="Numbers" TargetControlID="txtReorder" ValidChars="0123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" Text="Unit&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" SkinID="ddl" runat="server" TabIndex="10" DataSourceID="ObjUnit"
                                    DataTextField="Unit" DataValueField="Unit_ID" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="Purchase Tax Plan&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPurchase" SkinID="ddl" runat="server" TabIndex="11" DataSourceID="ObjPurchase"
                                    DataTextField="Tax_Description" DataValueField="Tax_ID" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Text="Purchase Deal :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPurchase" SkinID="txtRsz"  runat="server" TabIndex="12" Width="57px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPurchase" />
                                &nbsp;+&nbsp;
                                <asp:TextBox ID="txtPurchase1" SkinID="txtRsz" runat="server" TabIndex="13" Width="57px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPurchase1" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" Width="150px" runat="server" Text="Purchase Rate :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPurchaseRate" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPurchaseRate" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" Width="150px" runat="server" Text="MRP :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMRP" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMRP" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label13" Width="150px" runat="server" Text="Sale Rate :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSales" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtSales" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label14" Width="160px" runat="server" Text="Purchase Flat Rate :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtpurch" runat="server" SkinID="txt" TabIndex="17"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtpurch" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label15" Width="200px" runat="server" Text="Purchase Discount% :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDiscount" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscount" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label16" runat="server" Text="Sale Tax Plan&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlsaletax" SkinID="ddl" runat="server" TabIndex="19" DataSourceID="Objsaletax"
                                    DataTextField="Tax_Description" DataValueField="Tax_ID" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label17" Width="200px" runat="server" Text="Offer Period :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtoffperiod" runat="server" SkinID="txt" MaxLength="11" TabIndex="20"></asp:TextBox>
                            </td>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtoffperiod"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label18" runat="server" SkinID="lbl" Text="Discount Lock :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="Chkdislock" runat="server" AutoPostBack="true" TabIndex="21" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label19" Width="150px" runat="server" Text="Sale Discount% :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtsaleDiscount" runat="server" SkinID="txt" TabIndex="22"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtsaleDiscount" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label20" runat="server" SkinID="lblRsz" Text="Sale Deal :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtsaleDeal" SkinID="txtRsz" runat="server" TabIndex="23" Width="57px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtsaleDeal" />
                                &nbsp;+&nbsp;
                                <asp:TextBox ID="txtSaleDeal1" SkinID="txtRsz" runat="server" TabIndex="24" Width="57px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtSaleDeal1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="25"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="26" Text="VIEW" />
                            </td>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GridProduct" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="26"
                                                        CommandName="Edit" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="27"
                                                        Visible="false" CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product" Visible="true">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="Label5" runat="server" Value='<%# Bind("Product_Id") %>'>
                                                    </asp:HiddenField>
                                                    <asp:Label ID="Label1" runat="server"  Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label>
                                                    <asp:Label ID="lblType" runat="server" Visible="false" Text='<%# Bind("ProductType")  %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>
                                                      <asp:Label ID="Label21" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("LookUpAutoID") %>' Visible ="false" ></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldescId" runat="server" Text='<%# Bind("Description_Id") %>' Visible="false" />
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Packing Details">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpacking" runat="server" Text='<%# Bind("Packing_Details") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Supplier">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupp" runat="server" Text='<%# Bind("Company_ID") %>' Visible="false" />
                                                    <asp:Label ID="lblSuppname" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manf Company">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManuf" runat="server" Text='<%# Bind("Manuf_id") %>' Visible="false" />
                                                    <asp:Label ID="lblManufname" runat="server" Text='<%# Bind("Manufaturer_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reorder Level">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReorder" runat="server" Text='<%# Bind("Reorder_Level") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnitid" runat="server" Text='<%# Bind("Case_Factor_In_Strip") %>'
                                                        Visible="false" />
                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Purchase Tax Plan">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPurchtxtplan" runat="server" Text='<%# Bind("PurchTaxPlan") %>'
                                                        Visible="false" />
                                                    <asp:Label ID="lblpurchasetax" runat="server" Text='<%# Bind("Tax_Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Purchase Deal">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpdeal1" runat="server" Text='<%# Bind("New_Deal_Qty") %>'></asp:Label>
                                                    +
                                                    <asp:Label ID="lblpdeal2" runat="server" Text='<%# Bind("New_Deal_Free") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Purchase Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPurchaseRate" runat="server" Text='<%# Bind("New_Purchase_Rate","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="right" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MRP">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMrp" runat="server" Text='<%# Bind("New_Sale_MRP","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="right" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sale Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsales" runat="server" Text='<%# Bind("New_Sale_Rate","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="right" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Purch Flat Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpurch" runat="server" Text='<%# Bind("VAT_On_Free_percent","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="right" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Purchase Discount %">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("Purchase_Discount_Percent") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Center"  />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sale Tax Plan">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltaxplan" runat="server" Text='<%# Bind("TaxPlan_Id") %>' Visible="false" />
                                                    <asp:Label ID="lblSaletxplan" runat="server" Text='<%# Bind("SaleTaxPlan") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Offer Period">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloffer" runat="server" Text='<%# Bind("OfferPeriod","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Discount Lock">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscountlock" runat="server" Text='<%# Bind("DiscountLockYesNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Center"  />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sale Discount %">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsalediscount" runat="server" Text='<%# Bind("Sale_Discount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sale Deal">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsdeal1" runat="server" Text='<%# Bind("Sale_Deal_qty") %>'></asp:Label>
                                                    +
                                                    <asp:Label ID="lblsdeal2" runat="server" Text='<%# Bind("Sale_Deal_Free") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjDescription" runat="server" SelectMethod="GetDescription"
                        TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSupplier" runat="server" SelectMethod="getSupplier"
                        TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCompany" runat="server" SelectMethod="GetCompany" TypeName="Mfg_DLProductDetails">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="getUnit" TypeName="Mfg_DLProductDetails">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjPurchase" runat="server" SelectMethod="getPurchaseTaxPlan"
                        TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="Objsaletax" runat="server" SelectMethod="GetSaleTaxPlan"
                        TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                </center>
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
