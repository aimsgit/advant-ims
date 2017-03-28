<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCertificateDetls.aspx.vb"
    Inherits="frmCertificateDetls" Title="Student Certificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Certificate</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script language="JavaScript" type="text/javascript">
function Valid()
{
    var msg;  
    msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
  if(msg!="") return msg;
  msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
   if(msg!="") return msg;
    msg=AutoCompleteExtender(document.getElementById("<%=txtStdCode.ClientID %>"),'Student Code');
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
function ShowImage2()
{
GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

 }
function HideImage2()
{
 GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
}  
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />


<center>
      <asp:UpdatePanel id="UpdatePanel1" runat="server"> <contenttemplate>
    <div>
        <center>
            <h1 class="headingTxt">
                CERTIFICATE DETAILS
            </h1>
        </center>
        <center>
            <table class="custTable">
                <tr>
                    <td>
                        <asp:Label ID="lblCourse" runat="server" Height="16px" Text="Course*" Width="72px"
                            SkinID="lbl"></asp:Label></td>
                    <td>
<asp:TextBox id="txtCourse" runat="server" Width="295px" AutoPostBack="True"></asp:TextBox>

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
                        <asp:Label ID="Label1" runat="server" Height="16px" Text="Academic Year*" Width="72px" SkinID="lbl"></asp:Label></td>
                    <td>
 <asp:TextBox id="txtBatch" runat="server" AutoPostBack="True" skinID="txt"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender 
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
                    <td>
                        <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Student Code*" Width="91px"></asp:Label></td>
                    <td>
                        
<asp:TextBox id="txtStdCode" runat="server" AutoPostBack="True" skinID="txt">
</asp:TextBox>
 <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender3" 
 runat="Server" 
 ServicePath="TextBoxExt.asmx" 
 ServiceMethod="getStudentExt" 
 MinimumPrefixLength="1" 
 EnableCaching="True" 
 TargetControlID="txtStdCode"
     FirstRowSelected="true" 
    CompletionInterval="2000" 
    onclientpopulated="HideImage2" 
    onclientpopulating="ShowImage2">
</ajaxToolkit:AutoCompleteExtender> 
                        
                        </td>
                   
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
               
                <tr>
                    <td colspan="2" class="btnTd">
                        <asp:Button ID="btnCertificate" runat="server" SkinID="btn" Text="REPORT" Width="148px" TabIndex="6" Font-Names="Arial" CssClass="btnStyle"  /></td>
                   
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" >
                         <center><div class="errMgs"> <asp:Label ID="msginfo" runat="server" Visible="true" TabIndex="-1"></asp:Label></div></center></td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="CourseCoursePlannerCombo" TypeName="CourseManager">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="c" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </center>
    </div>
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
    SkinID="watermark" ></ajaxToolkit:TextBoxWatermarkExtender>
    <ajaxToolkit:TextBoxWatermarkExtender 
    ID="TextBoxWatermarkExtender3" 
    runat="server"     
    WatermarkText="Type first few characters" 
    TargetControlID="txtStdCode"
    SkinID="watermark" >
</ajaxToolkit:TextBoxWatermarkExtender>
    </contenttemplate>
    </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

