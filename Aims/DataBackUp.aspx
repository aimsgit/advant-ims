<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DataBackUp.aspx.vb"
    Inherits="DataBackUp" Title="Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Configuration</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
function Valid()
{
    var msg;   
    msg=ValidateDate(document.getElementById("<%=txtDate.ClientID%>"),'Date Value');
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

    <div class="mainBlock">
        <div class="mainBlock">
            <center>
                <h1 class="headingTxt">
                    DATE CONFIGURATION</h1>
            </center>
            <center>
                <%--<asp:FormView DataSourceID="ObjConfig" DefaultMode="ReadOnly" ID="FVConfig" DataKeyNames="config_id"
                    runat="server">
                    <EditItemTemplate>
                        <table class="custTable">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Name" SkinID="lbl" Width="71px"></asp:Label>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" SkinID="txt" Text='<%# Bind("Config_Name") %>'
                                            TabIndex="1"></asp:TextBox>&nbsp;&nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Date*" SkinID="lbl"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("Date_Value") %>' SkinID="txt"
                                        TabIndex="2"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtid" runat="server" Text='<%# Bind("Config_ID") %>' Visible="false"
                                        SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                                <td>
                                    <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtDate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="btnTd">
                                    <asp:Button ID="BtnUpdate" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                        CommandName="Update" OnClick="BtnUpdate_Click" Text="UPDATE" SkinID="btn" TabIndex="15"
                                        CssClass="btnStyle"></asp:Button><asp:Button ID="BtnCancel" runat="server" CausesValidation="true"
                                            CommandName="Cancel" Text="CANCEL" SkinID="btn" TabIndex="16" CssClass="btnStyle">
                                        </asp:Button></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                    </InsertItemTemplate>
                    <ItemTemplate>--%>
                        <table class="custTable">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Name" SkinID="lbl" Width="71px"></asp:Label>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" SkinID="txt" Text='<%# Bind("Config_Name") %>'
                                            TabIndex="1" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Date*" SkinID="lbl"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("Date_Value","{0:dd-MMM-yyyy}") %>' SkinID="txt"
                                        TabIndex="2"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtid" runat="server" Text='<%# Bind("Config_ID") %>' Visible="false"
                                        SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                                <td>
                                    <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtDate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="btnTd">
                                    <asp:Button ID="btnEdit" runat="server" Text="UPDATE" CommandName="Edit" SkinID="btn"
                                        CausesValidation="true" CssClass="btnStyle" visible="false" OnClick="BtnUpdate_Click" />
                                    <asp:Button ID="btnDetails" runat="server" Text="DETAILS" CommandName="Details" SkinID="btn"
                                        CausesValidation="false" CssClass="btnStyle" OnClick="btnDtls_Click" /></td>
                            </tr>
                        </table><%--
                    </ItemTemplate>
                </asp:FormView>--%>
            </center>
            <div>
                <asp:Label ID="msginfo" runat="server" ForeColor="Red" Visible="true" TabIndex="-1"></asp:Label>
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
            <asp:GridView ID="GVConfig" runat="server" SkinID="GridView" DataKeyNames="config_Id" 
                AutoGenerateColumns="False" Visible="True" 
                EmptyDataText="There are no records to display." PageSize="100">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" CommandName="Edit"
                                Text="Edit" Font-Underline="False" TabIndex="7"></asp:LinkButton>
                            <%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="true" CommandName="Delete"
                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                Font-Underline="False" TabIndex="8"></asp:LinkButton>--%>
                        </ItemTemplate>
                        <ItemStyle Wrap="False"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" SortExpression="config_Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="config_Id" runat="server" Value='<%# Bind("config_Id") %>' />
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("config_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="False"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" SortExpression="Date_Value">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Date_Value","{0:dd-MMM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="False"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </asp:Panel>
            </div>
            <asp:ObjectDataSource DataObjectTypeName="EntConfiguration" ID="ObjConfig" runat="server"
                SelectMethod="GetConfig" TypeName="ConfigurationB" UpdateMethod="UpdateRecord">
                <UpdateParameters>
                    <asp:Parameter ConvertEmptyStringToNull="true" DefaultValue="0" Name="config_id" Type="int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>

</form>
</body>
</html>
