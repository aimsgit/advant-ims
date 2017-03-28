<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmProductReceipeMaster.aspx.vb"
    Inherits="Mfg_FrmProductReceipeMaster" Title="Product Receipe Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Receipe Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLRM.ClientID%>"), 'RM/Part');

            if (msg != "") {
                document.getElementById("<%=DDLRM.ClientID%>").focus();
                return msg;

            }
            msg = DropDownForZero(document.getElementById("<%=ddlUnit.ClientID%>"), 'Unit');

            if (msg != "") {
                document.getElementById("<%=ddlUnit.ClientID%>").focus();
                return msg;

            }
            msg = Field1(document.getElementById("<%=TxtConv.ClientID%>"), 'Conv Fact');

            if (msg != "") {
                document.getElementById("<%=TxtConv.ClientID%>").focus();
                return msg;

            }
            msg = Field1(document.getElementById("<%=txtQuantity.ClientID%>"), 'Quantity');

            if (msg != "") {
                document.getElementById("<%=txtQuantity.ClientID%>").focus();
                return msg;

            }
            msg = Field1(document.getElementById("<%=txtSequence.ClientID%>"), 'Sequence');

            if (msg != "") {
                document.getElementById("<%=txtSequence.ClientID%>").focus();
                return msg;

            }
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
                <asp:Panel ID="panel1" runat="server">
                    <div class="mainBlock">
                        <center>
                            <h1 class="headingTxt">
                                PRODUCT RECIPE DETAILS
                            </h1>
                        </center>
                        </br>
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblprodct" runat="server" SkinID="lbl" Text="Product* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLProduct" runat="server" DataSourceID="ObjProduct" DataTextField="Product_Name"
                                            DataValueField="Product_Id" SkinID="ddlRsz" AutoPostBack="true" TabIndex="1"
                                            Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductFinishedGood"
                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="InsertProducyReceipe" runat="server" CssClass="ButtonClass" OnClientClick="return Validate1();"
                                            SkinID="btn" Text="ADD" ValidationGroup="ADD" Visible="false" />
                                        &nbsp;<asp:Button ID="ViewProducyReceipe" runat="server" CausesValidation="False"
                                            CssClass="ButtonClass" SkinID="btn" Text="VIEW" TabIndex="2" />
                                        &nbsp;<asp:Button ID="InsertAddDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btnRsz" Text="ADD DETAILS" Width="120" TabIndex="3" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <center>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            </center>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel5" runat="server" ScrollBars="Auto" Height="250px">
                                            <asp:GridView ID="GvAddPRD" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                Visible="False" AllowPaging="True" PageSize="100">
                                                <Columns>
                                                    <%-- <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Font-Underline="False" Text="Edit"  Visible="false"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Font-Underline="False" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" />
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="RM/Part" SortExpression="RM/Part">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HID1" runat="server" Value='<%# Bind("PRecepe_ID") %>' Visible="false" />
                                                            <asp:Label ID="lblARM1" runat="server" Text='<%# Bind("RM_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblARM2" runat="server" Text='<%# Bind("Product_Name") %>' Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("RM_Quantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnit1" runat="server" Visible="false" Text='<%# Bind("Unit_Id") %>'></asp:Label>
                                                            <asp:Label ID="lblUnit2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Wastage %" SortExpression="Wastage %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblWastage1" runat="server" Text='<%# Bind("Wastage") %>' Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence" ItemStyle-HorizontalAlign="Center" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSequence1" runat="server" Text='<%# Bind("Sequence") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Conv Fact" SortExpression="Conv Fact" ItemStyle-HorizontalAlign="Center"  >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblConv1" runat="server" Text='<%# Bind("CF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit rate" SortExpression="Unit rate" ItemStyle-HorizontalAlign="Right"> 
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitRate1" runat="server" Text='<%# Bind("New_Purchase_Rate","{0:0.00}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost" SortExpression="Cost" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCost1" runat="server" Text='<%# Bind("Cost","{0:0.00}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </asp:Panel>
                <asp:Panel ID="panel2" runat="server">
                    <hr />
                    <div class="mainBlock">
                        <center>
                            <h1 class="headingTxt">
                                ADD PRODUCT RECIPE DETAILS
                            </h1>
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRM" runat="server" SkinID="lbl" Text="RM/Part*&nbsp:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLRM" runat="server" DataSourceID="ObjProduct1" DataTextField="Product_Name"
                                            DataValueField="Product_Id" SkinID="ddl">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductRawMaterial"
                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Unit*&nbsp:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjUnit" DataTextField="Unit"
                                            DataValueField="Unit_ID" SkinID="ddl">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="GetUnit" TypeName="Mfg_DLBatchDetails">
                                </asp:ObjectDataSource>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblConv" runat="server" Text="Conv Fact*&nbsp:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtConv" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="TxtConv" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity*&nbsp:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuantity" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQuantity" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;<asp:Label ID="lblSequence" runat="server" Text="Sequence*&nbsp:&nbsp;&nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSequence" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtSequence" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblWastage" runat="server" Text="Wastage&nbsp:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtwastage" runat="server" SkinID="txt"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtwastage" />
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
                                <center>
                                    <tr>
                                        <td class="btnTd" colspan="4">
                                            <asp:Button ID="InsertPRD" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                                SkinID="btn" Text="ADD" ValidationGroup="ADD" />
                                            &nbsp;<asp:Button ID="ViewPRD" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" Text="VIEW" />
                                            &nbsp;<asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" Text="CLOSE" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                            </table>
                            <center>
                                <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                            </center>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel4" runat="server" ScrollBars="Auto" Height="250px">
                                            <asp:GridView ID="GvPRD" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                Visible="False" AllowPaging="True" PageSize="100">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RM/Part" SortExpression="RM/Part">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HID1" runat="server" Value='<%# Bind("PRecepe_ID") %>' Visible="false" />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("Recepe_Code") %>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblARM1" runat="server" Text='<%# Bind("RM_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblARM2" runat="server" Text='<%# Bind("Product_Name") %>' Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                            <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("RM_Quantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnit1" runat="server" Visible="false" Text='<%# Bind("Unit_Id") %>'></asp:Label>
                                                            <asp:Label ID="lblUnit2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Wastage %" SortExpression="Wastage %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblWastage1" runat="server" Text='<%# Bind("Wastage") %>' Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                            <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSequence1" runat="server" Text='<%# Bind("Sequence") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Conv Fact" SortExpression="Conv Fact">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblConv1" runat="server" Text='<%# Bind("CF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit rate" SortExpression="Unit rate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitRate1" runat="server" Text='<%# Bind("New_Purchase_Rate","{0:0.00}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost" SortExpression="Cost">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCost1" runat="server" Text='<%# Bind("Cost","{0:0.00}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                    
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

</form>
</body>
</html>

