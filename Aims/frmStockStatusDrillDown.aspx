<%@ Page Title="" Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false"
    CodeFile="frmStockStatusDrillDown.aspx.vb" Inherits="frmStockStatusDrillDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <center>
        <table>
            <tr>
                <td>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
        <center>
            <table>
                <tr>
                    <td align="center">
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="700px">
                            <asp:GridView ID="GVDrilldownStockStatus" runat="server" AutoGenerateColumns="False"
                                SkinID="GridView">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrdid" runat="server" Text='<%# Bind("Product_ID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblprodname" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Batch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purchase Invoice No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPurInvoiceNo" runat="server" Text='<%# Bind("Purchase_Invoice_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Expiry">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiry" runat="server" Text='<%# Bind("Expiry", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty IN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqtyin" runat="server" Text='<%# Bind("Qty_In") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Qty Out">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqtyout" runat="server" Text='<%# Bind("qtyout") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                  
                                    
                                <asp:TemplateField HeaderText="Purchase Flat Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPurcFlatrate" runat="server" Text='<%# Bind("Flat_Rate","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purchase Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPruchaseRate" runat="server" Text='<%# Bind("Purchase_Rate","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                               <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sale Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalerate" runat="server" Text='<%# Bind("New_Sale_Rate","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                           <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="MRP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMrp" runat="server" Text='<%# Bind("MRP","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                        </asp:TemplateField>
                                   </Columns>
                            </asp:GridView>
                        </asp:Panel>
        </center>
        </td> 
        </tr> 
        </table>
         </center>
        <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <center>
    </center>
</asp:Content>
