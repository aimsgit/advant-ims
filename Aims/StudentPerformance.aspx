<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentPerformance.aspx.vb"
    Inherits="StudentPerformance" Title="Student Result Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Result Details</title>
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
<script language="JavaScript" type="text/javascript">
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

function Valid()
{
    var msg; 
    msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
   if(msg!="") return msg;
    msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
   if(msg!="") return msg;
    msg=DropDown(document.getElementById("<%=ddlSubject.ClientID%>"),'Subject');
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
</script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />


<center>
                 <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<DIV><CENTER><H1 class="headingTxt">STUDENT PERFORMANCE </H1></CENTER><CENTER><TABLE class="custTable"><TBODY>
                   <TR><TD>
                    <asp:Label id="Label6" runat="server" Text="Course*" SkinID="lbl"></asp:Label></TD>
<TD colSpan=3>

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
</TD></TR><TR>
<TD>
<asp:Label id="Label8" runat="server" Text="Academic Year*" SkinID="lbl"></asp:Label>
</TD>
<TD colSpan=3>

<asp:TextBox id="txtBatch" runat="server" AutoPostBack="True" skinID="txt" />
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
 </TR><TR>
 <TD><asp:Label id="Label5" runat="server" Text="Subject*" SkinID="lbl"></asp:Label></TD><TD colSpan=3>
 <asp:DropDownList id="ddlSubject" tabIndex=5 runat="server" SkinID="ddl" DataValueField="Subject_ID" DataTextField="SubjectName">
                </asp:DropDownList></TD></TR>
                
                <TR><td></td>
                <td>
                <asp:Button id="btnReport" tabIndex=9 runat="server" Text="REPORT" SkinID="btn" CssClass="btnStyle" onclientclick="return Validate();"></asp:Button> 
</TD></TR>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                                <tr>
                    <td colspan="4">
                        <center><div class="errMgs">
                            <asp:Label id="msginfo" tabIndex=-1 runat="server" Visible="true"></asp:Label></div></center>
                    </td>
                 </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>

        </TR><TR><TD><asp:ObjectDataSource id="ObjCourse" runat="server" SelectMethod="CourseCoursePlannerCombo" OldValuesParameterFormatString="original_{0}" TypeName="CourseManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="c" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource> </TD></TR></TBODY></TABLE></CENTER>
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
                </DIV>
</contenttemplate>
    </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
