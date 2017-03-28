<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmNoDuesDetls.aspx.vb" Inherits="frmNoDuesDetls" Title="No Due Certificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vehicle Details</title>
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
function ShowImage2()
{
GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

 }
function HideImage2()
{
 GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
}

   function Valid(){
   var msg;
     msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID%>"),'Course');  
     if(msg!="") return msg;  
     msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID%>"),'Academic Year');
     if(msg!="") return msg;         
      msg=AutoCompleteExtender(document.getElementById("<%=txtStdCode.ClientID%>"),'Student Code');      
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
  
  function Valid_Report(){
   var msg;
     msg=AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID%>"),'Course');  
     if(msg!="") return msg;  
     msg=AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID%>"),'Academic Year');
     if(msg!="") return msg;         
     return true;
   }   
function Validate_Report(){
  var msg=Valid_Report();   
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
<div><center><H1 class="headingTxt">NO DUE CERTIFICATE </H1></center><center>
<table class="custTable">
        <tr>
                <td colspan="2"><asp:TextBox id="txtid" runat="server" Visible="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label id="lblCourse" runat="server" Height="16px" Text="Course" SkinID="lbl"></asp:Label></td>
            <td><asp:TextBox id="txtCourse" runat="server" Width="294px" AutoPostBack="True"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender2" runat="Server" onclientpopulating="ShowImage" onclientpopulated="HideImage" CompletionInterval="2000" FirstRowSelected="true" ServicePath="TextBoxExt.asmx" ServiceMethod="getCourseExt" MinimumPrefixLength="1" EnableCaching="true" TargetControlID="txtCourse">
</ajaxToolkit:AutoCompleteExtender></td>
        </tr>
        <tr>
            <td><asp:Label id="Label1" runat="server" Width="72px" Height="16px" Text="Academic Year" SkinID="lbl"></asp:Label></td>
            <td><asp:TextBox id="txtBatch" runat="server" AutoPostBack="True" skinID="txt"></asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender1" runat="Server" onclientpopulating="ShowImage1" onclientpopulated="HideImage1" CompletionInterval="2000" FirstRowSelected="true" ServicePath="TextBoxExt.asmx" ServiceMethod="getBatchExt" MinimumPrefixLength="1" EnableCaching="true" TargetControlID="txtBatch">
</ajaxToolkit:AutoCompleteExtender> </td>
        </tr>
        <tr>
            <td><asp:Label id="lblDepart" runat="server" Text="Department" SkinID="lbl"></asp:Label></td>
            <td><asp:DropDownList id="ddldept" runat="server" SkinID="ddl" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList></td>            
            <%--<asp:DropDownList id="ddldept" runat="server" SkinID="ddl" DataSourceID="ObjectDept" DataTextField="DeptName" DataValueField="Dept_ID">
                        </asp:DropDownList>--%>
        </tr>
        <tr>
            <td><asp:Label id="stdcode" runat="server" Width="91px" Text="Student Code" SkinID="lbl"></asp:Label></td>
            <td><asp:TextBox id="txtStdCode" runat="server" AutoPostBack="True" skinID="txt">
</asp:TextBox> <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender3" runat="Server" onclientpopulating="ShowImage2" onclientpopulated="HideImage2" CompletionInterval="2000" FirstRowSelected="true" ServicePath="TextBoxExt.asmx" ServiceMethod="getStudentExt" MinimumPrefixLength="1" EnableCaching="True" TargetControlID="txtStdCode">
</ajaxToolkit:AutoCompleteExtender> </td>
        </tr>
        <tr>
            <td><asp:Label id="lblPer" runat="server" Text="Performance" SkinID="lbl"></asp:Label></td>
            <td><asp:DropDownList id="ddlPerformance" runat="server" SkinID="ddl">
                            <asp:ListItem Text="No Dues">No Dues</asp:ListItem>
                            <asp:ListItem Text="Due Amount">Due Amount</asp:ListItem>
                        </asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label id="lblrmks" runat="server" Text="Remarks" SkinID="lbl"></asp:Label></td>
            <td><asp:TextBox id="txtRemark" runat="server" SkinID="txt"></asp:TextBox></td></tr>
        <tr>
            <td class="btnTd" colspan="2"><asp:Button id="btnsave" tabIndex=6 runat="server" Width="94px" Text="SAVE" SkinID="btn" onclientclick="return Validate();" CssClass="btnStyle"></asp:Button> <asp:Button id="btndetails" runat="server" Text="DETAILS" SkinID="btn" CssClass="btnStyle"></asp:Button> <asp:Button id="btnreport" runat="server" Text="REPORT" SkinID="btn" CssClass="btnStyle"></asp:Button> <!--<asp:Button id="btnrecover" runat="server" Text="RECOVER" SkinID="btn" CssClass="btnStyle"></asp:Button>--></td>
        </tr>
        <tr>
                            <td colspan="2">
                                  <center><div class="errMgs"><asp:Label id="msginfo" runat="server" ></asp:Label></div></center>
                            </td>
        </tr>
                                                      
       <tr>
        <td colspan="2"><asp:ObjectDataSource id="ObjInstitute" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetComboUser" TypeName="InstituteManager">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
       <asp:ObjectDataSource id="ObjectDept" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GlobalDataSetTableAdapters.DeptMasterTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_Dept_ID" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="DeptName" Type="String" />
                                <asp:Parameter Name="DeptCode" Type="String" />
                                <asp:Parameter Name="Del_Flag" Type="Boolean" />
                                <asp:Parameter Name="Original_Dept_ID" Type="Int32" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="DeptName" Type="String" />
                                <asp:Parameter Name="DeptCode" Type="String" />
                                <asp:Parameter Name="Del_Flag" Type="Boolean" />
                            </InsertParameters>
                        </asp:ObjectDataSource> 
                        <asp:ObjectDataSource id="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetBranchCombo" TypeName="BranchManager">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="i" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
                        <asp:ObjectDataSource id="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="CourseCoursePlannerCombo" TypeName="CourseManager">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="c" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
                        <asp:ObjectDataSource id="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="BLNoDue">
                            <SelectParameters>
                                <asp:Parameter Name="NoDueid" Type="Int64" />
                                <asp:Parameter Name="Inst" Type="Int64" />
                                <asp:Parameter Name="branch" Type="Int64" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView id="GVNoDue" runat="server" Width="298px" 
                Height="1px" SkinID="Gridview" Visible="False" AutoGenerateColumns="False" 
                DataKeyNames="Due_ID" EmptyDataText="There are no records to display." 
                PageSize="100">
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
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:HiddenField ID="Due_ID" runat="server" Value='<%#Bind("Due_ID")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="Ins_ID" runat="server" Value='<%#Bind("Institute_ID")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="Br_ID" runat="server" Value='<%#Bind("Branch_ID")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="Cr_ID" runat="server" Value='<%#Bind("Course_ID")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="Btch" runat="server" Value='<%#Bind("Batch_No")%>'></asp:HiddenField>
                                    <asp:HiddenField ID="dpt" runat="server" Value='<%#Bind("Dept_ID")%>'></asp:HiddenField>
                                    <asp:Label ID="Label4" runat="server" Text='<% #GetDeptName(Convert.ToInt64(Eval("Dept_ID"))) %>'
                                        ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Student Code">
                                <ItemTemplate>
                                    <asp:HiddenField ID="stdid" runat="server" Value='<%#Bind("StdId")%>'></asp:HiddenField>
                                    <asp:Label ID="Label5" runat="server" Text='<%# GetStdCode(Convert.ToInt64(Eval("StdId"))) %>'
                                        ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Performance">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Performance") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Remarks") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </asp:Panel>
                    </td></tr>
                   </table></center><ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Type first few characters" runat="server" SkinID="watermark" TargetControlID="txtCourse">
</ajaxToolkit:TextBoxWatermarkExtender> <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender2" watermarkText="Type first few characters" runat="server" SkinID="watermark" TargetControlID="txtBatch">
</ajaxToolkit:TextBoxWatermarkExtender> <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Type first few characters" runat="server" SkinID="watermark" TargetControlID="txtStdCode">
    </ajaxToolkit:TextBoxWatermarkExtender> </div>
</contenttemplate>
    <triggers>
<asp:AsyncPostBackTrigger ControlID="btndetails" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
   </asp:UpdatePanel>
  
</form>
</body>
</html>

