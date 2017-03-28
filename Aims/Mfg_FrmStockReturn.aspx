<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmStockReturn.aspx.vb"
    Inherits="Mfg_FrmStockReturn" Title="Stock Return" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stock Return</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = Field50(document.getElementById("<%=txtReturnNo.ClientID %>"), 'Return No');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=cmbPType.ClientID%>"), 'Party Type')
            if (msg != "") {
                document.getElementById("<%=cmbPType.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlPName.ClientID%>"), 'Party Name')
            if (msg != "") {
                document.getElementById("<%=ddlPName.ClientID%>").focus();
                return msg;
            }

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
            msg = DropDownForZero(document.getElementById("<%=DdlIssueNo.ClientID %>"), 'Issue No/Del');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlItemDesc.ClientID %>"), 'Item Description');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID %>"), 'Batch');
            if (msg != "") return msg;

            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtQty.ClientID %>"), 'Quantity');
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
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Stock Return" TabIndex="1">
                    <ContentTemplate>
                        <div>
                            <center>
                                <h1 class="headingTxt">
                                    STOCK RETURN
                                </h1>
                            </center>
                        </div>
                        <br />
                        <br />
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblReturnNo" runat="server" SkinID="lblRsz" Text="Return No*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReturnNo" runat="server" SkinID="txt"></asp:TextBox>
                                        <asp:TextBox ID="HidReturnId" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                    </td>
                                    &nbsp;<td align="right">
                                        <asp:Label ID="lblReturnDate" runat="server" SkinID="lblRsz" Text="Return Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReturnDate" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="ReturnDate" runat="server" TargetControlID="txtReturnDate"
                                            Format="dd-MMM-yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label6" runat="server" Text="Party Type* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cmbPType" TabIndex="2" runat="server" SkinID="ddl" DataSourceID="ObjPartyType"
                                            AutoPostBack="True" DataValueField="Id" DataTextField="Name">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjPartyType" runat="server" SelectMethod="GetPartyTypeddl"
                                            TypeName="Mfg_DLStockIssue"></asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblWorkorder" runat="server" Text="Work Order :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlWorkOrder" runat="server" DataTextField="Sale_Order_Number"
                                            DataSourceID="ObjWorkOrder" DataValueField="Sales_Order_ID" Width="240px" SkinID="ddlRsz"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjWorkOrder" runat="server" SelectMethod="GetWorkOrderDDL"
                                            TypeName="MaterialIndentDL"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Party Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPName" runat="server" SkinID="ddl" DataSourceID="ObjParty_Name"
                                            AutoPostBack="True" DataValueField="ID" DataTextField="Name">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjParty_Name" runat="server" SelectMethod="GetPartyNameddl"
                                            TypeName="Mfg_DLStockIssue">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cmbPType" Name="PartyName" Type="String" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemaks" runat="server" TextMode="MultiLine" SkinID="txt"></asp:TextBox>
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
                                            Text="ADD DETAILS" Width="130" />
                                        &nbsp;
                                        <asp:Button ID="btnPost" runat="server" CssClass="ButtonClass" SkinID="btn" Text="POST"
                                            TabIndex="10" />
                                        &nbsp;
                                        <asp:Button ID="BtnPrint" runat="server" CssClass="ButtonClass" SkinID="btn" Text="PRINT" />
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
                                <asp:GridView ID="GridStockReturnM" runat="server" AllowPaging="True" AutoGenerateColumns="False"
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
                                        <asp:TemplateField HeaderText="Return No.">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("StockReturn_Id") %>' />
                                                <asp:Label ID="lblReturnNo" runat="server" Text='<%# Bind("StockReturnNo") %>' />
                                                <asp:Label ID="lblReturnId" runat="server" Visible="false" Text='<%# Bind("StockReturn_Id") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockReturnDate" runat="server" Text='<%# Bind("StockReturnDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Wrap="false" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyType" runat="server" Text='<%# Bind("PartTypeName") %>' />
                                                <asp:Label ID="lblPartyTypeId" runat="server" Visible="false" Text='<%# Bind("Party_Type") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("PartyName") %>' />
                                                <asp:Label ID="lblPartyId" runat="server" Visible="false" Text='<%# Bind("Party_ID") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Work Order">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWo" runat="server" Text='<%# Bind("Sale_Order_Number") %>' />
                                                <asp:Label ID="lblWoId" runat="server" Visible="false" Text='<%# Bind("SO_Id") %>' />
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
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Stock Return Details"
                    TabIndex="2">
                    <ContentTemplate>
                        <center>
                            <h1 class="headingTxt">
                                ADD DETAILS</h1>
                        </center>
                        <center>
                            <table class="custTable">
                            </table>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblIssueNo" runat="server" SkinID="lblRsz" Text="Issue No/Del*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DdlIssueNo" TabIndex="6" runat="server" SkinID="ddl" DataSourceID="ObjIssue"
                                            AutoPostBack="True" DataValueField="Id" DataTextField="StockIssueNo">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjIssue" runat="server" SelectMethod="GetIssueNoDDL" TypeName=" Mfg_DLStockReturn">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblChallan" runat="server" SkinID="lblRsz" Text="Delivery Challan&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtChallanNO" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                        <asp:TextBox ID="HidTxtChallanId" runat="server" Visible="false" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblItemDesc" runat="server" Text="Item Description* :&nbsp;&nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlItemDesc" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                            DataValueField="Id" DataTextField="Name" Width="200px" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetItemDescDDL"
                                            TypeName="Mfg_DLStockReturn">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DdlIssueNo" Name="Name" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBatch" runat="server" SkinID="lblRsz" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlBatch" runat="server" DataSourceID="ObjBatch1" DataTextField="Batch"
                                            Width="200" DataValueField="Batch_ID" SkinID="ddlRsz" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBatch1" runat="server" SelectMethod="BatchCombo" TypeName="Mfg_DLStockReturn">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlItemDesc" Name="pid" PropertyName="SelectedValue"
                                                    Type="Int32" />
                                                <asp:ControlParameter ControlID="DdlIssueNo" Name="Name" PropertyName="SelectedValue"
                                                    Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblQtyIssued" runat="server" Text="Qty Issued :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQtyIssued" runat="server" SkinID="txt" Enabled="False"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQtyIssued" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblQty" runat="server" Text="Quantity :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQty" runat="server" SkinID="txt"></asp:TextBox>
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
                                        <asp:Button ID="BtnViewDetails" runat="server" CssClass="ButtonClass" SkinID="btn"
                                            Text="VIEW" />&nbsp;
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
                                                <asp:GridView ID="GVSRDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
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
                                                        <asp:TemplateField HeaderText="Issue No/Del">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ID" runat="server" Visible="False" Text='<%# Bind("StockReturn_Id") %> '></asp:Label>
                                                                <asp:Label ID="GVStockIssueNO" runat="server" Text='<%# Bind("StockIssueNo") %>'></asp:Label>
                                                                <asp:Label ID="GVStockIssueID" runat="server" Visible="false" Text='<%# Bind("StockIssue_ID")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delivery Challan">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDc" runat="server" Text='<%# Bind("Dc_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Item Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemDesc" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                                <asp:Label ID="lblItemDescID" runat="server" Visible="false" Text='<%# Bind("Product_Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatchno" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                                                <asp:Label ID="lblbatchid" runat="server" Visible="false" Text='<%# Bind("BatchId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label ID="GVqty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Post Status" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPost" runat="server" Text='<%# Bind("PostToStk") %>'></asp:Label>
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

