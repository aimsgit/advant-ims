<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentEligible.aspx.vb"
    Inherits="frmStudentEligible" Title="Student Eligible Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Eligible Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
     msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID%>"),'Course');  
     if(msg!="") return msg;  
     msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID%>"),'Academic Year');
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


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<center>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<div>
<center>
 <h1 tabindex="-1" class="headingTxt">
                STUDENT ELIGIBILITY REPORT</h1>
</center>
<center>
    <table class="custTable">      
        <tr>
            <td>
                <asp:Label ID="lblCourse" runat="server" Text="Course" 
                    SkinID="lbl"></asp:Label></td>
<td colspan="2">
<%--                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataTextField="CourseName"
                    DataValueField="Course_ID" SkinID="ddlL" TabIndex="4">
                </asp:DropDownList>--%>
                
<asp:TextBox id="txtCourse" runat="server" AutoPostBack="True" width="296px"></asp:TextBox>
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

</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="lblBatch" runat="server" Text="Academic Year" SkinID="lbl"></asp:Label></td>
            <td >
               <%-- <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataTextField="Batch_No"
                    DataValueField="ID" SkinID="ddl"  
                    TabIndex="5">
                </asp:DropDownList>--%>
<asp:TextBox id="txtBatch" runat="server" AutoPostBack="True"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender 
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

                
</td>
          
        </tr>
       
        <tr>
            <td colspan="2" class="btnTd">
                <asp:Button ID="btnReport" runat="server" Text="REPORT" OnClick="btnReport_Click"
                    SkinID="btn" TabIndex="8" CssClass="btnStyle"/></td>            
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
         </tr>
         <tr>
         
        <td colspan = "2">
                <center><div class="errMgs"><asp:Label ID="msginfo" runat="server" Text="" ></asp:Label></div></center>
        </td>
        
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
         </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:ObjectDataSource ID="ObjInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
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
                <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="CourseCoursePlannerCombo" TypeName="CourseManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="c" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                &nbsp;&nbsp;
            </td>
            
        </tr>
    </table>
    </center>
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
 </div>
 </contenttemplate>
 </asp:UpdatePanel>
 </center>

</form>
</body>
</html>

