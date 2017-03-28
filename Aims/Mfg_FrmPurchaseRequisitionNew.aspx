<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmPurchaseRequisitionNew.aspx.vb"
    Inherits="Mfg_FrmPurchaseRequisitionNew" Title="Purchase Requisition" %>

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
            return true;
        }

        function Valid1() {
            var msg;
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
                            PURCHASE REQUISITION
                        </h1>
                    </center>
                    <br />
                    <br />
                    <hr />
                    <asp:Panel ID="PurchaseRequisition" runat="server">
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPurchaseReqNo" runat="server" SkinID="lblRsz" Text="Purchase Request No.*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPurchaseReqNo" runat="server" SkinID="txtRsz" TabIndex="1" ReadOnly="true"
                                            Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbldate" runat="server" SkinID="lblRsz" Text="Date&nbsp;:&nbsp;&nbsp;"
                                            TabIndex="-1" Width="140px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" SkinID="txt" MaxLength="22" TabIndex="2"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                            Format="dd-MMM-yyyy" TargetControlID="txtDate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblStatus" runat="server" SkinID="lblRsz" Width="200px" Text="Status :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlRsz" TabIndex="3" Width="205">
                                            <asp:ListItem Value="Open">Open</asp:ListItem>
                                            <asp:ListItem Value="Goods Received">Goods Received</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <table>
                                <br />
                                <br />
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="4" Text="ADD" />
                                        &nbsp;
                                        <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="13"
                                            Text="VIEW" />
                                        &nbsp;
                                        <asp:Button ID="BtnAddDtls" Text="ADD PRODUCT" runat="server" CssClass="ButtonClass"
                                            SkinID="btnRsz" Width="130px" TabIndex="5"></asp:Button>
                                        &nbsp;
                                        <asp:Button ID="btnPost" Text="SUBMIT" runat="server" CssClass="ButtonClass" SkinID="btn"
                                            TabIndex="6"></asp:Button>
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
                    <center>
                    <asp:Panel ID="GV1Panel" runat="server" ScrollBars="Auto" Width="650px" Visible="false">
                        <asp:GridView ID="GvPruchaseReq" runat="server" AllowPaging="True" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="Purchase Req No" Visible="true">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Purchase_ReqMain_Id") %>' />
                                        <asp:Label ID="lblPurchNo" runat="server" Text='<%# Bind("Purchase_Req_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Req_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                   </ItemTemplate>
                                    <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                    <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                    <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submit Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostStatus" runat="server" Text='<%# Bind("Post_To_Stock") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                    <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    </center>
                    <asp:Panel ID="AddDetails" runat="server" Visible="false">
                        <center>
                            <h1 class="headingTxt">
                                Purchase Requisition Details
                            </h1>
                            <hr />
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblprodct" runat="server" SkinID="lbl" Text="Product* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLProduct" runat="server" DataSourceID="ObjProduct" DataTextField="Product_Name"
                                            DataValueField="Product_Id" SkinID="ddlRsz" TabIndex="7" Width="205" AutoPostBack="true">
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
                                        <asp:DropDownList ID="ddlUnit" SkinID="ddlRsz" runat="server" TabIndex="8" DataSourceID="ObjUnit"
                                            DataTextField="Unit" DataValueField="Unit_ID" Width="205">
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
                                        <asp:TextBox ID="txtQty" Style="text-align: right" runat="server" SkinID="txtRsz"
                                            TabIndex="9" Width="200"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQty">
                                        </ajaxToolkit:FilteredTextBoxExtender>
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
                                            OnClientClick="return Validate1();" SkinID="btnRsz" TabIndex="10" Text="ADD"
                                            Width="120px" />&nbsp;
                                        <asp:Button ID="BtnViewProduct" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="11" Text="VIEW" Width="120px" />&nbsp;
                                        <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="12" Text="CLOSE" />&nbsp;
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
                    <center>
                   
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px">
                        <asp:GridView ID="GVPRDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
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
                                       <asp:HiddenField ID="IID1" runat="server" Value='<%# Eval("Purchase_Req_Id") %>' />
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                        <asp:Label ID="ProductId" runat="server" Text='<%# Bind("Product_Id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                    <HeaderStyle Wrap="false" HorizontalAlign="Left" />
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
                                    <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    <HeaderStyle Wrap="false" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
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
    </div>

</form>
</body>
</html>
