<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmPurchaseRequisition.aspx.vb"
    Inherits="Mfg_FrmPurchaseRequisition" Title="Purchase Requisition " %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Purchase Requisition</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%=txtPurchaseReqNo.ClientID%>"), 'Purchase Request No');

            if (msg != "") {
                document.getElementById("<%=txtPurchaseReqNo.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID%>"), 'Product');

            if (msg != "") {
                document.getElementById("<%=DDLProduct.ClientID%>").focus();
                return msg;
            }
            msg = Field1(document.getElementById("<%=txtQty.ClientID%>"), 'Quantity');

            if (msg != "") {
                document.getElementById("<%=txtQty.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
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
                        PURCHASE REQUISITION
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPurchaseReqNo" runat="server" SkinID="lblRsz" Text="Purchase Request No.*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPurchaseReqNo" runat="server" SkinID="txt" TabIndex="1" ReadOnly="true"></asp:TextBox>
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
                                <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboD"
                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblUnit" runat="server" Text="Unit&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" SkinID="ddl" runat="server" TabIndex="3" DataSourceID="ObjUnit"
                                    DataTextField="Unit" DataValueField="Unit_ID" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="getUnit" TypeName="Mfg_DLProductDetails">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblQty" Width="150px" runat="server" Text="Quantity* :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtQty" Style="text-align: right" runat="server" SkinID="txt" TabIndex="4" ></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQty">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStatus" runat="server" SkinID="lblRsz" Width="200px" Text="Status :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlRsz" TabIndex="5" Width="200">
                                    <asp:ListItem Value="Open">Open</asp:ListItem>
                                    <asp:ListItem Value="Goods Received">Goods Received</asp:ListItem>
                                </asp:DropDownList>
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
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="6"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" TabIndex="7" Text="VIEW" />
                                <asp:Button ID="Btnposttostock" runat="server" Text="SUBMIT " CssClass="ButtonClass "
                                    CausesValidation="true" SkinID="btnRsz" TabIndex="8" />
                            </td>
                        </tr>
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
                                    <asp:GridView ID="GvPruchaseReq" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
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
                                            <asp:TemplateField HeaderText="Purchase Req No" Visible="true">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Purchase_Req_Id") %>' />
                                                    <asp:Label ID="lblPurchNo" runat="server" Text='<%# Bind("Purchase_Req_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                    <asp:Label ID="ProductId" runat="server" Text='<%# Bind("Product_Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                    <asp:Label ID="lblUnitId" runat="server" Text='<%# Bind("Unit_Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                    <a name="Bottom">
                        <div align="right">
                            <a href="#Top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                        </div>
                    </a>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                    </asp:Panel>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
