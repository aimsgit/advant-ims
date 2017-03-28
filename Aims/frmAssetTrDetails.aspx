<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAssetTrDetails.aspx.vb"
    Inherits="frmAssertTrDetails" Title="Asset Transfer Details"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Transfer Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">  
     function Valid()
   {
   var msg;
    msg=DropDown(document.getElementById("<%=ddlToBranch.ClientID %>"),'To Branch ');
    if(msg!="") return msg;
    msg=DropDown(document.getElementById("<%=ddlToInstitute.ClientID %>"),'To Institute ');
    if(msg!="") return msg;
     if (document.getElementById("<%=ddlAsstType.ClientID %>").value!=2)
   {
     msg=FeesField(document.getElementById("<%=txtPrice.ClientID %>"),'Price ');
     }
    if(msg!="") return msg;
    msg=ValidateDate(document.getElementById("<%=txtPurDate.ClientID %>"),'Purchase Date');
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

    <center>
        <h1>
            ASSET TRANSFER DETAILS</h1>
    </center>
    <h3>
        Asset Details</h3>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Asset Type*"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlAsstType" runat="server" SkinID="ddl" DataSourceID="SqlAssetType"
                    DataValueField="AssetType_ID" DataTextField="Name" TabIndex="3" AutoPostBack="true">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="Asset Name*"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlAsset" runat="server" DataSourceID="ObjAsset" DataValueField="Id"
                    DataTextField="Name" SkinID="ddl" TabIndex="4" AutoPostBack="True">
                </asp:DropDownList></td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Panel ID="Pan1" runat="server" SkinID="Pnl">
        <asp:GridView ID="gvAssetDetails" runat="server" DataSourceID="odsAssetDetails" SkinID="GridView"
            OnRowCommand="gvAssetDetails_RowCommand" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="Trasfer_Id" OnSelectedIndexChanged="gvAssetDetails_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:HiddenField ID="TRID" runat="server" Value='<%# Bind("Trasfer_Id") %>'></asp:HiddenField>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                            Text="Edit"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FromBranch">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Bind("BranchName")%>'></asp:Label>
                        <asp:Label ID="hftid" runat="server" Visible="false" Text='<%#Bind("Target_Id") %>' />
                        <asp:Label ID="hfSid" runat="server" Visible="false" Text='<%#Bind("Source_Id") %>' />
                        <asp:Label ID="hfinsid" runat="server" Visible="false" Text='<%#Bind("Institute_ID1") %>' />
                        <asp:Label ID="hfbrnid" runat="server" Visible="false" Text='<%#Bind("Branch_ID1") %>' />
                        <asp:Label ID="hfTrId" runat="Server" Visible="false" Text='<%#Bind("Trasfer_Id") %>' />
                        <asp:Label ID="hfAssetType" runat="Server" Visible="false" Text='<%#Bind("AssetType") %>' />
                        <asp:Label ID="SPrice" runat="Server" Visible="False" Text='<%#Bind("SPrice") %>' />
                        <asp:Label ID="TPrice" runat="server" Visible="False" Text='<%#Bind("TPrice") %>' />
                        <asp:Label ID="PurchaseDate" runat="Server" Visible="False" Text='<%#DataBinder.Eval(Container.DataItem, "PurchaseDate").ToShortDateString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="From BranchType">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%#Bind("InstituteName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ToBranch">
                    <ItemTemplate>
                        <asp:Label ID="ldl1" runat="server" Text='<%#Bind("BranchName1")%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="To BranchType">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Bind("InstituteName1") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lblprice" runat="server" Text='<%#Bind("TPrice") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                        <asp:Label ID="hfQty" runat="server" Visible="false" Text='<%# Convert.ToInt64(Eval("DiffQuantity")+Convert.ToInt32(Eval("Quantity"))) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblremarks" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SentBY">
                    <ItemTemplate>
                        <asp:Label ID="lblfrom" runat="server" Text='<%#Bind("From1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReceivedBy">
                    <ItemTemplate>
                        <asp:Label ID="lblto" runat="server" Text='<%#Bind("To1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TransferDate">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TransferDate").ToShortDateString()%>'></asp:Label>
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
    <br />
    <br />
    <asp:Panel ID="pan2" runat="server" Width="103%">
        <%--    <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="20%">
                    <asp:Label ID="Label2" runat="server" Text="From Institute" SkinID="lbl" EnableViewState="False"></asp:Label>&nbsp;
                </td>
                <td width="30%">
                    <asp:TextBox ID="txtFromInstitute" runat="server" ReadOnly="true" SkinID="txt" TabIndex="2"></asp:TextBox>
                </td>
                <td width="17%">
                    <asp:Label ID="Label1" runat="server" Text="Branch" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td width="30%">
                    <asp:DropDownList ID="ddlToBranch" runat="server" DataSourceID="OdsBranch" DataValueField="Id"
                        DataTextField="Name" SkinID="ddl" AutoPostBack="true" TabIndex="3">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                    <asp:Label ID="Label6" runat="server" Text=" Entry Date" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtEntryDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtEntryDate" ValidationGroup="Confirm" EnableViewState="False"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 22px">
                    <asp:Label ID="Label3" runat="server" Text=" To" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:DropDownList ID="ddlToInstitute" runat="server" DataSourceID="OdsInstitute"
                        DataValueField="Id" DataTextField="Name" SkinID="ddl" TabIndex="5">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:Label ID="Label8" runat="server" Text="PurchaseDate" SkinID="lbl"></asp:Label></td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtPurDate" runat="server" ReadOnly="True" SkinID="txt" TabIndex="6"></asp:TextBox></td>
                <td align="left" valign="top">
                    <asp:Label ID="Label5" runat="server" Text=" Quantity" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtQuantity" runat="server" SkinID="txt" MaxLength="5" TabIndex="7"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" Operator="LessThanEqual"
                        ControlToCompare="hfQty" ControlToValidate="txtQuantity" Type="Integer" ValidationGroup="Confirm"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtQuantity" ValidationGroup="Confirm"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="hfQty" Visible="False" />&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text=" Transfer Date" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtTransferDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtTransferDate" ValidationGroup="Confirm" EnableViewState="False"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToCompare="txtPurDate"
                        ControlToValidate="txtTransferDate" Operator="GreaterThanEqual" Type="Date" ValidationGroup="Confirm"></asp:CompareValidator></td>
            </tr>
        </table>--%>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <%--<tr>
                <td width="20%">
                    <asp:Label ID="Label2" runat="server" Text="From Institute" SkinID="lbl" EnableViewState="False"></asp:Label>&nbsp;
                </td>
                <td width="30%">
                    <asp:TextBox ID="txtFromInstitute" runat="server" ReadOnly="true" SkinID="txt" TabIndex="2"></asp:TextBox>
                </td>
                <td width="17%">
                    <asp:Label ID="Label1" runat="server" Text="From Branch" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td width="30%">
                    <asp:TextBox ID="txtfrombranch" runat="server" ReadOnly="true" SkinID="txt" TabIndex="2"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td style="height: 24px">
                    <asp:Label ID="Label3" runat="server" Text=" To BranchType" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td style="height: 24px">
                    <asp:DropDownList ID="ddlToInstitute" runat="server" DataSourceID="OdsInstitute"
                        DataValueField="Id" DataTextField="Name" SkinID="ddl" TabIndex="5">
                    </asp:DropDownList>
                </td>
                <td style="height: 24px">
                    <asp:Label ID="Label6" runat="server" Text=" Entry Date" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                <td style="height: 24px">
                    <asp:TextBox ID="txtEntryDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="20%">
                    <asp:Label ID="Label5" runat="server" Text="To Branch" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                <td style="height: 22px">
                    <asp:DropDownList ID="ddlToBranch" runat="server" DataSourceID="OdsBranch" DataValueField="Id"
                        DataTextField="Name" SkinID="ddl" AutoPostBack="true" TabIndex="3">
                    </asp:DropDownList></td>
                <td align="left" valign="top">
                    <asp:Label ID="Label8" runat="server" Text="PurchaseDate" SkinID="lbl"></asp:Label></td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtPurDate" runat="server" ReadOnly="True" SkinID="txt" TabIndex="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text=" Transfer Date" SkinID="lbl" EnableViewState="False"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtTransferDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>&nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:Label ID="Label10" runat="server" Text=" Quantity" SkinID="lbl" EnableViewState="False"></asp:Label>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtQuantity" runat="server" SkinID="txt" MaxLength="5" TabIndex="7"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox runat="server" ID="hfQty" Visible="False" Width="24px" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblprice1" runat="server" Text="Price" SkinID="lbl" EnableViewState="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtprice" runat="server" SkinID="txt"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtremarks" runat="server" SkinID="txt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblfrom" runat="server" Text="SentBY" SkinID="lbl" EnableViewState="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfrom" runat="server" SkinID="txt"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblto" runat="server" SkinID="lbl" Text="ReceivedBy"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtto" runat="server" SkinID="txt"></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>
    <div align="center" >
    <asp:Panel ID="Pan3" runat="server" Width="100%">
        <asp:GridView ID="gvBookDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="Book_ID" SkinID="GridView">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel"></asp:LinkButton>
                        <asp:Label ID="TransferBookId" runat="Server" Text='<%#Bind("OBkid") %>' Visible="false"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete"></asp:LinkButton>
                        <asp:Label ID="TransferBookId" runat="Server" Text='<%#Bind("OBkid") %>' Visible="false"></asp:Label>
                        <asp:Label ID="TQty" runat="server" Text='<%#Bind("TQty") %>' Visible="false"></asp:Label>
                        <asp:Label ID="BKPrice" runat="server" Text='<%#Bind("Price") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookName">
                    <ItemTemplate>
                        <asp:Label ID="lblBookName" runat="server" Text='<%#Bind("BookName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%#Bind("BookName") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthor" runat="server" Text='<%#Bind("Author") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblAuthor" runat="server" Text='<%#Bind("Author") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EditionNo">
                    <ItemTemplate>
                        <asp:Label ID="lblEditionNo" runat="server" Text='<%#Bind("BookEditionNo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblEditionNo" runat="server" Text='<%#Bind("BookEditionNo") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                        <asp:Label ID="TQtyAsset" runat="server" Text='<%#Bind("TQtyAsset") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%#Bind("Quantity") %>' Width="50px"
                            MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="lblQty" runat="server" Text='<%#Bind("TQty") %>' Visible="false"
                            Width="1px"></asp:TextBox><asp:CompareValidator ID="CompareValidator2" runat="server"
                                ErrorMessage="*" ControlToCompare="lblQty" ControlToValidate="txtQty" ValidationGroup="Update"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtQty" ValidationGroup="Update"></asp:RequiredFieldValidator>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                            TargetControlID="txtQty" FilterMode="InvalidChars" FilterType="numbers" InvalidChars="+-=/*(). ">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <div align="center" style="width: 100%;">
            &nbsp;<asp:Button ID="btnBKReport" runat="server" Text="REPORT" SkinID="btn" TabIndex="9" Visible="False" /><asp:Button
                ID="btnBKRecover" runat="server" Text="RECOVER" SkinID="btn" TabIndex="10" Visible="False" />
        </div>
    </asp:Panel>
    </div>
    <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="541px"></asp:Label><br />
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="text-align: center; height: 24px;" colspan="6">
                &nbsp;<asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" ValidationGroup="Confirm"
                    CausesValidation="False" TabIndex="15" /><asp:Button ID="btnInsert" runat="server"
                        Text="CONFIRM" SkinID="btn" CausesValidation="true" ValidationGroup="Confirm"
                        TabIndex="11" /><asp:Button ID="btnCancel" runat="server" Text="CANCEL" CommandName="Cancel"
                            SkinID="btn" CausesValidation="False" TabIndex="12" /><asp:Button ID="btnReport"
                                runat="server" Text="REPORT" SkinID="btn" CausesValidation="False" TabIndex="13" /><asp:Button
                                    ID="btnRecover" runat="server" Text="RECOVER" SkinID="btn" CausesValidation="False"
                                    TabIndex="14" Visible="False" />
            </td>
        </tr>
    </table>
    <ajaxToolkit:CalendarExtender ID="ceEntryDate" runat="server" TargetControlID="txtEntryDate" />
    <ajaxToolkit:CalendarExtender ID="ceTransferDate" runat="server" TargetControlID="txtTransferDate" />
    <asp:ObjectDataSource ID="OdsInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetComboUser" TypeName="InstituteManager">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsBranch" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetBranchCombo" TypeName="BranchManager">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SqlAssetType" runat="server" DataObjectTypeName="AssetType"
        SelectMethod="FillAssetType" TypeName="AssetTypeB"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsAsset" runat="server" TypeName="AssetManager" SelectMethod="GetAsset"
        DataObjectTypeName="Asset"></asp:ObjectDataSource>
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
        TargetControlID="txtQuantity" FilterMode="InvalidChars" FilterType="numbers"
        InvalidChars="+-=/*(). ">
    </ajaxToolkit:FilteredTextBoxExtender>
    <asp:ObjectDataSource ID="ObjInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
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
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjAsset" runat="server" TypeName="AssetManager" SelectMethod="GetAssetByID"
        DataObjectTypeName="Asset">
        <SelectParameters>
            <asp:ControlParameter DefaultValue="0" Name="ID" Type="Int64" ControlID="ddlAsstType"
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <%--  DeleteMethod="UpdateDel"--%>
    <asp:ObjectDataSource ID="odsAssetDetails" runat="server" TypeName="AssetTransfer.AssetTransferB"
        SelectMethod="Get_AssettransferDet" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlAsset" Name="Asset_Id" PropertyName="SelectedValue"
                Type="string" />
                <asp:SessionParameter Name="Institute_Id" SessionField="InstituteID" Type="Int32"/>
                <asp:SessionParameter Name="Branch_Id" SessionField="BranchID" Type="Int32"/>
            <asp:ControlParameter ControlID="ddlAsstType" Name="AssetType" PropertyName="SelectedValue"
                Type="string" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="hfRef" runat="Server" />
    <asp:HiddenField ID="hfTrId" runat="Server" />
    <asp:HiddenField ID="hftype" runat="server" />
    <asp:HiddenField ID="hfSPrice" runat="server" />
    <asp:HiddenField ID="hfTPrice" runat="Server" />
    <asp:HiddenField ID="hfSid" runat="server" />
    <asp:HiddenField runat="server" ID="hfTId" />

</form>
</body>
</html>