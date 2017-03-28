<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminResponse.aspx.vb"
    Inherits="AdminResponse" Title="Admin Response" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Response</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
function Valid(){
   var msg;
     msg=NameField100(document.getElementById("<%=txtAprName.ClientID%>"),'Full Name');  
     if(msg!="") return msg;  
     msg=Field255(document.getElementById("<%=txtRemarks.ClientID%>" )  ,'Description of Request');  
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
                   ADMIN RESPONSE 
                </h1>
            </center>
            <center>
                <asp:Panel ID="PanelFilter" runat="Server">
                    <asp:Label ID="Label9" runat="server" Text="Enter the following information to initiate a search... "
                        Font-Bold="true" Font-Names="Arial"></asp:Label>
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="User ID " SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Status " SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFilterStatus" runat="server">
                                    <asp:ListItem Selected="True" Value="0">Open</asp:ListItem>
                                    <asp:ListItem Value="1">Close</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Date" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFilterDate" runat="server"></asp:TextBox>
                            </td>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Priority" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFilterPriority" runat="server">
                                        <asp:ListItem Selected="True" Value="0">High</asp:ListItem>
                                        <asp:ListItem Value="1">Medium</asp:ListItem>
                                        <asp:ListItem Value="2">Low</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="Server" Text="SEARCH" SkinID="btn" />
                                    <asp:Button ID="btnClose" runat="Server" Text="CANCEL" SkinID="btn" />
                                </td>
                            </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelResponse" runat="Server" Width="350px">
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnReqID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Approver's Full Name *" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAprName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Status *" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                    <asp:ListItem Selected="False" Value="0">Open</asp:ListItem>
                                    <asp:ListItem Value="1" Selected="true">Close</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 26px">
                                <asp:Label ID="Label2" runat="server" Text="Date Closed *" SkinID="lbl"></asp:Label>
                            </td>
                            <td style="height: 26px">
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Admin Remarks *"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="SAVE" SkinID="btn" CausesValidation="true"
                                    OnClientClick="return Validate();" />
                                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" SkinID="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="msginfo" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </center>
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
            <asp:GridView ID="grdUserReq" runat="server" AutoGenerateColumns="False" SkinID="gridview"
                EmptyDataText="No records to display." SelectedIndex="-1" PageSize="100">
                <Columns>
                    <asp:CommandField ButtonType="Link" ShowSelectButton="true" SelectText="Respond" />
                    <asp:BoundField DataField="ID" HeaderText="Request Id" SortExpression="ID" ReadOnly="True" />
                    <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" ReadOnly="True" />
                    <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName"
                        ReadOnly="True" />
                    <asp:BoundField DataField="RequestDate" HeaderText="Request Date" SortExpression="RequestDate"
                        ReadOnly="True" />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority"
                        ReadOnly="True" />
                    <asp:BoundField DataField="DescOfRequest" HeaderText="Description" SortExpression="DescOfRequest"
                        ReadOnly="True" />
                    <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By" SortExpression="ApprovedBy"
                        ReadOnly="True" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="True" />
                    <asp:BoundField DataField="ClosedDate" HeaderText="Closed Date" SortExpression="ClosedDate"
                        ReadOnly="True" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks"
                        ReadOnly="True" />
                </Columns>
            </asp:GridView>
            </asp:Panel>
        </div>
    </center>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
        SkinID="Calendar" Format="dd-MMM-yyyy" PopupPosition="TopRight">
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFilterDate"
        SkinID="Calendar" Format="dd-MMM-yyyy" PopupPosition="TopRight">
    </ajaxToolkit:CalendarExtender>


</form>
</body>
</html>
