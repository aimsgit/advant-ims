<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmInstitute.aspx.vb"
    Inherits="frmInstitute" Title="Institution Details" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Institution Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">  
 function Valid()
{
    var msg;
    msg=NameField100(document.getElementById("<%=fvInstituteDetails.FindControl("txtName").ClientID %>"),'Name');
    if(msg!="") return msg; 
    msg=Field30N(document.getElementById("<%=fvInstituteDetails.FindControl("txtstate").ClientID %>"),'State');
    if(msg!="") return msg; 
    msg=CodeField(document.getElementById("<%=fvInstituteDetails.FindControl("txtcode").ClientID %>"),'Code');
    if(msg!="") return msg;
    msg=Field30N(document.getElementById("<%=fvInstituteDetails.FindControl("txtcountry").ClientID %>"),'Country');
    if(msg!="") return msg;
    msg=Field250(document.getElementById("<%=fvInstituteDetails.findcontrol("txtAddress").ClientID %>"),'Address');
    if(msg!="") return msg;  
    msg=NameField100(document.getElementById("<%=fvInstituteDetails.findcontrol("txtcontactPerson").ClientID %>"),'ContactPerson');
    if(msg!="") return msg;  
    msg=valcontact(document.getElementById("<%=fvInstituteDetails.findcontrol("txtcontactno").ClientID %>"),'ContactNo');
    if(msg!="") return msg;
    msg=Field30N(document.getElementById("<%=fvInstituteDetails.findcontrol("txtcity").ClientID %>"),'City');
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mainBlock" align="center">
                <center>
                    <h1 class="headingTxt">
                        BRANCH TYPE DETAILS</h1>
                </center>
                <center>
                    <asp:FormView ID="fvInstituteDetails" runat="server" DefaultMode="Insert" OnItemUpdated="FormviewItemUpdated"
                        OnItemInserted="FormviewItemInserted" DataSourceID="odsInstitute" DataKeyNames="id"
                        __designer:wfdid="w80">
                        <EditItemTemplate>
                            <center>
                                <table class="custTable">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" SkinID="lbl" Text="Branch Type Name*" Width="98px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name")%>' SkinID="txt" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" SkinID="lbl" Text="State"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtstate" runat="server" Text='<%# Bind("State") %>' SkinID="txt"
                                                TabIndex="5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" SkinID="lbl" Text="Code*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcode" runat="server" Text='<%# Bind("InstituteCode") %>' SkinID="txt"
                                                TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" SkinID="lbl" Text="Country"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcountry" runat="server" Text='<%# Bind("Country") %>' SkinID="txt"
                                                TabIndex="6"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" SkinID="lbl" Text="Address*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' TextMode="MultiLine"
                                                SkinID="txtML" TabIndex="3"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" SkinID="lbl" Text="Contact Person*" Width="97px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcontactPerson" runat="server" Text='<%# Bind("ContactPerson") %>'
                                                SkinID="txt" TabIndex="7"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label23" runat="server" SkinID="lbl" Text="Contact No.*" Width="76px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcontactno" runat="server" Text='<%# Bind("ContactNo") %>' SkinID="txt"
                                                TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" SkinID="lbl" Text="City"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcity" runat="server" Text='<%# Bind("City") %>' SkinID="txt"
                                                TabIndex="4"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="btnTd">
                                            <asp:Button ID="btnUpdate" CausesValidation="true" runat="server" CommandName="Update"
                                                EnableViewState="False" OnClientClick="return Validate();" SkinID="btn" Text="UPDATE"
                                                TabIndex="10" CssClass="btnStyle" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="true" CommandName="cancel"
                                                SkinID="btn" Text="CANCEL" TabIndex="11" OnClick="viewGridview" CssClass="btnStyle" />
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </center>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <center>
                                <table class="custTable">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" SkinID="lbl" TabIndex="-1" Text="Branch Type Name*"
                                                Width="117px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name")%>' SkinID="txt" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="State"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtstate" runat="server" Text='<%# Bind("State") %>' SkinID="txt"
                                                TabIndex="5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Code*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcode" runat="server" Text='<%# Bind("InstituteCode") %>' SkinID="txt"
                                                TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="Country"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcountry" runat="server" Text='<%# Bind("Country") %>' SkinID="txt"
                                                TabIndex="6"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="Address*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' TextMode="MultiLine"
                                                SkinID="txtML" TabIndex="3"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="Contact Person*" Width="101px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcontactPerson" runat="server" Text='<%# Bind("ContactPerson") %>'
                                                SkinID="txt" TabIndex="7"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="Contact No.*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcontactno" runat="server" Text='<%# Bind("ContactNo") %>' SkinID="txt"
                                                TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="City"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcity" runat="server" Text='<%# Bind("City") %>' SkinID="txt"
                                                TabIndex="4"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <center>
                                            <td colspan="2" class="btnTd">
                                                <asp:Button ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert"
                                                    OnClientClick="return Validate();" SkinID="btn" Text="SAVE" Width="80px" TabIndex="10"
                                                    CssClass="btnStyle" />
                                                <asp:Button ID="btnDetails" runat="server" CausesValidation="true" SkinID="btn" Text="DETAILS"
                                                    Width="80px" OnClick="btnDetails_Click" TabIndex="11" CssClass="btnStyle" />
                                                <asp:Button ID="btnReport" runat="server" CausesValidation="true" Height="24px" OnClick="Report"
                                                    SkinID="btn" Text="REPORT" Width="80px" TabIndex="12" CssClass="btnStyle" />
                                            </td>
                                        </center>
                                    </tr>
                                </table>
                            </center>
                        </InsertItemTemplate>
                    </asp:FormView>
                </center>
                <center>
                    <div>
                        &nbsp;</div>
                    <div class="errMgs">
                        <asp:Label ID="msginfo" TabIndex="-1" runat="server" Visible="true" __designer:wfdid="w82"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" __designer:wfdid="w83"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" __designer:wfdid="w84">false</asp:TextBox>
                    </div>
                    <div>
                        &nbsp;</div>
                </center>
                <div>
                    <center>
                        <asp:GridView ID="gvInstituteDetails" runat="server" Width="760px" Height="245px"
                            SkinID="GridView" DataKeyNames="Id" EmptyDataText="There are no data records to display."
                            AutoGenerateColumns="False" AllowPaging="True" __designer:wfdid="w85">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="true" CommandName="delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BranchType Name">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("Id") %>'></asp:HiddenField>
                                        <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Name") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("InstituteCode") %>' ID="Label1"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("Address") %>' ID="Label2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("City") %>' ID="Label3"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("State") %>' ID="Label4"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("Country") %>' ID="Label5"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No.">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("ContactNo") %>' ID="Label6"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Person">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("ContactPerson") %>' ID="Label7"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </center>
                </div>
                <div>
                    <asp:ObjectDataSource ID="odsInstitute" runat="server" DataObjectTypeName="Institute"
                        DeleteMethod="ChangeFlag" UpdateMethod="UpdateRecord" SelectMethod="GetInstitute"
                        InsertMethod="InsertRecord" TypeName="InstituteManager" __designer:wfdid="w86">
                    </asp:ObjectDataSource>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="fvInstituteDetails" EventName="ItemCommand">
            </asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>

</form>
</body>
</html>