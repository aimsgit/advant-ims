<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAssetUsage.aspx.vb"
    Inherits="frmAssetUsage" Title="Asset Usage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Usage</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">  
   function Valid(){
   var msg; 
    msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
  if(msg!="") return msg;
  msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
  if(msg!="") return msg;
     msg=FeesFieldRestrictDecimal(document.getElementById("<%=txtTotlQty.ClientID%>"),'Total Quantity');
     if(msg!="") return msg;         
     msg=ValidateDate(document.getElementById("<%=txtUsageDate.ClientID%>")  ,'Usage date')       
     if(msg!="") return msg;
     msg=FeesFieldRestrictDecimal(document.getElementById("<%=TxtQuantity.ClientID%>")  ,'Quantity')       
     if(msg!="") return msg;
     msg=FeesFieldRestrictDecimal(document.getElementById("<%=txtusedqty.ClientID%>")  ,'Used Quantity')       
     if(msg!="") return msg;
         return true;
   }   
function Validate(){

  var msg=Valid();
  
  if(msg!=true){
   if(navigator.appName=="Microsoft Internet Explorer")
{
 document.getElementById("<%=msginfo.ClientID %>").innerText=msg;
 return false;
}
else  if(navigator.appName == "Netscape")
{  
 document.getElementById("<%=msginfo.ClientID %>").textContent=msg;
 return false;
}   
 return true;
  } 
  }
  function ShowImage()
{
GlbShowSImage(document.getElementById("<%=txtCourse.ClientID%>"));

 }
function HideImage()
{
 GlbHideSImage(document.getElementById("<%=txtCourse.ClientID%>"));
}   
function ShowImage1()
{
GlbShowSImage(document.getElementById("<%=txtBatch.ClientID%>"));

 }
function HideImage1()
{
 GlbHideSImage(document.getElementById("<%=txtBatch.ClientID%>"));
}   
    </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 <div>
        <center>
        <h1 class="headingTxt">
            TEACHING MATERIAL USAGE
        </h1>
        </center>
        <center>
            <table class="custTable">
               <tr>
            <td>
                <asp:TextBox ID="TxtUsageID" runat="server" Visible="False">0</asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtTotalQTY" runat="server" Visible="false"></asp:TextBox>
                </td>
        </tr>
                <TR>
 <TD>
 <asp:Label id="lblcourse" runat="server" Width="53px" Text="Course*" SkinID="lbl"> </asp:Label> </TD>
 
 <TD>
 
<%-- <asp:DropDownList id="ddlCourse" tabIndex=3 runat="server" SkinID="ddlL" DataValueField="Course_ID" DataTextField="Course" AutoPostBack="True" __designer:wfdid="w37">
 
 </asp:DropDownList>
 --%>
 
<asp:TextBox id="txtCourse" runat="server" Width="296px" AutoPostBack="True"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender 
    id="AutoCompleteExtender2" 
    runat="Server" 
    TargetControlID="txtCourse" 
    EnableCaching="true" 
    MinimumPrefixLength="1" 
    ServiceMethod="getCourseExt" 
    ServicePath="TextBoxExt.asmx" 
    FirstRowSelected="true" 
    CompletionInterval="2000" 
    onclientpopulated="HideImage" 
    onclientpopulating="ShowImage">
</ajaxToolkit:AutoCompleteExtender>

 <ajaxToolkit:TextBoxWatermarkExtender 
    ID="TextBoxWatermarkExtender1" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtCourse" 
    SkinID="watermark">
</ajaxToolkit:TextBoxWatermarkExtender>

 </TD>
 <TD colSpan=1>
 </TD>
 </TR>
 <TR>
 <TD>
 <asp:Label id="lblbatch" runat="server" Text="Academic Year*" SkinID="lbl">
 </asp:Label>
  </TD>
  <TD>
  <asp:TextBox id="txtBatch" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
   <ajaxToolkit:AutoCompleteExtender 
    id="AutoCompleteExtender1" 
    runat="Server" 
    TargetControlID="txtBatch" 
    EnableCaching="true" 
    MinimumPrefixLength="1" 
    ServiceMethod="getBatchExt" 
    ServicePath="TextBoxExt.asmx" 
    FirstRowSelected="true" 
    CompletionInterval="2000" 
    onclientpopulated="HideImage1" 
    onclientpopulating="ShowImage1">
</ajaxToolkit:AutoCompleteExtender> 

<ajaxToolkit:TextBoxWatermarkExtender 
    ID="TextBoxWatermarkExtender2" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtBatch"
    SkinID="watermark" >
</ajaxToolkit:TextBoxWatermarkExtender>
   </TD>
   </TR>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Teaching Materials" Width="126px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="cmbAsset" runat="server" DataValueField="AssetDet_Id" DataTextField="AssetName"
                   SkinID="ddl" TabIndex="4" Width="92px" AutoPostBack="True">
                </asp:DropDownList></td>
         </tr>
         <tr>
            <td>
                <asp:Label ID="lblTtlQty" runat="server" Text="TotalQty" SkinID="lbl"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtTotlQty" runat="server" SkinID="txt"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="UsageDate" SkinID="lbl" Width="76px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtUsageDate" runat="server" SkinID="txt"></asp:TextBox></td>
        </tr>
        <tr>   
            <td>
                <asp:Label ID="lblavailableQty" runat="server" Text="Available Qty" Width="94px" SkinID="lbl"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtQuantity" runat="server"  SkinID="txt" ReadOnly="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Used Qty" Width="71px"></asp:Label></td>
            <td style="height: 26px">
                <asp:TextBox ID="txtusedqty" runat="server" AutoCompleteType="Disabled" MaxLength="20"
                    SkinID="txt" TabIndex="11" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtusedqty" ErrorMessage="RequiredFieldValidator" ValidationGroup="save"
                    >*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Remarks" runat="server" SkinID="lbl" Text="Remarks"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" AutoCompleteType="Disabled" MaxLength="20"
                    SkinID="txt" TabIndex="10"></asp:TextBox><asp:Label ID="lblError" runat="server" SkinID="lbl" Visible="False" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px">
                <asp:TextBox ID="txtAsstID" runat="server" Visible="False"></asp:TextBox>
                
                
                
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                TargetControlID="txtusedqty" FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-">
                </ajaxToolkit:FilteredTextBoxExtender>
                <ajaxToolkit:CalendarExtender ID="TextBox21" TargetControlID="txtUsageDate" runat="server" Format="dd-MMM-yyyy">
                </ajaxToolkit:CalendarExtender>
                </td>
               
        </tr>
        <tr>
            <td colspan="2" class="btnTd">
                <asp:Button ID="btnSave" runat="server" SkinID="btn" TabIndex="20" Text="SAVE" ValidationGroup="save" OnClientClick="return Validate();" CausesValidation = "true" CssClass="btnStyle" />
                <asp:Button ID="btnDetails" runat="server" SkinID="btn" TabIndex="21" Text="DETAILS" ValidationGroup=" " CssClass="btnStyle" />
                <!--<asp:Button ID="btnrecover" runat="server" SkinID="btn" Text="RECOVER" CssClass="btnStyle" />-->
                <asp:Button ID="btnreport" runat="server" SkinID="btn" Text="REPORT" CssClass="btnStyle" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hfAssetUsageID" runat="server" />
            </td>
       
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td colspan="2"><center><div class="errMgs"><asp:Label ID="msginfo" runat="server"></asp:Label></div></center></td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td colspan="2" >
                 <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <asp:GridView ID="GVAsstUsage" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Asset_Usage_Id" SkinID="Gridview" Visible="False" EmptyDataText="There are no records to display."
                        Height="1px" Width="298px" PageSize="100">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">                             
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teaching Materials">
                                <ItemTemplate>
                                    <asp:HiddenField ID="AUID" runat="server" Value='<%#Bind("Asset_Usage_Id")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="Ins_ID" runat="server" Value='<%#Bind("Institute_Id")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="Brn_ID" runat="server" Value='<%#Bind("Branch_Id")%>'></asp:HiddenField>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("AssetName") %>' Width="75px"></asp:Label>
                                </ItemTemplate>                             
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Usage Date">
                            <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("UsageDate","{0:dd-MMM-yy}") %>' Width="75px"></asp:Label>
                            </ItemTemplate>                            
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Used Quantity">
                                <ItemTemplate>
                                    <asp:HiddenField ID="AssetDet_ID" runat="server" Value='<%#Bind("Asset_Det_Id")%>'></asp:HiddenField>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UsedQuantity") %>' Width="75px"></asp:Label>
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:HiddenField ID="Asset_Id" runat="server" Value='<%#Bind("Asset_Id")%>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="DiffQuantity" runat="server" Value='<%#Bind("DiffQuantity")%>'>
                                    </asp:HiddenField>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Remarks") %>' Width="75px"></asp:Label>
                                </ItemTemplate>
                             
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
           </td>
        </tr>      
        <tr>
            <td colspan="2">
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
                &nbsp;
            </td>
        </tr>
    </table>


</form>
</body>
</html>
