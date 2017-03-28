<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StudentwiseDetail.aspx.vb"
    Inherits="IndStudentResult" Title="Student Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
function ShowImage2()
{
GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

 }
function HideImage2()
{
 GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
}  
function Valid()
{
    var msg;   
    msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"),'Course');
    if(msg!="") return msg;
    msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"),'Academic Year');
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

    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<DIV><CENTER><H1 class="headingTxt">STUDENTWISE DETAILED REPORT </H1></CENTER><CENTER><TABLE class="custTable"><TBODY>
        <TR><TD><asp:Label id="lblCourse" runat="server" Width="72px" Height="16px" Text="Course" SkinID="lbl"></asp:Label></TD><TD><%--                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataTextField="Course"
                            DataValueField="Course_ID" SkinID="ddlL" TabIndex="3">
                        </asp:DropDownList>--%><asp:TextBox id="txtCourse" runat="server" Width="295px" AutoPostBack="True"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender2" runat="Server" onclientpopulating="ShowImage" onclientpopulated="HideImage" CompletionInterval="2000" FirstRowSelected="true" ServicePath="TextBoxExt.asmx" ServiceMethod="getCourseExt" MinimumPrefixLength="1" EnableCaching="true" TargetControlID="txtCourse">
</ajaxToolkit:AutoCompleteExtender> </TD></TR><TR><TD><asp:Label id="Label1" runat="server" Width="72px" Height="16px" Text="Academic Year" SkinID="lbl"></asp:Label></TD><TD><%--                        <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataTextField="Batch_No"
                            DataValueField="ID" SkinID="ddl" TabIndex="4">
                        </asp:DropDownList>--%><asp:TextBox id="txtBatch" runat="server" AutoPostBack="True" skinID="txt"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender1" runat="Server" onclientpopulating="ShowImage1" onclientpopulated="HideImage1" CompletionInterval="2000" FirstRowSelected="true" ServicePath="TextBoxExt.asmx" ServiceMethod="getBatchExt" MinimumPrefixLength="1" EnableCaching="true" TargetControlID="txtBatch">
</ajaxToolkit:AutoCompleteExtender> </TD></TR><TR><TD><asp:Label id="Label2" runat="server" Width="91px" Text="Student Code" SkinID="lbl"></asp:Label></TD><TD><%--                        <asp:DropDownList ID="ddlCode" runat="server" SkinID="ddl" DataTextField="StdCode"
                            DataValueField="StdId" TabIndex="5">
                        </asp:DropDownList>--%><asp:TextBox id="txtStdCode" runat="server" AutoPostBack="True" skinID="txt">
</asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender3" runat="Server" onclientpopulating="ShowImage2" onclientpopulated="HideImage2" CompletionInterval="2000" FirstRowSelected="true" ServicePath="TextBoxExt.asmx" ServiceMethod="getStudentExt" MinimumPrefixLength="1" EnableCaching="True" TargetControlID="txtStdCode">
</ajaxToolkit:AutoCompleteExtender> </TD></TR><TR><TD><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="HEIGHT: 25px" colSpan=4><asp:Label id="msginfo" tabIndex=-1 runat="server" ForeColor="Red" Visible="true"></asp:Label></TD></TR><TR><TD class="btnTd" colSpan=2>
 <asp:Button id="btnReport" tabIndex=6 runat="server" Width="96px" Text="REPORT" SkinID="btn" CssClass="btnStyle" onclick="btnReport_Click"></asp:Button></TD></TR>
        <TR><TD colSpan=2>
            <asp:ObjectDataSource id="ObjCourse" runat="server" TypeName="CourseManager" SelectMethod="CourseCoursePlannerCombo" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="c" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource> </TD></TR></TBODY></TABLE></CENTER><ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Type first few characters" runat="server" SkinID="watermark" TargetControlID="txtCourse">
</ajaxToolkit:TextBoxWatermarkExtender> <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender2" watermarkText="Type first few characters" runat="server" SkinID="watermark" TargetControlID="txtBatch">
</ajaxToolkit:TextBoxWatermarkExtender> <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Type first few characters" runat="server" SkinID="watermark" TargetControlID="txtStdCode">
    </ajaxToolkit:TextBoxWatermarkExtender> </DIV>
</contenttemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
