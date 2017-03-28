<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmStockStatus.aspx.vb"
    Inherits="Mfg_frmStockStatus" Title="STOCK STATUS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STOCK STATUS</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    STOCK STATUS
                </h1>
            </center>
            <center>
                <table class="custTable">
                    </tr> </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:RadioButtonList ID="RbTYPE" runat="server" AutoPostBack="true" Height="20px"
                                RepeatDirection="Horizontal" Width="398px">
                                <asp:ListItem Selected="True" Text="Ready Made " Value="1"></asp:ListItem>
                                <asp:ListItem Text="Raw Material" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Finished Goods" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:HiddenField ID="HidempId" runat="server" />
                            <asp:Label ID="lblProdName" runat="server" SkinID="lblRsz" Text="Product Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProdName" runat="server" AutoPostBack="True" DataSourceID="ObjProdName"
                                DataTextField="Product_Name" DataValueField="Product_Id" SkinID="ddl" TabIndex="1"
                                Width="128">
                                <%-- <asp:ListItem Value='0' Text ="Select"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProdName" runat="server" SelectMethod="GetProductName"
                                TypeName="Mfg_DLStockStatus">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="RbTYPE" Name="id" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblcatagry" runat="server" Text="Category :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" SkinID="ddl" runat="server" TabIndex="2" DataSourceID="ObjDescription1"
                                DataTextField="Data" DataValueField="LookUpAutoID" AppendDataBoundItems="true">
                                <%--  <asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDescription1" runat="server" SelectMethod="GetCategory"
                                TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblGoDownNo" runat="server" SkinID="lblRsz" Text="GoDown Number&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGodownNo" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                                DataSourceID="ObjGodownNo" TabIndex="3" DataTextField="GodownCode" DataValueField="Godown_ID"
                                SkinID="ddl" Width="128">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjGodownNo" runat="server" SelectMethod="GetGodownCode"
                                TypeName="Mfg_DLStockStatus"></asp:ObjectDataSource>
                        </td>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRackNo" runat="server" SkinID="lblRsz" Text="Rack Number&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRackNo" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                                    DataSourceID="ObjRackNo" TabIndex="4" DataTextField="RackNumber" DataValueField="Godown_ID"
                                    SkinID="ddl" Width="128">
                                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjRackNo" runat="server" SelectMethod="GetRackNumber"
                                    TypeName="Mfg_DLStockStatus"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStartdate" runat="server" SkinID="lblRsz" Text="Start Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtStartDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEndDate" runat="server" SkinID="lblRsz" Text="End Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtEndDate">
                                </ajaxToolkit:CalendarExtender>
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
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="6" Text="VIEW" />
                                </center>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" class="btnTd" align="center">
                                <asp:Button ID="BtnNormal" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" TabIndex="6" Width="90" Text="Normal"> </asp:Button>
                                &nbsp;<asp:Button ID="Button7" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="130" TabIndex="6" Text="Consignment" > </asp:Button>
                                &nbsp;<asp:Button ID="btnReport" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="130" TabIndex="6" Text="Report" > </asp:Button>
                            </td>
                        </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td align="center">
                            <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="670px" Height="500">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    SkinID="GridView" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrdid" runat="server" Text='<%# Bind("Product_ID") %>' Visible="false"></asp:Label>
                                                <asp:LinkButton ID="lblprodname" runat="server" Text='<%# Bind("Product_Name") %>'
                                                    CommandName="Update"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"  />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Packing">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackdetails" runat="server" Text='<%# Bind("Packing_Details") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Batch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Expiry">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExpiry" runat="server" Text='<%# Bind("Expiry", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <%--       <gridviewcolumn header="Expiry">
                                   <GridViewColumn.CellTemplate>
                                            <DataTemplate>
                                                <Grid>
                                                    <Rectangle Fill="YellowGreen" ></Rectangle>
                                                     <asp:Label ID="lblExpiry" runat="server" Text='<%# Bind("Expiry", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        
                                                 
                                                </Grid>
                                            </DataTemplate>
                                        </GridViewColumn.CellTemplate>
                                    </GridViewColumn>--%>
                                        <%--    <GridViewColumn Header="Column Head">
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <Grid>
                                                <Rectangle Fill="YellowGreen" Opacity="0.4"></Rectangle>
                                                <Label Content="{Binding Path=�}"></Label>
                                                �
                                            </Grid>
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>--%>
                                        <asp:TemplateField HeaderText="Qty Stock" SortExpression="QtyInStock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQtystk" runat="server" Text='<%# Bind("QtyInStock") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Top" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Qty Stock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQtystk" runat="server" Text='<%# Bind("QtyInStock") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Purchase Flat Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPurcFlatrate" runat="server" Text='<%# Bind("LastOfFlat_Rate","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Purchase Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPruchaseRate" runat="server" Text='<%# Bind("Purchase_Rate","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalerate" runat="server" Text='<%# Bind("New_Sale_Rate","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MRP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMrp" runat="server" Text='<%# Bind("MRP","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("Amount","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue" runat="server" Text='<%# Bind("Stock_Value","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Godown No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGNo" runat="server" Text='<%# Bind("GodownCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rack No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRNo" runat="server" Text='<%# Bind("RackNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblRNo" runat="server" Text="Total Quantity : "></asp:Label>
                                        <asp:Label ID="lbltotalqty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblTotpurrate" runat="server" Text="Stock Value by Purchase Rate : "></asp:Label>
                                        <asp:Label ID="lblTotalpurrate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblTotpurflatrate" runat="server" Text="Stock Value by Purchase Flat Rate : "></asp:Label>
                                        <asp:Label ID="lblTotalpurflatrate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </asp:Panel>
                </table>
            </center>
            <table>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl" runat="server" Text="Color Indication:" SkinID="lbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="After 2 Months&nbsp;&nbsp;"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Button1" runat="server" BackColor="Yellow" Width="80px" Height="25px"
                            TabIndex="6" />
                    </td>
                    <td>
                        <asp:Button ID="BtnShow1" runat="server" SkinID="btn" Width="80px" Height="25px"
                            TabIndex="6" Text="Show" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="After 4 Months&nbsp;&nbsp;"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Button2" runat="server" BackColor="Blue" Width="80px" Height="25px"
                            TabIndex="6" />
                    </td>
                    <td>
                        <asp:Button ID="BtnShow2" runat="server" SkinID="btn" Width="80px" Height="25px"
                            TabIndex="6" Text="Show" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="Expired&nbsp;&nbsp;"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Button3" runat="server" BackColor="Red" Width="80px" Height="25px"
                            TabIndex="6" />
                    </td>
                    <td>
                        <asp:Button ID="BtnShow3" runat="server" SkinID="btn" Width="80px" Height="25px"
                            TabIndex="6" Text="Show" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

