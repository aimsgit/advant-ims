<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IdentityCard.aspx.vb"
    Inherits="IdentityCard" Title="Identity Card Issue" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Identity Card Issue</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px" onload="return disableText();">

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


   function Valid(){
   var msg;
     msg=CodeField(document.getElementById("<%=txtreceiptNo.ClientID%>"),'Receipt No');  
     if(msg!="") return msg;  
     msg=ValidateDate(document.getElementById("<%=txtrecptdate.ClientID%>"),'Receipt date');
     if(msg!="") return msg;         
    msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
  if(msg!="") return msg;
  msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
   if(msg!="") return msg;
     msg=FeesField(document.getElementById("<%=txtamount.ClientID%>"),'Amount');      
     if(msg!="") return msg;
        msg=NameField100(document.getElementById("<%=txtissdmonth.ClientID%>"),'Month');                  
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
    </script>

    <script type="text/javascript" language="javascript">  
  function ValidOK(){
   var msg;
    
     msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID%>"),'Course');                  
     if(msg!="") return msg;
     msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID%>"),'Academic Year');                  
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
  
  

    </script>

    <%--</head>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <%-- <asp:UpdatePanel id="UpdatePanel1" runat="server"> <contenttemplate>--%>
    <div>
        <center>
            <h1 class="headingTxt">
                IDENTITY CARD ISSUE
            </h1>
        </center>
        <center>
            <table class="custTable">
                <tbody>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="message" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Course *" SkinID="lbl"></asp:Label>
                        </td>
                        <td colspan="3">
                            <%--      
<asp:DropDownList id="ddlCourse" tabIndex=3 runat="server" SkinID="ddlL" DataValueField="Course_ID" DataTextField="CourseName" AutoPostBack="True">
</asp:DropDownList>--%>
                            <asp:TextBox ID="txtCourse" runat="server" Width="296px" AutoPostBack="True"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtCourse"
                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="getCourseExt" ServicePath="TextBoxExt.asmx"
                                FirstRowSelected="true" CompletionInterval="2000" OnClientPopulated="HideImage"
                                OnClientPopulating="ShowImage">
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Academic Year *" SkinID="lbl"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtBatch" runat="server" Width="184px" AutoPostBack="True"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtBatch"
                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="getBatchExt" ServicePath="TextBoxExt.asmx"
                                FirstRowSelected="true" CompletionInterval="2000" OnClientPopulated="HideImage1"
                                OnClientPopulating="ShowImage1">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                WatermarkText="Type first few characters" TargetControlID="txtCourse" SkinID="watermark">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                WatermarkText="Type first few characters" TargetControlID="txtBatch" SkinID="watermark">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblreceiptNo" runat="server" Text="Receipt No*" SkinID="lbl" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtreceiptNo" TabIndex="5" runat="server" SkinID="txt" Visible="False"
                                AutoCompleteType="disabled"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblrecptdate" runat="server" Width="97px" Text="Receipt Date*" SkinID="lbl"
                                Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtrecptdate" TabIndex="6" runat="server" Width="112px" Height="16px"
                                SkinID="txt" Visible="False" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblissdmonth" runat="server" Text="Issued Month*" SkinID="lbl" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtissdmonth" TabIndex="7" runat="server" Width="112px" Height="16px"
                                SkinID="txt" Visible="False" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblamount" runat="server" Width="72px" Height="16px" Text="Amount*"
                                SkinID="lbl" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtamount" TabIndex="8" runat="server" Width="112px" Height="16px"
                                SkinID="txt" Visible="False" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" SkinID="Calendar"
                                TargetControlID="txtrecptdate" Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <asp:Label ID="msginfo" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd" colspan="4">
                            <asp:Button ID="btnView" TabIndex="9" runat="server" Width="84px" Text="VIEW" CausesValidation="true"
                                SkinID="btn" CssClass="btnStyle"></asp:Button>
                            <asp:Button ID="Btnsave" TabIndex="10" runat="server" Width="96px" Text="SAVE" CausesValidation="true"
                                SkinID="btn" Visible="false" CssClass="btnStyle" OnClientClick=" return Validate();"
                                ValidationGroup="save"></asp:Button>
                            <asp:Button ID="btnReport" TabIndex="11" runat="server" Width="84px" Text="REPORT"
                                CausesValidation="false" SkinID="btn" CssClass="btnStyle" ValidationGroup="save">
                            </asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
        <center>
            <table>
                <tbody>
                    <tr>
                        <td colspan="4">
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" DataKeyNames="StdId"
                                    EmptyDataText="No records to Display." AllowPaging="true" 
                                    AutoGenerateColumns="False" PageSize="100">
                                    <Columns>
                                        <asp:TemplateField HeaderText="StudentCode" SortExpression="StudentCode">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="StdId" runat="server" Value='<%# Bind("StdId") %>' />
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StudentName" SortExpression="StudentName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Issued" SortExpression="Issued">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkIssued" runat="server" Checked='<%# Bind("IDCard_Issue") %>'
                                                    Text='<%# Bind("IDCard_Issue") %>' Enabled="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
        <asp:ObjectDataSource ID="ObjInstitute" runat="server" TypeName="InstituteManager"
            SelectMethod="GetComboUser" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjBranch" runat="server" TypeName="BranchManager" SelectMethod="GetBranchCombo"
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:ObjectDataSource ID="OdsIdentity" runat="server" TypeName="GlobalDataSetTableAdapters.IdentityCardTableAdapter"
            SelectMethod="GetData" OldValuesParameterFormatString="original_{0}" InsertMethod="Insert"
            DeleteMethod="Delete">
            <DeleteParameters>
                <asp:Parameter Name="Original_I_No" Type="Int32" />
                <asp:Parameter Name="Original_CourseId" Type="Int32" />
                <asp:Parameter Name="Original_BatchNo" Type="Int32" />
                <asp:Parameter Name="Original_InstituteId" Type="Int32" />
                <asp:Parameter Name="Original_BranchId" Type="Int32" />
                <asp:Parameter Name="Original_ReceiptNo" Type="Int32" />
                <asp:Parameter Name="Original_IssuedMonth" Type="String" />
                <asp:Parameter Name="Original_Amount" Type="Int32" />
                <asp:Parameter Name="Original_ReceiptDate" Type="DateTime" />
                <asp:Parameter Name="Original_StdId" Type="Int32" />
                <asp:Parameter Name="Original_Issued" Type="Boolean" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CourseId" Type="Int32" />
                <asp:Parameter Name="BatchNo" Type="Int32" />
                <asp:Parameter Name="InstituteId" Type="Int32" />
                <asp:Parameter Name="BranchId" Type="Int32" />
                <asp:Parameter Name="ReceiptNo" Type="Int32" />
                <asp:Parameter Name="IssuedMonth" Type="String" />
                <asp:Parameter Name="Amount" Type="Int32" />
                <asp:Parameter Name="ReceiptDate" Type="DateTime" />
                <asp:Parameter Name="StdId" Type="Int32" />
                <asp:Parameter Name="Issued" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </div>

</form>
</body>
</html>