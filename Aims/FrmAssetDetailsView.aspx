<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmAssetDetailsView.aspx.vb"
    Inherits="FrmAssetDetailsView" Title="View Asset Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Response</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />    <div>
     <center>
        <h1 class="headingTxt">
            ASSET DETAILS
        </h1>
        </center>
    <center>
        <table class="custTable">
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="Asset Type*" Width="132px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlAsstType" runat="server" SkinID="ddl" DataSourceID="SqlAssetType"
                        DataValueField="AssetType_ID" DataTextField="Name" TabIndex="3" AutoPostBack="true">
                    </asp:DropDownList></td>
             </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="Asset Name*" Width="89px"></asp:Label></td>
                <td style="height: 23px">
                    <asp:DropDownList ID="cmbAsset" runat="server" DataSourceID="odsAsset" DataValueField="Id"
                        DataTextField="Name" SkinID="ddl" TabIndex="4" AutoPostBack="True">
                    </asp:DropDownList>               
                </td>
            </tr>
            <tr>
               <td colspan="2" class="btnTd">
                    <asp:Button ID="btnback" runat="server" SkinID="btn" Text="BACK" Width="65px" TabIndex="3" CssClass="btnStyle" />
                    <asp:Button ID="btnreport" runat="server" SkinID="btn" Text="REPORT" TabIndex="2" CssClass="btnStyle" />
                   <%-- <asp:Button ID="btnrecover" runat="server" Text="RECOVER" SkinID="btn" CssClass="btnStyle" />--%>
               </td>
           </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Panel runat="server" ID="pnl1" SkinID="Pnl" ScrollBars="Horizontal">
                        <asp:GridView ID="GdAssetDetails" runat="server" Width="1px" DataSourceID="odsInsert"
                            AutoGenerateColumns="False" SkinID="GridView" DataKeyNames="AssetDet_Id" OnRowEditing="GdAssetDetails_RowEditing"
                            OnRowCommand="GdAssetDetails_RowCommand" AllowPaging="True">
                            <Columns>
                            <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ViewChild_Button" runat="server" Text="View" CommandName="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="ViewChild_Button" runat="server" Text="View" CommandName="Cancel" />
                                        <asp:GridView ID="GrdBookDetails" runat="server" Width="593px" SkinID="Gridview" DataKeyNames="AssetDetail_ID"
                                            DataSourceID="OdsBookDetails" AutoGenerateColumns="false" OnRowEditing="BookGridView_OnRowEditing">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="BID" runat="server" Value='<%# Bind("Book_ID") %>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Book Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("BookCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="AID" runat="server" Value='<%# Bind("AssetDet_Id") %>'></asp:HiddenField>
                                        <asp:LinkButton ID="LbEdit" runat="server" CausesValidation="False" Text="Edit" CommandName="Edit"
                                            OnClick="AssetDetailsMain"></asp:LinkButton>
                                        <asp:LinkButton ID="LbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the Selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asset Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Purchase Date">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("PurchaseDate","{0:dd/MMM/yyyy}")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty in Hand">
                                    <ItemTemplate>
                                        <asp:Label ID="DiffQuantity" runat="server" Text='<%# Bind("DiffQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblremarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asset Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetType" runat="server" Text='<%# Bind("AssetType_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btncreditnote" runat="server" CausesValidation="true" CommandName="CreditNote"
                                            ForeColor="red" Text="CreditNote" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btndebitnote" runat="server" CausesValidation="true" CommandName="DebitNote"
                                            ForeColor="red" Text="DebitNote" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        </center>
        <br />
         <asp:ObjectDataSource ID="odsInsert" runat="server" TypeName="AssetDetailsB" SelectMethod="Display"
            DeleteMethod="ChangeFlag">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmbAsset" Name="assetid" PropertyName="SelectedValue"
                    Type="string" />
                <asp:SessionParameter Name="brnid" SessionField="BranchID" Type="Int64"/>
                <asp:SessionParameter Name="insid" SessionField="InstituteID" Type="Int64"/>
                <asp:ControlParameter ControlID="ddlAsstType" Name="assettype" PropertyName="SelectedValue"
                    Type="string" />
            </SelectParameters>           
        </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="OdsBookDetails" runat="server" TypeName="BookManager"
            SelectMethod="GetDataFromBook">
            <SelectParameters>                           
                <asp:SessionParameter Name="AssetDetail_ID" SessionField="AssetDet_Id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="SqlAssetType" runat="server" TypeName="AssetTypeB" SelectMethod="FillAssetType"
            DataObjectTypeName="AssetType"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsAsset" runat="server" TypeName="AssetManager" SelectMethod="GetAssetByID"
            DataObjectTypeName="AssetCombo">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlAsstType" DefaultValue="0" Name="ID" PropertyName="SelectedValue"
                    Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</form>
</body>
</html>
