<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAssetTransfer.aspx.vb"
    Inherits="frmAssetTransfer" Title="Asset Transfer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Transfer</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">  
     function Valid()
   {
   var msg;
    msg=NameField100(document.getElementById("<%=txtFromInstitute.ClientID %>"),'From Institute ');
    if(msg!="") return msg;
    msg=DropDown(document.getElementById("<%=ddlToBranch.ClientID %>"),'To Branch ');
    if(msg!="") return msg;
    msg=DropDown(document.getElementById("<%=ddlToInstitute.ClientID %>"),'To Institute ');
    if(msg!="") return msg;
    if (document.getElementById("<%=ddlAsstType.ClientID %>").value!=2)
   {
     msg=FeesField(document.getElementById("<%=txtPrice.ClientID %>"),'Price ');
    }
    if(msg!="") return msg;
    msg=ValidateDate(document.getElementById("<%=txtPurchaseDate.ClientID %>"),'Purchase Date');
    if(msg!="") return msg;
    msg=ValidateDate(document.getElementById("<%=txtEntryDate.ClientID %>"),'Entry Date ');
    if(msg!="") return msg;
    msg=ValidateDate(document.getElementById("<%=txtTransferDate.ClientID %>"),'Transfer Date');
    if(msg!="") return msg;  
      if (document.getElementById("<%=ddlAsstType.ClientID %>").value!=2)
   {
     msg=CompareInt(document.getElementById("<%=txtQuantity.ClientID %>"),document.getElementById("<%=hfQty.ClientID %>"),'Transfer Quantity ','Max.Transfer Qty ');
    }
    if(msg!="") return msg;     
     msg=NameField100(document.getElementById("<%=txtfrom.ClientID %>"),'From ');
    if(msg!="") return msg;   
     msg=NameField100(document.getElementById("<%=txtto.ClientID %>"),'To ');
    if(msg!="") return msg;   
     return true;
   }
   
 function Validate(){
          var msg=Valid();
          if(msg!=true)
          { 
                    if(navigator.appName=="Microsoft Internet Explorer")
                    {
                     document.getElementById("<%=lblmsg.ClientID %>").innerText=msg;
                     return false;
                    }
                    else  if(navigator.appName == "Netscape")
                    {  
                     document.getElementById("<%=lblmsg.ClientID %>").textContent=msg;
                     return false;
                    }   
          }
           return true;
 }
  </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        <center>
            <h1 class="headingTxt">
                ASSET TRANSFER</h1>
        </center>
        <center>
            <table class="custTable">
                <tr>
                    <td colspan ="2">
                        <h3>
                            Asset Details</h3>
                    </td>
                </tr>
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
                        <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="Asset Name*" Width="130px"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlAsset" runat="server" DataSourceID="ObjAsset" DataValueField="Id"
                            DataTextField="Name" SkinID="ddl" TabIndex="4" AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
            </table>
        </center>
        <br />
        <div>
            <asp:Panel ID="Pan1" runat="server" SkinID="Pnl">
                <asp:GridView ID="gvAssetDetails" runat="server" DataSourceID="odsAssetDetails" SkinID="GridView"
                    OnSelectedIndexChanged="gvAssetDetails_SelectedIndexChanged" AllowPaging="True"
                    AutoGenerateColumns="False" DataKeyNames="AssetDet_Id">
                    <Columns>
                        <asp:TemplateField HeaderText="Branch">
                            <ItemTemplate>
                                <asp:Label ID="hfAssetDetailId" runat="server" EnableViewState="true" Visible="False"
                                    Text='<%# Bind("AssetDet_Id") %>' />
                                <asp:Label ID="hfAsset" runat="server" Visible="False" Text='<%# Bind("Asset_Id") %>' />
                                <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("BranchName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Type">
                            <ItemTemplate>
                                <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("InstituteName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier">
                            <ItemTemplate>
                                <asp:Label ID="lblSupplier" runat="server" Text='<%#Bind("Supp_Name") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manufacturer">
                            <ItemTemplate>
                                <asp:Label ID="hfAssetType" runat="Server" Text='<%#Bind("AssetType") %>' Visible="False" />
                                <asp:Label ID="lblManufacturer" runat="server" Text='<%# Bind("ManuFacturer") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:d}" DataField="PurchaseDate"
                            HeaderText="PurchaseDate"></asp:BoundField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Model_Number" HeaderText="ModelNumber" />
                        <asp:BoundField DataField="DiffQuantity" HeaderText="Quantity"></asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="Price"></asp:BoundField>
                        <asp:BoundField DataField="InvoiceNo" HeaderText="InvoiceNo"></asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Font-Underline="True" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Transfer"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
         <table cellpadding="0" cellspacing="0" border="0" width="110%">
            <tr>
                <td colspan="2" class="btnTd">
                    <asp:Button ID="btnInsert" runat="server" Text="CONFIRM" CommandName="Insert" SkinID="btnRsz"
                        CausesValidation="true" ValidationGroup="Confirm" TabIndex="14" 
                        CssClass="btnStyle" OnClientClick="return Validate();" Width="100px"/>
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" SkinID="btn" CausesValidation="False"
                        OnClick="Enable" TabIndex="15" CssClass="btnStyle" />
                    <asp:Button ID="btnDetails" runat="server" Text="DETAILS" OnClick="Details" SkinID="btn"
                        TabIndex="16" CssClass="btnStyle" /></td>
            </tr>
        </table>
        <asp:Panel ID="Pan2" runat="server" Width="100%">
            <h3>
                Transfer Details</h3>
            <br />
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="From" SkinID="lbl" EnableViewState="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromInstitute" runat="server" ReadOnly="true" SkinID="txt" TabIndex="2"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="To BranchType" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlToInstitute" runat="server" DataSourceID="OdsInstitute"
                            DataTextField="Name" DataValueField="Id" SkinID="ddl" TabIndex="5" AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text=" Price" SkinID="lbl" EnableViewState="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox></td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="To Branch" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlToBranch" runat="server" DataSourceID="OdsBranch" DataValueField="Id"
                            DataTextField="Name" SkinID="ddl" TabIndex="3">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" EnableViewState="False" SkinID="lbl" Text="Purchase Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPurchaseDate" runat="server" ReadOnly="true" SkinID="txt" TabIndex="6"></asp:TextBox></td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Max.Transfer Qty" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="hfQty" runat="server" ReadOnly="true" TabIndex="7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text=" Entry Date" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEntryDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox></td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text=" Quantity" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server" SkinID="txt" TabIndex="9">0</asp:TextBox>
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text=" Transfer Date" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTransferDate" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox></td> 
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblremarks" runat="server" Text="Remarks" SkinID="lbl" EnableViewState="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtremarks" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblfrom" runat="server" Text=" From" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtfrom" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblto" runat="server" Text="To" SkinID="lbl" EnableViewState="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtto" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Pan3" runat="server" Width="100%">
            <h3>
                Book Details</h3>
            <br />
            <div>
                <asp:GridView ID="GVBookDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="Book_ID"
                    SkinID="GridView">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" ValidationGroup="Update"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                                <asp:HiddenField runat="Server" ID="hfSubId" Value='<%#Bind("Subject_ID") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBkName" runat="server" Text='<%#Bind("BookName") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblBkName" runat="server" Text='<%#Bind("BookName") %>' /></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code">
                            <ItemTemplate>
                                <asp:Label ID="lblBKCode" runat="server" Text='<%#Bind("BookCode") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblBKCode" runat="server" Text='<%#Bind("BookCode") %>'></asp:Label></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Author">
                            <ItemTemplate>
                                <asp:Label ID="lblBKAuthor" runat="server" Text='<%#Bind("Author") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblBKAuthor" runat="server" Text='<%#Bind("Author") %>'></asp:Label></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publisher">
                            <ItemTemplate>
                                <asp:Label ID="lblBKBookPublisher" runat="server" Text='<%#Bind("BookPublisher") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblBKBookPublisher" runat="server" Text='<%#Bind("BookPublisher") %>'></asp:Label></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EditionNo">
                            <ItemTemplate>
                                <asp:Label ID="lblBKBookEditionNo" runat="server" Text='<%#Bind("BookEditionNo") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblBKBookEditionNo" runat="server" Text='<%#Bind("BookEditionNo") %>'></asp:Label></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblQty" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" Text='<%#Bind("Quantity") %>' Width="50px"></asp:TextBox>
                                <asp:TextBox ID="hfQty" runat="Server" Text='<%#Bind("Quantity") %>' Visible="False" /><asp:CompareValidator
                                    ID="CompareValidator3" ValidationGroup="Update" runat="server" ErrorMessage="*"
                                    ControlToCompare="hfQty" ControlToValidate="txtQty" Operator="LessThanEqual"
                                    Type="Double"></asp:CompareValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    TargetControlID="txtQty" FilterType="numbers" InvalidChars="+-=/*(). " FilterMode="InvalidChars">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PricePerBook">
                            <ItemTemplate>
                                <asp:Label runat="Server" ID="lblprice" Text='<%#Bind("Price") %>' /></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="Server" ID="txtprice" Text='<%#Bind("Price") %>' /></EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
        <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="541px"></asp:Label>
        &nbsp;
        <br />
       
        <ajaxToolkit:CalendarExtender ID="ceEntryDate" runat="server" TargetControlID="txtEntryDate" />
        <ajaxToolkit:CalendarExtender ID="ceTransferDate" runat="server" TargetControlID="txtTransferDate" />
        <asp:ObjectDataSource ID="OdsBranch1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetBranchCombo" TypeName="BranchManager">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
         <asp:ObjectDataSource ID="OdsBranch" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetBranchInstWise" TypeName="BranchManager">
        <SelectParameters>
            <asp:ControlParameter DefaultValue="0" Name="id" Type="Int32" ControlID="ddlToInstitute"
                                    PropertyName="SelectedValue" />
        </SelectParameters>
        
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetComboUser" TypeName="InstituteManager">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:ObjectDataSource ID="odsAssetDetails" runat="server" TypeName="AssetTransfer.AssetTransferB"
        SelectMethod="GVDISPGRID_Asset" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:SessionParameter Name="Institute_Id" SessionField="InstituteID" Type="Int32" />
            <asp:SessionParameter Name="Branch_Id" SessionField="BranchID" Type="Int32" />
            <asp:ControlParameter ControlID="ddlAsset" Name="Asset_Id" PropertyName="SelectedValue"
                Type="string" />
            <asp:ControlParameter ControlID="ddlAsstType" Name="AssetType" PropertyName="SelectedValue"
                Type="string" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <%-- <asp:ObjectDataSource ID="odsAssetDetails_Transfer" runat="server" TypeName="GlobalDataSetTableAdapters.AssetDetailsTableAdapter"
        InsertMethod="InsertRecord">
        <InsertParameters>
            <asp:Parameter Name="Institute_Id" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>--%>
    <asp:ObjectDataSource ID="SqlAssetType" runat="server" DataObjectTypeName="AssetType"
        SelectMethod="FillAssetType" TypeName="AssetTypeB"></asp:ObjectDataSource>
   <%-- <asp:ObjectDataSource ID="ObjInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetComboUser" TypeName="InstituteManager">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetBranchCombo" TypeName="BranchManager">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    <asp:ObjectDataSource ID="ObjAsset" runat="server" TypeName="AssetManager" SelectMethod="GetAssetByID"
        DataObjectTypeName="Asset">
        <SelectParameters>
            <asp:ControlParameter DefaultValue="0" Name="ID" Type="Int64" ControlID="ddlAsstType"
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="hffromdetail" runat="server" />
    <asp:HiddenField ID="hfAssetType" runat="Server" />
    <asp:HiddenField ID="hfReferenc" runat="Server" />
    <asp:HiddenField runat="Server" ID="hfPrice" />
    <asp:HiddenField runat="Server" ID="hfNewAssetDetId" />


</form>
</body>
</html>
