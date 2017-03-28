<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMaintenanceDetails.aspx.vb" Inherits="frmMaintenanceDetails" title="Machine Maintenance Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Machine Maintenance Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script language="JavaScript" type="text/javascript">
function Valid()
{
    var msg;
   
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

  <div>
        <center>
        <h1 class="headingTxt">
            MACHINE MAINTENANCE DETAILS
        </h1>
        </center>
        <center>
        <table class="custTable">
        
     <tr align="center">
         <td align="right">
             <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Maintenance Type* :  " Width="180px"></asp:Label></td>
         <td>
               <asp:DropDownList ID="ddlMainType" runat="server" AutoPostBack="True" DataSourceID="ObjMaintainType" 
                    DataTextField="MaintenanceType" DataValueField="M_ID" SkinID="ddlL" TabIndex="3" >
                </asp:DropDownList></td>
     </tr>
    
        <tr align="center">
            <td colspan="2" class="btnTd">
               <asp:Button ID="btnBack" runat="server" SkinID="btn" Text="BACK" 
                    TabIndex="6" CssClass="btnStyle"  />
               <asp:Button ID="btnReport" runat="server" CausesValidation="true" SkinID="btn" TabIndex="4"
                    Text="REPORT" CssClass="btnStyle"  />
               <%--<asp:Button ID="btnRecover" runat="server" CausesValidation="true"
                        SkinID="btn" TabIndex="5" Text="RECOVER" CssClass="btnStyle"  />--%>
                
            </td>
        </tr>
           <tr>
            <td style="width: 826px">
                  <asp:Label ID="msginfo" runat="server" ForeColor="Red" Visible="true"
                        TabIndex="-1"></asp:Label></td>         
        </tr>
        <tr>
                <td style="width: 826px">
                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" ></asp:Label></td>
            </tr>
            </table>
            <table>
        <tr>
            <td style="width: 826px">
                <asp:Panel ID="Panel1" runat="server" SkinID="Pnl">
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID ="GridView" EmptyDataText="No records to display." AllowPaging="True" >
                   <Columns>
                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="true" CommandName="Edit"
                                        Text="Edit" TabIndex="9" />&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Button3" runat="server" CausesValidation="true" CommandName="Delete"
                                        Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')"
                                        TabIndex="5" /></ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="Machine Make" SortExpression="ManuFacturer">
                          <ItemTemplate>
                          <asp:HiddenField  ID="MID" runat ="server"  Value ='<%# Bind("Maintain_ID") %>' />
                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("ManuFacturer") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Machine Type" SortExpression="AssetName">
                           
                           <ItemTemplate>
                               <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       
                       <asp:TemplateField HeaderText="Entry Date" SortExpression="Entry_Date">
                            
                           <ItemTemplate>
                               <asp:Label ID="Label6" runat="server" Text='<%# Bind("Entry_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Machine Model" SortExpression="Machine_Model">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Machine_Model") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label7" runat="server" Text='<%# Bind("Machine_Model") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Machine No" SortExpression="Machine_No">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Machine_No") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label8" runat="server" Text='<%# Bind("Machine_No") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       
                       <asp:TemplateField HeaderText="Cleaned Date" SortExpression="Cleaned_Date">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Cleaned_Date","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label10" runat="server" Text='<%# Bind("Cleaned_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Due Date" SortExpression="Due_Date">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Due_Date","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label11" runat="server" Text='<%# Bind("Due_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Time Stopped" SortExpression="Time_Stopped">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Time_Stopped") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label12" runat="server" Text='<%# Bind("Time_Stopped") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Part Changed" SortExpression="Part_Changed">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Part_Changed") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label13" runat="server" Text='<%# Bind("Part_Changed") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Time Run" SortExpression="Time_Run">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Time_Run") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label14" runat="server" Text='<%# Bind("Time_Run") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Operation" SortExpression="Operation">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Operation") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label15" runat="server" Text='<%# Bind("Operation") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Operator Name" SortExpression="Operator_Name">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Operator_Name") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label16" runat="server" Text='<%# Bind("Operator_Name") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Course Name" SortExpression="CourseName">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label22" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                           </ItemTemplate>
                             <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Academic Year" SortExpression="Batch_No">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("Batch_No") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label19" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Needle" SortExpression="Needle">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Needle") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label17" runat="server" Text='<%# Bind("Needle") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Parts" SortExpression="Parts">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("Parts") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label18" runat="server" Text='<%# Bind("Parts") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label20" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Wrap="False" />
                       </asp:TemplateField>
                                     
                   </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            
            <td style="width: 826px">
            <asp:ObjectDataSource ID="ObjMaintainType" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetMaintenanceTypeCombo" TypeName="MaintenanceTypeManager">                
                </asp:ObjectDataSource>
               <%-- <asp:ObjectDataSource ID="ObjMaintainType" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetMaintenanceType" TypeName="MaintenanceTypeManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
            </td>
        </tr>
    </table>
    </center>
    </div>

</form>
</body>
</html>
