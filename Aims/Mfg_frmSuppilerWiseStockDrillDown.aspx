<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="Mfg_frmSuppilerWiseStockDrillDown.aspx.vb" Inherits="Mfg_frmSuppilerWiseStockDrillDown" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    &nbsp;
                    <asp:GridView ID="GVDrillDown" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="150" SkinID="GridView" Width="300px">
                        <Columns>
                        
                        <asp:TemplateField HeaderText="PRODUCT ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPid" runat="server" Text='<%#Bind("Product_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <asp:TemplateField HeaderText="PRODUCT" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductN" runat="server" Text='<%#Bind("Product_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="PURCHASE INV NO" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblpurchaseINVNO" runat="server" Text='<%#Bind("Purchase_Invoice_No") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle Wrap ="false" />
                            </asp:TemplateField>
                              
                            <asp:TemplateField HeaderText="ENTRY DATE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateP" runat="server" Text='<%#Bind("EntryDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle Wrap ="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SALE INV NO" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblpurchaseINVNO" runat="server" Text='<%#Bind("Sale_Invoice_No") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle Wrap ="false" />
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="ENTRY DATE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateS" runat="server" Text='<%#Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap ="false" />
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="MANUFACTURER NAME" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblMfgName" runat="server" Text='<%#Bind("MR_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="QUANTITY IN " Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblQtyIn" runat="server" Text='<%#Bind("Qty_In") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="QUANTITY OUT " Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblQtyOut" runat="server" Text='<%#Bind("Qty_Out") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="FLAT RATE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblflateR" runat="server" Text='<%#Bind("Flat_Rate","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle Wrap ="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STOCK VALUE" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockvalue" runat="server" Text='<%#Bind("stockValue","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle Wrap ="false" />
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
</asp:Content>

