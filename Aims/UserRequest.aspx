<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserRequest.aspx.vb" Inherits="UserRequest" title="Place An Admin Request" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Place An Admin Request</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script type="text/javascript" language = "javascript">
function Valid(){
   var msg;
     msg=NameField100(document.getElementById("<%=txtUserName.ClientID%>"),'Full Name');  
     if(msg!="") return msg;  
     msg=ValidateDate( document.getElementById("<%=txtDate.ClientID%>"  )  ,'Date');                  
     if(msg!="") return msg;
     msg=Field255(document.getElementById("<%=txtDscReq.ClientID%>" )  ,'Description of Request');  
     if(msg!="") return msg;    
     return true;
   }   
function Validate(){

  var msg=Valid();
  
  if(msg!=true){
  document.getElementById("<%=msginfo.ClientID %>").style.color="red";
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
<div>

        <center>
            <h1 class="headingTxt">
               PLACE AN ADMIN REQUEST
            </h1>
        </center>
        <center>
            <table class="custTable">
            <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text= "Full Name *"></asp:Label>            
            </td>
            <td>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </td>
            </tr>    
            <tr>
            <td style="height: 26px">
                <asp:Label ID="Label2" runat="server" Text= "Date *"></asp:Label>            
            </td>
            <td style="height: 26px">
            <ajaxToolkit:MaskedEditExtender ID="meeSDate" runat="server" TargetControlID="txtDate"
                            ClearMaskOnLostFocus="false" MaskType="none" Mask="99-LLL-9999" PromptCharacter="_" />
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            </td>
            </tr> 
            <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text= "Priority *"></asp:Label>            
            </td>
            <td>
                <asp:DropDownList ID="ddlPriority" runat="server">
                    <asp:ListItem Selected="True" Value="0">High</asp:ListItem>
                    <asp:ListItem Value="1">Medium</asp:ListItem>
                    <asp:ListItem Value="2">Low</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text= "Description of Request *" 
                    SkinID="lblRsz" Width="173px"></asp:Label>            
            </td>
            <td>
            <asp:TextBox ID="txtDscReq" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            </tr>
            </table>
            <table>
           <tr>
           <td>
                <asp:Button ID="btnSave" runat="server" Text="SEND REQUEST" SkinID = "btn2" CausesValidation = "true" OnClientClick = "return Validate();"/>
                <asp:Button ID="btnStatus" runat="server" Text="STATUS" SkinID = "btn" />
                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" SkinID = "btn" />
           </td>
             </tr> 
             <tr>
             <td>
             
                 <asp:Label ID="msginfo" runat="server" Text="" ForeColor = "Red"></asp:Label>
             </td>
             
             </tr>
            </table>
           
  </center> 
  <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
  <asp:GridView ID="grdUserReq" runat="server" AutoGenerateColumns = "False" 
            SkinID = "gridview" EmptyDataText = "Your request is not found." PageSize="100">
  <Columns>
  <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" ReadOnly="True" />
  <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" ReadOnly="True" />
  <asp:BoundField DataField="RequestDate" HeaderText="Request Date" SortExpression="RequestDate" ReadOnly="True" />
  <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" ReadOnly="True" />
  <asp:BoundField DataField="DescOfRequest" HeaderText="Description" SortExpression="DescOfRequest" ReadOnly="True" />
  <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By" SortExpression="ApprovedBy" ReadOnly="True" />
  <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="True" />
  <asp:BoundField DataField="ClosedDate" HeaderText="Closed Date" SortExpression="ClosedDate" ReadOnly="True" />
  <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" ReadOnly="True" />
  </Columns>
  </asp:GridView>
  </asp:Panel>
</div>
</center>
<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
        SkinID="Calendar" Format="dd-MMM-yyyy" PopupPosition="TopRight"></ajaxToolkit:CalendarExtender>



</form>
</body>
</html>

