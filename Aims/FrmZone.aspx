<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmZone.aspx.vb"
    Inherits="frmZone" Title="Zone Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Zone Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

    <script type="text/javascript" language="javascript">  
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    function Valid()
    {
         var msg;
         msg=NameField100(document.getElementById("<%=txtZone.ClientID %>"),'Zone');  
         if(msg!="") return msg;  
         return true;
    }   
    function Validate()
    {
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
            return true;
        } 
    }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        ZONE MASTER</h1>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:Label ID="lblHO" runat="server" SkinID="lbl" Text="Head Office *"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbHO" runat="server" SkinID="ddl" DataTextField="MyCo_Name"
                                    DataValueField="MyCo_Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblZone" runat="server" SkinID="lbl" Text="Zone *"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtZone" runat="server" AutoCompleteType="Disabled" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<asp:HiddenField ID="hfHOid" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:HiddenField ID="hfID" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnSave" runat="server" SkinID="btn" Text="SAVE" />
                        <asp:Button ID="btnDetails" runat="server" CommandName="Update" SkinID="btn" TabIndex="3"
                            Text="DETAILS" ValidationGroup="edit" CssClass="btnStyle" />&nbsp;
                    </div>
                </center>
                <div>
                </div>
                
                <center>
                    <div>
                        <asp:Label ID="msginfo" runat="server" __designer:dtid="2533274790395927" __designer:wfdid="w1"
                            EnableTheming="True" BackColor="Red" ForeColor="White"></asp:Label>
                        <asp:Label ID="lblmsg" runat="server" BackColor="Green" Font-Bold="False" ForeColor="White"></asp:Label>
                    </div>
                    <div>
                        &nbsp;
                    </div>
                </center>
                <div>
                    <%--  <asp:Panel ID="Panel1" runat="server" Height="50px" SkinID="Pnl"   >--%>
                    <center>
                        <asp:GridView ID="gvZoneMaster" runat="server" DataKeyNames="ZoneID" AutoGenerateColumns="False"
                            Visible="True" AllowPaging="True" EmptyDataText="No records to display" SkinID="GridView">
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
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zone" SortExpression="MaintenanceType">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HOID" runat="server" Value='<%# Bind("HOID") %>'></asp:HiddenField>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ZoneName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ZoneCode" SortExpression="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ZoneCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </center>
                </div>
            </div>
        </ContentTemplate>
        <%-- <triggers>
<asp:AsyncPostBackTrigger ControlID="FormView1" EventName="ItemCommand"></asp:AsyncPostBackTrigger>
</triggers>--%>
    </asp:UpdatePanel>

</form>
</body>
</html>

