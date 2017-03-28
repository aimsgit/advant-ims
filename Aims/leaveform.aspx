<%@ Page Language="VB" AutoEventWireup="true"  CodeFile="leaveform.aspx.vb"
    Inherits="leaveform" Title="Leave Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Response</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<script type="text/javascript" language="javascript">  
   function ValidReport(){
   var msg;
    msg=AutoCompleteExtender(document.getElementById("<%=FormView1.FindControl("txtEmp").ClientID%>"),'Employee');
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
GlbShowSImage(document.getElementById("<%=FormView1.FindControl("txtEmp").ClientID%>"));

 }
function HideImage()
{
 GlbHideSImage(document.getElementById("<%=FormView1.FindControl("txtEmp").ClientID%>"));
}  
function Valid()
{
    var msg;
    msg=NameField100(document.getElementById("<%=FormView1.FindControl("txtEmp").ClientID %>"),'Employee');
    if(msg!="") return msg; 
    msg=DropDown(document.getElementById("<%=FormView1.FindControl("txtleav").ClientID %>"),'Leave Type');
    if(msg!="") return msg;
    msg=FeesField(document.getElementById("<%=FormView1.FindControl("textblanceleav").ClientID %>"),'Balance Leave');
    if(msg!="") return msg;  
    msg=Field255N(document.getElementById("<%=FormView1.FindControl("txtremark").ClientID %>"),'Remarks');
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

    
<asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
<DIV><CENTER><H1 class="headingTxt">LEAVE DETAILS MASTER </H1></CENTER><CENTER>
<asp:FormView id="FormView1" runat="server" __designer:wfdid="w159" DefaultMode="Insert" DataSourceID="odsleave" DataKeyNames="lmid"><EditItemTemplate>

<center>
<table class="custTable">
<tr>
<td ><asp:Label id="Label1" runat="server" Width="101px" Text="Employee*" SkinID="lbl" __designer:wfdid="w99"></asp:Label></td>
<td>
<%--  <asp:DropDownList ID="txtemp" runat="server" DataSourceID="ObjectEmp" DataValueField="Emp_Id"
                                                    DataTextField="Emp_Name" SelectedValue='<%# bind("EId") %>' SkinID="ddl" TabIndex="1">
                                                </asp:DropDownList>--%>
<asp:TextBox id="txtEmp" runat="server" AutoPostBack="true" SkinID="txt"></asp:TextBox> </td></tr>
<tr><td><asp:Label id="Label2" runat="server" Width="84px" Text="Leave Type*" SkinID="lbl" __designer:wfdid="w101"></asp:Label></td><td><asp:DropDownList id="txtleav" tabIndex=2 runat="server" SkinID="ddl" DataSourceID="ObjectLeaveType" __designer:wfdid="w102" SelectedValue='<%# bind("LeaveType") %>' DataTextField="Leave_Type" DataValueField="TY_ID">
</asp:DropDownList> </td></tr><tr><td><asp:Label id="Label3" runat="server" Width="103px" Text="Balance Leave*" SkinID="lbl" __designer:wfdid="w104"></asp:Label></td><td><asp:TextBox id="textblanceleav" tabIndex=3 runat="server" Text='<%#bind("BalanceLeave") %>' SkinID="txt" __designer:wfdid="w105"></asp:TextBox> <%--                                        <asp:RequiredFieldValidator ID="RFVbalanceleav" runat="server" ControlToValidate="textblanceleav"
                                            ErrorMessage="*" Width="23px">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textblanceleav"
                                            ErrorMessage="Enter numbers only." SetFocusOnError="true" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>--%></td></tr><tr><td><asp:Label id="Label4" runat="server" Text="Remarks" SkinID="lbl" __designer:wfdid="w106"></asp:Label></td><td><asp:TextBox id="txtremark" tabIndex=4 runat="server" Text='<%#bind("Remarks") %>' SkinID="txtML" __designer:wfdid="w107"></asp:TextBox></td></tr><tr><td colSpan=2 class="btnTd">
                                            <asp:Button id="btnupdate" tabIndex=5 onclick="btnupdate_Click" runat="server" Text="UPDATE" CausesValidation="true" SkinID="btn" __designer:wfdid="w108" OnClientClick="return Validate();" CssClass="btnStyle"></asp:Button><asp:Button id="BtnCancel" tabIndex=10 onclick="CancelEdit" runat="server" Text="CANCEL" CausesValidation="false" SkinID="btn" __designer:wfdid="w109" CommandName="CANCEL" CssClass="btnStyle"></asp:Button></td></tr></table></center>
<ajaxToolkit:AutoCompleteExtender 
    id="AutoCompleteExtender2" 
    runat="Server" 
    TargetControlID="txtEmp" 
    ServicePath="TextBoxExt.asmx" 
    ServiceMethod="getEmpExt" 
    onclientpopulating="ShowImage" 
    onclientpopulated="HideImage" 
    MinimumPrefixLength="3"
    CompletionInterval="1000" 
    FirstRowSelected="true"
    EnableCaching="true" >
</ajaxToolkit:AutoCompleteExtender> 
<asp:TextBox id="txtid" runat="server" Width="67px" __designer:wfdid="w103" Visible="False"></asp:TextBox>
</EditItemTemplate>
<InsertItemTemplate>
<CENTER><TABLE class="custTable"><TR><TD><asp:Label id="Label1" runat="server" Text="Employee*" SkinID="lbl" __designer:wfdid="w3"></asp:Label></TD><TD><%--<asp:DropDownList ID="txtemp" runat="server" DataSourceID="ObjectEmp" DataValueField="Emp_Id"
                                                DataTextField="Emp_Name" SelectedValue='<%# bind("EId") %>' SkinID="ddl" TabIndex="1">
                                            </asp:DropDownList>--%><asp:TextBox id="txtEmp" runat="server" __designer:wfdid="w4" AutoPostBack="true" SkinID="txt"></asp:TextBox> <%-- <asp:RequiredFieldValidator ID="RFVEmpl" runat="server" ControlToValidate="txtemp"
                                            ErrorMessage="*" Width="23px">*</asp:RequiredFieldValidator>--%></TD></TR><TR><TD><asp:Label id="Label2" runat="server" Text="Leave Type*" SkinID="lbl" __designer:wfdid="w5"></asp:Label></TD><TD><asp:DropDownList id="txtleav" tabIndex=2 runat="server" SkinID="ddl" __designer:wfdid="w6" DataSourceID="ObjectLeaveType" DataValueField="TY_ID" DataTextField="Leave_Type" SelectedValue='<% # bind("LeaveType") %>'>
                                            </asp:DropDownList> <%-- <asp:RequiredFieldValidator ID="RFVleavtypes" runat="server" ControlToValidate="txtleav"
                                            ErrorMessage="*" Width="23px">*</asp:RequiredFieldValidator>--%></TD></TR><TR><TD><asp:Label id="Label3" runat="server" Text="Balance Leave*" SkinID="lbl" __designer:wfdid="w7"></asp:Label></TD><TD><asp:TextBox id="textblanceleav" tabIndex=3 runat="server" Text='<%#bind("BalanceLeave") %>' SkinID="txt" __designer:wfdid="w8" AutoCompleteType="disabled"></asp:TextBox> <%--<asp:RequiredFieldValidator ID="RFVbalanceleav" runat="server" ControlToValidate="textblanceleav"
                                            ErrorMessage="*" Width="23px">*</asp:RequiredFieldValidator>--%><%--                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter numbers only."
                                            ValidationExpression="[0-9]*" ControlToValidate="textblanceleav" SetFocusOnError="true"></asp:RegularExpressionValidator>--%></TD></TR><TR><TD><asp:Label id="Label4" runat="server" Width="116px" Text="Remarks" SkinID="lbl" __designer:wfdid="w9"></asp:Label></TD><TD><asp:TextBox id="txtremark" tabIndex=4 runat="server" Width="201px" Text='<%#bind("remarks") %>' SkinID="txt" __designer:wfdid="w10" AutoCompleteType="disabled"></asp:TextBox> </TD></TR><TR><TD colspan="2" class="btnTd"><asp:Button id="BtnSave" tabIndex=5 onclick="BtnSave_Click" runat="server" Width="84px" Text="SAVE"   CausesValidation="true" SkinID="btn" __designer:wfdid="w11" CssClass="btnStyle" OnClientClick="return Validate();"></asp:Button> <asp:Button id="btnDetails" tabIndex=6 onclick="btnDetails_Click" runat="server" Width="84px" Text="DETAILS" CausesValidation="true" SkinID="btn" __designer:wfdid="w12" CssClass="btnStyle"></asp:Button> <asp:Button id="BtnReport" tabIndex=7 onclick="BtnReport_Click" runat="server" Width="84px" Text="REPORT" CausesValidation="true" SkinID="btn" __designer:wfdid="w13" CssClass="btnStyle" CommandName="Preview"></asp:Button> 
                                            <!--<asp:Button id="BtnRecover" tabIndex=8 onclick="BtnRecover_Click" runat="server" Width="84px" Text="RECOVER" CausesValidation="true" SkinID="btn" __designer:wfdid="w14" CssClass="btnStyle"></asp:Button>--></TD></TR></TABLE></CENTER>
<ajaxToolkit:AutoCompleteExtender 
   id="AutoCompleteExtender1" 
   runat="Server" 
   TargetControlID="txtEmp" 
    ServicePath="TextBoxExt.asmx" 
    ServiceMethod="getEmpExt" 
    onclientpopulating="ShowImage" 
    onclientpopulated="HideImage" 
    MinimumPrefixLength="3"
    CompletionInterval="2000" 
    FirstRowSelected="true"
    EnableCaching="true" >

</ajaxToolkit:AutoCompleteExtender> 
<asp:TextBox id="txtid" runat="server" Width="73px" __designer:wfdid="w16" Visible="False" SkinID="txt"></asp:TextBox>

<ajaxToolkit:TextBoxWatermarkExtender 
     id="TextBoxWatermarkExtender1" 
     watermarkText="Type first few characters" 
     runat="server" 
     TargetControlID="txtEmp"
      skinid="watermark" >
</ajaxToolkit:TextBoxWatermarkExtender>
</InsertItemTemplate>
</asp:FormView> </CENTER>
<div>&nbsp;</div>
 <center><div class="errMgs">
    <asp:Label id="lblErrorMsg" runat="server" __designer:wfdid="w160" ></asp:Label> 
    <asp:Label id="msginfo" tabIndex=-1 runat="server" __designer:wfdid="w161" Visible="true"></asp:Label> </div>
    </center>
<div>&nbsp;</div>
    <%--    <asp:Panel ID="Panel1" runat="server" SkinID="Pnl">--%><DIV><CENTER><asp:GridView id="GridView1" runat="server" SkinID="GridView" __designer:wfdid="w162" DataKeyNames="lmid" AutoGenerateColumns="False" EmptyDataText="No records to Display." AllowPaging="true">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee" SortExpression="Empid">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="lid" runat="server" Value='<%# Bind("lmid") %>' />
                                            <asp:HiddenField ID="emid" runat="server" value='<%# Bind("EId") %>' />
                                            <%--<asp:Label ID="Label6" runat="server" Text='<% #GetEmpName(Convert.ToInt64(Eval("EId"))) %>'></asp:Label>--%>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type" SortExpression="LeaveType">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="Label2" runat="server" Text='<%# GetLeavetype(Convert.ToInt64(Eval("LeaveType"))) %>'></asp:Label>--%>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Leave_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance Leave" SortExpression="BalanceLeave">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("BalanceLeave") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView> </CENTER></DIV><%--  </asp:Panel>--%><DIV><asp:ObjectDataSource id="odsleave" runat="server" TypeName="LeaveManager" SelectMethod="GetLeave" OldValuesParameterFormatString="original_{0}" DeleteMethod="ChangeFlag" DataObjectTypeName="Leave">
        <%--  <InsertParameters>
            <asp:Parameter Name="BalanceLeave" Type="Int64" ConvertEmptyStringToNull="true" DefaultValue="0" />
            
        </InsertParameters>--%>
    </asp:ObjectDataSource> <asp:ObjectDataSource id="ObjectEmp" runat="server" TypeName="EmployeeManager" SelectMethod="GetEmpEditdetails" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="EEid" Type="Int32" />
            <%--<asp:SessionParameter DefaultValue="0" Name="id" SessionField="EMPID" Type="Int64" />--%>
        </SelectParameters>
    </asp:ObjectDataSource> <asp:ObjectDataSource id="ObjectLeaveType" runat="server" TypeName="LeaveTypes" SelectMethod="GetLeavTypes" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="id" Type="Int32" />
            <%--<asp:SessionParameter DefaultValue="0" Name="id" SessionField="EMPID" Type="Int64" />--%>
        </SelectParameters>
    </asp:ObjectDataSource>&nbsp; </DIV></DIV>
</contenttemplate>
        </asp:UpdatePanel>
   
</form>
</body>
</html>
