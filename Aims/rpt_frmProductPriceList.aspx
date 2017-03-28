<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_frmProductPriceList.aspx.vb"
    Inherits="rpt_frmProductPriceList" Title="Product Price List" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Price List</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        PRODUCT PRICE LIST
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                      <tr>
                            <td align="right">
                                <asp:Label ID="lblMfg" runat="server" SkinID="lbl" Text="Category&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList1" SkinID="ddl" runat="server" DataSourceID="ObjDescription1"
                                    DataTextField="Data" DataValueField="LookUpAutoID" AutoPostBack ="true" AppendDataBoundItems="true">
                                </asp:DropDownList>
                              
                                <asp:ObjectDataSource ID="ObjDescription1" runat="server" SelectMethod="GetCategory"
                                    TypeName="Mfg_DLProductDetails"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblProduct" runat="server" SkinID="lbl" Text="Product&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlProduct" runat="server" Width="250px" DataSourceID="ObjProduct"
                                    DataTextField="Product_Name" SkinID="ddl" AutoPostBack="true" DataValueField="Product_Id"
                                    TabIndex="1">
                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="GetProduct2" TypeName="DLProductDetails">
                                 <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="LookUpAutoID" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                      
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSupplier" runat="server" SkinID="lbl" Text="Supplier&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSupplier" runat="server" Width="250px" SkinID="ddl" AutoPostBack="True"
                                    DataSourceID="odsSupplier" DataTextField="Supp_Name" DataValueField="Supp_Id_Auto">
                                   
                                   
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSupplier" runat="server" TypeName="Mfg_DLPurchaseInvoice"
                                    SelectMethod="GetSupplierDetails3">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlProduct" PropertyName="SelectedValue" Name="Product_Id" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>&nbsp;
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>

