<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmStockIssue.aspx.vb"
    Inherits="Mfg_frmStockIssue" Title="Stock Issue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stock Issue</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;

            msg = NameField100(document.getElementById("<%=txtIssueNo.ClientID %>"), 'Issue No');
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtDCNo.ClientID %>"), 'DC No');
            if (msg != "") return msg;

            msg = ValidateDate(document.getElementById("<%=txtDate.ClientID %>"), 'Date');
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtIndentNo.ClientID %>"), 'Indent No');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=cmbPType.ClientID %>"), 'Party Type');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlPName.ClientID %>"), 'Party Name');
            if (msg != "") return msg;

            return true;
        }
        function Validate1() {
            var msg = Valid1();
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
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLPRODUCT.ClientID %>"), 'Product');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID %>"), 'Batch');
            if (msg != "") return msg;
            msg = FeesField(document.getElementById("<%=txtQtyIssued.ClientID %>"), 'Issued Quantity');
            if (msg != "") return msg;

            return true;
        }
        function Validate() {
            var msg = Valid();
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
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="STOCK ISSUE" TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        STOCK ISSUE
                                    </h1>
                                </center>
                                <br />
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblIssueNo" runat="server" SkinID="lbl" Text="Issue No* :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtIssueNo" runat="server" SkinID="txt" TabIndex="1" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblIndentNo" runat="server" SkinID="lbl" Text="Indent No* :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtIndentNo" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDCNo" runat="server" SkinID="lbl" Text="DC No* :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDCNo" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDONo" runat="server" SkinID="lbl" Text="DO No :&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDONo" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDate" runat="server" SkinID="lblRsz" Text="Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="Date" runat="server" TargetControlID="txtDate"
                                                    Format="dd-MMM-yyyy" Enabled="True">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblPartyType" runat="server" Text="Party Type* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cmbPType" TabIndex="7" runat="server" SkinID="ddl" DataSourceID="ObjPartyType"
                                                    AutoPostBack="True" DataValueField="Id" DataTextField="Name">
                                                    <%--<asp:ListItem Text ="Select" Value ="0"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjPartyType" runat="server" SelectMethod="GetPartyTypeddl"
                                                    TypeName="Mfg_DLStockIssue"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblWorkOrder" runat="server" Text="Work Order :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    TabIndex="4"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlWorkOrder" TabIndex="4" runat="server" SkinID="ddl" AutoPostBack="True"
                                                    DataSourceID="ObjWorkOrder" DataValueField="Sales_Order_ID" DataTextField="Sale_Order_Number">
                                                    <%-- <asp:ListItem Text ="select" Value ="0"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjWorkOrder" runat="server" SelectMethod="GetWorkOrderDDL"
                                                    TypeName="Mfg_DLStockIssueR"></asp:ObjectDataSource>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblPartyName" runat="server" Text="Party Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPName" TabIndex="8" runat="server" SkinID="ddl" DataSourceID="ObjParty_Name"
                                                    DataValueField="ID" DataTextField="Name">
                                                    <%-- <asp:ListItem Text ="select" Value ="0"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjParty_Name" runat="server" SelectMethod="GetPartyNameddl"
                                                    TypeName="Mfg_DLStockIssue">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="cmbPType" Name="PartyName" Type="String" PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <%--  </asp:Panel>--%>
                                <br />
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td class="btnTd" colspan="2">
                                            <asp:Button ID="BtnAdd" runat="server" CssClass="ButtonClass" SkinID="btn" Text="ADD"
                                                TabIndex="9" OnClientClick="return Validate1();" />
                                            <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW"
                                                TabIndex="10" />
                                            <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                OnClientClick="return Validate1();" Text="ADD DETAILS" Width="130px" TabIndex="11" />
                                            <asp:Button ID="btnPost" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" Text="POST" TabIndex="12" />
                                            <asp:Button ID="BtnIssueNote" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btnRsz" Width="140px" Text="PRINT ISSUE NOTE" TabIndex="12" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <div>
                                <center>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                Processing your request..please wait...
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </center>
                            </div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGreenM" runat="server" SkinID="lblGreen"></asp:Label>
                                            <asp:Label ID="lblRedM" runat="server" SkinID="lblRed"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </br>
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="320px">
                                    <asp:GridView ID="GVStockIssue" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkhdr" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkChild" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="EditMain" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="DeteteMain" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Issue No">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="StockId" runat="server" Value='<%# Bind("StockIssueId") %>' />
                                                    <asp:Label ID="lblStockIssueNo" runat="server" Text='<%# Bind("StockIssueNo") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DC No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDCNo" runat="server" Text='<%# Bind("DCNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Issue Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIssueDate" runat="server" Text='<%# Bind("StockIssueDate","{0:dd-MMM-yyyy}") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Party Tytpe">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartyTypeId" runat="server" Visible="false" Text='<%# Bind("PartyType") %>'></asp:Label>
                                                    <asp:Label ID="lblPartyType" runat="server" Text='<%# Bind("PartyTypeName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Party Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartyNameId" runat="server" Visible="false" Text='<%# Bind("PartyId") %>'></asp:Label>
                                                    <asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("PartyName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sale Order">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSaleOrder" runat="server" Visible="false" Text='<%# Bind("SaleOrder") %>'></asp:Label>
                                                    <asp:Label ID="lblSaleOrderNo" runat="server" Text='<%# Bind("SaleOrderNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Indent No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIndentNo" runat="server" Text='<%# Bind("IndentNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DO No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDONo" runat="server" Text='<%# Bind("DO_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Post Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPost" runat="server" Text='<%# Bind("PostToStk") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="STOCK ISSUE DETAILS"
                        TabIndex="3">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        STOCK ISSUE DEATILS
                                        <br />
                                        <br />
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblProduct" runat="server" SkinID="lblRsz" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DDLPRODUCT" runat="server" DataSourceID="ObjProduct1" DataTextField="Product_Name"
                                                    Width="200" DataValueField="Product_Id" SkinID="ddlRsz" AutoPostBack="true" TabIndex="13">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductComboD"
                                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBatch" runat="server" SkinID="lblRsz" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlBatch" runat="server" DataSourceID="ObjBatch" DataTextField="Batch"
                                                    Width="200" DataValueField="Batch_ID" SkinID="ddlRsz" AutoPostBack="true" TabIndex="14">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchCombo" TypeName="Mfg_DLStockIssueR">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="DDLPRODUCT" Name="ProductId" PropertyName="SelectedValue"
                                                            Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblQtyAvailable" runat="server" Text="Qty Available :&nbsp;&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQtyAvailable" runat="server" SkinID="txt" TabIndex="15" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblIssuedQty" runat="server" Text="Qty Issued* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQtyIssued" runat="server" SkinID="txt"></asp:TextBox><asp:Label
                                                    ID="lblUnit" runat="server" SkinID="lblRsz"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" SkinID="txt" TabIndex="16" Height="60px"></asp:TextBox>
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
                                    <table>
                                        <tr>
                                            <td class="btnTd" colspan="4" align="center">
                                                <asp:Button ID="btnAdddet" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                                    SkinID="btn" Text="ADD" TabIndex="17" />&nbsp;
                                                <asp:Button ID="BtnViewDetails" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                    Text="VIEW" TabIndex="18" />&nbsp;
                                                <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                    SkinID="btn" Text="CLOSE" TabIndex="19" />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div>
                                        <center>
                                            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        Processing your request..please wait...
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </div>
                                    <center>
                                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                    </center>
                                    <center>
                                        <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="600px" Height="300px">
                                            <asp:GridView ID="GVStockIssueDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                PageSize="100" SkinID="GridView">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="EditDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="DeteteDetails" runat="server" CausesValidation="False" CommandName="Delete"
                                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Issue No">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("StkIssueDetId") %>' />
                                                            <asp:Label ID="lblStockIssueNo" runat="server" Text='<%# Bind("StockIssueNo") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Wrap="False" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Batch">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBatchId" runat="server" Visible="false" Text='<%# Bind("BatchId") %>'></asp:Label>
                                                            <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty Issued">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQtyIssued" runat="server" Text='<%# Bind("QtyIssued") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="True" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
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
