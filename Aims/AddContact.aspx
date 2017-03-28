<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddContact.aspx.vb" Inherits="AddContact" Title="Add Contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add Contact</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">  
   function Valid(){
   var msg;
   msg=NameField100(document.getElementById("<%=FormView1.FindControl("txtFirst").ClientID %>"),'First Name');
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
function TABLE1_onclick() {

}

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<div class="mainBlock">
        <center>
            <h1 class="headingTxt">CONTACT DETAILS</h1>
        </center>
      <div>
      
             <center>
                    <asp:FormView ID="FormView1" runat="server" DefaultMode="Insert" Width="314px" DataSourceID="odsContact"
                        DataKeyNames="ContactId">
                        <InsertItemTemplate>
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="First Name" Width="80px"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtFirst" runat="server" Text='<%# Bind("FirstName") %>' AutoCompleteType="Disabled"
                                            CssClass=" " SkinID="txt" TabIndex="1"></asp:TextBox>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" SkinID="lbl" Text="Last Name"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtlast" runat="server" Text='<%# Bind("LastName") %>' AutoCompleteType="Disabled"
                                            CssClass=" " SkinID="txt" TabIndex="2"></asp:TextBox></td>
                                    </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Address"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtaddrline" runat="server" Text='<%# Bind("Address") %>' AutoCompleteType="Disabled"
                                            CssClass=" " SkinID="txt" TabIndex="3"></asp:TextBox></td>
                                   </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="City"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtcity" runat="server" Text='<%# Bind("City") %>' AutoCompleteType="Disabled"
                                            CssClass=" " SkinID="txt" TabIndex="4"></asp:TextBox></td>
                                    </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="State"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtstate" runat="server" Text='<%# Bind("State") %>' AutoCompleteType="Disabled"
                                            CssClass=" " SkinID="txt" TabIndex="5"></asp:TextBox></td>
                                   </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Postal Code"></asp:Label></td>
                                    <td style="width: 200px; height: 20px;">
                                        <asp:TextBox ID="txtpo" runat="server" Text='<%# Bind("PostalCode") %>' AutoCompleteType="Disabled"
                                            CssClass=" " SkinID="txt" TabIndex="6"></asp:TextBox></td>
                                    </tr>
                                <tr>
                                    <td colspan="5" class="btnTd">
                                        <asp:Button ID="btnsave" runat="server" Text="SAVE" CommandName="Insert" 
                                            SkinID="btn" CausesValidation="true" OnClientClick="return Validate()"  TabIndex="7" CssClass="btnStyle" /></td>
                                    </tr>
                            </table>
                            </center>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <table class="custTable">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="First Name" Width="88px"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtFirst" runat="server" Text='<%# Bind("FirstName") %>' SkinID="txt"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="Last Name"></asp:Label></td>
                                    <td style="width: 177px">
                                        <asp:TextBox ID="txtLast" runat="server" Text='<%# Bind("LastName") %>' SkinID="txt"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="Address"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtaddrline" runat="server" Text='<%# Bind("Address") %>' SkinID="txt"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="City"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtcity" runat="server" Text='<%# Bind("City") %>' SkinID="txt"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="State"></asp:Label></td>
                                    <td style="width: 177px; height: 26px">
                                        <asp:TextBox ID="txtstate" runat="server" Text='<%# Bind("State") %>' SkinID="txt"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" SkinID="lbl" Text="Postal Code"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtpo" runat="server" Text='<%# Bind("PostalCode") %>' SkinID="txt"></asp:TextBox></td>
                                </tr>
                               <tr>
                                    <td colspan="5" class="btnTd" >
                                        <asp:Button ID="btnsave" runat="server" Text="UPDATE" CommandName="Update" SkinID="btn"
                                            CausesValidation="true" OnClientClick="return Validate()"  CssClass="btnStyle"/>
                                            <asp:Button ID="btnCancel" runat="server" Text="CANCEL"
                                                CommandName="Cancel" SkinID="btn" ValidationGroup="save" OnClick="btnCancel_Click" CssClass="btnStyle"/></td>
                                </tr>
                                
                            </table>
                        </EditItemTemplate>
                    </asp:FormView>
                 &nbsp;</center>
          <center>
            <asp:Label ID="msginfo" runat="server" ForeColor="red"></asp:Label>
          </center>
           <div>
                 <center>  
                  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/DiaryMain.aspx" Width="260px"
                        SkinID="lnkH" TabIndex="8">Main Diary Page</asp:HyperLink>
             <asp:Panel ID="Panel1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" DataSourceID="odsContact" DataKeyNames="ContactId"
                            AutoGenerateColumns="False" SkinID="GridView" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="CID" runat="server" Value='<%# Bind("ContactId") %>'></asp:HiddenField>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Edit"
                                            CommandName="Edit" />
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Postal Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    </center>
                    <asp:ObjectDataSource ID="odsContact" runat="server" TypeName="ContactManager" InsertMethod="InsertRecord"
                        SelectMethod="GetContact" UpdateMethod="UpdateRecord" DeleteMethod="DeleteRecord"
                        DataObjectTypeName="Contact">
                        <%--<SelectParameters>
                            <asp:Parameter Name="id" Type="int16" DefaultValue="0" />
                        </SelectParameters>--%>
                    </asp:ObjectDataSource>
                   
               </div>
       </div>


</form>
</body>
</html>

 