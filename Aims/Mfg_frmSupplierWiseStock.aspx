<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmSupplierWiseStock.aspx.vb"
    Inherits="Mfg_frmSupplierWiseStock" Title="Supplier Wise Stock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Supplier Wise Stock</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanal1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    SUPPLIER WISE STOCK
                </h1>
            </center>
            &nbsp;
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSupplier" SkinID="lbl" runat="server" Text="Supplier&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSupplire" runat="server" Width="152px" DataSourceID="ObjProduct"
                                DataTextField="Supp_Name" SkinID="ddlRsz" AutoPostBack="true" DataValueField="Supp_Id"
                                TabIndex="1">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="GetSupplier" TypeName="DLProductDetails">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStartingDate" SkinID="lbl" runat="server" Text="Start Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartingDate" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                FilterType="Custom , Numbers,UppercaseLetters ,LowercaseLetters" ValidChars="-/"
                                TargetControlID="txtStartingDate" Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtStartingDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" SkinID="lbl" runat="server" Text="End Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterType="Custom , Numbers,UppercaseLetters ,LowercaseLetters" ValidChars="-/"
                                TargetControlID="txtEndDate" Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtEndDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAll" runat="server" CausesValidation="False" CommandName="Insert"
                                CssClass="ButtonClass" SkinID="btn" TabIndex="14" Text="ALL" />
                            &nbsp;<asp:Button ID="btnExpired" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="15" Text="EXPIRED" />
                            &nbsp;<asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="15" Text="BACK" />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
            </center>
            <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    &nbsp;
                    <asp:GridView ID="g1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" SkinID="GridView" >
                        <Columns>
                            <asp:TemplateField HeaderText="SuppId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LabelsuppId" runat="server" Text='<%#Bind("Company_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="DATE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDate" runat="server" Text='<%#Bind("Ref_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="SUPPLIER" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="LabelSupplier" runat="server" Text='<%#Bind("Supp_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PID" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="lblpid" runat="server" Text='<%#Bind("Product_Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PRODUCT" Visible="true" ItemStyle-HorizontalAlign ="left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblProduct" runat="server" Text='<%#Bind("Product_Name") %>'
                                         CommandName="Update"></asp:LinkButton>
                                    <%-- <asp:Label ID="lblProduct" runat="server" Text='<%#Bind("Product_Name") %>'></asp:Label>--%>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MANUFACTURE NAME" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblMFG" runat="server" Text='<%#Bind("Manufaturer_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BATCH" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblbatch" runat="server" Text='<%#Bind("Batch") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EXPIRY" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblExpiry" runat="server" Text='<%#Bind("Expiry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty In Stock" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblQtyIn" runat="server" Text='<%#Bind("totstk") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Flat Rate" Visible="true"  ItemStyle-HorizontalAlign ="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblflatrate" runat="server" Text='<%#Bind("VAT_On_Free_percent","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock Value" ItemStyle-HorizontalAlign ="Right" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockV" runat="server" Text='<%#Bind("stockvalue","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                                
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
            <table>
                <tr>
                    <td>
                        <center>
                            <table align="right">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblTotal" SkinID="lbl" runat="server" Text="Total Quantity&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtvat" Style="text-align: right"  runat="server" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblStockV" SkinID="lbl" runat="server" Text="Stock Value&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtStocalV" Style="text-align: right" runat="server" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbltotalNo" SkinID="lbl" runat="server" Text="No of Items &nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtTotalNo" style="text-align:right"  runat="server" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                    </td>
                    <%--<td>
                        <asp:Label ID="lblExpy" SkinID="lbl" runat="server" Text="Expiry Colour Indication"></asp:Label>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" SkinID="lbl" runat="server" Text="After 2 Months&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblcolorYellow" SkinID="lbl" runat="server" Text="yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl4Month1" SkinID="lbl" runat="server" Text="After 4 Months&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbl4Month" SkinID="lbl" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblExpired" SkinID="lbl" runat="server" Text="Expired&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblExpired1" SkinID="lbl" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>--%>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

