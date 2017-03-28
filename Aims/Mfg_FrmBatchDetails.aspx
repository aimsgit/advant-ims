<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmBatchDetails.aspx.vb"
    Inherits="Mfg_FrmBatchDetails" Title="Batch Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%=TxtBatch.ClientID%>"), 'Batch');

            if (msg != "") {
                document.getElementById("<%=TxtBatch.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID%>"), 'Product');

            if (msg != "") {
                document.getElementById("<%=DDLProduct.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=TxtMfgdate.ClientID%>"), 'Mfg Date');

            if (msg != "") {
                document.getElementById("<%=TxtMfgdate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=Txtexpirtdate.ClientID%>"), 'Expiry Date');

            if (msg != "") {
                document.getElementById("<%=Txtexpirtdate.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtDealQty.ClientID%>"), 'Deal Qty');

            if (msg != "") {
                document.getElementById("<%=txtDealQty.ClientID%>").focus();
                return msg;
            }

            msg = numeric(document.getElementById("<%=TxtDealFree.ClientID%>"), 'Deal Free');

            if (msg != "") {
                document.getElementById("<%=TxtDealFree.ClientID%>").focus();
                return msg;
            }


            msg = Field50N(document.getElementById("<%=txtpacking.ClientID%>"), 'Packing');

            if (msg != "") {
                document.getElementById("<%=txtpacking.ClientID%>").focus();
                return msg;

            }

            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtPurchaseRate.ClientID%>"), 'Purchase Rate');

            if (msg != "") {
                document.getElementById("<%=TxtPurchaseRate.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=txtvat.ClientID%>"), 'Vat %');

            if (msg != "") {
                document.getElementById("<%=txtvat.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtcst.ClientID%>"), 'Cst %');

            if (msg != "") {
                document.getElementById("<%=Txtcst.ClientID%>").focus();
                return msg;
            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtDiscount.ClientID%>"), 'Discount');

            if (msg != "") {
                document.getElementById("<%=TxtDiscount.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtSaleRate.ClientID%>"), 'Sale Rate');

            if (msg != "") {
                document.getElementById("<%=TxtSaleRate.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtmrp.ClientID%>"), 'MRP');

            if (msg != "") {
                document.getElementById("<%=Txtmrp.ClientID%>").focus();
                return msg;

            }

            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
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
                            BATCH DETAILS</h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="center">
                                    <b>Batch Info</b>
                                </td>
                                <td>
                                </td>
                                <td align="center">
                                    <b>Rates</b>
                                </td>
                            </tr>
                            <caption>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblBatch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtBatch" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="LblPurchaseRate" runat="server" SkinID="lbl" Text="Purchase Rate :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtPurchaseRate" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblprodct" runat="server" SkinID="lbl" Text="Product* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLProduct" runat="server" DataSourceID="ObjProduct" DataTextField="Product_Name"
                                            DataValueField="Product_Id" SkinID="ddl" AutoPostBack="true" TabIndex="2">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblvat" runat="server" SkinID="lbl" Text="VAT % :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtvat" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblmfgdate" runat="server" SkinID="lbl" Text="Mfg Date* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMfgdate" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="TxtMfgdate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Lblcst" runat="server" SkinID="lbl" Text="CST % :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txtcst" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblexpirtdate" runat="server" SkinID="lbl" Text="Expiry :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txtexpirtdate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="Txtexpirtdate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblDiscount" runat="server" SkinID="lbl" Text="Discount :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDiscount" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDealQty" runat="server" SkinID="lbl" Text="Deal Qty :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDealQty" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="LblSaleRate" runat="server" SkinID="lbl" Text="Sale Rate :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtSaleRate" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDealFree" runat="server" SkinID="lbl" Text="Deal Free :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDealFree" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Lblmrp" runat="server" SkinID="lbl" Text="MRP :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txtmrp" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblpacking" runat="server" SkinID="lbl" Text="Packing :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpacking" runat="server" MaxLength="15" SkinID="txt" TabIndex="6"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="LblHold" runat="server" SkinID="lbl" Text="Hold/Release:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlHold" runat="server" SkinID="ddl" TabIndex="13">
                                            <asp:ListItem Text="Release" Value="Release"></asp:ListItem>
                                            <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </caption>
                        </table>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="15" Text="ADD" />
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="16"
                                        Text="VIEW" Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVBatchDetails" runat="server" SkinID="GridView" AllowPaging="true"
                                AutoGenerateColumns="False" PageSize="100">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" />
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Visible="false" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batch" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Batch_ID") %>' />
                                            <asp:Label ID="lblbatch" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label ID="lblproduct" runat="server" Visible="false" Text='<%# Bind("Product_ID") %>'></asp:Label>
                                            <asp:Label ID="ll1" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mfg Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmdate" runat="server" Text='<%# Bind("Mfg_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expiry">
                                        <ItemTemplate>
                                            <asp:Label ID="lbledate" runat="server" Text='<%# Bind("Expiry","{0:dd-MMM-yyyy}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deal Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldealqty" runat="server" Text='<%# Bind("Deal_Qty") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deal Free">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldealfree" runat="server" Text='<%# Bind("Deal_Free","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Packing">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpacking" runat="server" Text='<%# Bind("Packing_Details") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purchase Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprate" runat="server" Text='<%# Bind("Purchase_Rate","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" Width="50" HorizontalAlign="Right"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VAT %">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvat" runat="server" Text='<%# Bind("Purchase_VAT_State","{0:0.00}") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CST %">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcst" runat="server" Text='<%# Bind("Purchase_VAT_CST","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblpdiscount" runat="server" Text='<%# Bind("Purchase_Discount","{0:0.00}") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sale Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsrate" runat="server" Text='<%# Bind("Sale_Rate","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MRP">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmrp" runat="server" Text='<%# Bind("MRP","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hold/Release">
                                        <ItemTemplate>
                                            <asp:Label ID="lblhold" runat="server" Text='<%# Bind("Field3") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboD"
                                TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                        </asp:Panel>
                    </center>
                </div>
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

