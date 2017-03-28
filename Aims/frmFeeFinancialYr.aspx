<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmFeeFinancialYr.aspx.vb" Inherits="frmFeeFinancialYr" title="Untitled Page" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<center> 

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
</script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
    <div>
        <center>
            <h1 tabindex="-1" unselectable="on" class="headingTxt">
                FEE DETAILS FINANCIAL YEARWISE </h1>
        </center>
        <center>
            <table class="custTable">
                <tr>
                    <td>
                        <asp:Label ID="lblCourse" runat="server" Text="Course" 
                            SkinID="lbl"></asp:Label></td>
                    <td colspan="3"> 
 <asp:TextBox id="txtCourse" runat="server" Width="295px" AutoPostBack="True" TabIndex="3"></asp:TextBox>

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
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Academic Year" SkinID="lbl"></asp:Label></td>
                    <td colspan="3">
                    
                             
                        
<asp:TextBox id="txtBatch" runat="server" AutoPostBack="True" TabIndex="4">
</asp:TextBox> <ajaxToolkit:AutoCompleteExtender 
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
                <tr><td colspan="4"><asp:Label id="msginfo" runat="server" forecolor="red" text=""></asp:Label></td></tr>
                <tr>
                    <td colspan="4" class="btnTd">
                        <asp:Button ID="btnReport" runat="server" Text="REPORT" SkinID="btn"
                            TabIndex="6" CssClass="btnStyle" onclientclick="return ValidateReport();" /></td>
                    <td colspan="1">
                    </td>
                </tr>
                </table>
                </center>
                <center>
                <table>
                <tr>
                    <td colspan="2">
                        <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="CourseCoursePlannerCombo" TypeName="CourseManager">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="BatchCombo" TypeName="BatchB">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    
                </tr>
            </table>
        </center><ajaxToolkit:TextBoxWatermarkExtender 
    ID="TextBoxWatermarkExtender1" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtCourse" 
    SkinID="watermark">
</ajaxToolkit:TextBoxWatermarkExtender>

<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtBatch"
    SkinID="watermark" >
</ajaxToolkit:TextBoxWatermarkExtender>
    </div>
    <center>
         </contenttemplate>
         </asp:UpdatePanel>
         </center>


</form>
</body>
</html>