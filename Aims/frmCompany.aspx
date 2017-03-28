<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCompany.aspx.vb"
    Inherits="frmCompany" Title="Company Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Company Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
 function Valid()
{
    var msg;
    msg=NameField100(document.getElementById("<%=FormView1.FindControl("NameTextBox").ClientID %>"),'Name');
    if(msg!="") return msg; 
    msg=NameField100(document.getElementById("<%=FormView1.findcontrol("ContactPersonTextBox").ClientID %>"),'ContactPerson');
    if(msg!="") return msg;    
    msg=Field250(document.getElementById("<%=FormView1.findcontrol("AddressTextBox").ClientID %>"),'Address');
    if(msg!="") return msg;     
    msg=valcontact(document.getElementById("<%=FormView1.findcontrol("ContactNoTextBox").ClientID %>"),'ContactNo');
    if(msg!="") return msg;       
    return true;
} 
 function Validate(){
          var msg=Valid();
          if(msg!=true)
          { 
                    if(navigator.appName=="Microsoft Internet Explorer")
                    {
                     document.getElementById("<%=lblErrorMsg.ClientID %>").innerText=msg;
                     return false;
                    }
                    else  if(navigator.appName == "Netscape")
                    {  
                     document.getElementById("<%=lblErrorMsg.ClientID %>").textContent=msg;
                     return false;
                    }   
          }
           return true;
 }
 
    </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div class="mainBlock">
        <center>
            <h1 class="headingTxt">
                COMPANY DETAILS</h1>
        </center>
        <center>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:FormView ID="FormView1" runat="server" Width="464px" OnItemUpdated="FormviewItemUpdated"
                            OnItemInserted="FormviewItemInserted" DataKeyNames="Id" DefaultMode="Insert"
                            DataSourceID="Objcompany">
                            <EditItemTemplate>
                                <center>
                                    <table class="custTable">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblname" runat="server" SkinID="lbl" Text="Company Name*"></asp:Label>
                                                    <td>
                                                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' SkinID="txtL"
                                                            TabIndex="1"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcontactperson" runat="server" SkinID="lbl" Text="Contact Person*"></asp:Label>
                                                    <td>
                                                        <asp:TextBox ID="ContactPersonTextBox" runat="server" Text='<%# Bind("ContactPerson") %>'
                                                            SkinID="txt" TabIndex="2"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcontactno" SkinID="lbl" Text="Contact No*" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ContactNoTextBox" runat="server" Text='<%# Bind("ContactNo") %>'
                                                        SkinID="txt" TabIndex="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Address*" SkinID="lbl"></asp:Label>&nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' SkinID="txtML"
                                                        TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </center>
                                <center>
                                    <asp:Button ID="Button4" runat="server" CommandName="Update" SkinID="btn" Text="UPDATE"
                                        CausesValidation="true" OnClientClick="return Validate();" TabIndex="5" />
                                    <asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="cancel"
                                        SkinID="btn" Text="CANCEL" OnClick="cancel1" ValidationGroup="DetailsView" TabIndex="6" />
                                </center>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <center>
                                    <table class="custTable">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblname" runat="server" Text="Company Name*" SkinID="lbl" __designer:wfdid="w8"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="NameTextBox" TabIndex="1" runat="server" Text='<%# Bind("Name") %>'
                                                        SkinID="txtL" __designer:wfdid="w9"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcontactperson" runat="server" Text="Contact Person*" SkinID="lbl"
                                                        __designer:wfdid="w10"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ContactPersonTextBox" TabIndex="2" runat="server" Text='<%# Bind("ContactPerson") %>'
                                                        SkinID="txt" __designer:wfdid="w11"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcontactno" runat="server" Text="Contact No*" SkinID="lbl" __designer:wfdid="w12"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ContactNoTextBox" TabIndex="3" runat="server" Text='<%# Bind("ContactNo") %>'
                                                        SkinID="txt" __designer:wfdid="w13"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbladdress" runat="server" Text="Address*" SkinID="lbl" __designer:wfdid="w14"></asp:Label>&nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="AddressTextBox" TabIndex="4" runat="server" Text='<%# Bind("Address") %>'
                                                        SkinID="txtML" __designer:wfdid="w15" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </center>
                                <div>
                                    <asp:Button ID="btnsave" TabIndex="5" OnClick="btnInsert_Click" runat="server" Text="SAVE"
                                        CausesValidation="True" SkinID="btn" __designer:wfdid="w16" CssClass="btnStyle"
                                        OnClientClick="return Validate();" CommandName="Insert"></asp:Button>
                                    <asp:Button ID="btndetails" TabIndex="6" OnClick="btndetails_Click" runat="server"
                                        Text="DETAILS" CausesValidation="False" SkinID="btn" __designer:wfdid="w17" CssClass="btnStyle">
                                    </asp:Button>
                                    <asp:Button ID="btnreport" TabIndex="7" OnClick="btnreport_Click" runat="server"
                                        Text="REPORT" CausesValidation="False" SkinID="btn" __designer:wfdid="w18" CssClass="btnStyle">
                                    </asp:Button>
                                    <!--<asp:Button id="btnrecover" tabIndex=8 onclick="btnrecover_Click" runat="server" Text="RECOVER" CausesValidation="False" SkinID="btn" __designer:wfdid="w19" CssClass="btnStyle"></asp:Button>-->
                                </div>
                                <%--        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                TargetControlID="NameTextBox" FilterType="Numbers" FilterMode="InvalidChars"
                                InvalidChars="#+_=*()'@[]{}?><^%$!~`;:\|">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                TargetControlID="ContactPersonTextBox" FilterType="Numbers" FilterMode="InvalidChars"
                                InvalidChars="#+_=/*()'@[]{}?><&^%$!~`;:\|1234567890">
                            </ajaxToolkit:FilteredTextBoxExtender>
                           <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="ContactNoTextBox" FilterType="Custom" FilterMode="ValidChars"
                                ValidChars="-1234567890">
                            </ajaxToolkit:FilteredTextBoxExtender>--%>
                            </InsertItemTemplate>
                        </asp:FormView>
                        <table>
                            <tr>
                                <td>
                                    <center>
                                        <div class="errMgs">
                                            <asp:Label ID="lblErrorMsg" runat="server"/>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" Width="480px" SkinID="gridview" DataKeyNames="Id"
                                            AllowPaging="True" AutoGenerateColumns="False"
                                            __designer:wfdid="w4">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="Company Name">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="RID" runat="server" Value='<%# Bind("Id") %>'></asp:HiddenField>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ContactPerson" SortExpression="ContactPerson">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ContactPerson") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ContactNo" SortExpression="ContactNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="FormView1" EventName="ItemCommand"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp;
            </div>
        </center>
    </div>
    <asp:ObjectDataSource ID="Objcompany" runat="server" DataObjectTypeName="Company"
        DeleteMethod="ChangeFlag" InsertMethod="InsertRecord" SelectMethod="GetCompany"
        TypeName="CompanyManager" UpdateMethod="UpdateRecord" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>

</form>
</body>
</html>
