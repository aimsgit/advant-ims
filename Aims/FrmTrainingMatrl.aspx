<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmTrainingMatrl.aspx.vb"
    Inherits="FrmTrainingMatrl" Title="Training Material" %>

<%--<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Training Material</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
 function Valid()
{
    var msg;
     
    msg=FeesField(document.getElementById("<%=FormView1.FindControl("txtPrice").ClientID %>"),'Price');
    if(msg!="") return msg;    
    msg=DropDown(document.getElementById("<%=FormView1.FindControl("cmbAsset").ClientID %>"),'Asset');
    if(msg!="") return msg; 
    msg=ValidateDate(document.getElementById("<%=FormView1.FindControl("txtpurDate").ClientID %>"),'Purchase Date');
    if(msg!="") return msg;  
    msg=NameField100(document.getElementById("<%=FormView1.FindControl("txtInvNo").ClientID %>"),'Invoice No');
    if(msg!="") return msg;
    msg=Field255N(document.getElementById("<%=FormView1.FindControl("txtremarks").ClientID %>"),'Remarks');
    if(msg!="") return msg;txtreceivedby
    msg=NameField100N(document.getElementById("<%=FormView1.FindControl("txtreceivedby").ClientID %>"),'Received By');
    if(msg!="") return msg;    
    msg=Field30(document.getElementById("<%=FormView1.FindControl("txtLocation").ClientID %>"),'Location');
    if(msg!="") return msg;
    msg=NameField100(document.getElementById("<%=FormView1.FindControl("txtSerialNo").ClientID %>"),'Serial No');
    if(msg!="") return msg; 
    msg=NameField100(document.getElementById("<%=FormView1.FindControl("txtModel").ClientID %>"),'Model No');
    if(msg!="") return msg; 
    msg=Field255N(document.getElementById("<%=FormView1.FindControl("txtbrand").ClientID %>"),'Description');
    if(msg!="") return msg;  
    msg=FeesFieldRestrictDecimal(document.getElementById("<%=FormView1.FindControl("txtQty").ClientID %>"),'Quantity');
    if(msg!="") return msg;  
    msg=NameField100N(document.getElementById("<%=FormView1.FindControl("txtsentby").ClientID %>"),'Sent By');
    if(msg!="") return msg;
    return true;
} 
 function Validate(){
          var msg=Valid();
          if(msg!=true)
          { 
                    if(navigator.appName=="Microsoft Internet Explorer")
                    {
                     document.getElementById("<%=lblErrorMsg.ClientID %>").innerText=msg;
                     return false;
                    }
                    else  if(navigator.appName == "Netscape")
                    {  
                     document.getElementById("<%=lblErrorMsg.ClientID %>").textContent=msg;
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
                TRAINING MATERIALS</h1>
        </center>
        <center>
            <table class="custTable">
                <tbody>
                    <tr>
                        <td>
                            <asp:FormView ID="FormView1" runat="server" Width="665px" Height="135px" DataKeyNames="Id"
                                DataSourceID="odsInsert" DefaultMode="Insert" OnPageIndexChanging="FormView1_PageIndexChanging">
                                <InsertItemTemplate>
                                    <center>
                                        <table class="custTable">
                                                                                        <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="Asset Type*"></asp:Label></td>
                                                <td><asp:TextBox ID="TextBox2" runat="server" SkinID="txt" TabIndex="3" Text="Teaching Material"
                                                        Width="89px" AutoCompleteType="Disabled" Enabled="false" ></asp:TextBox><asp:TextBox ID="txtInsuredTo" runat="server" SkinID="txt"  Text='<%# Bind("InsuredTo") %>'
                                                TabIndex="12" AutoCompleteType="Disabled" Visible="false"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlAsstType" runat="server" SkinID="ddl"   SelectedValue='<%# Bind("AssetType") %>'
                                                        TabIndex="3" AutoPostBack="true" Visible="false" ><asp:ListItem Value="4">Teaching Material</asp:ListItem>
                                                    </asp:DropDownList></td>
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="Price*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtPrice" runat="server" SkinID="txt" Text='<%# Bind("Price") %>'
                                                        Width="89px" TabIndex="13" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator
                                                            ID="RFPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        TargetControlID="txtPrice" FilterType="Numbers" FilterMode="ValidChars" ValidChars=".1234567890/-">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="Asset Name*" Width="89px"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="cmbAsset" runat="server" DataSourceID="odsAsset" DataValueField="Id"
                                                        DataTextField="Name" SkinID="ddl" TabIndex="4">
                                                    </asp:DropDownList>
                                                <asp:HiddenField ID="hndAsset_Id" Value='<%# Bind("AssetId") %>' runat="server" />
                                              </td>
                                              </tr>
                                              
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" SkinID="lbl" Text=" Supplier"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="cmbSupp" runat="server" DataSourceID="CmbSuppSql" DataValueField="Supp_ID"
                                                        DataTextField="Supp_Name" AppendDataBoundItems="True" SkinID="ddl" SelectedValue='<%# Bind("SupplierId") %>'
                                                        TabIndex="5">
                                                    </asp:DropDownList></td>
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:Label ID="lblreceivedby" runat="server" SkinID="lbl" Text="Received By"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtreceivedby" runat="server" SkinID="txt" Text='<%# Bind("To1") %>'
                                                        Width="89px" TabIndex="15" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="Manufacturers"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="cmbManu" runat="server" DataSourceID="cmbManuSql" DataValueField="Id"
                                                        DataTextField="Manufacturername" AppendDataBoundItems="True" SkinID="ddl" SelectedValue='<%# Bind("Manufacturer") %>'
                                                        TabIndex="6">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>   
                                                <td>
                                                    <asp:Label ID="Label27" runat="server" SkinID="lbl" Text="Location*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtLocation" runat="server" SkinID="txt" TabIndex="16" Text='<%# Bind("Location") %>'
                                                        Width="89px" AutoCompleteType="Disabled"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLocation"
                                                        ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" SkinID="lbl" Text="Machine Sl. No.*" Width="110px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtSerialNo" runat="server" SkinID="txt" TabIndex="7" Text='<%# Bind("SerialNo") %>'
                                                        Width="89px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                             </tr>
                                             <tr> 
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Payment Method" Width="107px" SkinID="lbl"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList2" runat="server" SkinID="ddl" SelectedValue='<%# Bind("PaymentMtd") %>'
                                                        TabIndex="17">
                                                        <asp:ListItem Value="1">Cash</asp:ListItem>
                                                        <asp:ListItem Value="2">Cheque/DD</asp:ListItem>
                                                    </asp:DropDownList></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="Model No.*" SkinID="lbl" Width="90px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtModel" runat="server" SkinID="txt" Text='<%# Bind("ModelNo") %>'
                                                        TabIndex="9" AutoCompleteType="Disabled"></asp:TextBox></td>
                                               </tr>
                                               <tr> 
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" SkinID="lbl" Text="Purchase Date" Width="98px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtpurDate" runat="server" SkinID="txt" Text='<%# Bind("PurchaseDate","{0:dd/MMM/yyyy}")%>'
                                                        TabIndex="18" AutoCompleteType="Disabled"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqFieldValidator" runat="server" ControlToValidate="txtpurDate"
                                                        ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="Invoice No*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtInvNo" runat="server" SkinID="txt" Text='<%# Bind("Invoice")%>'
                                                        Width="95px" TabIndex="10" AutoCompleteType="Disabled"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInvNo"
                                                        ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator></td>
                                             </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblbillType" runat="server" Text="Bill Type" Width="58px" SkinID="lbl"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="97px" SkinID="ddl" SelectedValue='<%# Bind("BillType") %>'
                                                        TabIndex="19">
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Credit</asp:ListItem>
                                                    </asp:DropDownList></td>
                                              
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAmtPaid" runat="server" Text="Amt Paid  *" SkinID="lbl" Width="71px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" SkinID="txt" Text='<%# Bind("Amtpaid") %>'
                                                        AutoCompleteType="Disabled" TabIndex="11"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                        TargetControlID="TextBox1" FilterType="Numbers" FilterMode="ValidChars" ValidChars=".1234567890/-">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                              </tr>
                                              <tr>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" SkinID="lbl" Text="Brought By" Width="92px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtbroughtby" runat="server" SkinID="txt" Text='<%# Bind("Broughtby") %>'
                                                        TabIndex="20" AutoCompleteType="Disabled"></asp:TextBox></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" SkinID="lbl" Text="Quantity*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtQty" runat="server" SkinID="txt" Text='<%# Bind("Quantity")%>'
                                                        TabIndex="12" AutoCompleteType="Disabled" MaxLength="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RfQty" runat="server" ControlToValidate="txtQty"
                                                        ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        TargetControlID="txtQty" FilterType="Numbers" FilterMode="ValidChars" ValidChars=".1234567890/-">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                           </tr>
                                           <tr>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Description" SkinID="lbl"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtbrand" runat="server" SkinID="txt" Text='<%# Bind("Description") %>'
                                                        TabIndex="21" AutoCompleteType="Disabled"></asp:TextBox></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" SkinID="lbl" Text="Entrydate*" Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtentrydate" runat="server" SkinID="txt" Text='<%# Bind("Entrydate","{0:dd/MMM/yyyy}")%>'
                                                        AutoCompleteType="Disabled" MaxLength="2" Visible="False"></asp:TextBox></td>
                                              </tr>
                                              <tr>
                                                <td>
                                                    <asp:Label ID="lblsentby" runat="server" SkinID="lbl" Text="SentBy"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtsentby" runat="server" SkinID="txt" Text='<%# Bind("From1") %>'
                                                        Width="89px" TabIndex="22" AutoCompleteType="Disabled"></asp:TextBox></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label29" runat="server" SkinID="lbl" Text="Motor Sl. No.*" Width="106px"
                                                        Visible="False"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtMotorNo" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                                        TabIndex="8" Text='<%# Bind("MotorNo") %>' Width="89px" Visible="False"></asp:TextBox></td>
                                             </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblremarks" runat="server" SkinID="lbl" Text="Remarks"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtremarks" runat="server" SkinID="txt" Text='<%# Bind("Remarks") %>'
                                                        Width="89px" TabIndex="14" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                
                                            </tr>
                                            <tr>
                                                <td class="btnTd" colspan="2">
                                                    <asp:Button ID="btnsave" runat="server" Text="SAVE" Width="90px" SkinID="btn" CommandName="Insert"
                                                        TabIndex="19" ValidationGroup="save" OnClick="btnsave_click" OnClientClick="return Validate();"
                                                        CssClass="btnStyle" />
                                                    <asp:Button ID="btnDetails" runat="server" Text="DETAILS" SkinID="btn" Width="90px"
                                                        OnClick="Details" CausesValidation="False" TabIndex="20" CssClass="btnStyle" />
                                                </td>
                                               
                                            </tr>
                                            <tr> 
                                                <td>
                                                    <asp:TextBox ID="txttotalval" runat="server" SkinID="txt" Text='<%# Bind("TotalVal")%>'
                                                        AutoCompleteType="Disabled" MaxLength="2" Visible="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMotorNo"
                                                        ErrorMessage="*" ValidationGroup="save" Visible="False"></asp:RequiredFieldValidator>&nbsp;
                                                </td>
                                               
                                            </tr>
                                         </table>
                                         <table>   
                                            <tr>
                                                <td>
                                                    <asp:ObjectDataSource ID="odsAsset" runat="server" TypeName="AssetManager" SelectMethod="GetAssetByID"
                                                        DataObjectTypeName="AssetCombo">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="FormView1$ddlAsstType" DefaultValue="0" Name="ID"
                                                                PropertyName="SelectedValue" Type="Int64" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:CalendarExtender ID="ceEDate" runat="server" SkinID="CalendarView" TargetControlID="txtpurDate"
                                                        Format="dd/MMM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                               
                                            </tr>
                                        </table>
                                    </center>
                                </InsertItemTemplate>
                                <EditItemTemplate>
                                    <center>
                                        <table class="custTable">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="  Institute*"></asp:Label></td>
                                                <td><asp:TextBox ID="txtInsuredTo" runat="server" SkinID="txt"  Text='<%# Bind("InsuredTo") %>'
                                                TabIndex="12" AutoCompleteType="Disabled" Visible="false"></asp:TextBox>
                                                    <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="objInstitute" DataTextField="Name"
                                                        DataValueField="ID" SkinID="ddl" SelectedValue='<%# Bind("InstituteId") %>' TabIndex="1">
                                                    </asp:DropDownList></td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Branch*"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="objBranch" DataValueField="Id"
                                                        DataTextField="Name" AppendDataBoundItems="True" SkinID="ddl" SelectedValue='<%# Bind("BranchId") %>'
                                                        TabIndex="2">
                                                    </asp:DropDownList></td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Asset Type*"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAsstType" runat="server" SkinID="ddl"  Visible="false" 
                                                         SelectedValue='<%# Bind("AssetType") %>'
                                                        TabIndex="3" AutoPostBack="true"><asp:ListItem Value="4">Teaching Material</asp:ListItem>
                                                    </asp:DropDownList><asp:TextBox ID="TextBox3" runat="server" SkinID="txt" Enabled="false"  Text="Teaching Material"
                                                        Width="89px" TabIndex="3" AutoCompleteType="Disabled"></asp:TextBox> </td>
                                               </tr>
                                               <tr> 
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="Price*"></asp:Label></td>
                                                <td>
                                                   <asp:TextBox ID="txtPrice" runat="server" SkinID="txt" Text='<%# Bind("Price") %>'
                                                        Width="89px" TabIndex="13" AutoCompleteType="Disabled"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        TargetControlID="txtPrice" FilterType="Numbers" FilterMode="ValidChars" ValidChars=".1234567890/-">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RFPrice" runat="server" ControlToValidate="txtPrice"
                                                        ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Asset Name*" Width="89px"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="cmbAsset" runat="server" DataSourceID="odsAsset" DataValueField="Id"
                                                        DataTextField="Name" SkinID="ddl" TabIndex="4">
                                                    </asp:DropDownList></td>
                                              </tr>
                                              <tr>
                                                <td colspan="2">
                                                    <asp:HiddenField ID="hndAsset_Id" Value='<%# Bind("AssetId") %>' runat="server" />
                                                </td>
                                             </tr>
                                             
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" SkinID="lbl" Text=" Supplier"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="CmbSuppSql" DataValueField="Supp_Id"
                                                        DataTextField="Supp_Name" AppendDataBoundItems="True" SkinID="ddl" SelectedValue='<%# Bind("SupplierId") %>'
                                                        TabIndex="5">
                                                    </asp:DropDownList></td>
                                               
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:Label ID="lblreceivedby" runat="server" SkinID="lbl" Text="ReceivedBy"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtreceivedby" runat="server" SkinID="txt" Text='<%# Bind("To1") %>'
                                                        AutoCompleteType="disabled" TabIndex="15"></asp:TextBox></td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Manufacturers"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList9" runat="server" DataSourceID="cmbManuSql" DataValueField="Id"
                                                        DataTextField="Manufacturername" AppendDataBoundItems="True" SkinID="ddl" SelectedValue='<%# Bind("Manufacturer") %>'
                                                        TabIndex="6">
                                                    </asp:DropDownList></td>
                                                
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:Label ID="Label27" runat="server" SkinID="lbl" Text="Location*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtLocation" runat="server" SkinID="txt" TabIndex="16" Text='<%# Bind("Location") %>'
                                                        Width="89px" AutoCompleteType="Disabled"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLocation"
                                                        ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" SkinID="lbl" Text="Machine Sl. No.*" Width="117px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtSerialNo" runat="server" SkinID="txt" TabIndex="7" Text='<%# Bind("SerialNo") %>'
                                                        Width="89px" AutoCompleteType="Disabled"></asp:TextBox></td>
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Payment Method" Width="107px" SkinID="lbl"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList8" runat="server" SkinID="ddl" SelectedValue='<%# Bind("PaymentMtd") %>'
                                                        TabIndex="17">
                                                        <asp:ListItem Value="1">Cash</asp:ListItem>
                                                        <asp:ListItem Value="2">Cheque/DD</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="Model No.*" SkinID="lbl" Width="90px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtModel" runat="server" SkinID="txt" Text='<%# Bind("ModelNo") %>'
                                                        TabIndex="9" AutoCompleteType="Disabled"></asp:TextBox></td>
                                            </tr>
                                            <tr>   
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Purchase Date" Width="98px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtpurDate" runat="server" SkinID="txt" Text='<%# Bind("PurchaseDate","{0:dd/MMM/yyyy}")%>'
                                                        TabIndex="18"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpurDate"
                                                        ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" SkinID="lbl" Text="Invoice No*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtInvNo" runat="server" SkinID="txt" Text='<%# Bind("Invoice")%>'
                                                        Width="95px" TabIndex="10" AutoCompleteType="Disabled"></asp:TextBox></td>
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="Bill Type" Width="58px" SkinID="lbl"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList10" runat="server" Width="97px" SkinID="ddl" SelectedValue='<%# Bind("BillType") %>'
                                                        TabIndex="19">
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Credit</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label25" runat="server" Text="Amt Paid" SkinID="lbl"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="TextBox4" runat="server" SkinID="txt" Text='<%# Bind("Amtpaid") %>'
                                                        AutoCompleteType="Disabled" TabIndex="11"></asp:TextBox></td>
                                              </tr>
                                              
                                              <tr>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server" SkinID="lbl" Text="Brought By" Width="92px"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="TextBox5" runat="server" SkinID="txt" Text='<%# Bind("Broughtby") %>'
                                                        TabIndex="20" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" SkinID="lbl" Text="Quantity*"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtqty" runat="server" SkinID="txt" Text='<%# Bind("Quantity") %>'
                                                        TabIndex="12" ReadOnly="true" AutoCompleteType="Disabled" MaxLength="5"></asp:TextBox></td>
                                               </tr>
                                               <tr>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4"
                                                        ValidationExpression="[0-9]*" ValidationGroup="update">*</asp:RegularExpressionValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        TargetControlID="TextBox4" FilterType="Numbers" FilterMode="ValidChars" ValidChars=".1234567890/-">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                               </tr>
                                               <tr> 
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Description" SkinID="lbl"></asp:Label></td>
                                                <td style="height: 17px;">
                                                    <asp:TextBox ID="txtbrand" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                                        TabIndex="21" Text='<%# Bind("Description") %>'></asp:TextBox></td>
                                                <td style="height: 17px">
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" SkinID="lbl" Text="Entrydate*" Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtentrydate" runat="server" SkinID="txt" Text='<%# Bind("Entrydate","{0:dd/MMM/yyyy}")%>'
                                                        AutoCompleteType="Disabled" MaxLength="2" Visible="False"></asp:TextBox></td>
                                             </tr>
                                             <tr>   
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RfQty" runat="server" ControlToValidate="txtQty"
                                                        ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                        TargetControlID="txtqty" FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <asp:TextBox ID="txttotalval" runat="server" SkinID="txt" Text='<%# Bind("TotalVal")%>'
                                                        AutoCompleteType="Disabled" MaxLength="2" Visible="False"></asp:TextBox></td>
                                               </tr>
                                               <tr>
                                                <td style="height: 37px">
                                                    <asp:Label ID="lblsentby" runat="server" SkinID="lbl" Text="SentBy"></asp:Label></td>
                                                <td style="height: 37px">
                                                    <asp:TextBox ID="txtsentby" runat="server" SkinID="txt" Text='<%# Bind("From1") %>'
                                                        Width="89px" TabIndex="22" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                <td style="height: 37px">
                                                </td>
                                            </tr>
                                            <tr> 
                                                <td>
                                                    <asp:Label ID="lblremarks" runat="server" SkinID="lbl" Text="Remarks"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtremarks" runat="server" SkinID="txt" Text='<%# Bind("Remarks") %>'
                                                        Width="89px" TabIndex="14" AutoCompleteType="Disabled"></asp:TextBox></td>
                                                
                                            </tr>
                                            <tr>
                                               
                                                <td>
                                                    <asp:Label ID="Label29" runat="server" SkinID="lbl" Text="Motor Sl. No.*" Width="96px"
                                                        Visible="False"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtMotorNo" runat="server" SkinID="txt" Text='<%# Bind("MotorNo") %>'
                                                        AutoCompleteType="disabled" TabIndex="8" Visible="False"></asp:TextBox></td>
                                              </tr>
                                             
                                            </table>
                                            <table>
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:CalendarExtender ID="ceEDate" runat="server" SkinID="CalendarView" TargetControlID="txtpurDate"
                                                        Format="dd/MMM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <asp:ObjectDataSource ID="odsAsset" runat="server" TypeName="AssetManager" SelectMethod="GetAssetByID"
                                                        DataObjectTypeName="AssetCombo">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="FormView1$ddlAsstType" DefaultValue="0" Name="ID"
                                                                PropertyName="SelectedValue" Type="Int64" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="btnTd">
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnsave" runat="server" Text="UPDATE" Width="90px" SkinID="btn" CommandName="Update"
                                                        TabIndex="19" ValidationGroup="update" OnClick="btnupdate_click" OnClientClick="return Validate();"  CssClass="btnStyle" /><asp:Button
                                                            ID="btnCancel" runat="server" Text="CANCEL" SkinID="btn" CommandName="Update"
                                                            TabIndex="20" ValidationGroup=" " OnClick="btnCancel_Click" CssClass="btnStyle" /></td>
                                                
                                            </tr>
                                            <tr>  
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInvNo"
                                                        ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator>&nbsp;
                                                </td>
                                              </tr>
                                        </table>
                                </EditItemTemplate>
                                <EmptyDataTemplate>
                                    <strong>No Records To Display.</strong>
                                </EmptyDataTemplate>
                                <HeaderTemplate>
                                    <center>
                                        <span style="font-size: 16pt"></span><span style="font-size: 16pt"><strong></strong>
                                        </span>
                                    </center>
                                </HeaderTemplate>
                            </asp:FormView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center><div class="errMgs"><asp:Label ID="lblErrorMsg" runat="server" ></asp:Label></div></center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <%--<tr>
                        <td colspan="2">
                            <cc1:msgBox ID="MsgBox1" runat="server"></cc1:msgBox>
                        </td>
                    </tr>--%>
                </tbody>
            </table>
        </center>
        <center>
            <asp:ObjectDataSource ID="objBranch" runat="server" DataObjectTypeName="Branch" SelectMethod="GetBranch"
                TypeName="BranchManager"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsBranch" runat="server" SelectMethod="GetBranchCombo"
                TypeName="BranchManager" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsInsert" runat="server" DataObjectTypeName="AssetDetails"
                SelectMethod="GetAssetDetails" TypeName="AssetDetailsB" UpdateMethod="UpdateRecord"
                InsertMethod="InsertRecord"></asp:ObjectDataSource>
            <%-- <InsertParameters>
                <asp:Parameter Name="EntryDate" Type="DateTime" />
                <asp:Parameter Name="TotalVal" Type="Single" />
            </InsertParameters>--%>
            <%--<asp:ObjectDataSource ID="odsInsert" runat="server" TypeName="GlobalDataSetTableAdapters.AssetDetailsTableAdapter"
            InsertMethod="InsertRecord_Details" UpdateMethod="UpdateAssetDetails" SelectMethod="GetDataById"
            OldValuesParameterFormatString="original_{0}">
            <InsertParameters>
                <asp:Parameter Name="AssetType" Type="int32" />
                <asp:Parameter Name="Asset_Id" Type="int32" />
                <asp:Parameter Name="Branch_Id" Type="int32" />
                <asp:Parameter Name="Institute_Id" Type="int32" />
                <asp:Parameter Name="Supp_Id" Type="int32" />
                <asp:Parameter Name="ManuFacturer_Id" Type="int32" />
                <asp:Parameter Name="InvoiceNo" Type="String" />
                <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                <asp:Parameter Name="EntryDate" Type="DateTime" />
                <asp:Parameter Name="Quantity" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Model_Number" Type="String" />
                <asp:Parameter Name="Brought_by" Type="String" />
                <asp:Parameter Name="AmtPaid" Type="Double" />
                <asp:Parameter Name="BillType" Type="String" />
                <asp:Parameter Name="PaymentMethod_Id" Type="int32" />
                <asp:Parameter Name="Total_Value" Type="Double" />
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="Serial_No" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Remarks" Type="string" />
                <asp:Parameter Name="From1" Type="string" />
                <asp:Parameter Name="To1" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AssetType" Type="int32" />
                <asp:Parameter Name="Asset_Id" Type="int32" />
                <asp:Parameter Name="Branch_Id" Type="int32" />
                <asp:Parameter Name="Institute_Id" Type="int32" />
                <asp:Parameter Name="Supp_Id" Type="int32" />
                <asp:Parameter Name="ManuFacturer_Id" Type="int32" />
                <asp:Parameter Name="InvoiceNo" Type="String" />
                <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                <asp:Parameter Name="EntryDate" Type="DateTime" />
                <asp:Parameter Name="Quantity" Type="String" />
                <asp:Parameter Name="Price" Type="string" />
                <asp:Parameter Name="Model_Number" Type="String" />
                <asp:Parameter Name="Brought_by" Type="String" />
                <asp:Parameter Name="AmtPaid" Type="string" />
                <asp:Parameter Name="BillType" Type="String" />
                <asp:Parameter Name="PaymentMethod_Id" Type="int32" />
                <asp:Parameter Name="Total_Value" Type="int32" />
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="Serial_No" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Remarks" Type="string" />
                <asp:Parameter Name="From1" Type="string" />
                <asp:Parameter Name="To1" Type="string" />
                <asp:Parameter Name="Original_AssetDet_Id" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>--%>
            <asp:HiddenField ID="HFQuantity" runat="server"></asp:HiddenField>
            <asp:ObjectDataSource ID="objInstitute" runat="server" DataObjectTypeName="Institute"
                SelectMethod="GetInstitute" TypeName="InstituteManager"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsInstitute" runat="server" SelectMethod="GetComboUser"
                TypeName="InstituteManager" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="HfAssettype" runat="server"></asp:HiddenField>
            <%-- <asp:SqlDataSource ID="SqlAssetType" runat="server" SelectCommand="SELECT AssetType_ID,AssetType_Name FROM AssetType WHERE AssetType_ID<>4"
            ConnectionString="<%$ ConnectionStrings:Sahaj_Edu %>" ProviderName="<%$ ConnectionStrings:Sahaj_IMS.ProviderName %>">
        </asp:SqlDataSource>--%>
            <asp:ObjectDataSource ID="SqlAssetType" runat="server" DataObjectTypeName="AssetType"
                SelectMethod="FillAssetType" TypeName="AssetTypeB"></asp:ObjectDataSource>
            <%--<asp:SqlDataSource ID="CmbSuppSql" runat="server" SelectCommand="SELECT Supp_Id,Supp_Name FROM SupplierMaster where Del_Flag = 0 ORDER BY Supp_Name"
            ConnectionString="<%$ ConnectionStrings:Sahaj_Edu %>" ProviderName="<%$ ConnectionStrings:Sahaj_IMS.ProviderName %>">
        </asp:SqlDataSource>
            <asp:ObjectDataSource ID="CmbSuppSql" runat="server" DataObjectTypeName="Supplier"
                SelectMethod="GetSupplierDetails" TypeName="SupplierManager"></asp:ObjectDataSource>
            <%--<asp:SqlDataSource ID="cmbManuSql" runat="server" SelectCommand="SELECT ManuFacturer_ID,ManuFacturer FROM ManuFacturerMaster where Del_Flag = 0 ORDER BY ManuFacturer "
            ConnectionString="<%$ ConnectionStrings:Sahaj_Edu %>" ProviderName="<%$ ConnectionStrings:Sahaj_IMS.ProviderName %>">
        </asp:SqlDataSource>--%>
           
            <asp:ObjectDataSource ID="CmbSuppSql" runat="server" DataObjectTypeName="Supplier"
                SelectMethod="GetSupplierDetails" TypeName="SupplierManager"></asp:ObjectDataSource>
            <%--<asp:SqlDataSource ID="cmbManuSql" runat="server" SelectCommand="SELECT ManuFacturer_ID,ManuFacturer FROM ManuFacturerMaster where Del_Flag = 0 ORDER BY ManuFacturer "
            ConnectionString="<%$ ConnectionStrings:Sahaj_Edu %>" ProviderName="<%$ ConnectionStrings:Sahaj_IMS.ProviderName %>">
        </asp:SqlDataSource>--%>
            <asp:ObjectDataSource ID="cmbManuSql" runat="server" SelectMethod="GetManufacturer"
                TypeName="ManufacturerManager"></asp:ObjectDataSource>
            <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="AssetManager" SelectMethod="GetAssetByID"
               DataObjectTypeName="Asset">
               <SelectParameters>
                   <asp:ControlParameter DefaultValue="0" Name="ID" Type="Int64" ControlID="ddlAsstType"
                            PropertyName="SelectedValue" />
               </SelectParameters>
             </asp:ObjectDataSource>--%>
        </center>
    </div>

</form>
</body>
</html>
