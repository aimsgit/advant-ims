<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm16a.aspx.vb"
    Inherits="frm16a" Title="Form 16A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Form 16A</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">
function ShowImage()
{
GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));

 }
function HideImage()
{
 GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
}    
    
    
   function Valid(){
   var msg;
     msg=FeesFieldRestrictDecimal(document.getElementById("<%=txtFormID.ClientID%>"),'Form ID');
     if(msg!="") return msg;         
     msg=Field30( document.getElementById("<%=txtNatureofpayment.ClientID%>"  )  ,'Nature of payment');                  
     if(msg!="") return msg;
     msg=Duration(document.getElementById("<%=txtDuration.ClientID%>" )  ,'Duration');      
     if(msg!="") return msg;
     msg=FeesField(document.getElementById("<%=txtTaxableamount.ClientID%>" )   ,'Taxable amount');  
     if(msg!="") return msg;
     msg = ValidateDate(document.getElementById("<%=txtDeductiondate.ClientID%>" )  ,'Deduction date');      
     if(msg!="") return msg;
     msg=FeesField(document.getElementById("<%=txtTDS.ClientID%>"),'TDS');   
     if(msg!="") return msg;
     msg=FeesField(document.getElementById("<%=txtSurcharges.ClientID%>")  ,'Surcharges');      
     if(msg!="") return msg;
     msg=FeesField(document.getElementById("<%=txtEducationcess.ClientID%>")  ,'Educationcess');      
     if(msg!="") return msg;
     msg=Field30(document.getElementById("<%=txtPaymentdetails.ClientID%>")   ,'Payment Details');
     if(msg!="") return msg;    
     msg=FeesFieldRestrictDecimal(document.getElementById("<%=txtBSR.ClientID%>")   ,'BSR Code');      
     if(msg!="") return msg;
     msg=ValidateDate(document.getElementById("<%=txtPaymentdate.ClientID%>")  ,'Payment date');       
     if(msg!="") return msg;
     msg=FeesFieldRestrictDecimal(document.getElementById("<%=txtPayIdentificationno.ClientID%>")  ,'Pay Identication No');       
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
 function ValidOK(){
   var msg;
     msg=AutoCompleteExtender(document.getElementById("<%=txtEmp.ClientID%>"),'Emp Name');
     if(msg!="") return msg;         
     msg=validateYearField( document.getElementById("<%=txtFortheperiod.ClientID%>"  )  ,'For the period');                  
     if(msg!="") return msg; 
     return true;
   }   
   
  function Validate_OK(){

  var msg=ValidOK();
  
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
  
  
  function Validgrid(){
   var gridvalue = document.getElementById("<%=gv16a.ClientID%>");
        var Inputs = gridvalue.getElementsByTagName("input");
        msg=FeesFieldRestrictDecimal(document.getElementById(Inputs[2].id),'Form ID');
        if(msg!="") return msg;
        msg=Field30(document.getElementById(Inputs[3].id),'Nature Of Payment');
        if(msg!="") return msg;
        msg=Duration(document.getElementById(Inputs[4].id),'Duration');
        if(msg!="") return msg;
        msg=FeesField(document.getElementById(Inputs[5].id),'Taxable amount');
        if(msg!="") return msg;
        msg=ValidateDate(document.getElementById(Inputs[6].id),'Deduction date');
        if(msg!="") return msg;
        msg=FeesField(document.getElementById(Inputs[7].id),'TDS');
        if(msg!="") return msg;
        msg=FeesField(document.getElementById(Inputs[8].id),'Surcharges');
        if(msg!="") return msg;
        msg=FeesField(document.getElementById(Inputs[9].id),'Educationcess');
        if(msg!="") return msg;
          msg=FeesField(document.getElementById(Inputs[10].id),'Tax Amount');
        if(msg!="") return msg;
        msg=Field30(document.getElementById(Inputs[11].id),'Payment Details');
        if(msg!="") return msg;
        msg=FeesFieldRestrictDecimal(document.getElementById(Inputs[12].id),'BSR Code');
        if(msg!="") return msg;
        msg=ValidateDate(document.getElementById(Inputs[13].id),'Payment date');
        if(msg!="") return msg;
        msg=FeesFieldRestrictDecimal(document.getElementById(Inputs[14].id),'Pay Identication No');
        if(msg!="") return msg;
        msg=validateYearField(document.getElementById(Inputs[15].id),'For the period');
        if(msg!="") return msg;
        
        return true;
   } 
 function ValidateGrid(){

  var msg=Validgrid();
  
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
    </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
<DIV><CENTER><H1 class="headingTxt">FORM 16A </H1></CENTER><CENTER><TABLE class="custTable"><TBODY><TR><TD><asp:Label id="lblEmployee" runat="server" Text="Employee*" SkinID="lbl"></asp:Label></TD>
<TD>
<asp:TextBox id="txtEmp" runat="server" AutoPostBack="True"></asp:TextBox> 
<ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender2" runat="Server" 
    TargetControlID="txtEmp" 
    ServicePath="TextBoxExt.asmx" 
    ServiceMethod="getEmpExt" 
    onclientpopulating="ShowImage" 
    onclientpopulated="HideImage" 
    MinimumPrefixLength="3" 
    CompletionInterval="1000" 
    FirstRowSelected="true" 
    EnableCaching="true">
</ajaxToolkit:AutoCompleteExtender> 

<ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1"
     watermarkText="Type first 3 characters" 
     runat="server" 
     TargetControlID="txtEmp"
     skinid="watermark" >
</ajaxToolkit:TextBoxWatermarkExtender>
 </TD></TR>
 <TR>
 <TD>
 <asp:Label id="lblFortheperiod" runat="server" Text="For The Period*" SkinID="lbl"></asp:Label></TD><TD><asp:TextBox id="txtFortheperiod" tabIndex=2 runat="server" SkinID="txt" ToolTip="Example : Type the period like 2006-2007"></asp:TextBox></TD></TR>
 
 
 <TR><TD class="btnTd" colSpan=2><asp:Button id="btnOK" tabIndex=3 runat="server" Text="OK" CausesValidation="true" SkinID="btn" ToolTip="Click here to see the options." CssClass="btnStyle" OnClientClick="return Validate_OK();"></asp:Button> <asp:Button id="btnAdd" tabIndex=4 runat="server" Text="NEW" SkinID="btn" ToolTip="Click here to add a new record." ForeColor="Black" CssClass="btnStyle"></asp:Button> <asp:Button id="btnPreview" tabIndex=20 runat="server" Text="REPORT" SkinID="btn" ToolTip="Click here to see the 16A report for this employee." CssClass="btnStyle"></asp:Button> <asp:Button id="btnCancel" tabIndex=21 runat="server" Text="CANCEL" SkinID="btn" ToolTip="Click here to go back." CssClass="btnStyle"></asp:Button> </TD></TR>
 <tr><td colspan="2">&nbsp;</td></tr>
 <tr><td colspan="2">
        <center><div class="errMgs"><asp:Label id="msginfo" runat="server" Font-Bold="False"></asp:Label><asp:Label id="Label1" runat="server" Font-Bold="True"></asp:Label></div></center>
 </td></tr>
 <tr><td colspan="2">&nbsp;</td></tr>
 </TBODY></TABLE></CENTER><CENTER><asp:Panel id="PnlAddrecord" runat="server" ScrollBars="None">
 
                <table class="custTable">
                    <tr>
                        <td>
                            <asp:Label ID="lblFormID" runat="server" SkinID="lbl" Text="Form ID*"></asp:Label><span
                                style="color: #ff3333"></span></td>
                        <td>
                            <asp:TextBox ID="txtFormID" SkinID="txt" runat="server" TabIndex="5"></asp:TextBox></td>
                     </tr>
                     <tr>   
                        <td>
                            <asp:Label ID="lblNatureofpayment" runat="server" SkinID="lbl" Text="Nature of Payment*"
                                Width="132px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNatureofpayment" SkinID="txt" runat="server" TabIndex="12"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDuration" runat="server" SkinID="lbl" Text="Duration*"></asp:Label><span
                                style="color: #ff3333"></span></td>
                        <td>
                            <asp:TextBox ID="txtDuration" SkinID="txt" runat="server" TabIndex="6"></asp:TextBox></td>
                      </tr>
                      <tr> 
                        <td>
                            <asp:Label ID="lblTaxableamount" runat="server" SkinID="lbl" Text="Taxable Amount*"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTaxableamount" SkinID="txt" runat="server" TabIndex="13"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDeductiondate" runat="server" SkinID="lbl" Text="Deduction Date*"
                                Width="119px"></asp:Label><span style="color: #ff3333"></span></td>
                        <td>
                            <asp:TextBox ID="txtDeductiondate" SkinID="txt" runat="server" TabIndex="7"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td>
                            <asp:Label ID="lblTDS" runat="server" SkinID="lbl" Text="TDS*"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtTDS" SkinID="txt" runat="server" TabIndex="14"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSurcharges" runat="server" SkinID="lbl" Text="Surcharges*"></asp:Label><span
                                style="color: #ff3333"></span></td>
                        <td>
                            <asp:TextBox ID="txtSurcharges" SkinID="txt" runat="server" TabIndex="8"></asp:TextBox></td>
                     </tr>
                     <tr> 
                        <td>
                            <asp:Label ID="lblEducationcess" runat="server" SkinID="lbl" Text="Education Cess*"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEducationcess" SkinID="txt" runat="server" TabIndex="15"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTaxamt" runat="server" SkinID="lbl" Text="Tax Amount*"></asp:Label><span
                                style="color: #ff3333"></span></td>
                        <td>
                            <asp:TextBox ID="txttaxamt" SkinID="txt" runat="server" TabIndex="9"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td>
                            <asp:Label ID="lblPaymentdetails" runat="server" SkinID="lbl" Text="Payment Details*"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPaymentdetails" SkinID="txt" runat="server" TabIndex="16"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBSR" runat="server" SkinID="lbl" Text="BSR Code of Bank*"></asp:Label><span
                                style="color: #ff3333"></span></td>
                        <td>
                            <asp:TextBox ID="txtBSR" SkinID="txt" runat="server" TabIndex="10"></asp:TextBox></td>
                      </tr>
                      <tr>  
                        <td>
                            <asp:Label ID="lblPaymentdate" runat="server" SkinID="lbl" Text="Payment Date*"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPaymentdate" SkinID="txt" runat="server" TabIndex="17"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPayIdentificationno" runat="server" SkinID="lbl" Text="Pay Ident. No*"
                               ></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPayIdentificationno" SkinID="txt" runat="server" TabIndex="11"></asp:TextBox></td>
                        
                    </tr>
                    <tr>
                        
                        <td colspan="2" class="btnTd">
                            <asp:Button ID="btnAddrecord" OnClientClick="return Validate();" runat="server" Text="SAVE"
                                SkinID="btn" Width="130px" TabIndex="18" ToolTip="Click here to save the data." CausesValidation ="true" />
                            <asp:Button ID="btnCancl" runat="server" SkinID="btn" Text="CANCEL" Width="112px"
                                TabIndex="19" ToolTip="Click here to cancel." /></td>
                    </tr>
                </table>                
            </asp:Panel> </CENTER>
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
            <asp:GridView id="gv16a" runat="server" SkinID="GridView" PageSize="100" AllowPaging="True" EmptyDataText="No records to Display." DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" OnSelectedIndexChanged="gv16a_SelectedIndexChanged"><Columns>
<asp:TemplateField><EditItemTemplate>
<asp:LinkButton runat="server" Text="Update" CommandName="Update" CausesValidation="True" id="LinkButton1" OnClientClick = "return ValidateGrid();"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" id="LinkButton2"></asp:LinkButton>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" id="LinkButton1"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="True"/>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
                            <asp:HiddenField ID="lblId" runat="server" Value='<%# Bind("ID") %>'></asp:HiddenField>
                        <asp:HiddenField ID="lblEmpId" runat="server" Value='<%# Bind("EmpID") %>'></asp:HiddenField>
</EditItemTemplate>
<ItemTemplate>
                            <asp:HiddenField ID="lblId" runat="server" Value='<%# Bind("ID") %>'></asp:HiddenField>
                         <asp:HiddenField ID="lblEmpId" runat="server" Value='<%# Bind("EmpID") %>'></asp:HiddenField>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Form ID" SortExpression="FormID"><EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" width = "50" Text='<%# Bind("FormID") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("FormID") %>' ></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Employee Name" SortExpression="FormID"><ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%# GetEmpName(Convert.ToInt64(Eval("EmpId"))) %>' ></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nature Of Payment"><EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" width = "50" Text='<%# Bind("NatureOfPayment") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("NatureOfPayment") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Duration"><EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" width = "50" Text='<%# Bind("Duration") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Taxable Amount"><EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" width = "50" Text='<%# Bind("TaxableAmt") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("TaxableAmt") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Deduction Date"><EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" width = "50" Text='<%# Bind("DeductionDate","{0:dd-MMM-yyyy}")  %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("DeductionDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TDS"><EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" width = "50" Text='<%# Bind("TDS") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("TDS") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Surcharges"><EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" width = "50" Text='<%# Bind("Surcharges") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Surcharges") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Education Cess"><EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" width = "50" Text='<%# Bind("EducationCess") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("EducationCess") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tax Amount"><EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" width = "50" Text='<%# Bind("TaxAmt") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("TaxAmt") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Payment Detalis"><EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" width = "50" Text='<%# Bind("PaymentDtls") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("PaymentDtls") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="BSR Code"><EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" width = "50" Text='<%# Bind("BSRCode") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("BSRCode") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Payment Date"><EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" width = "50" Text='<%# Bind("PaymentDate","{0:dd-MMM-yyyy}") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Text='<%# Bind("PaymentDate","{0:dd-MMM-yyyy}")%>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Pay Identification No"><EditItemTemplate>
                            <asp:TextBox ID="TextBox13" runat="server" width = "50" Text='<%# Bind("PayIdentificationNo") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("PayIdentificationNo") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="For the period"><EditItemTemplate>
                            <asp:TextBox ID="txtperiod" runat="server" width = "50" Text='<%# Bind("period") %>'></asp:TextBox>
                        
</EditItemTemplate>
<ItemTemplate>
                            <asp:Label ID="Label15" runat="server" Text='<%# Bind("period") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> 
</asp:Panel> <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" SkinID="Calendar" TargetControlID="txtDeductiondate" Format="dd-MMM-yyyy" PopupPosition="TopRight">
            </ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" SkinID="Calendar" TargetControlID="txtPaymentdate" Format="dd-MMM-yyyy" PopupPosition="TopRight">
            </ajaxToolkit:CalendarExtender>
            <asp:ObjectDataSource id="ObjectDataSource1" runat="server" DeleteMethod="Del16A" TypeName="BL16a" UpdateMethod="Update16a">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="duration" Type="String" />                
                </SelectParameters>
                             <UpdateParameters>
                    <%--
            <asp:Parameter Name="formid" Type="Int32" />
            <asp:Parameter Name="natureofpayment" Type="String" />
            <asp:Parameter Name="duration" Type="String" />
            <asp:Parameter Name="taxableamt" Type="Int32" />
            <asp:Parameter Name="deddate" Type="DateTime" />
            <asp:Parameter Name="tds" Type="Double" />
            <asp:Parameter Name="surcharges" Type="Double" />
            <asp:Parameter Name="educationcess" Type="Double" />
            <asp:Parameter Name="taxamt" Type="Double" />
            <asp:Parameter Name="paymentdtls" Type="String" />
            <asp:Parameter Name="BSR" Type="String" />
            <asp:Parameter Name="paymentdate" Type="DateTime" />
            <asp:Parameter Name="paymentidentificationno" Type="Int32" />--%>
                    <%--  <asp:Parameter Name="EmpID" Type="Int32" />
            <asp:Parameter Name="FormID" Type="Int32" />
            <asp:Parameter Name="NatureOfPayment" Type="String" />
            <asp:Parameter Name="Duration" Type="String" />
            <asp:Parameter Name="TaxableAmt" Type="Int32" />
            <asp:Parameter Name="DeductionDate" Type="DateTime" />
            <asp:Parameter Name="TDS" Type="Double" />
            <asp:Parameter Name="Surcharges" Type="Double" />
            <asp:Parameter Name="EducationCess" Type="Double" />
            <asp:Parameter Name="TaxAmt" Type="Double" />
            <asp:Parameter Name="PaymentDtls" Type="String" />
            <asp:Parameter Name="BSRCode" Type="String" />
            <asp:Parameter Name="PaymentDate" Type="DateTime" />
            <asp:Parameter Name="PayIdentificationNo" Type="Int32" />--%>
                </UpdateParameters>
            </asp:ObjectDataSource> </DIV>
</contenttemplate>
    <triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAddrecord" EventName="Click"></asp:AsyncPostBackTrigger>
    </triggers>
</asp:UpdatePanel>


</form>
</body>
</html>