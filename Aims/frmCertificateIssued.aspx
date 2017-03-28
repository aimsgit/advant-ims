<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCertificateIssued.aspx.vb"
    Inherits="frmCertificareIssued" Title="Certificate Issued Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Certificate Issued Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">  
   function ValidReport(){
   var msg;
    msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
  if(msg!="") return msg;
  msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
   if(msg!="") return msg;
   return true;
   }
   function ValidateReport(){
  
          var msg=ValidReport();
          if(msg!=true)
          { 
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
          }
           return true;
 }
    </script>

    <script type="text/javascript" language="javascript">  
   function Valid(){
   var msg;
     msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
  if(msg!="") return msg;
  msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
  if(msg!="") return msg;
   msg=DropDown(document.getElementById("<%=ddlCode.ClientID %>"),'Roll No');
  if(msg!="") return msg;
    msg=ValidateDate(document.getElementById("<%=txtIDate.ClientID %>"),'Issue Date');
  if(msg!="") return msg;
    msg=DropDown(document.getElementById("<%=cmbCertificate.ClientID %>"),'Certificate');
  if(msg!="") return msg;
    msg=FeesFieldRestrictDecimal(document.getElementById("<%=txtno.ClientID %>"),'Certificate No');
  if(msg!="") return msg;
   return true;
   }
   function Validate(){
  
          var msg=Valid();
          if(msg!=true)
          { 
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
          }
           return true;
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


    <center>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<DIV>
<CENTER>
<H1 class="headingTxt">CERTIFICATE ISSUED DETAILS</H1>
</CENTER>
<CENTER>
<TABLE class="custTable">
<TBODY>

 <TR>
 <TD>
 <asp:Label id="lblcourse" runat="server" Width="53px" Text="Course*" SkinID="lbl" __designer:wfdid="w36"> </asp:Label> </TD>
 
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

 </TD>
 <TD colSpan=1>
 </TD>
 </TR>
 <TR>
 <TD>
 <asp:Label id="lblbatch" runat="server" Text="Academic Year*" SkinID="lbl" __designer:wfdid="w38">
 </asp:Label>
  </TD>
  <TD>
  <asp:TextBox id="txtBatch" runat="server" SkinID="txt" AutoPostBack="True" __designer:wfdid="w39"></asp:TextBox>
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
   </TD>
   </TR>
   <TR>
   <TD>
   <asp:Label id="Label4" runat="server" Text="Roll No*" SkinID="lbl" EnableTheming="True" __designer:wfdid="w41"></asp:Label>
   </TD>
   <TD>
   <asp:DropDownList id="ddlCode" tabIndex=5 runat="server" SkinID="ddl" DataValueField="StdId" DataTextField="StdCode" AutoPostBack="true" __designer:wfdid="w42"></asp:DropDownList>
   </TD>
   </TR>
   <TR>
   <TD>
   <asp:Label id="Label6" runat="server" Width="113px" Text="Certificate Name*" SkinID="lbl" __designer:wfdid="w43"></asp:Label>
   </TD>
   <TD>
   <asp:DropDownList id="cmbCertificate" tabIndex=7 runat="server" SkinID="ddl" DataValueField="Certificate_Id" DataTextField="Certificate_Name" DataSourceID="ObjCertificate" AutoPostBack="True" __designer:wfdid="w44"></asp:DropDownList>
   </TD>
   </TR>
   <TR>
   <TD>
   <asp:Label id="lblno" runat="server" Width="112px" Text="Certificate No*" SkinID="lbl" __designer:wfdid="w45"></asp:Label></TD>
   <TD>
   <asp:TextBox id="txtno" tabIndex=8 runat="server" SkinID="txt" AutoCompleteType="Disabled" __designer:wfdid="w46"></asp:TextBox>
   </TD></TR>
   <TR><TD>
   <asp:Label id="Label7" runat="server" Width="73px" Text="Issue Date*" SkinID="lbl" EnableTheming="True" __designer:wfdid="w47"></asp:Label>
   </TD><TD>
   <asp:TextBox id="txtIDate" tabIndex=6 runat="server" SkinID="txt" AutoCompleteType="Disabled" __designer:wfdid="w48"></asp:TextBox><%--<ajaxToolkit:MaskedEditValidator
                    ID="IDate" runat="server" ControlExtender="IssueDate" ControlToValidate="txtIDate"
                    Display="Static" EmptyValueBlurredText="*" EmptyValueMessage="Enter DOB" ErrorMessage="*"
                    InvalidValueBlurredMessage="*" InvalidValueMessage="Enter Correct Format" IsValidEmpty="false"
                    MaximumValueBlurredMessage="*" MaximumValueMessage="Enter Correct Format" MinimumValueBlurredText="*"
                    MinimumValueMessage="Enter Correct Format" SetFocusOnError="True" TabIndex="-1"
                    ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$"></ajaxToolkit:MaskedEditValidator>--%></TD></TR><TR><TD><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="txtno" ValidChars="1234567890/-" FilterMode="ValidChars" FilterType="Numbers" __designer:wfdid="w49">
  </ajaxToolkit:FilteredTextBoxExtender> </TD></TR>
  <TR><TD colspan="2">
  <asp:Label id="msginfo" tabIndex=-1 runat="server" Visible="true" ForeColor="Red" __designer:wfdid="w50">
  </asp:Label> 
  </TD></TR>
  
  <TR><TD class="btnTd" colSpan=3>
  <asp:Button id="btnSave" tabIndex=9 runat="server" Text="SAVE" CausesValidation="true" SkinID="btn" CssClass="btnStyle" OnClientClick="return Validate();" ValidationGroup="Save" __designer:wfdid="w51"></asp:Button> <asp:Button id="btnDetails" tabIndex=10 runat="server" Text="DETAILS"   CausesValidation="False" SkinID="btn" CssClass="btnStyle" __designer:wfdid="w52"></asp:Button> <asp:Button id="btnReport" tabIndex=11 runat="server" Text="REPORT" CausesValidation="true" SkinID="btn" CssClass="btnStyle" ValidationGroup="Save" __designer:wfdid="w53" ></asp:Button>
   <%--<asp:Button id="btnRecover" tabIndex=12 runat="server" Text="RECOVER" CausesValidation="False" SkinID="btn" CssClass="btnStyle" __designer:wfdid="w54"></asp:Button>--%></TD></TR></TBODY></TABLE></CENTER><CENTER><TABLE><TBODY><TR>
        <TD>
  <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
  <asp:GridView id="GVCIssue" runat="server" SkinID="GridView" AllowPaging="True" 
        DataKeyNames="ID" AutoGenerateColumns="False" 
        EmptyDataText="There are no records to display." visible="True" 
        __designer:wfdid="w56" PageSize="100"><Columns>
<asp:TemplateField ShowHeader="False"><EditItemTemplate>
 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
 Text="Update" ValidationGroup="Ed"></asp:LinkButton>
 <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
 Text="Cancel"></asp:LinkButton>
                                        
</EditItemTemplate>
<ItemTemplate>
  <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
   Text="Edit"></asp:LinkButton>
</ItemTemplate>

<ItemStyle Wrap="False" Width="100px"></ItemStyle></asp:TemplateField>
<asp:TemplateField><ItemTemplate>
 <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
  Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        
</ItemTemplate>

<ItemStyle Width="80px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Student Code" SortExpression="StdCode"><EditItemTemplate>
<asp:HiddenField ID="LID" runat="server" Value='<%# Bind("ID") %>' />
<asp:Label ID="TextBox5" runat="server" Text='<%# Bind("StdCode") %>' />
</EditItemTemplate>
<ItemTemplate>
<asp:HiddenField ID="SID" runat="server" Value='<%# Bind("StdId") %>' />
 <asp:Label ID="Label5" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        
</ItemTemplate>

<ItemStyle Wrap="False"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Student Name"><EditItemTemplate>
       <asp:Label ID="LabelS1" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>                                  
</EditItemTemplate>
<ItemTemplate>
 <asp:Label ID="LabelS" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                        
</ItemTemplate>

<ItemStyle Wrap="False"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Certificate Name" SortExpression="Certificate_Id"><EditItemTemplate>
 <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjCertificate"
     DataTextField="Certificate_Name" DataValueField="Certificate_Id" SelectedValue='<%# Bind("Certificate_Id") %>' SkinID="ddl">
 </asp:DropDownList>
                                        
</EditItemTemplate>
<ItemTemplate>
 <asp:Label ID="Label1" runat="server" Text='<%# Bind("Certificate_Name") %>'></asp:Label>
                                        
</ItemTemplate>

<ControlStyle Width="80px"></ControlStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="IssueDate" SortExpression="IssueDate"><EditItemTemplate>
<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("IssueDate","{0:dd-MMM-yyyy}") %>'></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
Format="dd-MMM-yyyy" TargetControlID="textbox3">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:MaskedEditExtender ID="meeDOB" runat="server" TargetControlID="textbox3"
ClearMaskOnLostFocus="false" MaskType="none" Mask="99-LLL-9999" PromptCharacter="_">
</ajaxToolkit:MaskedEditExtender>
                                        
</EditItemTemplate>
<ItemTemplate>
 <asp:Label ID="Label3" runat="server" Text='<%# Bind("IssueDate","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                        
</ItemTemplate>

<ItemStyle Wrap="False"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Certificate No" SortExpression="Certificate No"><EditItemTemplate>
<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Certificate_No") %>'></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4"
ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        
</EditItemTemplate>
<ItemTemplate>
 <asp:Label ID="lblcertifcateno" runat="server" Text='<%# Bind("Certificate_No")%>'></asp:Label>
                                        
</ItemTemplate>

<ItemStyle Wrap="False"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView> 
</asp:Panel>

 </TD>
 </TR>
 <TR>
 <TD>
<asp:ObjectDataSource id="ObjGrid" runat="server" SelectMethod="fillGridViewCertificateDetails" 
UpdateMethod="UpdateCertificateIssued" 
DeleteMethod="DeleteCertificateIssued" 
TypeName="CertificateIssuedB" >

<DeleteParameters>
<asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
</DeleteParameters>
<UpdateParameters>
<asp:Parameter Name="Certificate_Id" Type="Int32"></asp:Parameter>
<asp:Parameter Name="IssueDate" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="Certificate_No" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
</UpdateParameters>
<SelectParameters>
<asp:Parameter Name="ins" ></asp:Parameter>
<asp:Parameter Name="brn"></asp:Parameter>
<asp:Parameter Name="crs" ></asp:Parameter>
<asp:Parameter Name="btch" ></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource>
<ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" SkinID="Calendar" TargetControlID="txtIDate" Format="dd-MMM-yyyy" __designer:wfdid="w58">
</ajaxToolkit:CalendarExtender> 
<ajaxToolkit:MaskedEditExtender id="meeDOB" runat="server" TargetControlID="txtIDate" PromptCharacter="_" Mask="99-LLL-9999" MaskType="none" ClearMaskOnLostFocus="false" __designer:wfdid="w59">
 </ajaxToolkit:MaskedEditExtender> 
<asp:ObjectDataSource id="ObjInstitute" runat="server" SelectMethod="GetComboUser" TypeName="InstituteManager" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w60">
 <SelectParameters>
 <asp:Parameter DefaultValue="0" Name="id" Type="Int64" /></SelectParameters>
</asp:ObjectDataSource>
 <asp:ObjectDataSource id="ObjBranch" runat="server" SelectMethod="GetBranchCombo" TypeName="BranchManager" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w61">
<SelectParameters>
<asp:Parameter DefaultValue="0" Name="i" Type="Int32" /></SelectParameters>
</asp:ObjectDataSource> 
<asp:ObjectDataSource id="ObjCertificate" runat="server" 
SelectMethod="CertificateDetailsCombo" 
TypeName="CertificateIssuedB" 
OldValuesParameterFormatString="original_{0}" __designer:wfdid="w62">
</asp:ObjectDataSource>
 </TD>
 </TR>
 </TBODY>
 </TABLE>
 </CENTER>
 </DIV>
 <ajaxToolkit:TextBoxWatermarkExtender 
    ID="TextBoxWatermarkExtender1" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtCourse" 
    SkinID="watermark">
</ajaxToolkit:TextBoxWatermarkExtender>

<ajaxToolkit:TextBoxWatermarkExtender 
    ID="TextBoxWatermarkExtender2" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtBatch"
    SkinID="watermark" >
</ajaxToolkit:TextBoxWatermarkExtender>
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

